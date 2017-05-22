namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CG_AlchemyReq")]
    public class CG_AlchemyReq : IExtensible
    {
        private int _alchemyType;
        private int _callback;
        private readonly List<Cost> _costs = new List<Cost>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="alchemyType", DataFormat=DataFormat.TwosComplement)]
        public int alchemyType
        {
            get
            {
                return this._alchemyType;
            }
            set
            {
                this._alchemyType = value;
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

        [ProtoMember(3, Name="costs", DataFormat=DataFormat.Default)]
        public List<Cost> costs
        {
            get
            {
                return this._costs;
            }
        }
    }
}

