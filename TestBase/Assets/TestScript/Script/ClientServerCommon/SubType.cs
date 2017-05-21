namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="SubType")]
    public class SubType : IExtensible
    {
        private int _assetIconId;
        private int _assetIconType;
        private string _desc = "";
        private int _id;
        private string _name = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="assetIconId", DataFormat=DataFormat.TwosComplement)]
        public int assetIconId
        {
            get
            {
                return this._assetIconId;
            }
            set
            {
                this._assetIconId = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="assetIconType", DataFormat=DataFormat.TwosComplement)]
        public int assetIconType
        {
            get
            {
                return this._assetIconType;
            }
            set
            {
                this._assetIconType = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
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
    }
}

