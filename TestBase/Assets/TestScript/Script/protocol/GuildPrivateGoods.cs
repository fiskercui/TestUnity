namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GuildPrivateGoods")]
    public class GuildPrivateGoods : IExtensible
    {
        private int _buyCount;
        private int _gooodsId;
        private string _limitDesc = "";
        private long _nextRefreshTime;
        private int _showIndex;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="buyCount", DataFormat=DataFormat.TwosComplement)]
        public int buyCount
        {
            get
            {
                return this._buyCount;
            }
            set
            {
                this._buyCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="gooodsId", DataFormat=DataFormat.TwosComplement)]
        public int gooodsId
        {
            get
            {
                return this._gooodsId;
            }
            set
            {
                this._gooodsId = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="limitDesc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string limitDesc
        {
            get
            {
                return this._limitDesc;
            }
            set
            {
                this._limitDesc = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long nextRefreshTime
        {
            get
            {
                return this._nextRefreshTime;
            }
            set
            {
                this._nextRefreshTime = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="showIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int showIndex
        {
            get
            {
                return this._showIndex;
            }
            set
            {
                this._showIndex = value;
            }
        }
    }
}

