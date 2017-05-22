namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="OperationActivityItem")]
    public class OperationActivityItem : IExtensible
    {
        private int _couldPickCounts;
        private bool _isEverPurchase;
        private int _itemId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="couldPickCounts", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int couldPickCounts
        {
            get
            {
                return this._couldPickCounts;
            }
            set
            {
                this._couldPickCounts = value;
            }
        }

        [DefaultValue(false), ProtoMember(2, IsRequired=false, Name="isEverPurchase", DataFormat=DataFormat.Default)]
        public bool isEverPurchase
        {
            get
            {
                return this._isEverPurchase;
            }
            set
            {
                this._isEverPurchase = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="itemId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int itemId
        {
            get
            {
                return this._itemId;
            }
            set
            {
                this._itemId = value;
            }
        }
    }
}

