namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Consumable")]
    public class Consumable : IExtensible
    {
        private int _additionalAmount;
        private int _amount;
        private int _id;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="additionalAmount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int additionalAmount
        {
            get
            {
                return this._additionalAmount;
            }
            set
            {
                this._additionalAmount = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="amount", DataFormat=DataFormat.TwosComplement)]
        public int amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
    }
}

