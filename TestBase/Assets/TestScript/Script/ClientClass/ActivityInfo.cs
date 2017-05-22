namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class ActivityInfo
    {
        private long closeTime;
        private long openTime;
        private List<WeihuaGames.ClientClass.ActivityTimer> times = new List<WeihuaGames.ClientClass.ActivityTimer>();

        public WeihuaGames.ClientClass.ActivityInfo FromBuffer(com.kodgames.corgi.protocol.ActivityInfo activityInfo)
        {
            this.openTime = activityInfo.openTime;
            this.closeTime = activityInfo.closeTime;
            this.times.Clear();
            if ((activityInfo.times != null) && (activityInfo.times.Count > 0))
            {
                foreach (com.kodgames.corgi.protocol.ActivityTimer timer in activityInfo.times)
                {
                    WeihuaGames.ClientClass.ActivityTimer item = new WeihuaGames.ClientClass.ActivityTimer();
                    item.FromBuffer(timer);
                    this.times.Add(item);
                }
            }
            return this;
        }

        public List<WeihuaGames.ClientClass.ActivityTimer> GetTimersByStatus(int status)
        {
            List<WeihuaGames.ClientClass.ActivityTimer> list = new List<WeihuaGames.ClientClass.ActivityTimer>();
            foreach (WeihuaGames.ClientClass.ActivityTimer timer in this.times)
            {
                if ((timer.Status & status) == status)
                {
                    list.Add(timer);
                }
            }
            return list;
        }

        public bool IsEqual(object obj)
        {
            if (!(obj is WeihuaGames.ClientClass.ActivityInfo))
            {
                return false;
            }
            WeihuaGames.ClientClass.ActivityInfo info = obj as WeihuaGames.ClientClass.ActivityInfo;
            if (((this.openTime != info.OpenTime) || (this.closeTime != info.CloseTime)) || (this.times.Count != info.times.Count))
            {
                return false;
            }
            for (int i = 0; i < this.times.Count; i++)
            {
                if (!this.times[i].IsEqual(info.times[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public long CloseTime
        {
            get
            {
                return this.closeTime;
            }
        }

        public long OpenTime
        {
            get
            {
                return this.openTime;
            }
        }
    }
}

