namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Beast")]
    public class Beast : IExtensible
    {
        private int _breakthoughtLevel;
        private string _guid = "";
        private LevelAttrib _levelAttrib;
        private readonly List<int> _partIndexs = new List<int>();
        private int _resourceId;
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

        [ProtoMember(5, Name="partIndexs", DataFormat=DataFormat.TwosComplement)]
        public List<int> partIndexs
        {
            get
            {
                return this._partIndexs;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="resourceId", DataFormat=DataFormat.TwosComplement)]
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
    }
}

