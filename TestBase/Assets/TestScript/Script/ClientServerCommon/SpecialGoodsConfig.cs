namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="SpecialGoodsConfig")]
    public class SpecialGoodsConfig : Configuration, IExtensible
    {
        private readonly List<SpecialGood> _specialGoods = new List<SpecialGood>();
        private IExtension extensionObject;

        public SpecialGood GetGoodById(int id)
        {
            foreach (SpecialGood good in this._specialGoods)
            {
                if (good.GoodId == id)
                {
                    return good;
                }
            }
            return null;
        }

        public SpecialGood GetGoodByRewardId(int id)
        {
            foreach (SpecialGood good in this._specialGoods)
            {
                if (good.GoodReward.id == id)
                {
                    return good;
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
            if (element.Tag == "SpecialGoodsConfig")
            {
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string str;
                        if (((str = element2.Tag) != null) && (str == "SpecialGood"))
                        {
                            this._specialGoods.Add(this.LoadSpecialGoodFromXml(element2));
                        }
                    }
                }
                new SpecialGood();
            }
        }

        private SpecialGood LoadSpecialGoodFromXml(SecurityElement element)
        {
            SpecialGood good = new SpecialGood {
                GoodId = StrParser.ParseHexInt(element.Attribute("GoodId"), 0),
                IsOpen = StrParser.ParseBool(element.Attribute("IsOpen"), false)
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
                            good.Costs.Add(Cost.LoadFromXml(element2));
                        }
                        else if (tag == "GoodReward")
                        {
                            goto Label_008F;
                        }
                    }
                    continue;
                Label_008F:
                    good.GoodReward = Reward.LoadFromXml(element2);
                }
            }
            return good;
        }

        [ProtoMember(1, Name="specialGoods", DataFormat=DataFormat.Default)]
        public List<SpecialGood> SpecialGoods
        {
            get
            {
                return this._specialGoods;
            }
        }

        [ProtoContract(Name="SpecialGood")]
        public class SpecialGood : IExtensible
        {
            private readonly List<Cost> _costs = new List<Cost>();
            private int _goodId;
            private Reward _goodReward;
            private bool _isOpen;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> Costs
            {
                get
                {
                    return this._costs;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="goodId", DataFormat=DataFormat.TwosComplement)]
            public int GoodId
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

            [ProtoMember(3, IsRequired=false, Name="goodReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public Reward GoodReward
            {
                get
                {
                    return this._goodReward;
                }
                set
                {
                    this._goodReward = value;
                }
            }

            [DefaultValue(false), ProtoMember(4, IsRequired=false, Name="isOpen", DataFormat=DataFormat.Default)]
            public bool IsOpen
            {
                get
                {
                    return this._isOpen;
                }
                set
                {
                    this._isOpen = value;
                }
            }
        }
    }
}

