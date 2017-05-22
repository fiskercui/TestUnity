namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Exchange")]
    public class Exchange : IExtensible
    {
        private int _alreadyExchangeCount;
        private readonly List<CostAsset> _costAssets = new List<CostAsset>();
        private readonly List<ItemEx> _costs = new List<ItemEx>();
        private long _endTime;
        private int _exchangeCount;
        private int _exchangeId;
        private ItemEx _gainItem;
        private int _groupId;
        private long _nextOpenTime;
        private long _nextRefreshTime;
        private long _openTime;
        private int _playerLevel;
        private int _sortIndex;
        private int _vipLevel;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, IsRequired=false, Name="alreadyExchangeCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int alreadyExchangeCount
        {
            get
            {
                return this._alreadyExchangeCount;
            }
            set
            {
                this._alreadyExchangeCount = value;
            }
        }

        [ProtoMember(12, Name="costAssets", DataFormat=DataFormat.Default)]
        public List<CostAsset> costAssets
        {
            get
            {
                return this._costAssets;
            }
        }

        [ProtoMember(9, Name="costs", DataFormat=DataFormat.Default)]
        public List<ItemEx> costs
        {
            get
            {
                return this._costs;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(7, IsRequired=false, Name="endTime", DataFormat=DataFormat.TwosComplement)]
        public long endTime
        {
            get
            {
                return this._endTime;
            }
            set
            {
                this._endTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="exchangeCount", DataFormat=DataFormat.TwosComplement)]
        public int exchangeCount
        {
            get
            {
                return this._exchangeCount;
            }
            set
            {
                this._exchangeCount = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="exchangeId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int exchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                this._exchangeId = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="gainItem", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public ItemEx gainItem
        {
            get
            {
                return this._gainItem;
            }
            set
            {
                this._gainItem = value;
            }
        }

        [ProtoMember(13, IsRequired=false, Name="groupId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int groupId
        {
            get
            {
                return this._groupId;
            }
            set
            {
                this._groupId = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(8, IsRequired=false, Name="nextOpenTime", DataFormat=DataFormat.TwosComplement)]
        public long nextOpenTime
        {
            get
            {
                return this._nextOpenTime;
            }
            set
            {
                this._nextOpenTime = value;
            }
        }

        [ProtoMember(14, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [DefaultValue((long) 0L), ProtoMember(6, IsRequired=false, Name="openTime", DataFormat=DataFormat.TwosComplement)]
        public long openTime
        {
            get
            {
                return this._openTime;
            }
            set
            {
                this._openTime = value;
            }
        }

        [ProtoMember(11, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int playerLevel
        {
            get
            {
                return this._playerLevel;
            }
            set
            {
                this._playerLevel = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="sortIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int sortIndex
        {
            get
            {
                return this._sortIndex;
            }
            set
            {
                this._sortIndex = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

