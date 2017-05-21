namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="GuildPrivateShopConfig")]
    public class GuildPrivateShopConfig : Configuration, IExtensible
    {
        private readonly List<GuildPrivateGoods> _goods = new List<GuildPrivateGoods>();
        private IExtension extensionObject;
        private Dictionary<int, GuildPrivateGoods> goodsMap = new Dictionary<int, GuildPrivateGoods>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (GuildPrivateGoods goods in this._goods)
            {
                if (goods != null)
                {
                    if (this.goodsMap.ContainsKey(goods.GoodsId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey " + goods.GoodsId.ToString(), new object[0]);
                    }
                    else
                    {
                        this.goodsMap.Add(goods.GoodsId, goods);
                    }
                }
            }
        }

        public GuildPrivateGoods GetGoodsById(int id)
        {
            if (this.goodsMap.ContainsKey(id))
            {
                return this.goodsMap[id];
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _LimitType.Initialize();
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "GuildPrivateShopConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    this._goods.Add(this.LoadGuildPrivateGoodsFromXml(element2));
                }
            }
        }

        private GuildPrivateGoods LoadGuildPrivateGoodsFromXml(SecurityElement element)
        {
            GuildPrivateGoods goods = new GuildPrivateGoods {
                GoodsId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                GoodsName = StrParser.ParseStr(element.Attribute("Name"), ""),
                GoodsIconId = StrParser.ParseHexInt(element.Attribute("IconId"), 0),
                GoodsDesc = StrParser.ParseStr(element.Attribute("Desc"), ""),
                OpenTime = StrParser.ParseDateTime(element.Attribute("StartTime")),
                CloseTime = StrParser.ParseDateTime(element.Attribute("EndTime")),
                ResetType = TypeNameContainer<_TimeDurationType>.Parse(element.Attribute("ResetType"), 0),
                BuyLimitCountPerCircle = StrParser.ParseDecInt(element.Attribute("BuyLimitCountPerCircle"), 0),
                BatchPurchase = StrParser.ParseBool(element.Attribute("BatchPurchase"), false),
                ShowIndex = StrParser.ParseDecInt(element.Attribute("ShowIndex"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "CostInfo")
                        {
                            CostInfo item = new CostInfo {
                                BuyCount = StrParser.ParseDecInt(element2.Attribute("BuyCount"), 0)
                            };
                            if (element2.Children != null)
                            {
                                foreach (SecurityElement element3 in element2.Children)
                                {
                                    if (element3.Tag == "Cost")
                                    {
                                        item.Costs.Add(Cost.LoadFromXml(element3));
                                    }
                                }
                            }
                            goods.Costinfos.Add(item);
                        }
                        else if (tag == "Reward")
                        {
                            goods.Rewards.Add(Reward.LoadFromXml(element2));
                        }
                        else if (tag == "Limit")
                        {
                            LimitInfo info2 = new LimitInfo {
                                LimitType = TypeNameContainer<_LimitType>.Parse(element2.Attribute("Type"), 0),
                                LimitValue = StrParser.ParseDecInt(element2.Attribute("Value"), 0)
                            };
                            goods.LimitInfos.Add(info2);
                        }
                    }
                }
            }
            return goods;
        }

        [ProtoMember(1, Name="goods", DataFormat=DataFormat.Default)]
        public List<GuildPrivateGoods> Goods
        {
            get
            {
                return this._goods;
            }
        }

        public class _LimitType : TypeNameContainer<GuildPrivateShopConfig._LimitType>
        {
            public const int DayContribution = 3;
            public const int GuildLevel = 1;
            public const int KillBoss = 5;
            public const int PlayerLevel = 2;
            public const int TotalContribution = 4;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildPrivateShopConfig._LimitType>.RegisterType("GuildLevel", 1, "GuildLevel");
                flag &= TypeNameContainer<GuildPrivateShopConfig._LimitType>.RegisterType("PlayerLevel", 2, "PlayerLevel");
                flag &= TypeNameContainer<GuildPrivateShopConfig._LimitType>.RegisterType("DayContribution", 3, "DayContribution");
                flag &= TypeNameContainer<GuildPrivateShopConfig._LimitType>.RegisterType("TotalContribution", 4, "TotalContribution");
                return (flag & TypeNameContainer<GuildPrivateShopConfig._LimitType>.RegisterType("KillBoss", 5, "KillBoss"));
            }
        }

        [ProtoContract(Name="CostInfo")]
        public class CostInfo : IExtensible
        {
            private int _buyCount;
            private readonly List<Cost> _costs = new List<Cost>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="buyCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int BuyCount
            {
                get
                {
                    return this._buyCount;
                }
                set
                {
                    this._buyCount = value;
                }
            }

            [ProtoMember(2, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> Costs
            {
                get
                {
                    return this._costs;
                }
            }
        }

        [ProtoContract(Name="GuildPrivateGoods")]
        public class GuildPrivateGoods : IExtensible
        {
            private bool _batchPurchase;
            private int _buyLimitCountPerCircle;
            private long _closeTime;
            private readonly List<GuildPrivateShopConfig.CostInfo> _costinfos = new List<GuildPrivateShopConfig.CostInfo>();
            private string _goodsDesc = "";
            private int _goodsIconId;
            private int _goodsId;
            private string _goodsName = "";
            private readonly List<GuildPrivateShopConfig.LimitInfo> _limitInfos = new List<GuildPrivateShopConfig.LimitInfo>();
            private long _openTime;
            private int _resetType;
            private readonly List<Reward> _rewards = new List<Reward>();
            private int _showIndex;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(12, IsRequired=false, Name="batchPurchase", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool BatchPurchase
            {
                get
                {
                    return this._batchPurchase;
                }
                set
                {
                    this._batchPurchase = value;
                }
            }

            [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="buyLimitCountPerCircle", DataFormat=DataFormat.TwosComplement)]
            public int BuyLimitCountPerCircle
            {
                get
                {
                    return this._buyLimitCountPerCircle;
                }
                set
                {
                    this._buyLimitCountPerCircle = value;
                }
            }

            public DateTime CloseDateTime
            {
                get
                {
                    return new DateTime(this._closeTime * 0x2710L);
                }
            }

            [ProtoMember(7, IsRequired=false, Name="closeTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
            public long CloseTime
            {
                get
                {
                    return this._closeTime;
                }
                set
                {
                    this._closeTime = value;
                }
            }

            [ProtoMember(10, Name="costinfos", DataFormat=DataFormat.Default)]
            public List<GuildPrivateShopConfig.CostInfo> Costinfos
            {
                get
                {
                    return this._costinfos;
                }
            }

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="goodsDesc", DataFormat=DataFormat.Default)]
            public string GoodsDesc
            {
                get
                {
                    return this._goodsDesc;
                }
                set
                {
                    this._goodsDesc = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="goodsIconId", DataFormat=DataFormat.TwosComplement)]
            public int GoodsIconId
            {
                get
                {
                    return this._goodsIconId;
                }
                set
                {
                    this._goodsIconId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="goodsId", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="goodsName", DataFormat=DataFormat.Default)]
            public string GoodsName
            {
                get
                {
                    return this._goodsName;
                }
                set
                {
                    this._goodsName = value;
                }
            }

            [ProtoMember(5, Name="limitInfos", DataFormat=DataFormat.Default)]
            public List<GuildPrivateShopConfig.LimitInfo> LimitInfos
            {
                get
                {
                    return this._limitInfos;
                }
            }

            public DateTime OpenDateTime
            {
                get
                {
                    return new DateTime(this._openTime * 0x2710L);
                }
            }

            [DefaultValue((long) 0L), ProtoMember(6, IsRequired=false, Name="openTime", DataFormat=DataFormat.TwosComplement)]
            public long OpenTime
            {
                get
                {
                    return this._openTime;
                }
                set
                {
                    this._openTime = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="resetType", DataFormat=DataFormat.TwosComplement)]
            public int ResetType
            {
                get
                {
                    return this._resetType;
                }
                set
                {
                    this._resetType = value;
                }
            }

            [ProtoMember(11, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> Rewards
            {
                get
                {
                    return this._rewards;
                }
            }

            [ProtoMember(13, IsRequired=false, Name="showIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ShowIndex
            {
                get
                {
                    return this._showIndex;
                }
                set
                {
                    this._showIndex = value;
                }
            }
        }

        [ProtoContract(Name="LimitInfo")]
        public class LimitInfo : IExtensible
        {
            private int _limitType;
            private int _limitValue;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="limitType", DataFormat=DataFormat.TwosComplement)]
            public int LimitType
            {
                get
                {
                    return this._limitType;
                }
                set
                {
                    this._limitType = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="limitValue", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int LimitValue
            {
                get
                {
                    return this._limitValue;
                }
                set
                {
                    this._limitValue = value;
                }
            }
        }
    }
}

