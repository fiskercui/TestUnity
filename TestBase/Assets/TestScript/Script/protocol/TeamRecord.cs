namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="TeamRecord")]
    public class TeamRecord : IExtensible
    {
        private readonly List<AvatarResult> _avatarResults = new List<AvatarResult>();
        private string _displayName = "";
        private int _evaluation;
        private bool _isWinner;
        private readonly List<com.kodgames.corgi.protocol.Attribute> _teamBaseAttributes = new List<com.kodgames.corgi.protocol.Attribute>();
        private int _teamIndex;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, Name="avatarResults", DataFormat=DataFormat.Default)]
        public List<AvatarResult> avatarResults
        {
            get
            {
                return this._avatarResults;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="displayName", DataFormat=DataFormat.Default), DefaultValue("")]
        public string displayName
        {
            get
            {
                return this._displayName;
            }
            set
            {
                this._displayName = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="evaluation", DataFormat=DataFormat.TwosComplement)]
        public int evaluation
        {
            get
            {
                return this._evaluation;
            }
            set
            {
                this._evaluation = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="isWinner", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isWinner
        {
            get
            {
                return this._isWinner;
            }
            set
            {
                this._isWinner = value;
            }
        }

        [ProtoMember(4, Name="teamBaseAttributes", DataFormat=DataFormat.Default)]
        public List<com.kodgames.corgi.protocol.Attribute> teamBaseAttributes
        {
            get
            {
                return this._teamBaseAttributes;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="teamIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int teamIndex
        {
            get
            {
                return this._teamIndex;
            }
            set
            {
                this._teamIndex = value;
            }
        }
    }
}

