namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GuildRankRecord
    {
        private int currentGuildMemberCount;
        private int guildConstruct;
        private long guildConstructTime;
        private int guildId;
        private int guildLevel;
        private int guildMemberMax;
        private string guildName;
        private string leaderPlayerName;
        private int rank;

        public WeihuaGames.ClientClass.GuildRankRecord FromProtobuf(com.kodgames.corgi.protocol.GuildRankRecord guildRankRecord)
        {
            if (guildRankRecord != null)
            {
                this.rank = guildRankRecord.rank;
                this.guildId = guildRankRecord.guildId;
                this.guildName = guildRankRecord.guildName;
                this.guildLevel = guildRankRecord.guildLevel;
                this.currentGuildMemberCount = guildRankRecord.currentGuildMemberCount;
                this.guildMemberMax = guildRankRecord.guildMemberMax;
                this.leaderPlayerName = guildRankRecord.leaderPlayerName;
                this.guildConstruct = guildRankRecord.guildConstruct;
                this.guildConstructTime = guildRankRecord.guildConstructTime;
            }
            return this;
        }

        public int CurrentGuildMemberCount
        {
            get
            {
                return this.currentGuildMemberCount;
            }
            set
            {
                this.currentGuildMemberCount = value;
            }
        }

        public int GuildConstruct
        {
            get
            {
                return this.guildConstruct;
            }
            set
            {
                this.guildConstruct = value;
            }
        }

        public long GuildConstructTime
        {
            get
            {
                return this.guildConstructTime;
            }
            set
            {
                this.guildConstructTime = value;
            }
        }

        public int GuildId
        {
            get
            {
                return this.guildId;
            }
            set
            {
                this.guildId = value;
            }
        }

        public int GuildLevel
        {
            get
            {
                return this.guildLevel;
            }
            set
            {
                this.guildLevel = value;
            }
        }

        public int GuildMemberMax
        {
            get
            {
                return this.guildMemberMax;
            }
            set
            {
                this.guildMemberMax = value;
            }
        }

        public string GuildName
        {
            get
            {
                return this.guildName;
            }
            set
            {
                this.guildName = value;
            }
        }

        public string LeaderPlayerName
        {
            get
            {
                return this.leaderPlayerName;
            }
            set
            {
                this.leaderPlayerName = value;
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
    }
}

