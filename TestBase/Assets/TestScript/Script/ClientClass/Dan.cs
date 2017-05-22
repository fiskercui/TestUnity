namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class Dan
    {
        private List<int> attributeIds = new List<int>();
        private DynamicInt breakthoughtLevel = new DynamicInt();
        private long createTime;
        private List<WeihuaGames.ClientClass.DanAttributeGroup> danAttributeGroups = new List<WeihuaGames.ClientClass.DanAttributeGroup>();
        private float danPower;
        private string guid;
        private WeihuaGames.ClientClass.LevelAttrib levelAttrib = new WeihuaGames.ClientClass.LevelAttrib();
        private bool locked;
        private int resourceId;
        private int type;

        public WeihuaGames.ClientClass.Dan FromProtobuf(com.kodgames.corgi.protocol.Dan dan)
        {
            if (dan != null)
            {
                this.breakthoughtLevel = dan.breakthoughtLevel;
                this.guid = dan.guid;
                this.resourceId = dan.resourceId;
                this.levelAttrib.FromProtobuf(dan.levelAttrib);
                this.type = dan.type;
                this.locked = dan.locked;
                this.createTime = dan.createTime;
                this.danPower = dan.danPower;
                this.AttributeIds.Clear();
                if (dan.attributeIds != null)
                {
                    foreach (int num in dan.attributeIds)
                    {
                        this.AttributeIds.Add(num);
                    }
                }
                this.danAttributeGroups.Clear();
                if (dan.danAttributeGroups != null)
                {
                    foreach (com.kodgames.corgi.protocol.DanAttributeGroup group in dan.danAttributeGroups)
                    {
                        WeihuaGames.ClientClass.DanAttributeGroup item = new WeihuaGames.ClientClass.DanAttributeGroup();
                        item.FromProtobuf(group);
                        this.danAttributeGroups.Add(item);
                    }
                }
            }
            return this;
        }

        public List<int> AttributeIds
        {
            get
            {
                return this.attributeIds;
            }
            set
            {
                this.attributeIds = value;
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

        public long CreateTime
        {
            get
            {
                return this.createTime;
            }
            set
            {
                this.createTime = value;
            }
        }

        public List<WeihuaGames.ClientClass.DanAttributeGroup> DanAttributeGroups
        {
            get
            {
                return this.danAttributeGroups;
            }
            set
            {
                this.danAttributeGroups = value;
            }
        }

        public float DanPower
        {
            get
            {
                return this.danPower;
            }
            set
            {
                this.danPower = value;
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

        public bool Locked
        {
            get
            {
                return this.locked;
            }
            set
            {
                this.locked = value;
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

        public int Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

