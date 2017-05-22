namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Area")]
    public class Area : IExtensible
    {
        private int _areaAvatarNumber;
        private int _areaID;
        private string _interfaceServerIP;
        private int _interfaceServerPort;
        private int _mergeAreaID;
        private string _name;
        private int _newAreaID;
        private int _showAreaID;
        private int _status;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(6, IsRequired=false, Name="areaAvatarNumber", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int areaAvatarNumber
        {
            get
            {
                return this._areaAvatarNumber;
            }
            set
            {
                this._areaAvatarNumber = value;
            }
        }

        [ProtoMember(1, IsRequired=true, Name="areaID", DataFormat=DataFormat.TwosComplement)]
        public int areaID
        {
            get
            {
                return this._areaID;
            }
            set
            {
                this._areaID = value;
            }
        }

        [ProtoMember(4, IsRequired=true, Name="interfaceServerIP", DataFormat=DataFormat.Default)]
        public string interfaceServerIP
        {
            get
            {
                return this._interfaceServerIP;
            }
            set
            {
                this._interfaceServerIP = value;
            }
        }

        [ProtoMember(5, IsRequired=true, Name="interfaceServerPort", DataFormat=DataFormat.TwosComplement)]
        public int interfaceServerPort
        {
            get
            {
                return this._interfaceServerPort;
            }
            set
            {
                this._interfaceServerPort = value;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="mergeAreaID", DataFormat=DataFormat.TwosComplement)]
        public int mergeAreaID
        {
            get
            {
                return this._mergeAreaID;
            }
            set
            {
                this._mergeAreaID = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="name", DataFormat=DataFormat.Default)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="newAreaID", DataFormat=DataFormat.TwosComplement)]
        public int newAreaID
        {
            get
            {
                return this._newAreaID;
            }
            set
            {
                this._newAreaID = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="showAreaID", DataFormat=DataFormat.TwosComplement)]
        public int showAreaID
        {
            get
            {
                return this._showAreaID;
            }
            set
            {
                this._showAreaID = value;
            }
        }

        [ProtoMember(3, IsRequired=true, Name="status", DataFormat=DataFormat.TwosComplement)]
        public int status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }
    }
}

