namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="RobotNpc")]
    public class RobotNpc : IExtensible
    {
        private int _battlePosition;
        private int _breakthoughtLevel;
        private int _level;
        private string _name = "";
        private int _quality;
        private int _recourseId;
        private int _traitType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(7, IsRequired=false, Name="battlePosition", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(5, IsRequired=false, Name="breakthoughtLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int breakthoughtLevel
        {
            get
            {
                return this._breakthoughtLevel;
            }
            set
            {
                this._breakthoughtLevel = value;
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

        [ProtoMember(4, IsRequired=false, Name="quality", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int quality
        {
            get
            {
                return this._quality;
            }
            set
            {
                this._quality = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="recourseId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int recourseId
        {
            get
            {
                return this._recourseId;
            }
            set
            {
                this._recourseId = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="traitType", DataFormat=DataFormat.TwosComplement)]
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

