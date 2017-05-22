namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="SignData")]
    public class SignData : IExtensible
    {
        private int _freeSignCount;
        private int _remedySignCount;
        private int _serverTime;
        private int _signCount;
        private int _signDetails;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="freeSignCount", DataFormat=DataFormat.TwosComplement)]
        public int freeSignCount
        {
            get
            {
                return this._freeSignCount;
            }
            set
            {
                this._freeSignCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="remedySignCount", DataFormat=DataFormat.TwosComplement)]
        public int remedySignCount
        {
            get
            {
                return this._remedySignCount;
            }
            set
            {
                this._remedySignCount = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="serverTime", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int serverTime
        {
            get
            {
                return this._serverTime;
            }
            set
            {
                this._serverTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="signCount", DataFormat=DataFormat.TwosComplement)]
        public int signCount
        {
            get
            {
                return this._signCount;
            }
            set
            {
                this._signCount = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="signDetails", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int signDetails
        {
            get
            {
                return this._signDetails;
            }
            set
            {
                this._signDetails = value;
            }
        }
    }
}

