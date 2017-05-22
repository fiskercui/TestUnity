namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Quest
    {
        private int currentStep;
        private int phase;
        private int questId;

        public WeihuaGames.ClientClass.Quest FromProtoBuf(com.kodgames.corgi.protocol.Quest quest)
        {
            this.questId = quest.questId;
            this.currentStep = quest.currentStep;
            this.phase = quest.phase;
            return this;
        }

        public int CurrentStep
        {
            get
            {
                return this.currentStep;
            }
            set
            {
                this.currentStep = value;
            }
        }

        public int Phase
        {
            get
            {
                return this.phase;
            }
            set
            {
                this.phase = value;
            }
        }

        public int QuestId
        {
            get
            {
                return this.questId;
            }
            set
            {
                this.questId = value;
            }
        }
    }
}

