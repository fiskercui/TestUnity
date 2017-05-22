namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildTransferRes")]
    public class GC_GuildTransferRes : IExtensible
    {
        private int _callback;
        private GuildMiniInfo _guildMiniInfo;
        private int _playerId;
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

        [ProtoMember(4, IsRequired=false, Name="guildMiniInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public GuildMiniInfo guildMiniInfo
        {
            get
            {
                return this._guildMiniInfo;
            }
            set
            {
                this._guildMiniInfo = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement)]
        public int playerId
        {
            get
            {
                return this._playerId;
            }
            set
            {
                this._playerId = value;
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

