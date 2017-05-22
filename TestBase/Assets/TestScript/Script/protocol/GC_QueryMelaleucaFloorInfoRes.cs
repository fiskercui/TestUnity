namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="GC_QueryMelaleucaFloorInfoRes")]
    public class GC_QueryMelaleucaFloorInfoRes : IExtensible
    {
        private int _callback;
        private readonly List<Reward> _firstPassReward = new List<Reward>();
        private readonly List<NpcInfo> _npcInfos = new List<NpcInfo>();
        private readonly List<Reward> _passReward = new List<Reward>();
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

        [ProtoMember(5, Name="firstPassReward", DataFormat=DataFormat.Default)]
        public List<Reward> firstPassReward
        {
            get
            {
                return this._firstPassReward;
            }
        }

        [ProtoMember(3, Name="npcInfos", DataFormat=DataFormat.Default)]
        public List<NpcInfo> npcInfos
        {
            get
            {
                return this._npcInfos;
            }
        }

        [ProtoMember(4, Name="passReward", DataFormat=DataFormat.Default)]
        public List<Reward> passReward
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

