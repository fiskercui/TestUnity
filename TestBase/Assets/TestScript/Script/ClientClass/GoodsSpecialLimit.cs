namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class GoodsSpecialLimit
    {
        private int intValue;
        private int type;

        public WeihuaGames.ClientClass.GoodsSpecialLimit FromProtobuf(com.kodgames.corgi.protocol.GoodsSpecialLimit limit)
        {
            this.type = limit.type;
            this.intValue = limit.intValue;
            return this;
        }

        public com.kodgames.corgi.protocol.GoodsSpecialLimit ToProtoBuf()
        {
            return new com.kodgames.corgi.protocol.GoodsSpecialLimit { 
                type = this.type,
                intValue = this.intValue
            };
        }

        public int IntValue
        {
            get
            {
                return this.intValue;
            }
            set
            {
                this.intValue = value;
            }
        }

        public int Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

