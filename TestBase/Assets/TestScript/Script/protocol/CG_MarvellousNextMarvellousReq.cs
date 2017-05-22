namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_MarvellousNextMarvellousReq")]
    public class CG_MarvellousNextMarvellousReq : IExtensible
    {
        private int _callBack;
        private int _nextZone;
        private Position _position;
        private int _selectType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=true, Name="callBack", DataFormat=DataFormat.TwosComplement)]
        public int callBack
        {
            get
            {
                return this._callBack;
            }
            set
            {
                this._callBack = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="nextZone", DataFormat=DataFormat.TwosComplement)]
        public int nextZone
        {
            get
            {
                return this._nextZone;
            }
            set
            {
                this._nextZone = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="position", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="selectType", DataFormat=DataFormat.TwosComplement)]
        public int selectType
        {
            get
            {
                return this._selectType;
            }
            set
            {
                this._selectType = value;
            }
        }
    }
}

