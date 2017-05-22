namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="InviteReward")]
    public class InviteReward : IExtensible
    {
        private int _id;
        private int _pickState;
        private int _requireCount;
        private int _requireLevel;
        private Reward _reward;
        private int _sortIndex;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(5, IsRequired=false, Name="pickState", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int pickState
        {
            get
            {
                return this._pickState;
            }
            set
            {
                this._pickState = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="requireCount", DataFormat=DataFormat.TwosComplement)]
        public int requireCount
        {
            get
            {
                return this._requireCount;
            }
            set
            {
                this._requireCount = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="requireLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int requireLevel
        {
            get
            {
                return this._requireLevel;
            }
            set
            {
                this._requireLevel = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="reward", DataFormat=DataFormat.Default)]
        public Reward reward
        {
            get
            {
                return this._reward;
            }
            set
            {
                this._reward = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="sortIndex", DataFormat=DataFormat.TwosComplement)]
        public int sortIndex
        {
            get
            {
                return this._sortIndex;
            }
            set
            {
                this._sortIndex = value;
            }
        }
    }
}

