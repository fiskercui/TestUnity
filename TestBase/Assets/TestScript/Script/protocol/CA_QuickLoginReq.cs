namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CA_QuickLoginReq")]
    public class CA_QuickLoginReq : IExtensible
    {
        private int _callback;
        private KunlunQuickLoginReq _kunlunQuickLoginReq;
        private LocalQuickLoginReq _localQuickLoginReq;
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

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="kunlunQuickLoginReq", DataFormat=DataFormat.Default)]
        public KunlunQuickLoginReq kunlunQuickLoginReq
        {
            get
            {
                return this._kunlunQuickLoginReq;
            }
            set
            {
                this._kunlunQuickLoginReq = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="localQuickLoginReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public LocalQuickLoginReq localQuickLoginReq
        {
            get
            {
                return this._localQuickLoginReq;
            }
            set
            {
                this._localQuickLoginReq = value;
            }
        }

        [ProtoContract(Name="KunlunQuickLoginReq")]
        public class KunlunQuickLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _klsso = "";
            private string _randomSeed = "";
            private int _version;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(6, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="email", DataFormat=DataFormat.Default)]
            public string email
            {
                get
                {
                    return this._email;
                }
                set
                {
                    this._email = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="klsso", DataFormat=DataFormat.Default)]
            public string klsso
            {
                get
                {
                    return this._klsso;
                }
                set
                {
                    this._klsso = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default), DefaultValue("")]
            public string randomSeed
            {
                get
                {
                    return this._randomSeed;
                }
                set
                {
                    this._randomSeed = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="version", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoContract(Name="LocalQuickLoginReq")]
        public class LocalQuickLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _randomSeed = "";
            private int _version;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
            public string randomSeed
            {
                get
                {
                    return this._randomSeed;
                }
                set
                {
                    this._randomSeed = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="version", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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
}

