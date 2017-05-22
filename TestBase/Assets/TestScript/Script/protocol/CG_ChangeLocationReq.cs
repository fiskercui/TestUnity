namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_ChangeLocationReq")]
    public class CG_ChangeLocationReq : IExtensible
    {
        private int _callback;
        private string _guid = "";
        private int _index;
        private int _locationId;
        private string _offGuid = "";
        private int _positionId;
        private int _resourceId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
        public int callback
        {
            get
            {
                return this._callback;
            }
            set
            {
                this._callback = value;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="guid", DataFormat=DataFormat.Default)]
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

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="locationId", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="offGuid", DataFormat=DataFormat.Default)]
        public string offGuid
        {
            get
            {
                return this._offGuid;
            }
            set
            {
                this._offGuid = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="positionId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(3, IsRequired=false, Name="resourceId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

