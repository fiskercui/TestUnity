﻿namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="FCPointInfo")]
    public class FCPointInfo : IExtensible
    {
        private int _playerId;
        private string _playerName = "";
        private int _point;
        private int _stageCount;
        private long _time;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [ProtoMember(4, IsRequired=false, Name="point", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int point
        {
            get
            {
                return this._point;
            }
            set
            {
                this._point = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="stageCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int stageCount
        {
            get
            {
                return this._stageCount;
            }
            set
            {
                this._stageCount = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="time", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long time
        {
            get
            {
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }
    }
}

