//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ArenaMultiStartData.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ArenaMultiStartData")]
  public partial class ArenaMultiStartData : global::ProtoBuf.IExtensible
  {
    public ArenaMultiStartData() {}
    
    private uint _win;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"win", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint win
    {
      get { return _win; }
      set { _win = value; }
    }
    private uint _exp;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"exp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint exp
    {
      get { return _exp; }
      set { _exp = value; }
    }
    private uint _silver;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"silver", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint silver
    {
      get { return _silver; }
      set { _silver = value; }
    }
    private uint _prestige;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"prestige", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint prestige
    {
      get { return _prestige; }
      set { _prestige = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _item_type = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(5, Name=@"item_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> item_type
    {
      get { return _item_type; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _item_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(6, Name=@"item_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> item_id
    {
      get { return _item_id; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _item_num = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(7, Name=@"item_num", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> item_num
    {
      get { return _item_num; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}