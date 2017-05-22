namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_DiceRes")]
    public class GC_DiceRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private readonly List<int> _diceResults = new List<int>();
        private GuildTaskInfo _guildTaskInfo;
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

        [ProtoMember(3, Name="diceResults", DataFormat=DataFormat.TwosComplement)]
        public List<int> diceResults
        {
            get
            {
                return this._diceResults;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="guildTaskInfo", DataFormat=DataFormat.Default)]
        public GuildTaskInfo guildTaskInfo
        {
            get
            {
                return this._guildTaskInfo;
            }
            set
            {
                this._guildTaskInfo = value;
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

