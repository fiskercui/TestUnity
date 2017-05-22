namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_SyncEmailCount")]
    public class GC_SyncEmailCount : IExtensible
    {
        private int _count;
        private int _emailType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="emailType", DataFormat=DataFormat.TwosComplement)]
        public int emailType
        {
            get
            {
                return this._emailType;
            }
            set
            {
                this._emailType = value;
            }
        }
    }
}

