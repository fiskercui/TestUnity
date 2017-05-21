namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Requirement")]
    public class Requirement : IExtensible
    {
        private int _compairType;
        private int _type;
        private int _value;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="compairType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int compairType
        {
            get
            {
                return this._compairType;
            }
            set
            {
                this._compairType = value;
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement)]
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

