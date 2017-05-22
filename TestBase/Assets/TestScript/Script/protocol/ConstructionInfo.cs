namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="ConstructionInfo")]
    public class ConstructionInfo : IExtensible
    {
        private int _contribution;
        private int _guildAccomplishTaskCount;
        private int _guildConstruction;
        private int _guildLevel;
        private int _guildMaxAccomplishPerDay;
        private int _guildMoney;
        private int _guildMoveCount;
        private long _joinTime;
        private int _lvUpConstruction;
        private long _nextRefreshTime;
        private int _playerAccomplishTaskCount;
        private int _playerMaxAccomplishPerDay;
        private readonly List<Cost> _refershCosts = new List<Cost>();
        private readonly List<ConstructionTask> _tasks = new List<ConstructionTask>();
        private long _waitTime;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="contribution", DataFormat=DataFormat.TwosComplement)]
        public int contribution
        {
            get
            {
                return this._contribution;
            }
            set
            {
                this._contribution = value;
            }
        }

        [DefaultValue(0), ProtoMember(10, IsRequired=false, Name="guildAccomplishTaskCount", DataFormat=DataFormat.TwosComplement)]
        public int guildAccomplishTaskCount
        {
            get
            {
                return this._guildAccomplishTaskCount;
            }
            set
            {
                this._guildAccomplishTaskCount = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="guildConstruction", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildConstruction
        {
            get
            {
                return this._guildConstruction;
            }
            set
            {
                this._guildConstruction = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="guildLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildLevel
        {
            get
            {
                return this._guildLevel;
            }
            set
            {
                this._guildLevel = value;
            }
        }

        [ProtoMember(14, IsRequired=false, Name="guildMaxAccomplishPerDay", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildMaxAccomplishPerDay
        {
            get
            {
                return this._guildMaxAccomplishPerDay;
            }
            set
            {
                this._guildMaxAccomplishPerDay = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="guildMoney", DataFormat=DataFormat.TwosComplement)]
        public int guildMoney
        {
            get
            {
                return this._guildMoney;
            }
            set
            {
                this._guildMoney = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="guildMoveCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildMoveCount
        {
            get
            {
                return this._guildMoveCount;
            }
            set
            {
                this._guildMoveCount = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="joinTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long joinTime
        {
            get
            {
                return this._joinTime;
            }
            set
            {
                this._joinTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="lvUpConstruction", DataFormat=DataFormat.TwosComplement)]
        public int lvUpConstruction
        {
            get
            {
                return this._lvUpConstruction;
            }
            set
            {
                this._lvUpConstruction = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(11, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement)]
        public long nextRefreshTime
        {
            get
            {
                return this._nextRefreshTime;
            }
            set
            {
                this._nextRefreshTime = value;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="playerAccomplishTaskCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int playerAccomplishTaskCount
        {
            get
            {
                return this._playerAccomplishTaskCount;
            }
            set
            {
                this._playerAccomplishTaskCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(13, IsRequired=false, Name="playerMaxAccomplishPerDay", DataFormat=DataFormat.TwosComplement)]
        public int playerMaxAccomplishPerDay
        {
            get
            {
                return this._playerMaxAccomplishPerDay;
            }
            set
            {
                this._playerMaxAccomplishPerDay = value;
            }
        }

        [ProtoMember(15, Name="refershCosts", DataFormat=DataFormat.Default)]
        public List<Cost> refershCosts
        {
            get
            {
                return this._refershCosts;
            }
        }

        [ProtoMember(8, Name="tasks", DataFormat=DataFormat.Default)]
        public List<ConstructionTask> tasks
        {
            get
            {
                return this._tasks;
            }
        }

        [ProtoMember(12, IsRequired=false, Name="waitTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long waitTime
        {
            get
            {
                return this._waitTime;
            }
            set
            {
                this._waitTime = value;
            }
        }
    }
}

