namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class MysteryShopInfo
    {
        private List<WeihuaGames.ClientClass.MysteryGoodInfo> goods = new List<WeihuaGames.ClientClass.MysteryGoodInfo>();
        private long lastRefreshTime;
        private long lastResetTime;
        private long nextRefreshTime;
        private int playerRefreshTimes;
        private int shopType;

        public WeihuaGames.ClientClass.MysteryShopInfo FromProtoBuf(com.kodgames.corgi.protocol.MysteryShopInfo protoInfo)
        {
            if (protoInfo == null)
            {
                return null;
            }
            this.nextRefreshTime = protoInfo.nextRefreshTime;
            this.playerRefreshTimes = protoInfo.playerRefreshTimes;
            this.lastRefreshTime = protoInfo.lastRefreshTime;
            this.lastResetTime = protoInfo.lastResetTime;
            if (protoInfo.goods != null)
            {
                this.goods.Clear();
                foreach (com.kodgames.corgi.protocol.MysteryGoodInfo info in protoInfo.goods)
                {
                    WeihuaGames.ClientClass.MysteryGoodInfo item = new WeihuaGames.ClientClass.MysteryGoodInfo().FromProtoBuf(info);
                    if (item != null)
                    {
                        this.goods.Add(item);
                    }
                }
            }
            return this;
        }

        public List<WeihuaGames.ClientClass.MysteryGoodInfo> Goods
        {
            get
            {
                return this.goods;
            }
            set
            {
                this.goods = value;
            }
        }

        public long LastRefreshTime
        {
            get
            {
                return this.lastRefreshTime;
            }
            set
            {
                this.lastRefreshTime = value;
            }
        }

        public long LastResetTime
        {
            get
            {
                return this.lastResetTime;
            }
            set
            {
                this.lastResetTime = value;
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

        public int PlayerRefreshTimes
        {
            get
            {
                return this.playerRefreshTimes;
            }
            set
            {
                this.playerRefreshTimes = value;
            }
        }

        public int ShopType
        {
            get
            {
                return this.shopType;
            }
            set
            {
                this.shopType = value;
            }
        }
    }
}

