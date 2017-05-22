namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="AvatarHp")]
    public class AvatarHp : IExtensible
    {
        private double _leftHP;
        private int _locationId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((double) 0.0), ProtoMember(2, IsRequired=false, Name="leftHP", DataFormat=DataFormat.TwosComplement)]
        public double leftHP
        {
            get
            {
                return this._leftHP;
            }
            set
            {
                this._leftHP = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="locationId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int locationId
        {
            get
            {
                return this._locationId;
            }
            set
            {
                this._locationId = value;
            }
        }
    }
}

