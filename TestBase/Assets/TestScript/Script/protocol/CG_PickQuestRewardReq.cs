namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_PickQuestRewardReq")]
    public class CG_PickQuestRewardReq : IExtensible
    {
        private int _callback;
        private int _questId;
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

        [ProtoMember(2, IsRequired=false, Name="questId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int questId
        {
            get
            {
                return this._questId;
            }
            set
            {
                this._questId = value;
            }
        }
    }
}

