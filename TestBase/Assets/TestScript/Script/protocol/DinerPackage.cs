namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="DinerPackage")]
    public class DinerPackage : IExtensible
    {
        private long _lastRefreshTime;
        private long _nextRefreshTime;
        private int _normalRefreshAmount;
        private int _qualityType;
        private readonly List<QueryDiner> _queryDiners = new List<QueryDiner>();
        private long _refreshCountResetTime;
        private int _specialRefreshAmonut;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, IsRequired=false, Name="lastRefreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="normalRefreshAmount", DataFormat=DataFormat.TwosComplement)]
        public int normalRefreshAmount
        {
            get
            {
                return this._normalRefreshAmount;
            }
            set
            {
                this._normalRefreshAmount = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="qualityType", DataFormat=DataFormat.TwosComplement)]
        public int qualityType
        {
            get
            {
                return this._qualityType;
            }
            set
            {
                this._qualityType = value;
            }
        }

        [ProtoMember(2, Name="queryDiners", DataFormat=DataFormat.Default)]
        public List<QueryDiner> queryDiners
        {
            get
            {
                return this._queryDiners;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(7, IsRequired=false, Name="refreshCountResetTime", DataFormat=DataFormat.TwosComplement)]
        public long refreshCountResetTime
        {
            get
            {
                return this._refreshCountResetTime;
            }
            set
            {
                this._refreshCountResetTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="specialRefreshAmonut", DataFormat=DataFormat.TwosComplement)]
        public int specialRefreshAmonut
        {
            get
            {
                return this._specialRefreshAmonut;
            }
            set
            {
                this._specialRefreshAmonut = value;
            }
        }
    }
}

