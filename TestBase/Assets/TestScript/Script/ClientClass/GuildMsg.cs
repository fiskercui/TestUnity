namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GuildMsg
    {
        private string msg;
        private int playerId;
        private int playerLevel;
        private string playerName;
        private int roleId;
        private long time;

        public WeihuaGames.ClientClass.GuildMsg FromProtobuf(com.kodgames.corgi.protocol.GuildMsg guildMsg)
        {
            if (guildMsg != null)
            {
                this.time = guildMsg.time;
                this.playerId = guildMsg.playerId;
                this.playerName = guildMsg.playerName;
                this.roleId = guildMsg.roleId;
                this.msg = guildMsg.msg;
                this.playerLevel = guildMsg.playerLevel;
            }
            return this;
        }

        public string Msg
        {
            get
            {
                return this.msg;
            }
            set
            {
                this.msg = value;
            }
        }

        public int PlayerId
        {
            get
            {
                return this.playerId;
            }
            set
            {
                this.playerId = value;
            }
        }

        public int PlayerLevel
        {
            get
            {
                return this.playerLevel;
            }
            set
            {
                this.playerLevel = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            set
            {
                this.playerName = value;
            }
        }

        public int RoleId
        {
            get
            {
                return this.roleId;
            }
            set
            {
                this.roleId = value;
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

