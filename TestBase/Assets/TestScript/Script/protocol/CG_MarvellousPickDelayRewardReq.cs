namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_MarvellousPickDelayRewardReq")]
    public class CG_MarvellousPickDelayRewardReq : IExtensible
    {
        private int _callBack;
        private int _eventId;
        private long _gainRewardTime;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=true, Name="callBack", DataFormat=DataFormat.TwosComplement)]
        public int callBack
        {
            get
            {
                return this._callBack;
            }
            set
            {
                this._callBack = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="eventId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

