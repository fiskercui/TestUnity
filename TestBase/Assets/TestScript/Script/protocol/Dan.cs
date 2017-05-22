namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Dan")]
    public class Dan : IExtensible
    {
        private readonly List<int> _attributeIds = new List<int>();
        private int _breakthoughtLevel;
        private long _createTime;
        private readonly List<DanAttributeGroup> _danAttributeGroups = new List<DanAttributeGroup>();
        private float _danPower;
        private string _guid = "";
        private LevelAttrib _levelAttrib;
        private bool _locked;
        private int _resourceId;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, Name="attributeIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> attributeIds
        {
            get
            {
                return this._attributeIds;
            }
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

        [DefaultValue((long) 0L), ProtoMember(9, IsRequired=false, Name="createTime", DataFormat=DataFormat.TwosComplement)]
        public long createTime
        {
            get
            {
                return this._createTime;
            }
            set
            {
                this._createTime = value;
            }
        }

        [ProtoMember(6, Name="danAttributeGroups", DataFormat=DataFormat.Default)]
        public List<DanAttributeGroup> danAttributeGroups
        {
            get
            {
                return this._danAttributeGroups;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="danPower", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float danPower
        {
            get
            {
                return this._danPower;
            }
            set
            {
                this._danPower = value;
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

        [ProtoMember(3, IsRequired=false, Name="levelAttrib", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue(false), ProtoMember(8, IsRequired=false, Name="locked", DataFormat=DataFormat.Default)]
        public bool locked
        {
            get
            {
                return this._locked;
            }
            set
            {
                this._locked = value;
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

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

