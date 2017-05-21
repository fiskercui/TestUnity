namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="DinerConfig")]
    public class DinerConfig : Configuration, IExtensible
    {
        private readonly List<DinerBagRefreshTime> _dinerBagRefreshTimes = new List<DinerBagRefreshTime>();
        private readonly List<DinerBag> _dinerBags = new List<DinerBag>();
        private readonly List<Diner> _diners = new List<Diner>();
        private int _recommandAvatarIcon;
        private long _resetTime;
        private Dictionary<int, DinerBag> dic_bags = new Dictionary<int, DinerBag>();
        private Dictionary<int, List<DinerBag>> dic_dinerBags = new Dictionary<int, List<DinerBag>>();
        private Dictionary<int, Diner> dic_diners = new Dictionary<int, Diner>();
        private IExtension extensionObject;

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (DinerBag bag in this.DinerBags)
            {
                if (!this.dic_dinerBags.ContainsKey(bag.QualityType))
                {
                    this.dic_dinerBags.Add(bag.QualityType, new List<DinerBag>());
                }
                this.dic_bags.Add(bag.BagId, bag);
                this.dic_dinerBags[bag.QualityType].Add(bag);
            }
            foreach (Diner diner in this.Diners)
            {
                if (this.dic_diners.ContainsKey(diner.DinerId))
                {
                    Logger.Error(base.GetType().Name + " ContainsDinerId 0x" + diner.DinerId.ToString("X"), new object[0]);
                }
                else
                {
                    this.dic_diners.Add(diner.DinerId, diner);
                }
            }
        }

        public DinerBag GetDinerBagById(int id)
        {
            if (this.dic_bags.ContainsKey(id))
            {
                return this.dic_bags[id];
            }
            return null;
        }

        public DinerBag GetDinerBagByRefreshType(int qualityType, int refreshType)
        {
            if (this.dic_dinerBags.ContainsKey(qualityType))
            {
                foreach (DinerBag bag in this.dic_dinerBags[qualityType])
                {
                    if (bag.RefreshType == refreshType)
                    {
                        return bag;
                    }
                }
            }
            return null;
        }

        public List<DinerBag> GetDinerBagsByQuality(int qualityType)
        {
            if (this.dic_dinerBags.ContainsKey(qualityType))
            {
                return this.dic_dinerBags[qualityType];
            }
            return null;
        }

        public Diner GetDinerById(int dinerId)
        {
            if (this.dic_diners.ContainsKey(dinerId))
            {
                return this.dic_diners[dinerId];
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _AvatarRarityType.Initialize();
            _DinerRefreshType.Initialize();
            DinerRecommendState.Initialize();
        }

        private List<Cost> LoadCostsFromXml(SecurityElement element)
        {
            List<Cost> list = new List<Cost>();
            if ((element != null) && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Cost"))
                    {
                        Cost item = new Cost {
                            id = StrParser.ParseHexInt(element2.Attribute("Id"), 0),
                            count = StrParser.ParseDecInt(element2.Attribute("Count"), 0)
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        private List<int> LoadDinerBagIdsFromXml(SecurityElement element)
        {
            List<int> list = new List<int>();
            if ((element != null) && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "DinerBagId"))
                    {
                        list.Add(StrParser.ParseHexInt(element2.Attribute("DinerBagId"), 0));
                    }
                }
            }
            return list;
        }

        private void LoadDinerBagRefreshTimesFromXml(SecurityElement element)
        {
            if ((element != null) && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "DinerBagRefreshTime"))
                    {
                        DinerBagRefreshTime item = new DinerBagRefreshTime {
                            DinerBagQuality = TypeNameContainer<_AvatarRarityType>.Parse(element2.Attribute("DinerBagQuality"), 0)
                        };
                        this.DinerBagRefreshTimes.Add(item);
                    }
                }
            }
        }

        private void LoadDinerBagsFromXml(SecurityElement element)
        {
            if (element.Tag == "DinerBagCollection")
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "DinerBag"))
                    {
                        DinerBag item = new DinerBag {
                            BagId = StrParser.ParseHexInt(element2.Attribute("BagId"), 0),
                            QualityType = TypeNameContainer<_AvatarRarityType>.Parse(element2.Attribute("QualityType"), 0),
                            RefreshType = TypeNameContainer<_DinerRefreshType>.Parse(element2.Attribute("RefreshType"), 0),
                            IconId = StrParser.ParseHexInt(element2.Attribute("IconId"), 0),
                            BackGroundId = StrParser.ParseHexInt(element2.Attribute("BackGroundId"), 0)
                        };
                        item.DinerBagIds.AddRange(this.LoadDinerBagIdsFromXml(element2.SearchForChildByTag("DinerBagIdCollection")));
                        item.Costs.AddRange(this.LoadCostsFromXml(element2.SearchForChildByTag("CostCollection")));
                        this.DinerBags.Add(item);
                    }
                }
            }
        }

        private void LoadDinersFromXml(SecurityElement element)
        {
            if ((element.Tag == "DinerCollection") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Diner"))
                    {
                        Diner item = new Diner {
                            DinerId = StrParser.ParseHexInt(element2.Attribute("DinerId"), 0),
                            RemainTime = StrParser.ParseDecInt(element2.Attribute("RemainTime"), 0)
                        };
                        this.Diners.Add(item);
                    }
                }
            }
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "DinerConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "DinerBagCollection")
                        {
                            if (tag == "DinerCollection")
                            {
                                goto Label_0094;
                            }
                            if (tag == "DinerBagRefreshTimeCollection")
                            {
                                goto Label_009D;
                            }
                            if (tag == "SystemResetTime")
                            {
                                goto Label_00A6;
                            }
                            if (tag == "RecommandAvatarIcon")
                            {
                                goto Label_00B9;
                            }
                        }
                        else
                        {
                            this.LoadDinerBagsFromXml(element2);
                        }
                    }
                    continue;
                Label_0094:
                    this.LoadDinersFromXml(element2);
                    continue;
                Label_009D:
                    this.LoadDinerBagRefreshTimesFromXml(element2);
                    continue;
                Label_00A6:
                    this._resetTime = StrParser.ParseDateTime(element2.Text);
                    continue;
                Label_00B9:
                    this._recommandAvatarIcon = StrParser.ParseHexInt(element2.Text, 0);
                }
            }
        }

        private List<long> LoadRefreshTimesFromXml(SecurityElement element)
        {
            List<long> list = new List<long>();
            if ((element != null) && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "RefreshTime"))
                    {
                        list.Add(StrParser.ParseDateTime(element2.Attribute("RefreshTime")));
                    }
                }
            }
            return list;
        }

        public DateTime toDateTime(long time)
        {
            return new DateTime(time * 0x2710L);
        }

        [ProtoMember(4, Name="dinerBagRefreshTimes", DataFormat=DataFormat.Default)]
        public List<DinerBagRefreshTime> DinerBagRefreshTimes
        {
            get
            {
                return this._dinerBagRefreshTimes;
            }
        }

        [ProtoMember(2, Name="dinerBags", DataFormat=DataFormat.Default)]
        public List<DinerBag> DinerBags
        {
            get
            {
                return this._dinerBags;
            }
        }

        [ProtoMember(3, Name="diners", DataFormat=DataFormat.Default)]
        public List<Diner> Diners
        {
            get
            {
                return this._diners;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="recommandAvatarIcon", DataFormat=DataFormat.TwosComplement)]
        public int RecommandAvatarIcon
        {
            get
            {
                return this._recommandAvatarIcon;
            }
            set
            {
                this._recommandAvatarIcon = value;
            }
        }

        public DateTime ResetDataTime
        {
            get
            {
                return new DateTime(this._resetTime * 0x2710L);
            }
        }

        [DefaultValue((long) 0L), ProtoMember(1, IsRequired=false, Name="resetTime", DataFormat=DataFormat.TwosComplement)]
        public long ResetTime
        {
            get
            {
                return this._resetTime;
            }
            set
            {
                this._resetTime = value;
            }
        }

        public class _AvatarRarityType : TypeNameContainer<DinerConfig._AvatarRarityType>
        {
            public const int Elite = 2;
            public const int Normal = 1;
            public const int Rare = 3;
            public const int Unkonw = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DinerConfig._AvatarRarityType>.RegisterType("Unkonw", 0, "AvatarRarityType_Unkonw");
                flag &= TypeNameContainer<DinerConfig._AvatarRarityType>.RegisterType("Normal", 1, "AvatarRarityType_Normal");
                flag &= TypeNameContainer<DinerConfig._AvatarRarityType>.RegisterType("Elite", 2, "AvatarRarityType_Elite");
                return (flag & TypeNameContainer<DinerConfig._AvatarRarityType>.RegisterType("Rare", 3, "AvatarRarityType_Rare"));
            }
        }

        public class _DinerRefreshType : TypeNameContainer<DinerConfig._DinerRefreshType>
        {
            public const int Common = 1;
            public const int Special = 2;
            public const int System = 3;
            public const int Unkonw = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DinerConfig._DinerRefreshType>.RegisterType("Unkonw", 0, "DinerRefreshType_Unkonw");
                flag &= TypeNameContainer<DinerConfig._DinerRefreshType>.RegisterType("Common", 1, "DinerRefreshType_Common");
                flag &= TypeNameContainer<DinerConfig._DinerRefreshType>.RegisterType("Special", 2, "DinerRefreshType_Special");
                return (flag & TypeNameContainer<DinerConfig._DinerRefreshType>.RegisterType("System", 3, "DinerRefreshType_System"));
            }
        }

        [ProtoContract(Name="Diner")]
        public class Diner : IExtensible
        {
            private int _dinerId;
            private int _remainTime;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="dinerId", DataFormat=DataFormat.TwosComplement)]
            public int DinerId
            {
                get
                {
                    return this._dinerId;
                }
                set
                {
                    this._dinerId = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="remainTime", DataFormat=DataFormat.TwosComplement)]
            public int RemainTime
            {
                get
                {
                    return this._remainTime;
                }
                set
                {
                    this._remainTime = value;
                }
            }
        }

        [ProtoContract(Name="DinerBag")]
        public class DinerBag : IExtensible
        {
            private int _backGroundId;
            private int _bagId;
            private readonly List<Cost> _costs = new List<Cost>();
            private readonly List<int> _dinerBagIds = new List<int>();
            private int _iconId;
            private int _qualityType;
            private int _refreshType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, IsRequired=false, Name="backGroundId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int BackGroundId
            {
                get
                {
                    return this._backGroundId;
                }
                set
                {
                    this._backGroundId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="bagId", DataFormat=DataFormat.TwosComplement)]
            public int BagId
            {
                get
                {
                    return this._bagId;
                }
                set
                {
                    this._bagId = value;
                }
            }

            [ProtoMember(7, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> Costs
            {
                get
                {
                    return this._costs;
                }
            }

            [ProtoMember(4, Name="dinerBagIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> DinerBagIds
            {
                get
                {
                    return this._dinerBagIds;
                }
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement)]
            public int IconId
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

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="qualityType", DataFormat=DataFormat.TwosComplement)]
            public int QualityType
            {
                get
                {
                    return this._qualityType;
                }
                set
                {
                    this._qualityType = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="refreshType", DataFormat=DataFormat.TwosComplement)]
            public int RefreshType
            {
                get
                {
                    return this._refreshType;
                }
                set
                {
                    this._refreshType = value;
                }
            }
        }

        [ProtoContract(Name="DinerBagRefreshTime")]
        public class DinerBagRefreshTime : IExtensible
        {
            private int _dinerBagQuality;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="dinerBagQuality", DataFormat=DataFormat.TwosComplement)]
            public int DinerBagQuality
            {
                get
                {
                    return this._dinerBagQuality;
                }
                set
                {
                    this._dinerBagQuality = value;
                }
            }
        }

        public class DinerRecommendState : TypeNameContainer<DinerConfig.DinerRecommendState>
        {
            public const int Activity = 2;
            public const int Normal = 1;
            public const int Recommend = 3;
            public const int Unkonw = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DinerConfig.DinerRecommendState>.RegisterType("Unkonw", 0, "Unkonw");
                flag &= TypeNameContainer<DinerConfig.DinerRecommendState>.RegisterType("Normal", 2, "Normal");
                flag &= TypeNameContainer<DinerConfig.DinerRecommendState>.RegisterType("Activity", 2, "Activity");
                return (flag & TypeNameContainer<DinerConfig.DinerRecommendState>.RegisterType("Recommend", 3, "Recommend"));
            }
        }
    }
}

