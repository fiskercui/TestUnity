namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GuildApplyInfo
    {
        private int playerId;
        private int playerLevel;
        private string playerName;
        private int power;
        private int rank;
        private long time;

        public WeihuaGames.ClientClass.GuildApplyInfo FromProtobuf(com.kodgames.corgi.protocol.GuildApplyInfo guildApplyInfo)
        {
            if (guildApplyInfo != null)
            {
                this.playerId = guildApplyInfo.playerId;
                this.playerName = guildApplyInfo.playerName;
                this.playerLevel = guildApplyInfo.playerLevel;
                this.rank = guildApplyInfo.rank;
                this.time = guildApplyInfo.time;
                this.power = guildApplyInfo.power;
            }
            return this;
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

        public int Power
        {
            get
            {
                return this.power;
            }
            set
            {
                this.power = value;
            }
        }

        public int Rank
        {
            get
            {
                return this.rank;
            }
            set
            {
                this.rank = value;
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

