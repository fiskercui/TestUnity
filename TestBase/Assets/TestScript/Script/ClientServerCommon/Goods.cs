namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Goods")]
    public class Goods : IExtensible
    {
        private Cost _cost;
        private Cost _discountCost;
        private int _goodsId;
        private int _quality;
        private Reward _reward;
        private int _type;
        private int _weight;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="cost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="discountCost", DataFormat=DataFormat.Default)]
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

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="quality", DataFormat=DataFormat.TwosComplement)]
        public int quality
        {
            get
            {
                return this._quality;
            }
            set
            {
                this._quality = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="reward", DataFormat=DataFormat.Default)]
        public Reward reward
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

        [ProtoMember(7, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="weight", DataFormat=DataFormat.TwosComplement)]
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
}

