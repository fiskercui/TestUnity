namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class DanAttributeGroup
    {
        private string attributeDesc;
        private List<WeihuaGames.ClientClass.DanAttribute> danAttributes = new List<WeihuaGames.ClientClass.DanAttribute>();
        private int id;

        public WeihuaGames.ClientClass.DanAttributeGroup FromProtobuf(com.kodgames.corgi.protocol.DanAttributeGroup danAttributeGroup)
        {
            if (danAttributeGroup != null)
            {
                this.id = danAttributeGroup.id;
                this.attributeDesc = danAttributeGroup.attributeDesc;
                this.danAttributes.Clear();
                if (danAttributeGroup.danAttributes != null)
                {
                    foreach (com.kodgames.corgi.protocol.DanAttribute attribute in danAttributeGroup.danAttributes)
                    {
                        WeihuaGames.ClientClass.DanAttribute item = new WeihuaGames.ClientClass.DanAttribute();
                        item.FromProtobuf(attribute);
                        this.danAttributes.Add(item);
                    }
                }
            }
            return this;
        }

        public string AttributeDesc
        {
            get
            {
                return this.attributeDesc;
            }
            set
            {
                this.attributeDesc = value;
            }
        }

        public List<WeihuaGames.ClientClass.DanAttribute> DanAttributes
        {
            get
            {
                return this.danAttributes;
            }
            set
            {
                this.danAttributes = value;
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

