//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: CommonRankLikeRequest.proto
// Note: requires additional types generated from: U64Type.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CommonRankLikeRequest")]
  public partial class CommonRankLikeRequest : global::ProtoBuf.IExtensible
  {
    public CommonRankLikeRequest() {}
    
    private uint _type;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint type
    {
      get { return _type; }
      set { _type = value; }
    }
    private U64Type _like_player_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"like_player_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public U64Type like_player_id
    {
      get { return _like_player_id; }
      set { _like_player_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}