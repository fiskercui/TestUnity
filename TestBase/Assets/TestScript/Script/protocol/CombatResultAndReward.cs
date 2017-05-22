namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CombatResultAndReward")]
    public class CombatResultAndReward : IExtensible
    {
        private readonly List<BattleRecord> _battleRecords = new List<BattleRecord>();
        private int _combatNumMax;
        private int _combatNumReal;
        private Reward _dungeonReward;
        private Reward _dungeonReward_ExpSilver;
        private Reward _firstpassReward;
        private bool _isPlotBattle;
        private readonly List<Reward> _rewards = new List<Reward>();
        private readonly List<int> _starCompleteIndexs = new List<int>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="battleRecords", DataFormat=DataFormat.Default)]
        public List<BattleRecord> battleRecords
        {
            get
            {
                return this._battleRecords;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="combatNumMax", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int combatNumMax
        {
            get
            {
                return this._combatNumMax;
            }
            set
            {
                this._combatNumMax = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="combatNumReal", DataFormat=DataFormat.TwosComplement)]
        public int combatNumReal
        {
            get
            {
                return this._combatNumReal;
            }
            set
            {
                this._combatNumReal = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="dungeonReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Reward dungeonReward
        {
            get
            {
                return this._dungeonReward;
            }
            set
            {
                this._dungeonReward = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="dungeonReward_ExpSilver", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Reward dungeonReward_ExpSilver
        {
            get
            {
                return this._dungeonReward_ExpSilver;
            }
            set
            {
                this._dungeonReward_ExpSilver = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(9, IsRequired=false, Name="firstpassReward", DataFormat=DataFormat.Default)]
        public Reward firstpassReward
        {
            get
            {
                return this._firstpassReward;
            }
            set
            {
                this._firstpassReward = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="isPlotBattle", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isPlotBattle
        {
            get
            {
                return this._isPlotBattle;
            }
            set
            {
                this._isPlotBattle = value;
            }
        }

        [ProtoMember(2, Name="rewards", DataFormat=DataFormat.Default)]
        public List<Reward> rewards
        {
            get
            {
                return this._rewards;
            }
        }

        [ProtoMember(5, Name="starCompleteIndexs", DataFormat=DataFormat.TwosComplement)]
        public List<int> starCompleteIndexs
        {
            get
            {
                return this._starCompleteIndexs;
            }
        }
    }
}

