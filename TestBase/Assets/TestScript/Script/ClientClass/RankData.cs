namespace WeihuaGames.ClientClass
{
    using System;
    using System.Collections.Generic;

    public class RankData
    {
        private List<PlayerRecord> levelRank;
        private List<PlayerRecord> playerValueRank;
        private int selfLevelRank;
        private PlayerRecord selfPlayerRecord;
        private int selfPlayerValueRank;
        private int selfSupermanRank;
        private List<PlayerRecord> supermanRank;

        public List<PlayerRecord> LevelRank
        {
            get
            {
                return this.levelRank;
            }
            set
            {
                this.levelRank = value;
            }
        }

        public List<PlayerRecord> PlayerValueRank
        {
            get
            {
                return this.playerValueRank;
            }
            set
            {
                this.playerValueRank = value;
            }
        }

        public int SelfLevelRank
        {
            get
            {
                return this.selfLevelRank;
            }
            set
            {
                this.selfLevelRank = value;
            }
        }

        public PlayerRecord SelfPlayerRecord
        {
            get
            {
                return this.selfPlayerRecord;
            }
            set
            {
                this.selfPlayerRecord = value;
            }
        }

        public int SelfPlayerValueRank
        {
            get
            {
                return this.selfPlayerValueRank;
            }
            set
            {
                this.selfPlayerValueRank = value;
            }
        }

        public int SelfSupermanRank
        {
            get
            {
                return this.selfSupermanRank;
            }
            set
            {
                this.selfSupermanRank = value;
            }
        }

        public List<PlayerRecord> SupermanRank
        {
            get
            {
                return this.supermanRank;
            }
            set
            {
                this.supermanRank = value;
            }
        }
    }
}

