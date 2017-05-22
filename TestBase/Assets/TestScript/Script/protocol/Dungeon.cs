namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Dungeon")]
    public class Dungeon : IExtensible
    {
        private int _bestRecord;
        private int _dialogState;
        private int _dungeonId;
        private int _dungeonStatus;
        private int _todayAlreadyResetTimes;
        private int _todayCompleteTimes;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired=false, Name="bestRecord", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int bestRecord
        {
            get
            {
                return this._bestRecord;
            }
            set
            {
                this._bestRecord = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="dialogState", DataFormat=DataFormat.TwosComplement)]
        public int dialogState
        {
            get
            {
                return this._dialogState;
            }
            set
            {
                this._dialogState = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="dungeonId", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="dungeonStatus", DataFormat=DataFormat.TwosComplement)]
        public int dungeonStatus
        {
            get
            {
                return this._dungeonStatus;
            }
            set
            {
                this._dungeonStatus = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="todayAlreadyResetTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int todayAlreadyResetTimes
        {
            get
            {
                return this._todayAlreadyResetTimes;
            }
            set
            {
                this._todayAlreadyResetTimes = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="todayCompleteTimes", DataFormat=DataFormat.TwosComplement)]
        public int todayCompleteTimes
        {
            get
            {
                return this._todayCompleteTimes;
            }
            set
            {
                this._todayCompleteTimes = value;
            }
        }
    }
}

