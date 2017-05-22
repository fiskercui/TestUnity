namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CA_CreateAccountReq")]
    public class CA_CreateAccountReq : IExtensible
    {
        private int _callback;
        private KunlunCreateAccountReq _kunlunCreateAccountReq;
        private LocalCreateAccountReq _localCreateAccountReq;
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

        [ProtoMember(3, IsRequired=false, Name="kunlunCreateAccountReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public KunlunCreateAccountReq kunlunCreateAccountReq
        {
            get
            {
                return this._kunlunCreateAccountReq;
            }
            set
            {
                this._kunlunCreateAccountReq = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="localCreateAccountReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public LocalCreateAccountReq localCreateAccountReq
        {
            get
            {
                return this._localCreateAccountReq;
            }
            set
            {
                this._localCreateAccountReq = value;
            }
        }

        [ProtoContract(Name="KunlunCreateAccountReq")]
        public class KunlunCreateAccountReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _klsso = "";
            private string _mobile = "";
            private string _password = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="email", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="klsso", DataFormat=DataFormat.Default)]
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

            [ProtoMember(4, IsRequired=false, Name="mobile", DataFormat=DataFormat.Default), DefaultValue("")]
            public string mobile
            {
                get
                {
                    return this._mobile;
                }
                set
                {
                    this._mobile = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="password", DataFormat=DataFormat.Default), DefaultValue("")]
            public string password
            {
                get
                {
                    return this._password;
                }
                set
                {
                    this._password = value;
                }
            }
        }

        [ProtoContract(Name="LocalCreateAccountReq")]
        public class LocalCreateAccountReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _mobile = "";
            private string _password = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(3, IsRequired=false, Name="mobile", DataFormat=DataFormat.Default), DefaultValue("")]
            public string mobile
            {
                get
                {
                    return this._mobile;
                }
                set
                {
                    this._mobile = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="password", DataFormat=DataFormat.Default)]
            public string password
            {
                get
                {
                    return this._password;
                }
                set
                {
                    this._password = value;
                }
            }
        }
    }
}

