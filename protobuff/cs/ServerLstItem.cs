//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ServerLstItem.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ServerLstItem")]
  public partial class ServerLstItem : global::ProtoBuf.IExtensible
  {
    public ServerLstItem() {}
    
    private uint _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint id
    {
      get { return _id; }
      set { _id = value; }
    }
    private string _add;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"add", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string add
    {
      get { return _add; }
      set { _add = value; }
    }
    private uint _stat;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"stat", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint stat
    {
      get { return _stat; }
      set { _stat = value; }
    }
    private string _name;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private string _rolename;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"rolename", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string rolename
    {
      get { return _rolename; }
      set { _rolename = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}