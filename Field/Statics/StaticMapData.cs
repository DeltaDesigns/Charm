﻿using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using Field.Entities;
using Field.General;
using Field.Models;
using Field.Statics;
using static Field.General.PackageHandler;

namespace Field;

public class StaticMapData : Tag
{
    public D2Class_AD938080 Header;

    public StaticMapData(TagHash hash) : base(hash)
    {
    }

    protected override void ParseStructs()
    {
        Header = ReadHeader<D2Class_AD938080>();
    }

    public void LoadArrangedIntoFbxScene(FbxHandler fbxHandler)
    {
        Parallel.ForEach(Header.InstanceCounts, c =>
        {
            var s = Header.Statics[c.StaticIndex].Static;
            var parts = s.Load(ELOD.MostDetail);
            fbxHandler.AddStaticInstancesToScene(parts, Header.Instances.Skip(c.InstanceOffset).Take(c.InstanceCount).ToList(), s.Hash);
        });
    }

    public void LoadIntoFbxScene(FbxHandler fbxHandler, string savePath, bool bSaveShaders, bool saveCBuffers)
    {
        List<D2Class_BD938080> extractedStatics = Header.Statics.DistinctBy(x => x.Static.Hash).ToList();

        Parallel.ForEach(extractedStatics, s =>
        {
            var parts = s.Static.Load(ELOD.MostDetail);
            fbxHandler.AddStaticToScene(parts, s.Static.Hash);
            s.Static.SaveMaterialsFromParts(savePath, parts, bSaveShaders, saveCBuffers);
        });

        Parallel.ForEach(Header.InstanceCounts, c =>
        {
            var model = Header.Statics[c.StaticIndex].Static;
            fbxHandler.InfoHandler.AddStaticInstances(Header.Instances.Skip(c.InstanceOffset).Take(c.InstanceCount).ToList(), model.Hash);
        });
    }
}

[StructLayout(LayoutKind.Sequential, Size = 0xC0)]
public struct D2Class_AD938080
{
    public long FileSize;
    [DestinyOffset(0x18), DestinyField(FieldType.TagHash)]
    public Tag<D2Class_B1938080> ModelOcclusionBounds;
    [DestinyOffset(0x40), DestinyField(FieldType.TablePointer)]
    public List<D2Class_406D8080> Instances;
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_0B008080> Unk50;
    [DestinyOffset(0x78), DestinyField(FieldType.TablePointer)]
    public List<D2Class_BD938080> Statics;
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_286D8080> InstanceCounts;
    [DestinyOffset(0x98)]
    public DestinyHash Unk98;
    [DestinyOffset(0xA0)]
    public Vector4 UnkA0; // likely a bound corner
    public Vector4 UnkB0; // likely the other bound corner
}

