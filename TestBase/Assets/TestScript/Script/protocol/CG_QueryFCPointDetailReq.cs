namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_QueryFCPointDetailReq")]
    public class CG_QueryFCPointDetailReq : IExtensible
    {
        private int _callback;
        private int _rankType;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="rankType", DataFormat=DataFormat.TwosComplement)]
        public int rankType
        {
            get
            {
                return this._rankType;
            }
            set
            {
                this._rankType = value;
            }
        }
    }
}

