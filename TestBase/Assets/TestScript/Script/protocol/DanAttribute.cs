namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="DanAttribute")]
    public class DanAttribute : IExtensible
    {
        private readonly List<int> _funcParams = new List<int>();
        private int _funcType;
        private int _id;
        private readonly List<PropertyModifierSet> _propertyModifierSets = new List<PropertyModifierSet>();
        private readonly List<TargetCondition> _targetConditions = new List<TargetCondition>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, Name="funcParams", DataFormat=DataFormat.TwosComplement)]
        public List<int> funcParams
        {
            get
            {
                return this._funcParams;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="funcType", DataFormat=DataFormat.TwosComplement)]
        public int funcType
        {
            get
            {
                return this._funcType;
            }
            set
            {
                this._funcType = value;
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

        [ProtoMember(5, Name="propertyModifierSets", DataFormat=DataFormat.Default)]
        public List<PropertyModifierSet> propertyModifierSets
        {
            get
            {
                return this._propertyModifierSets;
            }
        }

        [ProtoMember(4, Name="targetConditions", DataFormat=DataFormat.Default)]
        public List<TargetCondition> targetConditions
        {
            get
            {
                return this._targetConditions;
            }
        }
    }
}

