namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="FreezeInfo")]
    public class FreezeInfo : IExtensible
    {
        private long _freezeEndTime;
        private long _freezeStartTime;
        private int _playerId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((long) 0L), ProtoMember(3, IsRequired=false, Name="freezeEndTime", DataFormat=DataFormat.TwosComplement)]
        public long freezeEndTime
        {
            get
            {
                return this._freezeEndTime;
            }
            set
            {
                this._freezeEndTime = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(2, IsRequired=false, Name="freezeStartTime", DataFormat=DataFormat.TwosComplement)]
        public long freezeStartTime
        {
            get
            {
                return this._freezeStartTime;
            }
            set
            {
                this._freezeStartTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement)]
        public int playerId
        {
            get
            {
                return this._playerId;
            }
            set
            {
                this._playerId = value;
            }
        }
    }
}

