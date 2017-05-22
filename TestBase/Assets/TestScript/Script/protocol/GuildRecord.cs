namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GuildRecord")]
    public class GuildRecord : IExtensible
    {
        private int _activeValue;
        private string _declaration = "";
        private int _guildId;
        private int _guildLevel;
        private int _guildMemberMax;
        private int _guildMemberNum;
        private string _guildName = "";
        private string _leaderPlayerName = "";
        private bool _underApply;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(9, IsRequired=false, Name="activeValue", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int activeValue
        {
            get
            {
                return this._activeValue;
            }
            set
            {
                this._activeValue = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="declaration", DataFormat=DataFormat.Default), DefaultValue("")]
        public string declaration
        {
            get
            {
                return this._declaration;
            }
            set
            {
                this._declaration = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="guildId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(3, IsRequired=false, Name="guildLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="guildMemberMax", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="guildMemberNum", DataFormat=DataFormat.TwosComplement)]
        public int guildMemberNum
        {
            get
            {
                return this._guildMemberNum;
            }
            set
            {
                this._guildMemberNum = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="guildName", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(4, IsRequired=false, Name="leaderPlayerName", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(6, IsRequired=false, Name="underApply", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool underApply
        {
            get
            {
                return this._underApply;
            }
            set
            {
                this._underApply = value;
            }
        }
    }
}

