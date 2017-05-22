namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_CombatWolfSmokeReq")]
    public class CG_CombatWolfSmokeReq : IExtensible
    {
        private int _additionId;
        private int _callback;
        private Position _position;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="additionId", DataFormat=DataFormat.TwosComplement)]
        public int additionId
        {
            get
            {
                return this._additionId;
            }
            set
            {
                this._additionId = value;
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

