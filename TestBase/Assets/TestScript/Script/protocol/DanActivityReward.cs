namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="DanActivityReward")]
    public class DanActivityReward : IExtensible
    {
        private int _alchemyCount;
        private readonly List<ShowReward> _baseRewards = new List<ShowReward>();
        private int _breakthought;
        private readonly List<ShowReward> _extraRewards = new List<ShowReward>();
        private int _level;
        private int _resourseId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="alchemyCount", DataFormat=DataFormat.TwosComplement)]
        public int alchemyCount
        {
            get
            {
                return this._alchemyCount;
            }
            set
            {
                this._alchemyCount = value;
            }
        }

        [ProtoMember(5, Name="baseRewards", DataFormat=DataFormat.Default)]
        public List<ShowReward> baseRewards
        {
            get
            {
                return this._baseRewards;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="breakthought", DataFormat=DataFormat.TwosComplement)]
        public int breakthought
        {
            get
            {
                return this._breakthought;
            }
            set
            {
                this._breakthought = value;
            }
        }

        [ProtoMember(6, Name="extraRewards", DataFormat=DataFormat.Default)]
        public List<ShowReward> extraRewards
        {
            get
            {
                return this._extraRewards;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
        public int level
        {
            get
            {
                return this._level;
            }
            set
            {
                this._level = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="resourseId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int resourseId
        {
            get
            {
                return this._resourseId;
            }
            set
            {
                this._resourseId = value;
            }
        }
    }
}

