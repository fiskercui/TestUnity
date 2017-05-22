namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_IllusionReq")]
    public class CG_IllusionReq : IExtensible
    {
        private int _avatarId;
        private int _callback;
        private int _illusionId;
        private int _type;
        private int _useStatu;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="avatarId", DataFormat=DataFormat.TwosComplement)]
        public int avatarId
        {
            get
            {
                return this._avatarId;
            }
            set
            {
                this._avatarId = value;
            }
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

        [ProtoMember(3, IsRequired=false, Name="illusionId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(4, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="useStatu", DataFormat=DataFormat.TwosComplement)]
        public int useStatu
        {
            get
            {
                return this._useStatu;
            }
            set
            {
                this._useStatu = value;
            }
        }
    }
}

