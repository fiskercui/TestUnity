namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GlobalBuffSuperpositionType")]
    public class GlobalBuffSuperpositionType : IExtensible
    {
        private int _buffType;
        private int _conflictStrategy;
        private int _superpositionType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="buffType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int buffType
        {
            get
            {
                return this._buffType;
            }
            set
            {
                this._buffType = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="conflictStrategy", DataFormat=DataFormat.TwosComplement)]
        public int conflictStrategy
        {
            get
            {
                return this._conflictStrategy;
            }
            set
            {
                this._conflictStrategy = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="superpositionType", DataFormat=DataFormat.TwosComplement)]
        public int superpositionType
        {
            get
            {
                return this._superpositionType;
            }
            set
            {
                this._superpositionType = value;
            }
        }
    }
}

