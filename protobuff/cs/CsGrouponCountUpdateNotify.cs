//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: CsGrouponCountUpdateNotify.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CsGrouponCountUpdateNotify")]
  public partial class CsGrouponCountUpdateNotify : global::ProtoBuf.IExtensible
  {
    public CsGrouponCountUpdateNotify() {}
    
    private uint _total_count;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"total_count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint total_count
    {
      get { return _total_count; }
      set { _total_count = value; }
    }
    private uint _left_count;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"left_count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint left_count
    {
      get { return _left_count; }
      set { _left_count = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}