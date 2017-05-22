namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_ApplePurchaseRes")]
    public class GC_ApplePurchaseRes : IExtensible
    {
        private readonly List<int> _appleGoodIds = new List<int>();
        private int _callback;
        private int _commodityCount;
        private int _commodityID;
        private int _realMoneyDelta;
        private int _remainingRMB;
        private int _result;
        private int _totalConsumedRMB;
        private string _transactionIdentifier = "";
        private int _vipLevel;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(10, Name="appleGoodIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> appleGoodIds
        {
            get
            {
                return this._appleGoodIds;
            }
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

        [ProtoMember(4, IsRequired=false, Name="commodityCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="commodityID", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="realMoneyDelta", DataFormat=DataFormat.TwosComplement)]
        public int realMoneyDelta
        {
            get
            {
                return this._realMoneyDelta;
            }
            set
            {
                this._realMoneyDelta = value;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="remainingRMB", DataFormat=DataFormat.TwosComplement)]
        public int remainingRMB
        {
            get
            {
                return this._remainingRMB;
            }
            set
            {
                this._remainingRMB = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="result", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(7, IsRequired=false, Name="totalConsumedRMB", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int totalConsumedRMB
        {
            get
            {
                return this._totalConsumedRMB;
            }
            set
            {
                this._totalConsumedRMB = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="transactionIdentifier", DataFormat=DataFormat.Default), DefaultValue("")]
        public string transactionIdentifier
        {
            get
            {
                return this._transactionIdentifier;
            }
            set
            {
                this._transactionIdentifier = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement)]
        public int vipLevel
        {
            get
            {
                return this._vipLevel;
            }
            set
            {
                this._vipLevel = value;
            }
        }
    }
}

