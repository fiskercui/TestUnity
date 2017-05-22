namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="BoxReward")]
    public class BoxReward : IExtensible
    {
        private int _alchemyCount;
        private bool _hasActivityIcon;
        private bool _hasPicked;
        private int _iconId;
        private int _id;
        private int _openIconId;
        private readonly List<ShowReward> _randomRewards = new List<ShowReward>();
        private readonly List<ShowReward> _rewards = new List<ShowReward>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="alchemyCount", DataFormat=DataFormat.TwosComplement)]
        public int alchemyCount
        {
            get
            {
                return this._alchemyCount;
            }
            set
            {
                this._alchemyCount = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="hasActivityIcon", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool hasActivityIcon
        {
            get
            {
                return this._hasActivityIcon;
            }
            set
            {
                this._hasActivityIcon = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="hasPicked", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool hasPicked
        {
            get
            {
                return this._hasPicked;
            }
            set
            {
                this._hasPicked = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="openIconId", DataFormat=DataFormat.TwosComplement)]
        public int openIconId
        {
            get
            {
                return this._openIconId;
            }
            set
            {
                this._openIconId = value;
            }
        }

        [ProtoMember(8, Name="randomRewards", DataFormat=DataFormat.Default)]
        public List<ShowReward> randomRewards
        {
            get
            {
                return this._randomRewards;
            }
        }

        [ProtoMember(7, Name="rewards", DataFormat=DataFormat.Default)]
        public List<ShowReward> rewards
        {
            get
            {
                return this._rewards;
            }
        }
    }
}

