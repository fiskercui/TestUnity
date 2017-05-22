namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CA_AuthActivityCodeReq")]
    public class CA_AuthActivityCodeReq : IExtensible
    {
        private int _accountId;
        private string _activityCode = "";
        private int _callback;
        private string _token = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="accountId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int accountId
        {
            get
            {
                return this._accountId;
            }
            set
            {
                this._accountId = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="activityCode", DataFormat=DataFormat.Default), DefaultValue("")]
        public string activityCode
        {
            get
            {
                return this._activityCode;
            }
            set
            {
                this._activityCode = value;
            }
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

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="token", DataFormat=DataFormat.Default)]
        public string token
        {
            get
            {
                return this._token;
            }
            set
            {
                this._token = value;
            }
        }
    }
}

