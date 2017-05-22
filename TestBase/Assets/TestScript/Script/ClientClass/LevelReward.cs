namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class LevelReward
    {
        private int id;
        private int state;

        public WeihuaGames.ClientClass.LevelReward FromProtobuf(com.kodgames.corgi.protocol.LevelReward protocol)
        {
            this.id = protocol.id;
            this.state = protocol.state;
            return this;
        }

        public com.kodgames.corgi.protocol.LevelReward ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.LevelReward { 
                id = this.id,
                state = this.state
            };
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

        public int State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }
    }
}

