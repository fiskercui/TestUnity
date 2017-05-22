namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="QuestEvent")]
    public class QuestEvent : IExtensible
    {
        private int _eventId;
        private int _eventType;
        private readonly List<KvPair> _kvPairs = new List<KvPair>();
        private int _playerId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="eventId", DataFormat=DataFormat.TwosComplement)]
        public int eventId
        {
            get
            {
                return this._eventId;
            }
            set
            {
                this._eventId = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="eventType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int eventType
        {
            get
            {
                return this._eventType;
            }
            set
            {
                this._eventType = value;
            }
        }

        [ProtoMember(3, Name="kvPairs", DataFormat=DataFormat.Default)]
        public List<KvPair> kvPairs
        {
            get
            {
                return this._kvPairs;
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

