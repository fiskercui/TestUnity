//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: LegionWorshipRequest.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LegionWorshipRequest")]
  public partial class LegionWorshipRequest : global::ProtoBuf.IExtensible
  {
    public LegionWorshipRequest() {}
    
    private uint _worship_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"worship_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint worship_id
    {
      get { return _worship_id; }
      set { _worship_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}