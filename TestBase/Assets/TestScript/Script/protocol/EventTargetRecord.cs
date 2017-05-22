namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="EventTargetRecord")]
    public class EventTargetRecord : IExtensible
    {
        private int _eventType;
        private readonly List<ActionRecord> _passiveActionRecords = new List<ActionRecord>();
        private int _targetIndex;
        private int _testType;
        private int _value;
        private int _value1;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [ProtoMember(6, Name="passiveActionRecords", DataFormat=DataFormat.Default)]
        public List<ActionRecord> passiveActionRecords
        {
            get
            {
                return this._passiveActionRecords;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="targetIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int targetIndex
        {
            get
            {
                return this._targetIndex;
            }
            set
            {
                this._targetIndex = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="testType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int testType
        {
            get
            {
                return this._testType;
            }
            set
            {
                this._testType = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement)]
        public int value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="value1", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int value1
        {
            get
            {
                return this._value1;
            }
            set
            {
                this._value1 = value;
            }
        }
    }
}

