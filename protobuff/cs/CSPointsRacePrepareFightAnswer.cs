//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: CSPointsRacePrepareFightAnswer.proto
// Note: requires additional types generated from: U64Type.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CSPointsRacePrepareFightAnswer")]
  public partial class CSPointsRacePrepareFightAnswer : global::ProtoBuf.IExtensible
  {
    public CSPointsRacePrepareFightAnswer() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _card_lv = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(10, Name=@"card_lv", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> card_lv
    {
      get { return _card_lv; }
    }
  

    private uint _rank = default(uint);
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"rank", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint rank
    {
      get { return _rank; }
      set { _rank = value; }
    }
    private uint _points;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"points", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint points
    {
      get { return _points; }
      set { _points = value; }
    }
    private uint _level;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint level
    {
      get { return _level; }
      set { _level = value; }
    }
    private uint _server_id;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"server_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint server_id
    {
      get { return _server_id; }
      set { _server_id = value; }
    }
    private string _server_name;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"server_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string server_name
    {
      get { return _server_name; }
      set { _server_name = value; }
    }
    private U64Type _player_id;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public U64Type player_id
    {
      get { return _player_id; }
      set { _player_id = value; }
    }
    private string _player_name;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"player_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string player_name
    {
      get { return _player_name; }
      set { _player_name = value; }
    }
    private uint _fashion_id;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"fashion_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint fashion_id
    {
      get { return _fashion_id; }
      set { _fashion_id = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _card_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(9, Name=@"card_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> card_id
    {
      get { return _card_id; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}