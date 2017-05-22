namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="ZentiaRank")]
    public class ZentiaRank : IExtensible
    {
        private int _iconId;
        private int _playerId;
        private string _playerName = "";
        private int _playerZentiaPoint;
        private int _rank;
        private Reward _reward;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement)]
        public int iconId
        {
            get
            {
                return this._iconId;
            }
            set
            {
                this._iconId = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(3, IsRequired=false, Name="playerName", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(4, IsRequired=false, Name="playerZentiaPoint", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int playerZentiaPoint
        {
            get
            {
                return this._playerZentiaPoint;
            }
            set
            {
                this._playerZentiaPoint = value;
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
    }
}

