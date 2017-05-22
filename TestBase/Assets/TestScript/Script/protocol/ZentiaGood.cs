namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="ZentiaGood")]
    public class ZentiaGood : IExtensible
    {
        private Cost _cost;
        private int _exchangeGoodId;
        private Reward _reward;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="cost", DataFormat=DataFormat.Default)]
        public Cost cost
        {
            get
            {
                return this._cost;
            }
            set
            {
                this._cost = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="exchangeGoodId", DataFormat=DataFormat.TwosComplement)]
        public int exchangeGoodId
        {
            get
            {
                return this._exchangeGoodId;
            }
            set
            {
                this._exchangeGoodId = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="reward", DataFormat=DataFormat.Default)]
        public Reward reward
        {
            get
            {
                return this._reward;
            }
            set
            {
                this._reward = value;
            }
        }
    }
}

