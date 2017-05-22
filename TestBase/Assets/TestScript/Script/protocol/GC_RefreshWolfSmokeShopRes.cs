namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_RefreshWolfSmokeShopRes")]
    public class GC_RefreshWolfSmokeShopRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private readonly List<WolfSmokeGoodsInfo> _goodsInfos = new List<WolfSmokeGoodsInfo>();
        private bool _isJoin;
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

        [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default)]
        public CostAndRewardAndSync costAndRewardAndSync
        {
            get
            {
                return this._costAndRewardAndSync;
            }
            set
            {
                this._costAndRewardAndSync = value;
            }
        }

        [ProtoMember(4, Name="goodsInfos", DataFormat=DataFormat.Default)]
        public List<WolfSmokeGoodsInfo> goodsInfos
        {
            get
            {
                return this._goodsInfos;
            }
        }

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="isJoin", DataFormat=DataFormat.Default)]
        public bool isJoin
        {
            get
            {
                return this._isJoin;
            }
            set
            {
                this._isJoin = value;
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

