namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="GC_QueryGuildPrivateShopRes")]
    public class GC_QueryGuildPrivateShopRes : IExtensible
    {
        private int _callback;
        private readonly List<GuildPrivateGoods> _guildPrivateGoods = new List<GuildPrivateGoods>();
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

        [ProtoMember(3, Name="guildPrivateGoods", DataFormat=DataFormat.Default)]
        public List<GuildPrivateGoods> guildPrivateGoods
        {
            get
            {
                return this._guildPrivateGoods;
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

