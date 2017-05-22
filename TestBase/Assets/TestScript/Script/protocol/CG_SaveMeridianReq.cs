namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_SaveMeridianReq")]
    public class CG_SaveMeridianReq : IExtensible
    {
        private string _avatarGuid = "";
        private int _callback;
        private int _meridianId;
        private bool _saveOrNot;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="avatarGuid", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(1, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
        public int callback
        {
            get
            {
                return this._callback;
            }
            set
            {
                this._callback = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="meridianId", DataFormat=DataFormat.TwosComplement)]
        public int meridianId
        {
            get
            {
                return this._meridianId;
            }
            set
            {
                this._meridianId = value;
            }
        }

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="saveOrNot", DataFormat=DataFormat.Default)]
        public bool saveOrNot
        {
            get
            {
                return this._saveOrNot;
            }
            set
            {
                this._saveOrNot = value;
            }
        }
    }
}

