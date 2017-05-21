namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="GrowthAttribute")]
    public class GrowthAttribute : IExtensible
    {
        private float _baseValue;
        private float _deltaValue;
        private int _powerValue;
        private int _type;
        private IExtension extensionObject;

        public float GetValue(int level)
        {
            return (this._baseValue + (this._deltaValue * (level - 1)));
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static GrowthAttribute LoadFromXml(SecurityElement element)
        {
            return new GrowthAttribute { 
                type = TypeNameContainer<_AvatarAttributeType>.Parse(element.Attribute("Type"), 0),
                baseValue = StrParser.ParseFloat(element.Attribute("Base"), 0f),
                deltaValue = StrParser.ParseFloat(element.Attribute("Delta"), 0f)
            };
        }

        [ProtoMember(2, IsRequired=false, Name="baseValue", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float baseValue
        {
            get
            {
                return this._baseValue;
            }
            set
            {
                this._baseValue = value;
            }
        }

        [DefaultValue((float) 0f), ProtoMember(3, IsRequired=false, Name="deltaValue", DataFormat=DataFormat.FixedSize)]
        public float deltaValue
        {
            get
            {
                return this._deltaValue;
            }
            set
            {
                this._deltaValue = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="powerValue", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int powerValue
        {
            get
            {
                return this._powerValue;
            }
            set
            {
                this._powerValue = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
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

