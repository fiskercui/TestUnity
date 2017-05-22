namespace WeihuaGames.ClientClass
{
    using System;
    using System.Collections.Generic;

    public class QuestData
    {
        private WeihuaGames.ClientClass.QuestQuick questQuick;
        private List<Quest> quests;

        public Quest GetQuestByQuestID(int qusetID)
        {
            foreach (Quest quest in this.quests)
            {
                if (quest.QuestId == qusetID)
                {
                    return quest;
                }
            }
            return null;
        }

        public WeihuaGames.ClientClass.QuestQuick QuestQuick
        {
            get
            {
                return this.questQuick;
            }
            set
            {
                this.questQuick = value;
            }
        }

        public List<Quest> Quests
        {
            get
            {
                return this.quests;
            }
            set
            {
                this.quests = value;
            }
        }
    }
}

