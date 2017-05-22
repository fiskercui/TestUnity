namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Reward")]
    public class Reward : IExtensible
    {
        private readonly List<Avatar> _avatars = new List<Avatar>();
        private readonly List<Beast> _beasts = new List<Beast>();
        private readonly List<Consumable> _consumables = new List<Consumable>();
        private readonly List<Consumable> _consumables_bind = new List<Consumable>();
        private readonly List<Dan> _dans = new List<Dan>();
        private readonly List<Equipment> _equips = new List<Equipment>();
        private readonly List<Consumable> _hideConsumables = new List<Consumable>();
        private bool _isBeastDecomposed;
        private readonly List<Skill> _skills = new List<Skill>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, Name="avatars", DataFormat=DataFormat.Default)]
        public List<Avatar> avatars
        {
            get
            {
                return this._avatars;
            }
        }

        [ProtoMember(8, Name="beasts", DataFormat=DataFormat.Default)]
        public List<Beast> beasts
        {
            get
            {
                return this._beasts;
            }
        }

        [ProtoMember(4, Name="consumables", DataFormat=DataFormat.Default)]
        public List<Consumable> consumables
        {
            get
            {
                return this._consumables;
            }
        }

        [ProtoMember(6, Name="consumables_bind", DataFormat=DataFormat.Default)]
        public List<Consumable> consumables_bind
        {
            get
            {
                return this._consumables_bind;
            }
        }

        [ProtoMember(7, Name="dans", DataFormat=DataFormat.Default)]
        public List<Dan> dans
        {
            get
            {
                return this._dans;
            }
        }

        [ProtoMember(1, Name="equips", DataFormat=DataFormat.Default)]
        public List<Equipment> equips
        {
            get
            {
                return this._equips;
            }
        }

        [ProtoMember(5, Name="hideConsumables", DataFormat=DataFormat.Default)]
        public List<Consumable> hideConsumables
        {
            get
            {
                return this._hideConsumables;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="isBeastDecomposed", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isBeastDecomposed
        {
            get
            {
                return this._isBeastDecomposed;
            }
            set
            {
                this._isBeastDecomposed = value;
            }
        }

        [ProtoMember(3, Name="skills", DataFormat=DataFormat.Default)]
        public List<Skill> skills
        {
            get
            {
                return this._skills;
            }
        }
    }
}

