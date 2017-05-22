namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CA_LoginReq")]
    public class CA_LoginReq : IExtensible
    {
        private AnZhiLoginReq _anZhiLoginReq;
        private AppotaLoginReq _appotaLoginReq;
        private Area91LoginReq _area91LoginReq;
        private int _callback;
        private CMGELoginReq _cmgeLoginReq;
        private CyAggregateLoginReq _cyAggregateLoginReq;
        private DownJoyLoginReq _downJoyLoginReq;
        private DuokuLoginReq _duokuLoginReq;
        private EFUNLoginReq _efunLoginReq;
        private JinSanLoginReq _jinSanLoginReq;
        private KuaiBoLoginReq _kuaiBoLoginReq;
        private KunlunLoginReq _kunlunLoginReq;
        private LocalLoginReq _localLoginReq;
        private MengXiangLoginReq _mengXiangLoginReq;
        private OppoLoginReq _oppoLoginReq;
        private QiHu360LoginReq _qiHu360LoginReq;
        private UCLoginReq _ucLoginReq;
        private WanDouJiaLoginReq _wanDouJiaLoginReq;
        private XiaoMiLoginReq _xiaoMiLoginReq;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((string) null), ProtoMember(15, IsRequired=false, Name="anZhiLoginReq", DataFormat=DataFormat.Default)]
        public AnZhiLoginReq anZhiLoginReq
        {
            get
            {
                return this._anZhiLoginReq;
            }
            set
            {
                this._anZhiLoginReq = value;
            }
        }

        [ProtoMember(0x13, IsRequired=false, Name="appotaLoginReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public AppotaLoginReq appotaLoginReq
        {
            get
            {
                return this._appotaLoginReq;
            }
            set
            {
                this._appotaLoginReq = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="area91LoginReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Area91LoginReq area91LoginReq
        {
            get
            {
                return this._area91LoginReq;
            }
            set
            {
                this._area91LoginReq = value;
            }
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

        [ProtoMember(0x11, IsRequired=false, Name="cmgeLoginReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public CMGELoginReq cmgeLoginReq
        {
            get
            {
                return this._cmgeLoginReq;
            }
            set
            {
                this._cmgeLoginReq = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x10, IsRequired=false, Name="cyAggregateLoginReq", DataFormat=DataFormat.Default)]
        public CyAggregateLoginReq cyAggregateLoginReq
        {
            get
            {
                return this._cyAggregateLoginReq;
            }
            set
            {
                this._cyAggregateLoginReq = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="downJoyLoginReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public DownJoyLoginReq downJoyLoginReq
        {
            get
            {
                return this._downJoyLoginReq;
            }
            set
            {
                this._downJoyLoginReq = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="duokuLoginReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public DuokuLoginReq duokuLoginReq
        {
            get
            {
                return this._duokuLoginReq;
            }
            set
            {
                this._duokuLoginReq = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x12, IsRequired=false, Name="efunLoginReq", DataFormat=DataFormat.Default)]
        public EFUNLoginReq efunLoginReq
        {
            get
            {
                return this._efunLoginReq;
            }
            set
            {
                this._efunLoginReq = value;
            }
        }

        [ProtoMember(13, IsRequired=false, Name="jinSanLoginReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public JinSanLoginReq jinSanLoginReq
        {
            get
            {
                return this._jinSanLoginReq;
            }
            set
            {
                this._jinSanLoginReq = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(14, IsRequired=false, Name="kuaiBoLoginReq", DataFormat=DataFormat.Default)]
        public KuaiBoLoginReq kuaiBoLoginReq
        {
            get
            {
                return this._kuaiBoLoginReq;
            }
            set
            {
                this._kuaiBoLoginReq = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="kunlunLoginReq", DataFormat=DataFormat.Default)]
        public KunlunLoginReq kunlunLoginReq
        {
            get
            {
                return this._kunlunLoginReq;
            }
            set
            {
                this._kunlunLoginReq = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="localLoginReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public LocalLoginReq localLoginReq
        {
            get
            {
                return this._localLoginReq;
            }
            set
            {
                this._localLoginReq = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(12, IsRequired=false, Name="mengXiangLoginReq", DataFormat=DataFormat.Default)]
        public MengXiangLoginReq mengXiangLoginReq
        {
            get
            {
                return this._mengXiangLoginReq;
            }
            set
            {
                this._mengXiangLoginReq = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="oppoLoginReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public OppoLoginReq oppoLoginReq
        {
            get
            {
                return this._oppoLoginReq;
            }
            set
            {
                this._oppoLoginReq = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="qiHu360LoginReq", DataFormat=DataFormat.Default)]
        public QiHu360LoginReq qiHu360LoginReq
        {
            get
            {
                return this._qiHu360LoginReq;
            }
            set
            {
                this._qiHu360LoginReq = value;
            }
        }

        [ProtoMember(11, IsRequired=false, Name="ucLoginReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public UCLoginReq ucLoginReq
        {
            get
            {
                return this._ucLoginReq;
            }
            set
            {
                this._ucLoginReq = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(9, IsRequired=false, Name="wanDouJiaLoginReq", DataFormat=DataFormat.Default)]
        public WanDouJiaLoginReq wanDouJiaLoginReq
        {
            get
            {
                return this._wanDouJiaLoginReq;
            }
            set
            {
                this._wanDouJiaLoginReq = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="xiaoMiLoginReq", DataFormat=DataFormat.Default)]
        public XiaoMiLoginReq xiaoMiLoginReq
        {
            get
            {
                return this._xiaoMiLoginReq;
            }
            set
            {
                this._xiaoMiLoginReq = value;
            }
        }

        [ProtoContract(Name="AnZhiLoginReq")]
        public class AnZhiLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _sid = "";
            private string _version = "";
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

            [ProtoMember(7, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
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

            [ProtoMember(1, IsRequired=false, Name="sid", DataFormat=DataFormat.Default), DefaultValue("")]
            public string sid
            {
                get
                {
                    return this._sid;
                }
                set
                {
                    this._sid = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
            public string version
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

        [ProtoContract(Name="AppotaLoginReq")]
        public class AppotaLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _gameChannel = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _userAccessToken = "";
            private string _userId = "";
            private string _userName = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(8, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [ProtoMember(9, IsRequired=false, Name="gameChannel", DataFormat=DataFormat.Default), DefaultValue("")]
            public string gameChannel
            {
                get
                {
                    return this._gameChannel;
                }
                set
                {
                    this._gameChannel = value;
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

            [ProtoMember(5, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [ProtoMember(7, IsRequired=false, Name="userAccessToken", DataFormat=DataFormat.Default), DefaultValue("")]
            public string userAccessToken
            {
                get
                {
                    return this._userAccessToken;
                }
                set
                {
                    this._userAccessToken = value;
                }
            }

            [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="userId", DataFormat=DataFormat.Default)]
            public string userId
            {
                get
                {
                    return this._userId;
                }
                set
                {
                    this._userId = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="userName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string userName
            {
                get
                {
                    return this._userName;
                }
                set
                {
                    this._userName = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
            public string version
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

        [ProtoContract(Name="Area91LoginReq")]
        public class Area91LoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _sessionID = "";
            private string _uin = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(7, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="email", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="password", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
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

            [ProtoMember(1, IsRequired=false, Name="sessionID", DataFormat=DataFormat.Default), DefaultValue("")]
            public string sessionID
            {
                get
                {
                    return this._sessionID;
                }
                set
                {
                    this._sessionID = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="uin", DataFormat=DataFormat.Default), DefaultValue("")]
            public string uin
            {
                get
                {
                    return this._uin;
                }
                set
                {
                    this._uin = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
            public string version
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

        [ProtoContract(Name="CMGELoginReq")]
        public class CMGELoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _gameChannel = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _sign = "";
            private string _timeStamp = "";
            private string _userId = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(8, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [ProtoMember(9, IsRequired=false, Name="gameChannel", DataFormat=DataFormat.Default), DefaultValue("")]
            public string gameChannel
            {
                get
                {
                    return this._gameChannel;
                }
                set
                {
                    this._gameChannel = value;
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

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
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

            [ProtoMember(7, IsRequired=false, Name="sign", DataFormat=DataFormat.Default), DefaultValue("")]
            public string sign
            {
                get
                {
                    return this._sign;
                }
                set
                {
                    this._sign = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="timeStamp", DataFormat=DataFormat.Default), DefaultValue("")]
            public string timeStamp
            {
                get
                {
                    return this._timeStamp;
                }
                set
                {
                    this._timeStamp = value;
                }
            }

            [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="userId", DataFormat=DataFormat.Default)]
            public string userId
            {
                get
                {
                    return this._userId;
                }
                set
                {
                    this._userId = value;
                }
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="version", DataFormat=DataFormat.Default)]
            public string version
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

        [ProtoContract(Name="CyAggregateLoginReq")]
        public class CyAggregateLoginReq : IExtensible
        {
            private int _channelID;
            private string _data = "";
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _gamechannel = "";
            private int _opcode;
            private string _password = "";
            private string _randomSeed = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="data", DataFormat=DataFormat.Default)]
            public string data
            {
                get
                {
                    return this._data;
                }
                set
                {
                    this._data = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [ProtoMember(1, IsRequired=false, Name="email", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(9, IsRequired=false, Name="gamechannel", DataFormat=DataFormat.Default)]
            public string gamechannel
            {
                get
                {
                    return this._gamechannel;
                }
                set
                {
                    this._gamechannel = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="opcode", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int opcode
            {
                get
                {
                    return this._opcode;
                }
                set
                {
                    this._opcode = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="password", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [ProtoMember(5, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="version", DataFormat=DataFormat.Default)]
            public string version
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

        [ProtoContract(Name="DownJoyLoginReq")]
        public class DownJoyLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _mid = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _token = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(7, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="email", DataFormat=DataFormat.Default)]
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

            [ProtoMember(2, IsRequired=false, Name="mid", DataFormat=DataFormat.Default), DefaultValue("")]
            public string mid
            {
                get
                {
                    return this._mid;
                }
                set
                {
                    this._mid = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="password", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
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

            [ProtoMember(1, IsRequired=false, Name="token", DataFormat=DataFormat.Default), DefaultValue("")]
            public string token
            {
                get
                {
                    return this._token;
                }
                set
                {
                    this._token = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
            public string version
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

        [ProtoContract(Name="DuokuLoginReq")]
        public class DuokuLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _sessionID = "";
            private string _uid = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(7, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [ProtoMember(3, IsRequired=false, Name="email", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="password", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
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

            [ProtoMember(1, IsRequired=false, Name="sessionID", DataFormat=DataFormat.Default), DefaultValue("")]
            public string sessionID
            {
                get
                {
                    return this._sessionID;
                }
                set
                {
                    this._sessionID = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="uid", DataFormat=DataFormat.Default)]
            public string uid
            {
                get
                {
                    return this._uid;
                }
                set
                {
                    this._uid = value;
                }
            }

            [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="version", DataFormat=DataFormat.Default)]
            public string version
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

        [ProtoContract(Name="EFUNLoginReq")]
        public class EFUNLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _gameChannel = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _sign = "";
            private string _timeStamp = "";
            private string _userId = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [ProtoMember(8, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [ProtoMember(1, IsRequired=false, Name="email", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(9, IsRequired=false, Name="gameChannel", DataFormat=DataFormat.Default)]
            public string gameChannel
            {
                get
                {
                    return this._gameChannel;
                }
                set
                {
                    this._gameChannel = value;
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

            [ProtoMember(5, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="sign", DataFormat=DataFormat.Default)]
            public string sign
            {
                get
                {
                    return this._sign;
                }
                set
                {
                    this._sign = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="timeStamp", DataFormat=DataFormat.Default), DefaultValue("")]
            public string timeStamp
            {
                get
                {
                    return this._timeStamp;
                }
                set
                {
                    this._timeStamp = value;
                }
            }

            [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="userId", DataFormat=DataFormat.Default)]
            public string userId
            {
                get
                {
                    return this._userId;
                }
                set
                {
                    this._userId = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
            public string version
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

        [ProtoContract(Name="JinSanLoginReq")]
        public class JinSanLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _mutk = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [ProtoMember(1, IsRequired=false, Name="mutk", DataFormat=DataFormat.Default), DefaultValue("")]
            public string mutk
            {
                get
                {
                    return this._mutk;
                }
                set
                {
                    this._mutk = value;
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default)]
            public string version
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

        [ProtoContract(Name="KuaiBoLoginReq")]
        public class KuaiBoLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _sid = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
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

            [ProtoMember(1, IsRequired=false, Name="sid", DataFormat=DataFormat.Default), DefaultValue("")]
            public string sid
            {
                get
                {
                    return this._sid;
                }
                set
                {
                    this._sid = value;
                }
            }

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default)]
            public string version
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

        [ProtoContract(Name="KunlunLoginReq")]
        public class KunlunLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _klsso = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _version = "";
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

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [ProtoMember(4, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default)]
            public string version
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

        [ProtoContract(Name="LocalLoginReq")]
        public class LocalLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _version = "";
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

            [DefaultValue((string) null), ProtoMember(6, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [ProtoMember(2, IsRequired=false, Name="password", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="version", DataFormat=DataFormat.Default)]
            public string version
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

        [ProtoContract(Name="MengXiangLoginReq")]
        public class MengXiangLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _sign = "";
            private string _timestamp = "";
            private string _userAccount = "";
            private string _version = "";
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

            [ProtoMember(7, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [ProtoMember(4, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [ProtoMember(1, IsRequired=false, Name="sign", DataFormat=DataFormat.Default), DefaultValue("")]
            public string sign
            {
                get
                {
                    return this._sign;
                }
                set
                {
                    this._sign = value;
                }
            }

            [DefaultValue(""), ProtoMember(9, IsRequired=false, Name="timestamp", DataFormat=DataFormat.Default)]
            public string timestamp
            {
                get
                {
                    return this._timestamp;
                }
                set
                {
                    this._timestamp = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="userAccount", DataFormat=DataFormat.Default), DefaultValue("")]
            public string userAccount
            {
                get
                {
                    return this._userAccount;
                }
                set
                {
                    this._userAccount = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
            public string version
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

        [ProtoContract(Name="OppoLoginReq")]
        public class OppoLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _id = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _token = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(7, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.Default), DefaultValue("")]
            public string id
            {
                get
                {
                    return this._id;
                }
                set
                {
                    this._id = value;
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(8, IsRequired=false, Name="token", DataFormat=DataFormat.Default)]
            public string token
            {
                get
                {
                    return this._token;
                }
                set
                {
                    this._token = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
            public string version
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

        [ProtoContract(Name="QiHu360LoginReq")]
        public class QiHu360LoginReq : IExtensible
        {
            private string _authorizationCode = "";
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="authorizationCode", DataFormat=DataFormat.Default), DefaultValue("")]
            public string authorizationCode
            {
                get
                {
                    return this._authorizationCode;
                }
                set
                {
                    this._authorizationCode = value;
                }
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

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [ProtoMember(4, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default)]
            public string version
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

        [ProtoContract(Name="UCLoginReq")]
        public class UCLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _sid = "";
            private string _version = "";
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

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [ProtoMember(4, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [ProtoMember(1, IsRequired=false, Name="sid", DataFormat=DataFormat.Default), DefaultValue("")]
            public string sid
            {
                get
                {
                    return this._sid;
                }
                set
                {
                    this._sid = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
            public string version
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

        [ProtoContract(Name="WanDouJiaLoginReq")]
        public class WanDouJiaLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _token = "";
            private string _uid = "";
            private string _version = "";
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

            [ProtoMember(7, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
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

            [ProtoMember(1, IsRequired=false, Name="token", DataFormat=DataFormat.Default), DefaultValue("")]
            public string token
            {
                get
                {
                    return this._token;
                }
                set
                {
                    this._token = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="uid", DataFormat=DataFormat.Default), DefaultValue("")]
            public string uid
            {
                get
                {
                    return this._uid;
                }
                set
                {
                    this._uid = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
            public string version
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

        [ProtoContract(Name="XiaoMiLoginReq")]
        public class XiaoMiLoginReq : IExtensible
        {
            private int _channelID;
            private DeviceInfo _deviceInfo;
            private string _email = "";
            private string _password = "";
            private string _randomSeed = "";
            private string _session = "";
            private string _uid = "";
            private string _version = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, IsRequired=false, Name="channelID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="deviceInfo", DataFormat=DataFormat.Default)]
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

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="randomSeed", DataFormat=DataFormat.Default)]
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

            [ProtoMember(1, IsRequired=false, Name="session", DataFormat=DataFormat.Default), DefaultValue("")]
            public string session
            {
                get
                {
                    return this._session;
                }
                set
                {
                    this._session = value;
                }
            }

            [DefaultValue(""), ProtoMember(8, IsRequired=false, Name="uid", DataFormat=DataFormat.Default)]
            public string uid
            {
                get
                {
                    return this._uid;
                }
                set
                {
                    this._uid = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
            public string version
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

