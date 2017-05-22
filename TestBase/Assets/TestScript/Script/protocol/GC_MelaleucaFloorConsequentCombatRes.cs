namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_MelaleucaFloorConsequentCombatRes")]
    public class GC_MelaleucaFloorConsequentCombatRes : IExtensible
    {
        private int _callback;
        private int _combatCount;
        private CombatResultAndReward _combatResultAndReward;
        private CostAndRewardAndSync _firstChallengeReward;
        private readonly List<int> _firstPassLayers = new List<int>();
        private readonly List<CostAndRewardAndSync> _firstPassReward = new List<CostAndRewardAndSync>();
        private int _layers;
        private MelaleucaFloorInfo _melaleucaFloorInfo;
        private readonly List<CostAndRewardAndSync> _passReward = new List<CostAndRewardAndSync>();
        private int _result;
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

        [DefaultValue(0), ProtoMember(10, IsRequired=false, Name="combatCount", DataFormat=DataFormat.TwosComplement)]
        public int combatCount
        {
            get
            {
                return this._combatCount;
            }
            set
            {
                this._combatCount = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="combatResultAndReward", DataFormat=DataFormat.Default)]
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

        [ProtoMember(4, IsRequired=false, Name="firstChallengeReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public CostAndRewardAndSync firstChallengeReward
        {
            get
            {
                return this._firstChallengeReward;
            }
            set
            {
                this._firstChallengeReward = value;
            }
        }

        [ProtoMember(8, Name="firstPassLayers", DataFormat=DataFormat.TwosComplement)]
        public List<int> firstPassLayers
        {
            get
            {
                return this._firstPassLayers;
            }
        }

        [ProtoMember(6, Name="firstPassReward", DataFormat=DataFormat.Default)]
        public List<CostAndRewardAndSync> firstPassReward
        {
            get
            {
                return this._firstPassReward;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="layers", DataFormat=DataFormat.TwosComplement)]
        public int layers
        {
            get
            {
                return this._layers;
            }
            set
            {
                this._layers = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="melaleucaFloorInfo", DataFormat=DataFormat.Default)]
        public MelaleucaFloorInfo melaleucaFloorInfo
        {
            get
            {
                return this._melaleucaFloorInfo;
            }
            set
            {
                this._melaleucaFloorInfo = value;
            }
        }

        [ProtoMember(5, Name="passReward", DataFormat=DataFormat.Default)]
        public List<CostAndRewardAndSync> passReward
        {
            get
            {
                return this._passReward;
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
    }
}

