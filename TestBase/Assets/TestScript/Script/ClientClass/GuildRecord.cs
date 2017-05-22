namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GuildRecord
    {
        private int activeValue;
        private string declaration;
        private int guildId;
        private int guildLevel;
        private int guildMemberMax;
        private int guildMemberNum;
        private string guildName;
        private string leaderPlayerName;
        private bool underApply;

        public WeihuaGames.ClientClass.GuildRecord FromProtobuf(com.kodgames.corgi.protocol.GuildRecord guildRecord)
        {
            if (guildRecord != null)
            {
                this.guildId = guildRecord.guildId;
                this.guildName = guildRecord.guildName;
                this.guildLevel = guildRecord.guildLevel;
                this.leaderPlayerName = guildRecord.leaderPlayerName;
                this.declaration = guildRecord.declaration;
                this.underApply = guildRecord.underApply;
                this.guildMemberNum = guildRecord.guildMemberNum;
                this.guildMemberMax = guildRecord.guildMemberMax;
                this.activeValue = guildRecord.activeValue;
            }
            return this;
        }

        public int ActiveValue
        {
            get
            {
                return this.activeValue;
            }
            set
            {
                this.activeValue = value;
            }
        }

        public string Declaration
        {
            get
            {
                return this.declaration;
            }
            set
            {
                this.declaration = value;
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

        public int GuildMemberNum
        {
            get
            {
                return this.guildMemberNum;
            }
            set
            {
                this.guildMemberNum = value;
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

        public bool UnderApply
        {
            get
            {
                return this.underApply;
            }
            set
            {
                this.underApply = value;
            }
        }
    }
}

