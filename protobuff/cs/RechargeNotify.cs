//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: RechargeNotify.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RechargeNotify")]
  public partial class RechargeNotify : global::ProtoBuf.IExtensible
  {
    public RechargeNotify() {}
    
    private string _product_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"product_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string product_id
    {
      get { return _product_id; }
      set { _product_id = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _item_nums = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(10, Name=@"item_nums", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> item_nums
    {
      get { return _item_nums; }
    }
  
    private uint _num;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"num", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint num
    {
      get { return _num; }
      set { _num = value; }
    }
    private int _way;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"way", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int way
    {
      get { return _way; }
      set { _way = value; }
    }
    private int _wayarg;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"wayarg", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int wayarg
    {
      get { return _wayarg; }
      set { _wayarg = value; }
    }
    private uint _money;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"money", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint money
    {
      get { return _money; }
      set { _money = value; }
    }
    private uint _yb;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"yb", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint yb
    {
      get { return _yb; }
      set { _yb = value; }
    }
    private uint _extra_yb;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"extra_yb", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint extra_yb
    {
      get { return _extra_yb; }
      set { _extra_yb = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _item_types = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(8, Name=@"item_types", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> item_types
    {
      get { return _item_types; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _item_ids = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(9, Name=@"item_ids", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> item_ids
    {
      get { return _item_ids; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}