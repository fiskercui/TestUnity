namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="AC_QueryManifestRes")]
    public class AC_QueryManifestRes : IExtensible
    {
        private string _appDownloadURL = "";
        private string _appUpdateDesc = "";
        private int _appVersion;
        private string _baseResourceUpdateURL = "";
        private int _callback;
        private string _gameConfigName = "";
        private int _gameConfigSize;
        private int _gameConfigUncompressedSize;
        private bool _isForcedUpdate;
        private bool _isReconnectOpen;
        private string _maintainNotice = "";
        private int _result;
        private int _timeZone;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="appDownloadURL", DataFormat=DataFormat.Default)]
        public string appDownloadURL
        {
            get
            {
                return this._appDownloadURL;
            }
            set
            {
                this._appDownloadURL = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="appUpdateDesc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string appUpdateDesc
        {
            get
            {
                return this._appUpdateDesc;
            }
            set
            {
                this._appUpdateDesc = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="appVersion", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int appVersion
        {
            get
            {
                return this._appVersion;
            }
            set
            {
                this._appVersion = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="baseResourceUpdateURL", DataFormat=DataFormat.Default), DefaultValue("")]
        public string baseResourceUpdateURL
        {
            get
            {
                return this._baseResourceUpdateURL;
            }
            set
            {
                this._baseResourceUpdateURL = value;
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

        [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="gameConfigName", DataFormat=DataFormat.Default)]
        public string gameConfigName
        {
            get
            {
                return this._gameConfigName;
            }
            set
            {
                this._gameConfigName = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="gameConfigSize", DataFormat=DataFormat.TwosComplement)]
        public int gameConfigSize
        {
            get
            {
                return this._gameConfigSize;
            }
            set
            {
                this._gameConfigSize = value;
            }
        }

        [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="gameConfigUncompressedSize", DataFormat=DataFormat.TwosComplement)]
        public int gameConfigUncompressedSize
        {
            get
            {
                return this._gameConfigUncompressedSize;
            }
            set
            {
                this._gameConfigUncompressedSize = value;
            }
        }

        [DefaultValue(false), ProtoMember(12, IsRequired=false, Name="isForcedUpdate", DataFormat=DataFormat.Default)]
        public bool isForcedUpdate
        {
            get
            {
                return this._isForcedUpdate;
            }
            set
            {
                this._isForcedUpdate = value;
            }
        }

        [ProtoMember(13, IsRequired=false, Name="isReconnectOpen", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isReconnectOpen
        {
            get
            {
                return this._isReconnectOpen;
            }
            set
            {
                this._isReconnectOpen = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="maintainNotice", DataFormat=DataFormat.Default), DefaultValue("")]
        public string maintainNotice
        {
            get
            {
                return this._maintainNotice;
            }
            set
            {
                this._maintainNotice = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="timeZone", DataFormat=DataFormat.TwosComplement)]
        public int timeZone
        {
            get
            {
                return this._timeZone;
            }
            set
            {
                this._timeZone = value;
            }
        }
    }
}

