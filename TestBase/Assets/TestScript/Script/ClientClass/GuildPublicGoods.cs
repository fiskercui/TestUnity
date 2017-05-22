namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GuildPublicGoods
    {
        private int buyCount;
        private int gooodsId;
        private int showIndex;

        public WeihuaGames.ClientClass.GuildPublicGoods FromProtobuf(com.kodgames.corgi.protocol.GuildPublicGoods guildPublicGoods)
        {
            if (guildPublicGoods != null)
            {
                this.gooodsId = guildPublicGoods.gooodsId;
                this.buyCount = guildPublicGoods.buyCount;
                this.showIndex = guildPublicGoods.showIndex;
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

        public int GooodsId
        {
            get
            {
                return this.gooodsId;
            }
            set
            {
                this.gooodsId = value;
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

