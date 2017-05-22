namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_LevelRewardGetRewardReq")]
    public class CG_LevelRewardGetRewardReq : IExtensible
    {
        private int _callback;
        private int _levelRewardId;
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

        [ProtoMember(2, IsRequired=false, Name="levelRewardId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int levelRewardId
        {
            get
            {
                return this._levelRewardId;
            }
            set
            {
                this._levelRewardId = value;
            }
        }
    }
}

