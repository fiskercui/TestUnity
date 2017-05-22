namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class RecruiteNpc
    {
        private List<WeihuaGames.ClientClass.Attribute> attributes = new List<WeihuaGames.ClientClass.Attribute>();
        private int avatarId;
        private int breakthroughLevel;
        private int level;
        private string name;
        private string npcDesc;
        private int npcId;
        private int qualityType;
        private List<int> skillIds = new List<int>();
        private int traitType;

        public WeihuaGames.ClientClass.RecruiteNpc FromProtobuf(com.kodgames.corgi.protocol.RecruiteNpc recruiteNpc)
        {
            if (recruiteNpc != null)
            {
                this.npcId = recruiteNpc.npcId;
                this.avatarId = recruiteNpc.avatarId;
                this.name = recruiteNpc.name;
                this.level = recruiteNpc.level;
                this.traitType = recruiteNpc.traitType;
                this.breakthroughLevel = recruiteNpc.breakthroughLevel;
                this.qualityType = recruiteNpc.qualityType;
                this.npcDesc = recruiteNpc.npcDesc;
                foreach (int num in recruiteNpc.skillIds)
                {
                    this.skillIds.Add(num);
                }
                foreach (com.kodgames.corgi.protocol.Attribute attribute in recruiteNpc.attributes)
                {
                    WeihuaGames.ClientClass.Attribute item = new WeihuaGames.ClientClass.Attribute();
                    item.FromProtobuf(attribute);
                    this.attributes.Add(item);
                }
            }
            return this;
        }

        public void ShallowCopy(WeihuaGames.ClientClass.RecruiteNpc recruiteNpc)
        {
            this.avatarId = recruiteNpc.avatarId;
            this.name = recruiteNpc.name;
            this.level = recruiteNpc.level;
            this.npcId = recruiteNpc.npcId;
            this.traitType = recruiteNpc.traitType;
            this.breakthroughLevel = recruiteNpc.breakthroughLevel;
            this.qualityType = recruiteNpc.qualityType;
            this.npcDesc = recruiteNpc.npcDesc;
            this.skillIds.Clear();
            foreach (int num in recruiteNpc.skillIds)
            {
                this.skillIds.Add(num);
            }
            this.attributes.Clear();
            foreach (WeihuaGames.ClientClass.Attribute attribute in recruiteNpc.attributes)
            {
                WeihuaGames.ClientClass.Attribute item = new WeihuaGames.ClientClass.Attribute();
                item.Copy(attribute);
                this.attributes.Add(item);
            }
        }

        public List<WeihuaGames.ClientClass.Attribute> Attributes
        {
            get
            {
                return this.attributes;
            }
        }

        public int AvatarId
        {
            get
            {
                return this.avatarId;
            }
            set
            {
                this.avatarId = value;
            }
        }

        public int BreakthroughLevel
        {
            get
            {
                return this.breakthroughLevel;
            }
            set
            {
                this.breakthroughLevel = value;
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

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string NpcDesc
        {
            get
            {
                return this.npcDesc;
            }
            set
            {
                this.npcDesc = value;
            }
        }

        public int NpcId
        {
            get
            {
                return this.npcId;
            }
            set
            {
                this.npcId = value;
            }
        }

        public int QualityType
        {
            get
            {
                return this.qualityType;
            }
            set
            {
                this.qualityType = value;
            }
        }

        public List<int> SkillIds
        {
            get
            {
                return this.skillIds;
            }
            set
            {
                this.skillIds = value;
            }
        }

        public int TraitType
        {
            get
            {
                return this.traitType;
            }
            set
            {
                this.traitType = value;
            }
        }
    }
}

