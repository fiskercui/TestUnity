namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class InviteReward
    {
        private int id;
        private int pickState;
        private int requireCount;
        private int requireLevel;
        private WeihuaGames.ClientClass.Reward reward;
        private int sortIndex;

        public WeihuaGames.ClientClass.InviteReward FromProtobuf(com.kodgames.corgi.protocol.InviteReward inviteReward)
        {
            if (inviteReward == null)
            {
                return null;
            }
            this.id = inviteReward.id;
            this.requireCount = inviteReward.requireCount;
            this.requireLevel = inviteReward.requireLevel;
            this.reward = new WeihuaGames.ClientClass.Reward().FromProtobuf(inviteReward.reward);
            this.pickState = inviteReward.pickState;
            this.sortIndex = inviteReward.sortIndex;
            return this;
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int PickState
        {
            get
            {
                return this.pickState;
            }
            set
            {
                this.pickState = value;
            }
        }

        public int RequireCount
        {
            get
            {
                return this.requireCount;
            }
            set
            {
                this.requireCount = value;
            }
        }

        public int RequireLevel
        {
            get
            {
                return this.requireLevel;
            }
            set
            {
                this.requireLevel = value;
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

        public int SortIndex
        {
            get
            {
                return this.sortIndex;
            }
            set
            {
                this.sortIndex = value;
            }
        }
    }
}

