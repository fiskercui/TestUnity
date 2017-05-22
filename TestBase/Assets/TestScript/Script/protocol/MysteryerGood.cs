namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="MysteryerGood")]
    public class MysteryerGood : IExtensible
    {
        private bool _buyOrNot;
        private Cost _cost;
        private Cost _discountCost;
        private int _goodsId;
        private int _place;
        private Consumable _reward;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="buyOrNot", DataFormat=DataFormat.Default)]
        public bool buyOrNot
        {
            get
            {
                return this._buyOrNot;
            }
            set
            {
                this._buyOrNot = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="cost", DataFormat=DataFormat.Default)]
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

        [ProtoMember(5, IsRequired=false, Name="discountCost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="place", DataFormat=DataFormat.TwosComplement)]
        public int place
        {
            get
            {
                return this._place;
            }
            set
            {
                this._place = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(6, IsRequired=false, Name="reward", DataFormat=DataFormat.Default)]
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

