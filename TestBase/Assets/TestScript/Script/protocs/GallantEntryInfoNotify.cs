//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: GallantEntryInfoNotify.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GallantEntryInfoNotify")]
  public partial class GallantEntryInfoNotify : global::ProtoBuf.IExtensible
  {
    public GallantEntryInfoNotify() {}
    
    private uint _all;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"all", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint all
    {
      get { return _all; }
      set { _all = value; }
    }
    private readonly global::System.Collections.Generic.List<uint> _id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(2, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> id
    {
      get { return _id; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}