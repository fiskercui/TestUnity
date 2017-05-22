namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CG_ChangeDomineerReq")]
    public class CG_ChangeDomineerReq : IExtensible
    {
        private string _avatarGuid = "";
        private int _callback;
        private readonly List<string> _destroyAvatarGUIDs = new List<string>();
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

        [ProtoMember(3, Name="destroyAvatarGUIDs", DataFormat=DataFormat.Default)]
        public List<string> destroyAvatarGUIDs
        {
            get
            {
                return this._destroyAvatarGUIDs;
            }
        }
    }
}

