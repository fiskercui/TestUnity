namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="GuildPublicShopConfig")]
    public class GuildPublicShopConfig : Configuration, IExtensible
    {
        private readonly List<GuildPublicGoods> _goods = new List<GuildPublicGoods>();
        private long _refreshTime;
        private IExtension extensionObject;
        private Dictionary<int, GuildPublicGoods> goodsMap = new Dictionary<int, GuildPublicGoods>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (GuildPublicGoods goods in this._goods)
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

        public GuildPublicGoods GetGoodsById(int id)
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
        }

        private CountLevel LoadCountLevel(SecurityElement element)
        {
            return new CountLevel { 
                GuildLevel = StrParser.ParseDecInt(element.Attribute("GuildLevel"), 0),
                Count = StrParser.ParseDecInt(element.Attribute("Count"), 0)
            };
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "GuildPublicShopConfig")
            {
                this._refreshTime = StrParser.ParseDateTime(element.Attribute("RefreshTime"));
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string str;
                        if (((str = element2.Tag) != null) && (str == "Goods"))
                        {
                            this._goods.Add(this.LoadGuildPublicGoodsFromXml(element2));
                        }
                    }
                }
            }
        }

        private GuildPublicGoods LoadGuildPublicGoodsFromXml(SecurityElement element)
        {
            GuildPublicGoods goods = new GuildPublicGoods {
                GoodsId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                GoodsName = StrParser.ParseStr(element.Attribute("Name"), ""),
                GoodsIconId = StrParser.ParseHexInt(element.Attribute("IconId"), 0),
                ShowIndex = StrParser.ParseDecInt(element.Attribute("ShowIndex"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "GoodsCount")
                        {
                            if (tag == "Cost")
                            {
                                goto Label_00D2;
                            }
                            if (tag == "Reward")
                            {
                                goto Label_00E5;
                            }
                        }
                        else
                        {
                            goods.CountLevels.Add(this.LoadCountLevel(element2));
                        }
                    }
                    continue;
                Label_00D2:
                    goods.Costs.Add(Cost.LoadFromXml(element2));
                    continue;
                Label_00E5:
                    goods.Rewards.Add(Reward.LoadFromXml(element2));
                }
            }
            return goods;
        }

        [ProtoMember(2, Name="goods", DataFormat=DataFormat.Default)]
        public List<GuildPublicGoods> Goods
        {
            get
            {
                return this._goods;
            }
        }

        public DateTime RefreshDateTime
        {
            get
            {
                return new DateTime(this._refreshTime * 0x2710L);
            }
        }

        [DefaultValue((long) 0L), ProtoMember(1, IsRequired=false, Name="refreshTime", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoContract(Name="CountLevel")]
        public class CountLevel : IExtensible
        {
            private int _count;
            private int _guildLevel;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
            public int Count
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

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="guildLevel", DataFormat=DataFormat.TwosComplement)]
            public int GuildLevel
            {
                get
                {
                    return this._guildLevel;
                }
                set
                {
                    this._guildLevel = value;
                }
            }
        }

        [ProtoContract(Name="GuildPublicGoods")]
        public class GuildPublicGoods : IExtensible
        {
            private readonly List<Cost> _costs = new List<Cost>();
            private readonly List<GuildPublicShopConfig.CountLevel> _countLevels = new List<GuildPublicShopConfig.CountLevel>();
            private int _goodsIconId;
            private int _goodsId;
            private string _goodsName = "";
            private readonly List<Reward> _rewards = new List<Reward>();
            private int _showIndex;
            private IExtension extensionObject;

            public int GetLimitCountByGuildLevel(int guildLevel)
            {
                foreach (GuildPublicShopConfig.CountLevel level in this._countLevels)
                {
                    if (level.GuildLevel == guildLevel)
                    {
                        return level.Count;
                    }
                }
                return 0;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> Costs
            {
                get
                {
                    return this._costs;
                }
            }

            [ProtoMember(5, Name="countLevels", DataFormat=DataFormat.Default)]
            public List<GuildPublicShopConfig.CountLevel> CountLevels
            {
                get
                {
                    return this._countLevels;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="goodsIconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(4, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> Rewards
            {
                get
                {
                    return this._rewards;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="showIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

