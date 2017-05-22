namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryDanUpgradeRes")]
    public class GC_QueryDanUpgradeRes : IExtensible
    {
        private int _callback;
        private readonly List<Cost> _costs = new List<Cost>();
        private bool _isLevelMax;
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

        [ProtoMember(4, Name="costs", DataFormat=DataFormat.Default)]
        public List<Cost> costs
        {
            get
            {
                return this._costs;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="isLevelMax", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isLevelMax
        {
            get
            {
                return this._isLevelMax;
            }
            set
            {
                this._isLevelMax = value;
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

