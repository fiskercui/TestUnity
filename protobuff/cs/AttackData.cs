//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: AttackData.proto
// Note: requires additional types generated from: FighterStatu.proto
// Note: requires additional types generated from: ContinueAttackData.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"AttackData")]
  public partial class AttackData : global::ProtoBuf.IExtensible
  {
    public AttackData() {}
    
    private readonly global::System.Collections.Generic.List<uint> _attackers = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(1, Name=@"attackers", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> attackers
    {
      get { return _attackers; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _beattackers = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(2, Name=@"beattackers", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> beattackers
    {
      get { return _beattackers; }
    }
  
    private uint _skillid;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"skillid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint skillid
    {
      get { return _skillid; }
      set { _skillid = value; }
    }
    private readonly global::System.Collections.Generic.List<FighterStatu> _newstatus = new global::System.Collections.Generic.List<FighterStatu>();
    [global::ProtoBuf.ProtoMember(4, Name=@"newstatus", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<FighterStatu> newstatus
    {
      get { return _newstatus; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _attackersflag = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(5, Name=@"attackersflag", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> attackersflag
    {
      get { return _attackersflag; }
    }
  
    private readonly global::System.Collections.Generic.List<ContinueAttackData> _continueAttacks = new global::System.Collections.Generic.List<ContinueAttackData>();
    [global::ProtoBuf.ProtoMember(6, Name=@"continueAttacks", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ContinueAttackData> continueAttacks
    {
      get { return _continueAttacks; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}