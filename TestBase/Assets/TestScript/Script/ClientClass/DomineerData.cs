namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class DomineerData
    {
        private List<WeihuaGames.ClientClass.Domineer> domineers = new List<WeihuaGames.ClientClass.Domineer>();
        private List<WeihuaGames.ClientClass.Domineer> unsaveDomineers = new List<WeihuaGames.ClientClass.Domineer>();

        public WeihuaGames.ClientClass.DomineerData FromProtoBuf(com.kodgames.corgi.protocol.DomineerData proto)
        {
            if (proto.unsaveDomineers != null)
            {
                foreach (com.kodgames.corgi.protocol.Domineer domineer in proto.unsaveDomineers)
                {
                    WeihuaGames.ClientClass.Domineer item = new WeihuaGames.ClientClass.Domineer();
                    item.FromProtoBuf(domineer);
                    this.unsaveDomineers.Add(item);
                }
            }
            if (proto.domineers != null)
            {
                foreach (com.kodgames.corgi.protocol.Domineer domineer3 in proto.domineers)
                {
                    WeihuaGames.ClientClass.Domineer domineer4 = new WeihuaGames.ClientClass.Domineer();
                    domineer4.FromProtoBuf(domineer3);
                    this.domineers.Add(domineer4);
                }
            }
            return this;
        }

        public List<WeihuaGames.ClientClass.Domineer> Domineers
        {
            get
            {
                return this.domineers;
            }
            set
            {
                this.domineers = value;
            }
        }

        public List<WeihuaGames.ClientClass.Domineer> UnsaveDomineers
        {
            get
            {
                return this.unsaveDomineers;
            }
            set
            {
                this.unsaveDomineers = value;
            }
        }
    }
}

