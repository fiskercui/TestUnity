namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_CombatFriendCampaignRes")]
    public class GC_CombatFriendCampaignRes : IExtensible
    {
        private int _callback;
        private CombatResultAndReward _combatResultAndReward;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private readonly List<HpInfo> _enemyHpInfo = new List<HpInfo>();
        private Player _enemyPlayer;
        private bool _isJoin;
        private int _passStageId;
        private int _result;
        private RobotInfo _robotInfo;
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

        [ProtoMember(8, Name="enemyHpInfo", DataFormat=DataFormat.Default)]
        public List<HpInfo> enemyHpInfo
        {
            get
            {
                return this._enemyHpInfo;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="enemyPlayer", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Player enemyPlayer
        {
            get
            {
                return this._enemyPlayer;
            }
            set
            {
                this._enemyPlayer = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="isJoin", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isJoin
        {
            get
            {
                return this._isJoin;
            }
            set
            {
                this._isJoin = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="passStageId", DataFormat=DataFormat.TwosComplement)]
        public int passStageId
        {
            get
            {
                return this._passStageId;
            }
            set
            {
                this._passStageId = value;
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

        [DefaultValue((string) null), ProtoMember(9, IsRequired=false, Name="robotInfo", DataFormat=DataFormat.Default)]
        public RobotInfo robotInfo
        {
            get
            {
                return this._robotInfo;
            }
            set
            {
                this._robotInfo = value;
            }
        }
    }
}

