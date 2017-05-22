namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="CG_SellItemReq")]
    public class CG_SellItemReq : IExtensible
    {
        private int _callback;
        private readonly List<Cost> _items = new List<Cost>();
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

        [ProtoMember(2, Name="items", DataFormat=DataFormat.Default)]
        public List<Cost> items
        {
            get
            {
                return this._items;
            }
        }
    }
}

