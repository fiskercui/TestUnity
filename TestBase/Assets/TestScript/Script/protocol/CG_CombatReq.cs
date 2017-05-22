namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_CombatReq")]
    public class CG_CombatReq : IExtensible
    {
        private int _callback;
        private int _dungeonId;
        private int _npcId;
        private Position _position;
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

        [ProtoMember(2, IsRequired=false, Name="dungeonId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int dungeonId
        {
            get
            {
                return this._dungeonId;
            }
            set
            {
                this._dungeonId = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="npcId", DataFormat=DataFormat.TwosComplement)]
        public int npcId
        {
            get
            {
                return this._npcId;
            }
            set
            {
                this._npcId = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="position", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Position position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }
    }
}

