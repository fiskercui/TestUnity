namespace WeihuaGames.ClientClass
{
    using System;

    public class TimerIncreaseValue
    {
        private long lastModifyTime;
        private DynamicInt value;

        public TimerIncreaseValue()
        {
            this.value = new DynamicInt();
        }

        public TimerIncreaseValue(int value, long lastIncreaseTime)
        {
            this.value = new DynamicInt();
            this.value = value;
            this.lastModifyTime = lastIncreaseTime;
        }

        public int ModifyValue(int delta, long modifyTime)
        {
            this.value = Math.Max(0, ((int) this.value) + delta);
            this.lastModifyTime = modifyTime;
            return (int) this.value;
        }

        public int UpdateValue(int value, long modifyTime)
        {
            this.value = value;
            this.lastModifyTime = modifyTime;
            return (int) this.value;
        }

        public long LastModifyTime
        {
            get
            {
                return this.lastModifyTime;
            }
            set
            {
                this.lastModifyTime = value;
            }
        }

        public int Value
        {
            get
            {
                return (int) this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}

