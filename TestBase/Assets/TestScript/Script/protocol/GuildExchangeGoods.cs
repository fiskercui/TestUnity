namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GuildExchangeGoods")]
    public class GuildExchangeGoods : IExtensible
    {
        private int _buyCount;
        private int _buyCountLimitPerActive;
        private string _conditionDesc = "";
        private readonly List<CostAsset> _costAssets = new List<CostAsset>();
        private readonly List<ItemEx> _costs = new List<ItemEx>();
        private long _endTime;
        private int _existTimeMs;
        private int _goodsId;
        private bool _isActive;
        private RewardView _rewardView;
        private int _showIndex;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="buyCount", DataFormat=DataFormat.TwosComplement)]
        public int buyCount
        {
            get
            {
                return this._buyCount;
            }
            set
            {
                this._buyCount = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="buyCountLimitPerActive", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int buyCountLimitPerActive
        {
            get
            {
                return this._buyCountLimitPerActive;
            }
            set
            {
                this._buyCountLimitPerActive = value;
            }
        }

        [DefaultValue(""), ProtoMember(11, IsRequired=false, Name="conditionDesc", DataFormat=DataFormat.Default)]
        public string conditionDesc
        {
            get
            {
                return this._conditionDesc;
            }
            set
            {
                this._conditionDesc = value;
            }
        }

        [ProtoMember(5, Name="costAssets", DataFormat=DataFormat.Default)]
        public List<CostAsset> costAssets
        {
            get
            {
                return this._costAssets;
            }
        }

        [ProtoMember(6, Name="costs", DataFormat=DataFormat.Default)]
        public List<ItemEx> costs
        {
            get
            {
                return this._costs;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(10, IsRequired=false, Name="endTime", DataFormat=DataFormat.TwosComplement)]
        public long endTime
        {
            get
            {
                return this._endTime;
            }
            set
            {
                this._endTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="existTimeMs", DataFormat=DataFormat.TwosComplement)]
        public int existTimeMs
        {
            get
            {
                return this._existTimeMs;
            }
            set
            {
                this._existTimeMs = value;
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

        [ProtoMember(8, IsRequired=false, Name="isActive", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isActive
        {
            get
            {
                return this._isActive;
            }
            set
            {
                this._isActive = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="rewardView", DataFormat=DataFormat.Default)]
        public RewardView rewardView
        {
            get
            {
                return this._rewardView;
            }
            set
            {
                this._rewardView = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="showIndex", DataFormat=DataFormat.TwosComplement)]
        public int showIndex
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

