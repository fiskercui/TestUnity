namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryArenaRankRes")]
    public class GC_QueryArenaRankRes : IExtensible
    {
        private int _arenaGradeId;
        private int _callback;
        private int _challengeTimes;
        private long _gradePoint;
        private long _lastResetChallengeTime;
        private readonly List<PlayerRecord> _playerRecords = new List<PlayerRecord>();
        private int _result;
        private int _selfRank;
        private int _speed;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired=false, Name="arenaGradeId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int arenaGradeId
        {
            get
            {
                return this._arenaGradeId;
            }
            set
            {
                this._arenaGradeId = value;
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

        [ProtoMember(3, IsRequired=false, Name="challengeTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int challengeTimes
        {
            get
            {
                return this._challengeTimes;
            }
            set
            {
                this._challengeTimes = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="gradePoint", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long gradePoint
        {
            get
            {
                return this._gradePoint;
            }
            set
            {
                this._gradePoint = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(6, IsRequired=false, Name="lastResetChallengeTime", DataFormat=DataFormat.TwosComplement)]
        public long lastResetChallengeTime
        {
            get
            {
                return this._lastResetChallengeTime;
            }
            set
            {
                this._lastResetChallengeTime = value;
            }
        }

        [ProtoMember(9, Name="playerRecords", DataFormat=DataFormat.Default)]
        public List<PlayerRecord> playerRecords
        {
            get
            {
                return this._playerRecords;
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

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="selfRank", DataFormat=DataFormat.TwosComplement)]
        public int selfRank
        {
            get
            {
                return this._selfRank;
            }
            set
            {
                this._selfRank = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="speed", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int speed
        {
            get
            {
                return this._speed;
            }
            set
            {
                this._speed = value;
            }
        }
    }
}

