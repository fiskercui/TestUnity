namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class ZentiaExchange
    {
        private List<WeihuaGames.ClientClass.CostAsset> costAssets = new List<WeihuaGames.ClientClass.CostAsset>();
        private List<WeihuaGames.ClientClass.ItemEx> costs = new List<WeihuaGames.ClientClass.ItemEx>();
        private int exchangeId;
        private int iconId;
        private int index;
        private bool isAlreadyExchanged;
        private WeihuaGames.ClientClass.Reward reward = new WeihuaGames.ClientClass.Reward();
        private WeihuaGames.ClientClass.Reward zentiaReward = new WeihuaGames.ClientClass.Reward();

        public WeihuaGames.ClientClass.ZentiaExchange FromProtobuf(com.kodgames.corgi.protocol.ZentiaExchange zentiaExchange)
        {
            if (zentiaExchange != null)
            {
                this.exchangeId = zentiaExchange.exchangeId;
                this.index = zentiaExchange.index;
                this.iconId = zentiaExchange.iconId;
                this.isAlreadyExchanged = zentiaExchange.isAlreadyExchanged;
                if (zentiaExchange.costs != null)
                {
                    List<WeihuaGames.ClientClass.ItemEx> list = new List<WeihuaGames.ClientClass.ItemEx>();
                    foreach (com.kodgames.corgi.protocol.ItemEx ex in zentiaExchange.costs)
                    {
                        if (ex != null)
                        {
                            WeihuaGames.ClientClass.ItemEx item = new WeihuaGames.ClientClass.ItemEx();
                            item.FromProtobuf(ex);
                            list.Add(item);
                        }
                    }
                    this.costs = list;
                }
                if (zentiaExchange.costAssets != null)
                {
                    List<WeihuaGames.ClientClass.CostAsset> list2 = new List<WeihuaGames.ClientClass.CostAsset>();
                    foreach (com.kodgames.corgi.protocol.CostAsset asset in zentiaExchange.costAssets)
                    {
                        if (asset != null)
                        {
                            WeihuaGames.ClientClass.CostAsset asset2 = new WeihuaGames.ClientClass.CostAsset();
                            asset2.FromProtobuf(asset);
                            list2.Add(asset2);
                        }
                    }
                    this.costAssets = list2;
                }
                if (zentiaExchange.reward != null)
                {
                    WeihuaGames.ClientClass.Reward reward = new WeihuaGames.ClientClass.Reward();
                    reward.FromProtobuf(zentiaExchange.reward);
                    this.reward = reward;
                }
                if (zentiaExchange.zentiaReward != null)
                {
                    WeihuaGames.ClientClass.Reward reward2 = new WeihuaGames.ClientClass.Reward();
                    reward2.FromProtobuf(zentiaExchange.zentiaReward);
                    this.zentiaReward = reward2;
                }
            }
            return this;
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

        public int ExchangeId
        {
            get
            {
                return this.exchangeId;
            }
            set
            {
                this.exchangeId = value;
            }
        }

        public int IconId
        {
            get
            {
                return this.iconId;
            }
            set
            {
                this.iconId = value;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }

        public bool IsAlreadyExchanged
        {
            get
            {
                return this.isAlreadyExchanged;
            }
            set
            {
                this.isAlreadyExchanged = value;
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

        public WeihuaGames.ClientClass.Reward ZentiaReward
        {
            get
            {
                return this.zentiaReward;
            }
            set
            {
                this.zentiaReward = value;
            }
        }
    }
}

