namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="RewardView")]
    public class RewardView : IExtensible
    {
        private int _attributeAlgorithmId;
        private int _breakthoughtLevel;
        private int _count;
        private int _id;
        private int _increase;
        private int _level;
        private float _possibility;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="attributeAlgorithmId", DataFormat=DataFormat.TwosComplement)]
        public int attributeAlgorithmId
        {
            get
            {
                return this._attributeAlgorithmId;
            }
            set
            {
                this._attributeAlgorithmId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="breakthoughtLevel", DataFormat=DataFormat.TwosComplement)]
        public int breakthoughtLevel
        {
            get
            {
                return this._breakthoughtLevel;
            }
            set
            {
                this._breakthoughtLevel = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="increase", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int increase
        {
            get
            {
                return this._increase;
            }
            set
            {
                this._increase = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(6, IsRequired=false, Name="possibility", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float possibility
        {
            get
            {
                return this._possibility;
            }
            set
            {
                this._possibility = value;
            }
        }
    }
}

