namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="CG_GuildOneKeyRefuseReq")]
    public class CG_GuildOneKeyRefuseReq : IExtensible
    {
        private int _callback;
        private readonly List<int> _playerIds = new List<int>();
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

        [ProtoMember(2, Name="playerIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> playerIds
        {
            get
            {
                return this._playerIds;
            }
        }
    }
}

