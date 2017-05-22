namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_QueryMelaleucaFloorInfoReq")]
    public class CG_QueryMelaleucaFloorInfoReq : IExtensible
    {
        private int _callback;
        private int _layer;
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

        [ProtoMember(2, IsRequired=false, Name="layer", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int layer
        {
            get
            {
                return this._layer;
            }
            set
            {
                this._layer = value;
            }
        }
    }
}

