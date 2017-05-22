namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Function")]
    public class Function : IExtensible
    {
        private bool _faceBookOpen;
        private bool _showExchange;
        private bool _showGiveMeFive;
        private bool _showGuild;
        private bool _showInviteCode;
        private bool _showSevenElevenGift;
        private bool _showStartGameVideo;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(7, IsRequired=false, Name="faceBookOpen", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool faceBookOpen
        {
            get
            {
                return this._faceBookOpen;
            }
            set
            {
                this._faceBookOpen = value;
            }
        }

        [DefaultValue(false), ProtoMember(1, IsRequired=false, Name="showExchange", DataFormat=DataFormat.Default)]
        public bool showExchange
        {
            get
            {
                return this._showExchange;
            }
            set
            {
                this._showExchange = value;
            }
        }

        [DefaultValue(false), ProtoMember(2, IsRequired=false, Name="showGiveMeFive", DataFormat=DataFormat.Default)]
        public bool showGiveMeFive
        {
            get
            {
                return this._showGiveMeFive;
            }
            set
            {
                this._showGiveMeFive = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="showGuild", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool showGuild
        {
            get
            {
                return this._showGuild;
            }
            set
            {
                this._showGuild = value;
            }
        }

        [DefaultValue(false), ProtoMember(5, IsRequired=false, Name="showInviteCode", DataFormat=DataFormat.Default)]
        public bool showInviteCode
        {
            get
            {
                return this._showInviteCode;
            }
            set
            {
                this._showInviteCode = value;
            }
        }

        [DefaultValue(false), ProtoMember(6, IsRequired=false, Name="showSevenElevenGift", DataFormat=DataFormat.Default)]
        public bool showSevenElevenGift
        {
            get
            {
                return this._showSevenElevenGift;
            }
            set
            {
                this._showSevenElevenGift = value;
            }
        }

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="showStartGameVideo", DataFormat=DataFormat.Default)]
        public bool showStartGameVideo
        {
            get
            {
                return this._showStartGameVideo;
            }
            set
            {
                this._showStartGameVideo = value;
            }
        }
    }
}

