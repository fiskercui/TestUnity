namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;

    [ProtoContract(Name="GC_NotifySeqIdError")]
    public class GC_NotifySeqIdError : IExtensible
    {
        private int _errorType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=true, Name="errorType", DataFormat=DataFormat.TwosComplement)]
        public int errorType
        {
            get
            {
                return this._errorType;
            }
            set
            {
                this._errorType = value;
            }
        }
    }
}

