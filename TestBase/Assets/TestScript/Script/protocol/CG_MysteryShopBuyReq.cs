namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_MysteryShopBuyReq")]
    public class CG_MysteryShopBuyReq : IExtensible
    {
        private int _callback;
        private int _goodsId;
        private int _goodsIndex;
        private int _shopType;
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="goodsId", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(4, IsRequired=false, Name="goodsIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int goodsIndex
        {
            get
            {
                return this._goodsIndex;
            }
            set
            {
                this._goodsIndex = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="shopType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int shopType
        {
            get
            {
                return this._shopType;
            }
            set
            {
                this._shopType = value;
            }
        }
    }
}

