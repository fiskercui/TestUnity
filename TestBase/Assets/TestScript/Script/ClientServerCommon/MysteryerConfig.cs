namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="MysteryerConfig")]
    public class MysteryerConfig : Configuration, IExtensible
    {
        private int _activityId;
        private readonly List<CardPack> _cardPackSet = new List<CardPack>();
        private int _defaultAvatarCardPackId;
        private int _defaultEquipCardPackId;
        private readonly List<Goods> _goodsSet = new List<Goods>();
        private readonly List<MysteryActivity> _mysteryActivitys = new List<MysteryActivity>();
        private readonly List<QualityWeightInfo> _qualityWeightInfos = new List<QualityWeightInfo>();
        private readonly List<RefreshInfo> _refreshInfos = new List<RefreshInfo>();
        private readonly List<WeightIncrease> _weightIncreases = new List<WeightIncrease>();
        private IExtension extensionObject;

        public CardPack GetCardPackById(int packId)
        {
            foreach (CardPack pack in this._cardPackSet)
            {
                if (pack.CardPackId == packId)
                {
                    return pack;
                }
            }
            return null;
        }

        public Goods GetGoodsById(int id)
        {
            foreach (Goods goods in this._goodsSet)
            {
                if (goods.goodsId == id)
                {
                    return goods;
                }
            }
            return null;
        }

        public Goods GetGoodsByRewardId(int id)
        {
            foreach (Goods goods in this._goodsSet)
            {
                if ((goods.reward != null) && (goods.reward.id == id))
                {
                    return goods;
                }
            }
            return null;
        }

        public MysteryActivity GetMysteryActivityByNum(int activityNum)
        {
            foreach (MysteryActivity activity in this._mysteryActivitys)
            {
                if (activity.ActivityNum == activityNum)
                {
                    return activity;
                }
            }
            return null;
        }

        public RefreshInfo GetRefreshInfoByIndex(int index)
        {
            foreach (RefreshInfo info in this._refreshInfos)
            {
                if (info.Index == index)
                {
                    return info;
                }
            }
            return null;
        }

        public WeightIncrease GetWeightIncreaseByLevel(int level)
        {
            foreach (WeightIncrease increase in this._weightIncreases)
            {
                if (increase.Level == level)
                {
                    return increase;
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
            _RefreshType.Initialize();
            _OperateType.Initialize();
        }

        private List<CardPack> loadCardPackSetFromXml(SecurityElement element)
        {
            List<CardPack> list = new List<CardPack>();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "CardPack"))
                    {
                        CardPack cp = new CardPack {
                            CardPackId = StrParser.ParseHexInt(element2.Attribute("CardPackId"), 0)
                        };
                        this.loadGoodsWeightFromXml(element2, cp);
                        list.Add(cp);
                    }
                }
            }
            return list;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "MysteryerConfig") && (element.Children != null))
            {
                this._activityId = StrParser.ParseHexInt(element.Attribute("ActivityId"), 0);
                this._defaultAvatarCardPackId = StrParser.ParseHexInt(element.Attribute("DefaultAvatarCardPackId"), 0);
                this._defaultEquipCardPackId = StrParser.ParseHexInt(element.Attribute("DefaultEquipCardPackId"), 0);
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "RefreshInfoSet")
                        {
                            if (tag == "MysteryActivitySet")
                            {
                                goto Label_00E6;
                            }
                            if (tag == "CardPackSet")
                            {
                                goto Label_00EF;
                            }
                            if (tag == "QualityWeightInfoSet")
                            {
                                goto Label_0103;
                            }
                            if (tag == "GoodsSet")
                            {
                                goto Label_010C;
                            }
                            if (tag == "WeightIncreaseSet")
                            {
                                goto Label_0120;
                            }
                        }
                        else
                        {
                            this.LoadRefreshInfosFromXml(element2);
                        }
                    }
                    continue;
                Label_00E6:
                    this.LoadMysteryActivitysFromXml(element2);
                    continue;
                Label_00EF:
                    this._cardPackSet.AddRange(this.loadCardPackSetFromXml(element2));
                    continue;
                Label_0103:
                    this.LoadQualityWeightInfosFromXml(element2);
                    continue;
                Label_010C:
                    this._goodsSet.AddRange(this.loadGoodsSetFromXml(element2));
                    continue;
                Label_0120:
                    this.LoadWeightIncreasesFromXml(element2);
                }
            }
        }

        private Goods loadGoodsFromXml(SecurityElement element)
        {
            Goods goods = new Goods {
                goodsId = StrParser.ParseHexInt(element.Attribute("GoodsId"), 0),
                weight = StrParser.ParseDecInt(element.Attribute("Weight"), 0),
                quality = StrParser.ParseDecInt(element.Attribute("Quality"), 0),
                type = TypeNameContainer<_RefreshType>.Parse(element.Attribute("Type"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "Cost")
                        {
                            if (tag == "DiscountCost")
                            {
                                goto Label_00C8;
                            }
                            if (tag == "Reward")
                            {
                                goto Label_00D6;
                            }
                        }
                        else
                        {
                            goods.cost = Cost.LoadFromXml(element2);
                        }
                    }
                    continue;
                Label_00C8:
                    goods.discountCost = Cost.LoadFromXml(element2);
                    continue;
                Label_00D6:
                    goods.reward = Reward.LoadFromXml(element2);
                }
            }
            return goods;
        }

        private List<Goods> loadGoodsSetFromXml(SecurityElement element)
        {
            List<Goods> list = new List<Goods>();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Goods"))
                    {
                        list.Add(this.loadGoodsFromXml(element2));
                    }
                }
            }
            return list;
        }

        private void loadGoodsWeightFromXml(SecurityElement element, CardPack cp)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Goods"))
                    {
                        GoodsWeight item = new GoodsWeight {
                            GoodsId = StrParser.ParseHexInt(element2.Attribute("GoodsId"), 0),
                            Weight = StrParser.ParseDecInt(element2.Attribute("Weight"), 0)
                        };
                        cp.GoodsWeights.Add(item);
                    }
                }
            }
        }

        public void LoadMysteryActivitysFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "MysteryActivity"))
                    {
                        MysteryActivity item = new MysteryActivity {
                            ActivityNum = StrParser.ParseDecInt(element2.Attribute("ActivityNum"), 0),
                            FirstRefreshType = TypeNameContainer<_RefreshType>.Parse(element2.Attribute("FirstRefreshType"), 0),
                            IsDelItem = StrParser.ParseBool(element2.Attribute("IsDelItem"), false),
                            ItemId = StrParser.ParseHexInt(element2.Attribute("ItemId"), 0),
                            ShowCardId1 = StrParser.ParseHexInt(element2.Attribute("ShowCardId1"), 0),
                            ShowCardId2 = StrParser.ParseHexInt(element2.Attribute("ShowCardId2"), 0),
                            ShowCardId3 = StrParser.ParseHexInt(element2.Attribute("ShowCardId3"), 0)
                        };
                        foreach (SecurityElement element3 in element2.Children)
                        {
                            string tag = element3.Tag;
                            if (tag != null)
                            {
                                if (tag == "Refresh")
                                {
                                    item.Refreshs.Add(this.LoadRefreshFromXml(element3));
                                }
                                else if (tag == "TavernRewardInfo")
                                {
                                    goto Label_0147;
                                }
                            }
                            continue;
                        Label_0147:
                            item.TavernRewardInfos.Add(this.LoadTavernRewardInfoFromXml(element3));
                        }
                        this._mysteryActivitys.Add(item);
                    }
                }
            }
        }

        public QualityWeight LoadQualityWeightFromXml(SecurityElement element)
        {
            return new QualityWeight { 
                Quality = StrParser.ParseDecInt(element.Attribute("Quality"), 0),
                Weight = StrParser.ParseDecInt(element.Attribute("Weight"), 0)
            };
        }

        public void LoadQualityWeightInfosFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "QualityWeightInfo"))
                    {
                        QualityWeightInfo item = new QualityWeightInfo {
                            Place = StrParser.ParseDecInt(element2.Attribute("Place"), 0),
                            RefreshType = TypeNameContainer<_RefreshType>.Parse(element2.Attribute("RefreshType"), 0)
                        };
                        foreach (SecurityElement element3 in element2.Children)
                        {
                            string str2;
                            if (((str2 = element3.Tag) != null) && (str2 == "QualityWeight"))
                            {
                                item.QualityWeights.Add(this.LoadQualityWeightFromXml(element3));
                            }
                        }
                        this._qualityWeightInfos.Add(item);
                    }
                }
            }
        }

        public Refresh LoadRefreshFromXml(SecurityElement element)
        {
            Refresh refresh = new Refresh {
                RefreshId = StrParser.ParseHexInt(element.Attribute("RefreshId"), 0),
                OperateType = TypeNameContainer<_OperateType>.Parse(element.Attribute("OperateType"), 0),
                RefreshType = TypeNameContainer<_RefreshType>.Parse(element.Attribute("RefreshType"), 0),
                RefreshName = StrParser.ParseStr(element.Attribute("RefreshName"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    Counter counter;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Cost")
                        {
                            refresh.Cost = new Cost();
                            refresh.Cost = Cost.LoadFromXml(element2);
                        }
                        else if (tag == "Counter")
                        {
                            goto Label_00D9;
                        }
                    }
                    continue;
                Label_00D9:
                    counter = new Counter();
                    counter.CounterId = StrParser.ParseHexInt(element2.Attribute("CounterId"), 0);
                    counter.NeedRefreshTimes = StrParser.ParseDecInt(element2.Attribute("NeedRefreshTimes"), 0);
                    counter.CloseActivatedTimes = StrParser.ParseDecInt(element2.Attribute("CloseActivatedTimes"), 0);
                    counter.EffectiveProbability = StrParser.ParseDouble(element2.Attribute("EffectiveProbability"), 0.0);
                    counter.CardPackId = StrParser.ParseHexInt(element2.Attribute("CardPackId"), 0);
                    counter.IsShowCounter = StrParser.ParseBool(element2.Attribute("IsShowCounter"), false);
                    refresh.Counters.Add(counter);
                }
            }
            return refresh;
        }

        public void LoadRefreshInfosFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "RefreshInfo"))
                    {
                        RefreshInfo item = new RefreshInfo {
                            Index = StrParser.ParseDecInt(element2.Attribute("Index"), 0),
                            RefreshTime = StrParser.ParseDateTime(element2.Attribute("RefreshTime")),
                            RefreshType = TypeNameContainer<_RefreshType>.Parse(element2.Attribute("RefreshType"), 0)
                        };
                        this._refreshInfos.Add(item);
                    }
                }
            }
        }

        public TavernRewardInfo LoadTavernRewardInfoFromXml(SecurityElement element)
        {
            TavernRewardInfo info = new TavernRewardInfo {
                TavernId = StrParser.ParseHexInt(element.Attribute("TavernId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Reward")
                        {
                            info.Reward = Reward.LoadFromXml(element2);
                        }
                        else if (tag == "TenTavernReward")
                        {
                            goto Label_0073;
                        }
                    }
                    continue;
                Label_0073:
                    info.TenTavernReward = Reward.LoadFromXml(element2);
                }
            }
            return info;
        }

        public void LoadWeightIncreasesFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "WeightIncrease"))
                    {
                        WeightIncrease item = new WeightIncrease {
                            Level = StrParser.ParseDecInt(element2.Attribute("Level"), 0),
                            Increase = StrParser.ParseDouble(element2.Attribute("Increase"), 0.0)
                        };
                        this._weightIncreases.Add(item);
                    }
                }
            }
        }

        [ProtoMember(9, IsRequired=false, Name="activityId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int ActivityId
        {
            get
            {
                return this._activityId;
            }
            set
            {
                this._activityId = value;
            }
        }

        [ProtoMember(3, Name="cardPackSet", DataFormat=DataFormat.Default)]
        public List<CardPack> CardPackSet
        {
            get
            {
                return this._cardPackSet;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="defaultAvatarCardPackId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int DefaultAvatarCardPackId
        {
            get
            {
                return this._defaultAvatarCardPackId;
            }
            set
            {
                this._defaultAvatarCardPackId = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="defaultEquipCardPackId", DataFormat=DataFormat.TwosComplement)]
        public int DefaultEquipCardPackId
        {
            get
            {
                return this._defaultEquipCardPackId;
            }
            set
            {
                this._defaultEquipCardPackId = value;
            }
        }

        [ProtoMember(5, Name="goodsSet", DataFormat=DataFormat.Default)]
        public List<Goods> GoodsSet
        {
            get
            {
                return this._goodsSet;
            }
        }

        [ProtoMember(2, Name="mysteryActivitys", DataFormat=DataFormat.Default)]
        public List<MysteryActivity> MysteryActivitys
        {
            get
            {
                return this._mysteryActivitys;
            }
        }

        [ProtoMember(4, Name="qualityWeightInfos", DataFormat=DataFormat.Default)]
        public List<QualityWeightInfo> QualityWeightInfos
        {
            get
            {
                return this._qualityWeightInfos;
            }
        }

        [ProtoMember(1, Name="refreshInfos", DataFormat=DataFormat.Default)]
        public List<RefreshInfo> RefreshInfos
        {
            get
            {
                return this._refreshInfos;
            }
        }

        [ProtoMember(6, Name="weightIncreases", DataFormat=DataFormat.Default)]
        public List<WeightIncrease> WeightIncreases
        {
            get
            {
                return this._weightIncreases;
            }
        }

        public class _OperateType : TypeNameContainer<MysteryerConfig._OperateType>
        {
            public const int Player = 2;
            public const int System = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<MysteryerConfig._OperateType>.RegisterType("System", 1, "System");
                return (flag & TypeNameContainer<MysteryerConfig._OperateType>.RegisterType("Player", 2, "Player"));
            }
        }

        public class _RefreshType : TypeNameContainer<MysteryerConfig._RefreshType>
        {
            public const int Avatar = 1;
            public const int Equip = 2;
            public const int Item = 3;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<MysteryerConfig._RefreshType>.RegisterType("Avatar", 1, "Avatar");
                flag &= TypeNameContainer<MysteryerConfig._RefreshType>.RegisterType("Equip", 2, "Equip");
                return (flag & TypeNameContainer<MysteryerConfig._RefreshType>.RegisterType("Item", 3, "Item"));
            }

            public static bool isValidType(int type)
            {
                string nameByType = TypeNameContainer<MysteryerConfig._RefreshType>.GetNameByType(type);
                return ((nameByType != null) && (nameByType.Trim() != ""));
            }
        }

        [ProtoContract(Name="CardPack")]
        public class CardPack : IExtensible
        {
            private int _cardPackId;
            private readonly List<MysteryerConfig.GoodsWeight> _goodsWeights = new List<MysteryerConfig.GoodsWeight>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="cardPackId", DataFormat=DataFormat.TwosComplement)]
            public int CardPackId
            {
                get
                {
                    return this._cardPackId;
                }
                set
                {
                    this._cardPackId = value;
                }
            }

            [ProtoMember(2, Name="goodsWeights", DataFormat=DataFormat.Default)]
            public List<MysteryerConfig.GoodsWeight> GoodsWeights
            {
                get
                {
                    return this._goodsWeights;
                }
            }
        }

        [ProtoContract(Name="Counter")]
        public class Counter : IExtensible
        {
            private int _cardPackId;
            private int _closeActivatedTimes;
            private int _counterId;
            private double _effectiveProbability;
            private bool _isShowCounter;
            private int _needRefreshTimes;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, IsRequired=false, Name="cardPackId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CardPackId
            {
                get
                {
                    return this._cardPackId;
                }
                set
                {
                    this._cardPackId = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="closeActivatedTimes", DataFormat=DataFormat.TwosComplement)]
            public int CloseActivatedTimes
            {
                get
                {
                    return this._closeActivatedTimes;
                }
                set
                {
                    this._closeActivatedTimes = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="counterId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CounterId
            {
                get
                {
                    return this._counterId;
                }
                set
                {
                    this._counterId = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="effectiveProbability", DataFormat=DataFormat.TwosComplement), DefaultValue((double) 0.0)]
            public double EffectiveProbability
            {
                get
                {
                    return this._effectiveProbability;
                }
                set
                {
                    this._effectiveProbability = value;
                }
            }

            [DefaultValue(false), ProtoMember(6, IsRequired=false, Name="isShowCounter", DataFormat=DataFormat.Default)]
            public bool IsShowCounter
            {
                get
                {
                    return this._isShowCounter;
                }
                set
                {
                    this._isShowCounter = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="needRefreshTimes", DataFormat=DataFormat.TwosComplement)]
            public int NeedRefreshTimes
            {
                get
                {
                    return this._needRefreshTimes;
                }
                set
                {
                    this._needRefreshTimes = value;
                }
            }
        }

        [ProtoContract(Name="GoodsWeight")]
        public class GoodsWeight : IExtensible
        {
            private int _goodsId;
            private int _weight;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="goodsId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int GoodsId
            {
                get
                {
                    return this._goodsId;
                }
                set
                {
                    this._goodsId = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="weight", DataFormat=DataFormat.TwosComplement)]
            public int Weight
            {
                get
                {
                    return this._weight;
                }
                set
                {
                    this._weight = value;
                }
            }
        }

        [ProtoContract(Name="MysteryActivity")]
        public class MysteryActivity : IExtensible
        {
            private int _activityNum;
            private int _firstRefreshType;
            private bool _isDelItem;
            private int _itemId;
            private readonly List<MysteryerConfig.Refresh> _refreshs = new List<MysteryerConfig.Refresh>();
            private int _showCardId1;
            private int _showCardId2;
            private int _showCardId3;
            private readonly List<MysteryerConfig.TavernRewardInfo> _tavernRewardInfos = new List<MysteryerConfig.TavernRewardInfo>();
            private IExtension extensionObject;

            public MysteryerConfig.Refresh GetRefreshByTypes(int operateType, int refreshType)
            {
                foreach (MysteryerConfig.Refresh refresh in this._refreshs)
                {
                    if ((refresh.OperateType == operateType) && (refresh.RefreshType == refreshType))
                    {
                        return refresh;
                    }
                }
                return null;
            }

            public MysteryerConfig.TavernRewardInfo GetTavernRewardInfoByTavernId(int tavernId)
            {
                foreach (MysteryerConfig.TavernRewardInfo info in this._tavernRewardInfos)
                {
                    if (info.TavernId == tavernId)
                    {
                        return info;
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="activityNum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ActivityNum
            {
                get
                {
                    return this._activityNum;
                }
                set
                {
                    this._activityNum = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="firstRefreshType", DataFormat=DataFormat.TwosComplement)]
            public int FirstRefreshType
            {
                get
                {
                    return this._firstRefreshType;
                }
                set
                {
                    this._firstRefreshType = value;
                }
            }

            [DefaultValue(false), ProtoMember(4, IsRequired=false, Name="isDelItem", DataFormat=DataFormat.Default)]
            public bool IsDelItem
            {
                get
                {
                    return this._isDelItem;
                }
                set
                {
                    this._isDelItem = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="itemId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ItemId
            {
                get
                {
                    return this._itemId;
                }
                set
                {
                    this._itemId = value;
                }
            }

            [ProtoMember(2, Name="refreshs", DataFormat=DataFormat.Default)]
            public List<MysteryerConfig.Refresh> Refreshs
            {
                get
                {
                    return this._refreshs;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="showCardId1", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ShowCardId1
            {
                get
                {
                    return this._showCardId1;
                }
                set
                {
                    this._showCardId1 = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="showCardId2", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ShowCardId2
            {
                get
                {
                    return this._showCardId2;
                }
                set
                {
                    this._showCardId2 = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="showCardId3", DataFormat=DataFormat.TwosComplement)]
            public int ShowCardId3
            {
                get
                {
                    return this._showCardId3;
                }
                set
                {
                    this._showCardId3 = value;
                }
            }

            [ProtoMember(9, Name="tavernRewardInfos", DataFormat=DataFormat.Default)]
            public List<MysteryerConfig.TavernRewardInfo> TavernRewardInfos
            {
                get
                {
                    return this._tavernRewardInfos;
                }
            }
        }

        [ProtoContract(Name="QualityWeight")]
        public class QualityWeight : IExtensible
        {
            private int _quality;
            private int _weight;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="quality", DataFormat=DataFormat.TwosComplement)]
            public int Quality
            {
                get
                {
                    return this._quality;
                }
                set
                {
                    this._quality = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="weight", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Weight
            {
                get
                {
                    return this._weight;
                }
                set
                {
                    this._weight = value;
                }
            }
        }

        [ProtoContract(Name="QualityWeightInfo")]
        public class QualityWeightInfo : IExtensible
        {
            private int _place;
            private readonly List<MysteryerConfig.QualityWeight> _qualityWeights = new List<MysteryerConfig.QualityWeight>();
            private int _refreshType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="place", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Place
            {
                get
                {
                    return this._place;
                }
                set
                {
                    this._place = value;
                }
            }

            [ProtoMember(3, Name="qualityWeights", DataFormat=DataFormat.Default)]
            public List<MysteryerConfig.QualityWeight> QualityWeights
            {
                get
                {
                    return this._qualityWeights;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="refreshType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoContract(Name="Refresh")]
        public class Refresh : IExtensible
        {
            private ClientServerCommon.Cost _cost;
            private readonly List<MysteryerConfig.Counter> _counters = new List<MysteryerConfig.Counter>();
            private int _operateType;
            private int _refreshId;
            private string _refreshName = "";
            private int _refreshType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="cost", DataFormat=DataFormat.Default)]
            public ClientServerCommon.Cost Cost
            {
                get
                {
                    return this._cost;
                }
                set
                {
                    this._cost = value;
                }
            }

            [ProtoMember(6, Name="counters", DataFormat=DataFormat.Default)]
            public List<MysteryerConfig.Counter> Counters
            {
                get
                {
                    return this._counters;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="operateType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int OperateType
            {
                get
                {
                    return this._operateType;
                }
                set
                {
                    this._operateType = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="refreshId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int RefreshId
            {
                get
                {
                    return this._refreshId;
                }
                set
                {
                    this._refreshId = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="refreshName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string RefreshName
            {
                get
                {
                    return this._refreshName;
                }
                set
                {
                    this._refreshName = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="refreshType", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoContract(Name="RefreshInfo")]
        public class RefreshInfo : IExtensible
        {
            private int _index;
            private long _refreshTime;
            private int _refreshType;
            private IExtension extensionObject;

            public DateTime GetRefreshDateTime()
            {
                return new DateTime(this._refreshTime * 0x2710L);
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement)]
            public int Index
            {
                get
                {
                    return this._index;
                }
                set
                {
                    this._index = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="refreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
            public long RefreshTime
            {
                get
                {
                    return this._refreshTime;
                }
                set
                {
                    this._refreshTime = value;
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

        [ProtoContract(Name="TavernRewardInfo")]
        public class TavernRewardInfo : IExtensible
        {
            private ClientServerCommon.Reward _reward;
            private int _tavernId;
            private ClientServerCommon.Reward _tenTavernReward;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="reward", DataFormat=DataFormat.Default)]
            public ClientServerCommon.Reward Reward
            {
                get
                {
                    return this._reward;
                }
                set
                {
                    this._reward = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="tavernId", DataFormat=DataFormat.TwosComplement)]
            public int TavernId
            {
                get
                {
                    return this._tavernId;
                }
                set
                {
                    this._tavernId = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="tenTavernReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public ClientServerCommon.Reward TenTavernReward
            {
                get
                {
                    return this._tenTavernReward;
                }
                set
                {
                    this._tenTavernReward = value;
                }
            }
        }

        [ProtoContract(Name="WeightIncrease")]
        public class WeightIncrease : IExtensible
        {
            private double _increase;
            private int _level;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((double) 0.0), ProtoMember(2, IsRequired=false, Name="increase", DataFormat=DataFormat.TwosComplement)]
            public double Increase
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

