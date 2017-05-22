namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryChatMessageListRes")]
    public class GC_QueryChatMessageListRes : IExtensible
    {
        private int _callback;
        private int _guildMsgCount;
        private readonly List<ChatMessage> _messages = new List<ChatMessage>();
        private int _privateMsgCount;
        private int _result;
        private int _worldMsgCount;
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

        [ProtoMember(6, IsRequired=false, Name="guildMsgCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(3, Name="messages", DataFormat=DataFormat.Default)]
        public List<ChatMessage> messages
        {
            get
            {
                return this._messages;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="privateMsgCount", DataFormat=DataFormat.TwosComplement)]
        public int privateMsgCount
        {
            get
            {
                return this._privateMsgCount;
            }
            set
            {
                this._privateMsgCount = value;
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

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="worldMsgCount", DataFormat=DataFormat.TwosComplement)]
        public int worldMsgCount
        {
            get
            {
                return this._worldMsgCount;
            }
            set
            {
                this._worldMsgCount = value;
            }
        }
    }
}

