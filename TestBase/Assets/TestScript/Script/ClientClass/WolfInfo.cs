namespace KodGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class WolfInfo
    {
        private int alreadyFailedTimes;
        private int alreadyResetTimes;
        private int gameMoney;
        private int maxPassStageId;
        private int medals;
        private double nextResetTime;
        private int realMoney;
        private int stageId;

        public KodGames.ClientClass.WolfInfo FromProtobuf(com.kodgames.corgi.protocol.WolfInfo wolfInfo)
        {
            if (wolfInfo != null)
            {
                this.stageId = wolfInfo.stageId;
                this.nextResetTime = wolfInfo.nextResetTime;
                this.alreadyResetTimes = wolfInfo.alreadyResetTimes;
                this.AlreadyFailedTimes = wolfInfo.alreadyFailedTimes;
                this.maxPassStageId = wolfInfo.maxPassStageId;
                this.gameMoney = wolfInfo.gameMoney;
                this.realMoney = wolfInfo.realMoney;
                this.Medals = wolfInfo.medals;
            }
            return this;
        }

        public int AlreadyFailedTimes
        {
            get
            {
                return this.alreadyFailedTimes;
            }
            set
            {
                this.alreadyFailedTimes = value;
            }
        }

        public int AlreadyResetTimes
        {
            get
            {
                return this.alreadyResetTimes;
            }
            set
            {
                this.alreadyResetTimes = value;
            }
        }

        public int GameMoney
        {
            get
            {
                return this.gameMoney;
            }
            set
            {
                this.gameMoney = value;
            }
        }

        public int MaxPassStageId
        {
            get
            {
                return this.maxPassStageId;
            }
            set
            {
                this.maxPassStageId = value;
            }
        }

        public int Medals
        {
            get
            {
                return this.medals;
            }
            set
            {
                this.medals = value;
            }
        }

        public double NextResetTime
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

        public int RealMoney
        {
            get
            {
                return this.realMoney;
            }
            set
            {
                this.realMoney = value;
            }
        }

        public int StageId
        {
            get
            {
                return this.stageId;
            }
            set
            {
                this.stageId = value;
            }
        }
    }
}

