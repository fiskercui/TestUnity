namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="DomineerConfig")]
    public class DomineerConfig : Configuration, IExtensible
    {
        private readonly List<DefaultDomineer> _defalultDomineers = new List<DefaultDomineer>();
        private readonly List<DomineerCostSet> _domineerCostSets = new List<DomineerCostSet>();
        private readonly List<Domineer> _domineers = new List<Domineer>();
        private int _needAvatarBreakThroughLevel;
        private int _needPlayerLevel;
        private Dictionary<int, Domineer> dic_domineer = new Dictionary<int, Domineer>();
        private IExtension extensionObject;

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Domineer domineer in this._domineers)
            {
                if (this.dic_domineer.ContainsKey(domineer.DomineerId))
                {
                    Logger.Error(base.GetType().Name + " Contains 0x" + domineer.DomineerId.ToString("X8"), new object[0]);
                }
                else
                {
                    this.dic_domineer.Add(domineer.DomineerId, domineer);
                }
            }
        }

        public int GetCostAvatarCount(int qualityLevel, int domineerLevel)
        {
            DomineerCost domineerCostByLevel = this.GetDomineerCostSetByQualityLevel(qualityLevel).GetDomineerCostByLevel(domineerLevel);
            return (domineerCostByLevel.ItemCostItemCount / domineerCostByLevel.SameCardDeductItemCount);
        }

        public DefaultDomineer GetDefaultDomineerByCountryType(int type)
        {
            foreach (DefaultDomineer domineer in this.DefalultDomineers)
            {
                if (domineer.AvatarCountryType == type)
                {
                    return domineer;
                }
            }
            return null;
        }

        public Domineer GetDomineerById(int id)
        {
            if (this.dic_domineer.ContainsKey(id))
            {
                return this.dic_domineer[id];
            }
            return null;
        }

        public DomineerCostSet GetDomineerCostSetByQualityLevel(int quality)
        {
            foreach (DomineerCostSet set in this._domineerCostSets)
            {
                if (set.AvatarQualityLevel == quality)
                {
                    return set;
                }
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _DomineerType.Initialize();
        }

        private void LoadDefaultDomineerFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "DefaultDomineer")
                    {
                        DefaultDomineer item = new DefaultDomineer {
                            DomineerId = StrParser.ParseHexInt(element2.Attribute("DomineerId"), 0),
                            AvatarCountryType = TypeNameContainer<AvatarConfig._AvatarCountryType>.Parse(element2.Attribute("AvatarCountryType"), 0),
                            Level = StrParser.ParseDecInt(element2.Attribute("Level"), 0)
                        };
                        this._defalultDomineers.Add(item);
                    }
                }
            }
        }

        private DomineerCostSet LoadDimineerCostSetFromXml(SecurityElement element)
        {
            DomineerCostSet set = new DomineerCostSet {
                AvatarQualityLevel = StrParser.ParseDecInt(element.Attribute("AvatarQualityLevel"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "DomineerCost")
                    {
                        set.DomineerCosts.Add(this.LoadDomineerCostFromXml(element2));
                    }
                }
            }
            return set;
        }

        private DomineerCost LoadDomineerCostFromXml(SecurityElement element)
        {
            DomineerCost cost = new DomineerCost {
                DomineerLevel = StrParser.ParseDecInt(element.Attribute("DomineerLevel"), 0),
                SameCardDeductItemCount = StrParser.ParseDecInt(element.Attribute("SameCardDeductItemCount"), 0),
                ItemCostItemId = StrParser.ParseHexInt(element.Attribute("ItemCostItemId"), 0),
                ItemCostItemCount = StrParser.ParseDecInt(element.Attribute("ItemCostItemCount"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "OtherCost")
                    {
                        cost.OtherCosts.Add(Cost.LoadFromXml(element2));
                    }
                }
            }
            return cost;
        }

        private Domineer LoadDomineerFromXml(SecurityElement element)
        {
            Domineer domineer = new Domineer {
                DomineerId = StrParser.ParseHexInt(element.Attribute("DomineerId"), 0),
                Type = TypeNameContainer<_DomineerType>.Parse(element.Attribute("Type"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "DomineerLevel")
                    {
                        domineer.DomineerLevels.Add(this.LoadDomineerLevelFromXml(element2));
                    }
                }
            }
            return domineer;
        }

        private DomineerLevel LoadDomineerLevelFromXml(SecurityElement element)
        {
            return new DomineerLevel { 
                Level = StrParser.ParseDecInt(element.Attribute("Level"), 0),
                Desc = StrParser.ParseStr(element.Attribute("Desc"), string.Empty),
                DomineerPower = StrParser.ParseFloat(element.Attribute("DomineerPower"), 0f)
            };
        }

        private void LoadDomineerSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Domineer")
                    {
                        this._domineers.Add(this.LoadDomineerFromXml(element2));
                    }
                }
            }
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "DomineerConfig")
            {
                this._needAvatarBreakThroughLevel = StrParser.ParseDecInt(element.Attribute("NeedAvatarBreakThroughLevel"), 0);
                this._needPlayerLevel = StrParser.ParseDecInt(element.Attribute("NeedPlayerLevel"), 0);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag != "DomineerSet")
                            {
                                if (tag == "DefaultDomineerSet")
                                {
                                    goto Label_00A2;
                                }
                                if (tag == "DomineerCostSet")
                                {
                                    goto Label_00AB;
                                }
                            }
                            else
                            {
                                this.LoadDomineerSetFromXml(element2);
                            }
                        }
                        continue;
                    Label_00A2:
                        this.LoadDefaultDomineerFromXml(element2);
                        continue;
                    Label_00AB:
                        this.DomineerCostSets.Add(this.LoadDimineerCostSetFromXml(element2));
                    }
                }
            }
        }

        [ProtoMember(2, Name="defalultDomineers", DataFormat=DataFormat.Default)]
        public List<DefaultDomineer> DefalultDomineers
        {
            get
            {
                return this._defalultDomineers;
            }
        }

        [ProtoMember(3, Name="domineerCostSets", DataFormat=DataFormat.Default)]
        public List<DomineerCostSet> DomineerCostSets
        {
            get
            {
                return this._domineerCostSets;
            }
        }

        [ProtoMember(1, Name="domineers", DataFormat=DataFormat.Default)]
        public List<Domineer> Domineers
        {
            get
            {
                return this._domineers;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="needAvatarBreakThroughLevel", DataFormat=DataFormat.TwosComplement)]
        public int NeedAvatarBreakThroughLevel
        {
            get
            {
                return this._needAvatarBreakThroughLevel;
            }
            set
            {
                this._needAvatarBreakThroughLevel = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="needPlayerLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int NeedPlayerLevel
        {
            get
            {
                return this._needPlayerLevel;
            }
            set
            {
                this._needPlayerLevel = value;
            }
        }

        public class _DomineerType : TypeNameContainer<DomineerConfig._DomineerType>
        {
            public const int HeZong = 2;
            public const int LianHeng = 1;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DomineerConfig._DomineerType>.RegisterType("LianHeng", 1);
                return (flag & TypeNameContainer<DomineerConfig._DomineerType>.RegisterType("HeZong", 2));
            }
        }

        [ProtoContract(Name="DefaultDomineer")]
        public class DefaultDomineer : IExtensible
        {
            private int _avatarCountryType;
            private int _domineerId;
            private int _level;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="avatarCountryType", DataFormat=DataFormat.TwosComplement)]
            public int AvatarCountryType
            {
                get
                {
                    return this._avatarCountryType;
                }
                set
                {
                    this._avatarCountryType = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="domineerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int DomineerId
            {
                get
                {
                    return this._domineerId;
                }
                set
                {
                    this._domineerId = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
            public int Level
            {
                get
                {
                    return this._level;
                }
                set
                {
                    this._level = value;
                }
            }
        }

        [ProtoContract(Name="Domineer")]
        public class Domineer : IExtensible
        {
            private int _domineerId;
            private readonly List<DomineerConfig.DomineerLevel> _domineerLevels = new List<DomineerConfig.DomineerLevel>();
            private int _type;
            private IExtension extensionObject;

            public DomineerConfig.DomineerLevel GetDomineerLevelByLevel(int level)
            {
                foreach (DomineerConfig.DomineerLevel level2 in this.DomineerLevels)
                {
                    if (level2.Level == level)
                    {
                        return level2;
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="domineerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int DomineerId
            {
                get
                {
                    return this._domineerId;
                }
                set
                {
                    this._domineerId = value;
                }
            }

            [ProtoMember(2, Name="domineerLevels", DataFormat=DataFormat.Default)]
            public List<DomineerConfig.DomineerLevel> DomineerLevels
            {
                get
                {
                    return this._domineerLevels;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
            public int Type
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

        [ProtoContract(Name="DomineerCost")]
        public class DomineerCost : IExtensible
        {
            private int _domineerLevel;
            private int _itemCostItemCount;
            private int _itemCostItemId;
            private readonly List<Cost> _otherCosts = new List<Cost>();
            private int _sameCardDeductItemCount;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="domineerLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int DomineerLevel
            {
                get
                {
                    return this._domineerLevel;
                }
                set
                {
                    this._domineerLevel = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="itemCostItemCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ItemCostItemCount
            {
                get
                {
                    return this._itemCostItemCount;
                }
                set
                {
                    this._itemCostItemCount = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="itemCostItemId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ItemCostItemId
            {
                get
                {
                    return this._itemCostItemId;
                }
                set
                {
                    this._itemCostItemId = value;
                }
            }

            [ProtoMember(5, Name="otherCosts", DataFormat=DataFormat.Default)]
            public List<Cost> OtherCosts
            {
                get
                {
                    return this._otherCosts;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="sameCardDeductItemCount", DataFormat=DataFormat.TwosComplement)]
            public int SameCardDeductItemCount
            {
                get
                {
                    return this._sameCardDeductItemCount;
                }
                set
                {
                    this._sameCardDeductItemCount = value;
                }
            }
        }

        [ProtoContract(Name="DomineerCostSet")]
        public class DomineerCostSet : IExtensible
        {
            private int _avatarQualityLevel;
            private readonly List<DomineerConfig.DomineerCost> _domineerCosts = new List<DomineerConfig.DomineerCost>();
            private IExtension extensionObject;

            public DomineerConfig.DomineerCost GetDomineerCostByLevel(int level)
            {
                foreach (DomineerConfig.DomineerCost cost in this.DomineerCosts)
                {
                    if (cost.DomineerLevel == level)
                    {
                        return cost;
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="avatarQualityLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int AvatarQualityLevel
            {
                get
                {
                    return this._avatarQualityLevel;
                }
                set
                {
                    this._avatarQualityLevel = value;
                }
            }

            [ProtoMember(2, Name="domineerCosts", DataFormat=DataFormat.Default)]
            public List<DomineerConfig.DomineerCost> DomineerCosts
            {
                get
                {
                    return this._domineerCosts;
                }
            }
        }

        [ProtoContract(Name="DomineerLevel")]
        public class DomineerLevel : IExtensible
        {
            private string _desc = "";
            private float _domineerPower;
            private int _level;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="desc", DataFormat=DataFormat.Default)]
            public string Desc
            {
                get
                {
                    return this._desc;
                }
                set
                {
                    this._desc = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="domineerPower", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float DomineerPower
            {
                get
                {
                    return this._domineerPower;
                }
                set
                {
                    this._domineerPower = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Level
            {
                get
                {
                    return this._level;
                }
                set
                {
                    this._level = value;
                }
            }
        }
    }
}

