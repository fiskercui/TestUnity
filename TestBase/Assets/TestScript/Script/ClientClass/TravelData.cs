namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class TravelData
    {
        private List<int> alreadyBuyGoodIds = new List<int>();
        private int dungeonId;
        private long openTime;

        public WeihuaGames.ClientClass.TravelData FromProtobuf(com.kodgames.corgi.protocol.TravelData travelData)
        {
            if (travelData != null)
            {
                this.dungeonId = travelData.dungeonId;
                this.openTime = travelData.openTime;
                this.alreadyBuyGoodIds = travelData.alreadyBuyGoodIds;
            }
            return this;
        }

        public void ShallowCopy(WeihuaGames.ClientClass.TravelData travelData)
        {
            if (travelData != null)
            {
                this.dungeonId = travelData.dungeonId;
                this.openTime = travelData.openTime;
                this.alreadyBuyGoodIds.Clear();
                foreach (int num in travelData.alreadyBuyGoodIds)
                {
                    this.alreadyBuyGoodIds.Add(num);
                }
            }
        }

        public List<int> AlreadyBuyGoodIds
        {
            get
            {
                return this.alreadyBuyGoodIds;
            }
            set
            {
                this.alreadyBuyGoodIds = value;
            }
        }

        public int DungeonId
        {
            get
            {
                return this.dungeonId;
            }
            set
            {
                this.dungeonId = value;
            }
        }

        public long OpenTime
        {
            get
            {
                return this.openTime;
            }
            set
            {
                this.openTime = value;
            }
        }
    }
}

