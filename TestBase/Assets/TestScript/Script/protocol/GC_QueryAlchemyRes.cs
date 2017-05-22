namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryAlchemyRes")]
    public class GC_QueryAlchemyRes : IExtensible
    {
        private AlchemyClientIcon _alchemyClientIcon;
        private readonly List<Cost> _alchemyCosts = new List<Cost>();
        private readonly List<Cost> _batchAlchemyCosts = new List<Cost>();
        private readonly List<BoxReward> _boxRewards = new List<BoxReward>();
        private int _callback;
        private DecomposeInfo _decomposeInfo;
        private long _nextRefreshTime;
        private int _result;
        private ShowCounter _showCounter;
        private int _todayAlchemyCount;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(8, IsRequired=false, Name="alchemyClientIcon", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public AlchemyClientIcon alchemyClientIcon
        {
            get
            {
                return this._alchemyClientIcon;
            }
            set
            {
                this._alchemyClientIcon = value;
            }
        }

        [ProtoMember(4, Name="alchemyCosts", DataFormat=DataFormat.Default)]
        public List<Cost> alchemyCosts
        {
            get
            {
                return this._alchemyCosts;
            }
        }

        [ProtoMember(5, Name="batchAlchemyCosts", DataFormat=DataFormat.Default)]
        public List<Cost> batchAlchemyCosts
        {
            get
            {
                return this._batchAlchemyCosts;
            }
        }

        [ProtoMember(6, Name="boxRewards", DataFormat=DataFormat.Default)]
        public List<BoxReward> boxRewards
        {
            get
            {
                return this._boxRewards;
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

        [ProtoMember(10, IsRequired=false, Name="decomposeInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public DecomposeInfo decomposeInfo
        {
            get
            {
                return this._decomposeInfo;
            }
            set
            {
                this._decomposeInfo = value;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="showCounter", DataFormat=DataFormat.Default)]
        public ShowCounter showCounter
        {
            get
            {
                return this._showCounter;
            }
            set
            {
                this._showCounter = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="todayAlchemyCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int todayAlchemyCount
        {
            get
            {
                return this._todayAlchemyCount;
            }
            set
            {
                this._todayAlchemyCount = value;
            }
        }
    }
}

