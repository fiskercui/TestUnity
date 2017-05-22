namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GuildRankRecord")]
    public class GuildRankRecord : IExtensible
    {
        private int _currentGuildMemberCount;
        private int _guildConstruct;
        private long _guildConstructTime;
        private int _guildId;
        private int _guildLevel;
        private int _guildMemberMax;
        private string _guildName = "";
        private string _leaderPlayerName = "";
        private int _rank;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="currentGuildMemberCount", DataFormat=DataFormat.TwosComplement)]
        public int currentGuildMemberCount
        {
            get
            {
                return this._currentGuildMemberCount;
            }
            set
            {
                this._currentGuildMemberCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="guildConstruct", DataFormat=DataFormat.TwosComplement)]
        public int guildConstruct
        {
            get
            {
                return this._guildConstruct;
            }
            set
            {
                this._guildConstruct = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(9, IsRequired=false, Name="guildConstructTime", DataFormat=DataFormat.TwosComplement)]
        public long guildConstructTime
        {
            get
            {
                return this._guildConstructTime;
            }
            set
            {
                this._guildConstructTime = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="guildId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildId
        {
            get
            {
                return this._guildId;
            }
            set
            {
                this._guildId = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="guildLevel", DataFormat=DataFormat.TwosComplement)]
        public int guildLevel
        {
            get
            {
                return this._guildLevel;
            }
            set
            {
                this._guildLevel = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="guildMemberMax", DataFormat=DataFormat.TwosComplement)]
        public int guildMemberMax
        {
            get
            {
                return this._guildMemberMax;
            }
            set
            {
                this._guildMemberMax = value;
            }
        }

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="guildName", DataFormat=DataFormat.Default)]
        public string guildName
        {
            get
            {
                return this._guildName;
            }
            set
            {
                this._guildName = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="leaderPlayerName", DataFormat=DataFormat.Default), DefaultValue("")]
        public string leaderPlayerName
        {
            get
            {
                return this._leaderPlayerName;
            }
            set
            {
                this._leaderPlayerName = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="rank", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int rank
        {
            get
            {
                return this._rank;
            }
            set
            {
                this._rank = value;
            }
        }
    }
}

