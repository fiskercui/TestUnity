namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;

    [ProtoContract(Name="CG_QueryFriendPlayerInfoReq")]
    public class CG_QueryFriendPlayerInfoReq : IExtensible
    {
        private int _callback;
        private int _friendPlayerId;
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

        [ProtoMember(2, IsRequired=true, Name="friendPlayerId", DataFormat=DataFormat.TwosComplement)]
        public int friendPlayerId
        {
            get
            {
                return this._friendPlayerId;
            }
            set
            {
                this._friendPlayerId = value;
            }
        }
    }
}

