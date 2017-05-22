namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_RemoveFriendReq")]
    public class CG_RemoveFriendReq : IExtensible
    {
        private int _callback;
        private int _removePlayerId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(2, IsRequired=false, Name="removePlayerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int removePlayerId
        {
            get
            {
                return this._removePlayerId;
            }
            set
            {
                this._removePlayerId = value;
            }
        }
    }
}

