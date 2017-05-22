namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryMysteryerRes")]
    public class GC_QueryMysteryerRes : IExtensible
    {
        private int _callback;
        private int _deleteItemId;
        private readonly List<MysteryerGood> _goods = new List<MysteryerGood>();
        private readonly List<MysteryerRefresh> _refreshs = new List<MysteryerRefresh>();
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

        [ProtoMember(5, IsRequired=false, Name="deleteItemId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int deleteItemId
        {
            get
            {
                return this._deleteItemId;
            }
            set
            {
                this._deleteItemId = value;
            }
        }

        [ProtoMember(3, Name="goods", DataFormat=DataFormat.Default)]
        public List<MysteryerGood> goods
        {
            get
            {
                return this._goods;
            }
        }

        [ProtoMember(4, Name="refreshs", DataFormat=DataFormat.Default)]
        public List<MysteryerRefresh> refreshs
        {
            get
            {
                return this._refreshs;
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

