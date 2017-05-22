namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryQinInfoRankRes")]
    public class GC_QueryQinInfoRankRes : IExtensible
    {
        private int _callback;
        private int _continueRightCount;
        private readonly List<QinInfoRank> _qinInfoRanks = new List<QinInfoRank>();
        private int _rank;
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

        [ProtoMember(4, IsRequired=false, Name="continueRightCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int continueRightCount
        {
            get
            {
                return this._continueRightCount;
            }
            set
            {
                this._continueRightCount = value;
            }
        }

        [ProtoMember(3, Name="qinInfoRanks", DataFormat=DataFormat.Default)]
        public List<QinInfoRank> qinInfoRanks
        {
            get
            {
                return this._qinInfoRanks;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="rank", DataFormat=DataFormat.TwosComplement)]
        public int rank
        {
            get
            {
                return this._rank;
            }
            set
            {
                this._rank = value;
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

