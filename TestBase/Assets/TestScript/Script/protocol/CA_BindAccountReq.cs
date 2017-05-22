namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CA_BindAccountReq")]
    public class CA_BindAccountReq : IExtensible
    {
        private int _callback;
        private KunlunBindAccountReq _kunlunBindAccountReq;
        private LocalBindAccountReq _localBindAccountReq;
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

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="kunlunBindAccountReq", DataFormat=DataFormat.Default)]
        public KunlunBindAccountReq kunlunBindAccountReq
        {
            get
            {
                return this._kunlunBindAccountReq;
            }
            set
            {
                this._kunlunBindAccountReq = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="localBindAccountReq", DataFormat=DataFormat.Default)]
        public LocalBindAccountReq localBindAccountReq
        {
            get
            {
                return this._localBindAccountReq;
            }
            set
            {
                this._localBindAccountReq = value;
            }
        }

        [ProtoContract(Name="KunlunBindAccountReq")]
        public class KunlunBindAccountReq : IExtensible
        {
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

            [ProtoMember(2, IsRequired=false, Name="email", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [ProtoMember(1, IsRequired=false, Name="klsso", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="mobile", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="password", DataFormat=DataFormat.Default)]
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

        [ProtoContract(Name="LocalBindAccountReq")]
        public class LocalBindAccountReq : IExtensible
        {
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _mobile = "";
            private string _password = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [ProtoMember(2, IsRequired=false, Name="email", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="mobile", DataFormat=DataFormat.Default)]
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
    }
}

