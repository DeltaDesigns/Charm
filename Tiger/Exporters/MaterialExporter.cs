﻿using ConcurrentCollections;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Tiger.Schema;

namespace Tiger.Exporters;

// TODO: Clean this up
public class MaterialExporter : AbstractExporter
{
    public override void Export(Exporter.ExportEventArgs args)
    {
        var _config = ConfigSubsystem.Get();

        ConcurrentHashSet<Texture> mapTextures = new();
        ConcurrentHashSet<ExportMaterial> mapMaterials = new();
        ConcurrentHashSet<ExportMaterial> materials = new();

        bool saveMats = _config.GetExportMaterials();
        bool saveIndiv = _config.GetIndvidualStaticsEnabled();

        Parallel.ForEach(args.Scenes, scene =>
        {
            if (scene.Type is ExportType.Entity or ExportType.Static or ExportType.API or ExportType.D1API)
            {
                ConcurrentHashSet<Texture> textures = scene.Textures;

                foreach (ExportMaterial material in scene.Materials)
                {
                    materials.Add(material);
                    foreach (STextureTag texture in material.Material.Vertex.EnumerateTextures())
                    {
                        if (texture.GetTexture() == null)
                            continue;

                        textures.Add(texture.GetTexture());
                    }
                    foreach (STextureTag texture in material.Material.Pixel.EnumerateTextures())
                    {
                        if (texture.GetTexture() == null)
                            continue;

                        textures.Add(texture.GetTexture());
                    }
                }

                string textureSaveDirectory = args.AggregateOutput ? args.OutputDirectory : Path.Join(args.OutputDirectory, scene.Name);
                textureSaveDirectory = $"{textureSaveDirectory}/Textures";

                Directory.CreateDirectory(textureSaveDirectory);
                foreach (Texture texture in textures)
                {
                    texture.SavetoFile($"{textureSaveDirectory}/{texture.Hash}");
                }
                foreach (ExportMaterial material in materials)
                {
                    string shaderSaveDirectory = args.AggregateOutput ? args.OutputDirectory : Path.Join(args.OutputDirectory, scene.Name);
                    Directory.CreateDirectory(shaderSaveDirectory);
                    material.Material.Export(shaderSaveDirectory);
                }
            }
            else
            {
                mapTextures.UnionWith(scene.Textures);
                foreach (ExportMaterial material in scene.Materials)
                {
                    mapMaterials.Add(material);
                    foreach (STextureTag texture in material.Material.Vertex.EnumerateTextures())
                    {
                        if (texture.GetTexture() == null)
                            continue;

                        mapTextures.Add(texture.GetTexture());
                    }
                    foreach (STextureTag texture in material.Material.Pixel.EnumerateTextures())
                    {
                        if (texture.GetTexture() == null)
                            continue;

                        mapTextures.Add(texture.GetTexture());
                    }
                }

                foreach (var cubemap in scene.Cubemaps)
                {
                    if (cubemap.CubemapTexture is null)
                        continue;

                    mapTextures.Add(cubemap.CubemapTexture);

                    if (ConfigSubsystem.Get().GetS2ShaderExportEnabled())
                    {
                        string saveDirectory = args.AggregateOutput ? args.OutputDirectory : Path.Join(args.OutputDirectory, $"Maps");
                        saveDirectory = $"{saveDirectory}/Textures";
                        Source2Handler.SaveVTEX(cubemap.CubemapTexture, saveDirectory);
                    }
                }
            }
        });

        foreach (Texture texture in mapTextures)
        {
            if (texture is null)
                continue;

            string textureSaveDirectory = args.AggregateOutput ? args.OutputDirectory : Path.Join(args.OutputDirectory, $"Maps");
            textureSaveDirectory = $"{textureSaveDirectory}/Textures";
            Directory.CreateDirectory(textureSaveDirectory);

            texture.SavetoFile($"{textureSaveDirectory}/{texture.Hash}");
        }

        if (saveMats)
        {
            foreach (ExportMaterial material in mapMaterials)
            {
                string shaderSaveDirectory = args.AggregateOutput ? args.OutputDirectory : Path.Join(args.OutputDirectory, $"Maps");
                Directory.CreateDirectory(shaderSaveDirectory);
                material.Material.Export(shaderSaveDirectory);
            }
        }

        // TODO?: Move this to a global AbstractExporter?

        if (Exporter.Get().GetOrCreateGlobalScene().TryGetItem<SMapAtmosphere>(out SMapAtmosphere atmosphere))
        {
            List<Texture> AtmosTextures = new();
            if (atmosphere.Lookup0 != null)
                AtmosTextures.Add(atmosphere.Lookup0);
            if (atmosphere.Lookup1 != null)
                AtmosTextures.Add(atmosphere.Lookup1);
            if (atmosphere.Lookup2 != null)
                AtmosTextures.Add(atmosphere.Lookup2);
            if (atmosphere.Lookup3 != null)
                AtmosTextures.Add(atmosphere.Lookup3);
            if (atmosphere.Lookup4 != null)
                AtmosTextures.Add(atmosphere.Lookup4);

            string savePath = args.AggregateOutput ? args.OutputDirectory : Path.Join(args.OutputDirectory, $"Maps");
            string texSavePath = $"{savePath}/Textures/Atmosphere";
            Directory.CreateDirectory(texSavePath);

            foreach (var tex in AtmosTextures)
            {
                // Not ideal but it works
                TextureExtractor.SaveTextureToFile($"{texSavePath}/{tex.Hash}", tex.IsVolume() ? Texture.FlattenVolume(tex.GetScratchImage(true)) : tex.GetScratchImage());
                if (_config.GetS2ShaderExportEnabled())
                    Source2Handler.SaveVTEX(tex, $"{texSavePath}", "Atmosphere");
            }

            string dataSavePath = $"{savePath}/Rendering";
            Directory.CreateDirectory(dataSavePath);

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Converters = new List<JsonConverter> { new StringEnumConverter() }
            };
            File.WriteAllText($"{dataSavePath}/Atmosphere.json", JsonConvert.SerializeObject(atmosphere, jsonSettings));
        }
    }
}
