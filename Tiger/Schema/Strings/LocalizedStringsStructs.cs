﻿
namespace Tiger.Schema.Strings;

[SchemaStruct(TigerStrategy.DESTINY1_RISE_OF_IRON, "5A038080", 0x48)]
[SchemaStruct(TigerStrategy.DESTINY2_SHADOWKEEP_2601, "889A8080", 0x50)]
[SchemaStruct(TigerStrategy.DESTINY2_BEYONDLIGHT_3402, "EF998080", 0x50)]
public struct SLocalizedStrings
{
    public ulong ThisSize;
    public SortedDynamicArray<SStringHash> StringHashes;
    // [DestinyField(FieldType.FileHash), MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
    // public StringData[] StringData;
    // [SchemaField(FieldType.FileHash)]  // only working with english rn for speed
    public LocalizedStringsData EnglishStringsData;    // actually StringData class
}

[SchemaStruct("70008080", 0x4)]
public struct SStringHash
{
    public StringHash StringHash;
}

[SchemaStruct(TigerStrategy.DESTINY1_RISE_OF_IRON, "BE088080", 0x58)]
[SchemaStruct(TigerStrategy.DESTINY2_SHADOWKEEP_2601, "8A9A8080", 0x58)]
[SchemaStruct(TigerStrategy.DESTINY2_BEYONDLIGHT_3402, "F1998080", 0x58)]
[SchemaStruct(TigerStrategy.DESTINY2_LIGHTFALL_7366, "F1998080", 0x48)]
public struct SLocalizedStringsData
{
    public long ThisSize;
    public DynamicArrayUnloaded<SStringPart> StringParts;
    // might be a colour table here
    [SchemaField(0x38, TigerStrategy.DESTINY1_RISE_OF_IRON)]
    [SchemaField(0x28, TigerStrategy.DESTINY2_WITCHQUEEN_6307)]
    public DynamicArrayUnloaded<SStringCharacter> StringCharacters;
    public DynamicArrayUnloaded<SStringPartDefinition> StringCombinations;
}

[SchemaStruct(TigerStrategy.DESTINY1_RISE_OF_IRON, "909A8080", 0x20)]
[SchemaStruct(TigerStrategy.DESTINY2_SHADOWKEEP_2601, "909A8080", 0x20)]
[SchemaStruct(TigerStrategy.DESTINY2_WITCHQUEEN_6307, "F7998080", 0x20)]
public struct SStringPart
{
    [SchemaField(0x8)]
    public RelativePointer StringPartDefinitionPointer;    // this doesn't get accessed so no need to make this easy to access
    // public TigerHash Unk10;
    [SchemaField(0x14)]
    public ushort ByteLength;    // these can differ if multibyte unicode
    public ushort StringLength;
    public ushort CipherShift;    // now always zero
}

[SchemaStruct("05008080", 0x01)]
public struct SStringCharacter
{
    public byte Character;
}

[SchemaStruct(TigerStrategy.DESTINY1_RISE_OF_IRON, "3E038080", 0x10)]
[SchemaStruct(TigerStrategy.DESTINY2_SHADOWKEEP_2601, "8E9A8080", 0x10)]
[SchemaStruct(TigerStrategy.DESTINY2_WITCHQUEEN_6307, "F5998080", 0x10)]
public struct SStringPartDefinition
{
    public RelativePointer StartStringPartPointer;
    public long PartCount;
}

[SchemaStruct(TigerStrategy.DESTINY1_RISE_OF_IRON, "50058080", 0x10)]
public struct S50058080
{
    [SchemaField(0x68)]
    public LocalizedStrings ActivityGlobalStrings; // content\activities\strings\activity_global_strings.localized_strings.tft
    [SchemaField(0xE8)]
    public LocalizedStrings CharacterNames; // content\sandbox\strings\character_names.localized_strings.tft
}

[SchemaStruct(TigerStrategy.DESTINY2_SHADOWKEEP_2601, "B7478080", 0x58)]
[SchemaStruct(TigerStrategy.DESTINY2_BEYONDLIGHT_3402, "02218080", 0x68)]
public struct D2Class_02218080
{
    [SchemaField(0x20, TigerStrategy.DESTINY2_SHADOWKEEP_2601)]
    [SchemaField(0x28, TigerStrategy.DESTINY2_BEYONDLIGHT_3402)]
    public DynamicArray<D2Class_0E3C8080> Unk28;
}

[SchemaStruct(TigerStrategy.DESTINY2_SHADOWKEEP_2601, "C6478080", 0x8)]
[SchemaStruct(TigerStrategy.DESTINY2_BEYONDLIGHT_3402, "0E3C8080", 0x28)]
public struct D2Class_0E3C8080
{
    //[Tag64]
    //public Tag Unk00; // Always FFFFFFFF?
    [SchemaField(0x0, TigerStrategy.DESTINY2_SHADOWKEEP_2601)]
    [SchemaField(TigerStrategy.DESTINY2_BEYONDLIGHT_3402, Obsolete = true)]
    public Tag Unk00;

    [SchemaField(0x10, TigerStrategy.DESTINY2_BEYONDLIGHT_3402), Tag64]
    public Tag Unk10; // Can be string container or something else
}

//
//
// // no-container string caching
//
// [StructLayout(LayoutKind.Sequential, Size = 0x68)]
// public struct D2Class_02218080
// {
//     public long FileSize;
//     // public long Unk08;
//     // [DestinyField(FieldType.FileHash)]
//     // public Tag Unk10; // 0D3C8080
//     // [DestinyField(FieldType.FileHash)]
//     // public Tag Unk14;
//     // [DestinyField(FieldType.TablePointer)]
//     // public List<D2Class_133C8080> Unk18;
//     [SchemaField(0x28), DestinyField(FieldType.TablePointer)]
//     public List<D2Class_0E3C8080> Unk28;
//     // [DestinyField(FieldType.FileHash)]
//     // public Tag Unk38;
//     // [DestinyField(FieldType.FileHash)]
//     // public Tag Unk3C;
//     // [DestinyField(FieldType.FileHash)]
//     // public Tag Unk40;
//     // [DestinyField(FieldType.FileHash)]
//     // public Tag Unk44;
//     // [DestinyField(FieldType.FileHash)]
//     // public Tag Unk48;
//     // [DestinyField(FieldType.FileHash)]
//     // public Tag Unk4C;
//     // [DestinyField(FieldType.FileHash)]
//     // public Tag Unk50;
//     // [SchemaField(0x58), DestinyField(FieldType.TablePointer)]
//     // public List<D2Class_04218080> Unk58;
// }
//
// [StructLayout(LayoutKind.Sequential, Size = 0x18)]
// public struct D2Class_133C8080
// {
//     public TigerHash Unk00;
//     [SchemaField(0x8), DestinyField(FieldType.TablePointer)]
//     private List<D2Class_153C8080> Unk08;
// }
//
// [StructLayout(LayoutKind.Sequential, Size = 8)]
// public struct D2Class_153C8080
// {
//     public TigerHash Unk00;
//     public Tag Unk08;
// }
//
// [StructLayout(LayoutKind.Sequential, Size = 0x28)]
// public struct D2Class_0E3C8080
// {
//     [DestinyField(FieldType.TagHash64)]
//     public Tag Unk00;
//     [DestinyField(FieldType.TagHash64)]
//     public LocalizedStrings Unk10;  // this can be a string container
// }
//
// [StructLayout(LayoutKind.Sequential, Size = 0x50)]
// public struct D2Class_04218080
// {
//     // this causes a duplication of the entire table, dunno why it does this but i wont bother
// }
