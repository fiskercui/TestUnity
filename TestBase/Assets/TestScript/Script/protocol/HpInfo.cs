namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="HpInfo")]
    public class HpInfo : IExtensible
    {
        private string _guid = "";
        private double _leftHP;
        private int _locationId;
        private int _resourceId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="guid", DataFormat=DataFormat.Default)]
        public string guid
        {
            get
            {
                return this._guid;
            }
            set
            {
                this._guid = value;
            }
        }

        [DefaultValue((double) 0.0), ProtoMember(3, IsRequired=false, Name="leftHP", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(4, IsRequired=false, Name="locationId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="resourceId", DataFormat=DataFormat.TwosComplement)]
        public int resourceId
        {
            get
            {
                return this._resourceId;
            }
            set
            {
                this._resourceId = value;
            }
        }
    }
}

