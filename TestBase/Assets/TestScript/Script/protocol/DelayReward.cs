namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="DelayReward")]
    public class DelayReward : IExtensible
    {
        private long _couldPickTime;
        private int _eventId;
        private long _gainRewardTime;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="couldPickTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long couldPickTime
        {
            get
            {
                return this._couldPickTime;
            }
            set
            {
                this._couldPickTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="eventId", DataFormat=DataFormat.TwosComplement)]
        public int eventId
        {
            get
            {
                return this._eventId;
            }
            set
            {
                this._eventId = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(3, IsRequired=false, Name="gainRewardTime", DataFormat=DataFormat.TwosComplement)]
        public long gainRewardTime
        {
            get
            {
                return this._gainRewardTime;
            }
            set
            {
                this._gainRewardTime = value;
            }
        }
    }
}

