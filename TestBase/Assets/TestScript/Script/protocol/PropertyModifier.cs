namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="PropertyModifier")]
    public class PropertyModifier : IExtensible
    {
        private int _attributeType;
        private float _attributeValue;
        private int _modifyType;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="attributeType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int attributeType
        {
            get
            {
                return this._attributeType;
            }
            set
            {
                this._attributeType = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="attributeValue", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float attributeValue
        {
            get
            {
                return this._attributeValue;
            }
            set
            {
                this._attributeValue = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="modifyType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int modifyType
        {
            get
            {
                return this._modifyType;
            }
            set
            {
                this._modifyType = value;
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
    }
}

