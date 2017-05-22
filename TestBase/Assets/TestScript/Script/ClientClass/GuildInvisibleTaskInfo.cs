namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GuildInvisibleTaskInfo
    {
        private int count;
        private int taskId;

        public WeihuaGames.ClientClass.GuildInvisibleTaskInfo FromProtobuf(com.kodgames.corgi.protocol.GuildInvisibleTaskInfo guildInvisibleTaskInfo)
        {
            if (guildInvisibleTaskInfo != null)
            {
                this.taskId = guildInvisibleTaskInfo.taskId;
                this.count = guildInvisibleTaskInfo.count;
            }
            return this;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        public int TaskId
        {
            get
            {
                return this.taskId;
            }
            set
            {
                this.taskId = value;
            }
        }
    }
}

