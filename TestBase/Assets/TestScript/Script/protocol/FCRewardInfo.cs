namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="FCRewardInfo")]
    public class FCRewardInfo : IExtensible
    {
        private readonly List<FCReward> _fcRewards = new List<FCReward>();
        private int _lowerLimit;
        private int _upperLimit;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, Name="fcRewards", DataFormat=DataFormat.Default)]
        public List<FCReward> fcRewards
        {
            get
            {
                return this._fcRewards;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="lowerLimit", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int lowerLimit
        {
            get
            {
                return this._lowerLimit;
            }
            set
            {
                this._lowerLimit = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="upperLimit", DataFormat=DataFormat.TwosComplement)]
        public int upperLimit
        {
            get
            {
                return this._upperLimit;
            }
            set
            {
                this._upperLimit = value;
            }
        }
    }
}

