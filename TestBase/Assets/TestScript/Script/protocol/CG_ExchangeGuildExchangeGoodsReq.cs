﻿namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CG_ExchangeGuildExchangeGoodsReq")]
    public class CG_ExchangeGuildExchangeGoodsReq : IExtensible
    {
        private int _callback;
        private readonly List<Cost> _costs = new List<Cost>();
        private int _exchangeId;
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

        [ProtoMember(3, Name="costs", DataFormat=DataFormat.Default)]
        public List<Cost> costs
        {
            get
            {
                return this._costs;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="exchangeId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int exchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                this._exchangeId = value;
            }
        }
    }
}

