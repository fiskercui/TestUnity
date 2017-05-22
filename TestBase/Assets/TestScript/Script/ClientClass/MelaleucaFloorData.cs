namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class MelaleucaFloorData
    {
        private int challengeFailsCount;
        private int currentLayer;
        private int currentPoint;
        private bool isResetPlayerInfo;
        private int lastWeekLayer;
        private int lastWeekPoint;
        private int lastWeekRank;
        private int maxPassLayer;
        private long nextResetTime;
        private int thisWeekLayer;
        private int thisWeekPoint;
        private int thisWeekRank;

        public MelaleucaFloorData FromProtoBuf(MelaleucaFloorInfo protoInfo)
        {
            if (protoInfo == null)
            {
                return null;
            }
            this.nextResetTime = protoInfo.nextResetTime;
            this.currentLayer = protoInfo.currentLayer;
            this.currentPoint = protoInfo.currentPoint;
            this.maxPassLayer = protoInfo.maxPassLayer;
            this.challengeFailsCount = protoInfo.challengeFailsCount;
            return this;
        }

        public int ChallengeFailsCount
        {
            get
            {
                return this.challengeFailsCount;
            }
            set
            {
                this.challengeFailsCount = value;
            }
        }

        public int CurrentLayer
        {
            get
            {
                return this.currentLayer;
            }
            set
            {
                this.currentLayer = value;
            }
        }

        public int CurrentPoint
        {
            get
            {
                return this.currentPoint;
            }
            set
            {
                this.currentPoint = value;
            }
        }

        public bool IsResetPlayerInfo
        {
            get
            {
                return this.isResetPlayerInfo;
            }
            set
            {
                this.isResetPlayerInfo = value;
            }
        }

        public int LastWeekLayer
        {
            get
            {
                return this.lastWeekLayer;
            }
            set
            {
                this.lastWeekLayer = value;
            }
        }

        public int LastWeekPoint
        {
            get
            {
                return this.lastWeekPoint;
            }
            set
            {
                this.lastWeekPoint = value;
            }
        }

        public int LastWeekRank
        {
            get
            {
                return this.lastWeekRank;
            }
            set
            {
                this.lastWeekRank = value;
            }
        }

        public int MaxPassLayer
        {
            get
            {
                return this.maxPassLayer;
            }
            set
            {
                this.maxPassLayer = value;
            }
        }

        public long NextResetTime
        {
            get
            {
                return this.nextResetTime;
            }
            set
            {
                this.nextResetTime = value;
            }
        }

        public int ThisWeekLayer
        {
            get
            {
                return this.thisWeekLayer;
            }
            set
            {
                this.thisWeekLayer = value;
            }
        }

        public int ThisWeekPoint
        {
            get
            {
                return this.thisWeekPoint;
            }
            set
            {
                this.thisWeekPoint = value;
            }
        }

        public int ThisWeekRank
        {
            get
            {
                return this.thisWeekRank;
            }
            set
            {
                this.thisWeekRank = value;
            }
        }
    }
}

