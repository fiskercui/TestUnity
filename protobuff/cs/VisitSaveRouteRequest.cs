//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: VisitSaveRouteRequest.proto
// Note: requires additional types generated from: U64Type.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"VisitSaveRouteRequest")]
  public partial class VisitSaveRouteRequest : global::ProtoBuf.IExtensible
  {
    public VisitSaveRouteRequest() {}
    
    private readonly global::System.Collections.Generic.List<uint> _route_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(1, Name=@"route_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> route_id
    {
      get { return _route_id; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _card_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(2, Name=@"card_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> card_id
    {
      get { return _card_id; }
    }
  
    private readonly global::System.Collections.Generic.List<U64Type> _card_guid = new global::System.Collections.Generic.List<U64Type>();
    [global::ProtoBuf.ProtoMember(3, Name=@"card_guid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<U64Type> card_guid
    {
      get { return _card_guid; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _station_id = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(4, Name=@"station_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> station_id
    {
      get { return _station_id; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _horse_lv = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(5, Name=@"horse_lv", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> horse_lv
    {
      get { return _horse_lv; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}