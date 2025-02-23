﻿using ConcurrentCollections;
using Tiger.Schema;

namespace Tiger.Exporters;

public class MaterialExporter : AbstractExporter
{
    public override void Export(Exporter.ExportEventArgs args)
    {
        ConcurrentHashSet<Texture> mapTextures = new();
        ConcurrentHashSet<ExportMaterial> mapMaterials = new();

        Parallel.ForEach(args.Scenes, scene =>
        {
            if (scene.Type is ExportType.Entity or ExportType.Static or ExportType.API)
            {
                ConcurrentHashSet<Texture> textures = scene.Textures;

                foreach (ExportMaterial material in scene.Materials)
                {
                    foreach (STextureTag texture in material.Material.EnumerateVSTextures())
                    {
                        if (texture.Texture == null)
                        {
                            continue;
                        }
                        textures.Add(texture.Texture);
                    }
                    foreach (STextureTag texture in material.Material.EnumeratePSTextures())
                    {
                        if (texture.Texture == null)
                        {
                            continue;
                        }
                        textures.Add(texture.Texture);
                    }

                    string shaderSaveDirectory = $"{args.OutputDirectory}/{scene.Name}";
                    material.Material.SaveShaders(shaderSaveDirectory, material.Type, material.IsTerrain);
                    material.Material.SaveVertexShader(shaderSaveDirectory);
                }

                string textureSaveDirectory = $"{args.OutputDirectory}/{scene.Name}/Textures";
                Directory.CreateDirectory(textureSaveDirectory);
                foreach (Texture texture in textures)
                {
                    texture.SavetoFile($"{textureSaveDirectory}/{texture.Hash}");
                }
            }
            else
            {
                mapTextures.UnionWith(scene.Textures);
                foreach (ExportMaterial material in scene.Materials)
                {
                    foreach (STextureTag texture in material.Material.EnumerateVSTextures())
                    {
                        mapTextures.Add(texture.Texture);
                    }
                    foreach (STextureTag texture in material.Material.EnumeratePSTextures())
                    {
                        mapTextures.Add(texture.Texture);
                    }

                    if (material.Material.VertexShader != null || material.Material.PixelShader != null)
                    {
                        mapMaterials.Add(material);
                    }
                }
            }
        });

        string textureSaveDirectory = $"{args.OutputDirectory}/Maps/Textures";
        Directory.CreateDirectory(textureSaveDirectory);
        foreach (Texture texture in mapTextures)
        {
            if (texture is null)
                continue;
            texture.SavetoFile($"{textureSaveDirectory}/{texture.Hash}");
            if (texture.IsCubemap())
            {
                SBoxHandler.SaveVTEX(texture, textureSaveDirectory);
            }
        }

        string shaderSaveDirectory = $"{args.OutputDirectory}/Maps";
        Directory.CreateDirectory(shaderSaveDirectory);
        foreach (ExportMaterial material in mapMaterials)
        {
            material.Material.SaveShaders(shaderSaveDirectory, material.Type, material.IsTerrain);
        }
    }
}
