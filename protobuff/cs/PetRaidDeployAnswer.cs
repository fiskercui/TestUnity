//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: PetRaidDeployAnswer.proto
// Note: requires additional types generated from: U64Type.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PetRaidDeployAnswer")]
  public partial class PetRaidDeployAnswer : global::ProtoBuf.IExtensible
  {
    public PetRaidDeployAnswer() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _pos = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(2, Name=@"pos", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> pos
    {
      get { return _pos; }
    }
  
    private readonly global::System.Collections.Generic.List<U64Type> _guid = new global::System.Collections.Generic.List<U64Type>();
    [global::ProtoBuf.ProtoMember(3, Name=@"guid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<U64Type> guid
    {
      get { return _guid; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(4, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> id
    {
      get { return _id; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _level = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(5, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> level
    {
      get { return _level; }
    }
  
    private uint _pet_id;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"pet_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint pet_id
    {
      get { return _pet_id; }
      set { _pet_id = value; }
    }
    private uint _pet_level;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"pet_level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint pet_level
    {
      get { return _pet_level; }
      set { _pet_level = value; }
    }
    private uint _pet_refine_level;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"pet_refine_level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint pet_refine_level
    {
      get { return _pet_refine_level; }
      set { _pet_refine_level = value; }
    }
    private uint _fashion_id;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"fashion_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
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