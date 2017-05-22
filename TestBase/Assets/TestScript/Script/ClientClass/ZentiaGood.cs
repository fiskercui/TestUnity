namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class ZentiaGood
    {
        private WeihuaGames.ClientClass.Cost cost = new WeihuaGames.ClientClass.Cost();
        private int exchangeGoodId;
        private WeihuaGames.ClientClass.Reward reward = new WeihuaGames.ClientClass.Reward();

        public WeihuaGames.ClientClass.ZentiaGood FromProtobuf(com.kodgames.corgi.protocol.ZentiaGood zentiaGood)
        {
            if (zentiaGood != null)
            {
                this.exchangeGoodId = zentiaGood.exchangeGoodId;
                if (zentiaGood.reward != null)
                {
                    WeihuaGames.ClientClass.Reward reward = new WeihuaGames.ClientClass.Reward();
                    reward.FromProtobuf(zentiaGood.reward);
                    this.reward = reward;
                }
                if (zentiaGood.cost != null)
                {
                    WeihuaGames.ClientClass.Cost cost = new WeihuaGames.ClientClass.Cost();
                    cost.FromProtobuf(zentiaGood.cost);
                    this.cost = cost;
                }
            }
            return this;
        }

        public WeihuaGames.ClientClass.Cost Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                this.cost = value;
            }
        }

        public int ExchangeGoodId
        {
            get
            {
                return this.exchangeGoodId;
            }
            set
            {
                this.exchangeGoodId = value;
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
    }
}

