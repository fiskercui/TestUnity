namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_ApplePurchaseReq")]
    public class CG_ApplePurchaseReq : IExtensible
    {
        private int _callback;
        private int _commodityCount;
        private int _commodityID;
        private string _monthCardId = "";
        private byte[] _receipt;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(3, IsRequired=false, Name="commodityCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int commodityCount
        {
            get
            {
                return this._commodityCount;
            }
            set
            {
                this._commodityCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="commodityID", DataFormat=DataFormat.TwosComplement)]
        public int commodityID
        {
            get
            {
                return this._commodityID;
            }
            set
            {
                this._commodityID = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="monthCardId", DataFormat=DataFormat.Default), DefaultValue("")]
        public string monthCardId
        {
            get
            {
                return this._monthCardId;
            }
            set
            {
                this._monthCardId = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="receipt", DataFormat=DataFormat.Default)]
        public byte[] receipt
        {
            get
            {
                return this._receipt;
            }
            set
            {
                this._receipt = value;
            }
        }
    }
}

