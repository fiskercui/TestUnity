namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class StartServerRewardInfo
    {
        private int dayCount;
        private long loginTime;
        private List<int> unPickIds = new List<int>();

        public WeihuaGames.ClientClass.StartServerRewardInfo FromProtoBuf(com.kodgames.corgi.protocol.StartServerRewardInfo protoInfo)
        {
            if (protoInfo == null)
            {
                return null;
            }
            this.dayCount = protoInfo.dayCont;
            if (protoInfo.unPickIds != null)
            {
                this.unPickIds = protoInfo.unPickIds;
            }
            return this;
        }

        public int DayCount
        {
            get
            {
                return this.dayCount;
            }
            set
            {
                this.dayCount = value;
            }
        }

        public long LoginTime
        {
            get
            {
                return this.loginTime;
            }
            set
            {
                this.loginTime = value;
            }
        }

        public List<int> UnPickIds
        {
            get
            {
                return this.unPickIds;
            }
            set
            {
                this.unPickIds = value;
            }
        }
    }
}

