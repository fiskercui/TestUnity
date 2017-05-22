namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Equipment
    {
        private DynamicInt breakthoughtLevel = new DynamicInt();
        private string guid;
        private bool isAssembleActive;
        private WeihuaGames.ClientClass.LevelAttrib levelAttrib = new WeihuaGames.ClientClass.LevelAttrib();
        private int resourceId;

        public WeihuaGames.ClientClass.Equipment FromProtobuf(com.kodgames.corgi.protocol.Equipment equipment)
        {
            if (equipment != null)
            {
                this.breakthoughtLevel = equipment.breakthoughtLevel;
                this.guid = equipment.guid;
                this.resourceId = equipment.resourceId;
                this.levelAttrib.FromProtobuf(equipment.levelAttrib);
            }
            return this;
        }

        public int BreakthoughtLevel
        {
            get
            {
                return (int) this.breakthoughtLevel;
            }
            set
            {
                this.breakthoughtLevel = value;
            }
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

        public bool IsAssembleActive
        {
            get
            {
                return this.isAssembleActive;
            }
            set
            {
                this.isAssembleActive = value;
            }
        }

        public WeihuaGames.ClientClass.LevelAttrib LevelAttrib
        {
            get
            {
                return this.levelAttrib;
            }
            set
            {
                this.levelAttrib = value;
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

