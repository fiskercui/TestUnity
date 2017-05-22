namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Dungeon
    {
        private int bestRecord;
        private int dungeonDialogState;
        private int dungeonId;
        private int dungeonStatus;
        private DynamicInt todayAlreadyResetTimes = new DynamicInt();
        private DynamicInt todayCompleteTimes = new DynamicInt();

        public void CopyDungeon(WeihuaGames.ClientClass.Dungeon dungeon)
        {
            this.DungeonId = dungeon.DungeonId;
            this.TodayCompleteTimes = dungeon.TodayCompleteTimes;
            this.todayAlreadyResetTimes = dungeon.todayAlreadyResetTimes;
            this.BestRecord = dungeon.BestRecord;
            this.DungeonStatus = dungeon.DungeonStatus;
            this.DungeonDialogState = dungeon.DungeonDialogState;
        }

        public WeihuaGames.ClientClass.Dungeon FromProtobuf(com.kodgames.corgi.protocol.Dungeon dungeon)
        {
            if (dungeon != null)
            {
                this.bestRecord = dungeon.bestRecord;
                this.dungeonId = dungeon.dungeonId;
                this.todayCompleteTimes = dungeon.todayCompleteTimes;
                this.todayAlreadyResetTimes = dungeon.todayAlreadyResetTimes;
                this.dungeonStatus = dungeon.dungeonStatus;
                this.dungeonDialogState = dungeon.dialogState;
            }
            return this;
        }

        public int BestRecord
        {
            get
            {
                return this.bestRecord;
            }
            set
            {
                this.bestRecord = value;
            }
        }

        public int DungeonDialogState
        {
            get
            {
                return this.dungeonDialogState;
            }
            set
            {
                this.dungeonDialogState = value;
            }
        }

        public int DungeonId
        {
            get
            {
                return this.dungeonId;
            }
            set
            {
                this.dungeonId = value;
            }
        }

        public int DungeonStatus
        {
            get
            {
                return this.dungeonStatus;
            }
            set
            {
                this.dungeonStatus = value;
            }
        }

        public int TodayAlreadyResetTimes
        {
            get
            {
                return (int) this.todayAlreadyResetTimes;
            }
            set
            {
                this.todayAlreadyResetTimes = value;
            }
        }

        public int TodayCompleteTimes
        {
            get
            {
                return (int) this.todayCompleteTimes;
            }
            set
            {
                this.todayCompleteTimes = value;
            }
        }
    }
}

