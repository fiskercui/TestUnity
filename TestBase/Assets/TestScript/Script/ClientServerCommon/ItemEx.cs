namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="ItemEx")]
    public class ItemEx : IExtensible
    {
        private int _count;
        private int _extensionBreakThroughLevelFrom;
        private int _extensionBreakThroughLevelTo;
        private int _extensionLevelFrom;
        private int _extensionLevelTo;
        private int _id;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static ItemEx LoadItemExFromXml(SecurityElement element)
        {
            return new ItemEx { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                count = StrParser.ParseDecInt(element.Attribute("Count"), 0),
                extensionBreakThroughLevelFrom = StrParser.ParseDecInt(element.Attribute("ExtensionBreakThroughLevelFrom"), 0),
                extensionBreakThroughLevelTo = StrParser.ParseDecInt(element.Attribute("ExtensionBreakThroughLevelTo"), 0),
                extensionLevelFrom = StrParser.ParseDecInt(element.Attribute("ExtensionLevelFrom"), 0),
                extensionLevelTo = StrParser.ParseDecInt(element.Attribute("ExtensionLevelTo"), 0)
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="extensionBreakThroughLevelFrom", DataFormat=DataFormat.TwosComplement)]
        public int extensionBreakThroughLevelFrom
        {
            get
            {
                return this._extensionBreakThroughLevelFrom;
            }
            set
            {
                this._extensionBreakThroughLevelFrom = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="extensionBreakThroughLevelTo", DataFormat=DataFormat.TwosComplement)]
        public int extensionBreakThroughLevelTo
        {
            get
            {
                return this._extensionBreakThroughLevelTo;
            }
            set
            {
                this._extensionBreakThroughLevelTo = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="extensionLevelFrom", DataFormat=DataFormat.TwosComplement)]
        public int extensionLevelFrom
        {
            get
            {
                return this._extensionLevelFrom;
            }
            set
            {
                this._extensionLevelFrom = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="extensionLevelTo", DataFormat=DataFormat.TwosComplement)]
        public int extensionLevelTo
        {
            get
            {
                return this._extensionLevelTo;
            }
            set
            {
                this._extensionLevelTo = value;
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
    }
}

