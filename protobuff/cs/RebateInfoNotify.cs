//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: RebateInfoNotify.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RebateInfoNotify")]
  public partial class RebateInfoNotify : global::ProtoBuf.IExtensible
  {
    public RebateInfoNotify() {}
    
    private uint _money;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"money", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint money
    {
      get { return _money; }
      set { _money = value; }
    }
    private uint _deadline;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"deadline", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint deadline
    {
      get { return _deadline; }
      set { _deadline = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}