namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GuildNews")]
    public class GuildNews : IExtensible
    {
        private string _content = "";
        private int _idx;
        private long _time;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="content", DataFormat=DataFormat.Default), DefaultValue("")]
        public string content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="idx", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int idx
        {
            get
            {
                return this._idx;
            }
            set
            {
                this._idx = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="time", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long time
        {
            get
            {
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }
    }
}

