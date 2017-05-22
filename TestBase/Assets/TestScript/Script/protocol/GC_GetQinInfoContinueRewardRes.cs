namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GetQinInfoContinueRewardRes")]
    public class GC_GetQinInfoContinueRewardRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private Reward _fixReward;
        private QinInfo _qinInfo;
        private Reward _randomReward;
        private int _result;
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

        [ProtoMember(3, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [ProtoMember(6, IsRequired=false, Name="qinInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public QinInfo qinInfo
        {
            get
            {
                return this._qinInfo;
            }
            set
            {
                this._qinInfo = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="randomReward", DataFormat=DataFormat.Default)]
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
    }
}

