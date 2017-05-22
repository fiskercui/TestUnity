namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="DeviceInfo")]
    public class DeviceInfo : IExtensible
    {
        private string _deviceName = "";
        private int _deviceType;
        private string _OSType = "";
        private string _OSVersion = "";
        private string _UDID = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="deviceName", DataFormat=DataFormat.Default)]
        public string deviceName
        {
            get
            {
                return this._deviceName;
            }
            set
            {
                this._deviceName = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="deviceType", DataFormat=DataFormat.TwosComplement)]
        public int deviceType
        {
            get
            {
                return this._deviceType;
            }
            set
            {
                this._deviceType = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="OSType", DataFormat=DataFormat.Default), DefaultValue("")]
        public string OSType
        {
            get
            {
                return this._OSType;
            }
            set
            {
                this._OSType = value;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="OSVersion", DataFormat=DataFormat.Default)]
        public string OSVersion
        {
            get
            {
                return this._OSVersion;
            }
            set
            {
                this._OSVersion = value;
            }
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="UDID", DataFormat=DataFormat.Default)]
        public string UDID
        {
            get
            {
                return this._UDID;
            }
            set
            {
                this._UDID = value;
            }
        }
    }
}

