namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class ConstructionInfo
    {
        private int contribution;
        private int guildAccomplishTaskCount;
        private int guildConstruction;
        private int guildLevel;
        private int guildMaxAccomplishPerDay;
        private int guildMoney;
        private int guildMoveCount;
        private long joinTime;
        private int lvUpConstruction;
        private long nextRefreshTime;
        private int playerAccomplishTaskCount;
        private int playerMaxAccomplishPerDay;
        private List<WeihuaGames.ClientClass.Cost> refershCosts = new List<WeihuaGames.ClientClass.Cost>();
        private List<WeihuaGames.ClientClass.ConstructionTask> tasks = new List<WeihuaGames.ClientClass.ConstructionTask>();
        private long waitTime;

        public WeihuaGames.ClientClass.ConstructionInfo FromProtobuf(com.kodgames.corgi.protocol.ConstructionInfo constructionInfo)
        {
            if (constructionInfo != null)
            {
                this.guildLevel = constructionInfo.guildLevel;
                this.guildConstruction = constructionInfo.guildConstruction;
                this.lvUpConstruction = constructionInfo.lvUpConstruction;
                this.guildMoney = constructionInfo.guildMoney;
                this.guildMoveCount = constructionInfo.guildMoveCount;
                this.contribution = constructionInfo.contribution;
                this.joinTime = constructionInfo.joinTime;
                if (constructionInfo.tasks != null)
                {
                    List<WeihuaGames.ClientClass.ConstructionTask> list = new List<WeihuaGames.ClientClass.ConstructionTask>();
                    foreach (com.kodgames.corgi.protocol.ConstructionTask task in constructionInfo.tasks)
                    {
                        list.Add(new WeihuaGames.ClientClass.ConstructionTask().FromProtobuf(task));
                    }
                    this.tasks = list;
                }
                this.playerAccomplishTaskCount = constructionInfo.playerAccomplishTaskCount;
                this.guildAccomplishTaskCount = constructionInfo.guildAccomplishTaskCount;
                this.nextRefreshTime = constructionInfo.nextRefreshTime;
                this.waitTime = constructionInfo.waitTime;
                this.playerMaxAccomplishPerDay = constructionInfo.playerMaxAccomplishPerDay;
                this.guildMaxAccomplishPerDay = constructionInfo.guildMaxAccomplishPerDay;
                if (constructionInfo.refershCosts != null)
                {
                    List<WeihuaGames.ClientClass.Cost> list2 = new List<WeihuaGames.ClientClass.Cost>();
                    foreach (com.kodgames.corgi.protocol.Cost cost in constructionInfo.refershCosts)
                    {
                        list2.Add(new WeihuaGames.ClientClass.Cost().FromProtobuf(cost));
                    }
                    this.refershCosts = list2;
                }
            }
            return this;
        }

        public int Contribution
        {
            get
            {
                return this.contribution;
            }
            set
            {
                this.contribution = value;
            }
        }

        public int GuildAccomplishTaskCount
        {
            get
            {
                return this.guildAccomplishTaskCount;
            }
            set
            {
                this.guildAccomplishTaskCount = value;
            }
        }

        public int GuildConstruction
        {
            get
            {
                return this.guildConstruction;
            }
            set
            {
                this.guildConstruction = value;
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

        public int GuildMaxAccomplishPerDay
        {
            get
            {
                return this.guildMaxAccomplishPerDay;
            }
            set
            {
                this.guildMaxAccomplishPerDay = value;
            }
        }

        public int GuildMoney
        {
            get
            {
                return this.guildMoney;
            }
            set
            {
                this.guildMoney = value;
            }
        }

        public int GuildMoveCount
        {
            get
            {
                return this.guildMoveCount;
            }
            set
            {
                this.guildMoveCount = value;
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

        public int LvUpConstruction
        {
            get
            {
                return this.lvUpConstruction;
            }
            set
            {
                this.lvUpConstruction = value;
            }
        }

        public long NextRefreshTime
        {
            get
            {
                return this.nextRefreshTime;
            }
            set
            {
                this.nextRefreshTime = value;
            }
        }

        public int PlayerAccomplishTaskCount
        {
            get
            {
                return this.playerAccomplishTaskCount;
            }
            set
            {
                this.playerAccomplishTaskCount = value;
            }
        }

        public int PlayerMaxAccomplishPerDay
        {
            get
            {
                return this.playerMaxAccomplishPerDay;
            }
            set
            {
                this.playerMaxAccomplishPerDay = value;
            }
        }

        public List<WeihuaGames.ClientClass.Cost> RefershCosts
        {
            get
            {
                return this.refershCosts;
            }
            set
            {
                this.refershCosts = value;
            }
        }

        public List<WeihuaGames.ClientClass.ConstructionTask> Tasks
        {
            get
            {
                return this.tasks;
            }
            set
            {
                this.tasks = value;
            }
        }

        public long WaitTime
        {
            get
            {
                return this.waitTime;
            }
            set
            {
                this.waitTime = value;
            }
        }
    }
}

