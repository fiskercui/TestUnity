namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GuildSetAutoEnterReq")]
    public class CG_GuildSetAutoEnterReq : IExtensible
    {
        private bool _allowAutoEnter;
        private int _callback;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="allowAutoEnter", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool allowAutoEnter
        {
            get
            {
                return this._allowAutoEnter;
            }
            set
            {
                this._allowAutoEnter = value;
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
    }
}

