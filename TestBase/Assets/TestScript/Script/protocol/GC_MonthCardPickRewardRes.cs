namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_MonthCardPickRewardRes")]
    public class GC_MonthCardPickRewardRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private Reward _fixReward;
        private readonly List<OneMonthCardInfo> _info = new List<OneMonthCardInfo>();
        private Reward _randomReward;
        private int _result;
        private int _rewardType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(6, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="fixReward", DataFormat=DataFormat.Default)]
        public Reward fixReward
        {
            get
            {
                return this._fixReward;
            }
            set
            {
                this._fixReward = value;
            }
        }

        [ProtoMember(7, Name="info", DataFormat=DataFormat.Default)]
        public List<OneMonthCardInfo> info
        {
            get
            {
                return this._info;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="randomReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Reward randomReward
        {
            get
            {
                return this._randomReward;
            }
            set
            {
                this._randomReward = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="result", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="rewardType", DataFormat=DataFormat.TwosComplement)]
        public int rewardType
        {
            get
            {
                return this._rewardType;
            }
            set
            {
                this._rewardType = value;
            }
        }
    }
}

