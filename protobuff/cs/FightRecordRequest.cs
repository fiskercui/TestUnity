//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: FightRecordRequest.proto
// Note: requires additional types generated from: FightData.proto
// Note: requires additional types generated from: FortressFightRecordData.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FightRecordRequest")]
  public partial class FightRecordRequest : global::ProtoBuf.IExtensible
  {
    public FightRecordRequest() {}
    
    private uint _version;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"version", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint version
    {
      get { return _version; }
      set { _version = value; }
    }
    private uint _win;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"win", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint win
    {
      get { return _win; }
      set { _win = value; }
    }
    private readonly global::System.Collections.Generic.List<FightData> _fightdatas = new global::System.Collections.Generic.List<FightData>();
    [global::ProtoBuf.ProtoMember(3, Name=@"fightdatas", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<FightData> fightdatas
    {
      get { return _fightdatas; }
    }
  
    private uint _type;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint type
    {
      get { return _type; }
      set { _type = value; }
    }

    private FortressFightRecordData _fortress = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"fortress", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public FortressFightRecordData fortress
    {
      get { return _fortress; }
      set { _fortress = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}