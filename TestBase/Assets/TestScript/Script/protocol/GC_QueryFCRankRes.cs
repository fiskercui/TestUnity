namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryFCRankRes")]
    public class GC_QueryFCRankRes : IExtensible
    {
        private int _callback;
        private string _desc = "";
        private long _nextRefreshTime;
        private readonly List<FCRankInfo> _rankInfos = new List<FCRankInfo>();
        private int _rankMaxSize;
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [ProtoMember(5, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [ProtoMember(4, Name="rankInfos", DataFormat=DataFormat.Default)]
        public List<FCRankInfo> rankInfos
        {
            get
            {
                return this._rankInfos;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="rankMaxSize", DataFormat=DataFormat.TwosComplement)]
        public int rankMaxSize
        {
            get
            {
                return this._rankMaxSize;
            }
            set
            {
                this._rankMaxSize = value;
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

