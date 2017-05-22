namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;

    [ProtoContract(Name="CG_ChatReq")]
    public class CG_ChatReq : IExtensible
    {
        private int _callback;
        private ChatMessage _chatMessage;
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

        [ProtoMember(2, IsRequired=true, Name="chatMessage", DataFormat=DataFormat.Default)]
        public ChatMessage chatMessage
        {
            get
            {
                return this._chatMessage;
            }
            set
            {
                this._chatMessage = value;
            }
        }
    }
}

