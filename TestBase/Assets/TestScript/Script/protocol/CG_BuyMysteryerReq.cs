namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_BuyMysteryerReq")]
    public class CG_BuyMysteryerReq : IExtensible
    {
        private int _callback;
        private int _goodId;
        private int _place;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="goodId", DataFormat=DataFormat.TwosComplement)]
        public int goodId
        {
            get
            {
                return this._goodId;
            }
            set
            {
                this._goodId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="place", DataFormat=DataFormat.TwosComplement)]
        public int place
        {
            get
            {
                return this._place;
            }
            set
            {
                this._place = value;
            }
        }
    }
}

