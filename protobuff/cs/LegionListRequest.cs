//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: LegionListRequest.proto
// Note: requires additional types generated from: U64Type.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LegionListRequest")]
  public partial class LegionListRequest : global::ProtoBuf.IExtensible
  {
    public LegionListRequest() {}
    
    private readonly global::System.Collections.Generic.List<uint> _status = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(10, Name=@"status", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> status
    {
      get { return _status; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _accept_type = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(11, Name=@"accept_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> accept_type
    {
      get { return _accept_type; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _accept_value = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(12, Name=@"accept_value", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> accept_value
    {
      get { return _accept_value; }
    }
  
    private readonly global::System.Collections.Generic.List<U64Type> _legion_id = new global::System.Collections.Generic.List<U64Type>();
    [global::ProtoBuf.ProtoMember(2, Name=@"legion_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<U64Type> legion_id
    {
      get { return _legion_id; }
    }
  
    private readonly global::System.Collections.Generic.List<string> _name = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(3, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> name
    {
      get { return _name; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _logo_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(4, Name=@"logo_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> logo_id
    {
      get { return _logo_id; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _frame_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(5, Name=@"frame_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> frame_id
    {
      get { return _frame_id; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _level = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(6, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> level
    {
      get { return _level; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _member_num = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(7, Name=@"member_num", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> member_num
    {
      get { return _member_num; }
    }
  
    private readonly global::System.Collections.Generic.List<U64Type> _head_id = new global::System.Collections.Generic.List<U64Type>();
    [global::ProtoBuf.ProtoMember(8, Name=@"head_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<U64Type> head_id
    {
      get { return _head_id; }
    }
  
    private readonly global::System.Collections.Generic.List<string> _declaration = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(9, Name=@"declaration", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> declaration
    {
      get { return _declaration; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}