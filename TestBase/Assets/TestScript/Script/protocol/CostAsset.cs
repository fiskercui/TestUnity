namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CostAsset")]
    public class CostAsset : IExtensible
    {
        private int _breakThroughLevelFrom;
        private int _breakThroughLevelTo;
        private int _count;
        private int _iconId;
        private int _levelFrom;
        private int _levelTo;
        private int _qualityLevel;
        private int _subType;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, IsRequired=false, Name="breakThroughLevelFrom", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int breakThroughLevelFrom
        {
            get
            {
                return this._breakThroughLevelFrom;
            }
            set
            {
                this._breakThroughLevelFrom = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="breakThroughLevelTo", DataFormat=DataFormat.TwosComplement)]
        public int breakThroughLevelTo
        {
            get
            {
                return this._breakThroughLevelTo;
            }
            set
            {
                this._breakThroughLevelTo = value;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
        public int count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement)]
        public int iconId
        {
            get
            {
                return this._iconId;
            }
            set
            {
                this._iconId = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="levelFrom", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int levelFrom
        {
            get
            {
                return this._levelFrom;
            }
            set
            {
                this._levelFrom = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="levelTo", DataFormat=DataFormat.TwosComplement)]
        public int levelTo
        {
            get
            {
                return this._levelTo;
            }
            set
            {
                this._levelTo = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="qualityLevel", DataFormat=DataFormat.TwosComplement)]
        public int qualityLevel
        {
            get
            {
                return this._qualityLevel;
            }
            set
            {
                this._qualityLevel = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="subType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int subType
        {
            get
            {
                return this._subType;
            }
            set
            {
                this._subType = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

