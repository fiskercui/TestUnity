namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class Zone
    {
        private List<WeihuaGames.ClientClass.DungeonDifficulty> dungeonDifficulties;
        private int status;
        private int zoneId;

        public WeihuaGames.ClientClass.Zone FromProtobuf(com.kodgames.corgi.protocol.Zone zone)
        {
            if (zone != null)
            {
                this.dungeonDifficulties = new List<WeihuaGames.ClientClass.DungeonDifficulty>();
                this.zoneId = zone.zoneId;
                foreach (com.kodgames.corgi.protocol.DungeonDifficulty difficulty in zone.dungeonDifficulties)
                {
                    WeihuaGames.ClientClass.DungeonDifficulty item = new WeihuaGames.ClientClass.DungeonDifficulty();
                    item.FromProtobuf(difficulty);
                    this.dungeonDifficulties.Add(item);
                }
                this.status = zone.status;
            }
            return this;
        }

        public WeihuaGames.ClientClass.DungeonDifficulty GetDungeonDiffcultyByDiffcultyType(int diffcultyType)
        {
            if ((this.dungeonDifficulties != null) && (this.dungeonDifficulties.Count > 0))
            {
                foreach (WeihuaGames.ClientClass.DungeonDifficulty difficulty in this.dungeonDifficulties)
                {
                    if (difficulty.DifficultyType == diffcultyType)
                    {
                        return difficulty;
                    }
                }
            }
            return null;
        }

        public List<WeihuaGames.ClientClass.DungeonDifficulty> DungeonDifficulties
        {
            get
            {
                return this.dungeonDifficulties;
            }
            set
            {
                this.dungeonDifficulties = value;
            }
        }

        public int Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public int ZoneId
        {
            get
            {
                return this.zoneId;
            }
            set
            {
                this.zoneId = value;
            }
        }
    }
}

