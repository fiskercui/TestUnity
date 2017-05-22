namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_TavernBuyReq")]
    public class CG_TavernBuyReq : IExtensible
    {
        private int _callback;
        private int _tavernId;
        private int _tavernType;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="tavernId", DataFormat=DataFormat.TwosComplement)]
        public int tavernId
        {
            get
            {
                return this._tavernId;
            }
            set
            {
                this._tavernId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="tavernType", DataFormat=DataFormat.TwosComplement)]
        public int tavernType
        {
            get
            {
                return this._tavernType;
            }
            set
            {
                this._tavernType = value;
            }
        }
    }
}

