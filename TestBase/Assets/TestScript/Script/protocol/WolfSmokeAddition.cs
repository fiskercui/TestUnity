namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="WolfSmokeAddition")]
    public class WolfSmokeAddition : IExtensible
    {
        private int _affectType;
        private readonly List<PropertyModifier> _modifiers = new List<PropertyModifier>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="affectType", DataFormat=DataFormat.TwosComplement)]
        public int affectType
        {
            get
            {
                return this._affectType;
            }
            set
            {
                this._affectType = value;
            }
        }

        [ProtoMember(2, Name="modifiers", DataFormat=DataFormat.Default)]
        public List<PropertyModifier> modifiers
        {
            get
            {
                return this._modifiers;
            }
        }
    }
}

