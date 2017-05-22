namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="AC_LoginRes")]
    public class AC_LoginRes : IExtensible
    {
        private int _accountID;
        private readonly List<Area> _areas = new List<Area>();
        private int _callback;
        private ChannelMessage _channelMessage;
        private bool _isFirstQuickLogin;
        private bool _isShowActivityInterface;
        private int _lastAreaID = -1;
        private int _result;
        private string _token = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="accountID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int accountID
        {
            get
            {
                return this._accountID;
            }
            set
            {
                this._accountID = value;
            }
        }

        [ProtoMember(5, Name="areas", DataFormat=DataFormat.Default)]
        public List<Area> areas
        {
            get
            {
                return this._areas;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue((string) null), ProtoMember(9, IsRequired=false, Name="channelMessage", DataFormat=DataFormat.Default)]
        public ChannelMessage channelMessage
        {
            get
            {
                return this._channelMessage;
            }
            set
            {
                this._channelMessage = value;
            }
        }

        [DefaultValue(false), ProtoMember(7, IsRequired=false, Name="isFirstQuickLogin", DataFormat=DataFormat.Default)]
        public bool isFirstQuickLogin
        {
            get
            {
                return this._isFirstQuickLogin;
            }
            set
            {
                this._isFirstQuickLogin = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="isShowActivityInterface", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isShowActivityInterface
        {
            get
            {
                return this._isShowActivityInterface;
            }
            set
            {
                this._isShowActivityInterface = value;
            }
        }

        [DefaultValue(-1), ProtoMember(6, IsRequired=false, Name="lastAreaID", DataFormat=DataFormat.TwosComplement)]
        public int lastAreaID
        {
            get
            {
                return this._lastAreaID;
            }
            set
            {
                this._lastAreaID = value;
            }
        }

        [ProtoMember(1, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
        public int result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="token", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoContract(Name="ChannelMessage")]
        public class ChannelMessage : IExtensible
        {
            private string _accessToken = "";
            private string _channelUniqueId = "";
            private string _channelUserName = "";
            private string _oid = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="accessToken", DataFormat=DataFormat.Default)]
            public string accessToken
            {
                get
                {
                    return this._accessToken;
                }
                set
                {
                    this._accessToken = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="channelUniqueId", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="channelUserName", DataFormat=DataFormat.Default)]
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

            [ProtoMember(4, IsRequired=false, Name="oid", DataFormat=DataFormat.Default), DefaultValue("")]
            public string oid
            {
                get
                {
                    return this._oid;
                }
                set
                {
                    this._oid = value;
                }
            }
        }
    }
}

