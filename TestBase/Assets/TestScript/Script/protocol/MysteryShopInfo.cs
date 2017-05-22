namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="MysteryShopInfo")]
    public class MysteryShopInfo : IExtensible
    {
        private readonly List<MysteryGoodInfo> _goods = new List<MysteryGoodInfo>();
        private long _lastRefreshTime;
        private long _lastResetTime;
        private long _nextRefreshTime;
        private int _playerRefreshTimes;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="goods", DataFormat=DataFormat.Default)]
        public List<MysteryGoodInfo> goods
        {
            get
            {
                return this._goods;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(4, IsRequired=false, Name="lastRefreshTime", DataFormat=DataFormat.TwosComplement)]
        public long lastRefreshTime
        {
            get
            {
                return this._lastRefreshTime;
            }
            set
            {
                this._lastRefreshTime = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="lastResetTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long lastResetTime
        {
            get
            {
                return this._lastResetTime;
            }
            set
            {
                this._lastResetTime = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="playerRefreshTimes", DataFormat=DataFormat.TwosComplement)]
        public int playerRefreshTimes
        {
            get
            {
                return this._playerRefreshTimes;
            }
            set
            {
                this._playerRefreshTimes = value;
            }
        }
    }
}

