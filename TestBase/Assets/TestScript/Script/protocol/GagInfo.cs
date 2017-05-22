namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GagInfo")]
    public class GagInfo : IExtensible
    {
        private string _gagTime = "";
        private int _gagType;
        private int _playerId;
        private string _udid = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="gagTime", DataFormat=DataFormat.Default)]
        public string gagTime
        {
            get
            {
                return this._gagTime;
            }
            set
            {
                this._gagTime = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="gagType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int gagType
        {
            get
            {
                return this._gagType;
            }
            set
            {
                this._gagType = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int playerId
        {
            get
            {
                return this._playerId;
            }
            set
            {
                this._playerId = value;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="udid", DataFormat=DataFormat.Default)]
        public string udid
        {
            get
            {
                return this._udid;
            }
            set
            {
                this._udid = value;
            }
        }
    }
}

