namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildStageQueryTalentRes")]
    public class GC_GuildStageQueryTalentRes : IExtensible
    {
        private readonly List<BossTalent> _bossTalents = new List<BossTalent>();
        private int _callback;
        private int _remainResetTimes;
        private int _result;
        private int _talentPoint;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, Name="bossTalents", DataFormat=DataFormat.Default)]
        public List<BossTalent> bossTalents
        {
            get
            {
                return this._bossTalents;
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

        [ProtoMember(5, IsRequired=false, Name="remainResetTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int remainResetTimes
        {
            get
            {
                return this._remainResetTimes;
            }
            set
            {
                this._remainResetTimes = value;
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

        [ProtoMember(3, IsRequired=false, Name="talentPoint", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int talentPoint
        {
            get
            {
                return this._talentPoint;
            }
            set
            {
                this._talentPoint = value;
            }
        }
    }
}

