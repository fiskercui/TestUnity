//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: PetProp.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PetProp")]
  public partial class PetProp : global::ProtoBuf.IExtensible
  {
    public PetProp() {}
    
    private uint _pos;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"pos", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint pos
    {
      get { return _pos; }
      set { _pos = value; }
    }
    private uint _id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint id
    {
      get { return _id; }
      set { _id = value; }
    }
    private uint _level;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint level
    {
      get { return _level; }
      set { _level = value; }
    }
    private uint _exp;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"exp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint exp
    {
      get { return _exp; }
      set { _exp = value; }
    }
    private uint _refining_level;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"refining_level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint refining_level
    {
      get { return _refining_level; }
      set { _refining_level = value; }
    }
    private uint _refining_exp;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"refining_exp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint refining_exp
    {
      get { return _refining_exp; }
      set { _refining_exp = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}