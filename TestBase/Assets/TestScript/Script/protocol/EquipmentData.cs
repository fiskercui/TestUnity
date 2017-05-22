namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="EquipmentData")]
    public class EquipmentData : IExtensible
    {
        private int _breakThrough;
        private int _id;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="breakThrough", DataFormat=DataFormat.TwosComplement)]
        public int breakThrough
        {
            get
            {
                return this._breakThrough;
            }
            set
            {
                this._breakThrough = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

