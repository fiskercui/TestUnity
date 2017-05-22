namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Domineer")]
    public class Domineer : IExtensible
    {
        private int _domineerId;
        private int _level;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="domineerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int domineerId
        {
            get
            {
                return this._domineerId;
            }
            set
            {
                this._domineerId = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int level
        {
            get
            {
                return this._level;
            }
            set
            {
                this._level = value;
            }
        }
    }
}

