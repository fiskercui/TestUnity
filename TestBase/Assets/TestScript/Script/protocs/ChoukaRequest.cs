//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ChoukaRequest.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ChoukaRequest")]
  public partial class ChoukaRequest : global::ProtoBuf.IExtensible
  {
    public ChoukaRequest() {}
    
    private uint _isdef;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"isdef", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint isdef
    {
      get { return _isdef; }
      set { _isdef = value; }
    }
    private uint _act_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"act_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint act_id
    {
      get { return _act_id; }
      set { _act_id = value; }
    }
    private uint _cfg_id;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"cfg_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint cfg_id
    {
      get { return _cfg_id; }
      set { _cfg_id = value; }
    }
    private uint _count;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint count
    {
      get { return _count; }
      set { _count = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}