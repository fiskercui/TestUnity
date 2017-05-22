namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_VerifyInviteCodeAndPickRewardRes")]
    public class GC_VerifyInviteCodeAndPickRewardRes : IExtensible
    {
        private int _callBack;
        private string _codeOwnerName = "";
        private CostAndRewardAndSync _costAndRewardAndSync;
        private int _result;
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

        [ProtoMember(4, IsRequired=false, Name="codeOwnerName", DataFormat=DataFormat.Default), DefaultValue("")]
        public string codeOwnerName
        {
            get
            {
                return this._codeOwnerName;
            }
            set
            {
                this._codeOwnerName = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default)]
        public CostAndRewardAndSync costAndRewardAndSync
        {
            get
            {
                return this._costAndRewardAndSync;
            }
            set
            {
                this._costAndRewardAndSync = value;
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

