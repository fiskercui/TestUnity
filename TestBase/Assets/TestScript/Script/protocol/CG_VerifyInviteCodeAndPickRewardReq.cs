namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_VerifyInviteCodeAndPickRewardReq")]
    public class CG_VerifyInviteCodeAndPickRewardReq : IExtensible
    {
        private int _callBack;
        private string _inviteCode = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [ProtoMember(2, IsRequired=false, Name="inviteCode", DataFormat=DataFormat.Default), DefaultValue("")]
        public string inviteCode
        {
            get
            {
                return this._inviteCode;
            }
            set
            {
                this._inviteCode = value;
            }
        }
    }
}

