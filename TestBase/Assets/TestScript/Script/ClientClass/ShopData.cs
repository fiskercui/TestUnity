namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class ShopData
    {
        private List<WeihuaGames.ClientClass.Goods> goods;
        private long nextRefreshTime;
        private List<TavernInfo> tavernInfos = new List<TavernInfo>();

        public WeihuaGames.ClientClass.Goods GetGoodsById(int goodsId)
        {
            if (this.goods != null)
            {
                foreach (WeihuaGames.ClientClass.Goods goods in this.goods)
                {
                    if (goods.GoodsID == goodsId)
                    {
                        return goods;
                    }
                }
            }
            return null;
        }

        public TavernInfo GetTavernInfoById(int tavernId)
        {
            if (this.tavernInfos != null)
            {
                foreach (TavernInfo info in this.tavernInfos)
                {
                    if (info.id == tavernId)
                    {
                        return info;
                    }
                }
            }
            return null;
        }

        public int GetTavernInfoIndexById(int tavernId)
        {
            if (this.tavernInfos != null)
            {
                for (int i = 0; i < this.tavernInfos.Count; i++)
                {
                    if (this.tavernInfos[i].id == tavernId)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public void UpdateGoodData(WeihuaGames.ClientClass.Goods good)
        {
            if (this.goods != null)
            {
                foreach (WeihuaGames.ClientClass.Goods goods in this.goods)
                {
                    if (goods.GoodsID == good.GoodsID)
                    {
                        goods.CopyGoods(good);
                        break;
                    }
                }
            }
        }

        public List<WeihuaGames.ClientClass.Goods> Goods
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

        public List<TavernInfo> TavernInfos
        {
            get
            {
                return this.tavernInfos;
            }
            set
            {
                this.tavernInfos = value;
            }
        }
    }
}

