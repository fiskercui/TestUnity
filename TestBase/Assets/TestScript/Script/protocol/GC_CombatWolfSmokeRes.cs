namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_CombatWolfSmokeRes")]
    public class GC_CombatWolfSmokeRes : IExtensible
    {
        private int _alreadyFailedTimes;
        private int _alreadyResetTimes;
        private int _callback;
        private CombatResultAndReward _combatResultAndReward;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private CostAndRewardAndSync _eggsCostAndRewardAndSync;
        private bool _isJoin;
        private int _result;
        private Avatar _showAvatar;
        private int _stageId;
        private readonly List<WolfEggs> _wolfEggs = new List<WolfEggs>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(6, IsRequired=false, Name="alreadyFailedTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int alreadyFailedTimes
        {
            get
            {
                return this._alreadyFailedTimes;
            }
            set
            {
                this._alreadyFailedTimes = value;
            }
        }

        [ProtoMember(11, IsRequired=false, Name="alreadyResetTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int alreadyResetTimes
        {
            get
            {
                return this._alreadyResetTimes;
            }
            set
            {
                this._alreadyResetTimes = value;
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

        [DefaultValue((string) null), ProtoMember(9, IsRequired=false, Name="eggsCostAndRewardAndSync", DataFormat=DataFormat.Default)]
        public CostAndRewardAndSync eggsCostAndRewardAndSync
        {
            get
            {
                return this._eggsCostAndRewardAndSync;
            }
            set
            {
                this._eggsCostAndRewardAndSync = value;
            }
        }

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="isJoin", DataFormat=DataFormat.Default)]
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

        [DefaultValue((string) null), ProtoMember(10, IsRequired=false, Name="showAvatar", DataFormat=DataFormat.Default)]
        public Avatar showAvatar
        {
            get
            {
                return this._showAvatar;
            }
            set
            {
                this._showAvatar = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="stageId", DataFormat=DataFormat.TwosComplement)]
        public int stageId
        {
            get
            {
                return this._stageId;
            }
            set
            {
                this._stageId = value;
            }
        }

        [ProtoMember(8, Name="wolfEggs", DataFormat=DataFormat.Default)]
        public List<WolfEggs> wolfEggs
        {
            get
            {
                return this._wolfEggs;
            }
        }
    }
}

