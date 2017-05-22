namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="OneMonthCardInfo")]
    public class OneMonthCardInfo : IExtensible
    {
        private int _buyRewardCount;
        private bool _isCouldPickDailyReward;
        private long _lastPickTime;
        private int _monthCardId;
        private int _monthCardType;
        private int _pickCounter;
        private int _remainDates;
        private int _remainFreeCounts;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired=false, Name="buyRewardCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int buyRewardCount
        {
            get
            {
                return this._buyRewardCount;
            }
            set
            {
                this._buyRewardCount = value;
            }
        }

        [DefaultValue(false), ProtoMember(8, IsRequired=false, Name="isCouldPickDailyReward", DataFormat=DataFormat.Default)]
        public bool isCouldPickDailyReward
        {
            get
            {
                return this._isCouldPickDailyReward;
            }
            set
            {
                this._isCouldPickDailyReward = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="lastPickTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long lastPickTime
        {
            get
            {
                return this._lastPickTime;
            }
            set
            {
                this._lastPickTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="monthCardId", DataFormat=DataFormat.TwosComplement)]
        public int monthCardId
        {
            get
            {
                return this._monthCardId;
            }
            set
            {
                this._monthCardId = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="monthCardType", DataFormat=DataFormat.TwosComplement)]
        public int monthCardType
        {
            get
            {
                return this._monthCardType;
            }
            set
            {
                this._monthCardType = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="pickCounter", DataFormat=DataFormat.TwosComplement)]
        public int pickCounter
        {
            get
            {
                return this._pickCounter;
            }
            set
            {
                this._pickCounter = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="remainDates", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int remainDates
        {
            get
            {
                return this._remainDates;
            }
            set
            {
                this._remainDates = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="remainFreeCounts", DataFormat=DataFormat.TwosComplement)]
        public int remainFreeCounts
        {
            get
            {
                return this._remainFreeCounts;
            }
            set
            {
                this._remainFreeCounts = value;
            }
        }
    }
}

