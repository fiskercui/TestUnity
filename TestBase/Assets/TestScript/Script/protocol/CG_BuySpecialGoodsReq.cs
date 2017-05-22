namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_BuySpecialGoodsReq")]
    public class CG_BuySpecialGoodsReq : IExtensible
    {
        private int _callback;
        private int _goodId;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="goodId", DataFormat=DataFormat.TwosComplement)]
        public int goodId
        {
            get
            {
                return this._goodId;
            }
            set
            {
                this._goodId = value;
            }
        }
    }
}

