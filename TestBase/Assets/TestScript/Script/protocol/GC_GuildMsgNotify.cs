namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildMsgNotify")]
    public class GC_GuildMsgNotify : IExtensible
    {
        private GuildMsg _msg;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((string) null), ProtoMember(1, IsRequired=false, Name="msg", DataFormat=DataFormat.Default)]
        public GuildMsg msg
        {
            get
            {
                return this._msg;
            }
            set
            {
                this._msg = value;
            }
        }
    }
}

