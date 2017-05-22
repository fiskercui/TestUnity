namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;

    [ProtoContract(Name="CG_ExchangeCodeReq")]
    public class CG_ExchangeCodeReq : IExtensible
    {
        private int _callback;
        private string _exchangeCode;
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

        [ProtoMember(2, IsRequired=true, Name="exchangeCode", DataFormat=DataFormat.Default)]
        public string exchangeCode
        {
            get
            {
                return this._exchangeCode;
            }
            set
            {
                this._exchangeCode = value;
            }
        }
    }
}