[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_B1938080
{
    public long FileSize;
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_B3938080> InstanceBounds;
}

[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_B3938080
{
    public Vector4 Corner1;
    public Vector4 Corner2;
    public DestinyHash Unk20;
}

[StructLayout(LayoutKind.Sequential, Size = 0x40)]
public struct D2Class_406D8080
{
    public Vector4 Rotation;
    public Vector3 Position;
    public Vector3 Scale;  // Only X is used as a global scale
}

[StructLayout(LayoutKind.Sequential, Size = 0x4)]
public struct D2Class_BD938080
{
    [DestinyField(FieldType.TagHash)]
    public StaticContainer Static;
}

[StructLayout(LayoutKind.Sequential, Size = 0x8)]
public struct D2Class_286D8080
{
    public short InstanceCount;
    public short InstanceOffset;
    public short StaticIndex;
    public short Unk06;
}

#region Parent/other structures for maps


/// <summary>
/// The very top reference for all map-related things.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x60)]
public struct D2Class_1E898080
{
    public long FileSize;
    [DestinyField(FieldType.TagHash)]
    public Tag<D2Class_01878080> ChildMapReference;
    [DestinyOffset(0x10), DestinyField(FieldType.String64)] // actually wrong, not a String64 instead StringNoContainer
    public string MapName;
    public int Unk1C;
    [DestinyOffset(0x40), DestinyField(FieldType.TablePointer)]
    public List<D2Class_C9968080> Unk40;
    [DestinyField(FieldType.TagHash64)] 
    public Tag Unk50;  // 0B878080 some kind of parent thing, very strange weird idk
}

[StructLayout(LayoutKind.Sequential, Size = 0x38)]
public struct D2Class_0B878080
{
    public ulong FileSize;
    [DestinyField(FieldType.TagHash)]
    public Tag Unk08; //BF968080
    [DestinyField(FieldType.TagHash)]
    public Tag Unk0C; //8C978080
    [DestinyOffset(0x18), DestinyField(FieldType.TablePointer)]
    public List<D2Class_1D898080> Unk18;
    [DestinyOffset(0x28), DestinyField(FieldType.TablePointer)]
    public List<D2Class_1D898080> Unk28;
}

[StructLayout(LayoutKind.Sequential, Size = 0x40)]
public struct D2Class_BF968080
{
    public ulong FileSize;
    [DestinyField(FieldType.RelativePointer)]
    public string Unk08;
    [DestinyOffset(0x10), DestinyField(FieldType.TablePointer)]
    public List<D2Class_CE968080> Unk10;
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_C3968080> Unk20;
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_35748080> Unk30;
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_CE968080
{
    public DestinyHash Unk00;
    public DestinyHash Unk04;
    public DestinyHash Unk08;
}

[StructLayout(LayoutKind.Sequential, Size = 0x60)]
public struct D2Class_C3968080
{

}

[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_35748080
{

}

/// <summary>
/// Basically same table as in the child tag, but in a weird format. Never understood what its for.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct D2Class_C9968080
{
    [DestinyField(FieldType.TagHash64)] 
    public Tag Unk00;
}

/// <summary>
/// The one below the top reference, actually contains useful information.
/// First of MapResources is what I call "ambient entities", second is always the static map.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x60)]
public struct D2Class_01878080
{
    public long FileSize;
    [DestinyField(FieldType.TablePointer)] 
    public List<D2Class_03878080> MapResources;
}

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct D2Class_03878080
{
    [DestinyField(FieldType.TagHash64)] 
    public Tag<D2Class_07878080> MapResource;
}

/// <summary>
/// A map resource, contains all the data used to make a map.
/// This is quite similar to EntityResource, but with more children.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x38)]
public struct D2Class_07878080
{
    public long FileSize;
    public long Unk08;
    [DestinyOffset(0x28), DestinyField(FieldType.TablePointer)] 
    public List<D2Class_09878080> DataTables;
}

[StructLayout(LayoutKind.Sequential, Size = 4)]
public struct D2Class_09878080
{
    [DestinyField(FieldType.TagHash)] 
    public Tag<D2Class_83988080> DataTable;
}

/// <summary>
/// A map data table, containing data entries. 
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_83988080
{
    public long FileSize;
    [DestinyField(FieldType.TablePointer)] 
    public List<D2Class_85988080> DataEntries;
}


/// <summary>
/// A data entry. Can be static maps, entities, etc. with a defined world transform.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x90)]
public struct D2Class_85988080
{
    public Vector4 Rotation;
    public Vector4 Translation;
    [DestinyOffset(0x28), DestinyField(FieldType.TagHash64, true)]
    public Entity Entity;
    [DestinyOffset(0x78), DestinyField(FieldType.ResourcePointer)]
    public dynamic? DataResource;
}

/// <summary>
/// Data resource containing a static map.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_C96C8080
{
    [DestinyOffset(0x8)] 
    public DestinyHash Unk08;
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag<D2Class_0D6A8080> StaticMapParent;
}

[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_0D6A8080
{
    // no filesize
    [DestinyOffset(0x8), DestinyField(FieldType.TagHash)] 
    public StaticMapData StaticMap;  // could make it StaticMapData but dont want it to load it, could have a NoLoad option
    [DestinyOffset(0x2C)]
    public DestinyHash Unk2C;
}

/// <summary>
/// Boss entity data resource?
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x50)]
public struct D2Class_19808080
{
    // todo rest of this
    // [DestinyField(FieldType.ResourcePointer)]
    // public dynamic? Unk00;
    [DestinyOffset(0x24)]
    public DestinyHash EntityName;
}

/// <summary>
/// Unk data resource, maybe lights for entities?
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_5E6C8080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag Unk10;  // D2Class_716C8080, might be related to lights for entities?
    [DestinyOffset(0x1C)]
    public DestinyHash Unk1C;
}

/// <summary>
/// Unk data resource, maybe lights for entities?
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_636A8080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag Unk10;  // D2Class_656C8080, might be related to lights for entities?
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_B5678080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag Unk10;  // D2Class_A16D8080, has some materials and coords
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x88)]
public struct D2Class_A16D8080
{

}

/// <summary>
/// Audio data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_6F668080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash64)]
    public Tag AudioContainer;  // 38978080 audio container
}

