namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="MonthCardConfig")]
    public class MonthCardConfig : Configuration, IExtensible
    {
        private string _explain = "";
        private readonly List<MonthCard> _monthCards = new List<MonthCard>();
        private long _resetTime;
        private IExtension extensionObject;

        public MonthCard GetMonthCardByGoodId(int goodid)
        {
            foreach (MonthCard card in this._monthCards)
            {
                if (card.goodsId == goodid)
                {
                    return card;
                }
            }
            return null;
        }

        public MonthCard GetMonthCardById(int id)
        {
            foreach (MonthCard card in this._monthCards)
            {
                if (card.id == id)
                {
                    return card;
                }
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "MonthCardConfig")
            {
                this.resetTime = StrParser.ParseDateTime(element.Attribute("ResetTime"));
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag == "Explain")
                            {
                                this._explain = StrParser.ParseStr(element2.Text, "");
                            }
                            else if (tag == "MonthCard")
                            {
                                goto Label_008C;
                            }
                        }
                        continue;
                    Label_008C:
                        this._monthCards.Add(this.LoadMonthCardFromXml(element2));
                    }
                }
            }
        }

        private MonthCard LoadMonthCardFromXml(SecurityElement element)
        {
            MonthCard card = new MonthCard {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                monthCardIconId = StrParser.ParseHexInt(element.Attribute("MonthCardIconId"), 0),
                type = TypeNameContainer<MonthCardType>.Parse(element.Attribute("Type"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), ""),
                introduce = StrParser.ParseStr(element.Attribute("Introduce"), "", true),
                remainDaysLimit = StrParser.ParseDecInt(element.Attribute("RemainDaysLimit"), 0),
                durationDay = StrParser.ParseDecInt(element.Attribute("DurationDay"), 0),
                rmb = StrParser.ParseDecInt(element.Attribute("Rmb"), 0),
                freeTimes = StrParser.ParseDecInt(element.Attribute("FreeTimes"), 0),
                isShow = StrParser.ParseBool(element.Attribute("IsShow"), false),
                goodsId = StrParser.ParseHexInt(element.Attribute("GoodsId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "BuyReward")
                        {
                            if (tag == "TenTimesReward")
                            {
                                goto Label_0173;
                            }
                            if (tag == "DailyReward")
                            {
                                goto Label_0182;
                            }
                        }
                        else
                        {
                            card.buyRewardAndIcon = this.LoadMonthCardRewardAndIconFromXml(element2);
                        }
                    }
                    continue;
                Label_0173:
                    card.tenRewardAndIcon = this.LoadMonthCardRewardAndIconFromXml(element2);
                    continue;
                Label_0182:
                    card.dailyRewardAndIcon = this.LoadMonthCardRewardAndIconFromXml(element2);
                }
            }
            return card;
        }

        private MonthCardRewardAndIcon LoadMonthCardRewardAndIconFromXml(SecurityElement element)
        {
            MonthCardRewardAndIcon icon = new MonthCardRewardAndIcon {
                iconId = StrParser.ParseHexInt(element.Attribute("IconId"), 0),
                fixTimeRewardSetId = StrParser.ParseHexInt(element.Attribute("FixRewardSetId"), 0),
                randomRewardSetId = StrParser.ParseHexInt(element.Attribute("RandomRewardSetId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "FixReward")
                        {
                            icon.fixRewardShow.Add(Reward.LoadFromXml(element2));
                        }
                        else if (tag == "RandomReward")
                        {
                            goto Label_00A9;
                        }
                    }
                    continue;
                Label_00A9:
                    icon.randomRewardShow.Add(Reward.LoadFromXml(element2));
                }
            }
            return icon;
        }

        [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="explain", DataFormat=DataFormat.Default)]
        public string explain
        {
            get
            {
                return this._explain;
            }
            set
            {
                this._explain = value;
            }
        }

        [ProtoMember(2, Name="monthCards", DataFormat=DataFormat.Default)]
        public List<MonthCard> monthCards
        {
            get
            {
                return this._monthCards;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="resetTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [ProtoContract(Name="MonthCard")]
        public class MonthCard : IExtensible
        {
            private MonthCardConfig.MonthCardRewardAndIcon _buyRewardAndIcon;
            private MonthCardConfig.MonthCardRewardAndIcon _dailyRewardAndIcon;
            private int _durationDay;
            private int _freeTimes;
            private int _goodsId;
            private int _id;
            private string _introduce = "";
            private bool _isShow;
            private int _monthCardIconId;
            private string _name = "";
            private int _remainDaysLimit;
            private int _rmb;
            private MonthCardConfig.MonthCardRewardAndIcon _tenRewardAndIcon;
            private int _type;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="buyRewardAndIcon", DataFormat=DataFormat.Default)]
            public MonthCardConfig.MonthCardRewardAndIcon buyRewardAndIcon
            {
                get
                {
                    return this._buyRewardAndIcon;
                }
                set
                {
                    this._buyRewardAndIcon = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="dailyRewardAndIcon", DataFormat=DataFormat.Default)]
            public MonthCardConfig.MonthCardRewardAndIcon dailyRewardAndIcon
            {
                get
                {
                    return this._dailyRewardAndIcon;
                }
                set
                {
                    this._dailyRewardAndIcon = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="durationDay", DataFormat=DataFormat.TwosComplement)]
            public int durationDay
            {
                get
                {
                    return this._durationDay;
                }
                set
                {
                    this._durationDay = value;
                }
            }

            [ProtoMember(11, IsRequired=false, Name="freeTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int freeTimes
            {
                get
                {
                    return this._freeTimes;
                }
                set
                {
                    this._freeTimes = value;
                }
            }

            [ProtoMember(14, IsRequired=false, Name="goodsId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="introduce", DataFormat=DataFormat.Default)]
            public string introduce
            {
                get
                {
                    return this._introduce;
                }
                set
                {
                    this._introduce = value;
                }
            }

            [ProtoMember(13, IsRequired=false, Name="isShow", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool isShow
            {
                get
                {
                    return this._isShow;
                }
                set
                {
                    this._isShow = value;
                }
            }

            [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="monthCardIconId", DataFormat=DataFormat.TwosComplement)]
            public int monthCardIconId
            {
                get
                {
                    return this._monthCardIconId;
                }
                set
                {
                    this._monthCardIconId = value;
                }
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
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

            [ProtoMember(9, IsRequired=false, Name="remainDaysLimit", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int remainDaysLimit
            {
                get
                {
                    return this._remainDaysLimit;
                }
                set
                {
                    this._remainDaysLimit = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="rmb", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int rmb
            {
                get
                {
                    return this._rmb;
                }
                set
                {
                    this._rmb = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(6, IsRequired=false, Name="tenRewardAndIcon", DataFormat=DataFormat.Default)]
            public MonthCardConfig.MonthCardRewardAndIcon tenRewardAndIcon
            {
                get
                {
                    return this._tenRewardAndIcon;
                }
                set
                {
                    this._tenRewardAndIcon = value;
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

        [ProtoContract(Name="MonthCardRewardAndIcon")]
        public class MonthCardRewardAndIcon : IExtensible
        {
            private readonly List<Reward> _fixRewardShow = new List<Reward>();
            private int _fixTimeRewardSetId;
            private int _iconId;
            private int _randomRewardSetId;
            private readonly List<Reward> _randomRewardShow = new List<Reward>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, Name="fixRewardShow", DataFormat=DataFormat.Default)]
            public List<Reward> fixRewardShow
            {
                get
                {
                    return this._fixRewardShow;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="fixTimeRewardSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int fixTimeRewardSetId
            {
                get
                {
                    return this._fixTimeRewardSetId;
                }
                set
                {
                    this._fixTimeRewardSetId = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(2, IsRequired=false, Name="randomRewardSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int randomRewardSetId
            {
                get
                {
                    return this._randomRewardSetId;
                }
                set
                {
                    this._randomRewardSetId = value;
                }
            }

            [ProtoMember(5, Name="randomRewardShow", DataFormat=DataFormat.Default)]
            public List<Reward> randomRewardShow
            {
                get
                {
                    return this._randomRewardShow;
                }
            }
        }
    }
}

