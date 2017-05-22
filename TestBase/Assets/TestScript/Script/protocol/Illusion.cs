namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Illusion")]
    public class Illusion : IExtensible
    {
        private long _endTime;
        private int _illusionId;
        private int _useStatus;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="endTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long endTime
        {
            get
            {
                return this._endTime;
            }
            set
            {
                this._endTime = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="illusionId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int illusionId
        {
            get
            {
                return this._illusionId;
            }
            set
            {
                this._illusionId = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="useStatus", DataFormat=DataFormat.TwosComplement)]
        public int useStatus
        {
            get
            {
                return this._useStatus;
            }
            set
            {
                this._useStatus = value;
            }
        }
    }
}

