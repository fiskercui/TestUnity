namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GuildTransferMember
    {
        private long joinTime;
        private int playerId;
        private int playerLevel;
        private string playerName;
        private int roleId;
        private int totalContribution;

        public WeihuaGames.ClientClass.GuildTransferMember FromProtobuf(com.kodgames.corgi.protocol.GuildTransferMember guildTransferMember)
        {
            if (guildTransferMember != null)
            {
                this.playerId = guildTransferMember.playerId;
                this.playerName = guildTransferMember.playerName;
                this.roleId = guildTransferMember.roleId;
                this.playerLevel = guildTransferMember.playerLevel;
                this.totalContribution = guildTransferMember.totalContribution;
                this.joinTime = guildTransferMember.joinTime;
            }
            return this;
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
    }
}

