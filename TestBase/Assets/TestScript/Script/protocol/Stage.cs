namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Stage")]
    public class Stage : IExtensible
    {
        private int _costMove;
        private int _eventType;
        private int _iconId;
        private int _index;
        private bool _showCombatIcon;
        private int _status;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="costMove", DataFormat=DataFormat.TwosComplement)]
        public int costMove
        {
            get
            {
                return this._costMove;
            }
            set
            {
                this._costMove = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="eventType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int eventType
        {
            get
            {
                return this._eventType;
            }
            set
            {
                this._eventType = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int iconId
        {
            get
            {
                return this._iconId;
            }
            set
            {
                this._iconId = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="showCombatIcon", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool showCombatIcon
        {
            get
            {
                return this._showCombatIcon;
            }
            set
            {
                this._showCombatIcon = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="status", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

