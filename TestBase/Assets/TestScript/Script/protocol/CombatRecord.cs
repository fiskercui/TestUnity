namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="CombatRecord")]
    public class CombatRecord : IExtensible
    {
        private readonly List<RoundRecord> _roundRecords = new List<RoundRecord>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="roundRecords", DataFormat=DataFormat.Default)]
        public List<RoundRecord> roundRecords
        {
            get
            {
                return this._roundRecords;
            }
        }
    }
}

