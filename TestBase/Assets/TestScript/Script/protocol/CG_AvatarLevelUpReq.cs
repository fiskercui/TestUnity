namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_AvatarLevelUpReq")]
    public class CG_AvatarLevelUpReq : IExtensible
    {
        private string _avatarGUID = "";
        private int _callback;
        private bool _levelUpType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="avatarGUID", DataFormat=DataFormat.Default), DefaultValue("")]
        public string avatarGUID
        {
            get
            {
                return this._avatarGUID;
            }
            set
            {
                this._avatarGUID = value;
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

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="levelUpType", DataFormat=DataFormat.Default)]
        public bool levelUpType
        {
            get
            {
                return this._levelUpType;
            }
            set
            {
                this._levelUpType = value;
            }
        }
    }
}

