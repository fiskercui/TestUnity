//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: LoginRequest.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LoginRequest")]
  public partial class LoginRequest : global::ProtoBuf.IExtensible
  {
    public LoginRequest() {}
    
    private uint _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint id
    {
      get { return _id; }
      set { _id = value; }
    }
    private uint _channel;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"channel", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint channel
    {
      get { return _channel; }
      set { _channel = value; }
    }
    private string _sign;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"sign", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string sign
    {
      get { return _sign; }
      set { _sign = value; }
    }
    private string _open_id;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"open_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string open_id
    {
      get { return _open_id; }
      set { _open_id = value; }
    }
    private string _sid;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"sid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string sid
    {
      get { return _sid; }
      set { _sid = value; }
    }

    private uint _region_id = default(uint);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"region_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint region_id
    {
      get { return _region_id; }
      set { _region_id = value; }
    }

    private string _token = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"token", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string token
    {
      get { return _token; }
      set { _token = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}