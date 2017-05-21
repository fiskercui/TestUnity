namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="AllPlayerGiftCounterConfig")]
    public class AllPlayerGiftCounterConfig : IExtensible
    {
        private readonly List<AllPlayerGiftCounter> _allPlayerGiftCounters = new List<AllPlayerGiftCounter>();
        private readonly List<SinglePlayerGiftCounter> _singlePlayerGiftCounters = new List<SinglePlayerGiftCounter>();
        private readonly List<SpecialGuaranteePartCounter> _specialGuaranteePartCounters = new List<SpecialGuaranteePartCounter>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="allPlayerGiftCounters", DataFormat=DataFormat.Default)]
        public List<AllPlayerGiftCounter> AllPlayerGiftCounters
        {
            get
            {
                return this._allPlayerGiftCounters;
            }
        }

        [ProtoMember(2, Name="singlePlayerGiftCounters", DataFormat=DataFormat.Default)]
        public List<SinglePlayerGiftCounter> SinglePlayerGiftCounters
        {
            get
            {
                return this._singlePlayerGiftCounters;
            }
        }

        [ProtoMember(3, Name="specialGuaranteePartCounters", DataFormat=DataFormat.Default)]
        public List<SpecialGuaranteePartCounter> SpecialGuaranteePartCounters
        {
            get
            {
                return this._specialGuaranteePartCounters;
            }
        }

        [ProtoContract(Name="AllPlayerGiftCounter")]
        public class AllPlayerGiftCounter : IExtensible
        {
            private int _counterId;
            private bool _isOpen;
            private int _openPurchaseRMB;
            private int _rangeMax;
            private int _rangeMin;
            private int _rewardsetId;
            private int _vipLevelMax;
            private int _vipLevelMin;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="counterId", DataFormat=DataFormat.TwosComplement)]
            public int CounterId
            {
                get
                {
                    return this._counterId;
                }
                set
                {
                    this._counterId = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="isOpen", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool IsOpen
            {
                get
                {
                    return this._isOpen;
                }
                set
                {
                    this._isOpen = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="openPurchaseRMB", DataFormat=DataFormat.TwosComplement)]
            public int OpenPurchaseRMB
            {
                get
                {
                    return this._openPurchaseRMB;
                }
                set
                {
                    this._openPurchaseRMB = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="rangeMax", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int RangeMax
            {
                get
                {
                    return this._rangeMax;
                }
                set
                {
                    this._rangeMax = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="rangeMin", DataFormat=DataFormat.TwosComplement)]
            public int RangeMin
            {
                get
                {
                    return this._rangeMin;
                }
                set
                {
                    this._rangeMin = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="rewardsetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int RewardsetId
            {
                get
                {
                    return this._rewardsetId;
                }
                set
                {
                    this._rewardsetId = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="vipLevelMax", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int VipLevelMax
            {
                get
                {
                    return this._vipLevelMax;
                }
                set
                {
                    this._vipLevelMax = value;
                }
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="vipLevelMin", DataFormat=DataFormat.TwosComplement)]
            public int VipLevelMin
            {
                get
                {
                    return this._vipLevelMin;
                }
                set
                {
                    this._vipLevelMin = value;
                }
            }
        }

        [ProtoContract(Name="SinglePlayerGiftCounter")]
        public class SinglePlayerGiftCounter : IExtensible
        {
            private int _activeCount;
            private int _counterId;
            private bool _isOpen;
            private int _rangeMax;
            private int _rangeMin;
            private int _rewardsetId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, IsRequired=false, Name="activeCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ActiveCount
            {
                get
                {
                    return this._activeCount;
                }
                set
                {
                    this._activeCount = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="counterId", DataFormat=DataFormat.TwosComplement)]
            public int CounterId
            {
                get
                {
                    return this._counterId;
                }
                set
                {
                    this._counterId = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="isOpen", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool IsOpen
            {
                get
                {
                    return this._isOpen;
                }
                set
                {
                    this._isOpen = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="rangeMax", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int RangeMax
            {
                get
                {
                    return this._rangeMax;
                }
                set
                {
                    this._rangeMax = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="rangeMin", DataFormat=DataFormat.TwosComplement)]
            public int RangeMin
            {
                get
                {
                    return this._rangeMin;
                }
                set
                {
                    this._rangeMin = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="rewardsetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int RewardsetId
            {
                get
                {
                    return this._rewardsetId;
                }
                set
                {
                    this._rewardsetId = value;
                }
            }
        }

        [ProtoContract(Name="SpecialGuaranteePartCounter")]
        public class SpecialGuaranteePartCounter : IExtensible
        {
            private int _activeNum;
            private int _closeActiveTime;
            private bool _isOpen;
            private int _itemId;
            private int _priority;
            private int _rewardsetId;
            private int _thresholdNum;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="activeNum", DataFormat=DataFormat.TwosComplement)]
            public int ActiveNum
            {
                get
                {
                    return this._activeNum;
                }
                set
                {
                    this._activeNum = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="closeActiveTime", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CloseActiveTime
            {
                get
                {
                    return this._closeActiveTime;
                }
                set
                {
                    this._closeActiveTime = value;
                }
            }

            [DefaultValue(false), ProtoMember(2, IsRequired=false, Name="isOpen", DataFormat=DataFormat.Default)]
            public bool IsOpen
            {
                get
                {
                    return this._isOpen;
                }
                set
                {
                    this._isOpen = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="itemId", DataFormat=DataFormat.TwosComplement)]
            public int ItemId
            {
                get
                {
                    return this._itemId;
                }
                set
                {
                    this._itemId = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="priority", DataFormat=DataFormat.TwosComplement)]
            public int Priority
            {
                get
                {
                    return this._priority;
                }
                set
                {
                    this._priority = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="rewardsetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int RewardsetId
            {
                get
                {
                    return this._rewardsetId;
                }
                set
                {
                    this._rewardsetId = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="thresholdNum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ThresholdNum
            {
                get
                {
                    return this._thresholdNum;
                }
                set
                {
                    this._thresholdNum = value;
                }
            }
        }
    }
}

