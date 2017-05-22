namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Location")]
    public class Location : IExtensible
    {
        private string _guid = "";
        private int _index;
        private int _locationId;
        private int _positionId;
        private int _recourseId;
        private int _showLocationId;
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

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement)]
        public int index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="locationId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="positionId", DataFormat=DataFormat.TwosComplement)]
        public int positionId
        {
            get
            {
                return this._positionId;
            }
            set
            {
                this._positionId = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="recourseId", DataFormat=DataFormat.TwosComplement)]
        public int recourseId
        {
            get
            {
                return this._recourseId;
            }
            set
            {
                this._recourseId = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="showLocationId", DataFormat=DataFormat.TwosComplement)]
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

