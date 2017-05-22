namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class WolfSmokeAddition
    {
        private int affectType;
        private List<WeihuaGames.ClientClass.PropertyModifier> modifiers = new List<WeihuaGames.ClientClass.PropertyModifier>();

        public WeihuaGames.ClientClass.WolfSmokeAddition FromProtobuf(com.kodgames.corgi.protocol.WolfSmokeAddition wolfSmokeAddition)
        {
            if (wolfSmokeAddition != null)
            {
                this.affectType = wolfSmokeAddition.affectType;
                foreach (com.kodgames.corgi.protocol.PropertyModifier modifier in wolfSmokeAddition.modifiers)
                {
                    WeihuaGames.ClientClass.PropertyModifier modifier2 = new WeihuaGames.ClientClass.PropertyModifier();
                    this.modifiers.Add(modifier2.FromProtobuf(modifier));
                }
            }
            return this;
        }

        public int AffectType
        {
            get
            {
                return this.affectType;
            }
            set
            {
                this.affectType = value;
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
    }
}

