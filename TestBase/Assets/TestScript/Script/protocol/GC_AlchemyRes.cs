namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_AlchemyRes")]
    public class GC_AlchemyRes : IExtensible
    {
        private readonly List<Cost> _alchemyCosts = new List<Cost>();
        private readonly List<Cost> _batchAlchemyCosts = new List<Cost>();
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private DecomposeInfo _decomposeInfo;
        private Reward _extraReward;
        private bool _isNeedRefresh;
        private int _result;
        private Reward _reward;
        private ShowCounter _showCounter;
        private int _todayAlchemyCount;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(8, Name="alchemyCosts", DataFormat=DataFormat.Default)]
        public List<Cost> alchemyCosts
        {
            get
            {
                return this._alchemyCosts;
            }
        }

        [ProtoMember(9, Name="batchAlchemyCosts", DataFormat=DataFormat.Default)]
        public List<Cost> batchAlchemyCosts
        {
            get
            {
                return this._batchAlchemyCosts;
            }
        }

        [ProtoMember(1, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
        public int callback
        {
            get
            {
                return this._callback;
            }
            set
            {
                this._callback = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default)]
        public CostAndRewardAndSync costAndRewardAndSync
        {
            get
            {
                return this._costAndRewardAndSync;
            }
            set
            {
                this._costAndRewardAndSync = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(11, IsRequired=false, Name="decomposeInfo", DataFormat=DataFormat.Default)]
        public DecomposeInfo decomposeInfo
        {
            get
            {
                return this._decomposeInfo;
            }
            set
            {
                this._decomposeInfo = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="extraReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Reward extraReward
        {
            get
            {
                return this._extraReward;
            }
            set
            {
                this._extraReward = value;
            }
        }

        [DefaultValue(false), ProtoMember(10, IsRequired=false, Name="isNeedRefresh", DataFormat=DataFormat.Default)]
        public bool isNeedRefresh
        {
            get
            {
                return this._isNeedRefresh;
            }
            set
            {
                this._isNeedRefresh = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
        public int result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="reward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue((string) null), ProtoMember(6, IsRequired=false, Name="showCounter", DataFormat=DataFormat.Default)]
        public ShowCounter showCounter
        {
            get
            {
                return this._showCounter;
            }
            set
            {
                this._showCounter = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="todayAlchemyCount", DataFormat=DataFormat.TwosComplement)]
        public int todayAlchemyCount
        {
            get
            {
                return this._todayAlchemyCount;
            }
            set
            {
                this._todayAlchemyCount = value;
            }
        }
    }
}

