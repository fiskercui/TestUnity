namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class ChatMessage
    {
        private string content;
        private int displayCount;
        private long messageId;
        private int messageType;
        private int receiverId;
        private string receiverName;
        private int receiverVipLevel;
        private int senderId;
        private string senderName;
        private int senderVipLevel;
        private long time;

        public WeihuaGames.ClientClass.ChatMessage FromProtoClass(com.kodgames.corgi.protocol.ChatMessage chatMessage)
        {
            if (chatMessage != null)
            {
                this.messageId = chatMessage.messageId;
                this.messageType = chatMessage.messageType;
                this.receiverId = chatMessage.receiverId;
                this.senderId = chatMessage.senderId;
                this.senderName = chatMessage.senderName;
                this.time = chatMessage.time;
                this.content = chatMessage.content;
                this.receiverName = chatMessage.receiverName;
                this.senderVipLevel = chatMessage.senderVipLevel;
                this.receiverVipLevel = chatMessage.receiverVipLevel;
            }
            return this;
        }

        public com.kodgames.corgi.protocol.ChatMessage ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.ChatMessage { 
                content = this.content,
                messageType = this.messageType,
                receiverId = this.receiverId,
                senderId = this.senderId,
                time = this.time
            };
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }

        public int DisplayCount
        {
            get
            {
                return this.displayCount;
            }
            set
            {
                this.displayCount = value;
            }
        }

        public long MessageId
        {
            get
            {
                return this.messageId;
            }
            set
            {
                this.messageId = value;
            }
        }

        public int MessageType
        {
            get
            {
                return this.messageType;
            }
            set
            {
                this.messageType = value;
            }
        }

        public int ReceiverId
        {
            get
            {
                return this.receiverId;
            }
            set
            {
                this.receiverId = value;
            }
        }

        public string ReceiverName
        {
            get
            {
                return this.receiverName;
            }
            set
            {
                this.receiverName = value;
            }
        }

        public int ReceiverVipLevel
        {
            get
            {
                return this.receiverVipLevel;
            }
            set
            {
                this.receiverVipLevel = value;
            }
        }

        public int SenderId
        {
            get
            {
                return this.senderId;
            }
            set
            {
                this.senderId = value;
            }
        }

        public string SenderName
        {
            get
            {
                return this.senderName;
            }
            set
            {
                this.senderName = value;
            }
        }

        public int SenderVipLevel
        {
            get
            {
                return this.senderVipLevel;
            }
            set
            {
                this.senderVipLevel = value;
            }
        }

        public long Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }
    }
}

