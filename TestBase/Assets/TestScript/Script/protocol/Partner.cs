namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Partner")]
    public class Partner : IExtensible
    {
        private string _avatarGuid = "";
        private int _partnerId;
        private int _positionId;
        private int _resourceId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired=false, Name="avatarGuid", DataFormat=DataFormat.Default), DefaultValue("")]
        public string avatarGuid
        {
            get
            {
                return this._avatarGuid;
            }
            set
            {
                this._avatarGuid = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="partnerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int partnerId
        {
            get
            {
                return this._partnerId;
            }
            set
            {
                this._partnerId = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="positionId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int positionId
        {
            get
            {
                return this._positionId;
            }
            set
            {
                this._positionId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="resourceId", DataFormat=DataFormat.TwosComplement)]
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

