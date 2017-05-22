namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Attribute
    {
        private int type;
        private DynamicDouble value;

        public void Copy(WeihuaGames.ClientClass.Attribute attrib)
        {
            this.type = attrib.type;
            this.value = attrib.value;
        }

        public WeihuaGames.ClientClass.Attribute FromProtobuf(com.kodgames.corgi.protocol.Attribute attribute)
        {
            this.type = attribute.type;
            this.value = attribute.value;
            return this;
        }

        public com.kodgames.corgi.protocol.Attribute ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.Attribute { 
                type = this.type,
                value = (double) this.value
            };
        }

        public int Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public double Value
        {
            get
            {
                return (double) this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}

