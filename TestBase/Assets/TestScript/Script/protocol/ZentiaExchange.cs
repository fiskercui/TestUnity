namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="ZentiaExchange")]
    public class ZentiaExchange : IExtensible
    {
        private readonly List<CostAsset> _costAssets = new List<CostAsset>();
        private readonly List<ItemEx> _costs = new List<ItemEx>();
        private int _exchangeId;
        private int _iconId;
        private int _index;
        private bool _isAlreadyExchanged;
        private Reward _reward;
        private Reward _zentiaReward;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(6, Name="costAssets", DataFormat=DataFormat.Default)]
        public List<CostAsset> costAssets
        {
            get
            {
                return this._costAssets;
            }
        }

        [ProtoMember(5, Name="costs", DataFormat=DataFormat.Default)]
        public List<ItemEx> costs
        {
            get
            {
                return this._costs;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="exchangeId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int exchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                this._exchangeId = value;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement)]
        public int index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="isAlreadyExchanged", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isAlreadyExchanged
        {
            get
            {
                return this._isAlreadyExchanged;
            }
            set
            {
                this._isAlreadyExchanged = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="reward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="zentiaReward", DataFormat=DataFormat.Default)]
        public Reward zentiaReward
        {
            get
            {
                return this._zentiaReward;
            }
            set
            {
                this._zentiaReward = value;
            }
        }
    }
}

