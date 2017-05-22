namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryFCRankRewardRes")]
    public class GC_QueryFCRankRewardRes : IExtensible
    {
        private int _callback;
        private string _desc = "";
        private bool _isGetReward;
        private long _nextRefreshTime;
        private int _playerRank;
        private int _rankMaxSize;
        private int _result;
        private readonly List<FCRewardInfo> _rewardInfos = new List<FCRewardInfo>();
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

        [ProtoMember(7, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="isGetReward", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isGetReward
        {
            get
            {
                return this._isGetReward;
            }
            set
            {
                this._isGetReward = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(8, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement)]
        public long nextRefreshTime
        {
            get
            {
                return this._nextRefreshTime;
            }
            set
            {
                this._nextRefreshTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="playerRank", DataFormat=DataFormat.TwosComplement)]
        public int playerRank
        {
            get
            {
                return this._playerRank;
            }
            set
            {
                this._playerRank = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="rankMaxSize", DataFormat=DataFormat.TwosComplement)]
        public int rankMaxSize
        {
            get
            {
                return this._rankMaxSize;
            }
            set
            {
                this._rankMaxSize = value;
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

        [ProtoMember(6, Name="rewardInfos", DataFormat=DataFormat.Default)]
        public List<FCRewardInfo> rewardInfos
        {
            get
            {
                return this._rewardInfos;
            }
        }
    }
}

