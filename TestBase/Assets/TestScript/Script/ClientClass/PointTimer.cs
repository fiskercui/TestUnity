namespace WeihuaGames.ClientClass
{
    using System;

    public class PointTimer
    {
        private int generateTime;
        private int maxPoint;
        private TimerIncreaseValue point;

        public PointTimer()
        {
            this.point = new TimerIncreaseValue();
        }

        public PointTimer(TimerIncreaseValue point)
        {
            this.point = new TimerIncreaseValue();
            this.SetData(point, 0, 0);
        }

        public int GetFullGenerationLeftTime(long nowTime)
        {
            if (this.IsPointFull())
            {
                return 0;
            }
            return ((((this.maxPoint - this.point.Value) - 1) * this.generateTime) + this.GetNextGenerationLeftTime(nowTime));
        }

        public int GetNextGenerationLeftTime(long nowTime)
        {
            if (this.IsPointFull())
            {
                return 0;
            }
            return (this.generateTime - ((int) (nowTime - this.point.LastModifyTime)));
        }

        public bool IsPointFull()
        {
            return (this.point.Value >= this.maxPoint);
        }

        public void ModifyPoint(int delta, long modifyTime)
        {
            if ((delta < 0) && (this.point.Value >= this.maxPoint))
            {
                this.point.LastModifyTime = modifyTime;
            }
            this.point.Value = Math.Max(0, this.point.Value + delta);
        }

        public void SetData(TimerIncreaseValue point, int maxPoint, int generateTime)
        {
            this.Point = point;
            this.maxPoint = maxPoint;
            this.generateTime = generateTime;
        }

        public void UpdateMaxPoint(int maxPoint, long nowTime)
        {
            if ((this.point.Value >= this.maxPoint) && (this.point.Value < maxPoint))
            {
                this.point.LastModifyTime = nowTime;
            }
            this.maxPoint = maxPoint;
        }

        public bool UpdatePoint(long nowTime)
        {
            if (!this.IsPointFull() && ((nowTime - this.point.LastModifyTime) >= this.generateTime))
            {
                this.point.Value = (int) Math.Min(this.point.Value + ((nowTime - this.point.LastModifyTime) / ((long) this.generateTime)), (long) this.maxPoint);
                this.point.LastModifyTime += ((nowTime - this.point.LastModifyTime) / ((long) this.generateTime)) * this.generateTime;
                return true;
            }
            return false;
        }

        public int GenerateTime
        {
            get
            {
                return this.generateTime;
            }
            set
            {
                this.generateTime = value;
            }
        }

        public int MaxPoint
        {
            get
            {
                return this.maxPoint;
            }
            set
            {
                this.maxPoint = value;
            }
        }

        public TimerIncreaseValue Point
        {
            get
            {
                return this.point;
            }
            set
            {
                this.point = (value != null) ? value : new TimerIncreaseValue();
            }
        }
    }
}

