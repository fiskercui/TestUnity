namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_ContinueCombatRes")]
    public class GC_ContinueCombatRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private Dungeon _dungeon;
        private int _result;
        private readonly List<CombatResultAndReward> _rewards = new List<CombatResultAndReward>();
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

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="dungeon", DataFormat=DataFormat.Default)]
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

        [ProtoMember(4, Name="rewards", DataFormat=DataFormat.Default)]
        public List<CombatResultAndReward> rewards
        {
            get
            {
                return this._rewards;
            }
        }
    }
}

