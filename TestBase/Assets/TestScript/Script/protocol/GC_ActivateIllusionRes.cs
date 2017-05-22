namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_ActivateIllusionRes")]
    public class GC_ActivateIllusionRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private IllusionAvatar _illusionAvatar;
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

        [ProtoMember(4, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [ProtoMember(3, IsRequired=false, Name="illusionAvatar", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public IllusionAvatar illusionAvatar
        {
            get
            {
                return this._illusionAvatar;
            }
            set
            {
                this._illusionAvatar = value;
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

