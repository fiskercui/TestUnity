namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="GoodConfig")]
    public class GoodConfig : Configuration, IExtensible
    {
        private readonly List<AssetGood> _assetGoods = new List<AssetGood>();
        private readonly List<Good> _goods = new List<Good>();
        private Dictionary<int, int> assetGoodMap = new Dictionary<int, int>();
        private IExtension extensionObject;
        private Dictionary<int, List<Good>> groupId_goodMap = new Dictionary<int, List<Good>>();
        private Dictionary<int, Good> id_goodMap = new Dictionary<int, Good>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Good good in this._goods)
            {
                if (good != null)
                {
                    if (this.id_goodMap.ContainsKey(good.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + good.id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_goodMap.Add(good.id, good);
                        if (good.groupId != 0)
                        {
                            List<Good> list = null;
                            if (!this.groupId_goodMap.TryGetValue(good.groupId, out list))
                            {
                                list = new List<Good> {
                                    good
                                };
                                this.groupId_goodMap.Add(good.groupId, list);
                            }
                            else
                            {
                                list.Add(good);
                            }
                        }
                    }
                }
            }
            foreach (AssetGood good2 in this._assetGoods)
            {
                if (good2 != null)
                {
                    if (this.assetGoodMap.ContainsKey(good2.assetId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + good2.assetId.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.assetGoodMap.Add(good2.assetId, good2.goodId);
                    }
                }
            }
        }

        public Good GetGoodById(int id)
        {
            Good good = null;
            if (!this.id_goodMap.TryGetValue(id, out good))
            {
                return null;
            }
            return good;
        }

        public int GetGoodIdByAssetId(int assetId)
        {
            if (this.assetGoodMap.ContainsKey(assetId))
            {
                return this.assetGoodMap[assetId];
            }
            return 0;
        }

        public Good GetGoodsByGroupIdAndIndex(int groupId, int index)
        {
            List<Good> list = null;
            if (!this.groupId_goodMap.TryGetValue(groupId, out list))
            {
                return null;
            }
            return list[index];
        }

        public int GetGoodsListCountByGroupId(int groupId)
        {
            List<Good> list = null;
            if (!this.groupId_goodMap.TryGetValue(groupId, out list))
            {
                return 0;
            }
            return list.Count;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        private AssetGood LoadAssetGoodFromXml(SecurityElement element)
        {
            return new AssetGood { 
                goodId = StrParser.ParseHexInt(element.Attribute("GoodId"), 0),
                assetId = StrParser.ParseHexInt(element.Attribute("AssetId"), 0)
            };
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "GoodConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Good")
                    {
                        Good item = this.LoadGoodFromXml(element2);
                        this._goods.Add(item);
                    }
                    if (element2.Tag == "AssetGood")
                    {
                        AssetGood good2 = this.LoadAssetGoodFromXml(element2);
                        this._assetGoods.Add(good2);
                    }
                }
            }
        }

        private Good LoadGoodFromXml(SecurityElement element)
        {
            Good good = new Good {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                goodsType = TypeNameContainer<_Goods>.Parse(element.Attribute("GoodsType"), 0),
                assetIconId = StrParser.ParseHexInt(element.Attribute("AssetIconId"), 0),
                goodsIndex = StrParser.ParseHexInt(element.Attribute("GoodsIndex"), 0),
                groupId = StrParser.ParseHexInt(element.Attribute("GroupId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Cost")
                        {
                            good.costs.Add(Cost.LoadFromXml(element2));
                        }
                        else if (tag == "Reward")
                        {
                            goto Label_00D7;
                        }
                    }
                    continue;
                Label_00D7:
                    good.rewards.Add(Reward.LoadFromXml(element2));
                }
            }
            return good;
        }

        [ProtoMember(2, Name="assetGoods", DataFormat=DataFormat.Default)]
        public List<AssetGood> assetGoods
        {
            get
            {
                return this._assetGoods;
            }
        }

        [ProtoMember(1, Name="goods", DataFormat=DataFormat.Default)]
        public List<Good> goods
        {
            get
            {
                return this._goods;
            }
        }

        [ProtoContract(Name="AssetGood")]
        public class AssetGood : IExtensible
        {
            private int _assetId;
            private int _goodId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="assetId", DataFormat=DataFormat.TwosComplement)]
            public int assetId
            {
                get
                {
                    return this._assetId;
                }
                set
                {
                    this._assetId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="goodId", DataFormat=DataFormat.TwosComplement)]
            public int goodId
            {
                get
                {
                    return this._goodId;
                }
                set
                {
                    this._goodId = value;
                }
            }
        }

        [ProtoContract(Name="Good")]
        public class Good : IExtensible
        {
            private int _assetIconId;
            private readonly List<Cost> _costs = new List<Cost>();
            private int _goodsIndex;
            private int _goodsType;
            private int _groupId;
            private int _id;
            private readonly List<Reward> _rewards = new List<Reward>();
            public static List<GoodConfig.Good> _typeList = new List<GoodConfig.Good>();
            private IExtension extensionObject;

            public Good()
            {
                _typeList.Add(this);
            }

            public int GetGoodItemType()
            {
                if (!this.IsItemGood())
                {
                    return 0;
                }
                ItemConfig.Item itemById = ConfigDatabase.DefaultCfg.ItemConfig.GetItemById(this._rewards[0].id);
                if (itemById == null)
                {
                    return 0;
                }
                return itemById.type;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            public bool IsItemGood()
            {
                if (this.rewards.Count != 1)
                {
                    return false;
                }
                return (IDSeg.ToAssetType(this._rewards[0].id) == 7);
            }

            [ProtoMember(5, IsRequired=false, Name="assetIconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int assetIconId
            {
                get
                {
                    return this._assetIconId;
                }
                set
                {
                    this._assetIconId = value;
                }
            }

            [ProtoMember(2, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> costs
            {
                get
                {
                    return this._costs;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="goodsIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int goodsIndex
            {
                get
                {
                    return this._goodsIndex;
                }
                set
                {
                    this._goodsIndex = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="goodsType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int goodsType
            {
                get
                {
                    return this._goodsType;
                }
                set
                {
                    this._goodsType = value;
                }
            }

            [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="groupId", DataFormat=DataFormat.TwosComplement)]
            public int groupId
            {
                get
                {
                    return this._groupId;
                }
                set
                {
                    this._groupId = value;
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

            [ProtoMember(3, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> rewards
            {
                get
                {
                    return this._rewards;
                }
            }
        }
    }
}

