namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Attachment
    {
        private int count;
        private int id;

        public WeihuaGames.ClientClass.Attachment FromProtocolBuf(com.kodgames.corgi.protocol.Attachment attachmentProto)
        {
            this.id = attachmentProto.id;
            this.count = attachmentProto.count;
            return this;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
    }
}

