namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="OrderInfo")]
    public class OrderInfo : IExtensible
    {
        private int _accountType;
        private int _channelId;
        private string _orderId = "";
        private int _playerId;
        private int _realMoney;
        private int _rmb;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="accountType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int accountType
        {
            get
            {
                return this._accountType;
            }
            set
            {
                this._accountType = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="channelId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int channelId
        {
            get
            {
                return this._channelId;
            }
            set
            {
                this._channelId = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="orderId", DataFormat=DataFormat.Default), DefaultValue("")]
        public string orderId
        {
            get
            {
                return this._orderId;
            }
            set
            {
                this._orderId = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int playerId
        {
            get
            {
                return this._playerId;
            }
            set
            {
                this._playerId = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="realMoney", DataFormat=DataFormat.TwosComplement)]
        public int realMoney
        {
            get
            {
                return this._realMoney;
            }
            set
            {
                this._realMoney = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="rmb", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int rmb
        {
            get
            {
                return this._rmb;
            }
            set
            {
                this._rmb = value;
            }
        }
    }
}

