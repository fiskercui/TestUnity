namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GuildViewSimpleReq")]
    public class CG_GuildViewSimpleReq : IExtensible
    {
        private int _callback;
        private int _guildId;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="guildId", DataFormat=DataFormat.TwosComplement)]
        public int guildId
        {
            get
            {
                return this._guildId;
            }
            set
            {
                this._guildId = value;
            }
        }
    }
}

