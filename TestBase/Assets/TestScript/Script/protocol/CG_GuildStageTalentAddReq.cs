namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GuildStageTalentAddReq")]
    public class CG_GuildStageTalentAddReq : IExtensible
    {
        private int _callback;
        private int _talentId;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
        public int callback
        {
            get
            {
                return this._callback;
            }
            set
            {
                this._callback = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="talentId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

