namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class CostAsset
    {
        private int breakThroughLevelFrom;
        private int breakThroughLevelTo;
        private int count;
        private int iconId;
        private int levelFrom;
        private int levelTo;
        private int qualityLevel;
        private int subType;
        private int type;

        public WeihuaGames.ClientClass.CostAsset FromProtobuf(com.kodgames.corgi.protocol.CostAsset costAsset)
        {
            this.iconId = costAsset.iconId;
            this.subType = costAsset.subType;
            this.type = costAsset.type;
            this.qualityLevel = costAsset.qualityLevel;
            this.count = costAsset.count;
            this.BreakThroughLevelFrom = costAsset.breakThroughLevelFrom;
            this.BreakThroughLevelTo = costAsset.breakThroughLevelTo;
            this.levelFrom = costAsset.levelFrom;
            this.levelTo = costAsset.levelTo;
            return this;
        }

        public int BreakThroughLevelFrom
        {
            get
            {
                return this.breakThroughLevelFrom;
            }
            set
            {
                this.breakThroughLevelFrom = value;
            }
        }

        public int BreakThroughLevelTo
        {
            get
            {
                return this.breakThroughLevelTo;
            }
            set
            {
                this.breakThroughLevelTo = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        public int IconId
        {
            get
            {
                return this.iconId;
            }
            set
            {
                this.iconId = value;
            }
        }

        public int LevelFrom
        {
            get
            {
                return this.levelFrom;
            }
            set
            {
                this.levelFrom = value;
            }
        }

        public int LevelTo
        {
            get
            {
                return this.levelTo;
            }
            set
            {
                this.levelTo = value;
            }
        }

        public int QualityLevel
        {
            get
            {
                return this.qualityLevel;
            }
            set
            {
                this.qualityLevel = value;
            }
        }

        public int SubType
        {
            get
            {
                return this.subType;
            }
            set
            {
                this.subType = value;
            }
        }

        public int Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

