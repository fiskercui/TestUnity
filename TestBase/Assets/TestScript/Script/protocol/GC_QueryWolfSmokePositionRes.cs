namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryWolfSmokePositionRes")]
    public class GC_QueryWolfSmokePositionRes : IExtensible
    {
        private int _callback;
        private bool _isJoin;
        private int _result;
        private readonly List<WolfSelectedAddition> _wolfSelectedAdditions = new List<WolfSelectedAddition>();
        private readonly List<WolfSmokeAddition> _wolfSmokeAdditions = new List<WolfSmokeAddition>();
        private WolfSmokePlayer _wolfSmokePlayer;
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

        [ProtoMember(3, IsRequired=false, Name="isJoin", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isJoin
        {
            get
            {
                return this._isJoin;
            }
            set
            {
                this._isJoin = value;
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

        [ProtoMember(6, Name="wolfSelectedAdditions", DataFormat=DataFormat.Default)]
        public List<WolfSelectedAddition> wolfSelectedAdditions
        {
            get
            {
                return this._wolfSelectedAdditions;
            }
        }

        [ProtoMember(5, Name="wolfSmokeAdditions", DataFormat=DataFormat.Default)]
        public List<WolfSmokeAddition> wolfSmokeAdditions
        {
            get
            {
                return this._wolfSmokeAdditions;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="wolfSmokePlayer", DataFormat=DataFormat.Default)]
        public WolfSmokePlayer wolfSmokePlayer
        {
            get
            {
                return this._wolfSmokePlayer;
            }
            set
            {
                this._wolfSmokePlayer = value;
            }
        }
    }
}

