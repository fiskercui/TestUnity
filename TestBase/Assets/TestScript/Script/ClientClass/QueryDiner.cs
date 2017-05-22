namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class QueryDiner
    {
        private int avatarResourceId;
        private int breakThroughLevel;
        private List<WeihuaGames.ClientClass.Cost> costs = new List<WeihuaGames.ClientClass.Cost>();
        private int dinerId;
        private WeihuaGames.ClientClass.DomineerData domineerData = new WeihuaGames.ClientClass.DomineerData();
        private int level;
        private List<WeihuaGames.ClientClass.MeridianData> meridianDatas = new List<WeihuaGames.ClientClass.MeridianData>();
        private int state;

        public WeihuaGames.ClientClass.QueryDiner FromProtoBuf(com.kodgames.corgi.protocol.QueryDiner proto)
        {
            if (proto != null)
            {
                this.dinerId = proto.dinerId;
                this.avatarResourceId = proto.avatarResourceId;
                this.level = proto.level;
                this.breakThroughLevel = proto.breakThroughLevel;
                this.state = proto.state;
                if (proto.meridianDatas != null)
                {
                    foreach (com.kodgames.corgi.protocol.MeridianData data in proto.meridianDatas)
                    {
                        this.meridianDatas.Add(new WeihuaGames.ClientClass.MeridianData().FromProtoBuf(data));
                    }
                }
                if (proto.domineerData != null)
                {
                    this.domineerData = this.DomineerData.FromProtoBuf(proto.domineerData);
                }
                if (proto.costs != null)
                {
                    foreach (com.kodgames.corgi.protocol.Cost cost in proto.costs)
                    {
                        this.costs.Add(new WeihuaGames.ClientClass.Cost().FromProtobuf(cost));
                    }
                }
            }
            return this;
        }

        public void ShallowCopy(WeihuaGames.ClientClass.QueryDiner queryDiner)
        {
            if (queryDiner != null)
            {
                this.dinerId = queryDiner.dinerId;
                this.avatarResourceId = queryDiner.avatarResourceId;
                this.level = queryDiner.level;
                this.breakThroughLevel = queryDiner.breakThroughLevel;
                this.state = queryDiner.state;
                this.meridianDatas = queryDiner.meridianDatas;
                this.domineerData = queryDiner.domineerData;
                this.costs = queryDiner.costs;
            }
        }

        public int AvatarResourceId
        {
            get
            {
                return this.avatarResourceId;
            }
            set
            {
                this.AvatarResourceId = value;
            }
        }

        public int BreakThroughLevel
        {
            get
            {
                return this.breakThroughLevel;
            }
            set
            {
                this.breakThroughLevel = value;
            }
        }

        public List<WeihuaGames.ClientClass.Cost> Costs
        {
            get
            {
                return this.costs;
            }
            set
            {
                this.costs = value;
            }
        }

        public int DinerId
        {
            get
            {
                return this.dinerId;
            }
            set
            {
                this.dinerId = value;
            }
        }

        public WeihuaGames.ClientClass.DomineerData DomineerData
        {
            get
            {
                return this.domineerData;
            }
            set
            {
                this.domineerData = value;
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

