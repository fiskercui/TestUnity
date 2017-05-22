namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="EfunPlayerInfo")]
    public class EfunPlayerInfo : IExtensible
    {
        private int _level;
        private int _playerId;
        private string _playerName = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
        public int level
        {
            get
            {
                return this._level;
            }
            set
            {
                this._level = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement)]
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
    }
}

