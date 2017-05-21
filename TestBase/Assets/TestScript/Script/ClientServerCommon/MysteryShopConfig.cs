namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="MysteryShopConfig")]
    public class MysteryShopConfig : Configuration, IExtensible
    {
        private readonly List<Shop> _shopSet = new List<Shop>();
        private IExtension extensionObject;
        private Dictionary<int, Shop> shopMap = new Dictionary<int, Shop>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Shop shop in this._shopSet)
            {
                if (shop != null)
                {
                    if (this.shopMap.ContainsKey(shop.shopType))
                    {
                        Logger.Error(base.GetType().Name + " ContainsShopType 0x" + shop.shopType.ToString(), new object[0]);
                    }
                    else
                    {
                        this.shopMap.Add(shop.shopType, shop);
                        foreach (Refresh refresh in shop.refreshSet)
                        {
                            if (refresh != null)
                            {
                                if (shop.GetRefreshMap().ContainsKey(refresh.refreshId))
                                {
                                    Logger.Error(base.GetType().Name + " ContainsKey RefreshId 0x" + refresh.refreshId.ToString("X"), new object[0]);
                                }
                                else
                                {
                                    shop.GetRefreshMap().Add(refresh.refreshId, refresh);
                                    foreach (Counter counter in refresh.counters)
                                    {
                                        if (counter != null)
                                        {
                                            if (shop.GetCounterMap().ContainsKey(counter.counterId))
                                            {
                                                Logger.Error(base.GetType().Name + " ContainsKey CounterId 0x" + counter.counterId.ToString("X"), new object[0]);
                                            }
                                            else
                                            {
                                                shop.GetCounterMap().Add(counter.counterId, counter);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        foreach (Goods goods in shop.goodsSet)
                        {
                            if (goods != null)
                            {
                                if (shop.GetGoodsMap().ContainsKey(goods.goodsId))
                                {
                                    Logger.Error(base.GetType().Name + " ContainsKey GoodsId 0x" + goods.goodsId.ToString("X"), new object[0]);
                                }
                                else
                                {
                                    shop.GetGoodsMap().Add(goods.goodsId, goods);
                                }
                            }
                        }
                        foreach (CardPack pack in shop.cardPackSet)
                        {
                            if (pack != null)
                            {
                                if (shop.GetCardPackMap().ContainsKey(pack.cardPackId))
                                {
                                    Logger.Error(base.GetType().Name + " ContainsKey CardPackId 0x" + pack.cardPackId.ToString("X"), new object[0]);
                                }
                                else
                                {
                                    shop.GetCardPackMap().Add(pack.cardPackId, pack);
                                }
                            }
                        }
                    }
                }
            }
        }

        public Shop GetShopByType(int type)
        {
            if (this.shopMap.ContainsKey(type))
            {
                return this.shopMap[type];
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _ShopType.Initialize();
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
                            cardPackId = StrParser.ParseHexInt(element2.Attribute("CardPackId"), 0)
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
            if ((element.Tag == "MysteryShopConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "ShopSet"))
                    {
                        Shop item = this.LoadShopFromXml(element2);
                        if (item != null)
                        {
                            this._shopSet.Add(item);
                        }
                    }
                }
            }
        }

        private Goods loadGoodsFromXml(SecurityElement element)
        {
            Goods goods = new Goods {
                goodsId = StrParser.ParseHexInt(element.Attribute("GoodsId"), 0)
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
                                goto Label_0083;
                            }
                            if (tag == "Reward")
                            {
                                goto Label_0091;
                            }
                        }
                        else
                        {
                            goods.cost = Cost.LoadFromXml(element2);
                        }
                    }
                    continue;
                Label_0083:
                    goods.discountCost = Cost.LoadFromXml(element2);
                    continue;
                Label_0091:
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
                            goodsId = StrParser.ParseHexInt(element2.Attribute("GoodsId"), 0),
                            weight = StrParser.ParseDecInt(element2.Attribute("Weight"), 0)
                        };
                        cp.goodsWeights.Add(item);
                    }
                }
            }
        }

        private Refresh loadRefreshFromXml(SecurityElement element)
        {
            Refresh refresh = new Refresh {
                refreshId = StrParser.ParseHexInt(element.Attribute("RefreshId"), 0),
                refreshName = StrParser.ParseStr(element.Attribute("RefreshName"), ""),
                iconId = StrParser.ParseHexInt(element.Attribute("IconId"), 0),
                backgroundIconId = StrParser.ParseHexInt(element.Attribute("BackgroundIconId"), 0),
                vipLevel = StrParser.ParseDecInt(element.Attribute("VipLevel"), 0),
                priority = StrParser.ParseDecInt(element.Attribute("Priority"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    Counter counter;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "Cost")
                        {
                            if (tag == "CardPack")
                            {
                                goto Label_010A;
                            }
                            if (tag == "Counter")
                            {
                                goto Label_0128;
                            }
                        }
                        else
                        {
                            refresh.cost = Cost.LoadFromXml(element2);
                        }
                    }
                    continue;
                Label_010A:
                    refresh.cardPackIDs.Add(StrParser.ParseHexInt(element2.Attribute("CardPackId"), 0));
                    continue;
                Label_0128:
                    counter = new Counter();
                    counter.counterId = StrParser.ParseHexInt(element2.Attribute("CounterId"), 0);
                    counter.activateNeedRefreshTime = StrParser.ParseDecInt(element2.Attribute("ActivateNeedRefreshTime"), 0);
                    counter.closeNeedActivateTime = StrParser.ParseDecInt(element2.Attribute("CloseNeedActivateTime"), 0);
                    counter.cardPackId = StrParser.ParseHexInt(element2.Attribute("CardPackId"), 0);
                    refresh.counters.Add(counter);
                }
            }
            return refresh;
        }

        private List<Refresh> LoadRefreshSetFromXml(SecurityElement element)
        {
            List<Refresh> list = new List<Refresh>();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Refresh"))
                    {
                        list.Add(this.loadRefreshFromXml(element2));
                    }
                }
            }
            return list;
        }

        private void LoadRefreshTimeFromXml(SecurityElement element, Shop shop)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Time"))
                    {
                        shop.refreshTime.Add(StrParser.ParseDateTime(element2.Attribute("Start")));
                    }
                }
            }
        }

        private Shop LoadShopFromXml(SecurityElement element)
        {
            if (element == null)
            {
                return null;
            }
            Shop shop = new Shop {
                shopType = TypeNameContainer<_ShopType>.Parse(element.Attribute("ShopType"), 1)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    switch (element2.Tag)
                    {
                        case "RefreshTime":
                            this.LoadRefreshTimeFromXml(element2, shop);
                            break;

                        case "OpenLevel":
                            shop.openLevel = StrParser.ParseDecInt(element2.Attribute("Level"), 0);
                            break;

                        case "DefaultRefreshId":
                            shop.defaultRefreshId = StrParser.ParseHexInt(element2.Attribute("RefreshId"), 0);
                            break;

                        case "ResetTime":
                            shop.resetTime = StrParser.ParseDateTime(element2.Attribute("Time"));
                            break;

                        case "RefreshSet":
                            shop.refreshSet.AddRange(this.LoadRefreshSetFromXml(element2));
                            break;

                        case "CardPackSet":
                            shop.cardPackSet.AddRange(this.loadCardPackSetFromXml(element2));
                            break;

                        case "GoodsSet":
                            shop.goodsSet.AddRange(this.loadGoodsSetFromXml(element2));
                            break;
                    }
                }
            }
            return shop;
        }

        [ProtoMember(1, Name="shopSet", DataFormat=DataFormat.Default)]
        public List<Shop> shopSet
        {
            get
            {
                return this._shopSet;
            }
        }

        public class _ShopType : TypeNameContainer<MysteryShopConfig._ShopType>
        {
            public const int MelaleucaFloor = 2;
            public const int Normal = 1;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<MysteryShopConfig._ShopType>.RegisterType("Normal", 1);
                return (flag & TypeNameContainer<MysteryShopConfig._ShopType>.RegisterType("MelaleucaFloor", 2));
            }

            public static bool isValidType(int type)
            {
                string nameByType = TypeNameContainer<MysteryShopConfig._ShopType>.GetNameByType(type);
                return ((nameByType != null) && (nameByType.Trim() != ""));
            }
        }

        [ProtoContract(Name="CardPack")]
        public class CardPack : IExtensible
        {
            private int _cardPackId;
            private readonly List<MysteryShopConfig.GoodsWeight> _goodsWeights = new List<MysteryShopConfig.GoodsWeight>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="cardPackId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int cardPackId
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
            public List<MysteryShopConfig.GoodsWeight> goodsWeights
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
            private int _activateNeedRefreshTime;
            private int _cardPackId;
            private int _closeNeedActivateTime;
            private int _counterId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="activateNeedRefreshTime", DataFormat=DataFormat.TwosComplement)]
            public int activateNeedRefreshTime
            {
                get
                {
                    return this._activateNeedRefreshTime;
                }
                set
                {
                    this._activateNeedRefreshTime = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="cardPackId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int cardPackId
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

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="closeNeedActivateTime", DataFormat=DataFormat.TwosComplement)]
            public int closeNeedActivateTime
            {
                get
                {
                    return this._closeNeedActivateTime;
                }
                set
                {
                    this._closeNeedActivateTime = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="counterId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int counterId
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

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="goodsId", DataFormat=DataFormat.TwosComplement)]
            public int goodsId
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
            public int weight
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

        [ProtoContract(Name="Refresh")]
        public class Refresh : IExtensible
        {
            private int _backgroundIconId;
            private readonly List<int> _cardPackIDs = new List<int>();
            private Cost _cost;
            private readonly List<MysteryShopConfig.Counter> _counters = new List<MysteryShopConfig.Counter>();
            private int _iconId;
            private int _priority;
            private int _refreshId;
            private string _refreshName = "";
            private int _vipLevel;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, IsRequired=false, Name="backgroundIconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int backgroundIconId
            {
                get
                {
                    return this._backgroundIconId;
                }
                set
                {
                    this._backgroundIconId = value;
                }
            }

            [ProtoMember(8, Name="cardPackIDs", DataFormat=DataFormat.TwosComplement)]
            public List<int> cardPackIDs
            {
                get
                {
                    return this._cardPackIDs;
                }
            }

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="cost", DataFormat=DataFormat.Default)]
            public Cost cost
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

            [ProtoMember(9, Name="counters", DataFormat=DataFormat.Default)]
            public List<MysteryShopConfig.Counter> counters
            {
                get
                {
                    return this._counters;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(2, IsRequired=false, Name="priority", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int priority
            {
                get
                {
                    return this._priority;
                }
                set
                {
                    this._priority = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="refreshId", DataFormat=DataFormat.TwosComplement)]
            public int refreshId
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

            [ProtoMember(3, IsRequired=false, Name="refreshName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string refreshName
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

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement)]
            public int vipLevel
            {
                get
                {
                    return this._vipLevel;
                }
                set
                {
                    this._vipLevel = value;
                }
            }
        }

        [ProtoContract(Name="Shop")]
        public class Shop : IExtensible
        {
            private readonly List<MysteryShopConfig.CardPack> _cardPackSet = new List<MysteryShopConfig.CardPack>();
            private int _defaultRefreshId;
            private readonly List<Goods> _goodsSet = new List<Goods>();
            private int _openLevel;
            private readonly List<MysteryShopConfig.Refresh> _refreshSet = new List<MysteryShopConfig.Refresh>();
            private readonly List<long> _refreshTime = new List<long>();
            private long _resetTime;
            private int _shopType;
            private Dictionary<int, MysteryShopConfig.CardPack> cardPackMap = new Dictionary<int, MysteryShopConfig.CardPack>();
            private Dictionary<int, MysteryShopConfig.Counter> counterMap = new Dictionary<int, MysteryShopConfig.Counter>();
            private IExtension extensionObject;
            private Dictionary<int, Goods> goodsMap = new Dictionary<int, Goods>();
            private Dictionary<int, MysteryShopConfig.Refresh> refreshMap = new Dictionary<int, MysteryShopConfig.Refresh>();

            public MysteryShopConfig.CardPack GetCardPackById(int id)
            {
                if (this.cardPackMap.ContainsKey(id))
                {
                    return this.cardPackMap[id];
                }
                return null;
            }

            public Dictionary<int, MysteryShopConfig.CardPack> GetCardPackMap()
            {
                return this.cardPackMap;
            }

            public MysteryShopConfig.Counter GetCounterById(int id)
            {
                if (this.counterMap.ContainsKey(id))
                {
                    return this.counterMap[id];
                }
                return null;
            }

            public Dictionary<int, MysteryShopConfig.Counter> GetCounterMap()
            {
                return this.counterMap;
            }

            public Goods GetGoodsById(int id)
            {
                if (this.goodsMap.ContainsKey(id))
                {
                    return this.goodsMap[id];
                }
                return null;
            }

            public Dictionary<int, Goods> GetGoodsMap()
            {
                return this.goodsMap;
            }

            public MysteryShopConfig.Refresh GetRefreshById(int id)
            {
                if (this.refreshMap.ContainsKey(id))
                {
                    return this.refreshMap[id];
                }
                return null;
            }

            public Dictionary<int, MysteryShopConfig.Refresh> GetRefreshMap()
            {
                return this.refreshMap;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            public DateTime ToDateTime(long time)
            {
                return new DateTime(time * 0x2710L);
            }

            [ProtoMember(8, Name="cardPackSet", DataFormat=DataFormat.Default)]
            public List<MysteryShopConfig.CardPack> cardPackSet
            {
                get
                {
                    return this._cardPackSet;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="defaultRefreshId", DataFormat=DataFormat.TwosComplement)]
            public int defaultRefreshId
            {
                get
                {
                    return this._defaultRefreshId;
                }
                set
                {
                    this._defaultRefreshId = value;
                }
            }

            [ProtoMember(7, Name="goodsSet", DataFormat=DataFormat.Default)]
            public List<Goods> goodsSet
            {
                get
                {
                    return this._goodsSet;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="openLevel", DataFormat=DataFormat.TwosComplement)]
            public int openLevel
            {
                get
                {
                    return this._openLevel;
                }
                set
                {
                    this._openLevel = value;
                }
            }

            [ProtoMember(6, Name="refreshSet", DataFormat=DataFormat.Default)]
            public List<MysteryShopConfig.Refresh> refreshSet
            {
                get
                {
                    return this._refreshSet;
                }
            }

            [ProtoMember(2, Name="refreshTime", DataFormat=DataFormat.TwosComplement)]
            public List<long> refreshTime
            {
                get
                {
                    return this._refreshTime;
                }
            }

            public DateTime ResetDateTime
            {
                get
                {
                    return new DateTime(this.resetTime * 0x2710L);
                }
            }

            [DefaultValue((long) 0L), ProtoMember(5, IsRequired=false, Name="resetTime", DataFormat=DataFormat.TwosComplement)]
            public long resetTime
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

            [ProtoMember(1, IsRequired=false, Name="shopType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int shopType
            {
                get
                {
                    return this._shopType;
                }
                set
                {
                    this._shopType = value;
                }
            }
        }
    }
}

