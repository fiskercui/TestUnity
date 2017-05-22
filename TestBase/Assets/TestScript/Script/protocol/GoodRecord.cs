namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GoodRecord")]
    public class GoodRecord : IExtensible
    {
        private int _amount;
        private int _goodsID;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="amount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="goodsID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int goodsID
        {
            get
            {
                return this._goodsID;
            }
            set
            {
                this._goodsID = value;
            }
        }
    }
}

