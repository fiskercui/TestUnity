namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="ActivityInfo")]
    public class ActivityInfo : IExtensible
    {
        private long _closeTime;
        private long _openTime;
        private int _resetType;
        private readonly List<ActivityTimer> _times = new List<ActivityTimer>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="closeTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long closeTime
        {
            get
            {
                return this._closeTime;
            }
            set
            {
                this._closeTime = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="openTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [ProtoMember(1, IsRequired=false, Name="resetType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int resetType
        {
            get
            {
                return this._resetType;
            }
            set
            {
                this._resetType = value;
            }
        }

        [ProtoMember(4, Name="times", DataFormat=DataFormat.Default)]
        public List<ActivityTimer> times
        {
            get
            {
                return this._times;
            }
        }
    }
}

