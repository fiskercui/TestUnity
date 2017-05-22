namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_PartnerOpenReq")]
    public class CG_PartnerOpenReq : IExtensible
    {
        private int _callback;
        private int _partnerId;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="partnerId", DataFormat=DataFormat.TwosComplement)]
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
    }
}

