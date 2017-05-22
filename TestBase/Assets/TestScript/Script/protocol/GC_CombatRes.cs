namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_CombatRes")]
    public class GC_CombatRes : IExtensible
    {
        private int _callback;
        private CombatResultAndReward _combatResultAndReward;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private Dungeon _dungeon;
        private int _result;
        private TravelData _travelData;
        private int _zoneStatus;
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="combatResultAndReward", DataFormat=DataFormat.Default)]
        public CombatResultAndReward combatResultAndReward
        {
            get
            {
                return this._combatResultAndReward;
            }
            set
            {
                this._combatResultAndReward = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default)]
        public CostAndRewardAndSync costAndRewardAndSync
        {
            get
            {
                return this._costAndRewardAndSync;
            }
            set
            {
                this._costAndRewardAndSync = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="dungeon", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Dungeon dungeon
        {
            get
            {
                return this._dungeon;
            }
            set
            {
                this._dungeon = value;
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

        [ProtoMember(7, IsRequired=false, Name="travelData", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public TravelData travelData
        {
            get
            {
                return this._travelData;
            }
            set
            {
                this._travelData = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="zoneStatus", DataFormat=DataFormat.TwosComplement)]
        public int zoneStatus
        {
            get
            {
                return this._zoneStatus;
            }
            set
            {
                this._zoneStatus = value;
            }
        }
    }
}

