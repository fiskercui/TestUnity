//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: EquipProp.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EquipProp")]
  public partial class EquipProp : global::ProtoBuf.IExtensible
  {
    public EquipProp() {}
    
    private uint _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint id
    {
      get { return _id; }
      set { _id = value; }
    }
    private uint _luckValue;
    [global::ProtoBuf.ProtoMember(10, IsRequired = true, Name=@"luckValue", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint luckValue
    {
      get { return _luckValue; }
      set { _luckValue = value; }
    }
    private uint _pos;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"pos", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint pos
    {
      get { return _pos; }
      set { _pos = value; }
    }
    private uint _strengthenLevel;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"strengthenLevel", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint strengthenLevel
    {
      get { return _strengthenLevel; }
      set { _strengthenLevel = value; }
    }
    private uint _levelUpgrade;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"levelUpgrade", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint levelUpgrade
    {
      get { return _levelUpgrade; }
      set { _levelUpgrade = value; }
    }
    private uint _levelJingLian;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"levelJingLian", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint levelJingLian
    {
      get { return _levelJingLian; }
      set { _levelJingLian = value; }
    }
    private uint _expJingLian;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"expJingLian", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint expJingLian
    {
      get { return _expJingLian; }
      set { _expJingLian = value; }
    }
    private uint _expUpgrade;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"expUpgrade", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint expUpgrade
    {
      get { return _expUpgrade; }
      set { _expUpgrade = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _attrType = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(8, Name=@"attrType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> attrType
    {
      get { return _attrType; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _attrValue = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(9, Name=@"attrValue", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> attrValue
    {
      get { return _attrValue; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}