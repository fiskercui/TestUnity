namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="WolfInfo")]
    public class WolfInfo : IExtensible
    {
        private int _alreadyFailedTimes;
        private int _alreadyResetTimes;
        private int _gameMoney;
        private int _maxPassStageId;
        private int _medals;
        private long _nextResetTime;
        private int _realMoney;
        private int _stageId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired=false, Name="alreadyFailedTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int alreadyFailedTimes
        {
            get
            {
                return this._alreadyFailedTimes;
            }
            set
            {
                this._alreadyFailedTimes = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="alreadyResetTimes", DataFormat=DataFormat.TwosComplement)]
        public int alreadyResetTimes
        {
            get
            {
                return this._alreadyResetTimes;
            }
            set
            {
                this._alreadyResetTimes = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="gameMoney", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int gameMoney
        {
            get
            {
                return this._gameMoney;
            }
            set
            {
                this._gameMoney = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="maxPassStageId", DataFormat=DataFormat.TwosComplement)]
        public int maxPassStageId
        {
            get
            {
                return this._maxPassStageId;
            }
            set
            {
                this._maxPassStageId = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="medals", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int medals
        {
            get
            {
                return this._medals;
            }
            set
            {
                this._medals = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(2, IsRequired=false, Name="nextResetTime", DataFormat=DataFormat.TwosComplement)]
        public long nextResetTime
        {
            get
            {
                return this._nextResetTime;
            }
            set
            {
                this._nextResetTime = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="realMoney", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int realMoney
        {
            get
            {
                return this._realMoney;
            }
            set
            {
                this._realMoney = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="stageId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int stageId
        {
            get
            {
                return this._stageId;
            }
            set
            {
                this._stageId = value;
            }
        }
    }
}

