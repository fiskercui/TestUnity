﻿namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_BuyGoodsRes")]
    public class GC_BuyGoodsRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private Goods _good;
        private string _notEnoughText = "";
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default)]
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

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="good", DataFormat=DataFormat.Default)]
        public Goods good
        {
            get
            {
                return this._good;
            }
            set
            {
                this._good = value;
            }
        }

        [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="notEnoughText", DataFormat=DataFormat.Default)]
        public string notEnoughText
        {
            get
            {
                return this._notEnoughText;
            }
            set
            {
                this._notEnoughText = value;
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

