namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildStageCombatBossRes")]
    public class GC_GuildStageCombatBossRes : IExtensible
    {
        private BossRank _bossRank;
        private int _callback;
        private CombatResultAndReward _combatResultAndReward;
        private readonly List<ShowReward> _commonRewards = new List<ShowReward>();
        private CostAndRewardAndSync _costAndRewardAndSync;
        private readonly List<ShowReward> _extraRewards = new List<ShowReward>();
        private bool _hasActivateGoods;
        private Rank _myRank;
        private int _result;
        private Rank _thisData;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((string) null), ProtoMember(6, IsRequired=false, Name="bossRank", DataFormat=DataFormat.Default)]
        public BossRank bossRank
        {
            get
            {
                return this._bossRank;
            }
            set
            {
                this._bossRank = value;
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

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="combatResultAndReward", DataFormat=DataFormat.Default)]
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

        [ProtoMember(7, Name="commonRewards", DataFormat=DataFormat.Default)]
        public List<ShowReward> commonRewards
        {
            get
            {
                return this._commonRewards;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [ProtoMember(8, Name="extraRewards", DataFormat=DataFormat.Default)]
        public List<ShowReward> extraRewards
        {
            get
            {
                return this._extraRewards;
            }
        }

        [DefaultValue(false), ProtoMember(9, IsRequired=false, Name="hasActivateGoods", DataFormat=DataFormat.Default)]
        public bool hasActivateGoods
        {
            get
            {
                return this._hasActivateGoods;
            }
            set
            {
                this._hasActivateGoods = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="myRank", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Rank myRank
        {
            get
            {
                return this._myRank;
            }
            set
            {
                this._myRank = value;
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

        [ProtoMember(10, IsRequired=false, Name="thisData", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Rank thisData
        {
            get
            {
                return this._thisData;
            }
            set
            {
                this._thisData = value;
            }
        }
    }
}

