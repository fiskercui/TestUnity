namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class HpInfo
    {
        private string guid;
        private double leftHP;
        private int locationId;
        private int resourceId;

        public WeihuaGames.ClientClass.HpInfo FromProtobuf(com.kodgames.corgi.protocol.HpInfo hpInfo)
        {
            if (hpInfo != null)
            {
                this.guid = hpInfo.guid;
                this.resourceId = hpInfo.resourceId;
                this.leftHP = hpInfo.leftHP;
                this.locationId = hpInfo.locationId;
            }
            return this;
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

        public double LeftHP
        {
            get
            {
                return this.leftHP;
            }
            set
            {
                this.leftHP = value;
            }
        }

        public int LocationId
        {
            get
            {
                return this.locationId;
            }
            set
            {
                this.locationId = value;
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

