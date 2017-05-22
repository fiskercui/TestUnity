namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryGoodsListRes")]
    public class GC_QueryGoodsListRes : IExtensible
    {
        private int _callback;
        private readonly List<Goods> _goods = new List<Goods>();
        private bool _isMelaleucaShopOpen;
        private long _nextRefreshTime;
        private int _result;
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

        [ProtoMember(3, Name="goods", DataFormat=DataFormat.Default)]
        public List<Goods> goods
        {
            get
            {
                return this._goods;
            }
        }

        [DefaultValue(false), ProtoMember(5, IsRequired=false, Name="isMelaleucaShopOpen", DataFormat=DataFormat.Default)]
        public bool isMelaleucaShopOpen
        {
            get
            {
                return this._isMelaleucaShopOpen;
            }
            set
            {
                this._isMelaleucaShopOpen = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(4, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement)]
        public long nextRefreshTime
        {
            get
            {
                return this._nextRefreshTime;
            }
            set
            {
                this._nextRefreshTime = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
        public int result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }
    }
}

