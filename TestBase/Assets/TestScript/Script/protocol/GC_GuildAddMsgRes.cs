namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildAddMsgRes")]
    public class GC_GuildAddMsgRes : IExtensible
    {
        private int _callback;
        private int _guildMsDay;
        private int _guildMsgCount;
        private readonly List<GuildMsg> _guildMsgs = new List<GuildMsg>();
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

        [ProtoMember(4, IsRequired=false, Name="guildMsDay", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildMsDay
        {
            get
            {
                return this._guildMsDay;
            }
            set
            {
                this._guildMsDay = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="guildMsgCount", DataFormat=DataFormat.TwosComplement)]
        public int guildMsgCount
        {
            get
            {
                return this._guildMsgCount;
            }
            set
            {
                this._guildMsgCount = value;
            }
        }

        [ProtoMember(3, Name="guildMsgs", DataFormat=DataFormat.Default)]
        public List<GuildMsg> guildMsgs
        {
            get
            {
                return this._guildMsgs;
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

