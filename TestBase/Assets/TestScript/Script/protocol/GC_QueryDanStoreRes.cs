namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="GC_QueryDanStoreRes")]
    public class GC_QueryDanStoreRes : IExtensible
    {
        private int _callback;
        private readonly List<DanStoreQueryTime> _danStoreQueryTimes = new List<DanStoreQueryTime>();
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

        [ProtoMember(3, Name="danStoreQueryTimes", DataFormat=DataFormat.Default)]
        public List<DanStoreQueryTime> danStoreQueryTimes
        {
            get
            {
                return this._danStoreQueryTimes;
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

