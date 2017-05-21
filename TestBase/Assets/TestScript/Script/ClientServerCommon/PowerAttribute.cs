namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="PowerAttribute")]
    public class PowerAttribute : IExtensible
    {
        private float _baseValue;
        private float _deltaValue;
        private IExtension extensionObject;

        public float GetValue(int level)
        {
            return (this._baseValue + (this._deltaValue * (level - 1)));
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static PowerAttribute LoadFromXml(SecurityElement element)
        {
            return new PowerAttribute { 
                baseValue = StrParser.ParseFloat(element.Attribute("Base"), 0f),
                deltaValue = StrParser.ParseFloat(element.Attribute("Delta"), 0f)
            };
        }

        [ProtoMember(1, IsRequired=false, Name="baseValue", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
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

        [DefaultValue((float) 0f), ProtoMember(2, IsRequired=false, Name="deltaValue", DataFormat=DataFormat.FixedSize)]
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
    }
}

