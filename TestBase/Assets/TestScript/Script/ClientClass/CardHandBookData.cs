namespace WeihuaGames.ClientClass
{
    using System;
    using System.Collections.Generic;

    public class CardHandBookData
    {
        private List<int> cardIds;

        public void AddCard(int id)
        {
            if ((this.cardIds != null) && !this.cardIds.Contains(id))
            {
                this.cardIds.Add(id);
            }
        }

        public List<int> CardIds
        {
            get
            {
                return this.cardIds;
            }
            set
            {
                this.cardIds = value;
            }
        }
    }
}

