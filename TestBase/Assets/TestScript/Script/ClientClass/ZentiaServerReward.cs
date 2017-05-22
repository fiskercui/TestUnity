namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class ZentiaServerReward
    {
        private bool isActived;
        private bool isRewardGet;
        private WeihuaGames.ClientClass.Reward reward = new WeihuaGames.ClientClass.Reward();
        private int rewardLevelId;
        private long serverZentiaPoint;
        private int totalZentiaPoint;

        public WeihuaGames.ClientClass.ZentiaServerReward FromProtobuf(com.kodgames.corgi.protocol.ZentiaServerReward zentiaServerReward)
        {
            if (zentiaServerReward != null)
            {
                this.rewardLevelId = zentiaServerReward.rewardLevelId;
                this.serverZentiaPoint = zentiaServerReward.serverZentiaPoint;
                this.totalZentiaPoint = zentiaServerReward.totalZentiaPoint;
                this.isActived = zentiaServerReward.isActived;
                this.isRewardGet = zentiaServerReward.isRewardGet;
                if (zentiaServerReward.reward != null)
                {
                    WeihuaGames.ClientClass.Reward reward = new WeihuaGames.ClientClass.Reward();
                    reward.FromProtobuf(zentiaServerReward.reward);
                    this.reward = reward;
                }
            }
            return this;
        }

        public bool IsActived
        {
            get
            {
                return this.isActived;
            }
            set
            {
                this.isActived = value;
            }
        }

        public bool IsRewardGet
        {
            get
            {
                return this.isRewardGet;
            }
            set
            {
                this.isRewardGet = value;
            }
        }

        public WeihuaGames.ClientClass.Reward Reward
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

        public int RewardLevelId
        {
            get
            {
                return this.rewardLevelId;
            }
            set
            {
                this.rewardLevelId = value;
            }
        }

        public long ServerZentiaPoint
        {
            get
            {
                return this.serverZentiaPoint;
            }
            set
            {
                this.serverZentiaPoint = value;
            }
        }

        public int TotalZentiaPoint
        {
            get
            {
                return this.totalZentiaPoint;
            }
            set
            {
                this.totalZentiaPoint = value;
            }
        }
    }
}

