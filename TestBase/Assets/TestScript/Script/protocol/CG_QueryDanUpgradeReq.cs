namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_QueryDanUpgradeReq")]
    public class CG_QueryDanUpgradeReq : IExtensible
    {
        private int _callback;
        private string _danGUID = "";
        private int _upgradeType;
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

        [ProtoMember(2, IsRequired=false, Name="danGUID", DataFormat=DataFormat.Default), DefaultValue("")]
        public string danGUID
        {
            get
            {
                return this._danGUID;
            }
            set
            {
                this._danGUID = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="upgradeType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int upgradeType
        {
            get
            {
                return this._upgradeType;
            }
            set
            {
                this._upgradeType = value;
            }
        }
    }
}

