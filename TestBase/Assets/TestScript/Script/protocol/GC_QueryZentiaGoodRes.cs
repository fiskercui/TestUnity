namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryZentiaGoodRes")]
    public class GC_QueryZentiaGoodRes : IExtensible
    {
        private int _callback;
        private bool _isRankOpen;
        private int _result;
        private readonly List<ZentiaGood> _zentiaGoods = new List<ZentiaGood>();
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

        [DefaultValue(false), ProtoMember(4, IsRequired=false, Name="isRankOpen", DataFormat=DataFormat.Default)]
        public bool isRankOpen
        {
            get
            {
                return this._isRankOpen;
            }
            set
            {
                this._isRankOpen = value;
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

        [ProtoMember(3, Name="zentiaGoods", DataFormat=DataFormat.Default)]
        public List<ZentiaGood> zentiaGoods
        {
            get
            {
                return this._zentiaGoods;
            }
        }
    }
}

