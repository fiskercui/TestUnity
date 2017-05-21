namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="QualityCost")]
    public class QualityCost : IExtensible
    {
        private readonly List<Cost> _costs = new List<Cost>();
        private int _qualityLevel;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, Name="costs", DataFormat=DataFormat.Default)]
        public List<Cost> costs
        {
            get
            {
                return this._costs;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="qualityLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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
    }
}

