namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Avatar")]
    public class Avatar : IExtensible
    {
        private int _breakthoughtLevel;
        private DomineerData _domineerData;
        private string _guid = "";
        private bool _isAvatar;
        private LevelAttrib _levelAttrib;
        private readonly List<MeridianData> _meridianData = new List<MeridianData>();
        private string _name = "";
        private int _resourceId;
        private int _traitType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="breakthoughtLevel", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(6, IsRequired=false, Name="domineerData", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public DomineerData domineerData
        {
            get
            {
                return this._domineerData;
            }
            set
            {
                this._domineerData = value;
            }
        }

        [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="guid", DataFormat=DataFormat.Default)]
        public string guid
        {
            get
            {
                return this._guid;
            }
            set
            {
                this._guid = value;
            }
        }

        [DefaultValue(false), ProtoMember(7, IsRequired=false, Name="isAvatar", DataFormat=DataFormat.Default)]
        public bool isAvatar
        {
            get
            {
                return this._isAvatar;
            }
            set
            {
                this._isAvatar = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="levelAttrib", DataFormat=DataFormat.Default)]
        public LevelAttrib levelAttrib
        {
            get
            {
                return this._levelAttrib;
            }
            set
            {
                this._levelAttrib = value;
            }
        }

        [ProtoMember(5, Name="meridianData", DataFormat=DataFormat.Default)]
        public List<MeridianData> meridianData
        {
            get
            {
                return this._meridianData;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="name", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(2, IsRequired=false, Name="resourceId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int resourceId
        {
            get
            {
                return this._resourceId;
            }
            set
            {
                this._resourceId = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="traitType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

