namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Modifier")]
    public class Modifier : IExtensible
    {
        private int _abilityType;
        private int _type;
        private int _value;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="abilityType", DataFormat=DataFormat.TwosComplement)]
        public int abilityType
        {
            get
            {
                return this._abilityType;
            }
            set
            {
                this._abilityType = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
}

