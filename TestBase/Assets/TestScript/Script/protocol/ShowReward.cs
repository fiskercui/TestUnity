namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="ShowReward")]
    public class ShowReward : IExtensible
    {
        private readonly List<int> _attributeIds = new List<int>();
        private int _breakthought;
        private int _count;
        private readonly List<DanAttributeGroup> _danAttributeGroups = new List<DanAttributeGroup>();
        private int _id;
        private int _level;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, Name="attributeIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> attributeIds
        {
            get
            {
                return this._attributeIds;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="breakthought", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(6, Name="danAttributeGroups", DataFormat=DataFormat.Default)]
        public List<DanAttributeGroup> danAttributeGroups
        {
            get
            {
                return this._danAttributeGroups;
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

        [ProtoMember(3, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

