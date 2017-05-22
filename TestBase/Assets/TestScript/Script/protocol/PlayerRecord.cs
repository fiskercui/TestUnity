namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="PlayerRecord")]
    public class PlayerRecord : IExtensible
    {
        private readonly List<int> _avatarBattlePositions = new List<int>();
        private readonly List<int> _avatarResourceIds = new List<int>();
        private int _guildId;
        private int _playerId;
        private int _playerLevel;
        private string _playerName = "";
        private int _power;
        private int _rank;
        private int _speed;
        private int _vipLevel;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, Name="avatarBattlePositions", DataFormat=DataFormat.TwosComplement)]
        public List<int> avatarBattlePositions
        {
            get
            {
                return this._avatarBattlePositions;
            }
        }

        [ProtoMember(4, Name="avatarResourceIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> avatarResourceIds
        {
            get
            {
                return this._avatarResourceIds;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="guildId", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(3, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(2, IsRequired=false, Name="playerName", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(10, IsRequired=false, Name="power", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="rank", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(6, IsRequired=false, Name="speed", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int speed
        {
            get
            {
                return this._speed;
            }
            set
            {
                this._speed = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

