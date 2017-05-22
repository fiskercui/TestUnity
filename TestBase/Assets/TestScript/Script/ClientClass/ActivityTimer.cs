namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class ActivityTimer
    {
        private int status;
        private long timer;

        public WeihuaGames.ClientClass.ActivityTimer FromBuffer(com.kodgames.corgi.protocol.ActivityTimer activityTimer)
        {
            if (activityTimer != null)
            {
                this.timer = activityTimer.timer;
                this.status = activityTimer.status;
            }
            return this;
        }

        public bool IsEqual(object obj)
        {
            if (!(obj is WeihuaGames.ClientClass.ActivityTimer))
            {
                return false;
            }
            WeihuaGames.ClientClass.ActivityTimer timer = obj as WeihuaGames.ClientClass.ActivityTimer;
            return ((this.timer == timer.timer) && (this.status == timer.status));
        }

        public int Status
        {
            get
            {
                return this.status;
            }
        }

        public long Timer
        {
            get
            {
                return this.timer;
            }
        }
    }
}

