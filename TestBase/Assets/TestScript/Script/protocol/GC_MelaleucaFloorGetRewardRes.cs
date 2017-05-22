namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_MelaleucaFloorGetRewardRes")]
    public class GC_MelaleucaFloorGetRewardRes : IExtensible
    {
        private int _callback;
        private bool _isGetWeekReward;
        private int _result;
        private CostAndRewardAndSync _reward;
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

        [DefaultValue(false), ProtoMember(4, IsRequired=false, Name="isGetWeekReward", DataFormat=DataFormat.Default)]
        public bool isGetWeekReward
        {
            get
            {
                return this._isGetWeekReward;
            }
            set
            {
                this._isGetWeekReward = value;
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

        [ProtoMember(3, IsRequired=false, Name="reward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public CostAndRewardAndSync reward
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

