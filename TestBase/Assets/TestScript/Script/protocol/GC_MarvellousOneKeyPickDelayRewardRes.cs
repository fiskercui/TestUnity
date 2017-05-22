namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_MarvellousOneKeyPickDelayRewardRes")]
    public class GC_MarvellousOneKeyPickDelayRewardRes : IExtensible
    {
        private int _callBack;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private readonly List<DelayReward> _delayRewards = new List<DelayReward>();
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=true, Name="callBack", DataFormat=DataFormat.TwosComplement)]
        public int callBack
        {
            get
            {
                return this._callBack;
            }
            set
            {
                this._callBack = value;
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

        [ProtoMember(4, Name="delayRewards", DataFormat=DataFormat.Default)]
        public List<DelayReward> delayRewards
        {
            get
            {
                return this._delayRewards;
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

