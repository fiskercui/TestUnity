namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_MarvellousQueryRes")]
    public class GC_MarvellousQueryRes : IExtensible
    {
        private readonly List<DelayReward> _allDelayRewards = new List<DelayReward>();
        private int _callBack;
        private MarvellousProto _marvellousProto;
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, Name="allDelayRewards", DataFormat=DataFormat.Default)]
        public List<DelayReward> allDelayRewards
        {
            get
            {
                return this._allDelayRewards;
            }
        }

        [ProtoMember(1, IsRequired=true, Name="callBack", DataFormat=DataFormat.TwosComplement)]
        public int callBack
        {
            get
            {
                return this._callBack;
            }
            set
            {
                this._callBack = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="marvellousProto", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public MarvellousProto marvellousProto
        {
            get
            {
                return this._marvellousProto;
            }
            set
            {
                this._marvellousProto = value;
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

