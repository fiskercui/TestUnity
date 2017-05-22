namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="TravelData")]
    public class TravelData : IExtensible
    {
        private readonly List<int> _alreadyBuyGoodIds = new List<int>();
        private int _dungeonId;
        private long _openTime;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, Name="alreadyBuyGoodIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> alreadyBuyGoodIds
        {
            get
            {
                return this._alreadyBuyGoodIds;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="dungeonId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int dungeonId
        {
            get
            {
                return this._dungeonId;
            }
            set
            {
                this._dungeonId = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="openTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long openTime
        {
            get
            {
                return this._openTime;
            }
            set
            {
                this._openTime = value;
            }
        }
    }
}

