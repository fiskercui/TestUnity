namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_PartnerSetupReq")]
    public class CG_PartnerSetupReq : IExtensible
    {
        private string _avatarGuid = "";
        private int _callback;
        private int _partnerId;
        private int _positionId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="avatarGuid", DataFormat=DataFormat.Default)]
        public string avatarGuid
        {
            get
            {
                return this._avatarGuid;
            }
            set
            {
                this._avatarGuid = value;
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="partnerId", DataFormat=DataFormat.TwosComplement)]
        public int partnerId
        {
            get
            {
                return this._partnerId;
            }
            set
            {
                this._partnerId = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="positionId", DataFormat=DataFormat.TwosComplement)]
        public int positionId
        {
            get
            {
                return this._positionId;
            }
            set
            {
                this._positionId = value;
            }
        }
    }
}

