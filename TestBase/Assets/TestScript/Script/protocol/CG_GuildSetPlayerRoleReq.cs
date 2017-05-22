namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GuildSetPlayerRoleReq")]
    public class CG_GuildSetPlayerRoleReq : IExtensible
    {
        private int _callback;
        private int _playerId;
        private int _roleId;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement)]
        public int playerId
        {
            get
            {
                return this._playerId;
            }
            set
            {
                this._playerId = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="roleId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int roleId
        {
            get
            {
                return this._roleId;
            }
            set
            {
                this._roleId = value;
            }
        }
    }
}

