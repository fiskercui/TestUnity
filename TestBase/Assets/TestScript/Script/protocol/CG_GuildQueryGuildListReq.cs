namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GuildQueryGuildListReq")]
    public class CG_GuildQueryGuildListReq : IExtensible
    {
        private int _callback;
        private string _keyWord = "";
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

        [ProtoMember(2, IsRequired=false, Name="keyWord", DataFormat=DataFormat.Default), DefaultValue("")]
        public string keyWord
        {
            get
            {
                return this._keyWord;
            }
            set
            {
                this._keyWord = value;
            }
        }
    }
}

