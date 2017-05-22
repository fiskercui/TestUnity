namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class PropertyModifierSet
    {
        private int level;
        private List<WeihuaGames.ClientClass.PropertyModifier> modifiers = new List<WeihuaGames.ClientClass.PropertyModifier>();

        public WeihuaGames.ClientClass.PropertyModifierSet FromProtobuf(com.kodgames.corgi.protocol.PropertyModifierSet propertyModifierSet)
        {
            if (propertyModifierSet != null)
            {
                this.level = propertyModifierSet.levelFilter;
                this.modifiers.Clear();
                if (propertyModifierSet.modifiers != null)
                {
                    foreach (com.kodgames.corgi.protocol.PropertyModifier modifier in propertyModifierSet.modifiers)
                    {
                        WeihuaGames.ClientClass.PropertyModifier item = new WeihuaGames.ClientClass.PropertyModifier();
                        item.FromProtobuf(modifier);
                        this.modifiers.Add(item);
                    }
                }
            }
            return this;
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
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

