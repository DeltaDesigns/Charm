﻿using System.Diagnostics;
using Arithmic;

namespace Tiger.Schema.Static;

public class StaticPart : MeshPart
{
    public StaticPart(SStaticPart terrainPartEntry) : base()
    {
        IndexOffset = terrainPartEntry.IndexOffset;
        IndexCount = terrainPartEntry.IndexCount;
        LodCategory = terrainPartEntry.Lod.DetailLevel;
        PrimitiveType = PrimitiveType.TriangleStrip;
        MaterialType = Shaders.MaterialType.Opaque;
    }

    public StaticPart(SMeshGroup terrainPartEntry) : base()
    {
        IndexOffset = terrainPartEntry.IndexOffset;
        IndexCount = terrainPartEntry.IndexCount;
        LodCategory = ELodCategory.LowPolyGeom1;
        PrimitiveType = PrimitiveType.TriangleStrip;
        MaterialType = Shaders.MaterialType.Opaque;
    }

    public StaticPart(SStaticMeshPart staticPartEntry) : base()
    {
        IndexOffset = staticPartEntry.IndexOffset;
        IndexCount = staticPartEntry.IndexCount;
        LodCategory = staticPartEntry.Lod.DetailLevel;
        PrimitiveType = (PrimitiveType)staticPartEntry.PrimitiveType;
        MaterialType = Shaders.MaterialType.Opaque;
    }

    public StaticPart(SStaticMeshDecal decalPartEntry) : base()
    {
        IndexOffset = decalPartEntry.IndexOffset;
        IndexCount = decalPartEntry.IndexCount;
        LodCategory = decalPartEntry.Lod.DetailLevel;
        PrimitiveType = (PrimitiveType)decalPartEntry.PrimitiveType;
        MaterialType = Shaders.MaterialType.Transparent;
    }

    public void GetAllData(SStaticMeshBuffers buffers, SStaticMesh container)
    {
        Indices = buffers.Indices.GetIndexData(PrimitiveType, IndexOffset, IndexCount);
        // Get unique vertex indices we need to get data for
        HashSet<uint> uniqueVertexIndices = new HashSet<uint>();
        foreach (UIntVector3 index in Indices)
        {
            uniqueVertexIndices.Add(index.X);
            uniqueVertexIndices.Add(index.Y);
            uniqueVertexIndices.Add(index.Z);
        }
        VertexIndices = uniqueVertexIndices.ToList();
        // Have to call it like this b/c we don't know the format of the vertex data here

        if (Strategy.CurrentStrategy <= TigerStrategy.DESTINY2_SHADOWKEEP_2999)
        {
            DXBCIOSignature[] inputSignatures = Material.VertexShader.InputSignatures.ToArray();

            List<int> strides = new();
            if (buffers.Vertices0 != null) strides.Add(buffers.Vertices0.TagData.Stride);
            if (buffers.Vertices1 != null) strides.Add(buffers.Vertices1.TagData.Stride);
            if (buffers.Vertices2 != null) strides.Add(buffers.Vertices2.TagData.Stride);
            Helpers.DecorateSignaturesWithBufferIndex(ref inputSignatures, strides); // absorb into the getter probs

            Log.Debug($"Reading vertex buffers {buffers.Vertices0.Hash}/{buffers.Vertices0.TagData.Stride}/{inputSignatures.Where(s => s.BufferIndex == 0).DebugString()} and {buffers.Vertices1?.Hash}/{buffers.Vertices1?.TagData.Stride}/{inputSignatures.Where(s => s.BufferIndex == 1).DebugString()}");
            buffers.Vertices0.ReadVertexDataSignatures(this, uniqueVertexIndices, inputSignatures.Where(s => s.BufferIndex == 0).ToList());
            buffers.Vertices1?.ReadVertexDataSignatures(this, uniqueVertexIndices, inputSignatures.Where(s => s.BufferIndex == 1).ToList());
        }
        else
        {
            buffers.Vertices0.ReadVertexData(this, uniqueVertexIndices);
            buffers.Vertices1?.ReadVertexData(this, uniqueVertexIndices);
            buffers.Vertices2?.ReadVertexData(this, uniqueVertexIndices);
        }

        Debug.Assert(VertexPositions.Count == VertexTexcoords0.Count && VertexPositions.Count == VertexNormals.Count);

        TransformData(container);
    }

