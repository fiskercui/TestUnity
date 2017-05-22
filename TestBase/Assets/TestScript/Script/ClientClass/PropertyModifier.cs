namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class PropertyModifier
    {
        private int attributeType;
        private float attributeValue;
        private int modifyType;
        private int type;

        public void CopyValue(WeihuaGames.ClientClass.PropertyModifier modifier)
        {
            this.type = modifier.Type;
            this.modifyType = modifier.ModifyType;
            this.attributeType = modifier.AttributeType;
            this.attributeValue = modifier.AttributeValue;
        }

        public WeihuaGames.ClientClass.PropertyModifier FromProtobuf(com.kodgames.corgi.protocol.PropertyModifier proto)
        {
            this.type = proto.type;
            this.modifyType = proto.modifyType;
            this.attributeType = proto.attributeType;
            this.attributeValue = proto.attributeValue;
            return this;
        }

        public int AttributeType
        {
            get
            {
                return this.attributeType;
            }
            set
            {
                this.attributeType = value;
            }
        }

        public float AttributeValue
        {
            get
            {
                return this.attributeValue;
            }
            set
            {
                this.attributeValue = value;
            }
        }

        public int ModifyType
        {
            get
            {
                return this.modifyType;
            }
            set
            {
                this.modifyType = value;
            }
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
    }
}

