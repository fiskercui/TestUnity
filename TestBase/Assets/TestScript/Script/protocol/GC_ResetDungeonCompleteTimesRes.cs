namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_ResetDungeonCompleteTimesRes")]
    public class GC_ResetDungeonCompleteTimesRes : IExtensible
    {
        private int _alreadyResetTimes;
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private int _result;
        private int _todayCompleteTimes;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="alreadyResetTimes", DataFormat=DataFormat.TwosComplement)]
        public int alreadyResetTimes
        {
            get
            {
                return this._alreadyResetTimes;
            }
            set
            {
                this._alreadyResetTimes = value;
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

        [ProtoMember(5, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="todayCompleteTimes", DataFormat=DataFormat.TwosComplement)]
        public int todayCompleteTimes
        {
            get
            {
                return this._todayCompleteTimes;
            }
            set
            {
                this._todayCompleteTimes = value;
            }
        }
    }
}

