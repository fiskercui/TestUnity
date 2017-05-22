namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GiveFiveStarsEvaluateReq")]
    public class CG_GiveFiveStarsEvaluateReq : IExtensible
    {
        private int _callback;
        private bool _isEvaluate;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(2, IsRequired=false, Name="isEvaluate", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isEvaluate
        {
            get
            {
                return this._isEvaluate;
            }
            set
            {
                this._isEvaluate = value;
            }
        }
    }
}

