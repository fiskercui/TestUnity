namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryBeastExchangeShopRes")]
    public class GC_QueryBeastExchangeShopRes : IExtensible
    {
        private readonly List<ZentiaExchange> _beastExchanges = new List<ZentiaExchange>();
        private int _callback;
        private long _nextSystemRefreshTime;
        private Cost _refreshCost;
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, Name="beastExchanges", DataFormat=DataFormat.Default)]
        public List<ZentiaExchange> beastExchanges
        {
            get
            {
                return this._beastExchanges;
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

        [ProtoMember(5, IsRequired=false, Name="nextSystemRefreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long nextSystemRefreshTime
        {
            get
            {
                return this._nextSystemRefreshTime;
            }
            set
            {
                this._nextSystemRefreshTime = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="refreshCost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Cost refreshCost
        {
            get
            {
                return this._refreshCost;
            }
            set
            {
                this._refreshCost = value;
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

