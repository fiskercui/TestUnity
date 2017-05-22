namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="ShowCounter")]
    public class ShowCounter : IExtensible
    {
        private int _remainCount;
        private readonly List<ShowReward> _rewards = new List<ShowReward>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="remainCount", DataFormat=DataFormat.TwosComplement)]
        public int remainCount
        {
            get
            {
                return this._remainCount;
            }
            set
            {
                this._remainCount = value;
            }
        }

        [ProtoMember(2, Name="rewards", DataFormat=DataFormat.Default)]
        public List<ShowReward> rewards
        {
            get
            {
                return this._rewards;
            }
        }
    }
}

