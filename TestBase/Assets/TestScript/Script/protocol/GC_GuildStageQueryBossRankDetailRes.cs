namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildStageQueryBossRankDetailRes")]
    public class GC_GuildStageQueryBossRankDetailRes : IExtensible
    {
        private BossRank _bossRank;
        private int _callback;
        private Rank _myRank;
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="bossRank", DataFormat=DataFormat.Default)]
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

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="myRank", DataFormat=DataFormat.Default)]
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
    }
}

