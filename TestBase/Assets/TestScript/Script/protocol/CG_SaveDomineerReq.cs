namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_SaveDomineerReq")]
    public class CG_SaveDomineerReq : IExtensible
    {
        private string _avatarGuid = "";
        private int _callback;
        private bool _isSave;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="avatarGuid", DataFormat=DataFormat.Default)]
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

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="isSave", DataFormat=DataFormat.Default)]
        public bool isSave
        {
            get
            {
                return this._isSave;
            }
            set
            {
                this._isSave = value;
            }
        }
    }
}

