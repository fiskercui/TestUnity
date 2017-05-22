namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="FriendCampaignPosition")]
    public class FriendCampaignPosition : IExtensible
    {
        private readonly List<HpInfo> _avatarHpInfos = new List<HpInfo>();
        private readonly List<Location> _locations = new List<Location>();
        private Player _player;
        private double _totalLeftHpPercent;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, Name="avatarHpInfos", DataFormat=DataFormat.Default)]
        public List<HpInfo> avatarHpInfos
        {
            get
            {
                return this._avatarHpInfos;
            }
        }

        [ProtoMember(3, Name="locations", DataFormat=DataFormat.Default)]
        public List<Location> locations
        {
            get
            {
                return this._locations;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="player", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Player player
        {
            get
            {
                return this._player;
            }
            set
            {
                this._player = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="totalLeftHpPercent", DataFormat=DataFormat.TwosComplement), DefaultValue((double) 0.0)]
        public double totalLeftHpPercent
        {
            get
            {
                return this._totalLeftHpPercent;
            }
            set
            {
                this._totalLeftHpPercent = value;
            }
        }
    }
}

