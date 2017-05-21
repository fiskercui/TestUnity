namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="PowerUpCost")]
    public class PowerUpCost : IExtensible
    {
        private int _level;
        private readonly List<QualityCost> _qualityCosts = new List<QualityCost>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(2, Name="qualityCosts", DataFormat=DataFormat.Default)]
        public List<QualityCost> qualityCosts
        {
            get
            {
                return this._qualityCosts;
            }
        }
    }
}

