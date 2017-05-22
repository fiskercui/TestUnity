namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GetServerZentiaRewardRes")]
    public class GC_GetServerZentiaRewardRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private int _result;
        private long _serverZentiaPoint;
        private int _totalZentiaPoint;
        private readonly List<ZentiaServerReward> _zentiaServerRewards = new List<ZentiaServerReward>();
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

        [ProtoMember(6, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue((long) 0L), ProtoMember(3, IsRequired=false, Name="serverZentiaPoint", DataFormat=DataFormat.TwosComplement)]
        public long serverZentiaPoint
        {
            get
            {
                return this._serverZentiaPoint;
            }
            set
            {
                this._serverZentiaPoint = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="totalZentiaPoint", DataFormat=DataFormat.TwosComplement)]
        public int totalZentiaPoint
        {
            get
            {
                return this._totalZentiaPoint;
            }
            set
            {
                this._totalZentiaPoint = value;
            }
        }

        [ProtoMember(5, Name="zentiaServerRewards", DataFormat=DataFormat.Default)]
        public List<ZentiaServerReward> zentiaServerRewards
        {
            get
            {
                return this._zentiaServerRewards;
            }
        }
    }
}

