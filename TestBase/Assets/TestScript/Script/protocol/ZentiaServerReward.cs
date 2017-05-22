namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="ZentiaServerReward")]
    public class ZentiaServerReward : IExtensible
    {
        private bool _isActived;
        private bool _isRewardGet;
        private Reward _reward;
        private int _rewardLevelId;
        private long _serverZentiaPoint;
        private int _totalZentiaPoint;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(false), ProtoMember(4, IsRequired=false, Name="isActived", DataFormat=DataFormat.Default)]
        public bool isActived
        {
            get
            {
                return this._isActived;
            }
            set
            {
                this._isActived = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="isRewardGet", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isRewardGet
        {
            get
            {
                return this._isRewardGet;
            }
            set
            {
                this._isRewardGet = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(6, IsRequired=false, Name="reward", DataFormat=DataFormat.Default)]
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

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="rewardLevelId", DataFormat=DataFormat.TwosComplement)]
        public int rewardLevelId
        {
            get
            {
                return this._rewardLevelId;
            }
            set
            {
                this._rewardLevelId = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(2, IsRequired=false, Name="serverZentiaPoint", DataFormat=DataFormat.TwosComplement)]
        public long serverZentiaPoint
        {
            get
            {
                return this._serverZentiaPoint;
            }
            set
            {
                this._serverZentiaPoint = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="totalZentiaPoint", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int totalZentiaPoint
        {
            get
            {
                return this._totalZentiaPoint;
            }
            set
            {
                this._totalZentiaPoint = value;
            }
        }
    }
}

