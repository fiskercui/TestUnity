//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: BlusherRewardAnswer.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BlusherRewardAnswer")]
  public partial class BlusherRewardAnswer : global::ProtoBuf.IExtensible
  {
    public BlusherRewardAnswer() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _types = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(2, Name=@"types", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> types
    {
      get { return _types; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _ids = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(3, Name=@"ids", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> ids
    {
      get { return _ids; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _nums = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(4, Name=@"nums", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> nums
    {
      get { return _nums; }
    }
  
    private uint _exp;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"exp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint exp
    {
      get { return _exp; }
      set { _exp = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}