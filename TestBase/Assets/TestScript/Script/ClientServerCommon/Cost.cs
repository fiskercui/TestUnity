namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="Cost")]
    public class Cost : IExtensible
    {
        private int _count;
        private int _id;
        private int _increase;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static Cost LoadFromXml(SecurityElement element)
        {
            return new Cost { 
                _id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                _count = StrParser.ParseDecInt(element.Attribute("Count"), 0),
                _increase = StrParser.ParseDecInt(element.Attribute("Increase"), 0)
            };
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
        public int count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="increase", DataFormat=DataFormat.TwosComplement)]
        public int increase
        {
            get
            {
                return this._increase;
            }
            set
            {
                this._increase = value;
            }
        }
    }
}

