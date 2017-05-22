namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Skill
    {
        private string guid;
        private bool isAssembleActive;
        private WeihuaGames.ClientClass.LevelAttrib levelAttrib = new WeihuaGames.ClientClass.LevelAttrib();
        private int resourceId;

        public void Copy(WeihuaGames.ClientClass.Skill skill)
        {
            this.guid = skill.guid;
            this.resourceId = skill.resourceId;
            this.levelAttrib.Copy(skill.levelAttrib);
        }

        public void FromProtobuf(com.kodgames.corgi.protocol.Skill skill)
        {
            this.guid = skill.guid;
            this.resourceId = skill.resourceId;
            this.levelAttrib.FromProtobuf(skill.levelAttrib);
        }

        public string Guid
        {
            get
            {
                return this.guid;
            }
            set
            {
                this.guid = value;
            }
        }

        public bool IsAssembleActive
        {
            get
            {
                return this.isAssembleActive;
            }
            set
            {
                this.isAssembleActive = value;
            }
        }

        public WeihuaGames.ClientClass.LevelAttrib LevelAttrib
        {
            get
            {
                return this.levelAttrib;
            }
            set
            {
                this.levelAttrib = value;
            }
        }

        public int ResourceId
        {
            get
            {
                return this.resourceId;
            }
            set
            {
                this.resourceId = value;
            }
        }
    }
}

