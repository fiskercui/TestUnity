//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: KickRoleNotify.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"KickRoleNotify")]
  public partial class KickRoleNotify : global::ProtoBuf.IExtensible
  {
    public KickRoleNotify() {}
    
    private uint _reason;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"reason", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint reason
    {
      get { return _reason; }
      set { _reason = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}