namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="GuildExchangeShopConfig")]
    public class GuildExchangeShopConfig : Configuration, IExtensible
    {
        private readonly List<GuildActivity> _activities = new List<GuildActivity>();
        private int _activityId;
        private IExtension extensionObject;

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (GuildActivity activity in this._activities)
            {
                if (activity != null)
                {
                    activity.init();
                }
            }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _ActiveConditionType.Initialize();
        }

        private GuildExchangeGoods LoadExchangGoodsFromXml(SecurityElement element)
        {
            GuildExchangeGoods goods = new GuildExchangeGoods {
                GoodsId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                ShowIndex = StrParser.ParseDecInt(element.Attribute("ShowIndex"), 0),
                ActiveConditionType = TypeNameContainer<_ActiveConditionType>.Parse(element.Attribute("ActiveConditionType"), 0),
                ActiveConditionValue = StrParser.ParseStr(element.Attribute("ActiveConditionValue"), ""),
                ExistTimeMs = StrParser.ParseDecInt(element.Attribute("ExistTimeMs"), 0),
                BuyCountLimitPerActive = StrParser.ParseDecInt(element.Attribute("BuyCountLimitPerActive"), 0),
                ConditionDesc = StrParser.ParseStr(element.Attribute("ConditionDesc"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "CostAsset")
                        {
                            if (tag == "ItemEx")
                            {
                                goto Label_011A;
                            }
                            if (tag == "Reward")
                            {
                                goto Label_012D;
                            }
                        }
                        else
                        {
                            goods.CostAssets.Add(CostAsset.LoadCostAssetFromXml(element2));
                        }
                    }
                    continue;
                Label_011A:
                    goods.Costs.Add(ItemEx.LoadItemExFromXml(element2));
                    continue;
                Label_012D:
                    goods.Reward = Reward.LoadFromXml(element2);
                }
            }
            return goods;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "GuildExchangeShopConfig")
            {
                this._activityId = StrParser.ParseHexInt(element.Attribute("ActivityId"), 0);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        this._activities.Add(this.LoadGuildActivityFromXml(element2));
                    }
                }
            }
        }

        private GuildActivity LoadGuildActivityFromXml(SecurityElement element)
        {
            if (element.Tag != "GuildActivity")
            {
                return null;
            }
            GuildActivity activity = new GuildActivity {
                ActivityNum = StrParser.ParseDecInt(element.Attribute("ActivityNum"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Goods"))
                    {
                        activity.Goods.Add(this.LoadExchangGoodsFromXml(element2));
                    }
                }
            }
            return activity;
        }

        [ProtoMember(1, Name="activities", DataFormat=DataFormat.Default)]
        public List<GuildActivity> Activities
        {
            get
            {
                return this._activities;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="activityId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        public class _ActiveConditionType : TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>
        {
            public const int GuildKillChallengeBossCount = 11;
            public const int GuildKillPassBossCount = 10;
            public const int GuildKillSpeficChallengeBoss = 13;
            public const int GuildKillSpeficPassBoss = 12;
            public const int GuildStageArrivalLayer = 7;
            public const int LastWeekStageProgressTotalPoint = 1;
            public const int PlayerChallengeCount = 9;
            public const int PlayerCostMoveCount = 8;
            public const int ThisWeekGuildKillChallengeBossCount = 3;
            public const int ThisWeekGuildKillPassBossCount = 2;
            public const int ThisWeekPlayerChallengeCount = 6;
            public const int ThisWeekPlayerCostMoveCount = 4;
            public const int ThisWeekPlayerInSpeedRrank = 5;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("LastWeekStageProgressTotalPoint", 1);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("ThisWeekGuildKillPassBossCount", 2);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("ThisWeekGuildKillChallengeBossCount", 3);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("ThisWeekPlayerCostMoveCount", 4);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("ThisWeekPlayerInSpeedRrank", 5);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("ThisWeekPlayerChallengeCount", 6);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("GuildStageArrivalLayer", 7);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("PlayerCostMoveCount", 8);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("PlayerChallengeCount", 9);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("GuildKillPassBossCount", 10);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("GuildKillChallengeBossCount", 11);
                flag &= TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("GuildKillSpeficPassBoss", 12);
                return (flag & TypeNameContainer<GuildExchangeShopConfig._ActiveConditionType>.RegisterType("GuildKillSpeficChallengeBoss", 13));
            }
        }

        [ProtoContract(Name="GuildActivity")]
        public class GuildActivity : IExtensible
        {
            private int _activityNum;
            private readonly List<GuildExchangeShopConfig.GuildExchangeGoods> _goods = new List<GuildExchangeShopConfig.GuildExchangeGoods>();
            private IExtension extensionObject;
            private Dictionary<int, GuildExchangeShopConfig.GuildExchangeGoods> goodsMap = new Dictionary<int, GuildExchangeShopConfig.GuildExchangeGoods>();

            public GuildExchangeShopConfig.GuildExchangeGoods GetGoodsById(int id)
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

            public void init()
            {
                foreach (GuildExchangeShopConfig.GuildExchangeGoods goods in this._goods)
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

            [ProtoMember(2, Name="goods", DataFormat=DataFormat.Default)]
            public List<GuildExchangeShopConfig.GuildExchangeGoods> Goods
            {
                get
                {
                    return this._goods;
                }
            }
        }

        [ProtoContract(Name="GuildExchangeGoods")]
        public class GuildExchangeGoods : IExtensible
        {
            private int _activeConditionType;
            private string _activeConditionValue = "";
            private int _buyCountLimitPerActive;
            private string _conditionDesc = "";
            private readonly List<CostAsset> _costAssets = new List<CostAsset>();
            private readonly List<ItemEx> _costs = new List<ItemEx>();
            private int _existTimeMs;
            private int _goodsId;
            private ClientServerCommon.Reward _reward;
            private int _showIndex;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="activeConditionType", DataFormat=DataFormat.TwosComplement)]
            public int ActiveConditionType
            {
                get
                {
                    return this._activeConditionType;
                }
                set
                {
                    this._activeConditionType = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="activeConditionValue", DataFormat=DataFormat.Default), DefaultValue("")]
            public string ActiveConditionValue
            {
                get
                {
                    return this._activeConditionValue;
                }
                set
                {
                    this._activeConditionValue = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="buyCountLimitPerActive", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int BuyCountLimitPerActive
            {
                get
                {
                    return this._buyCountLimitPerActive;
                }
                set
                {
                    this._buyCountLimitPerActive = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="conditionDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string ConditionDesc
            {
                get
                {
                    return this._conditionDesc;
                }
                set
                {
                    this._conditionDesc = value;
                }
            }

            [ProtoMember(7, Name="costAssets", DataFormat=DataFormat.Default)]
            public List<CostAsset> CostAssets
            {
                get
                {
                    return this._costAssets;
                }
            }

            [ProtoMember(8, Name="costs", DataFormat=DataFormat.Default)]
            public List<ItemEx> Costs
            {
                get
                {
                    return this._costs;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="existTimeMs", DataFormat=DataFormat.TwosComplement)]
            public int ExistTimeMs
            {
                get
                {
                    return this._existTimeMs;
                }
                set
                {
                    this._existTimeMs = value;
                }
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

            [ProtoMember(9, IsRequired=false, Name="reward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [ProtoMember(2, IsRequired=false, Name="showIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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
    }
}

