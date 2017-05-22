namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GuildSetDeclarationReq")]
    public class CG_GuildSetDeclarationReq : IExtensible
    {
        private int _callback;
        private string _declaration = "";
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

        [ProtoMember(2, IsRequired=false, Name="declaration", DataFormat=DataFormat.Default), DefaultValue("")]
        public string declaration
        {
            get
            {
                return this._declaration;
            }
            set
            {
                this._declaration = value;
            }
        }
    }
}

