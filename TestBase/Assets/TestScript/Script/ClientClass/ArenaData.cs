namespace WeihuaGames.ClientClass
{
    using System;
    using System.Collections.Generic;

    public class ArenaData
    {
        private int additionalHonorPoint;
        private int challengePoint;
        private List<PlayerRecord> challengeRecords = new List<PlayerRecord>();
        private List<PlayerRecord> counterRecords = new List<PlayerRecord>();
        private long honorPoint;
        private int selfRank;
        private List<PlayerRecord> top10Records = new List<PlayerRecord>();

        public int AddHonorPoint
        {
            get
            {
                return this.additionalHonorPoint;
            }
            set
            {
                this.additionalHonorPoint = value;
            }
        }

        public int ChallengePoint
        {
            get
            {
                return this.challengePoint;
            }
            set
            {
                this.challengePoint = value;
            }
        }

        public List<PlayerRecord> ChallengeRecords
        {
            get
            {
                return this.challengeRecords;
            }
            set
            {
                this.challengeRecords = value;
            }
        }

        public List<PlayerRecord> CounterRecords
        {
            get
            {
                return this.counterRecords;
            }
            set
            {
                this.counterRecords = value;
            }
        }

        public long HonorPoint
        {
            get
            {
                return this.honorPoint;
            }
            set
            {
                this.honorPoint = value;
            }
        }

        public int SelfRank
        {
            get
            {
                return this.selfRank;
            }
            set
            {
                this.selfRank = value;
            }
        }

        public List<PlayerRecord> Top10Records
        {
            get
            {
                return this.top10Records;
            }
            set
            {
                this.top10Records = value;
            }
        }
    }
}

