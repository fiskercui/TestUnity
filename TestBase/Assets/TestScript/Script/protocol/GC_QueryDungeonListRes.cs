namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryDungeonListRes")]
    public class GC_QueryDungeonListRes : IExtensible
    {
        private int _callback;
        private int _lastDungeonId;
        private long _lastResetDungeonTime;
        private int _lastSecretDungeonId;
        private int _lastSecretZoneId;
        private int _lastZoneId;
        private int _positionId;
        private int _result;
        private readonly List<Zone> _secretZones = new List<Zone>();
        private readonly List<Zone> _zones = new List<Zone>();
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

        [ProtoMember(5, IsRequired=false, Name="lastDungeonId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int lastDungeonId
        {
            get
            {
                return this._lastDungeonId;
            }
            set
            {
                this._lastDungeonId = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="lastResetDungeonTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long lastResetDungeonTime
        {
            get
            {
                return this._lastResetDungeonTime;
            }
            set
            {
                this._lastResetDungeonTime = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="lastSecretDungeonId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int lastSecretDungeonId
        {
            get
            {
                return this._lastSecretDungeonId;
            }
            set
            {
                this._lastSecretDungeonId = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="lastSecretZoneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int lastSecretZoneId
        {
            get
            {
                return this._lastSecretZoneId;
            }
            set
            {
                this._lastSecretZoneId = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="lastZoneId", DataFormat=DataFormat.TwosComplement)]
        public int lastZoneId
        {
            get
            {
                return this._lastZoneId;
            }
            set
            {
                this._lastZoneId = value;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="positionId", DataFormat=DataFormat.TwosComplement)]
        public int positionId
        {
            get
            {
                return this._positionId;
            }
            set
            {
                this._positionId = value;
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

        [ProtoMember(4, Name="secretZones", DataFormat=DataFormat.Default)]
        public List<Zone> secretZones
        {
            get
            {
                return this._secretZones;
            }
        }

        [ProtoMember(3, Name="zones", DataFormat=DataFormat.Default)]
        public List<Zone> zones
        {
            get
            {
                return this._zones;
            }
        }
    }
}

