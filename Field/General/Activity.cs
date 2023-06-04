﻿using System.Runtime.InteropServices;
using Field.Entities;
using Field.General;
using Field.Strings;
using Field.Investment;
using Field.Models;

namespace Field;

public class Activity : Tag
{
	public D2Class_8E8E8080 Header;

	public Activity(TagHash hash) : base(hash)
	{
	}

	protected override void ParseStructs()
	{
		// Getting the string container
		StringContainer sc;
		using (var handle = GetHandle())
		{
			handle.BaseStream.Seek(0x28, SeekOrigin.Begin);
			var tag = PackageHandler.GetTag<D2Class_8B8E8080>(new TagHash(handle.ReadUInt64()));
			sc = tag.Header.StringContainer;
		}
		Header = ReadHeader<D2Class_8E8E8080>(sc);
	}
}

[StructLayout(LayoutKind.Sequential, Size = 0x78)]
public struct D2Class_8E8E8080
{
	public long FileSize;
	public DestinyHash LocationName;  // these all have actual string hashes but have no string container given directly
	public DestinyHash Unk0C;
	public DestinyHash Unk10;
	public DestinyHash Unk14;
	[DestinyField(FieldType.ResourcePointer)]
	public dynamic? Unk18;  // 6A988080 + 20978080
	[DestinyField(FieldType.TagHash64)]
	public Tag<D2Class_8B8E8080> Unk20;  // some weird kind of parent thing with names, contains the string container for this tag
	[DestinyOffset(0x40), DestinyField(FieldType.TablePointer)]
	public List<D2Class_26898080> Unk40;
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_24898080> Unk50;
	public DestinyHash Unk60;
	[DestinyField(FieldType.TagHash)]
	public Tag<D2Class_8C978080> Unk64;  // an entity thing
	[DestinyField(FieldType.TagHash64)]
	public Tag<D2Class_8E8E8080> UnkActivity68; //8E8E8080, Tag for the ambient activity?
}

[StructLayout(LayoutKind.Sequential, Size = 0x78)]
public struct D2Class_8B8E8080
{
	public long FileSize;
	public DestinyHash LocationName;
	[DestinyOffset(0x10), DestinyField(FieldType.TagHash64)]
	public StringContainer StringContainer;
	[DestinyField(FieldType.TagHash)]
	public Tag<D2Class_E1998080> Events;
	[DestinyField(FieldType.TagHash)]
	public Tag<D2Class_75988080> Patrols;
	public uint Unk28;
	[DestinyField(FieldType.TagHash)]
	public Tag Unk2C; //Different class but same thing as Patrols?
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_DE448080> TagBags;
	[DestinyOffset(0x48), DestinyField(FieldType.TablePointer)]
	public List<D2Class_2E898080> Activities;
	[DestinyField(FieldType.RelativePointer)]
	public string DestinationName;
}

[StructLayout(LayoutKind.Sequential, Size = 4)]
public struct D2Class_DE448080
{
	[DestinyField(FieldType.TagHash)]
	public Tag Unk00;
}

