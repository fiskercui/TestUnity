namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GoodRecord
    {
        private int amount;
        private int goodsID;

        public void FromProtobuf(com.kodgames.corgi.protocol.GoodRecord goodRecord)
        {
            this.goodsID = goodRecord.goodsID;
            this.amount = goodRecord.amount;
        }

        public com.kodgames.corgi.protocol.GoodRecord ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.GoodRecord { 
                goodsID = this.goodsID,
                amount = this.amount
            };
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
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
    }
}

