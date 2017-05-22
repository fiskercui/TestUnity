namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="PropertyModifierSet")]
    public class PropertyModifierSet : IExtensible
    {
        private int _levelFilter;
        private readonly List<PropertyModifier> _modifiers = new List<PropertyModifier>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="levelFilter", DataFormat=DataFormat.TwosComplement)]
        public int levelFilter
        {
            get
            {
                return this._levelFilter;
            }
            set
            {
                this._levelFilter = value;
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

