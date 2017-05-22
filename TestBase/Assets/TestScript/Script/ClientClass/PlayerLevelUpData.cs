namespace WeihuaGames.ClientClass
{
    using System;

    public class PlayerLevelUpData
    {
        private CostAndRewardAndSync crs;
        private int playerLevel;

        public PlayerLevelUpData()
        {
        }

        public PlayerLevelUpData(int playerLvl, CostAndRewardAndSync crs)
        {
            this.playerLevel = playerLvl;
            this.crs = crs;
        }

        public CostAndRewardAndSync Crs
        {
            get
            {
                return this.crs;
            }
            set
            {
                this.crs = value;
            }
        }

        public int PlayerLevel
        {
            get
            {
                return this.playerLevel;
            }
            set
            {
                this.playerLevel = value;
            }
        }
    }
}

