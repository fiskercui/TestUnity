namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="AppleGoodConfig")]
    public class AppleGoodConfig : Configuration, IExtensible
    {
        private int _currencyType;
        private readonly List<Reward> _firstRewards = new List<Reward>();
        private readonly List<GoodInfo> _goodInfos = new List<GoodInfo>();
        private int _multiplyingPower;
        private IExtension extensionObject;

        public List<Reward> GetAllFirstReward()
        {
            return this.firstRewards;
        }

        public List<GoodInfo> GetAllGoodInfo()
        {
            return this.goodInfos;
        }

        public Reward GetFirstRewardById(int id)
        {
            foreach (Reward reward in this._firstRewards)
            {
                if (reward.id == id)
                {
                    return reward;
                }
            }
            return null;
        }

        public int GetGoodIdByRMB(int RMB, int type, int deviceType)
        {
            int goodId = 0;
            foreach (GoodInfo info in this.goodInfos)
            {
                if (type == info.type)
                {
                    foreach (SubGoodInfo info2 in info.subGoodInfos)
                    {
                        if ((info2.costRMB == RMB) && (info2.deviceType == deviceType))
                        {
                            goodId = info.goodId;
                            break;
                        }
                    }
                }
            }
            return goodId;
        }

        public GoodInfo GetGoodInfoById(int goodId)
        {
            foreach (GoodInfo info2 in this.goodInfos)
            {
                if (goodId == info2.goodId)
                {
                    return info2;
                }
            }
            return null;
        }

        public SubGoodInfo GetGoodInfoByRMB(int RMB, int type, int deviceType)
        {
            SubGoodInfo info = null;
            foreach (GoodInfo info2 in this.goodInfos)
            {
                if (type == info2.type)
                {
                    foreach (SubGoodInfo info3 in info2.subGoodInfos)
                    {
                        if ((info3.costRMB == RMB) && (info3.deviceType == deviceType))
                        {
                            info = info3;
                            break;
                        }
                    }
                }
            }
            return info;
        }

        public SubGoodInfo GetSubGoodInfoById(int goodId, int deviceType)
        {
            SubGoodInfo info = null;
            foreach (GoodInfo info2 in this.goodInfos)
            {
                if (info2.goodId == goodId)
                {
                    foreach (SubGoodInfo info3 in info2.subGoodInfos)
                    {
                        if (info3.deviceType == deviceType)
                        {
                            return info3;
                        }
                    }
                    return info;
                }
            }
            return info;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "AppleGoodConfig")
            {
                this._currencyType = TypeNameContainer<_CurrencyType>.Parse(element.Attribute("CurrencyType"), 0);
                this._multiplyingPower = StrParser.ParseDecInt(element.Attribute("MultiplyingPower"), 1);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag == "GoodInfo")
                            {
                                this._goodInfos.Add(this.LoadGoodInfoFromXml(element2));
                            }
                            else if (tag == "Reward")
                            {
                                goto Label_00A0;
                            }
                        }
                        continue;
                    Label_00A0:
                        this._firstRewards.Add(Reward.LoadFromXml(element2));
                    }
                }
            }
        }

        private GoodInfo LoadGoodInfoFromXml(SecurityElement element)
        {
            GoodInfo info = new GoodInfo {
                goodId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                type = TypeNameContainer<PurchaseType>.Parse(element.Attribute("Type"), -1),
                sortIndex = StrParser.ParseDecInt(element.Attribute("SortIndex"), 0)
            };
            foreach (SecurityElement element2 in element.Children)
            {
                info.subGoodInfos.Add(this.LoadSubGoodInfoFromXml(element2));
            }
            return info;
        }

        private SubGoodInfo LoadSubGoodInfoFromXml(SecurityElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new SubGoodInfo { 
                deviceType = _DeviceType.ParseAppGoodChannelType(element.Attribute("DeviceType"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), ""),
                minDisplayVIPLevel = StrParser.ParseDecInt(element.Attribute("MinDisplayVIPLevel"), 0),
                hideInApple = StrParser.ParseBool(element.Attribute("HideInApple"), false),
                costRMB = StrParser.ParseDecInt(element.Attribute("CostRMB"), 0),
                realMoneyCount = StrParser.ParseDecInt(element.Attribute("RealMoneyCount"), 0),
                realMoneyCountExtra = StrParser.ParseDecInt(element.Attribute("RealMoneyCountExtra"), 0),
                desc = StrParser.ParseStr(element.Attribute("Desc"), ""),
                firstMultiple = StrParser.ParseDecInt(element.Attribute("FirstMultiple"), 1),
                productId = StrParser.ParseStr(element.Attribute("ProductId"), "")
            };
        }

        [ProtoMember(3, IsRequired=false, Name="currencyType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int currencyType
        {
            get
            {
                return this._currencyType;
            }
            set
            {
                this._currencyType = value;
            }
        }

        [ProtoMember(1, Name="firstRewards", DataFormat=DataFormat.Default)]
        public List<Reward> firstRewards
        {
            get
            {
                return this._firstRewards;
            }
        }

        [ProtoMember(2, Name="goodInfos", DataFormat=DataFormat.Default)]
        public List<GoodInfo> goodInfos
        {
            get
            {
                return this._goodInfos;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="multiplyingPower", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int multiplyingPower
        {
            get
            {
                return this._multiplyingPower;
            }
            set
            {
                this._multiplyingPower = value;
            }
        }

        [ProtoContract(Name="GoodInfo")]
        public class GoodInfo : IExtensible
        {
            private int _goodId;
            private int _sortIndex;
            private readonly List<AppleGoodConfig.SubGoodInfo> _subGoodInfos = new List<AppleGoodConfig.SubGoodInfo>();
            private int _type;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [ProtoMember(3, IsRequired=false, Name="sortIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int sortIndex
            {
                get
                {
                    return this._sortIndex;
                }
                set
                {
                    this._sortIndex = value;
                }
            }

            [ProtoMember(4, Name="subGoodInfos", DataFormat=DataFormat.Default)]
            public List<AppleGoodConfig.SubGoodInfo> subGoodInfos
            {
                get
                {
                    return this._subGoodInfos;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoContract(Name="SubGoodInfo")]
        public class SubGoodInfo : IExtensible
        {
            private int _costRMB;
            private string _desc = "";
            private int _deviceType;
            private int _firstMultiple;
            private bool _hideInApple;
            private int _minDisplayVIPLevel;
            private string _name = "";
            private string _productId = "";
            private int _realMoneyCount;
            private int _realMoneyCountExtra;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="costRMB", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int costRMB
            {
                get
                {
                    return this._costRMB;
                }
                set
                {
                    this._costRMB = value;
                }
            }

            [DefaultValue(""), ProtoMember(8, IsRequired=false, Name="desc", DataFormat=DataFormat.Default)]
            public string desc
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

            [ProtoMember(1, IsRequired=false, Name="deviceType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int deviceType
            {
                get
                {
                    return this._deviceType;
                }
                set
                {
                    this._deviceType = value;
                }
            }

            [ProtoMember(9, IsRequired=false, Name="firstMultiple", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int firstMultiple
            {
                get
                {
                    return this._firstMultiple;
                }
                set
                {
                    this._firstMultiple = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="hideInApple", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool hideInApple
            {
                get
                {
                    return this._hideInApple;
                }
                set
                {
                    this._hideInApple = value;
                }
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="minDisplayVIPLevel", DataFormat=DataFormat.TwosComplement)]
            public int minDisplayVIPLevel
            {
                get
                {
                    return this._minDisplayVIPLevel;
                }
                set
                {
                    this._minDisplayVIPLevel = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
            public string name
            {
                get
                {
                    return this._name;
                }
                set
                {
                    this._name = value;
                }
            }

            [DefaultValue(""), ProtoMember(10, IsRequired=false, Name="productId", DataFormat=DataFormat.Default)]
            public string productId
            {
                get
                {
                    return this._productId;
                }
                set
                {
                    this._productId = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="realMoneyCount", DataFormat=DataFormat.TwosComplement)]
            public int realMoneyCount
            {
                get
                {
                    return this._realMoneyCount;
                }
                set
                {
                    this._realMoneyCount = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="realMoneyCountExtra", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int realMoneyCountExtra
            {
                get
                {
                    return this._realMoneyCountExtra;
                }
                set
                {
                    this._realMoneyCountExtra = value;
                }
            }
        }
    }
}

