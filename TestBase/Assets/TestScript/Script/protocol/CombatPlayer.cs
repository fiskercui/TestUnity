namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CombatPlayer")]
    public class CombatPlayer : IExtensible
    {
        private readonly List<CombatAvatarData> _combatAvatarDatas = new List<CombatAvatarData>();
        private string _displayName = "";
        private int _evaluation;
        private int _playerId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, Name="combatAvatarDatas", DataFormat=DataFormat.Default)]
        public List<CombatAvatarData> combatAvatarDatas
        {
            get
            {
                return this._combatAvatarDatas;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="displayName", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(4, IsRequired=false, Name="evaluation", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(1, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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
    }
}

