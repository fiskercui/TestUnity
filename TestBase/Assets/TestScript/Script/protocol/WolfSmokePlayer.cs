namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="WolfSmokePlayer")]
    public class WolfSmokePlayer : IExtensible
    {
        private readonly List<Avatar> _avatars = new List<Avatar>();
        private readonly List<Equipment> _equipments = new List<Equipment>();
        private string _name = "";
        private int _playerId;
        private Position _position;
        private readonly List<Skill> _skills = new List<Skill>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, Name="avatars", DataFormat=DataFormat.Default)]
        public List<Avatar> avatars
        {
            get
            {
                return this._avatars;
            }
        }

        [ProtoMember(5, Name="equipments", DataFormat=DataFormat.Default)]
        public List<Equipment> equipments
        {
            get
            {
                return this._equipments;
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

        [ProtoMember(3, IsRequired=false, Name="position", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Position position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }

        [ProtoMember(6, Name="skills", DataFormat=DataFormat.Default)]
        public List<Skill> skills
        {
            get
            {
                return this._skills;
            }
        }
    }
}

