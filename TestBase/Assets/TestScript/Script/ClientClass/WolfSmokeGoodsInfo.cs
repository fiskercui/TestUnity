namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class WolfSmokeGoodsInfo
    {
        private bool alreadyBuy;
        private WeihuaGames.ClientClass.Cost cost = new WeihuaGames.ClientClass.Cost();
        private WeihuaGames.ClientClass.Cost discountCost = new WeihuaGames.ClientClass.Cost();
        private int goodsId;
        private int goodsIndex;
        private WeihuaGames.ClientClass.Consumable reward = new WeihuaGames.ClientClass.Consumable();

        public WeihuaGames.ClientClass.WolfSmokeGoodsInfo FromProtobuf(com.kodgames.corgi.protocol.WolfSmokeGoodsInfo wolfSmokeGoodsInfo)
        {
            if (wolfSmokeGoodsInfo != null)
            {
                this.goodsId = wolfSmokeGoodsInfo.goodsId;
                this.alreadyBuy = wolfSmokeGoodsInfo.alreadyBuy;
                if (wolfSmokeGoodsInfo.reward != null)
                {
                    WeihuaGames.ClientClass.Consumable consumable = new WeihuaGames.ClientClass.Consumable();
                    consumable.FromProtobuf(wolfSmokeGoodsInfo.reward);
                    this.reward = consumable;
                }
                if (wolfSmokeGoodsInfo.cost != null)
                {
                    WeihuaGames.ClientClass.Cost cost = new WeihuaGames.ClientClass.Cost();
                    cost.FromProtobuf(wolfSmokeGoodsInfo.cost);
                    this.cost = cost;
                }
                if (wolfSmokeGoodsInfo.discountCost != null)
                {
                    WeihuaGames.ClientClass.Cost cost2 = new WeihuaGames.ClientClass.Cost();
                    cost2.FromProtobuf(wolfSmokeGoodsInfo.discountCost);
                    this.discountCost = cost2;
                }
                this.goodsIndex = wolfSmokeGoodsInfo.goodsIndex;
            }
            return this;
        }

        public bool AlreadyBuy
        {
            get
            {
                return this.alreadyBuy;
            }
            set
            {
                this.alreadyBuy = value;
            }
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

        public WeihuaGames.ClientClass.Cost DiscountCost
        {
            get
            {
                return this.discountCost;
            }
            set
            {
                this.discountCost = value;
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

        public int GoodsIndex
        {
            get
            {
                return this.goodsIndex;
            }
            set
            {
                this.goodsIndex = value;
            }
        }

        public WeihuaGames.ClientClass.Consumable Reward
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

