namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryFCPointDetailRes")]
    public class GC_QueryFCPointDetailRes : IExtensible
    {
        private int _callback;
        private string _desc = "";
        private int _friendMaxCount;
        private long _nextRefreshTime;
        private readonly List<FCPointInfo> _pointInfos = new List<FCPointInfo>();
        private int _result;
        private int _totalPoint;
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

        [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="desc", DataFormat=DataFormat.Default)]
        public string desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="friendMaxCount", DataFormat=DataFormat.TwosComplement)]
        public int friendMaxCount
        {
            get
            {
                return this._friendMaxCount;
            }
            set
            {
                this._friendMaxCount = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(7, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(5, Name="pointInfos", DataFormat=DataFormat.Default)]
        public List<FCPointInfo> pointInfos
        {
            get
            {
                return this._pointInfos;
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

        [ProtoMember(4, IsRequired=false, Name="totalPoint", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int totalPoint
        {
            get
            {
                return this._totalPoint;
            }
            set
            {
                this._totalPoint = value;
            }
        }
    }
}

