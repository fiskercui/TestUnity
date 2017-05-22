namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="DanStoreQueryTime")]
    public class DanStoreQueryTime : IExtensible
    {
        private long _lastQueryTime;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((long) 0L), ProtoMember(2, IsRequired=false, Name="lastQueryTime", DataFormat=DataFormat.TwosComplement)]
        public long lastQueryTime
        {
            get
            {
                return this._lastQueryTime;
            }
            set
            {
                this._lastQueryTime = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

