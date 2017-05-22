namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryGuildStageRes")]
    public class GC_QueryGuildStageRes : IExtensible
    {
        private int _callback;
        private Cost _cost;
        private int _explorePoint;
        private int _freeChallengeCount;
        private int _guildLevel;
        private int _handResetStatus;
        private long _handResetTime;
        private int _index;
        private bool _isLastMap;
        private bool _isStageOpen;
        private int _itemChallengeCount;
        private int _mapNum;
        private int _needGuildLevel;
        private int _needPassBossCount;
        private string _preName = "";
        private int _result;
        private string _roadPreName = "";
        private readonly List<Stage> _stages = new List<Stage>();
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

        [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="cost", DataFormat=DataFormat.Default)]
        public Cost cost
        {
            get
            {
                return this._cost;
            }
            set
            {
                this._cost = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="explorePoint", DataFormat=DataFormat.TwosComplement)]
        public int explorePoint
        {
            get
            {
                return this._explorePoint;
            }
            set
            {
                this._explorePoint = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="freeChallengeCount", DataFormat=DataFormat.TwosComplement)]
        public int freeChallengeCount
        {
            get
            {
                return this._freeChallengeCount;
            }
            set
            {
                this._freeChallengeCount = value;
            }
        }

        [ProtoMember(0x12, IsRequired=false, Name="guildLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildLevel
        {
            get
            {
                return this._guildLevel;
            }
            set
            {
                this._guildLevel = value;
            }
        }

        [ProtoMember(15, IsRequired=false, Name="handResetStatus", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int handResetStatus
        {
            get
            {
                return this._handResetStatus;
            }
            set
            {
                this._handResetStatus = value;
            }
        }

        [ProtoMember(14, IsRequired=false, Name="handResetTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long handResetTime
        {
            get
            {
                return this._handResetTime;
            }
            set
            {
                this._handResetTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(10, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(false), ProtoMember(0x11, IsRequired=false, Name="isLastMap", DataFormat=DataFormat.Default)]
        public bool isLastMap
        {
            get
            {
                return this._isLastMap;
            }
            set
            {
                this._isLastMap = value;
            }
        }

        [DefaultValue(false), ProtoMember(13, IsRequired=false, Name="isStageOpen", DataFormat=DataFormat.Default)]
        public bool isStageOpen
        {
            get
            {
                return this._isStageOpen;
            }
            set
            {
                this._isStageOpen = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="itemChallengeCount", DataFormat=DataFormat.TwosComplement)]
        public int itemChallengeCount
        {
            get
            {
                return this._itemChallengeCount;
            }
            set
            {
                this._itemChallengeCount = value;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="mapNum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int mapNum
        {
            get
            {
                return this._mapNum;
            }
            set
            {
                this._mapNum = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x10, IsRequired=false, Name="needGuildLevel", DataFormat=DataFormat.TwosComplement)]
        public int needGuildLevel
        {
            get
            {
                return this._needGuildLevel;
            }
            set
            {
                this._needGuildLevel = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="needPassBossCount", DataFormat=DataFormat.TwosComplement)]
        public int needPassBossCount
        {
            get
            {
                return this._needPassBossCount;
            }
            set
            {
                this._needPassBossCount = value;
            }
        }

        [DefaultValue(""), ProtoMember(11, IsRequired=false, Name="preName", DataFormat=DataFormat.Default)]
        public string preName
        {
            get
            {
                return this._preName;
            }
            set
            {
                this._preName = value;
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

        [ProtoMember(12, IsRequired=false, Name="roadPreName", DataFormat=DataFormat.Default), DefaultValue("")]
        public string roadPreName
        {
            get
            {
                return this._roadPreName;
            }
            set
            {
                this._roadPreName = value;
            }
        }

        [ProtoMember(3, Name="stages", DataFormat=DataFormat.Default)]
        public List<Stage> stages
        {
            get
            {
                return this._stages;
            }
        }
    }
}

