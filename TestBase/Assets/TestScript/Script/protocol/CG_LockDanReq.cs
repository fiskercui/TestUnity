﻿namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_LockDanReq")]
    public class CG_LockDanReq : IExtensible
    {
        private int _callback;
        private string _guid = "";
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [ProtoMember(3, IsRequired=false, Name="guid", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

