namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GuildMemberInfo
    {
        private int freeChallengeCount;
        private long joinTime;
        private int latestContribution;
        private long offlineTime;
        private bool online;
        private int playerId;
        private int playerLevel;
        private string playerName;
        private int power;
        private int receiveBoxCount;
        private int roleId;
        private int totalContribution;
        private int vipLevel;

        public WeihuaGames.ClientClass.GuildMemberInfo FromProtobuf(com.kodgames.corgi.protocol.GuildMemberInfo guildMemberInfo)
        {
            if (guildMemberInfo != null)
            {
                this.playerId = guildMemberInfo.playerId;
                this.playerName = guildMemberInfo.playerName;
                this.playerLevel = guildMemberInfo.playerLevel;
                this.latestContribution = guildMemberInfo.latestContribution;
                this.totalContribution = guildMemberInfo.totalContribution;
                this.online = guildMemberInfo.online;
                this.offlineTime = guildMemberInfo.offlineTime;
                this.roleId = guildMemberInfo.roleId;
                this.vipLevel = guildMemberInfo.vipLevel;
                this.joinTime = guildMemberInfo.joinTime;
                this.freeChallengeCount = guildMemberInfo.freeChallengeCount;
                this.receiveBoxCount = guildMemberInfo.receiveBoxCount;
                this.power = guildMemberInfo.power;
            }
            return this;
        }

        public int FreeChallengeCount
        {
            get
            {
                return this.freeChallengeCount;
            }
            set
            {
                this.freeChallengeCount = value;
            }
        }

        public long JoinTime
        {
            get
            {
                return this.joinTime;
            }
            set
            {
                this.joinTime = value;
            }
        }

        public int LatestContribution
        {
            get
            {
                return this.latestContribution;
            }
            set
            {
                this.latestContribution = value;
            }
        }

        public long OfflineTime
        {
            get
            {
                return this.offlineTime;
            }
            set
            {
                this.offlineTime = value;
            }
        }

        public bool Online
        {
            get
            {
                return this.online;
            }
            set
            {
                this.online = value;
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

        public int ReceiveBoxCount
        {
            get
            {
                return this.receiveBoxCount;
            }
            set
            {
                this.receiveBoxCount = value;
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

        public int TotalContribution
        {
            get
            {
                return this.totalContribution;
            }
            set
            {
                this.totalContribution = value;
            }
        }

        public int VipLevel
        {
            get
            {
                return this.vipLevel;
            }
            set
            {
                this.vipLevel = value;
            }
        }
    }
}

