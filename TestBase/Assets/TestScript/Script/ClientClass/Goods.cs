namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class Goods
    {
        private int discount;
        private long earlyShowTime;
        private long endTime;
        private int goodsID;
        private int maxBuyCount;
        private List<WeihuaGames.ClientClass.GoodsSpecialLimit> melaleucaLimits = new List<WeihuaGames.ClientClass.GoodsSpecialLimit>();
        private long nextOpenTime;
        private long openTime;
        private int playerLevel;
        private int remainBuyCount;
        private int showPlayerLevel;
        private int showVipLevel;
        private int status;
        private int statusIndex;
        private int timeDurationType;
        private int vipLevel;
        private List<WeihuaGames.ClientClass.GoodsSpecialLimit> wolfSmokeLimits = new List<WeihuaGames.ClientClass.GoodsSpecialLimit>();

        public void CopyGoods(WeihuaGames.ClientClass.Goods good)
        {
            this.discount = good.discount;
            this.endTime = good.endTime;
            this.goodsID = good.goodsID;
            this.status = good.status;
            this.remainBuyCount = good.remainBuyCount;
            this.nextOpenTime = good.nextOpenTime;
            this.vipLevel = good.vipLevel;
            this.playerLevel = good.playerLevel;
            this.openTime = good.openTime;
            this.statusIndex = good.statusIndex;
            this.maxBuyCount = good.maxBuyCount;
            this.showPlayerLevel = good.showPlayerLevel;
            this.showVipLevel = good.showVipLevel;
            this.earlyShowTime = good.earlyShowTime;
            this.timeDurationType = good.timeDurationType;
            this.melaleucaLimits.Clear();
            foreach (WeihuaGames.ClientClass.GoodsSpecialLimit limit in good.melaleucaLimits)
            {
                WeihuaGames.ClientClass.GoodsSpecialLimit item = new WeihuaGames.ClientClass.GoodsSpecialLimit {
                    Type = limit.Type,
                    IntValue = limit.IntValue
                };
                this.melaleucaLimits.Add(item);
            }
            this.wolfSmokeLimits.Clear();
            foreach (WeihuaGames.ClientClass.GoodsSpecialLimit limit3 in good.wolfSmokeLimits)
            {
                WeihuaGames.ClientClass.GoodsSpecialLimit limit4 = new WeihuaGames.ClientClass.GoodsSpecialLimit {
                    Type = limit3.Type,
                    IntValue = limit3.IntValue
                };
                this.wolfSmokeLimits.Add(limit4);
            }
        }

        public WeihuaGames.ClientClass.Goods FromProtobuf(com.kodgames.corgi.protocol.Goods goods)
        {
            if (goods != null)
            {
                this.discount = goods.discount;
                this.endTime = goods.endTime;
                this.goodsID = goods.goodsID;
                this.status = goods.status;
                this.remainBuyCount = goods.remainBuyCount;
                this.nextOpenTime = goods.nextOpenTime;
                this.vipLevel = goods.vipLevel;
                this.playerLevel = goods.playerLevel;
                this.openTime = goods.openTime;
                this.statusIndex = goods.statusIndex;
                this.maxBuyCount = goods.maxBuyCount;
                this.showVipLevel = goods.showVipLevel;
                this.showPlayerLevel = goods.showPlayerLevel;
                this.earlyShowTime = goods.earlyShowTime;
                this.timeDurationType = goods.timeDurationType;
                foreach (com.kodgames.corgi.protocol.GoodsSpecialLimit limit in goods.melaleucaLimits)
                {
                    this.melaleucaLimits.Add(new WeihuaGames.ClientClass.GoodsSpecialLimit().FromProtobuf(limit));
                }
                foreach (com.kodgames.corgi.protocol.GoodsSpecialLimit limit2 in goods.wolfSmokeLimits)
                {
                    this.wolfSmokeLimits.Add(new WeihuaGames.ClientClass.GoodsSpecialLimit().FromProtobuf(limit2));
                }
            }
            return this;
        }

        public com.kodgames.corgi.protocol.Goods ToProtoBuf()
        {
            com.kodgames.corgi.protocol.Goods goods = new com.kodgames.corgi.protocol.Goods {
                discount = this.discount,
                endTime = this.endTime,
                goodsID = this.goodsID,
                status = this.status,
                remainBuyCount = this.remainBuyCount,
                nextOpenTime = this.nextOpenTime,
                vipLevel = this.vipLevel,
                playerLevel = this.playerLevel,
                openTime = this.openTime,
                statusIndex = this.statusIndex,
                maxBuyCount = this.maxBuyCount,
                showPlayerLevel = this.showPlayerLevel,
                showVipLevel = this.showVipLevel,
                earlyShowTime = this.earlyShowTime,
                timeDurationType = this.timeDurationType
            };
            foreach (WeihuaGames.ClientClass.GoodsSpecialLimit limit in this.melaleucaLimits)
            {
                goods.melaleucaLimits.Add(limit.ToProtoBuf());
            }
            foreach (WeihuaGames.ClientClass.GoodsSpecialLimit limit2 in this.wolfSmokeLimits)
            {
                goods.wolfSmokeLimits.Add(limit2.ToProtoBuf());
            }
            return goods;
        }

        public int Discount
        {
            get
            {
                return this.discount;
            }
            set
            {
                this.discount = value;
            }
        }

        public long EarlyShowTime
        {
            get
            {
                return this.earlyShowTime;
            }
            set
            {
                this.earlyShowTime = value;
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

        public int GoodsID
        {
            get
            {
                return this.goodsID;
            }
            set
            {
                this.goodsID = value;
            }
        }

        public int MaxBuyCount
        {
            get
            {
                return this.maxBuyCount;
            }
            set
            {
                this.maxBuyCount = value;
            }
        }

        public List<WeihuaGames.ClientClass.GoodsSpecialLimit> MelaleucaLimits
        {
            get
            {
                return this.melaleucaLimits;
            }
            set
            {
                this.melaleucaLimits = value;
            }
        }

        public long NextOpenTime
        {
            get
            {
                return this.nextOpenTime;
            }
            set
            {
                this.nextOpenTime = value;
            }
        }

        public long OpenTime
        {
            get
            {
                return this.openTime;
            }
            set
            {
                this.openTime = value;
            }
        }

        public int PlayerLevel
        {
            get
            {
                return this.playerLevel;
            }
            set
            {
                this.playerLevel = value;
            }
        }

        public int RemainBuyCount
        {
            get
            {
                return this.remainBuyCount;
            }
            set
            {
                this.remainBuyCount = value;
            }
        }

        public int ShowPlayerLevel
        {
            get
            {
                return this.showPlayerLevel;
            }
            set
            {
                this.showPlayerLevel = value;
            }
        }

        public int ShowVipLevel
        {
            get
            {
                return this.showVipLevel;
            }
            set
            {
                this.showVipLevel = value;
            }
        }

        public int Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public int StatusIndex
        {
            get
            {
                return this.statusIndex;
            }
            set
            {
                this.statusIndex = value;
            }
        }

        public int TimeDurationType
        {
            get
            {
                return this.timeDurationType;
            }
            set
            {
                this.timeDurationType = value;
            }
        }

        public int VipLevel
        {
            get
            {
                return this.vipLevel;
            }
            set
            {
                this.vipLevel = value;
            }
        }

        public List<WeihuaGames.ClientClass.GoodsSpecialLimit> WolfSmokeLimits
        {
            get
            {
                return this.wolfSmokeLimits;
            }
            set
            {
                this.wolfSmokeLimits = value;
            }
        }
    }
}

