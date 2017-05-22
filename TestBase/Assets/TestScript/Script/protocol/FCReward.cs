namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="FCReward")]
    public class FCReward : IExtensible
    {
        private int _breakThroughLevel;
        private int _count;
        private int _id;
        private int _level;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="breakThroughLevel", DataFormat=DataFormat.TwosComplement)]
        public int breakThroughLevel
        {
            get
            {
                return this._breakThroughLevel;
            }
            set
            {
                this._breakThroughLevel = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
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
    }
}

