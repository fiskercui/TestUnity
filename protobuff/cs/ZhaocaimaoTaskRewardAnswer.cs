//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ZhaocaimaoTaskRewardAnswer.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ZhaocaimaoTaskRewardAnswer")]
  public partial class ZhaocaimaoTaskRewardAnswer : global::ProtoBuf.IExtensible
  {
    public ZhaocaimaoTaskRewardAnswer() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private uint _id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint id
    {
      get { return _id; }
      set { _id = value; }
    }
    private uint _progress;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"progress", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint progress
    {
      get { return _progress; }
      set { _progress = value; }
    }
    private uint _state;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"state", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint state
    {
      get { return _state; }
      set { _state = value; }
    }
    private uint _count;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint count
    {
      get { return _count; }
      set { _count = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _item_type = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(6, Name=@"item_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> item_type
    {
      get { return _item_type; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _item_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(7, Name=@"item_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> item_id
    {
      get { return _item_id; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _item_num = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(8, Name=@"item_num", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> item_num
    {
      get { return _item_num; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}