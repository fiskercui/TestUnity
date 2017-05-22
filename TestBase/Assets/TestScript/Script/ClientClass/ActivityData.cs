namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class ActivityData
    {
        private int activityId;
        private List<WeihuaGames.ClientClass.ActivityInfo> activityInfos = new List<WeihuaGames.ClientClass.ActivityInfo>();
        private int activityType;

        public void FromProtobuf(com.kodgames.corgi.protocol.ActivityData activityData)
        {
            if (activityData != null)
            {
                this.activityType = activityData.activityType;
                this.activityId = activityData.activityId;
                this.activityInfos.Clear();
                if ((activityData.activityData != null) && (activityData.activityData.Count > 0))
                {
                    foreach (com.kodgames.corgi.protocol.ActivityInfo info in activityData.activityData)
                    {
                        WeihuaGames.ClientClass.ActivityInfo item = new WeihuaGames.ClientClass.ActivityInfo();
                        item.FromBuffer(info);
                        this.activityInfos.Add(item);
                    }
                }
            }
        }

        public int ActivityId
        {
            get
            {
                return this.activityId;
            }
        }

        public List<WeihuaGames.ClientClass.ActivityInfo> ActivityInfos
        {
            get
            {
                return this.activityInfos;
            }
        }

        public int ActivityType
        {
            get
            {
                return this.activityType;
            }
        }
    }
}