/// <summary>
/// Spatial audio data resource, contains a list of positions to play an audio container.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x48)]
public struct D2Class_6D668080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash64)]
    public Tag AudioContainer;  // 38978080 audio container
    [DestinyOffset(0x30), DestinyField(FieldType.TablePointer)]
    public List<D2Class_94008080> AudioPositions;
    public float Unk40; //Range?
}

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct D2Class_94008080
{
    public Vector4 Translation; //W is always 1
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_B58C8080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag Unk10;  // B78C8080
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_B78C8080
{
    [DestinyOffset(0x08), DestinyField(FieldType.TablePointer)]
    public List<D2Class_B98C8080> Unk08;
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_B98C8080
{

}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_A36A8080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag Unk10;  // A76A8080
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_55698080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag<D2Class_5B698080> Unk10;  // 5B698080, lights/volumes/smth maybe cubemaps idk
}

/// <summary>
/// lights/volumes/smth maybe cubemaps idk
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x78)]
public struct D2Class_5B698080
{
    [DestinyOffset(0x28), DestinyField(FieldType.ResourcePointer)]
    public dynamic? Unk28;
    //[DestinyOffset(0x2C), DestinyField(FieldType.ResourcePointer)]
    //public dynamic? Unk2C;
    //?? 2 lists or dynamic arrays: one of D2Class_63698080, one of D2Class_64698080?
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 8)]
public struct D2Class_63698080
{
   
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct D2Class_64698080
{

}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_7B918080
{
    [DestinyField(FieldType.RelativePointer)]
    public dynamic? Unk00;
}

/// <summary>
/// Havok volume data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_21918080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag HavokVolume;  // type 27 subtype 0
    public DestinyHash Unk14;
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_C0858080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag Unk10;  // C2858080
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_C26A8080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag<D2Class_C46A8080> Unk10;  // C46A8080
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public struct D2Class_C46A8080
{
    [DestinyOffset(0x08), DestinyField(FieldType.TagHash)]
    public Tag Unk08;
    [DestinyOffset(0x10), DestinyField(FieldType.TablePointer)]
    public List<D2Class_D86E8080> Unk10;
    //[DestinyField(FieldType.TablePointer)]
    //public List<D2Class_94008080> Unk11;
    //[DestinyField(FieldType.TablePointer)]
    //public List<D2Class_DD6E8080> Unk12;
    //[DestinyField(FieldType.TablePointer)]
    //public List<D2Class_94008080> Unk13;
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0xF0)]
public struct D2Class_D86E8080
{
    //Vector4s maybe?
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_DD6E8080
{
    public long FileSize; //maybe?
    public dynamic? Unk08;
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_222B8080
{
    [DestinyOffset(0x10)]
    public DestinyHash Unk10;
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_04868080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag Unk10;  // 24878080, smth related to havok volumes
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x110)]
public struct D2Class_716C8080
{
    
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0xF0)]
public struct D2Class_6B6E8080
{
    public long FileSize;
    //[DestinyField(FieldType.TagHash)] //Not worth loading
    //public Tag Unk08; //FFFFFFFF
    //[DestinyField(FieldType.TagHash)]
    //public Tag Unk0C; //FFFFFFFF
    //[DestinyField(FieldType.TagHash)]
    //public Tag Unk10; //FFFFFFFF
    [DestinyOffset(0x14)]
    public DestinyHash Unk14;
    public DestinyHash Unk18;
    [DestinyOffset(0x20), DestinyField(FieldType.TablePointer)]
    public List<D2Class_896E8080> Unk20;
    [DestinyOffset(0x30), DestinyField(FieldType.TablePointer)]
    public List<D2Class_07008080> Unk30;
    [DestinyOffset(0x40), DestinyField(FieldType.TablePointer)]
    public List<D2Class_0C008080> Unk40;
    [DestinyOffset(0x60)]
    public Vector4 Unk60; //??
    public Vector4 Unk70;
    public Vector4 Unk80;
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_209F8080> Unk90;
    [DestinyOffset(0xA0), DestinyField(FieldType.TagHash)]
    public Tag UnkA0; //6E6E8080
    [DestinyField(FieldType.TagHash)]
    public Tag UnkA4; //67958080
    [DestinyField(FieldType.TagHash)]
    public Tag<D2Class_67958080> UnkA8; //67958080
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct D2Class_77968080
{
    public long FileSize;
    [DestinyOffset(0xC), DestinyField(FieldType.TagHash)]
    public Tag<D2Class_338A8080> Unk0C; //338A8080
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x4)]
public struct D2Class_84958080
{

}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_85958080
{
    [DestinyField(FieldType.TagHash)]
    public Tag<D2Class_77968080> Unk00; //77968080
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_87958080
{
    [DestinyOffset(0x24), DestinyField(FieldType.TagHash)]
    public Tag Unk24; //77968080
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public struct D2Class_88958080
{
    public long Unk00;
    public DestinyHash Unk08;
    public DestinyHash Unk0C;
    [DestinyOffset(0x18)]
    public DestinyHash Unk18;
    public DestinyHash Unk1C;
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct D2Class_896E8080
{

}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x14)]
public struct D2Class_89958080
{

}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_209F8080
{
    public Vector4 Unk00;
    public Vector4 Unk10;
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x88)]
public struct D2Class_67958080
{
    public long FileSize;
    [DestinyOffset(0x18), DestinyField(FieldType.TablePointer)]
    public List<D2Class_89958080> Unk18;
    [DestinyOffset(0x28), DestinyField(FieldType.TablePointer)]
    public List<D2Class_88958080> Unk28;
    [DestinyOffset(0x38), DestinyField(FieldType.TablePointer)]
    public List<D2Class_85958080> Unk38;
    [DestinyOffset(0x48), DestinyField(FieldType.TablePointer)]
    public List<D2Class_84958080> Unk48;

    [DestinyOffset(0x78), DestinyField(FieldType.TagHash)]
    public Tag Unk78; //7B958080
    [DestinyField(FieldType.TagHash)]
    public Tag Unk7C; //81958080
}

/// <summary>
/// Unk data resource.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_F16C8080
{
    [DestinyOffset(0x10), DestinyField(FieldType.TagHash)]
    public Tag<D2Class_6B6E8080> Unk10;
}

#endregion