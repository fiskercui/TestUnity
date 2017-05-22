namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="DungeonGuideNpc")]
    public class DungeonGuideNpc : IExtensible
    {
        private int _avatarResourceId;
        private int _battlePosition;
        private int _breakthroughLevel;
        private int _level;
        private string _name = "";
        private int _qualityType;
        private int _traitType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="avatarResourceId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int avatarResourceId
        {
            get
            {
                return this._avatarResourceId;
            }
            set
            {
                this._avatarResourceId = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="battlePosition", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int battlePosition
        {
            get
            {
                return this._battlePosition;
            }
            set
            {
                this._battlePosition = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="breakthroughLevel", DataFormat=DataFormat.TwosComplement)]
        public int breakthroughLevel
        {
            get
            {
                return this._breakthroughLevel;
            }
            set
            {
                this._breakthroughLevel = value;
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

        [ProtoMember(5, IsRequired=false, Name="name", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="qualityType", DataFormat=DataFormat.TwosComplement)]
        public int qualityType
        {
            get
            {
                return this._qualityType;
            }
            set
            {
                this._qualityType = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="traitType", DataFormat=DataFormat.TwosComplement)]
        public int traitType
        {
            get
            {
                return this._traitType;
            }
            set
            {
                this._traitType = value;
            }
        }
    }
}

