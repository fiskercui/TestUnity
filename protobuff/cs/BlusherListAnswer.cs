//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: BlusherListAnswer.proto
// Note: requires additional types generated from: BlusherData.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BlusherListAnswer")]
  public partial class BlusherListAnswer : global::ProtoBuf.IExtensible
  {
    public BlusherListAnswer() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private readonly global::System.Collections.Generic.List<BlusherData> _data = new global::System.Collections.Generic.List<BlusherData>();
    [global::ProtoBuf.ProtoMember(2, Name=@"data", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<BlusherData> data
    {
      get { return _data; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}