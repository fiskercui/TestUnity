namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="WolfEggs")]
    public class WolfEggs : IExtensible
    {
        private int _rewardCount;
        private int _rewardId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="rewardCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int rewardCount
        {
            get
            {
                return this._rewardCount;
            }
            set
            {
                this._rewardCount = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="rewardId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int rewardId
        {
            get
            {
                return this._rewardId;
            }
            set
            {
                this._rewardId = value;
            }
        }
    }
}

