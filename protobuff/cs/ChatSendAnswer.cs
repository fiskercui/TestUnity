//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ChatSendAnswer.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ChatSendAnswer")]
  public partial class ChatSendAnswer : global::ProtoBuf.IExtensible
  {
    public ChatSendAnswer() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private uint _channel;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"channel", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint channel
    {
      get { return _channel; }
      set { _channel = value; }
    }
    private string _to_name;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"to_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string to_name
    {
      get { return _to_name; }
      set { _to_name = value; }
    }
    private string _content;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"content", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string content
    {
      get { return _content; }
      set { _content = value; }
    }

    private uint _fashion_id = default(uint);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"fashion_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint fashion_id
    {
      get { return _fashion_id; }
      set { _fashion_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}