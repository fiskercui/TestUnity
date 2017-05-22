namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;

    [ProtoContract(Name="ActivityTimer")]
    public class ActivityTimer : IExtensible
    {
        private int _status;
        private long _timer;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=true, Name="status", DataFormat=DataFormat.TwosComplement)]
        public int status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        [ProtoMember(1, IsRequired=true, Name="timer", DataFormat=DataFormat.TwosComplement)]
        public long timer
        {
            get
            {
                return this._timer;
            }
            set
            {
                this._timer = value;
            }
        }
    }
}

