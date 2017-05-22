namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class DungeonGuideNpc
    {
        private int avatarResourceId;
        private int battlePosition;
        private int breakthroughLevel;
        private int level;
        private string name;
        private int qualityType;
        private int traitType;

        public WeihuaGames.ClientClass.DungeonGuideNpc FromProtobuf(com.kodgames.corgi.protocol.DungeonGuideNpc dungeonGuideNpc)
        {
            if (dungeonGuideNpc != null)
            {
                this.avatarResourceId = dungeonGuideNpc.avatarResourceId;
                this.battlePosition = dungeonGuideNpc.battlePosition;
                this.level = dungeonGuideNpc.level;
                this.traitType = dungeonGuideNpc.traitType;
                this.name = dungeonGuideNpc.name;
                this.breakthroughLevel = dungeonGuideNpc.breakthroughLevel;
                this.qualityType = dungeonGuideNpc.qualityType;
            }
            return this;
        }

        public void ShallowCopy(WeihuaGames.ClientClass.DungeonGuideNpc guidNpc)
        {
            this.avatarResourceId = guidNpc.avatarResourceId;
            this.battlePosition = guidNpc.battlePosition;
            this.level = guidNpc.level;
            this.traitType = guidNpc.traitType;
            this.name = guidNpc.name;
            this.breakthroughLevel = guidNpc.breakthroughLevel;
            this.qualityType = guidNpc.qualityType;
        }

        public int AvatarResourceId
        {
            get
            {
                return this.avatarResourceId;
            }
            set
            {
                this.avatarResourceId = value;
            }
        }

        public int BattlePosition
        {
            get
            {
                return this.battlePosition;
            }
            set
            {
                this.battlePosition = value;
            }
        }

        public int BreakthroughLevel
        {
            get
            {
                return this.breakthroughLevel;
            }
            set
            {
                this.breakthroughLevel = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int QualityType
        {
            get
            {
                return this.qualityType;
            }
            set
            {
                this.qualityType = value;
            }
        }

        public int TraitType
        {
            get
            {
                return this.traitType;
            }
            set
            {
                this.traitType = value;
            }
        }
    }
}

