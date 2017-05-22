namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_BuyTravelRes")]
    public class GC_BuyTravelRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private int _result;
        private TravelData _travelData;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
        public int callback
        {
            get
            {
                return this._callback;
            }
            set
            {
                this._callback = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default)]
        public CostAndRewardAndSync costAndRewardAndSync
        {
            get
            {
                return this._costAndRewardAndSync;
            }
            set
            {
                this._costAndRewardAndSync = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
        public int result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="travelData", DataFormat=DataFormat.Default)]
        public TravelData travelData
        {
            get
            {
                return this._travelData;
            }
            set
            {
                this._travelData = value;
            }
        }
    }
}

