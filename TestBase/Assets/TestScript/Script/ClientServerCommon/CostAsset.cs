namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="CostAsset")]
    public class CostAsset : IExtensible
    {
        private int _breakThroughLevelFrom;
        private int _breakThroughLevelTo;
        private int _count;
        private int _iconId;
        private int _levelFrom;
        private int _levelTo;
        private int _qualityLevel;
        private int _subType;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static CostAsset LoadCostAssetFromXml(SecurityElement element)
        {
            CostAsset asset = new CostAsset {
                iconId = StrParser.ParseHexInt(element.Attribute("IconId"), 0),
                type = TypeNameContainer<IDSeg>.Parse(element.Attribute("Type"), 0),
                count = StrParser.ParseDecInt(element.Attribute("Count"), 0),
                qualityLevel = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0),
                breakThroughLevelFrom = StrParser.ParseDecInt(element.Attribute("BreakThroughLevelFrom"), 0),
                breakThroughLevelTo = StrParser.ParseDecInt(element.Attribute("BreakThroughLevelTo"), 0)
            };
            switch (asset.type)
            {
                case 3:
                    asset._subType = TypeNameContainer<AvatarConfig._AvatarCountryType>.Parse(element.Attribute("SubType"), 0);
                    return asset;

                case 4:
                    asset.subType = TypeNameContainer<EquipmentConfig._Type>.Parse(element.Attribute("SubType"), 0);
                    return asset;

                case 0x57:
                    asset._subType = TypeNameContainer<DanConfig._DanType>.Parse(element.Attribute("SubType"), 0);
                    return asset;
            }
            return asset;
        }

        [ProtoMember(5, IsRequired=false, Name="breakThroughLevelFrom", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int breakThroughLevelFrom
        {
            get
            {
                return this._breakThroughLevelFrom;
            }
            set
            {
                this._breakThroughLevelFrom = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="breakThroughLevelTo", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int breakThroughLevelTo
        {
            get
            {
                return this._breakThroughLevelTo;
            }
            set
            {
                this._breakThroughLevelTo = value;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(1, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int iconId
        {
            get
            {
                return this._iconId;
            }
            set
            {
                this._iconId = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="levelFrom", DataFormat=DataFormat.TwosComplement)]
        public int levelFrom
        {
            get
            {
                return this._levelFrom;
            }
            set
            {
                this._levelFrom = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="levelTo", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int levelTo
        {
            get
            {
                return this._levelTo;
            }
            set
            {
                this._levelTo = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="qualityLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int qualityLevel
        {
            get
            {
                return this._qualityLevel;
            }
            set
            {
                this._qualityLevel = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="subType", DataFormat=DataFormat.TwosComplement)]
        public int subType
        {
            get
            {
                return this._subType;
            }
            set
            {
                this._subType = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
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

