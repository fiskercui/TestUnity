namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GuildNews
    {
        private string content;
        private int idx;
        private long time;

        public WeihuaGames.ClientClass.GuildNews FromProtobuf(com.kodgames.corgi.protocol.GuildNews guildNews)
        {
            if (guildNews != null)
            {
                this.idx = guildNews.idx;
                this.time = guildNews.time;
                this.content = guildNews.content;
            }
            return this;
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

        public int Idx
        {
            get
            {
                return this.idx;
            }
            set
            {
                this.idx = value;
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

