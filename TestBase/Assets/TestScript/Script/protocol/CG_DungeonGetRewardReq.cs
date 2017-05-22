namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_DungeonGetRewardReq")]
    public class CG_DungeonGetRewardReq : IExtensible
    {
        private int _boxIndex;
        private int _callback;
        private int _dungeonDifficulty;
        private int _zoneId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired=false, Name="boxIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int boxIndex
        {
            get
            {
                return this._boxIndex;
            }
            set
            {
                this._boxIndex = value;
            }
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

        [ProtoMember(3, IsRequired=false, Name="dungeonDifficulty", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int dungeonDifficulty
        {
            get
            {
                return this._dungeonDifficulty;
            }
            set
            {
                this._dungeonDifficulty = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="zoneId", DataFormat=DataFormat.TwosComplement)]
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

