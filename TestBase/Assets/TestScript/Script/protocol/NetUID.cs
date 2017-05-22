namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="NetUID")]
    public class NetUID : IExtensible
    {
        private string _channelUniqueId = "";
        private string _channelUserName = "";
        private DeviceInfo _deviceInfo;
        private string _ipMessage = "";
        private long _loginTime;
        private int _playerId;
        private int _sequenceId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(6, IsRequired=false, Name="channelUniqueId", DataFormat=DataFormat.Default), DefaultValue("")]
        public string channelUniqueId
        {
            get
            {
                return this._channelUniqueId;
            }
            set
            {
                this._channelUniqueId = value;
            }
        }

        [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="channelUserName", DataFormat=DataFormat.Default)]
        public string channelUserName
        {
            get
            {
                return this._channelUserName;
            }
            set
            {
                this._channelUserName = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [ProtoMember(4, IsRequired=false, Name="ipMessage", DataFormat=DataFormat.Default), DefaultValue("")]
        public string ipMessage
        {
            get
            {
                return this._ipMessage;
            }
            set
            {
                this._ipMessage = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="loginTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long loginTime
        {
            get
            {
                return this._loginTime;
            }
            set
            {
                this._loginTime = value;
            }
        }

        [ProtoMember(1, IsRequired=true, Name="playerId", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(2, IsRequired=true, Name="sequenceId", DataFormat=DataFormat.TwosComplement)]
        public int sequenceId
        {
            get
            {
                return this._sequenceId;
            }
            set
            {
                this._sequenceId = value;
            }
        }
    }
}