[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_E1998080
{
    public ulong FileSize;
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_E3998080> Unk08;
}

[StructLayout(LayoutKind.Sequential, Size = 0x48)]
public struct D2Class_E3998080
{
    [DestinyField(FieldType.RelativePointer)]
    public string Unk00; //Event schedule string thing
    [DestinyOffset(0x20), DestinyField(FieldType.TablePointer)]
    public List<D2Class_E7998080> Unk20;
}

[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public struct D2Class_E7998080
{
    public DestinyHash Unk00;
    //[DestinyOffset(0x18), DestinyField(FieldType.String)]
    //public string Unk18;
}


[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_2E898080
{
	public DestinyHash ShortActivityName;
	[DestinyOffset(0x8)]
	public DestinyHash Unk08;
	public DestinyHash Unk10;
	[DestinyField(FieldType.RelativePointer)]
	public string ActivityName;
}

[StructLayout(LayoutKind.Sequential, Size = 0x58)]
public struct D2Class_26898080
{
	public DestinyHash LocationName;
    public DestinyHash ActivityName;
    public DestinyHash BubbleName;
    public DestinyHash Unk0C;
    public DestinyHash Unk10;
    [DestinyOffset(0x18)]
    public DestinyHash BubbleName2;
    [DestinyOffset(0x20)]
    public DestinyHash Unk20;
    public DestinyHash Unk24;
    public DestinyHash Unk28;
    [DestinyOffset(0x30)]
    public int Unk30;
    [DestinyOffset(0x38), DestinyField(FieldType.TablePointer)]
    public List<D2Class_48898080> Unk38;
    [DestinyOffset(0x48)]
    public DestinyHash Unk48;
    [DestinyOffset(0x50)]
    public DestinyHash Unk50;
    public DestinyHash Unk54;
    public DestinyHash Unk58;
    [DestinyOffset(0x6A)] 
    public short Unk6A;
    //[DestinyOffset(0x70), DestinyField(FieldType.TablePointer)]
    //public List<D2Class_48898080> Unk70;
}

[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_48898080
{
	public DestinyHash LocationName;
	public DestinyHash ActivityName;
	public DestinyHash BubbleName;
	public DestinyHash ActivityPhaseName;
	public DestinyHash ActivityPhaseName2;
	[DestinyField(FieldType.TagHash)]
	public Tag<D2Class_898E8080> UnkEntityReference;
}

[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_898E8080
{
    public long FileSize;
    public long Unk08;
    [DestinyField(FieldType.ResourcePointer)]
    public dynamic? Unk10;  // 46938080 has dialogue table, 45938080 unk, 19978080 unk
    [DestinyOffset(0x18), DestinyField(FieldType.TagHash)]
    public Tag<D2Class_BE8E8080> Unk18;  // D2Class_898E8080 entity script stuff
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_BE8E8080
{
    public long FileSize;
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_42898080> EntityResources;
}

[StructLayout(LayoutKind.Sequential, Size = 4)]
public struct D2Class_42898080
{
    [DestinyField(FieldType.TagHash)]
    public Tag<D2Class_43898080> EntityResourceParent;
}

[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public struct D2Class_43898080
{
    public long FileSize;
    public DestinyHash Unk08;
    [DestinyOffset(0x20), DestinyField(FieldType.TagHash)]
    public EntityResource EntityResource;
}

[StructLayout(LayoutKind.Sequential, Size = 0x58)]
public struct D2Class_46938080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag DialogueTable;
	[DestinyOffset(0x3C)]
	public int Unk3C;
	public float Unk40;
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_19978080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag DialogueTable;

	public DestinyHash Unk10;
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_18978080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag DialogueTable;

	public DestinyHash Unk10;
	[DestinyOffset(0x18)]
	public DestinyHash Unk18;
	public int Unk1C;
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_17978080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag DialogueTable;

	public DestinyHash Unk10;
	[DestinyOffset(0x18)]
	public DestinyHash Unk18;
	public int Unk1C;
}

[StructLayout(LayoutKind.Sequential, Size = 0x58)]
public struct D2Class_45938080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag DialogueTable;
	[DestinyOffset(0x18), DestinyField(FieldType.TablePointer)]
	public List<D2Class_28998080> Unk18;
	[DestinyOffset(0x3C)]
	public int Unk3C;
	public float Unk40;
}

[StructLayout(LayoutKind.Sequential, Size = 0x58)]
public struct D2Class_44938080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag DialogueTable;
	[DestinyOffset(0x18), DestinyField(FieldType.TablePointer)]
	public List<D2Class_28998080> Unk18;
	[DestinyOffset(0x3C)]
	public int Unk3C;
	public float Unk40;
	public DestinyHash Unk44;
	[DestinyOffset(0x50)]
	public int Unk50;
}

/// <summary>
/// Generally used in ambients to provide dialogue and music together.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x50)]
public struct D2Class_D5908080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag DialogueTable;
	[DestinyOffset(0x38), DestinyField(FieldType.TagHash)]
	public Tag<D2Class_EB458080> Music;
	public int Unk3C;
	public float Unk40;
	public DestinyHash Unk44;
}

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct D2Class_28998080
{
	public DestinyHash Unk00;
	public DestinyHash Unk04;
	public DestinyHash Unk08;
}

[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_1A978080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag Unk00;
}

[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_478F8080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag Unk00;
}

/// <summary>
/// Stores static map data for activities
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x38)]
public struct D2Class_24898080
{
	public DestinyHash LocationName;
	public DestinyHash ActivityName;
	public DestinyHash BubbleName;
	[DestinyOffset(0x10), DestinyField(FieldType.ResourcePointer)]
	public dynamic? Unk10;  // 0F978080, 53418080
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_48898080> Unk18;
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_1D898080> MapReferences;
}

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct D2Class_1D898080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag<D2Class_1E898080> MapReference;
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_53418080
{
	public DestinyHash Unk00;
	public DestinyHash Unk04;
	[DestinyOffset(0xC)]
	public int Unk0C;
}

[StructLayout(LayoutKind.Sequential, Size = 0x40)]
public struct D2Class_54418080
{
	public DestinyHash Unk00;
	public DestinyHash Unk04;
	[DestinyOffset(0xC)]
	public int Unk0C;
}

[StructLayout(LayoutKind.Sequential, Size = 0x40)]
public struct D2Class_0F978080
{
	[DestinyField(FieldType.RelativePointer)]
	public string BubbleName;
	public DestinyHash Unk08;
	public DestinyHash Unk0C;
	public DestinyHash Unk10;
	[DestinyOffset(0x28)]
	public long Unk28;
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_DD978080> Unk30;
}

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct D2Class_DD978080
{
	public DestinyHash Unk00;
	public DestinyHash Unk04;
	public DestinyHash Unk08;
}

/// <summary>
/// Directive table + audio links for activity directives.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x84)]
public struct D2Class_6A988080
{
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_28898080> DirectiveTables;
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_B7978080> DialogueTables;
    public DestinyHash StartingBubbleName;
	public DestinyHash Unk24;
	[DestinyOffset(0x2C), DestinyField(FieldType.TagHash)]
	public Tag<D2Class_EB458080> Music;
    [DestinyOffset(0x60), DestinyField(FieldType.RelativePointer)]
    public string Unk60; //A path for some music? Mentions descent, loading in from orbit perhaps?
	[DestinyOffset(0x68), DestinyField(FieldType.TagHash64)]
	public Tag Unk68;

}

[StructLayout(LayoutKind.Sequential, Size = 0x14)]
public struct D2Class_B7978080
{
	[DestinyField(FieldType.TagHash64)]
	public Tag<D2Class_B8978080> DialogueTable;
}

/// <summary>
/// Directive table for public events so no audio linked.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x38)]
public struct D2Class_20978080
{
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_28898080> PEDirectiveTables;
	[DestinyOffset(0x20)]
	public DestinyHash StartingBubbleName;
}

[StructLayout(LayoutKind.Sequential, Size = 4)]
public struct D2Class_28898080
{
	[DestinyField(FieldType.TagHash)]
	public Tag<D2Class_C78E8080> DirectiveTable;
}

[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_C78E8080
{
	public long FileSize;
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_C98E8080> DirectiveTable;
}

[StructLayout(LayoutKind.Sequential, Size = 0x80)]
public struct D2Class_C98E8080
{
	public DestinyHash Hash;
	public int Unk04;

	[DestinyOffset(0x10), DestinyField(FieldType.String64)]
	public string NameString;
	[DestinyOffset(0x28), DestinyField(FieldType.String64)]
	public string DescriptionString;
	[DestinyOffset(0x40), DestinyField(FieldType.String64)]
	public string ObjectiveString;
	[DestinyOffset(0x58), DestinyField(FieldType.String64)]
	public string Unk58;
	[DestinyOffset(0x70)]
	public int ObjectiveTargetCount;
}

[StructLayout(LayoutKind.Sequential, Size = 0x38)]
public struct D2Class_0B978080
{
	[DestinyField(FieldType.RelativePointer)]
	public string BubbleName;
	public DestinyHash Unk08;
	public DestinyHash Unk0C;
	public DestinyHash Unk10;
	[DestinyOffset(0x40), DestinyField(FieldType.TablePointer)]
	public List<D2Class_0C008080> Unk40;
}

[StructLayout(LayoutKind.Sequential, Size = 8)]
public struct D2Class_0C008080
{
	public DestinyHash Unk00;
	public DestinyHash Unk04;
}

#region Patrol Table

[StructLayout(LayoutKind.Sequential, Size = 0x38)]
public struct D2Class_75988080
{
    public ulong Unk00;
    [DestinyField(FieldType.TagHash)]
    public Tag<D2Class_20808080> Unk08;
    [DestinyOffset(0x10), DestinyField(FieldType.RelativePointer)]
    public string PatrolTablePath;
    [DestinyOffset(0x18), DestinyField(FieldType.TagHash)]
    public Tag<D2Class_A8418080> PatrolTable; //The actual patrol table
    //[DestinyOffset(0x28), DestinyField(FieldType.TagHash64)]
    //public StringContainer StringContainer; //?
}

[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_20808080
{
    [DestinyOffset(0x08), DestinyField(FieldType.TablePointer)]
    public List<D2Class_22808080> Unk08;
}

[StructLayout(LayoutKind.Sequential, Size = 0x18)]
public struct D2Class_22808080
{
    public DestinyHash Unk00; //??
    [DestinyOffset(0x08), DestinyField(FieldType.RelativePointer)]
    public string PatrolDevString;
}

[StructLayout(LayoutKind.Sequential, Size = 0x48)]
public struct D2Class_A8418080 //Patrol table (TABLES IN TABLES IN TABLES IN TABLES MAKE IT STOP PLEASEEEE)
{
    [DestinyOffset(0x08), DestinyField(FieldType.TablePointer)]
    public List<D2Class_AD418080> Unk08;
    [DestinyOffset(0x18), DestinyField(FieldType.TablePointer)]
    public List<D2Class_B0418080> Unk18;
    [DestinyOffset(0x28), DestinyField(FieldType.TablePointer)]
    public List<D2Class_B4418080> Unk28;
}

[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_AD418080
{
    public DestinyHash Unk00;
    [DestinyOffset(0x08)]
    public DestinyHash Unk08;
    [DestinyOffset(0x18)]
	public byte Unk18; //index?
    [DestinyOffset(0x20), DestinyField(FieldType.TablePointer)]
    public List<D2Class_AF418080> Unk20;
}

[StructLayout(LayoutKind.Sequential, Size = 0x8)]
public struct D2Class_AF418080 
{
	public byte Index; //index maybe?
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_B0418080 
{
	public DestinyHash Unk00;
	[DestinyOffset(0x08), DestinyField(FieldType.TablePointer)]
	public List<D2Class_B3418080> Unk08;
    //[DestinyOffset(0x18), DestinyField(FieldType.TagHash64)]
    //public StringContainer Unk18;
}

[StructLayout(LayoutKind.Sequential, Size = 0x8)]
public struct D2Class_B3418080 
{
    public byte Index; //index maybe?
}

[StructLayout(LayoutKind.Sequential, Size = 0x160)]
public struct D2Class_B4418080 //Theres a lot of things here
{
	public DestinyHash PatrolHash;
	[DestinyOffset(0x8), DestinyField(FieldType.String64)]
	public string PatrolNameString;
    [DestinyOffset(0x20), DestinyField(FieldType.String64)]
    public string PatrolDescriptionString;
    [DestinyOffset(0x38), DestinyField(FieldType.String64)]
    public string PatrolObjectiveString;
   
    [DestinyOffset(0x50), DestinyField(FieldType.TagHash)]
    public Tag<D2Class_A53E8080> Unk50; //Patrol type?
    [DestinyOffset(0x60)]
    public DestinyHash Unk60;
	[DestinyOffset(0x68), DestinyField(FieldType.TagHash64)]
    public Tag<D2Class_B8978080> DialogueTable;
	//[DestinyOffset(0x98), DestinyField(FieldType.TagHash64)]
	//public Tag<D2Class_B8978080> DialogueTable2; //Same as the first?
	[DestinyOffset(0xA8), DestinyField(FieldType.TablePointer)]
    public List<D2Class_B7418080> UnkA8;
    [DestinyOffset(0xB8), DestinyField(FieldType.TablePointer)]
    public List<D2Class_B7418080> UnkB8;
	//Bunch of DestinyHash's from C8 to 148?

    [DestinyOffset(0x148)]
    public int Unk148; //Objective target count? Some numbers dont seem right though
}

[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_B7418080
{
    [DestinyOffset(0x04)]
    public DestinyHash Unk04;
    [DestinyField(FieldType.TablePointer)]
    public List<D2Class_70008080> Unk08;
    [DestinyOffset(0x18), DestinyField(FieldType.ResourcePointer)]
    public dynamic? Unk18; //D2Class_B8838080, E5838080 or 03658080
    [DestinyOffset(0x20), DestinyField(FieldType.TablePointer)]
    public List<D2Class_B9418080> Unk20;
}

[StructLayout(LayoutKind.Sequential, Size = 0x8)]
public struct D2Class_B9418080 
{
    [DestinyField(FieldType.ResourcePointer)]
    public dynamic? Unk00; //BB418080 or BC418080 
}

[StructLayout(LayoutKind.Sequential, Size = 0x4)]
public struct D2Class_BB418080 
{
	public byte Unk00; //always 1?
}

[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public struct D2Class_BC418080 
{
	[DestinyField(FieldType.TagHash64)]
	public Tag Unk00; //Entity? seems to always be a cluster of engram meshes
    public DestinyHash Unk10;
    public DestinyHash Unk14;
}

[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public struct D2Class_B8838080
{
	public DestinyHash Unk00;
    public DestinyHash Unk04;
    public DestinyHash Unk08;
    public DestinyHash Unk0C;
    public DestinyHash Unk10;
}

[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_E5838080
{
	public DestinyHash Unk00; 
}

[StructLayout(LayoutKind.Sequential, Size = 0x320)] //??
public struct D2Class_03658080
{

}

[StructLayout(LayoutKind.Sequential, Size = 0x70)]
public struct D2Class_A53E8080
{
	[DestinyOffset(0x8)]
	public DestinyHash Unk08;
	[DestinyField(FieldType.TagHash)]
	public Tag<D2Class_BA3E8080> UnkC;
    [DestinyField(FieldType.TagHash64)]
    public Tag<D2Class_EF998080> Unk10;
    [DestinyOffset(0x20), DestinyField(FieldType.TablePointer)]
	public List<D2Class_B73B8080> Unk20;
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_B73B8080
{
	public DestinyHash Unk00;
	[DestinyOffset(0x10)]
	public Vector4 Unk10; //??
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_BA3E8080
{
    [DestinyOffset(0x8), DestinyField(FieldType.TablePointer)]
    public List<D2Class_BE3E8080> Unk08;
}

[StructLayout(LayoutKind.Sequential, Size = 0x70)]
public struct D2Class_BE3E8080
{
	public DestinyHash Unk00;
    [DestinyField(FieldType.TagHash)]
    public Tag<D2Class_CF3E8080> Unk04;
}



#endregion

#region Audio

[StructLayout(LayoutKind.Sequential, Size = 0x38)]
public struct D2Class_EB458080
{
	public long FileSize;
	[DestinyField(FieldType.RelativePointer)]
	public string MusicTemplateName;
	[DestinyField(FieldType.TagHash64)]
	public Tag MusicTemplateTag; // F0458080

	public long Unk20;
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_ED458080> Unk28;
}

[StructLayout(LayoutKind.Sequential, Size = 8)]
public struct D2Class_ED458080
{
	[DestinyField(FieldType.ResourcePointer)]
	public dynamic? Unk00;
}

[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_F5458080
{
	[DestinyField(FieldType.RelativePointer)]
	public string WwiseMusicLoopName;
	[DestinyField(FieldType.TagHash64)]
	public WwiseSound MusicLoopSound;
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_FB458080> Unk18;

	public DestinyHash Unk28;
}

[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public struct D2Class_F7458080
{
	[DestinyField(FieldType.RelativePointer)]
	public string AmbientMusicSetName;
	[DestinyField(FieldType.TagHash64)]
	public Tag<D2Class_50968080> AmbientMusicSet;
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_FA458080> Unk18;
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_50968080
{
	public long FileSize;
	[DestinyField(FieldType.TablePointer)]
	public List<D2Class_318A8080> Unk08;
	public DestinyHash Unk18;
}

[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public struct D2Class_318A8080
{
	[DestinyField(FieldType.TagHash64)]
	public WwiseSound MusicLoopSound;

	public float Unk10;
	public DestinyHash Unk14;
	public float Unk18;
	public DestinyHash Unk1C;
	public float Unk20;
	public DestinyHash Unk24;
	public int Unk28;
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_FA458080
{
	public DestinyHash Unk00;
	[DestinyOffset(8), DestinyField(FieldType.RelativePointer)]
	public string EventName;

	public DestinyHash Unk10;  // eventhash? idk
	public DestinyHash Unk14;
}

[StructLayout(LayoutKind.Sequential, Size = 0x20)]
public struct D2Class_FB458080
{
	public DestinyHash Unk00;
	[DestinyOffset(8), DestinyField(FieldType.RelativePointer)]
	public string EventName;

	public int Unk10;
	public int Unk14;
	public DestinyHash EventHash;
}

[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public struct D2Class_F0458080
{
	public long FileSize;
	public int Unk08;
	public int Unk0C;
	public int WwiseSwitchKey;
}


#endregion