namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CG_DanDecomposeReq")]
    public class CG_DanDecomposeReq : IExtensible
    {
        private int _callback;
        private Cost _cost;
        private readonly List<string> _guids = new List<string>();
        private int _type;
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

        [ProtoMember(4, IsRequired=false, Name="cost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Cost cost
        {
            get
            {
                return this._cost;
            }
            set
            {
                this._cost = value;
            }
        }

        [ProtoMember(3, Name="guids", DataFormat=DataFormat.Default)]
        public List<string> guids
        {
            get
            {
                return this._guids;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

