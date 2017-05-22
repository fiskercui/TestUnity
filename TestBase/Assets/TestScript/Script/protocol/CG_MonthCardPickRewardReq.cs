namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_MonthCardPickRewardReq")]
    public class CG_MonthCardPickRewardReq : IExtensible
    {
        private int _callback;
        private int _monthCardId;
        private int _rewardType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(2, IsRequired=false, Name="monthCardId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int monthCardId
        {
            get
            {
                return this._monthCardId;
            }
            set
            {
                this._monthCardId = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="rewardType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int rewardType
        {
            get
            {
                return this._rewardType;
            }
            set
            {
                this._rewardType = value;
            }
        }
    }
}

