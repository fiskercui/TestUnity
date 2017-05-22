namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Area
    {
        private int areaID;
        private string areaName;
        private int areaStatus;
        private string interfaceServerIP;
        private int mergeAreaId;
        private int newAreaId;
        private int num;
        private int port;
        private int showAreaId;

        public void FromProtobuf(com.kodgames.corgi.protocol.Area area)
        {
            this.AreaID = area.areaID;
            this.AreaName = area.name;
            this.AreaStatus = area.status;
            this.InterfaceServerIP = area.interfaceServerIP;
            this.Port = area.interfaceServerPort;
            this.Nun = area.areaAvatarNumber;
            this.newAreaId = area.newAreaID;
            this.showAreaId = area.showAreaID;
            this.mergeAreaId = area.mergeAreaID;
        }

        public int AreaID
        {
            get
            {
                return this.areaID;
            }
            set
            {
                this.areaID = value;
            }
        }

        public string AreaName
        {
            get
            {
                return this.areaName;
            }
            set
            {
                this.areaName = value;
            }
        }

        public int AreaStatus
        {
            get
            {
                return this.areaStatus;
            }
            set
            {
                this.areaStatus = value;
            }
        }

        public string InterfaceServerIP
        {
            get
            {
                return this.interfaceServerIP;
            }
            set
            {
                this.interfaceServerIP = value;
            }
        }

        public int MergeAreaId
        {
            get
            {
                return this.mergeAreaId;
            }
            set
            {
                this.mergeAreaId = value;
            }
        }

        public int NewAreaId
        {
            get
            {
                return this.newAreaId;
            }
            set
            {
                this.newAreaId = value;
            }
        }

        public int Nun
        {
            get
            {
                return this.num;
            }
            set
            {
                this.num = value;
            }
        }

        public int Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }

        public int ShowAreaId
        {
            get
            {
                return this.showAreaId;
            }
            set
            {
                this.showAreaId = value;
            }
        }
    }
}

