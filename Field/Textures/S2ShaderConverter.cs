﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Field.General;
using Field.Models;
//using Field;

namespace Field;

public class S2ShaderConverter
{
    private StringReader hlsl;
    private StringBuilder vfx;
    private List<Texture> textures = new List<Texture>();
    private List<int> samplers = new List<int>();
    private List<Cbuffer> cbuffers = new List<Cbuffer>();
    private List<Input> inputs = new List<Input>();
    private List<Output> outputs = new List<Output>();
    private static bool isTerrain = false;
    private bool bOpacityEnabled = false;
    private bool bUsesFrontFace = false;
    private bool bFixRoughness = false;

    public string vfxStructure = $@"HEADER
{{
	Description = ""Charm Auto-Generated Source 2 Shader""; 
}}

MODES
{{
	VrForward();

	Depth(); 

	ToolsVis( S_MODE_TOOLS_VIS );
	ToolsWireframe( ""vr_tools_wireframe.shader"" );
	ToolsShadingComplexity( ""tools_shading_complexity.shader"" );

	Reflection( ""high_quality_reflections.shader"" );
}}

FEATURES
{{
    #include ""common/features.hlsl""
    Feature( F_DYNAMIC_REFLECTIONS, 0..1, ""Rendering"" );
}}

COMMON
{{
    //alpha
    //frontface
	#include ""common/shared.hlsl""
    #define CUSTOM_MATERIAL_INPUTS
}}

struct VertexInput
{{
    float4 vColorBlendValues : Color0 < Semantic( Color ); >;
	#include ""common/vertexinput.hlsl""
}};

struct PixelInput
{{
    float4 vBlendValues		 : TEXCOORD14;
    float3 o0                : TEXCOORD15;
	#include ""common/pixelinput.hlsl""
}};

VS
{{
	#include ""common/vertex.hlsl""

    BoolAttribute( UsesHighQualityReflections, ( F_HIGH_QUALITY_REFLECTIONS > 0 ) );

	PixelInput MainVs( INSTANCED_SHADER_PARAMS( VS_INPUT i ) )
	{{
		PixelInput o = ProcessVertex( i );
        o.vBlendValues = i.vColorBlendValues;
		o.vBlendValues.a = i.vColorBlendValues.a;
        {(isTerrain ? "float4 r0;\r\n        r0.xyzw = (int4)float4(i.vPositionOs.xyz,0);\r\n        r0.xyzw = float4(0,0,0,0) + r0.xyzw;\r\n        r0.z = r0.w * 65536 + r0.z;\r\n        r0.xyw = float3(0.015625,0.015625,0.000122070313) * r0.xyz;\r\n        o.o0.xyz = r0.xyw;": "")}
		return FinalizeVertex( o );
	}}
}}

PS
{{
    #include ""common/pixel.hlsl""
    #include ""raytracing/reflections.hlsl""
    #define CUSTOM_TEXTURE_FILTERING 
    #define cmp -
    
    #if ( S_MODE_REFLECTIONS )
		#define FinalOutput ReflectionOutput
	#else
		#define FinalOutput float4
	#endif

    //samplers
    
    //Debugs, uncomment for use in shader baker
    //bool g_bDiffuse < Attribute( ""Debug_Diffuse"" ); >;
    //bool g_bRough < Attribute( ""Debug_Rough"" ); >;
    //bool g_bMetal < Attribute( ""Debug_Metal"" ); >;
    //bool g_bNorm < Attribute( ""Debug_Normal"" ); >;
    //bool g_bAO < Attribute( ""Debug_AO"" ); >;
    //bool g_bEmit < Attribute( ""Debug_Emit"" ); >;
    //bool g_bAlpha < Attribute( ""Debug_Alpha"" ); >;";

    public string HlslToVfx(Material material, string hlslText, bool bIsVertexShader, bool bIsTerrain = false)
    {
        //Console.WriteLine("Material: " + material.Hash);
        StringBuilder texSamples = new StringBuilder();
        hlsl = new StringReader(hlslText);
        vfx = new StringBuilder();
        isTerrain = bIsTerrain;
        bOpacityEnabled = false;
        bUsesFrontFace = false;
        ProcessHlslData();

        if (bOpacityEnabled) //This way is stupid but it works
            vfxStructure = vfxStructure.Replace("//alpha", "#ifndef S_ALPHA_TEST\r\n\t#define S_ALPHA_TEST 1\r\n\t#endif\r\n\t#ifndef S_TRANSLUCENT\r\n\t#define S_TRANSLUCENT 0\r\n\t#endif");

        if (bUsesFrontFace)
        {
            vfxStructure = vfxStructure.Replace("//frontface", "#define S_RENDER_BACKFACES 1");
            vfxStructure += "\n    RenderState( CullMode, S_RENDER_BACKFACES ? NONE : DEFAULT );"; //ugh
        }

        for (int i = 0; i < material.Header.PSSamplers.Count; i++)
        {
            if (material.Header.PSSamplers[i].Samplers is null)
                continue;

            var sampler = material.Header.PSSamplers[i].Samplers.Sampler;
            texSamples.AppendLine($"SamplerState g_s{i+1} < Filter({sampler.Header.Filter}); AddressU({sampler.Header.AddressU}); AddressV({sampler.Header.AddressV}); AddressW({sampler.Header.AddressW}); ComparisonFunc({sampler.Header.ComparisonFunc}); MaxAniso({sampler.Header.MaxAnisotropy}); >;");
        }

        vfxStructure = vfxStructure.Replace("//samplers", texSamples.ToString());
        vfx.AppendLine(vfxStructure);

        WriteCbuffers(material, bIsVertexShader);
        WriteFunctionDefinition(material, bIsVertexShader);
        hlsl = new StringReader(hlslText);
        bool success = ConvertInstructions();
        if (!success)
        {
            return "";
        }

        if (!bIsVertexShader)
        {
            AddOutputs();
        }

        //WriteFooter(bIsVertexShader);
        return vfx.ToString();
    }

    private void ProcessHlslData()
    {
        string line = string.Empty;
        bool bFindOpacity = false;
        do
        {
            line = hlsl.ReadLine();
            if (line != null)
            {
                if (line.Contains("r0,r1")) // at end of function definition
                {
                    bFindOpacity = true;
                }

                if (bFindOpacity)
                {
                    if (line.Contains("discard") || line.Contains("o0.w = r"))
                    {
                        bOpacityEnabled = true;
                        break;
                    }
                    continue;
                }

                if (line.Contains("Texture"))
                {
                    Texture texture = new Texture();
                    texture.Dimension = line.Split("<")[0];
                    texture.Type = line.Split("<")[1].Split(">")[0];
                    texture.Variable = line.Split("> ")[1].Split(" :")[0];
                    texture.Index = Int32.TryParse(new string(texture.Variable.Skip(1).ToArray()), out int index) ? index : -1;
                    textures.Add(texture);
                }
                else if (line.Contains("SamplerState"))
                {
                    samplers.Add(line.Split("(")[1].Split(")")[0].Last() - 48);
                }
                else if (line.Contains("cbuffer"))
                {
                    hlsl.ReadLine();
                    line = hlsl.ReadLine();
                    Cbuffer cbuffer = new Cbuffer();
                    cbuffer.Variable = "cb" + line.Split("cb")[1].Split("[")[0];
                    cbuffer.Index = Int32.TryParse(new string(cbuffer.Variable.Skip(2).ToArray()), out int index) ? index : -1;
                    cbuffer.Count = Int32.TryParse(new string(line.Split("[")[1].Split("]")[0]), out int count) ? count : -1;
                    cbuffer.Type = line.Split("cb")[0].Trim();
                    cbuffers.Add(cbuffer);
                }
                else if (line.Contains(" v") && line.Contains(" : ") && !line.Contains("?"))
                {
                    Input input = new Input();
                    input.Variable = "v" + line.Split("v")[1].Split(" : ")[0];
                    input.Index = Int32.TryParse(new string(input.Variable.Skip(1).ToArray()), out int index) ? index : -1;
                    input.Semantic = line.Split(" : ")[1].Split(",")[0];
                    if(input.Semantic == "SV_isFrontFace0")
                        bUsesFrontFace = true;
                    input.Type = line.Split(" v")[0].Trim();
                    inputs.Add(input);
                }
                else if (line.Contains("out") && line.Contains(" : "))
                {
                    Output output = new Output();
                    output.Variable = "o" + line.Split(" o")[2].Split(" : ")[0];
                    output.Index = Int32.TryParse(new string(output.Variable.Skip(1).ToArray()), out int index) ? index : -1;
                    output.Semantic = line.Split(" : ")[1].Split(",")[0];
                    output.Type = line.Split("out ")[1].Split(" o")[0];
                    outputs.Add(output);
                }
            }

        } while (line != null);
    }

    private void WriteCbuffers(Material material, bool bIsVertexShader)
    {
        // Try to find matches, pixel shader has Unk2D0 Unk2E0 Unk2F0 Unk300 available
        foreach (var cbuffer in cbuffers)
        {
            vfx.AppendLine($"   static {cbuffer.Type} {cbuffer.Variable}[{cbuffer.Count}] = ").AppendLine(" {");
            
            dynamic data = null;
            if (!bIsVertexShader)
            {
                if (cbuffer.Count == material.Header.Unk2D0.Count)
                {
                    data = material.Header.Unk2D0;
                }
                else if (cbuffer.Count == material.Header.Unk2E0.Count)
                {
                    data = material.Header.Unk2E0;
                }
                else if (cbuffer.Count == material.Header.Unk300.Count)
                {
                    data = material.Header.Unk300;
                }
                else
                {
                    if (material.Header.PSVector4Container.Hash != 0xffff_ffff)
                    {
                        // Try the Vector4 storage file
                        DestinyFile container = new DestinyFile(PackageHandler.GetEntryReference(material.Header.PSVector4Container));
                        byte[] containerData = container.GetData();
                        int num = containerData.Length / 16;
                        if (cbuffer.Count == num)
                        {
                            List<Vector4> float4s = new List<Vector4>();
                            for (int i = 0; i < containerData.Length / 16; i++)
                            {
                                float4s.Add(StructConverter.ToStructure<Vector4>(containerData.Skip(i*16).Take(16).ToArray()));
                            }

                            data = float4s;
                        }                        
                    }

                }
            }

            for (int i = 0; i < cbuffer.Count; i++)
            {
                switch (cbuffer.Type)
                {
                    case "float4":
                        if (data == null) vfx.AppendLine("      float4(0.0, 0.0, 0.0, 0.0), //null"+i);
                        else
                        {
                            try
                            {
                                if (data[i] is Vector4)
                                {
                                    vfx.AppendLine($"       float4({data[i].X}, {data[i].Y}, {data[i].Z}, {data[i].W}), //"+i);
                                }
                                else
                                {
                                    var x = data[i].Unk00.X; // really bad but required
                                    vfx.AppendLine($"       float4({x}, {data[i].Unk00.Y}, {data[i].Unk00.Z}, {data[i].Unk00.W}), //"+i);
                                }
                            }
                            catch (Exception e)  // figure out whats up here, taniks breaks it
                            {
                                vfx.AppendLine("        float4(0.0, 0.0, 0.0, 0.0), //Exception"+i);
                            }
                        }
                        break;
                    case "float3":
                        if (data == null) vfx.AppendLine("      float3(0.0, 0.0, 0.0), //null"+i);
                        else vfx.AppendLine($"      float3({data[i].Unk00.X}, {data[i].Unk00.Y}, {data[i].Unk00.Z}), //"+i);
                        break;
                    case "float":
                        if (data == null) vfx.AppendLine("    float(0.0), //null"+i);
                        else vfx.AppendLine($"      float4({data[i].Unk00}), //"+i);
                        break;
                    default:
                        throw new NotImplementedException();
                }  
            }

            vfx.AppendLine("    };");
        }
    }
    
    private void WriteFunctionDefinition(Material material, bool bIsVertexShader)
    {
        if (!bIsVertexShader)
        {
            foreach (var e in material.Header.PSTextures)
            {
                if (e.Texture != null)
                {
                    string type = e.Texture.IsSrgb() ? "Srgb" : "Linear";

					vfx.AppendLine($"   CreateInputTexture2D( TextureT{e.TextureIndex}, {type}, 8, \"\", \"\",  \"Textures,10/{e.TextureIndex}\", Default3( 1.0, 1.0, 1.0 ));");
                    vfx.AppendLine($"   CreateTexture2DWithoutSampler( g_t{e.TextureIndex} )  < Channel( RGBA,  Box( TextureT{e.TextureIndex} ), {type} ); OutputFormat( BC7 ); SrgbRead( {e.Texture.IsSrgb()} ); >; ");
                    vfx.AppendLine($"   TextureAttribute(g_t{e.TextureIndex}, g_t{e.TextureIndex});\n"); //Prevents some inputs not appearing for some reason
                }
            }
            
            if(isTerrain) //Terrain has 4 dyemaps per shader, from what ive seen
            {
                vfx.AppendLine($"   CreateInputTexture2D( TextureT14_0, Linear, 8, \"\", \"\",  \"Textures,10/14\", Default3( 1.0, 1.0, 1.0 ));");
                vfx.AppendLine($"   CreateTexture2DWithoutSampler( g_t14_0 )  < Channel( RGBA,  Box( TextureT14_0 ), Linear ); OutputFormat( BC7 ); SrgbRead( False ); >; ");
                vfx.AppendLine($"   TextureAttribute(g_t14_0, g_t14_0);\n");

                vfx.AppendLine($"   CreateInputTexture2D( TextureT14_1, Linear, 8, \"\", \"\",  \"Textures,10/15\", Default3( 1.0, 1.0, 1.0 ));");
                vfx.AppendLine($"   CreateTexture2DWithoutSampler( g_t14_1 )  < Channel( RGBA,  Box( TextureT14_1 ), Linear ); OutputFormat( BC7 ); SrgbRead( False ); >; ");
                vfx.AppendLine($"   TextureAttribute(g_t14_1, g_t14_1);\n");

                vfx.AppendLine($"   CreateInputTexture2D( TextureT14_2, Linear, 8, \"\", \"\",  \"Textures,10/16\", Default3( 1.0, 1.0, 1.0 ));");
                vfx.AppendLine($"   CreateTexture2DWithoutSampler( g_t14_2 )  < Channel( RGBA,  Box( TextureT14_2 ), Linear ); OutputFormat( BC7 ); SrgbRead( False ); >; ");
                vfx.AppendLine($"   TextureAttribute(g_t14_2, g_t14_2);\n");

                vfx.AppendLine($"   CreateInputTexture2D( TextureT14_3, Linear, 8, \"\", \"\",  \"Textures,10/17\", Default3( 1.0, 1.0, 1.0 ));");
                vfx.AppendLine($"   CreateTexture2DWithoutSampler( g_t14_3 )  < Channel( RGBA,  Box( TextureT14_3 ), Linear ); OutputFormat( BC7 ); SrgbRead( False ); >; ");
                vfx.AppendLine($"   TextureAttribute(g_t14_3, g_t14_3);\n");
            }

            vfx.AppendLine("    FinalOutput MainPs( PixelInput i ) : SV_Target0");
            vfx.AppendLine("    {");

            vfx.AppendLine(@"       float3 vPositionWs = i.vPositionWithOffsetWs.xyz + g_vHighPrecisionLightingOffsetWs.xyz;
        float3 vCameraToPositionDirWs = CalculateCameraToPositionDirWs( vPositionWs.xyz );
        float3 vNormalWs = normalize( i.vNormalWs.xyz ); 
        float3 vTangentUWs = i.vTangentUWs.xyz;
        float3 vTangentVWs = i.vTangentVWs.xyz;
        //float3 vTangentViewDir = Vec3WsToTs( vCameraToPositionDirWs.xyz, vNormalWs.xyz, vTangentUWs.xyz, vTangentVWs.xyz ); //Not needed anymore, keeping in case
        //vCameraToPositionDirWs = vCameraToPositionDirWs/-vCameraToPositionDirWs.z; //idk if really needed
        ");

            // Output render targets, todo support vertex shader
            vfx.AppendLine("        float4 o0,o1,o2;");
            vfx.AppendLine("        float alpha = 1;");

            if(isTerrain) //variables are different for terrain for whatever reason, kinda have to guess
            {
                vfx.AppendLine("        float4 v0 = {i.o0,1};"); //Detail uv?
                vfx.AppendLine("        float4 v1 = {i.o0*0.05,1};"); //Main uv?
                vfx.AppendLine("        float4 v2 = {vNormalWs,1};"); 
                vfx.AppendLine("        float4 v3 = {vTangentUWs,1};");
                vfx.AppendLine("        float4 v4 = {vTangentVWs,1};");
                vfx.AppendLine("        float4 v5 = i.vBlendValues;"); //For dyemaps
            }
            else
            {
                vfx.AppendLine("        float4 v0 = {vNormalWs,1};"); //Mesh world normals
                vfx.AppendLine("        float4 v1 = {vTangentUWs,1};");
                vfx.AppendLine("        float4 v2 = {vTangentVWs,1};");
                vfx.AppendLine("        float4 v3 = {i.vTextureCoords, 1,1};"); //UVs
                vfx.AppendLine("        float4 v4 = {0,0,0,0};"); //Don't really know
                vfx.AppendLine("        float4 v5 = i.vBlendValues;"); //Vertex color.
                //vfx.AppendLine("        uint v6 = 1;"); //Usually FrontFace but can also be v7
            }

            foreach (var i in inputs)
            {
                if (i.Type == "uint")
                {
                    if(i.Semantic == "SV_isFrontFace0")
                        vfx.AppendLine($"       int {i.Variable} = i.face;");
                    else
                        vfx.AppendLine($"       int {i.Variable} = {i.Variable};");
                }
            }
        }
    }

    private bool ConvertInstructions()
    {
        Dictionary<int, Texture> texDict = new Dictionary<int, Texture>();

        foreach (var texture in textures)
        {
            texDict.Add(texture.Index, texture);
        }
        List<int> sortedIndices = texDict.Keys.OrderBy(x => x).ToList();
        List<Texture> sortedTextures = texDict.Values.OrderBy(x => x.Variable).ToList();
        string line = hlsl.ReadLine();
        if (line == null)
        {
            // its a broken pixel shader that uses some kind of memory textures
            return false;
        }
        while (!line.Contains("SV_TARGET2"))
        {
            line = hlsl.ReadLine();
            if (line == null)
            {
                // its a broken pixel shader that uses some kind of memory textures
                return false;
            }
        }
        hlsl.ReadLine();
        do
        {
            line = hlsl.ReadLine();
            if (line != null)
            {
                if (line.Contains("cb12[7].xyz + -v4.xyz")) //cb12 is view scope
                {
					vfx.AppendLine(line.Replace("cb12[7].xyz", "vCameraToPositionDirWs"));
				}
                else if (line.Contains("v4.xy * cb")) //might be a detail uv or something when v4 is used like this, idk
                {
                    vfx.AppendLine(line.Replace("v4", "(v3.xy*5)"));
                }
                else if (line.Contains("while (true)"))
                {
                    vfx.AppendLine(line.Replace("while (true)", "       [unroll(20)] while (true)"));
                }
                else if (line.Contains("return;"))
                {
                    break;
                }
                else if (line.Contains("Sample"))
                {
                    var equal = line.Split("=")[0];
                    var texIndex = Int32.Parse(line.Split(".Sample")[0].Split("t")[1]);
                    var sampleIndex = Int32.Parse(line.Split("(s")[1].Split("_s,")[0]);
                    var sampleUv = line.Split(", ")[1].Split(")")[0];
                    var dotAfter = line.Split(").")[1];
                    // todo add dimension

                    if(texIndex == 14) //THIS IS SO SO BAD
                    {
                        vfx.AppendLine($"bool red = i.vBlendValues.x > 0.5;\r\n" +
                            $"        bool green = i.vBlendValues.y > 0.5;\r\n" +
                            $"        bool blue = i.vBlendValues.z > 0.5;\r\n\r\n" +
                            $"        if (red && !green && !blue)\r\n" +
                            $"        {{\r\n" +
                            $"            {equal} = Tex2DS(g_t14_0, TextureFiltering, {sampleUv}).{dotAfter};\r\n" +
                            $"        }}\r\n" +
                            $"        else if (!red && green && !blue)\r\n" +
                            $"        {{\r\n" +
                            $"            {equal} = Tex2DS(g_t14_1, TextureFiltering, {sampleUv}).{dotAfter};\r\n" +
                            $"        }}\r\n" +
                            $"        else if (!red && !green && blue)\r\n" +
                            $"        {{\r\n" +
                            $"            {equal} = Tex2DS(g_t14_2, TextureFiltering, {sampleUv}).{dotAfter};\r\n" +
                            $"        }}\r\n" +
                            $"        else if (red && green && blue)\r\n" +
                            $"        {{\r\n" +
                            $"            {equal} = Tex2DS(g_t14_3, TextureFiltering, {sampleUv}).{dotAfter};\r\n" +
                            $"        }}");
                    }
                    else 
                    {
                        vfx.AppendLine($"       {equal}= Tex2DS(g_t{texIndex}, g_s{sampleIndex}, {sampleUv}).{dotAfter}");
                    } 
                }
                else if (line.Contains("CalculateLevelOfDetail"))
                {
                    var equal = line.Split("=")[0];
                    var texIndex = Int32.Parse(line.Split(".CalculateLevelOfDetail")[0].Split("t")[1]);
                    var sampleIndex = Int32.Parse(line.Split("(s")[1].Split("_s,")[0]);
                    var sampleUv = line.Split(", ")[1].Split(")")[0];

                    vfx.AppendLine($"       {equal}= g_t{texIndex}.CalculateLevelOfDetail(g_s{sampleIndex}, {sampleUv});");
                }
                else if (line.Contains("Load"))
                {
                    var equal = line.Split("=")[0];
                    var texIndex = Int32.Parse(line.Split(".Load")[0].Split("t")[1]); 
                    var sampleUv = line.Split("(")[1].Split(")")[0];

                    vfx.AppendLine($"       {equal}= g_t{texIndex+1}.Load({sampleUv});"); //Usually seen in decals, the texture isnt actually valid though? Probably from gbuffer
                }
                else if (line.Contains("o0.w = r")) //o0.w = r(?)
                {
                    vfx.AppendLine($"       {line}");
                    vfx.AppendLine($"       alpha = 1 - o0.w;");
                }
                else if (line.Contains("discard"))
                {
                    vfx.AppendLine(line.Replace("discard", "        { alpha = 0; }")); //sometimes o0.w is used for alpha instead on some shaders
                }
                else if (line.Contains("o1.xyzw = float4(0,0,0,0);"))
                {
                    vfx.AppendLine(line.Replace("o1.xyzw = float4(0,0,0,0);", "        o1.xyzw = float4(1,1,1,0);")); //decals(?) have 0 normals sometimes, dont want that
                    bFixRoughness = true;
                }
                else
                {
                    vfx.AppendLine($"       {line}");
                }
                vfx.Replace("∞", "1.#INF");
            }
        } while (line != null);

        return true;
    }

    private void AddOutputs()
    {
        Dictionary<int, Texture> texDict = new Dictionary<int, Texture>();

        foreach (var texture in textures)
        {
            texDict.Add(texture.Index, texture);
        }
        List<Texture> sortedTextures = texDict.Values.OrderBy(x => x.Variable).ToList();
        //{(bOpacityEnabled ? "" : " - float3(0.5, 0.5, 0.5)")}; Guess "- float3(0.5, 0.5, 0.5)" is actually always needed regardless of transparency? Messes with roughness otherwise
        string outputString = @$"

        // Normal
        float3 biased_normal = o1.xyz - float3(0.5, 0.5, 0.5); 
        float normal_length = length(biased_normal);
        float3 normal_in_world_space = biased_normal / normal_length;
 
        float smoothness = saturate(8 * ({(bFixRoughness ? "0" : "normal_length")} - 0.375));
        
        Material mat = Material::From(i, 
                    float4(o0.xyz, alpha), //albedo, alpha
                    float4(0.5, 0.5, 1, 1), //Normal, gets set later
                    float4(1 - smoothness, saturate(o2.x), saturate(o2.y * 2), 1), //rough, metal, ao
                    float3( 1.0f, 1.0f, 1.0f ), //tint
                    clamp((o2.y - 0.5) * 2 * 6 * o0.xyz, 0, 100)); //emission

        mat.Transmission = o2.z;
        mat.Normal = normal_in_world_space; //Normal is already in world space so no need to convert in Material::From

        //if(g_bDiffuse)
        //{{
        //    mat.Albedo = 0;
        //    mat.Emission = o0.xyz;
        //}}
        //if(g_bRough)
        //{{
        //    mat.Albedo = 0;
        //    mat.Emission = 1 - smoothness;
        //}}
        //if(g_bMetal)
        //{{
        //    mat.Albedo = 0;
        //    mat.Emission = saturate(o2.x);
        //}}
        //if(g_bNorm)
        //{{
        //    mat.Albedo = 0;
        //    mat.Emission = SrgbGammaToLinear(PackNormal3D(Vec3WsToTs(normal_in_world_space.xyz, i.vNormalWs.xyz, vTangentUWs.xyz, vTangentVWs.xyz)));
        //}}
        //if(g_bAO)
        //{{
        //    mat.Albedo = 0;
        //    mat.Emission = saturate(o2.y * 2);
        //}}
        //if(g_bEmit)
        //{{
        //    mat.Albedo = 0;
        //    mat.Emission = (o2.y - 0.5);
        //}}
        //if(g_bAlpha)
        //{{
        //    mat.Albedo = 0;
        //    mat.Emission = alpha;
        //}}

        #if ( S_MODE_REFLECTIONS )
		{{
			return Reflections::From( i, mat, SampleCountIntersection );
		}}
        #else
		{{
            return ShadingModelStandard::Shade(i, mat);
        }}
        #endif
    }}
}}";
 
        //if(bOpacityEnabled)
        //{
        //    outputString = outputString.Replace("float3 biased_normal = o1.xyz - float3(0.5, 0.5, 0.5);", "float3 biased_normal = o1.xyz;");
        //}
        vfx.AppendLine(outputString);
    }
}