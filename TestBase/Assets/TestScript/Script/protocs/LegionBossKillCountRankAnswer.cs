//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: LegionBossKillCountRankAnswer.proto
// Note: requires additional types generated from: U64Type.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LegionBossKillCountRankAnswer")]
  public partial class LegionBossKillCountRankAnswer : global::ProtoBuf.IExtensible
  {
    public LegionBossKillCountRankAnswer() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _kill_count = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(10, Name=@"kill_count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> kill_count
    {
      get { return _kill_count; }
    }
  
    private readonly global::System.Collections.Generic.List<string> _legion_name = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(11, Name=@"legion_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> legion_name
    {
      get { return _legion_name; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _legion_logo_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(12, Name=@"legion_logo_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> legion_logo_id
    {
      get { return _legion_logo_id; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _legion_frame_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(13, Name=@"legion_frame_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> legion_frame_id
    {
      get { return _legion_frame_id; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _fashion_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(14, Name=@"fashion_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> fashion_id
    {
      get { return _fashion_id; }
    }
  
    private uint _self_rank;
    [global::ProtoBuf.ProtoMember(15, IsRequired = true, Name=@"self_rank", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint self_rank
    {
      get { return _self_rank; }
      set { _self_rank = value; }
    }
    private uint _self_kill_count;
    [global::ProtoBuf.ProtoMember(16, IsRequired = true, Name=@"self_kill_count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint self_kill_count
    {
      get { return _self_kill_count; }
      set { _self_kill_count = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _rank = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(4, Name=@"rank", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> rank
    {
      get { return _rank; }
    }
  
    private readonly global::System.Collections.Generic.List<U64Type> _player_id = new global::System.Collections.Generic.List<U64Type>();
    [global::ProtoBuf.ProtoMember(5, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<U64Type> player_id
    {
      get { return _player_id; }
    }
  
    private readonly global::System.Collections.Generic.List<string> _name = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(6, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> name
    {
      get { return _name; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _main_card_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(7, Name=@"main_card_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> main_card_id
    {
      get { return _main_card_id; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _level = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(8, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> level
    {
      get { return _level; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _viplv = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(9, Name=@"viplv", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> viplv
    {
      get { return _viplv; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}