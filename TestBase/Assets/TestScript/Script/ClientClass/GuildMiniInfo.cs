namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class GuildMiniInfo
    {
        private bool guildAllowAutoEnter;
        private string guildAnnouncement;
        private int guildConstruct;
        private long guildConstructTime;
        private long guildCreateTime;
        private string guildDeclaration;
        private int guildId;
        private List<WeihuaGames.ClientClass.GuildInvisibleTaskInfo> guildInvisibleTaskInfos = new List<WeihuaGames.ClientClass.GuildInvisibleTaskInfo>();
        private int guildLeaderPlayerId;
        private int guildLevel;
        private int guildMsgCount;
        private int guildMsgDay;
        private string guildName;
        private int guildRank;
        private int latestContribution;
        private string leaderName;
        private int memberCount;
        private int msgLeft;
        private int newsLeft;
        private long publicShopNextRefreshTime;
        private int roleId;
        private int totalContribution;

        public WeihuaGames.ClientClass.GuildMiniInfo FromProtobuf(com.kodgames.corgi.protocol.GuildMiniInfo guildMiniInfo)
        {
            if (guildMiniInfo != null)
            {
                this.guildId = guildMiniInfo.guildId;
                this.guildLeaderPlayerId = guildMiniInfo.guildLeaderPlayerId;
                this.guildName = guildMiniInfo.guildName;
                this.guildLevel = guildMiniInfo.guildLevel;
                this.guildCreateTime = guildMiniInfo.guildCreateTime;
                this.guildAnnouncement = guildMiniInfo.guildAnnouncement;
                this.guildDeclaration = guildMiniInfo.guildDeclaration;
                this.guildConstruct = guildMiniInfo.guildConstruct;
                this.guildConstructTime = guildMiniInfo.guildConstructTime;
                this.guildAllowAutoEnter = guildMiniInfo.guildAllowAutoEnter;
                this.roleId = guildMiniInfo.roleId;
                this.totalContribution = guildMiniInfo.totalContribution;
                this.latestContribution = guildMiniInfo.latestContribution;
                this.guildMsgDay = guildMiniInfo.guildMsgDay;
                this.guildMsgCount = guildMiniInfo.guildMsgCount;
                this.msgLeft = guildMiniInfo.msgLeft;
                this.newsLeft = guildMiniInfo.newsLeft;
                this.leaderName = guildMiniInfo.leaderName;
                this.guildRank = guildMiniInfo.guildRank;
                this.memberCount = guildMiniInfo.memberCount;
                if (guildMiniInfo.guildInvisibleTaskInfos != null)
                {
                    List<WeihuaGames.ClientClass.GuildInvisibleTaskInfo> list = new List<WeihuaGames.ClientClass.GuildInvisibleTaskInfo>();
                    foreach (com.kodgames.corgi.protocol.GuildInvisibleTaskInfo info in guildMiniInfo.guildInvisibleTaskInfos)
                    {
                        list.Add(new WeihuaGames.ClientClass.GuildInvisibleTaskInfo().FromProtobuf(info));
                    }
                    this.guildInvisibleTaskInfos = list;
                }
                this.publicShopNextRefreshTime = guildMiniInfo.publicShopNextRefreshTime;
            }
            return this;
        }

        public bool GuildAllowAutoEnter
        {
            get
            {
                return this.guildAllowAutoEnter;
            }
            set
            {
                this.guildAllowAutoEnter = value;
            }
        }

        public string GuildAnnouncement
        {
            get
            {
                return this.guildAnnouncement;
            }
            set
            {
                this.guildAnnouncement = value;
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

        public long GuildCreateTime
        {
            get
            {
                return this.guildCreateTime;
            }
            set
            {
                this.guildCreateTime = value;
            }
        }

        public string GuildDeclaration
        {
            get
            {
                return this.guildDeclaration;
            }
            set
            {
                this.guildDeclaration = value;
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

        public List<WeihuaGames.ClientClass.GuildInvisibleTaskInfo> GuildInvisibleTaskInfos
        {
            get
            {
                return this.guildInvisibleTaskInfos;
            }
            set
            {
                this.guildInvisibleTaskInfos = value;
            }
        }

        public int GuildLeaderPlayerId
        {
            get
            {
                return this.guildLeaderPlayerId;
            }
            set
            {
                this.guildLeaderPlayerId = value;
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

        public int GuildMsgCount
        {
            get
            {
                return this.guildMsgCount;
            }
            set
            {
                this.guildMsgCount = value;
            }
        }

        public int GuildMsgDay
        {
            get
            {
                return this.guildMsgDay;
            }
            set
            {
                this.guildMsgDay = value;
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

        public int GuildRank
        {
            get
            {
                return this.guildRank;
            }
            set
            {
                this.guildRank = value;
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

        public string LeaderName
        {
            get
            {
                return this.leaderName;
            }
            set
            {
                this.leaderName = value;
            }
        }

        public int MemberCount
        {
            get
            {
                return this.memberCount;
            }
            set
            {
                this.memberCount = value;
            }
        }

        public int MsgLeft
        {
            get
            {
                return this.msgLeft;
            }
            set
            {
                this.msgLeft = value;
            }
        }

        public int NewsLeft
        {
            get
            {
                return this.newsLeft;
            }
            set
            {
                this.newsLeft = value;
            }
        }

        public long PublicShopNextRefreshTime
        {
            get
            {
                return this.publicShopNextRefreshTime;
            }
            set
            {
                this.publicShopNextRefreshTime = value;
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

