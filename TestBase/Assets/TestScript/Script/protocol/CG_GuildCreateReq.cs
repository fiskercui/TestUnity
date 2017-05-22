namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GuildCreateReq")]
    public class CG_GuildCreateReq : IExtensible
    {
        private bool _allowAutoEnter;
        private int _callback;
        private string _guildName = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="allowAutoEnter", DataFormat=DataFormat.Default), DefaultValue(false)]
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

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="guildName", DataFormat=DataFormat.Default)]
        public string guildName
        {
            get
            {
                return this._guildName;
            }
            set
            {
                this._guildName = value;
            }
        }
    }
}

