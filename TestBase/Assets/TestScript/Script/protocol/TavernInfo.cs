namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="TavernInfo")]
    public class TavernInfo : IExtensible
    {
        private bool _alreadyTenTavern;
        private int _id;
        private bool _isFirstMoneyBuy;
        private int _leftFreeCount;
        private long _nextFreeStartTime;
        private readonly List<int> _sepicalRewardIds = new List<int>();
        private TavernRewardInfo _tavernRewardInfo;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(false), ProtoMember(5, IsRequired=false, Name="alreadyTenTavern", DataFormat=DataFormat.Default)]
        public bool alreadyTenTavern
        {
            get
            {
                return this._alreadyTenTavern;
            }
            set
            {
                this._alreadyTenTavern = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [DefaultValue(false), ProtoMember(4, IsRequired=false, Name="isFirstMoneyBuy", DataFormat=DataFormat.Default)]
        public bool isFirstMoneyBuy
        {
            get
            {
                return this._isFirstMoneyBuy;
            }
            set
            {
                this._isFirstMoneyBuy = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="leftFreeCount", DataFormat=DataFormat.TwosComplement)]
        public int leftFreeCount
        {
            get
            {
                return this._leftFreeCount;
            }
            set
            {
                this._leftFreeCount = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(3, IsRequired=false, Name="nextFreeStartTime", DataFormat=DataFormat.TwosComplement)]
        public long nextFreeStartTime
        {
            get
            {
                return this._nextFreeStartTime;
            }
            set
            {
                this._nextFreeStartTime = value;
            }
        }

        [ProtoMember(6, Name="sepicalRewardIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> sepicalRewardIds
        {
            get
            {
                return this._sepicalRewardIds;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="tavernRewardInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public TavernRewardInfo tavernRewardInfo
        {
            get
            {
                return this._tavernRewardInfo;
            }
            set
            {
                this._tavernRewardInfo = value;
            }
        }
    }
}

