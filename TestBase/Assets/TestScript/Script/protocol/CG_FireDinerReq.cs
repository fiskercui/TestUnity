namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_FireDinerReq")]
    public class CG_FireDinerReq : IExtensible
    {
        private int _callback;
        private int _dinerId;
        private int _qualityType;
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

        [ProtoMember(3, IsRequired=false, Name="dinerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int dinerId
        {
            get
            {
                return this._dinerId;
            }
            set
            {
                this._dinerId = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="qualityType", DataFormat=DataFormat.TwosComplement)]
        public int qualityType
        {
            get
            {
                return this._qualityType;
            }
            set
            {
                this._qualityType = value;
            }
        }
    }
}

