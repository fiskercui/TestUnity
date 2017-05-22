namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class ChannelMessage
    {
        private string accessToken;
        private string channelUniqueId;
        private string channelUserName;
        private string oid;

        public void FromProtobuf(AC_LoginRes.ChannelMessage channelMessage)
        {
            this.accessToken = channelMessage.accessToken;
            this.channelUniqueId = channelMessage.channelUniqueId;
            this.channelUserName = channelMessage.channelUserName;
            this.oid = channelMessage.oid;
        }

        public string AccessToken
        {
            get
            {
                return this.accessToken;
            }
            set
            {
                this.accessToken = value;
            }
        }

        public string ChannelUniqueId
        {
            get
            {
                return this.channelUniqueId;
            }
            set
            {
                this.channelUniqueId = value;
            }
        }

        public string ChannelUserName
        {
            get
            {
                return this.channelUserName;
            }
            set
            {
                this.channelUserName = value;
            }
        }

        public string Oid
        {
            get
            {
                return this.oid;
            }
            set
            {
                this.Oid = value;
            }
        }
    }
}

