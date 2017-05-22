namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GuildPrivateGoods
    {
        private int buyCount;
        private int gooodsId;
        private string limitDesc;
        private long nextRefreshTime;
        private int showIndex;

        public WeihuaGames.ClientClass.GuildPrivateGoods FromProtobuf(com.kodgames.corgi.protocol.GuildPrivateGoods guildPrivateGoods)
        {
            if (guildPrivateGoods != null)
            {
                this.gooodsId = guildPrivateGoods.gooodsId;
                this.buyCount = guildPrivateGoods.buyCount;
                this.nextRefreshTime = guildPrivateGoods.nextRefreshTime;
                this.showIndex = guildPrivateGoods.showIndex;
                this.limitDesc = guildPrivateGoods.limitDesc;
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

        public string LimitDesc
        {
            get
            {
                return this.limitDesc;
            }
            set
            {
                this.limitDesc = value;
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

