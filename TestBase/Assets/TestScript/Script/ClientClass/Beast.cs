namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class Beast
    {
        private int breakthoughtLevel;
        private string guid;
        private WeihuaGames.ClientClass.LevelAttrib levelAttrib = new WeihuaGames.ClientClass.LevelAttrib();
        private List<int> partIndexs = new List<int>();
        private int resourceId;

        public WeihuaGames.ClientClass.Beast FromProtobuf(com.kodgames.corgi.protocol.Beast beast)
        {
            if (beast != null)
            {
                this.guid = beast.guid;
                this.resourceId = beast.resourceId;
                if (beast.levelAttrib != null)
                {
                    this.levelAttrib.FromProtobuf(beast.levelAttrib);
                }
                this.breakthoughtLevel = beast.breakthoughtLevel;
                if (beast.partIndexs != null)
                {
                    List<int> list = new List<int>();
                    foreach (int num in beast.partIndexs)
                    {
                        list.Add(num);
                    }
                    this.partIndexs = list;
                }
            }
            return this;
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

        public List<int> PartIndexs
        {
            get
            {
                return this.partIndexs;
            }
            set
            {
                this.partIndexs = value;
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

