namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="SellGeneralReward")]
    public class SellGeneralReward : IExtensible
    {
        private int _level;
        private readonly List<QualityReward> _qualityRewards = new List<QualityReward>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(2, Name="qualityRewards", DataFormat=DataFormat.Default)]
        public List<QualityReward> qualityRewards
        {
            get
            {
                return this._qualityRewards;
            }
        }
    }
}

