namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="WolfSmokeGoodsInfo")]
    public class WolfSmokeGoodsInfo : IExtensible
    {
        private bool _alreadyBuy;
        private Cost _cost;
        private Cost _discountCost;
        private int _goodsId;
        private int _goodsIndex;
        private Consumable _reward;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="alreadyBuy", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool alreadyBuy
        {
            get
            {
                return this._alreadyBuy;
            }
            set
            {
                this._alreadyBuy = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="cost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="discountCost", DataFormat=DataFormat.Default)]
        public Cost discountCost
        {
            get
            {
                return this._discountCost;
            }
            set
            {
                this._discountCost = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="goodsId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="reward", DataFormat=DataFormat.Default)]
        public Consumable reward
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
    }
}

