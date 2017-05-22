namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_MelaleucaFloorThisWeekRankRes")]
    public class GC_MelaleucaFloorThisWeekRankRes : IExtensible
    {
        private int _callback;
        private int _currentLayer;
        private int _currentPoint;
        private int _maxPointWeek;
        private int _predictRank;
        private readonly List<MfRankInfo> _rankInfo = new List<MfRankInfo>();
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="currentLayer", DataFormat=DataFormat.TwosComplement)]
        public int currentLayer
        {
            get
            {
                return this._currentLayer;
            }
            set
            {
                this._currentLayer = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="currentPoint", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int currentPoint
        {
            get
            {
                return this._currentPoint;
            }
            set
            {
                this._currentPoint = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="maxPointWeek", DataFormat=DataFormat.TwosComplement)]
        public int maxPointWeek
        {
            get
            {
                return this._maxPointWeek;
            }
            set
            {
                this._maxPointWeek = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="predictRank", DataFormat=DataFormat.TwosComplement)]
        public int predictRank
        {
            get
            {
                return this._predictRank;
            }
            set
            {
                this._predictRank = value;
            }
        }

        [ProtoMember(7, Name="rankInfo", DataFormat=DataFormat.Default)]
        public List<MfRankInfo> rankInfo
        {
            get
            {
                return this._rankInfo;
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

