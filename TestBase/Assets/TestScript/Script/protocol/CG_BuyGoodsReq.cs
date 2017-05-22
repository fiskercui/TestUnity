namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_BuyGoodsReq")]
    public class CG_BuyGoodsReq : IExtensible
    {
        private int _callback;
        private GoodRecord _goodRecords;
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

        [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="goodRecords", DataFormat=DataFormat.Default)]
        public GoodRecord goodRecords
        {
            get
            {
                return this._goodRecords;
            }
            set
            {
                this._goodRecords = value;
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

