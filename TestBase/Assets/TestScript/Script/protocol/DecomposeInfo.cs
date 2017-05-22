namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="DecomposeInfo")]
    public class DecomposeInfo : IExtensible
    {
        private int _danDecomposeCout;
        private int _danItemDecomposeCount;
        private Cost _decomposeCost;
        private int _maxDanDecomposeCout;
        private int _maxDanItemDecomposeCount;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="danDecomposeCout", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int danDecomposeCout
        {
            get
            {
                return this._danDecomposeCout;
            }
            set
            {
                this._danDecomposeCout = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="danItemDecomposeCount", DataFormat=DataFormat.TwosComplement)]
        public int danItemDecomposeCount
        {
            get
            {
                return this._danItemDecomposeCount;
            }
            set
            {
                this._danItemDecomposeCount = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="decomposeCost", DataFormat=DataFormat.Default)]
        public Cost decomposeCost
        {
            get
            {
                return this._decomposeCost;
            }
            set
            {
                this._decomposeCost = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="maxDanDecomposeCout", DataFormat=DataFormat.TwosComplement)]
        public int maxDanDecomposeCout
        {
            get
            {
                return this._maxDanDecomposeCout;
            }
            set
            {
                this._maxDanDecomposeCout = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="maxDanItemDecomposeCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int maxDanItemDecomposeCount
        {
            get
            {
                return this._maxDanItemDecomposeCount;
            }
            set
            {
                this._maxDanItemDecomposeCount = value;
            }
        }
    }
}

