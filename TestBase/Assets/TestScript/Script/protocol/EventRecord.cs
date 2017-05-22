namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="EventRecord")]
    public class EventRecord : IExtensible
    {
        private int _eventIdx;
        private readonly List<EventTargetRecord> _eventTargetRecords = new List<EventTargetRecord>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="eventIdx", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int eventIdx
        {
            get
            {
                return this._eventIdx;
            }
            set
            {
                this._eventIdx = value;
            }
        }

        [ProtoMember(2, Name="eventTargetRecords", DataFormat=DataFormat.Default)]
        public List<EventTargetRecord> eventTargetRecords
        {
            get
            {
                return this._eventTargetRecords;
            }
        }
    }
}

