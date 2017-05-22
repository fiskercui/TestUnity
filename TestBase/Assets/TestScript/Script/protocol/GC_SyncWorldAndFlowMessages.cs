namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="GC_SyncWorldAndFlowMessages")]
    public class GC_SyncWorldAndFlowMessages : IExtensible
    {
        private readonly List<ChatMessage> _messages = new List<ChatMessage>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="messages", DataFormat=DataFormat.Default)]
        public List<ChatMessage> messages
        {
            get
            {
                return this._messages;
            }
        }
    }
}

