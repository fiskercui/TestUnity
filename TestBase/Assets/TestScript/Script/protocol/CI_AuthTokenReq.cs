namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;

    [ProtoContract(Name="CI_AuthTokenReq")]
    public class CI_AuthTokenReq : IExtensible
    {
        private int _accountId;
        private int _areaId;
        private int _callback;
        private string _token;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=true, Name="accountId", DataFormat=DataFormat.TwosComplement)]
        public int accountId
        {
            get
            {
                return this._accountId;
            }
            set
            {
                this._accountId = value;
            }
        }

        [ProtoMember(4, IsRequired=true, Name="areaId", DataFormat=DataFormat.TwosComplement)]
        public int areaId
        {
            get
            {
                return this._areaId;
            }
            set
            {
                this._areaId = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(1, IsRequired=true, Name="token", DataFormat=DataFormat.Default)]
        public string token
        {
            get
            {
                return this._token;
            }
            set
            {
                this._token = value;
            }
        }
    }
}

