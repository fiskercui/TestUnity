namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="ActionRecord")]
    public class ActionRecord : IExtensible
    {
        private uint _actionId;
        private readonly List<EventRecord> _eventRecords = new List<EventRecord>();
        private int _srcAvatarIndex;
        private readonly List<int> _targetAvatarIndeices = new List<int>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((long) 0L), ProtoMember(1, IsRequired=false, Name="actionId", DataFormat=DataFormat.FixedSize)]
        public uint actionId
        {
            get
            {
                return this._actionId;
            }
            set
            {
                this._actionId = value;
            }
        }

        [ProtoMember(4, Name="eventRecords", DataFormat=DataFormat.Default)]
        public List<EventRecord> eventRecords
        {
            get
            {
                return this._eventRecords;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="srcAvatarIndex", DataFormat=DataFormat.TwosComplement)]
        public int srcAvatarIndex
        {
            get
            {
                return this._srcAvatarIndex;
            }
            set
            {
                this._srcAvatarIndex = value;
            }
        }

        [ProtoMember(3, Name="targetAvatarIndeices", DataFormat=DataFormat.TwosComplement)]
        public List<int> targetAvatarIndeices
        {
            get
            {
                return this._targetAvatarIndeices;
            }
        }
    }
}

