namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Skill")]
    public class Skill : IExtensible
    {
        private string _guid = "";
        private LevelAttrib _levelAttrib;
        private int _resourceId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="guid", DataFormat=DataFormat.Default), DefaultValue("")]
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

