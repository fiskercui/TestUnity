namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="MelaleucaFloorInfo")]
    public class MelaleucaFloorInfo : IExtensible
    {
        private int _challengeFailsCount;
        private int _currentLayer;
        private int _currentPoint;
        private int _maxPassLayer;
        private long _nextResetTime;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="challengeFailsCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int challengeFailsCount
        {
            get
            {
                return this._challengeFailsCount;
            }
            set
            {
                this._challengeFailsCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="currentLayer", DataFormat=DataFormat.TwosComplement)]
        public int currentLayer
        {
            get
            {
                return this._currentLayer;
            }
            set
            {
                this._currentLayer = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="currentPoint", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int currentPoint
        {
            get
            {
                return this._currentPoint;
            }
            set
            {
                this._currentPoint = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="maxPassLayer", DataFormat=DataFormat.TwosComplement)]
        public int maxPassLayer
        {
            get
            {
                return this._maxPassLayer;
            }
            set
            {
                this._maxPassLayer = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="nextResetTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long nextResetTime
        {
            get
            {
                return this._nextResetTime;
            }
            set
            {
                this._nextResetTime = value;
            }
        }
    }
}

