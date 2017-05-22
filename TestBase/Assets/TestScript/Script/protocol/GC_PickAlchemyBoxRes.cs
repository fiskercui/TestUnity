namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_PickAlchemyBoxRes")]
    public class GC_PickAlchemyBoxRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private bool _hasPicked;
        private bool _isNeedRefresh;
        private Reward _randomReward;
        private int _result;
        private Reward _reward;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default)]
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

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="hasPicked", DataFormat=DataFormat.Default)]
        public bool hasPicked
        {
            get
            {
                return this._hasPicked;
            }
            set
            {
                this._hasPicked = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="isNeedRefresh", DataFormat=DataFormat.Default), DefaultValue(false)]
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

        [ProtoMember(6, IsRequired=false, Name="randomReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [ProtoMember(5, IsRequired=false, Name="reward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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
    }
}

