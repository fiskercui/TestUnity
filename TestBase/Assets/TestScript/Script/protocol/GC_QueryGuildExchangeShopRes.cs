﻿namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="GC_QueryGuildExchangeShopRes")]
    public class GC_QueryGuildExchangeShopRes : IExtensible
    {
        private int _callback;
        private readonly List<GuildExchangeGoods> _guildExchangeGoods = new List<GuildExchangeGoods>();
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

        [ProtoMember(3, Name="guildExchangeGoods", DataFormat=DataFormat.Default)]
        public List<GuildExchangeGoods> guildExchangeGoods
        {
            get
            {
                return this._guildExchangeGoods;
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

