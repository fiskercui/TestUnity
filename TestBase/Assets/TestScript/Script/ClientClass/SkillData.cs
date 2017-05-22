namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class SkillData
    {
        private int id;
        private int level;

        public void Copy(WeihuaGames.ClientClass.SkillData skillData)
        {
            this.id = skillData.id;
            this.level = skillData.level;
        }

        public WeihuaGames.ClientClass.SkillData FromProtobuf(com.kodgames.corgi.protocol.SkillData protocol)
        {
            this.id = protocol.id;
            this.level = protocol.level;
            return this;
        }

        public com.kodgames.corgi.protocol.SkillData ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.SkillData { 
                id = this.id,
                level = this.level
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

