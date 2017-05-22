namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="NpcInfo")]
    public class NpcInfo : IExtensible
    {
        private int _avatarId;
        private int _battlePosition;
        private int _breakthroughLevel;
        private int _level;
        private int _npcId;
        private string _npcName = "";
        private int _traitType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="avatarId", DataFormat=DataFormat.TwosComplement)]
        public int avatarId
        {
            get
            {
                return this._avatarId;
            }
            set
            {
                this._avatarId = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="battlePosition", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(5, IsRequired=false, Name="breakthroughLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(4, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(1, IsRequired=false, Name="npcId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int npcId
        {
            get
            {
                return this._npcId;
            }
            set
            {
                this._npcId = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="npcName", DataFormat=DataFormat.Default), DefaultValue("")]
        public string npcName
        {
            get
            {
                return this._npcName;
            }
            set
            {
                this._npcName = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="traitType", DataFormat=DataFormat.TwosComplement)]
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

