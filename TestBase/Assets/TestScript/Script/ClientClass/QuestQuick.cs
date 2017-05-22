namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class QuestQuick
    {
        private int canPickDailyQuestsCount;
        private int canPickGoalQuestsCount;
        private int canPickRepeatedQuestsCount;
        private long lastResetTime;

        public WeihuaGames.ClientClass.QuestQuick FromProtoBuffer(com.kodgames.corgi.protocol.QuestQuick questQuick)
        {
            this.lastResetTime = questQuick.lastResetTime;
            this.canPickDailyQuestsCount = questQuick.canPickDailyQuestsCount;
            this.canPickGoalQuestsCount = questQuick.canPickGoalQuestsCount;
            this.canPickRepeatedQuestsCount = questQuick.canPickRepeatedQuestsCount;
            return this;
        }

        public int CanPickDailyQuestsCount
        {
            get
            {
                return this.canPickDailyQuestsCount;
            }
            set
            {
                this.canPickDailyQuestsCount = value;
            }
        }

        public int CanPickGoalQuestsCount
        {
            get
            {
                return this.canPickGoalQuestsCount;
            }
            set
            {
                this.canPickGoalQuestsCount = value;
            }
        }

        public int CanPickRepeatedQuestsCount
        {
            get
            {
                return this.canPickRepeatedQuestsCount;
            }
            set
            {
                this.canPickRepeatedQuestsCount = value;
            }
        }

        public long LastResetTime
        {
            get
            {
                return this.lastResetTime;
            }
            set
            {
                this.lastResetTime = value;
            }
        }
    }
}

