//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: RebelShareAnswer.proto
// Note: requires additional types generated from: U64Type.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RebelShareAnswer")]
  public partial class RebelShareAnswer : global::ProtoBuf.IExtensible
  {
    public RebelShareAnswer() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private U64Type _serial_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"serial_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public U64Type serial_id
    {
      get { return _serial_id; }
      set { _serial_id = value; }
    }
    private uint _share_state;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"share_state", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint share_state
    {
      get { return _share_state; }
      set { _share_state = value; }
    }
    private readonly global::System.Collections.Generic.List<U64Type> _friends = new global::System.Collections.Generic.List<U64Type>();
    [global::ProtoBuf.ProtoMember(4, Name=@"friends", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<U64Type> friends
    {
      get { return _friends; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}