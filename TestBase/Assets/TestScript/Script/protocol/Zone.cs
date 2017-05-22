namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Zone")]
    public class Zone : IExtensible
    {
        private readonly List<DungeonDifficulty> _dungeonDifficulties = new List<DungeonDifficulty>();
        private int _status;
        private int _zoneId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, Name="dungeonDifficulties", DataFormat=DataFormat.Default)]
        public List<DungeonDifficulty> dungeonDifficulties
        {
            get
            {
                return this._dungeonDifficulties;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="status", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="zoneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int zoneId
        {
            get
            {
                return this._zoneId;
            }
            set
            {
                this._zoneId = value;
            }
        }
    }
}

