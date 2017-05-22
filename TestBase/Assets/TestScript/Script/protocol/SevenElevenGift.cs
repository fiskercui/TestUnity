namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="SevenElevenGift")]
    public class SevenElevenGift : IExtensible
    {
        private int _convertType;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private string _exchangeCode = "";
        private Reward _reward;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="convertType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int convertType
        {
            get
            {
                return this._convertType;
            }
            set
            {
                this._convertType = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="exchangeCode", DataFormat=DataFormat.Default)]
        public string exchangeCode
        {
            get
            {
                return this._exchangeCode;
            }
            set
            {
                this._exchangeCode = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="reward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Reward reward
        {
            get
            {
                return this._reward;
            }
            set
            {
                this._reward = value;
            }
        }
    }
}

