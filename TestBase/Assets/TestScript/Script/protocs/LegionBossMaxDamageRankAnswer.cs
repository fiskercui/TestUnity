//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: LegionBossMaxDamageRankAnswer.proto
// Note: requires additional types generated from: U64Type.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LegionBossMaxDamageRankAnswer")]
  public partial class LegionBossMaxDamageRankAnswer : global::ProtoBuf.IExtensible
  {
    public LegionBossMaxDamageRankAnswer() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private readonly global::System.Collections.Generic.List<U64Type> _max_damage = new global::System.Collections.Generic.List<U64Type>();
    [global::ProtoBuf.ProtoMember(10, Name=@"max_damage", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<U64Type> max_damage
    {
      get { return _max_damage; }
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
  
    private U64Type _killer_id;
    [global::ProtoBuf.ProtoMember(15, IsRequired = true, Name=@"killer_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public U64Type killer_id
    {
      get { return _killer_id; }
      set { _killer_id = value; }
    }
    private string _killer_name;
    [global::ProtoBuf.ProtoMember(16, IsRequired = true, Name=@"killer_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string killer_name
    {
      get { return _killer_name; }
      set { _killer_name = value; }
    }
    private uint _killer_level;
    [global::ProtoBuf.ProtoMember(17, IsRequired = true, Name=@"killer_level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint killer_level
    {
      get { return _killer_level; }
      set { _killer_level = value; }
    }
    private uint _killer_kill_ts;
    [global::ProtoBuf.ProtoMember(18, IsRequired = true, Name=@"killer_kill_ts", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint killer_kill_ts
    {
      get { return _killer_kill_ts; }
      set { _killer_kill_ts = value; }
    }
    private uint _killer_main_card_id;
    [global::ProtoBuf.ProtoMember(19, IsRequired = true, Name=@"killer_main_card_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint killer_main_card_id
    {
      get { return _killer_main_card_id; }
      set { _killer_main_card_id = value; }
    }
    private uint _stage;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"stage", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint stage
    {
      get { return _stage; }
      set { _stage = value; }
    }
    private string _killer_legion_name;
    [global::ProtoBuf.ProtoMember(20, IsRequired = true, Name=@"killer_legion_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string killer_legion_name
    {
      get { return _killer_legion_name; }
      set { _killer_legion_name = value; }
    }
    private uint _killer_viplv;
    [global::ProtoBuf.ProtoMember(21, IsRequired = true, Name=@"killer_viplv", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint killer_viplv
    {
      get { return _killer_viplv; }
      set { _killer_viplv = value; }
    }

    private uint _killer_fashion_id = default(uint);
    [global::ProtoBuf.ProtoMember(22, IsRequired = false, Name=@"killer_fashion_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint killer_fashion_id
    {
      get { return _killer_fashion_id; }
      set { _killer_fashion_id = value; }
    }
    private uint _self_rank;
    [global::ProtoBuf.ProtoMember(25, IsRequired = true, Name=@"self_rank", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint self_rank
    {
      get { return _self_rank; }
      set { _self_rank = value; }
    }
    private U64Type _self_max_damage;
    [global::ProtoBuf.ProtoMember(26, IsRequired = true, Name=@"self_max_damage", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public U64Type self_max_damage
    {
      get { return _self_max_damage; }
      set { _self_max_damage = value; }
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