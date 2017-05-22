namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GuildMiniInfo")]
    public class GuildMiniInfo : IExtensible
    {
        private bool _guildAllowAutoEnter;
        private string _guildAnnouncement = "";
        private int _guildConstruct;
        private long _guildConstructTime;
        private long _guildCreateTime;
        private string _guildDeclaration = "";
        private int _guildId;
        private readonly List<GuildInvisibleTaskInfo> _guildInvisibleTaskInfos = new List<GuildInvisibleTaskInfo>();
        private int _guildLeaderPlayerId;
        private int _guildLevel;
        private int _guildMsgCount;
        private int _guildMsgDay;
        private string _guildName = "";
        private int _guildRank;
        private int _latestContribution;
        private string _leaderName = "";
        private int _memberCount;
        private int _msgLeft;
        private int _newsLeft;
        private long _publicShopNextRefreshTime;
        private int _roleId;
        private int _totalContribution;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(10, IsRequired=false, Name="guildAllowAutoEnter", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool guildAllowAutoEnter
        {
            get
            {
                return this._guildAllowAutoEnter;
            }
            set
            {
                this._guildAllowAutoEnter = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="guildAnnouncement", DataFormat=DataFormat.Default), DefaultValue("")]
        public string guildAnnouncement
        {
            get
            {
                return this._guildAnnouncement;
            }
            set
            {
                this._guildAnnouncement = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="guildConstruct", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(5, IsRequired=false, Name="guildCreateTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long guildCreateTime
        {
            get
            {
                return this._guildCreateTime;
            }
            set
            {
                this._guildCreateTime = value;
            }
        }

        [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="guildDeclaration", DataFormat=DataFormat.Default)]
        public string guildDeclaration
        {
            get
            {
                return this._guildDeclaration;
            }
            set
            {
                this._guildDeclaration = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="guildId", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(0x15, Name="guildInvisibleTaskInfos", DataFormat=DataFormat.Default)]
        public List<GuildInvisibleTaskInfo> guildInvisibleTaskInfos
        {
            get
            {
                return this._guildInvisibleTaskInfos;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="guildLeaderPlayerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildLeaderPlayerId
        {
            get
            {
                return this._guildLeaderPlayerId;
            }
            set
            {
                this._guildLeaderPlayerId = value;
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

        [DefaultValue(0), ProtoMember(15, IsRequired=false, Name="guildMsgCount", DataFormat=DataFormat.TwosComplement)]
        public int guildMsgCount
        {
            get
            {
                return this._guildMsgCount;
            }
            set
            {
                this._guildMsgCount = value;
            }
        }

        [ProtoMember(14, IsRequired=false, Name="guildMsgDay", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildMsgDay
        {
            get
            {
                return this._guildMsgDay;
            }
            set
            {
                this._guildMsgDay = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="guildName", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [DefaultValue(0), ProtoMember(0x13, IsRequired=false, Name="guildRank", DataFormat=DataFormat.TwosComplement)]
        public int guildRank
        {
            get
            {
                return this._guildRank;
            }
            set
            {
                this._guildRank = value;
            }
        }

        [DefaultValue(0), ProtoMember(13, IsRequired=false, Name="latestContribution", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(0x12, IsRequired=false, Name="leaderName", DataFormat=DataFormat.Default), DefaultValue("")]
        public string leaderName
        {
            get
            {
                return this._leaderName;
            }
            set
            {
                this._leaderName = value;
            }
        }

        [ProtoMember(20, IsRequired=false, Name="memberCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int memberCount
        {
            get
            {
                return this._memberCount;
            }
            set
            {
                this._memberCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x10, IsRequired=false, Name="msgLeft", DataFormat=DataFormat.TwosComplement)]
        public int msgLeft
        {
            get
            {
                return this._msgLeft;
            }
            set
            {
                this._msgLeft = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x11, IsRequired=false, Name="newsLeft", DataFormat=DataFormat.TwosComplement)]
        public int newsLeft
        {
            get
            {
                return this._newsLeft;
            }
            set
            {
                this._newsLeft = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(0x16, IsRequired=false, Name="publicShopNextRefreshTime", DataFormat=DataFormat.TwosComplement)]
        public long publicShopNextRefreshTime
        {
            get
            {
                return this._publicShopNextRefreshTime;
            }
            set
            {
                this._publicShopNextRefreshTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="roleId", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="totalContribution", DataFormat=DataFormat.TwosComplement)]
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
    }
}

