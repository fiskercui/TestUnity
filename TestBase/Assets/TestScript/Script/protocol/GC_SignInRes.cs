namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_SignInRes")]
    public class GC_SignInRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private int _result;
        private Reward _reward;
        private SignData _signData;
        private int _signType;
        private Reward _specialReward;
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="reward", DataFormat=DataFormat.Default)]
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

        [ProtoMember(7, IsRequired=false, Name="signData", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public SignData signData
        {
            get
            {
                return this._signData;
            }
            set
            {
                this._signData = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="signType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int signType
        {
            get
            {
                return this._signType;
            }
            set
            {
                this._signType = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="specialReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Reward specialReward
        {
            get
            {
                return this._specialReward;
            }
            set
            {
                this._specialReward = value;
            }
        }
    }
}

