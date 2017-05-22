namespace KodGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class WolfEggs
    {
        private int rewardCount;
        private int rewardId;

        public KodGames.ClientClass.WolfEggs FromProtobuf(com.kodgames.corgi.protocol.WolfEggs wolfEggs)
        {
            if (wolfEggs != null)
            {
                this.rewardId = wolfEggs.rewardId;
                this.rewardCount = wolfEggs.rewardCount;
            }
            return this;
        }

        public int RewardCount
        {
            get
            {
                return this.rewardCount;
            }
            set
            {
                this.rewardCount = value;
            }
        }

        public int RewardId
        {
            get
            {
                return this.rewardId;
            }
            set
            {
                this.rewardId = value;
            }
        }
    }
}

