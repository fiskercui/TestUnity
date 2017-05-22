namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_BuyAndUseReq")]
    public class CG_BuyAndUseReq : IExtensible
    {
        private int _callback;
        private int _goodsId;
        private int _statusIndex;
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

        [ProtoMember(2, IsRequired=false, Name="goodsId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int goodsId
        {
            get
            {
                return this._goodsId;
            }
            set
            {
                this._goodsId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="statusIndex", DataFormat=DataFormat.TwosComplement)]
        public int statusIndex
        {
            get
            {
                return this._statusIndex;
            }
            set
            {
                this._statusIndex = value;
            }
        }
    }
}

