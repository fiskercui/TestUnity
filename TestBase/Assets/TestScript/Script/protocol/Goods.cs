namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Goods")]
    public class Goods : IExtensible
    {
        private int _discount;
        private long _earlyShowTime;
        private long _endTime;
        private int _goodsID;
        private int _maxBuyCount;
        private readonly List<GoodsSpecialLimit> _melaleucaLimits = new List<GoodsSpecialLimit>();
        private long _nextOpenTime;
        private long _openTime;
        private int _playerLevel;
        private int _remainBuyCount;
        private int _showPlayerLevel;
        private int _showVipLevel;
        private int _status;
        private int _statusIndex;
        private int _timeDurationType;
        private int _vipLevel;
        private readonly List<GoodsSpecialLimit> _wolfSmokeLimits = new List<GoodsSpecialLimit>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="discount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int discount
        {
            get
            {
                return this._discount;
            }
            set
            {
                this._discount = value;
            }
        }

        [ProtoMember(14, IsRequired=false, Name="earlyShowTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long earlyShowTime
        {
            get
            {
                return this._earlyShowTime;
            }
            set
            {
                this._earlyShowTime = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(5, IsRequired=false, Name="endTime", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="goodsID", DataFormat=DataFormat.TwosComplement)]
        public int goodsID
        {
            get
            {
                return this._goodsID;
            }
            set
            {
                this._goodsID = value;
            }
        }

        [ProtoMember(11, IsRequired=false, Name="maxBuyCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int maxBuyCount
        {
            get
            {
                return this._maxBuyCount;
            }
            set
            {
                this._maxBuyCount = value;
            }
        }

        [ProtoMember(0x10, Name="melaleucaLimits", DataFormat=DataFormat.Default)]
        public List<GoodsSpecialLimit> melaleucaLimits
        {
            get
            {
                return this._melaleucaLimits;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="nextOpenTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [DefaultValue((long) 0L), ProtoMember(4, IsRequired=false, Name="openTime", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="remainBuyCount", DataFormat=DataFormat.TwosComplement)]
        public int remainBuyCount
        {
            get
            {
                return this._remainBuyCount;
            }
            set
            {
                this._remainBuyCount = value;
            }
        }

        [ProtoMember(13, IsRequired=false, Name="showPlayerLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int showPlayerLevel
        {
            get
            {
                return this._showPlayerLevel;
            }
            set
            {
                this._showPlayerLevel = value;
            }
        }

        [ProtoMember(12, IsRequired=false, Name="showVipLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int showVipLevel
        {
            get
            {
                return this._showVipLevel;
            }
            set
            {
                this._showVipLevel = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="status", DataFormat=DataFormat.TwosComplement)]
        public int status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="statusIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int statusIndex
        {
            get
            {
                return this._statusIndex;
            }
            set
            {
                this._statusIndex = value;
            }
        }

        [ProtoMember(15, IsRequired=false, Name="timeDurationType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int timeDurationType
        {
            get
            {
                return this._timeDurationType;
            }
            set
            {
                this._timeDurationType = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(0x11, Name="wolfSmokeLimits", DataFormat=DataFormat.Default)]
        public List<GoodsSpecialLimit> wolfSmokeLimits
        {
            get
            {
                return this._wolfSmokeLimits;
            }
        }
    }
}

