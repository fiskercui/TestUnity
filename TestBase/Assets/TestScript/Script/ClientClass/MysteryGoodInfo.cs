namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class MysteryGoodInfo
    {
        private bool buyOrNot;
        private WeihuaGames.ClientClass.Consumable consume;
        private WeihuaGames.ClientClass.Cost cost;
        private WeihuaGames.ClientClass.Cost discountCost;
        private int goodId;
        private int goodIndex;

        public WeihuaGames.ClientClass.MysteryGoodInfo FromProtoBuf(com.kodgames.corgi.protocol.MysteryGoodInfo protoInfo)
        {
            if (protoInfo == null)
            {
                return null;
            }
            this.goodId = protoInfo.goodsId;
            this.goodIndex = protoInfo.goodsIndex;
            this.buyOrNot = protoInfo.buyOrNot;
            this.consume = new WeihuaGames.ClientClass.Consumable().FromProtobuf(protoInfo.reward);
            this.cost = new WeihuaGames.ClientClass.Cost().FromProtobuf(protoInfo.cost);
            if (protoInfo.discountCost != null)
            {
                this.discountCost = new WeihuaGames.ClientClass.Cost().FromProtobuf(protoInfo.discountCost);
            }
            return this;
        }

        public bool BuyOrNot
        {
            get
            {
                return this.buyOrNot;
            }
            set
            {
                this.buyOrNot = value;
            }
        }

        public WeihuaGames.ClientClass.Consumable Consume
        {
            get
            {
                return this.consume;
            }
            set
            {
                this.consume = value;
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

        public int GoodId
        {
            get
            {
                return this.goodId;
            }
            set
            {
                this.goodId = value;
            }
        }

        public int GoodIndex
        {
            get
            {
                return this.goodIndex;
            }
            set
            {
                this.goodIndex = value;
            }
        }
    }
}

