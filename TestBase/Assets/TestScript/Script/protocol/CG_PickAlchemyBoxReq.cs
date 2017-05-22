namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_PickAlchemyBoxReq")]
    public class CG_PickAlchemyBoxReq : IExtensible
    {
        private int _boxId;
        private int _callback;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="boxId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int boxId
        {
            get
            {
                return this._boxId;
            }
            set
            {
                this._boxId = value;
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
    }
}