    public void GetDecalData(SStaticMeshDecal mesh, SStaticMesh container)
    {
        Indices = mesh.Indices.GetIndexData(PrimitiveType, IndexOffset, IndexCount);
        // Get unique vertex indices we need to get data for
        HashSet<uint> uniqueVertexIndices = new HashSet<uint>();
        foreach (UIntVector3 index in Indices)
        {
            uniqueVertexIndices.Add(index.X);
            uniqueVertexIndices.Add(index.Y);
            uniqueVertexIndices.Add(index.Z);
        }
        VertexIndices = uniqueVertexIndices.ToList();
        // Have to call it like this b/c we don't know the format of the vertex data here
        if (Strategy.CurrentStrategy <= TigerStrategy.DESTINY2_SHADOWKEEP_2999)
        {
            List<DXBCIOSignature> inputSignatures = mesh.Material.VertexShader.InputSignatures;
            int b0Stride = mesh.Vertices0.TagData.Stride;
            int b1Stride = mesh.Vertices1?.TagData.Stride ?? 0;
            List<DXBCIOSignature> inputSignatures0 = new();
            List<DXBCIOSignature> inputSignatures1 = new();
            int stride = 0;
            foreach (DXBCIOSignature inputSignature in inputSignatures)
            {
                if (stride < b0Stride)
                {
                    inputSignatures0.Add(inputSignature);
                }
                else
                {
                    inputSignatures1.Add(inputSignature);
                }

                if (inputSignature.Semantic == DXBCSemantic.Colour)
                {
                    stride += inputSignature.GetNumberOfComponents() * 1;  // 1 byte per component
                }
                else
                {
                    stride += inputSignature.GetNumberOfComponents() * 2;  // 2 bytes per component
                }
                // todo entities can have 4 bytes per component, although its isolated for cloth so we can probably account for it
            }
            Debug.Assert(b0Stride + b1Stride == stride);

            Log.Debug($"Reading vertex buffers {mesh.Vertices0.Hash}/{b0Stride}/{inputSignatures0.DebugString()} and {mesh.Vertices1?.Hash}/{b1Stride}/{inputSignatures1.DebugString()}");
            mesh.Vertices0.ReadVertexDataSignatures(this, uniqueVertexIndices, inputSignatures0);
            mesh.Vertices1?.ReadVertexDataSignatures(this, uniqueVertexIndices, inputSignatures1);
        }
        else
        {
            mesh.Vertices0.ReadVertexData(this, uniqueVertexIndices);
            mesh.Vertices1?.ReadVertexData(this, uniqueVertexIndices);
            mesh.Vertices2?.ReadVertexData(this, uniqueVertexIndices);
        }

        TransformData(container);
    }

    private void TransformData(SStaticMesh container)
    {
        if (Strategy.CurrentStrategy >= TigerStrategy.DESTINY2_BEYONDLIGHT_3402)
        {
            var t = (container.StaticData as DESTINY2_BEYONDLIGHT_3402.StaticMeshData).TagData;
            TransformPositions(t.ModelTransform);
            TransformUVs(new Vector2(t.TexcoordScale, t.TexcoordScale), t.TexcoordTranslation);
        }
        else
        {
            TransformPositions(container.ModelTransform);
            TransformUVs(container.TexcoordScale, container.TexcoordTranslation);
        }
    }

    private void TransformUVs(Vector2 texcoordScale, Vector2 texcoordTranslation)
    {
        for (int i = 0; i < VertexTexcoords0.Count; i++)
        {
            VertexTexcoords0[i] = new Vector2(
                VertexTexcoords0[i].X * texcoordScale.X + texcoordTranslation.X,
                VertexTexcoords0[i].Y * -texcoordScale.Y + 1 - texcoordTranslation.Y
            );
        }
    }

    private void TransformPositions(Vector4 modelTransform)
    {
        for (int i = 0; i < VertexPositions.Count; i++)
        {
            // i think theres a different scale and offset for model data vs decals... like 99% sure
            VertexPositions[i] = new Vector4(
                VertexPositions[i].X * modelTransform.W + modelTransform.X,
                VertexPositions[i].Y * modelTransform.W + modelTransform.Y,
                VertexPositions[i].Z * modelTransform.W + modelTransform.Z,
                VertexPositions[i].W
            );
        }
    }
}
