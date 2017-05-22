namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_MarvellousNextMarvellousRes")]
    public class GC_MarvellousNextMarvellousRes : IExtensible
    {
        private int _callBack;
        private CombatResultAndReward _combatResultAndReward;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private readonly List<DelayReward> _currentGeneratedDelayRewards = new List<DelayReward>();
        private CostAndRewardAndSync _fixRewardPackage;
        private MarvellousProto _marvellousProto;
        private CostAndRewardAndSync _normalTipsReward;
        private CostAndRewardAndSync _randRewardPackage;
        private int _result;
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

        [ProtoMember(5, IsRequired=false, Name="combatResultAndReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue((string) null), ProtoMember(6, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default)]
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

        [ProtoMember(4, Name="currentGeneratedDelayRewards", DataFormat=DataFormat.Default)]
        public List<DelayReward> currentGeneratedDelayRewards
        {
            get
            {
                return this._currentGeneratedDelayRewards;
            }
        }

        [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="fixRewardPackage", DataFormat=DataFormat.Default)]
        public CostAndRewardAndSync fixRewardPackage
        {
            get
            {
                return this._fixRewardPackage;
            }
            set
            {
                this._fixRewardPackage = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="marvellousProto", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public MarvellousProto marvellousProto
        {
            get
            {
                return this._marvellousProto;
            }
            set
            {
                this._marvellousProto = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(9, IsRequired=false, Name="normalTipsReward", DataFormat=DataFormat.Default)]
        public CostAndRewardAndSync normalTipsReward
        {
            get
            {
                return this._normalTipsReward;
            }
            set
            {
                this._normalTipsReward = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="randRewardPackage", DataFormat=DataFormat.Default)]
        public CostAndRewardAndSync randRewardPackage
        {
            get
            {
                return this._randRewardPackage;
            }
            set
            {
                this._randRewardPackage = value;
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

