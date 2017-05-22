namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="ItemEx")]
    public class ItemEx : IExtensible
    {
        private int _count;
        private int _extensionBreakThroughLevelFrom;
        private int _extensionBreakThroughLevelTo;
        private int _extensionLevelFrom;
        private int _extensionLevelTo;
        private int _id;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="extensionBreakThroughLevelFrom", DataFormat=DataFormat.TwosComplement)]
        public int extensionBreakThroughLevelFrom
        {
            get
            {
                return this._extensionBreakThroughLevelFrom;
            }
            set
            {
                this._extensionBreakThroughLevelFrom = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="extensionBreakThroughLevelTo", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int extensionBreakThroughLevelTo
        {
            get
            {
                return this._extensionBreakThroughLevelTo;
            }
            set
            {
                this._extensionBreakThroughLevelTo = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="extensionLevelFrom", DataFormat=DataFormat.TwosComplement)]
        public int extensionLevelFrom
        {
            get
            {
                return this._extensionLevelFrom;
            }
            set
            {
                this._extensionLevelFrom = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="extensionLevelTo", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int extensionLevelTo
        {
            get
            {
                return this._extensionLevelTo;
            }
            set
            {
                this._extensionLevelTo = value;
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
    }
}

