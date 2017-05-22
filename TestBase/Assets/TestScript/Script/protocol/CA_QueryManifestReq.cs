namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CA_QueryManifestReq")]
    public class CA_QueryManifestReq : IExtensible
    {
        private int _callback;
        private int _channelID;
        private DeviceInfo _deviceInfo;
        private int _resourceVersion;
        private int _subChannelID;
        private int _version;
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

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement)]
        public int channelID
        {
            get
            {
                return this._channelID;
            }
            set
            {
                this._channelID = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
        public DeviceInfo deviceInfo
        {
            get
            {
                return this._deviceInfo;
            }
            set
            {
                this._deviceInfo = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="resourceVersion", DataFormat=DataFormat.TwosComplement)]
        public int resourceVersion
        {
            get
            {
                return this._resourceVersion;
            }
            set
            {
                this._resourceVersion = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="subChannelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int subChannelID
        {
            get
            {
                return this._subChannelID;
            }
            set
            {
                this._subChannelID = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="version", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int version
        {
            get
            {
                return this._version;
            }
            set
            {
                this._version = value;
            }
        }
    }
}

