namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildViewSimpleRes")]
    public class GC_GuildViewSimpleRes : IExtensible
    {
        private int _callback;
        private GuildInfoSimple _guildInfoSimple;
        private int _result;
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

        [ProtoMember(3, IsRequired=false, Name="guildInfoSimple", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public GuildInfoSimple guildInfoSimple
        {
            get
            {
                return this._guildInfoSimple;
            }
            set
            {
                this._guildInfoSimple = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
        public int result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }
    }
}

