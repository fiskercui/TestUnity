namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryGetFixedTimeActivityRewardRes")]
    public class GC_QueryGetFixedTimeActivityRewardRes : IExtensible
    {
        private int _callback;
        private long _lastGetTime;
        private int _resetType;
        private int _result;
        private readonly List<Reward> _reward = new List<Reward>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(4, IsRequired=false, Name="lastGetTime", DataFormat=DataFormat.ZigZag), DefaultValue((long) 0L)]
        public long lastGetTime
        {
            get
            {
                return this._lastGetTime;
            }
            set
            {
                this._lastGetTime = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="resetType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(2, IsRequired=false, Name="result", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(3, Name="reward", DataFormat=DataFormat.Default)]
        public List<Reward> reward
        {
            get
            {
                return this._reward;
            }
        }
    }
}

