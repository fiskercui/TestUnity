namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_NumberConvertReq")]
    public class CG_NumberConvertReq : IExtensible
    {
        private int _callback;
        private int _convertType;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="convertType", DataFormat=DataFormat.TwosComplement)]
        public int convertType
        {
            get
            {
                return this._convertType;
            }
            set
            {
                this._convertType = value;
            }
        }
    }
}

