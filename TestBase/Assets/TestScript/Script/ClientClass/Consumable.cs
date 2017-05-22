namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Consumable
    {
        private DynamicInt addtionalAmount = new DynamicInt();
        private DynamicInt amount = new DynamicInt();
        private int id;

        public WeihuaGames.ClientClass.Consumable FromProtobuf(com.kodgames.corgi.protocol.Consumable protocol)
        {
            this.id = protocol.id;
            this.amount = protocol.amount;
            this.addtionalAmount = protocol.additionalAmount;
            return this;
        }

        public com.kodgames.corgi.protocol.Consumable ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.Consumable { 
                id = this.id,
                amount = (int) this.amount,
                additionalAmount = (int) this.addtionalAmount
            };
        }

        public int AddtionalAmount
        {
            get
            {
                return (int) this.addtionalAmount;
            }
            set
            {
                this.addtionalAmount = value;
            }
        }

        public int Amount
        {
            get
            {
                return (int) this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
    }
}

