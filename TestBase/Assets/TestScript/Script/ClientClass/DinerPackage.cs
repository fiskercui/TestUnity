namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class DinerPackage
    {
        private Dictionary<int, WeihuaGames.ClientClass.QueryDiner> dic_queryDiners = new Dictionary<int, WeihuaGames.ClientClass.QueryDiner>();
        private long lastRefreshTime;
        private long nextRefreshTime;
        private int normalRefreshAmount;
        private int qualityType;
        private List<WeihuaGames.ClientClass.QueryDiner> queryDiners = new List<WeihuaGames.ClientClass.QueryDiner>();
        private long refreshCountResetTime;
        private int specialRefreshAmonut;

        public WeihuaGames.ClientClass.DinerPackage FromProtoBuf(com.kodgames.corgi.protocol.DinerPackage proto)
        {
            if (proto != null)
            {
                this.qualityType = proto.qualityType;
                this.normalRefreshAmount = proto.normalRefreshAmount;
                this.specialRefreshAmonut = proto.specialRefreshAmonut;
                this.nextRefreshTime = proto.nextRefreshTime;
                this.lastRefreshTime = proto.lastRefreshTime;
                this.refreshCountResetTime = proto.refreshCountResetTime;
                if (proto.queryDiners != null)
                {
                    foreach (com.kodgames.corgi.protocol.QueryDiner diner in proto.queryDiners)
                    {
                        this.queryDiners.Add(new WeihuaGames.ClientClass.QueryDiner().FromProtoBuf(diner));
                    }
                }
            }
            return this;
        }

        public WeihuaGames.ClientClass.QueryDiner GetQueryDinerById(int dinerId)
        {
            if (this.dic_queryDiners.ContainsKey(dinerId))
            {
                return this.dic_queryDiners[dinerId];
            }
            return null;
        }

        public void ShallowCopy(WeihuaGames.ClientClass.DinerPackage package)
        {
            if (package != null)
            {
                this.qualityType = package.qualityType;
                this.normalRefreshAmount = package.normalRefreshAmount;
                this.specialRefreshAmonut = package.specialRefreshAmonut;
                this.nextRefreshTime = package.nextRefreshTime;
                this.lastRefreshTime = package.lastRefreshTime;
                this.refreshCountResetTime = package.refreshCountResetTime;
                this.dic_queryDiners.Clear();
                this.queryDiners.Clear();
                foreach (WeihuaGames.ClientClass.QueryDiner diner in package.queryDiners)
                {
                    WeihuaGames.ClientClass.QueryDiner item = new WeihuaGames.ClientClass.QueryDiner();
                    item.ShallowCopy(diner);
                    this.queryDiners.Add(item);
                    this.dic_queryDiners.Add(item.DinerId, item);
                }
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

        public int NormalRefreshAmount
        {
            get
            {
                return this.normalRefreshAmount;
            }
            set
            {
                this.normalRefreshAmount = value;
            }
        }

        public int QualityType
        {
            get
            {
                return this.qualityType;
            }
            set
            {
                this.qualityType = value;
            }
        }

        public List<WeihuaGames.ClientClass.QueryDiner> QueryDiners
        {
            get
            {
                return this.queryDiners;
            }
            set
            {
                this.queryDiners = value;
            }
        }

        public long RefreshCountResetTime
        {
            get
            {
                return this.refreshCountResetTime;
            }
            set
            {
                this.refreshCountResetTime = value;
            }
        }

        public int SpecialRefreshAmonut
        {
            get
            {
                return this.specialRefreshAmonut;
            }
            set
            {
                this.specialRefreshAmonut = value;
            }
        }
    }
}

