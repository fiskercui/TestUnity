namespace WeihuaGames.ClientClass
{
    using System;
    using System.Collections.Generic;

    public class ChatData
    {
        private List<ChatMessage> guildChatMsgs = new List<ChatMessage>();
        private bool hasUnreadGuildChatMsgs;
        private bool hasUnreadPrivateChatMsgs;
        private bool offlineMessageQueried;
        private List<ChatMessage> privateChatMsgs = new List<ChatMessage>();
        private int unreadGuildChatCount;
        private int unreadPrivateChatMsgCount;
        private int unreadWorldChatMsgCount;
        private List<ChatMessage> worldChatMsgs = new List<ChatMessage>();

        public List<ChatMessage> GuildChatMsgs
        {
            get
            {
                return this.guildChatMsgs;
            }
            set
            {
                this.guildChatMsgs = value;
            }
        }

        public bool HasUnreadGuildChatMsgs
        {
            get
            {
                return this.hasUnreadGuildChatMsgs;
            }
            set
            {
                this.hasUnreadGuildChatMsgs = value;
            }
        }

        public bool HasUnreadPrivateChatMsgs
        {
            get
            {
                return this.hasUnreadPrivateChatMsgs;
            }
            set
            {
                this.hasUnreadPrivateChatMsgs = value;
            }
        }

        public bool OfflineMessageQueried
        {
            get
            {
                return this.offlineMessageQueried;
            }
            set
            {
                this.offlineMessageQueried = value;
            }
        }

        public List<ChatMessage> PrivateChatMsgs
        {
            get
            {
                return this.privateChatMsgs;
            }
            set
            {
                this.privateChatMsgs = value;
            }
        }

        public int UnreadGuildChatCount
        {
            get
            {
                return this.unreadGuildChatCount;
            }
            set
            {
                this.unreadGuildChatCount = value;
            }
        }

        public int UnreadPrivateChatMsgCount
        {
            get
            {
                return this.unreadPrivateChatMsgCount;
            }
            set
            {
                this.unreadPrivateChatMsgCount = value;
            }
        }

        public int UnreadWorldChatMsgCount
        {
            get
            {
                return this.unreadWorldChatMsgCount;
            }
            set
            {
                this.unreadWorldChatMsgCount = value;
            }
        }

        public List<ChatMessage> WorldChatMsgs
        {
            get
            {
                return this.worldChatMsgs;
            }
            set
            {
                this.worldChatMsgs = value;
            }
        }
    }
}

