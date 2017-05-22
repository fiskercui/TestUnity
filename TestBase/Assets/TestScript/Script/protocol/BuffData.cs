namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="BuffData")]
    public class BuffData : IExtensible
    {
        private int _buffId;
        private int _instId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="buffId", DataFormat=DataFormat.TwosComplement)]
        public int buffId
        {
            get
            {
                return this._buffId;
            }
            set
            {
                this._buffId = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="instId", DataFormat=DataFormat.TwosComplement)]
        public int instId
        {
            get
            {
                return this._instId;
            }
            set
            {
                this._instId = value;
            }
        }
    }
}

