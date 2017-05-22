namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="QueryDiner")]
    public class QueryDiner : IExtensible
    {
        private int _avatarResourceId;
        private int _breakThroughLevel;
        private readonly List<Cost> _costs = new List<Cost>();
        private int _dinerId;
        private DomineerData _domineerData;
        private int _level;
        private readonly List<MeridianData> _meridianDatas = new List<MeridianData>();
        private int _state;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="avatarResourceId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int avatarResourceId
        {
            get
            {
                return this._avatarResourceId;
            }
            set
            {
                this._avatarResourceId = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="breakThroughLevel", DataFormat=DataFormat.TwosComplement)]
        public int breakThroughLevel
        {
            get
            {
                return this._breakThroughLevel;
            }
            set
            {
                this._breakThroughLevel = value;
            }
        }

        [ProtoMember(7, Name="costs", DataFormat=DataFormat.Default)]
        public List<Cost> costs
        {
            get
            {
                return this._costs;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="dinerId", DataFormat=DataFormat.TwosComplement)]
        public int dinerId
        {
            get
            {
                return this._dinerId;
            }
            set
            {
                this._dinerId = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="domineerData", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public DomineerData domineerData
        {
            get
            {
                return this._domineerData;
            }
            set
            {
                this._domineerData = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
        public int level
        {
            get
            {
                return this._level;
            }
            set
            {
                this._level = value;
            }
        }

        [ProtoMember(5, Name="meridianDatas", DataFormat=DataFormat.Default)]
        public List<MeridianData> meridianDatas
        {
            get
            {
                return this._meridianDatas;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="state", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int state
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
            }
        }
    }
}

