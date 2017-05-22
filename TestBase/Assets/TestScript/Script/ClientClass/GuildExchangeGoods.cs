namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class GuildExchangeGoods
    {
        private int buyCount;
        private int buyCountLimitPerActive;
        private string conditionDesc;
        private List<WeihuaGames.ClientClass.CostAsset> costAssets = new List<WeihuaGames.ClientClass.CostAsset>();
        private List<WeihuaGames.ClientClass.ItemEx> costs = new List<WeihuaGames.ClientClass.ItemEx>();
        private long endTime;
        private int existTimeMs;
        private int goodsId;
        private bool isActive;
        private WeihuaGames.ClientClass.RewardView rewardView;
        private int showIndex;

        public WeihuaGames.ClientClass.GuildExchangeGoods FromProtobuf(com.kodgames.corgi.protocol.GuildExchangeGoods guildExchangeGoods)
        {
            if (guildExchangeGoods != null)
            {
                this.goodsId = guildExchangeGoods.goodsId;
                this.showIndex = guildExchangeGoods.showIndex;
                this.existTimeMs = guildExchangeGoods.existTimeMs;
                this.buyCountLimitPerActive = guildExchangeGoods.buyCountLimitPerActive;
                if (guildExchangeGoods.costAssets != null)
                {
                    List<WeihuaGames.ClientClass.CostAsset> list = new List<WeihuaGames.ClientClass.CostAsset>();
                    foreach (com.kodgames.corgi.protocol.CostAsset asset in guildExchangeGoods.costAssets)
                    {
                        list.Add(new WeihuaGames.ClientClass.CostAsset().FromProtobuf(asset));
                    }
                    this.costAssets = list;
                }
                if (guildExchangeGoods.costs != null)
                {
                    List<WeihuaGames.ClientClass.ItemEx> list2 = new List<WeihuaGames.ClientClass.ItemEx>();
                    foreach (com.kodgames.corgi.protocol.ItemEx ex in guildExchangeGoods.costs)
                    {
                        list2.Add(new WeihuaGames.ClientClass.ItemEx().FromProtobuf(ex));
                    }
                    this.costs = list2;
                }
                if (guildExchangeGoods.rewardView != null)
                {
                    WeihuaGames.ClientClass.RewardView view = new WeihuaGames.ClientClass.RewardView();
                    view.FromProtobuf(guildExchangeGoods.rewardView);
                    this.rewardView = view;
                }
                this.isActive = guildExchangeGoods.isActive;
                this.buyCount = guildExchangeGoods.buyCount;
                this.endTime = guildExchangeGoods.endTime;
                this.conditionDesc = guildExchangeGoods.conditionDesc;
            }
            return this;
        }

        public int BuyCount
        {
            get
            {
                return this.buyCount;
            }
            set
            {
                this.buyCount = value;
            }
        }

        public int BuyCountLimitPerActive
        {
            get
            {
                return this.buyCountLimitPerActive;
            }
            set
            {
                this.buyCountLimitPerActive = value;
            }
        }

        public string ConditionDesc
        {
            get
            {
                return this.conditionDesc;
            }
            set
            {
                this.conditionDesc = value;
            }
        }

        public List<WeihuaGames.ClientClass.CostAsset> CostAssets
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

        public List<WeihuaGames.ClientClass.ItemEx> Costs
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

        public long EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
            }
        }

        public int ExistTimeMs
        {
            get
            {
                return this.existTimeMs;
            }
            set
            {
                this.existTimeMs = value;
            }
        }

        public int GoodsId
        {
            get
            {
                return this.goodsId;
            }
            set
            {
                this.goodsId = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return this.isActive;
            }
            set
            {
                this.isActive = value;
            }
        }

        public WeihuaGames.ClientClass.RewardView RewardView
        {
            get
            {
                return this.rewardView;
            }
            set
            {
                this.rewardView = value;
            }
        }

        public int ShowIndex
        {
            get
            {
                return this.showIndex;
            }
            set
            {
                this.showIndex = value;
            }
        }
    }
}

