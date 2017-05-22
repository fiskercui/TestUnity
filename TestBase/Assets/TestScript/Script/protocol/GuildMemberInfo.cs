namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GuildMemberInfo")]
    public class GuildMemberInfo : IExtensible
    {
        private int _freeChallengeCount;
        private long _joinTime;
        private int _latestContribution;
        private long _offlineTime;
        private bool _online;
        private int _playerId;
        private int _playerLevel;
        private string _playerName = "";
        private int _power;
        private int _receiveBoxCount;
        private int _roleId;
        private int _totalContribution;
        private int _vipLevel;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(11, IsRequired=false, Name="freeChallengeCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int freeChallengeCount
        {
            get
            {
                return this._freeChallengeCount;
            }
            set
            {
                this._freeChallengeCount = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="joinTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long joinTime
        {
            get
            {
                return this._joinTime;
            }
            set
            {
                this._joinTime = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="latestContribution", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int latestContribution
        {
            get
            {
                return this._latestContribution;
            }
            set
            {
                this._latestContribution = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="offlineTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long offlineTime
        {
            get
            {
                return this._offlineTime;
            }
            set
            {
                this._offlineTime = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="online", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool online
        {
            get
            {
                return this._online;
            }
            set
            {
                this._online = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int playerId
        {
            get
            {
                return this._playerId;
            }
            set
            {
                this._playerId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement)]
        public int playerLevel
        {
            get
            {
                return this._playerLevel;
            }
            set
            {
                this._playerLevel = value;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="playerName", DataFormat=DataFormat.Default)]
        public string playerName
        {
            get
            {
                return this._playerName;
            }
            set
            {
                this._playerName = value;
            }
        }

        [ProtoMember(13, IsRequired=false, Name="power", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int power
        {
            get
            {
                return this._power;
            }
            set
            {
                this._power = value;
            }
        }

        [ProtoMember(12, IsRequired=false, Name="receiveBoxCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int receiveBoxCount
        {
            get
            {
                return this._receiveBoxCount;
            }
            set
            {
                this._receiveBoxCount = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="roleId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int roleId
        {
            get
            {
                return this._roleId;
            }
            set
            {
                this._roleId = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="totalContribution", DataFormat=DataFormat.TwosComplement)]
        public int totalContribution
        {
            get
            {
                return this._totalContribution;
            }
            set
            {
                this._totalContribution = value;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement)]
        public int vipLevel
        {
            get
            {
                return this._vipLevel;
            }
            set
            {
                this._vipLevel = value;
            }
        }
    }
}

