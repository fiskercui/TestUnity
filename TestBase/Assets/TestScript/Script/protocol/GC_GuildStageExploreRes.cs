namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildStageExploreRes")]
    public class GC_GuildStageExploreRes : IExtensible
    {
        private int _callback;
        private CombatResultAndReward _combatResultAndReward;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private int _operateType;
        private int _result;
        private StageInfo _stageInfo;
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

        [ProtoMember(4, IsRequired=false, Name="combatResultAndReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [ProtoMember(5, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [ProtoMember(6, IsRequired=false, Name="operateType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int operateType
        {
            get
            {
                return this._operateType;
            }
            set
            {
                this._operateType = value;
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

        [ProtoMember(3, IsRequired=false, Name="stageInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public StageInfo stageInfo
        {
            get
            {
                return this._stageInfo;
            }
            set
            {
                this._stageInfo = value;
            }
        }
    }
}

