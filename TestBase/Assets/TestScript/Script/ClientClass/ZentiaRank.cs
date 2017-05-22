namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class ZentiaRank
    {
        private int iconId;
        private int playerId;
        private string playerName;
        private int playerZentiaPoint;
        private int rank;
        private WeihuaGames.ClientClass.Reward reward = new WeihuaGames.ClientClass.Reward();

        public WeihuaGames.ClientClass.ZentiaRank FromProtobuf(com.kodgames.corgi.protocol.ZentiaRank zentiaRank)
        {
            if (zentiaRank != null)
            {
                this.rank = zentiaRank.rank;
                this.playerId = zentiaRank.playerId;
                this.playerName = zentiaRank.playerName;
                this.playerZentiaPoint = zentiaRank.playerZentiaPoint;
                this.iconId = zentiaRank.iconId;
                if (zentiaRank.reward != null)
                {
                    WeihuaGames.ClientClass.Reward reward = new WeihuaGames.ClientClass.Reward();
                    reward.FromProtobuf(zentiaRank.reward);
                    this.reward = reward;
                }
            }
            return this;
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

        public int PlayerId
        {
            get
            {
                return this.playerId;
            }
            set
            {
                this.playerId = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            set
            {
                this.playerName = value;
            }
        }

        public int PlayerZentiaPoint
        {
            get
            {
                return this.playerZentiaPoint;
            }
            set
            {
                this.playerZentiaPoint = value;
            }
        }

        public int Rank
        {
            get
            {
                return this.rank;
            }
            set
            {
                this.rank = value;
            }
        }

        public WeihuaGames.ClientClass.Reward Reward
        {
            get
            {
                return this.reward;
            }
            set
            {
                this.reward = value;
            }
        }
    }
}

