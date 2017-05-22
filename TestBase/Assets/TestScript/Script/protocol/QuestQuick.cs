namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="QuestQuick")]
    public class QuestQuick : IExtensible
    {
        private int _canPickDailyQuestsCount;
        private int _canPickGoalQuestsCount;
        private int _canPickRepeatedQuestsCount;
        private long _lastResetTime;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="canPickDailyQuestsCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int canPickDailyQuestsCount
        {
            get
            {
                return this._canPickDailyQuestsCount;
            }
            set
            {
                this._canPickDailyQuestsCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="canPickGoalQuestsCount", DataFormat=DataFormat.TwosComplement)]
        public int canPickGoalQuestsCount
        {
            get
            {
                return this._canPickGoalQuestsCount;
            }
            set
            {
                this._canPickGoalQuestsCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="canPickRepeatedQuestsCount", DataFormat=DataFormat.TwosComplement)]
        public int canPickRepeatedQuestsCount
        {
            get
            {
                return this._canPickRepeatedQuestsCount;
            }
            set
            {
                this._canPickRepeatedQuestsCount = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="lastResetTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long lastResetTime
        {
            get
            {
                return this._lastResetTime;
            }
            set
            {
                this._lastResetTime = value;
            }
        }
    }
}

