//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: LegionWorshipOpenBoxRequest.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LegionWorshipOpenBoxRequest")]
  public partial class LegionWorshipOpenBoxRequest : global::ProtoBuf.IExtensible
  {
    public LegionWorshipOpenBoxRequest() {}
    
    private uint _box_order;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"box_order", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint box_order
    {
      get { return _box_order; }
      set { _box_order = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}