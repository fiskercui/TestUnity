//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: UniteSkillShowNotify.proto
namespace Pb
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UniteSkillShowNotify")]
  public partial class UniteSkillShowNotify : global::ProtoBuf.IExtensible
  {
    public UniteSkillShowNotify() {}
    
    private readonly global::System.Collections.Generic.List<uint> _sheng_jie_code = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(1, Name=@"sheng_jie_code", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> sheng_jie_code
    {
      get { return _sheng_jie_code; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}