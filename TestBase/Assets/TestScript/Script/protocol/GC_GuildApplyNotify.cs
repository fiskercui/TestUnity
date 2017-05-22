namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildApplyNotify")]
    public class GC_GuildApplyNotify : IExtensible
    {
        private GuildMiniInfo _guildMiniInfo;
        private string _guildName = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="guildMiniInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

