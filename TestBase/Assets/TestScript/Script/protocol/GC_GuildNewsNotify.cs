namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildNewsNotify")]
    public class GC_GuildNewsNotify : IExtensible
    {
        private GuildNews _news;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="news", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public GuildNews news
        {
            get
            {
                return this._news;
            }
            set
            {
                this._news = value;
            }
        }
    }
}

