namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_InviteFriendReq")]
    public class CG_InviteFriendReq : IExtensible
    {
        private int _callback;
        private int _invitedPlayerId;
        private string _invitedPlayerName = "";
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

        [ProtoMember(2, IsRequired=false, Name="invitedPlayerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int invitedPlayerId
        {
            get
            {
                return this._invitedPlayerId;
            }
            set
            {
                this._invitedPlayerId = value;
            }
        }

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="invitedPlayerName", DataFormat=DataFormat.Default)]
        public string invitedPlayerName
        {
            get
            {
                return this._invitedPlayerName;
            }
            set
            {
                this._invitedPlayerName = value;
            }
        }
    }
}

