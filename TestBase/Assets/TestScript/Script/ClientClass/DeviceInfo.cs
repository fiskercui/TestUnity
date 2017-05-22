namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class DeviceInfo
    {
        private string deviceName;
        private int deviceType;
        private string osType;
        private string osVersion;
        private string udid;

        public void FromProtobuf(com.kodgames.corgi.protocol.DeviceInfo deviceInfo)
        {
            this.DeviceType = deviceInfo.deviceType;
            this.Udid = deviceInfo.UDID;
            this.OsType = deviceInfo.OSType;
            this.OsVersion = deviceInfo.OSVersion;
            this.DeviceName = deviceInfo.deviceName;
        }

        public com.kodgames.corgi.protocol.DeviceInfo ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.DeviceInfo { 
                deviceType = this.deviceType,
                OSType = this.osType,
                OSVersion = this.osVersion,
                UDID = this.udid,
                deviceName = this.deviceName
            };
        }

        public string DeviceName
        {
            get
            {
                return this.deviceName;
            }
            set
            {
                this.deviceName = value;
            }
        }

        public int DeviceType
        {
            get
            {
                return this.deviceType;
            }
            set
            {
                this.deviceType = value;
            }
        }

        public string OsType
        {
            get
            {
                return this.osType;
            }
            set
            {
                this.osType = value;
            }
        }

        public string OsVersion
        {
            get
            {
                return this.osVersion;
            }
            set
            {
                this.osVersion = value;
            }
        }

        public string Udid
        {
            get
            {
                return this.udid;
            }
            set
            {
                this.udid = value;
            }
        }
    }
}

