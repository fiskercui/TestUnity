namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class ConfigParameter
    {
        public string name;
        public string value;

        public static WeihuaGames.ClientClass.ConfigParameter CopyTo(WeihuaGames.ClientClass.ConfigParameter theOne)
        {
            return new WeihuaGames.ClientClass.ConfigParameter { 
                name = theOne.name,
                value = theOne.value
            };
        }

        public WeihuaGames.ClientClass.ConfigParameter FromProtobuf(com.kodgames.corgi.protocol.ConfigParameter configParameter)
        {
            this.name = configParameter.name;
            this.value = configParameter.value;
            return this;
        }

        public com.kodgames.corgi.protocol.ConfigParameter ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.ConfigParameter { 
                name = this.name,
                value = this.value
            };
        }
    }
}

