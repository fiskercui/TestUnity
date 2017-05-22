namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class SignData
    {
        private DynamicInt freeSignCount = new DynamicInt();
        private DynamicInt remedySignCount = new DynamicInt();
        private int serverTime;
        private int signCount;
        private int signDetails;

        public void FromProtobuf(com.kodgames.corgi.protocol.SignData signData)
        {
            this.signDetails = signData.signDetails;
            this.serverTime = signData.serverTime;
            this.signCount = signData.signCount;
            this.freeSignCount = signData.freeSignCount;
            this.remedySignCount = signData.remedySignCount;
        }

        public int GetMonth()
        {
            return ((this.ServerTime % 0x2710) / 100);
        }

        public int FreeSignCount
        {
            get
            {
                return (int) this.freeSignCount;
            }
            set
            {
                this.freeSignCount = value;
            }
        }

        public int RemedySignCount
        {
            get
            {
                return (int) this.remedySignCount;
            }
            set
            {
                this.remedySignCount = value;
            }
        }

        public int ServerTime
        {
            get
            {
                return this.serverTime;
            }
            set
            {
                this.serverTime = value;
            }
        }

        public int SignCount
        {
            get
            {
                return this.signCount;
            }
            set
            {
                this.signCount = value;
            }
        }

        public int SignDetails
        {
            get
            {
                return this.signDetails;
            }
            set
            {
                this.signDetails = value;
            }
        }
    }
}

