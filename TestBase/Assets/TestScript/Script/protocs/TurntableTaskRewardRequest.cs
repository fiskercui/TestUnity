//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: TurntableTaskRewardRequest.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"TurntableTaskRewardRequest")]
  public partial class TurntableTaskRewardRequest : global::ProtoBuf.IExtensible
  {
    public TurntableTaskRewardRequest() {}
    
    private uint _task_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"task_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint task_id
    {
      get { return _task_id; }
      set { _task_id = value; }
    }

    private uint _exchange_cnt = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"exchange_cnt", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint exchange_cnt
    {
      get { return _exchange_cnt; }
      set { _exchange_cnt = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}