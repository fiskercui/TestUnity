namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="LevelAttrib")]
    public class LevelAttrib : IExtensible
    {
        private int _experience;
        private int _level;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="experience", DataFormat=DataFormat.TwosComplement)]
        public int experience
        {
            get
            {
                return this._experience;
            }
            set
            {
                this._experience = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
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

