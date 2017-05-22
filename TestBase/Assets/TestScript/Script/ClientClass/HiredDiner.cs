namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class HiredDiner
    {
        private string avatarGuid;
        private int dinerId;
        private long endTime;
        private long hireTime;
        private int qualityType;
        private int state;

        public WeihuaGames.ClientClass.HiredDiner FromProtoBuf(com.kodgames.corgi.protocol.HiredDiner proto)
        {
            if (proto != null)
            {
                this.dinerId = proto.dinerId;
                this.qualityType = proto.qualityType;
                this.endTime = proto.endTime;
                this.state = proto.state;
                this.hireTime = proto.hireTime;
                this.avatarGuid = proto.avatarGuid;
            }
            return this;
        }

        public void ShallowCopy(WeihuaGames.ClientClass.HiredDiner hireDiner)
        {
            this.dinerId = hireDiner.dinerId;
            this.qualityType = hireDiner.qualityType;
            this.avatarGuid = hireDiner.avatarGuid;
            this.hireTime = hireDiner.hireTime;
            this.endTime = hireDiner.endTime;
            this.state = hireDiner.state;
        }

        public string AvatarGuid
        {
            get
            {
                return this.avatarGuid;
            }
            set
            {
                this.avatarGuid = value;
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

        public long EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
            }
        }

        public long HireTime
        {
            get
            {
                return this.hireTime;
            }
            set
            {
                this.hireTime = value;
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

