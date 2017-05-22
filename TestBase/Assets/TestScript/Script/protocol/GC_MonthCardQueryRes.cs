namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_MonthCardQueryRes")]
    public class GC_MonthCardQueryRes : IExtensible
    {
        private int _callback;
        private readonly List<OneMonthCardInfo> _info = new List<OneMonthCardInfo>();
        private long _lastRestTime;
        private int _result;
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

        [ProtoMember(3, Name="info", DataFormat=DataFormat.Default)]
        public List<OneMonthCardInfo> info
        {
            get
            {
                return this._info;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="lastRestTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long lastRestTime
        {
            get
            {
                return this._lastRestTime;
            }
            set
            {
                this._lastRestTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="result", DataFormat=DataFormat.TwosComplement)]
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

