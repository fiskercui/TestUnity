namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class RewardView
    {
        private int attributeAlgorithmId;
        private int breakthoughtLevel;
        private int count;
        private int id;
        private int increase;
        private int level;
        private float possibility;

        public WeihuaGames.ClientClass.RewardView FromProtobuf(com.kodgames.corgi.protocol.RewardView rewardView)
        {
            if (rewardView != null)
            {
                this.id = rewardView.id;
                this.level = rewardView.level;
                this.breakthoughtLevel = rewardView.breakthoughtLevel;
                this.count = rewardView.count;
                this.increase = rewardView.increase;
                this.possibility = rewardView.possibility;
                this.attributeAlgorithmId = rewardView.attributeAlgorithmId;
            }
            return this;
        }

        public int AttributeAlgorithmId
        {
            get
            {
                return this.attributeAlgorithmId;
            }
            set
            {
                this.attributeAlgorithmId = value;
            }
        }

        public int BreakthoughtLevel
        {
            get
            {
                return this.breakthoughtLevel;
            }
            set
            {
                this.breakthoughtLevel = value;
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

        public int Id
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

        public int Increase
        {
            get
            {
                return this.increase;
            }
            set
            {
                this.increase = value;
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

        public float Possibility
        {
            get
            {
                return this.possibility;
            }
            set
            {
                this.possibility = value;
            }
        }
    }
}

