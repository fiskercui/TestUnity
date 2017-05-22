namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_MelaleucaFloorLastWeekRankRes")]
    public class GC_MelaleucaFloorLastWeekRankRes : IExtensible
    {
        private int _arrivalLayer;
        private int _callback;
        private int _point;
        private int _rank;
        private readonly List<MfRankInfo> _rankInfo = new List<MfRankInfo>();
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, IsRequired=false, Name="arrivalLayer", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int arrivalLayer
        {
            get
            {
                return this._arrivalLayer;
            }
            set
            {
                this._arrivalLayer = value;
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

        [ProtoMember(4, IsRequired=false, Name="point", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int point
        {
            get
            {
                return this._point;
            }
            set
            {
                this._point = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="rank", DataFormat=DataFormat.TwosComplement)]
        public int rank
        {
            get
            {
                return this._rank;
            }
            set
            {
                this._rank = value;
            }
        }

        [ProtoMember(6, Name="rankInfo", DataFormat=DataFormat.Default)]
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

