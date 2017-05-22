namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class LevelAttrib
    {
        private DynamicInt experience = new DynamicInt();
        private DynamicInt level = new DynamicInt();

        public void Copy(WeihuaGames.ClientClass.LevelAttrib levelAttrib)
        {
            this.Level = levelAttrib.Level;
            this.Experience = levelAttrib.Experience;
        }

        public WeihuaGames.ClientClass.LevelAttrib FromProtobuf(com.kodgames.corgi.protocol.LevelAttrib protocol)
        {
            this.level = protocol.level;
            this.experience = protocol.experience;
            return this;
        }

        public com.kodgames.corgi.protocol.LevelAttrib ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.LevelAttrib { 
                level = (int) this.level,
                experience = (int) this.experience
            };
        }

        public int Experience
        {
            get
            {
                return (int) this.experience;
            }
            set
            {
                this.experience = value;
            }
        }

        public int Level
        {
            get
            {
                return (int) this.level;
            }
            set
            {
                this.level = value;
            }
        }
    }
}

