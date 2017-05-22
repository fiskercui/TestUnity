namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class CostAndRewardAndSync
    {
        private List<WeihuaGames.ClientClass.Cost> costs;
        private WeihuaGames.ClientClass.Cost notEnoughCost;
        private WeihuaGames.ClientClass.Reward reward;
        private WeihuaGames.ClientClass.Reward viewFixReward;
        private WeihuaGames.ClientClass.Reward viewRandomReward;

        public WeihuaGames.ClientClass.CostAndRewardAndSync FromProtoBuf(com.kodgames.corgi.protocol.CostAndRewardAndSync proto)
        {
            if (proto != null)
            {
                if (proto.costs != null)
                {
                    this.costs = new List<WeihuaGames.ClientClass.Cost>();
                    foreach (com.kodgames.corgi.protocol.Cost cost in proto.costs)
                    {
                        if (cost != null)
                        {
                            WeihuaGames.ClientClass.Cost item = new WeihuaGames.ClientClass.Cost();
                            item.FromProtobuf(cost);
                            this.costs.Add(item);
                        }
                    }
                }
                if (proto.reward != null)
                {
                    this.reward = new WeihuaGames.ClientClass.Reward();
                    this.reward.FromProtobuf(proto.reward);
                }
                if (proto.notEnoughCost != null)
                {
                    this.notEnoughCost = new WeihuaGames.ClientClass.Cost();
                    this.notEnoughCost.FromProtobuf(proto.notEnoughCost);
                }
                if (proto.viewFixReward != null)
                {
                    this.viewFixReward = new WeihuaGames.ClientClass.Reward();
                    this.viewFixReward.FromProtobuf(proto.viewFixReward);
                }
                if (proto.viewRandomreward != null)
                {
                    this.viewRandomReward = new WeihuaGames.ClientClass.Reward();
                    this.viewRandomReward.FromProtobuf(proto.viewRandomreward);
                }
            }
            return this;
        }

        public List<WeihuaGames.ClientClass.Cost> Costs
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

        public WeihuaGames.ClientClass.Cost NotEnoughCost
        {
            get
            {
                return this.notEnoughCost;
            }
            set
            {
                this.notEnoughCost = value;
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

        public WeihuaGames.ClientClass.Reward ViewFixReward
        {
            get
            {
                return this.viewFixReward;
            }
            set
            {
                this.viewFixReward = value;
            }
        }

        public WeihuaGames.ClientClass.Reward ViewRandomReward
        {
            get
            {
                return this.viewRandomReward;
            }
            set
            {
                this.viewRandomReward = value;
            }
        }
    }
}

