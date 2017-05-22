namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class MsgFlowData
    {
        public List<com.kodgames.corgi.protocol.ChatMessage> messages = new List<com.kodgames.corgi.protocol.ChatMessage>();
        public List<com.kodgames.corgi.protocol.ChatMessage> msg_ShowTimeMap = new List<com.kodgames.corgi.protocol.ChatMessage>();
        public com.kodgames.corgi.protocol.ChatMessage showMessage;
    }
}

