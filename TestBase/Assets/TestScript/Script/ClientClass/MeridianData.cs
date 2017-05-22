namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class MeridianData
    {
        private int bufferId;
        private int id;
        private List<WeihuaGames.ClientClass.PropertyModifier> modifiers = new List<WeihuaGames.ClientClass.PropertyModifier>();
        private int times;

        public WeihuaGames.ClientClass.MeridianData FromProtoBuf(com.kodgames.corgi.protocol.MeridianData proto)
        {
            this.id = proto.id;
            this.times = proto.times;
            this.bufferId = proto.bufferId;
            this.modifiers.Clear();
            foreach (com.kodgames.corgi.protocol.PropertyModifier modifier in proto.modifiers)
            {
                this.modifiers.Add(new WeihuaGames.ClientClass.PropertyModifier().FromProtobuf(modifier));
            }
            return this;
        }

        public int BufferId
        {
            get
            {
                return this.bufferId;
            }
            set
            {
                this.bufferId = value;
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

        public List<WeihuaGames.ClientClass.PropertyModifier> Modifiers
        {
            get
            {
                return this.modifiers;
            }
            set
            {
                this.modifiers = value;
            }
        }

        public int Times
        {
            get
            {
                return this.times;
            }
            set
            {
                this.times = value;
            }
        }
    }
}

