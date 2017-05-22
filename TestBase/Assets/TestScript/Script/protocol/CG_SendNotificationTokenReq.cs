namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_SendNotificationTokenReq")]
    public class CG_SendNotificationTokenReq : IExtensible
    {
        private byte[] _apnsToken;
        private int _callback;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="apnsToken", DataFormat=DataFormat.Default)]
        public byte[] apnsToken
        {
            get
            {
                return this._apnsToken;
            }
            set
            {
                this._apnsToken = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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
    }
}

