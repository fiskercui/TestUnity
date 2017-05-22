namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Domineer
    {
        private int domineerId;
        private int level;

        public WeihuaGames.ClientClass.Domineer FromProtoBuf(com.kodgames.corgi.protocol.Domineer proto)
        {
            this.domineerId = proto.domineerId;
            this.level = proto.level;
            return this;
        }

        public int DomineerId
        {
            get
            {
                return this.domineerId;
            }
            set
            {
                this.domineerId = value;
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
    }
}

