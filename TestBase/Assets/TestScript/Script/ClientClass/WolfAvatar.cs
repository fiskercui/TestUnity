namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class WolfAvatar
    {
        private string guid;
        private double leftHP;
        private int resourceId;

        public WeihuaGames.ClientClass.WolfAvatar FromProtobuf(com.kodgames.corgi.protocol.WolfAvatar wolfAvatar)
        {
            if (wolfAvatar != null)
            {
                this.guid = wolfAvatar.guid;
                this.resourceId = wolfAvatar.resourceId;
                this.leftHP = wolfAvatar.leftHP;
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

