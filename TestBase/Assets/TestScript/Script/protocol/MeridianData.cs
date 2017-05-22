namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="MeridianData")]
    public class MeridianData : IExtensible
    {
        private int _bufferId;
        private int _id;
        private readonly List<PropertyModifier> _modifiers = new List<PropertyModifier>();
        private int _times;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired=false, Name="bufferId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int bufferId
        {
            get
            {
                return this._bufferId;
            }
            set
            {
                this._bufferId = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="times", DataFormat=DataFormat.TwosComplement)]
        public int times
        {
            get
            {
                return this._times;
            }
            set
            {
                this._times = value;
            }
        }
    }
}

