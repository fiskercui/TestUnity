namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="QualityReward")]
    public class QualityReward : IExtensible
    {
        private int _qualityLevel;
        private readonly List<Reward> _rewards = new List<Reward>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [ProtoMember(2, Name="rewards", DataFormat=DataFormat.Default)]
        public List<Reward> rewards
        {
            get
            {
                return this._rewards;
            }
        }
    }
}

