namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Cost
    {
        private DynamicInt count;
        private string guid;
        private int id;

        public Cost()
        {
            this.count = new DynamicInt();
        }

        public Cost(int id, int count, string guid)
        {
            this.count = new DynamicInt();
            this.id = id;
            this.count = count;
            this.guid = guid;
        }

        public WeihuaGames.ClientClass.Cost FromProtobuf(com.kodgames.corgi.protocol.Cost cost)
        {
            this.id = cost.id;
            this.count = cost.count;
            this.guid = cost.guid;
            return this;
        }

        public com.kodgames.corgi.protocol.Cost ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.Cost { 
                guid = this.guid,
                id = this.id,
                count = (int) this.count
            };
        }

        public int Count
        {
            get
            {
                return (int) this.count;
            }
            set
            {
                this.count = value;
            }
        }

        public string Guid
        {
            get
            {
                return this.guid;
            }
            set
            {
                this.guid = value;
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

