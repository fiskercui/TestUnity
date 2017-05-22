namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class BuffData
    {
        private int buffId;
        private int instId;

        public void Copy(WeihuaGames.ClientClass.BuffData buffData)
        {
            this.instId = buffData.instId;
            this.buffId = buffData.buffId;
        }

        public WeihuaGames.ClientClass.BuffData FromProtobuf(com.kodgames.corgi.protocol.BuffData protocol)
        {
            this.instId = protocol.instId;
            this.buffId = protocol.buffId;
            return this;
        }

        public com.kodgames.corgi.protocol.BuffData ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.BuffData { 
                instId = this.instId,
                buffId = this.buffId
            };
        }

        public int BuffId
        {
            get
            {
                return this.buffId;
            }
            set
            {
                this.buffId = value;
            }
        }

        public int InstId
        {
            get
            {
                return this.instId;
            }
            set
            {
                this.instId = value;
            }
        }
    }
}

