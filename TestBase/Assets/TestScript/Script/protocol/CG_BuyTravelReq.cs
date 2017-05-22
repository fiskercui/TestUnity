namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_BuyTravelReq")]
    public class CG_BuyTravelReq : IExtensible
    {
        private int _callback;
        private int _dungeonId;
        private int _goodId;
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

        [ProtoMember(2, IsRequired=false, Name="dungeonId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int dungeonId
        {
            get
            {
                return this._dungeonId;
            }
            set
            {
                this._dungeonId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="goodId", DataFormat=DataFormat.TwosComplement)]
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
    }
}

