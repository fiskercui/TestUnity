namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class QinInfoRank
    {
        private int maxContinueRightCount;
        private string name;
        private int rank;

        public WeihuaGames.ClientClass.QinInfoRank FromProtobuf(com.kodgames.corgi.protocol.QinInfoRank qinInfoRank)
        {
            if (qinInfoRank != null)
            {
                this.name = qinInfoRank.name;
                this.maxContinueRightCount = qinInfoRank.maxContinueRightCount;
                this.rank = qinInfoRank.rank;
            }
            return this;
        }

        public int MaxContinueRightCount
        {
            get
            {
                return this.maxContinueRightCount;
            }
            set
            {
                this.maxContinueRightCount = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Rank
        {
            get
            {
                return this.rank;
            }
            set
            {
                this.rank = value;
            }
        }
    }
}

