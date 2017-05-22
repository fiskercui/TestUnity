namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class Avatar
    {
        private WeihuaGames.ClientClass.Attribute attributes = new WeihuaGames.ClientClass.Attribute();
        private DynamicInt breakthoughtLevel = new DynamicInt();
        private WeihuaGames.ClientClass.DomineerData domineer = new WeihuaGames.ClientClass.DomineerData();
        private string guid;
        private bool isAvatar;
        private WeihuaGames.ClientClass.LevelAttrib levelAttrib = new WeihuaGames.ClientClass.LevelAttrib();
        private List<WeihuaGames.ClientClass.MeridianData> meridianDatas = new List<WeihuaGames.ClientClass.MeridianData>();
        private string name;
        private int resourceId;
        private int traitType;

        public void FromProtobuf(com.kodgames.corgi.protocol.Avatar avatar)
        {
            this.breakthoughtLevel = avatar.breakthoughtLevel;
            this.guid = avatar.guid;
            this.resourceId = avatar.resourceId;
            if (avatar.levelAttrib != null)
            {
                this.levelAttrib.FromProtobuf(avatar.levelAttrib);
            }
            this.meridianDatas.Clear();
            if (avatar.meridianData != null)
            {
                foreach (com.kodgames.corgi.protocol.MeridianData data in avatar.meridianData)
                {
                    WeihuaGames.ClientClass.MeridianData item = new WeihuaGames.ClientClass.MeridianData();
                    item.FromProtoBuf(data);
                    this.meridianDatas.Add(item);
                }
            }
            if (avatar.domineerData != null)
            {
                this.domineer.FromProtoBuf(avatar.domineerData);
            }
            this.isAvatar = avatar.isAvatar;
            this.traitType = avatar.traitType;
            this.name = avatar.name;
        }

        public WeihuaGames.ClientClass.MeridianData GetMeridianByID(int id)
        {
            for (int i = 0; i < this.meridianDatas.Count; i++)
            {
                if (this.meridianDatas[i].Id == id)
                {
                    return this.meridianDatas[i];
                }
            }
            return null;
        }

        public void SaveMeridianData(int meridianId, List<WeihuaGames.ClientClass.PropertyModifier> modifiers, int buffId)
        {
            WeihuaGames.ClientClass.MeridianData item = null;
            for (int i = 0; i < this.meridianDatas.Count; i++)
            {
                if (this.meridianDatas[i].Id == meridianId)
                {
                    item = this.meridianDatas[i];
                }
            }
            if (item == null)
            {
                item = new WeihuaGames.ClientClass.MeridianData {
                    Id = meridianId,
                    BufferId = buffId
                };
                this.meridianDatas.Add(item);
            }
            if (item.Modifiers == null)
            {
                item.Modifiers = new List<WeihuaGames.ClientClass.PropertyModifier>();
            }
            item.Modifiers.Clear();
            foreach (WeihuaGames.ClientClass.PropertyModifier modifier in modifiers)
            {
                WeihuaGames.ClientClass.PropertyModifier modifier2 = new WeihuaGames.ClientClass.PropertyModifier();
                modifier2.CopyValue(modifier);
                item.Modifiers.Add(modifier2);
            }
        }

        public void ShallowCopy(WeihuaGames.ClientClass.Avatar avatar)
        {
            this.guid = avatar.Guid;
            this.resourceId = avatar.ResourceId;
            this.levelAttrib.Level = avatar.LevelAttrib.Level;
            this.levelAttrib.Experience = avatar.LevelAttrib.Experience;
            this.BreakthoughtLevel = avatar.BreakthoughtLevel;
            this.attributes = avatar.Attributes;
            this.meridianDatas = avatar.meridianDatas;
            this.domineer = avatar.domineer;
            this.isAvatar = avatar.isAvatar;
            this.traitType = avatar.traitType;
            this.name = avatar.name;
        }

        public WeihuaGames.ClientClass.Attribute Attributes
        {
            get
            {
                return this.attributes;
            }
            set
            {
                this.attributes = value;
            }
        }

        public int BreakthoughtLevel
        {
            get
            {
                return (int) this.breakthoughtLevel;
            }
            set
            {
                this.breakthoughtLevel = value;
            }
        }

        public WeihuaGames.ClientClass.DomineerData Domineer
        {
            get
            {
                return this.domineer;
            }
            set
            {
                this.domineer = value;
            }
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

        public bool IsAvatar
        {
            get
            {
                return this.isAvatar;
            }
            set
            {
                this.isAvatar = value;
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

        public List<WeihuaGames.ClientClass.MeridianData> MeridianDatas
        {
            get
            {
                return this.meridianDatas;
            }
            set
            {
                this.meridianDatas = value;
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

