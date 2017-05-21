namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="Breakthrough")]
    public class Breakthrough : IExtensible
    {
        private int _fromTimes;
        private readonly List<GrowthAttribute> _growthAttributes = new List<GrowthAttribute>();
        private bool _isCostSameCardItem;
        private int _itemCostItemCount;
        private int _itemCostItemId;
        private readonly List<Cost> _otherCosts = new List<Cost>();
        private int _powerUpLevelLimit;
        private int _sameCardDeductItemCount;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static Breakthrough LoadFromXml(SecurityElement element)
        {
            Breakthrough breakthrough = new Breakthrough {
                fromTimes = StrParser.ParseDecInt(element.Attribute("FromTimes"), 0),
                sameCardDeductItemCount = StrParser.ParseDecInt(element.Attribute("SameCardDeductItemCount"), 0),
                itemCostItemId = StrParser.ParseHexInt(element.Attribute("ItemCostItemId"), 0),
                itemCostItemCount = StrParser.ParseDecInt(element.Attribute("ItemCostItemCount"), 0),
                powerUpLevelLimit = StrParser.ParseDecInt(element.Attribute("PowerUpLevelLimit"), 0),
                isCostSameCardItem = StrParser.ParseBool(element.Attribute("IsCostSameCardItem"), false)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Attribute")
                        {
                            GrowthAttribute item = GrowthAttribute.LoadFromXml(element2);
                            if (item.baseValue != 0f)
                            {
                                breakthrough.growthAttributes.Add(item);
                            }
                        }
                        else if (tag == "OtherCost")
                        {
                            goto Label_0100;
                        }
                    }
                    goto Label_0111;
                Label_0100:
                    breakthrough.otherCosts.Add(Cost.LoadFromXml(element2));
                Label_0111:
                    bool flag1 = element2.Tag != "Attribute";
                }
            }
            return breakthrough;
        }

        [ProtoMember(1, IsRequired=false, Name="fromTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int fromTimes
        {
            get
            {
                return this._fromTimes;
            }
            set
            {
                this._fromTimes = value;
            }
        }

        [ProtoMember(6, Name="growthAttributes", DataFormat=DataFormat.Default)]
        public List<GrowthAttribute> growthAttributes
        {
            get
            {
                return this._growthAttributes;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="isCostSameCardItem", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isCostSameCardItem
        {
            get
            {
                return this._isCostSameCardItem;
            }
            set
            {
                this._isCostSameCardItem = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="itemCostItemCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int itemCostItemCount
        {
            get
            {
                return this._itemCostItemCount;
            }
            set
            {
                this._itemCostItemCount = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="itemCostItemId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int itemCostItemId
        {
            get
            {
                return this._itemCostItemId;
            }
            set
            {
                this._itemCostItemId = value;
            }
        }

        [ProtoMember(5, Name="otherCosts", DataFormat=DataFormat.Default)]
        public List<Cost> otherCosts
        {
            get
            {
                return this._otherCosts;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="powerUpLevelLimit", DataFormat=DataFormat.TwosComplement)]
        public int powerUpLevelLimit
        {
            get
            {
                return this._powerUpLevelLimit;
            }
            set
            {
                this._powerUpLevelLimit = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="sameCardDeductItemCount", DataFormat=DataFormat.TwosComplement)]
        public int sameCardDeductItemCount
        {
            get
            {
                return this._sameCardDeductItemCount;
            }
            set
            {
                this._sameCardDeductItemCount = value;
            }
        }
    }
}

