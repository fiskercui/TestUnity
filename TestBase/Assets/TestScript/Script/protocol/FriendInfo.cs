namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="FriendInfo")]
    public class FriendInfo : IExtensible
    {
        private bool _isOnLine;
        private long _lastLoginTime;
        private int _level;
        private long _makeFriendTime;
        private string _name = "";
        private int _playerId;
        private int _power;
        private int _showAvatarId;
        private int _status;
        private int _vipLevel;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(6, IsRequired=false, Name="isOnLine", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isOnLine
        {
            get
            {
                return this._isOnLine;
            }
            set
            {
                this._isOnLine = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="lastLoginTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long lastLoginTime
        {
            get
            {
                return this._lastLoginTime;
            }
            set
            {
                this._lastLoginTime = value;
            }
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

        [ProtoMember(8, IsRequired=false, Name="makeFriendTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long makeFriendTime
        {
            get
            {
                return this._makeFriendTime;
            }
            set
            {
                this._makeFriendTime = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="name", DataFormat=DataFormat.Default), DefaultValue("")]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
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

        [ProtoMember(9, IsRequired=false, Name="showAvatarId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int showAvatarId
        {
            get
            {
                return this._showAvatarId;
            }
            set
            {
                this._showAvatarId = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="status", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement)]
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

