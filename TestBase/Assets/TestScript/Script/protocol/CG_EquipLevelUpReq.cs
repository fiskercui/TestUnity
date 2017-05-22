namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_EquipLevelUpReq")]
    public class CG_EquipLevelUpReq : IExtensible
    {
        private int _callback;
        private string _equipGUID = "";
        private bool _strengthenType;
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

        [ProtoMember(2, IsRequired=false, Name="equipGUID", DataFormat=DataFormat.Default), DefaultValue("")]
        public string equipGUID
        {
            get
            {
                return this._equipGUID;
            }
            set
            {
                this._equipGUID = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="strengthenType", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool strengthenType
        {
            get
            {
                return this._strengthenType;
            }
            set
            {
                this._strengthenType = value;
            }
        }
    }
}

