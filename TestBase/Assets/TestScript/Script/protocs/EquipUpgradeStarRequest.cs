//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: EquipUpgradeStarRequest.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EquipUpgradeStarRequest")]
  public partial class EquipUpgradeStarRequest : global::ProtoBuf.IExtensible
  {
    public EquipUpgradeStarRequest() {}
    
    private uint _posZhengXing;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"posZhengXing", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint posZhengXing
    {
      get { return _posZhengXing; }
      set { _posZhengXing = value; }
    }
    private uint _pos;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"pos", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint pos
    {
      get { return _pos; }
      set { _pos = value; }
    }
    private uint _utype;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"utype", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint utype
    {
      get { return _utype; }
      set { _utype = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}