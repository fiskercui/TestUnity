namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_MarvellousQueryDelayRewardReq")]
    public class CG_MarvellousQueryDelayRewardReq : IExtensible
    {
        private int _callBack;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="callBack", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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
    }
}

