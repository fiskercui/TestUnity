namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GuildPublicGoods")]
    public class GuildPublicGoods : IExtensible
    {
        private int _buyCount;
        private int _gooodsId;
        private int _showIndex;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="buyCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int buyCount
        {
            get
            {
                return this._buyCount;
            }
            set
            {
                this._buyCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="gooodsId", DataFormat=DataFormat.TwosComplement)]
        public int gooodsId
        {
            get
            {
                return this._gooodsId;
            }
            set
            {
                this._gooodsId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="showIndex", DataFormat=DataFormat.TwosComplement)]
        public int showIndex
        {
            get
            {
                return this._showIndex;
            }
            set
            {
                this._showIndex = value;
            }
        }
    }
}

