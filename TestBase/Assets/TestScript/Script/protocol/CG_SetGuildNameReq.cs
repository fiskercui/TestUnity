namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_SetGuildNameReq")]
    public class CG_SetGuildNameReq : IExtensible
    {
        private int _callback;
        private string _guildName = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="guildName", DataFormat=DataFormat.Default)]
        public string guildName
        {
            get
            {
                return this._guildName;
            }
            set
            {
                this._guildName = value;
            }
        }
    }
}

