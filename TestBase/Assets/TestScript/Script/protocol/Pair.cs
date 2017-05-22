namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Pair")]
    public class Pair : IExtensible
    {
        private int _locationId;
        private int _showLocationId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [ProtoMember(2, IsRequired=false, Name="showLocationId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int showLocationId
        {
            get
            {
                return this._showLocationId;
            }
            set
            {
                this._showLocationId = value;
            }
        }
    }
}

