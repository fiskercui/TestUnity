//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: CreateRoleAnswer.proto
// Note: requires additional types generated from: U64Type.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateRoleAnswer")]
  public partial class CreateRoleAnswer : global::ProtoBuf.IExtensible
  {
    public CreateRoleAnswer() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private U64Type _player_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public U64Type player_id
    {
      get { return _player_id; }
      set { _player_id = value; }
    }
    private uint _card_id;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"card_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint card_id
    {
      get { return _card_id; }
      set { _card_id = value; }
    }
    private string _name;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}