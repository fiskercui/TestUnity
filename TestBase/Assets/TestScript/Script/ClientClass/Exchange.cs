namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class Exchange
    {
        private int alreadyExchangeCount;
        private List<WeihuaGames.ClientClass.CostAsset> costAssets;
        private List<WeihuaGames.ClientClass.ItemEx> costs;
        private long endTime;
        private int exchangeCount;
        private int exchangeId;
        private WeihuaGames.ClientClass.ItemEx gainItem;
        private int groupId;
        private int index;
        private long nextOpenTime;
        private long nextRefreshTime;
        private long openTime;
        private int playerLevel;
        private int vipLevel;

        public void FromProtobuf(com.kodgames.corgi.protocol.Exchange exchange)
        {
            this.exchangeId = exchange.exchangeId;
            this.vipLevel = exchange.vipLevel;
            this.exchangeCount = exchange.exchangeCount;
            this.alreadyExchangeCount = exchange.alreadyExchangeCount;
            this.openTime = exchange.openTime;
            this.endTime = exchange.endTime;
            this.nextOpenTime = exchange.nextOpenTime;
            if (exchange.gainItem != null)
            {
                this.gainItem = new WeihuaGames.ClientClass.ItemEx();
                this.gainItem.FromProtobuf(exchange.gainItem);
            }
            this.playerLevel = exchange.playerLevel;
            this.groupId = exchange.groupId;
            this.nextRefreshTime = exchange.nextRefreshTime;
            if (exchange.costs != null)
            {
                this.costs = new List<WeihuaGames.ClientClass.ItemEx>();
                foreach (com.kodgames.corgi.protocol.ItemEx ex in exchange.costs)
                {
                    if (ex != null)
                    {
                        WeihuaGames.ClientClass.ItemEx item = new WeihuaGames.ClientClass.ItemEx();
                        item.FromProtobuf(ex);
                        this.costs.Add(item);
                    }
                }
            }
            if (exchange.costAssets != null)
            {
                this.costAssets = new List<WeihuaGames.ClientClass.CostAsset>();
                foreach (com.kodgames.corgi.protocol.CostAsset asset in exchange.costAssets)
                {
                    if (asset != null)
                    {
                        WeihuaGames.ClientClass.CostAsset asset2 = new WeihuaGames.ClientClass.CostAsset();
                        asset2.FromProtobuf(asset);
                        this.costAssets.Add(asset2);
                    }
                }
            }
        }

        public int AlreadyExchangeCount
        {
            get
            {
                return this.alreadyExchangeCount;
            }
            set
            {
                this.alreadyExchangeCount = value;
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

        public int ExchangeCount
        {
            get
            {
                return this.exchangeCount;
            }
            set
            {
                this.exchangeCount = value;
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

        public WeihuaGames.ClientClass.ItemEx GainItem
        {
            get
            {
                return this.gainItem;
            }
            set
            {
                this.gainItem = value;
            }
        }

        public int GroupId
        {
            get
            {
                return this.groupId;
            }
            set
            {
                this.groupId = value;
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
    }
}

