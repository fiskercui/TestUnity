namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="BossTalent")]
    public class BossTalent : IExtensible
    {
        private int _level;
        private int _talentId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(1, IsRequired=false, Name="talentId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int talentId
        {
            get
            {
                return this._talentId;
            }
            set
            {
                this._talentId = value;
            }
        }
    }
}

