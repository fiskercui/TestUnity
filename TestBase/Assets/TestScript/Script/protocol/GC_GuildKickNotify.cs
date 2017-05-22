namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildKickNotify")]
    public class GC_GuildKickNotify : IExtensible
    {
        private string _guildName = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="guildName", DataFormat=DataFormat.Default), DefaultValue("")]
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

