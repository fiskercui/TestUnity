namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class DungeonDifficulty
    {
        private List<int> boxPickedIndexs = new List<int>();
        private int difficultyType;
        private List<WeihuaGames.ClientClass.Dungeon> dungeons = new List<WeihuaGames.ClientClass.Dungeon>();
        private List<WeihuaGames.ClientClass.TravelData> travelDatas = new List<WeihuaGames.ClientClass.TravelData>();

        public WeihuaGames.ClientClass.DungeonDifficulty FromProtobuf(com.kodgames.corgi.protocol.DungeonDifficulty dungeonDifficulty)
        {
            if (dungeonDifficulty != null)
            {
                this.dungeons = new List<WeihuaGames.ClientClass.Dungeon>();
                this.difficultyType = dungeonDifficulty.difficultyType;
                foreach (int num in dungeonDifficulty.boxPickedIndexs)
                {
                    this.boxPickedIndexs.Add(num);
                }
                foreach (com.kodgames.corgi.protocol.Dungeon dungeon in dungeonDifficulty.dungeons)
                {
                    WeihuaGames.ClientClass.Dungeon item = new WeihuaGames.ClientClass.Dungeon();
                    item.FromProtobuf(dungeon);
                    this.dungeons.Add(item);
                }
                foreach (com.kodgames.corgi.protocol.TravelData data in dungeonDifficulty.travelDatas)
                {
                    WeihuaGames.ClientClass.TravelData data2 = new WeihuaGames.ClientClass.TravelData();
                    data2.FromProtobuf(data);
                    this.travelDatas.Add(data2);
                }
            }
            return this;
        }

        public List<int> BoxPickedIndexs
        {
            get
            {
                return this.boxPickedIndexs;
            }
            set
            {
                this.boxPickedIndexs = value;
            }
        }

        public int DifficultyType
        {
            get
            {
                return this.difficultyType;
            }
            set
            {
                this.difficultyType = value;
            }
        }

        public List<WeihuaGames.ClientClass.Dungeon> Dungeons
        {
            get
            {
                return this.dungeons;
            }
            set
            {
                this.dungeons = value;
            }
        }

        public List<WeihuaGames.ClientClass.TravelData> TravelDatas
        {
            get
            {
                return this.travelDatas;
            }
            set
            {
                this.travelDatas = value;
            }
        }
    }
}

