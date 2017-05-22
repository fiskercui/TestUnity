namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class ConstructionTask
    {
        private string color;
        private WeihuaGames.ClientClass.CostAsset costAssets;
        private WeihuaGames.ClientClass.ItemEx costs;
        private int guildConstruct;
        private bool isDoing;
        private List<WeihuaGames.ClientClass.Cost> oneClickCompletedCosts = new List<WeihuaGames.ClientClass.Cost>();
        private int playerContribution;
        private List<WeihuaGames.ClientClass.RewardView> reward = new List<WeihuaGames.ClientClass.RewardView>();
        private string taskDesc;
        private int taskIconId;
        private int taskId;
        private int taskIndex;
        private string taskName;
        private int taskQuality;

        public WeihuaGames.ClientClass.ConstructionTask FromProtobuf(com.kodgames.corgi.protocol.ConstructionTask constructionTask)
        {
            if (constructionTask != null)
            {
                this.taskId = constructionTask.taskId;
                this.taskIndex = constructionTask.taskIndex;
                this.isDoing = constructionTask.isDoing;
                this.taskName = constructionTask.taskName;
                this.taskQuality = constructionTask.taskQuality;
                this.taskIconId = constructionTask.taskIconId;
                this.taskDesc = constructionTask.taskDesc;
                this.color = constructionTask.color;
                if (constructionTask.oneClickCompletedCosts != null)
                {
                    List<WeihuaGames.ClientClass.Cost> list = new List<WeihuaGames.ClientClass.Cost>();
                    foreach (com.kodgames.corgi.protocol.Cost cost in constructionTask.oneClickCompletedCosts)
                    {
                        list.Add(new WeihuaGames.ClientClass.Cost().FromProtobuf(cost));
                    }
                    this.oneClickCompletedCosts = list;
                }
                if (constructionTask.costs != null)
                {
                    WeihuaGames.ClientClass.ItemEx ex = new WeihuaGames.ClientClass.ItemEx();
                    ex.FromProtobuf(constructionTask.costs);
                    this.costs = ex;
                }
                if (constructionTask.costAssets != null)
                {
                    WeihuaGames.ClientClass.CostAsset asset = new WeihuaGames.ClientClass.CostAsset();
                    asset.FromProtobuf(constructionTask.costAssets);
                    this.costAssets = asset;
                }
                if (constructionTask.reward != null)
                {
                    List<WeihuaGames.ClientClass.RewardView> list2 = new List<WeihuaGames.ClientClass.RewardView>();
                    foreach (com.kodgames.corgi.protocol.RewardView view in constructionTask.reward)
                    {
                        list2.Add(new WeihuaGames.ClientClass.RewardView().FromProtobuf(view));
                    }
                    this.reward = list2;
                }
                this.guildConstruct = constructionTask.guildConstruct;
                this.playerContribution = constructionTask.playerContribution;
            }
            return this;
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public WeihuaGames.ClientClass.CostAsset CostAssets
        {
            get
            {
                return this.costAssets;
            }
            set
            {
                this.costAssets = value;
            }
        }

        public WeihuaGames.ClientClass.ItemEx Costs
        {
            get
            {
                return this.costs;
            }
            set
            {
                this.costs = value;
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

        public bool IsDoing
        {
            get
            {
                return this.isDoing;
            }
            set
            {
                this.isDoing = value;
            }
        }

        public List<WeihuaGames.ClientClass.Cost> OneClickCompletedCosts
        {
            get
            {
                return this.oneClickCompletedCosts;
            }
            set
            {
                this.oneClickCompletedCosts = value;
            }
        }

        public int PlayerContribution
        {
            get
            {
                return this.playerContribution;
            }
            set
            {
                this.playerContribution = value;
            }
        }

        public List<WeihuaGames.ClientClass.RewardView> Reward
        {
            get
            {
                return this.reward;
            }
            set
            {
                this.reward = value;
            }
        }

        public string TaskDesc
        {
            get
            {
                return this.taskDesc;
            }
            set
            {
                this.taskDesc = value;
            }
        }

        public int TaskIconId
        {
            get
            {
                return this.taskIconId;
            }
            set
            {
                this.taskIconId = value;
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

        public int TaskIndex
        {
            get
            {
                return this.taskIndex;
            }
            set
            {
                this.taskIndex = value;
            }
        }

        public string TaskName
        {
            get
            {
                return this.taskName;
            }
            set
            {
                this.taskName = value;
            }
        }

        public int TaskQuality
        {
            get
            {
                return this.taskQuality;
            }
            set
            {
                this.taskQuality = value;
            }
        }
    }
}

