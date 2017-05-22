namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_ChangeMeridianReq")]
    public class CG_ChangeMeridianReq : IExtensible
    {
        private string _avatarGuid = "";
        private int _callback;
        private int _meridianId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="avatarGuid", DataFormat=DataFormat.Default)]
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

        [ProtoMember(2, IsRequired=false, Name="meridianId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int meridianId
        {
            get
            {
                return this._meridianId;
            }
            set
            {
                this._meridianId = value;
            }
        }
    }
}

