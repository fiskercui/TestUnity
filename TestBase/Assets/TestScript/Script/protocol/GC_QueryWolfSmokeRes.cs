namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryWolfSmokeRes")]
    public class GC_QueryWolfSmokeRes : IExtensible
    {
        private int _callback;
        private Player _enemyPlayer;
        private bool _isJoin;
        private int _lastPositionId;
        private readonly List<Location> _locations = new List<Location>();
        private int _result;
        private readonly List<WolfAvatar> _wolfAvatars = new List<WolfAvatar>();
        private WolfInfo _wolfInfo;
        private Player _wolfPlayer;
        private readonly List<WolfSelectedAddition> _wolfSelectedAdditions = new List<WolfSelectedAddition>();
        private readonly List<WolfSmokeAddition> _wolfSmokeAdditions = new List<WolfSmokeAddition>();
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

        [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="enemyPlayer", DataFormat=DataFormat.Default)]
        public Player enemyPlayer
        {
            get
            {
                return this._enemyPlayer;
            }
            set
            {
                this._enemyPlayer = value;
            }
        }

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="isJoin", DataFormat=DataFormat.Default)]
        public bool isJoin
        {
            get
            {
                return this._isJoin;
            }
            set
            {
                this._isJoin = value;
            }
        }

        [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="lastPositionId", DataFormat=DataFormat.TwosComplement)]
        public int lastPositionId
        {
            get
            {
                return this._lastPositionId;
            }
            set
            {
                this._lastPositionId = value;
            }
        }

        [ProtoMember(6, Name="locations", DataFormat=DataFormat.Default)]
        public List<Location> locations
        {
            get
            {
                return this._locations;
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

        [ProtoMember(10, Name="wolfAvatars", DataFormat=DataFormat.Default)]
        public List<WolfAvatar> wolfAvatars
        {
            get
            {
                return this._wolfAvatars;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="wolfInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public WolfInfo wolfInfo
        {
            get
            {
                return this._wolfInfo;
            }
            set
            {
                this._wolfInfo = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="wolfPlayer", DataFormat=DataFormat.Default)]
        public Player wolfPlayer
        {
            get
            {
                return this._wolfPlayer;
            }
            set
            {
                this._wolfPlayer = value;
            }
        }

        [ProtoMember(9, Name="wolfSelectedAdditions", DataFormat=DataFormat.Default)]
        public List<WolfSelectedAddition> wolfSelectedAdditions
        {
            get
            {
                return this._wolfSelectedAdditions;
            }
        }

        [ProtoMember(8, Name="wolfSmokeAdditions", DataFormat=DataFormat.Default)]
        public List<WolfSmokeAddition> wolfSmokeAdditions
        {
            get
            {
                return this._wolfSmokeAdditions;
            }
        }
    }
}

