namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="Attribute")]
    public class Attribute : IExtensible
    {
        private int _type;
        private double _value;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static ClientServerCommon.Attribute LoadFromXml(SecurityElement element)
        {
            return new ClientServerCommon.Attribute { 
                type = TypeNameContainer<_AvatarAttributeType>.Parse(element.Attribute("Type"), 0),
                value = StrParser.ParseDouble(element.Attribute("Value"), 0.0)
            };
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

        [DefaultValue((double) 0.0), ProtoMember(2, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement)]
        public double value
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

