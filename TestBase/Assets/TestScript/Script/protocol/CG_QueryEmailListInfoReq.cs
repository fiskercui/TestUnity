namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_QueryEmailListInfoReq")]
    public class CG_QueryEmailListInfoReq : IExtensible
    {
        private int _callback;
        private int _emailType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="emailType", DataFormat=DataFormat.TwosComplement)]
        public int emailType
        {
            get
            {
                return this._emailType;
            }
            set
            {
                this._emailType = value;
            }
        }
    }
}

