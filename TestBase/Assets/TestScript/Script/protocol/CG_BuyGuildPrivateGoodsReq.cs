namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_BuyGuildPrivateGoodsReq")]
    public class CG_BuyGuildPrivateGoodsReq : IExtensible
    {
        private int _callback;
        private int _goodsCount;
        private int _goodsId;
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="goodsCount", DataFormat=DataFormat.TwosComplement)]
        public int goodsCount
        {
            get
            {
                return this._goodsCount;
            }
            set
            {
                this._goodsCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="goodsId", DataFormat=DataFormat.TwosComplement)]
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
    }
}

