namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="TurnRecord")]
    public class TurnRecord : IExtensible
    {
        private readonly List<ActionRecord> _actionRecords = new List<ActionRecord>();
        private int _avatarIndex;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, Name="actionRecords", DataFormat=DataFormat.Default)]
        public List<ActionRecord> actionRecords
        {
            get
            {
                return this._actionRecords;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="avatarIndex", DataFormat=DataFormat.TwosComplement)]
        public int avatarIndex
        {
            get
            {
                return this._avatarIndex;
            }
            set
            {
                this._avatarIndex = value;
            }
        }
    }
}

