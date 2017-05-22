namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class GuildTaskInfo
    {
        private int completedTaskCount;
        private WeihuaGames.ClientClass.Cost diceCost;
        private int doingTaskProgress;
        private WeihuaGames.ClientClass.RewardView extRewardView;
        private int freeDiceCount;
        private int freeRefreshCountPerDay;
        private List<int> lastDiceResults;
        private int maxCompletedTaskPerDay;
        private int maxFreeDiceCountPerDay;
        private long nextRefreshTime;
        private WeihuaGames.ClientClass.Cost refreshCost;
        private int refreshCount;
        private List<WeihuaGames.ClientClass.RewardView> rewardViews = new List<WeihuaGames.ClientClass.RewardView>();
        private string taskDesc;
        private string taskExtRewardDesc;
        private int taskIconId;
        private int taskId;
        private string taskName;
        private string taskParamList;
        private int taskQuality;
        private int taskType;
        private int total;

        public WeihuaGames.ClientClass.GuildTaskInfo FromProtobuf(com.kodgames.corgi.protocol.GuildTaskInfo guildTaskInfo)
        {
            if (guildTaskInfo != null)
            {
                this.taskId = guildTaskInfo.taskId;
                this.taskName = guildTaskInfo.taskName;
                this.taskIconId = guildTaskInfo.taskIconId;
                this.taskDesc = guildTaskInfo.taskDesc;
                this.taskQuality = guildTaskInfo.taskQuality;
                this.taskType = guildTaskInfo.taskType;
                this.total = guildTaskInfo.total;
                this.taskParamList = guildTaskInfo.taskParamList;
                if (guildTaskInfo.rewardViews != null)
                {
                    List<WeihuaGames.ClientClass.RewardView> list = new List<WeihuaGames.ClientClass.RewardView>();
                    foreach (com.kodgames.corgi.protocol.RewardView view in guildTaskInfo.rewardViews)
                    {
                        list.Add(new WeihuaGames.ClientClass.RewardView().FromProtobuf(view));
                    }
                    this.rewardViews = list;
                }
                this.taskExtRewardDesc = guildTaskInfo.taskExtRewardDesc;
                if (guildTaskInfo.extRewardView != null)
                {
                    WeihuaGames.ClientClass.RewardView view2 = new WeihuaGames.ClientClass.RewardView();
                    view2.FromProtobuf(guildTaskInfo.extRewardView);
                    this.extRewardView = view2;
                }
                this.maxCompletedTaskPerDay = guildTaskInfo.maxCompletedTaskPerDay;
                this.maxFreeDiceCountPerDay = guildTaskInfo.maxFreeDiceCountPerDay;
                this.freeRefreshCountPerDay = guildTaskInfo.freeRefreshCountPerDay;
                this.freeDiceCount = guildTaskInfo.freeDiceCount;
                this.refreshCount = guildTaskInfo.refreshCount;
                this.completedTaskCount = guildTaskInfo.completedTaskCount;
                this.doingTaskProgress = guildTaskInfo.doingTaskProgress;
                if (guildTaskInfo.refreshCost != null)
                {
                    WeihuaGames.ClientClass.Cost cost = new WeihuaGames.ClientClass.Cost();
                    cost.FromProtobuf(guildTaskInfo.refreshCost);
                    this.refreshCost = cost;
                }
                if (guildTaskInfo.diceCost != null)
                {
                    WeihuaGames.ClientClass.Cost cost2 = new WeihuaGames.ClientClass.Cost();
                    cost2.FromProtobuf(guildTaskInfo.diceCost);
                    this.diceCost = cost2;
                }
                this.lastDiceResults = guildTaskInfo.lastDiceResults;
                this.nextRefreshTime = guildTaskInfo.nextRefreshTime;
            }
            return this;
        }

        public int CompletedTaskCount
        {
            get
            {
                return this.completedTaskCount;
            }
            set
            {
                this.completedTaskCount = value;
            }
        }

        public WeihuaGames.ClientClass.Cost DiceCost
        {
            get
            {
                return this.diceCost;
            }
            set
            {
                this.diceCost = value;
            }
        }

        public int DoingTaskProgress
        {
            get
            {
                return this.doingTaskProgress;
            }
            set
            {
                this.doingTaskProgress = value;
            }
        }

        public WeihuaGames.ClientClass.RewardView ExtRewardView
        {
            get
            {
                return this.extRewardView;
            }
            set
            {
                this.extRewardView = value;
            }
        }

        public int FreeDiceCount
        {
            get
            {
                return this.freeDiceCount;
            }
            set
            {
                this.freeDiceCount = value;
            }
        }

        public int FreeRefreshCountPerDay
        {
            get
            {
                return this.freeRefreshCountPerDay;
            }
            set
            {
                this.freeRefreshCountPerDay = value;
            }
        }

        public List<int> LastDiceResults
        {
            get
            {
                return this.lastDiceResults;
            }
            set
            {
                this.lastDiceResults = value;
            }
        }

        public int MaxCompletedTaskPerDay
        {
            get
            {
                return this.maxCompletedTaskPerDay;
            }
            set
            {
                this.maxCompletedTaskPerDay = value;
            }
        }

        public int MaxFreeDiceCountPerDay
        {
            get
            {
                return this.maxFreeDiceCountPerDay;
            }
            set
            {
                this.maxFreeDiceCountPerDay = value;
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

        public WeihuaGames.ClientClass.Cost RefreshCost
        {
            get
            {
                return this.refreshCost;
            }
            set
            {
                this.refreshCost = value;
            }
        }

        public int RefreshCount
        {
            get
            {
                return this.refreshCount;
            }
            set
            {
                this.refreshCount = value;
            }
        }

        public List<WeihuaGames.ClientClass.RewardView> RewardViews
        {
            get
            {
                return this.rewardViews;
            }
            set
            {
                this.rewardViews = value;
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

        public string TaskExtRewardDesc
        {
            get
            {
                return this.taskExtRewardDesc;
            }
            set
            {
                this.taskExtRewardDesc = value;
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

        public string TaskParamList
        {
            get
            {
                return this.taskParamList;
            }
            set
            {
                this.taskParamList = value;
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

        public int TaskType
        {
            get
            {
                return this.taskType;
            }
            set
            {
                this.taskType = value;
            }
        }

        public int Total
        {
            get
            {
                return this.total;
            }
            set
            {
                this.total = value;
            }
        }
    }
}

