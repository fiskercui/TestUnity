namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="DanAttributeGroup")]
    public class DanAttributeGroup : IExtensible
    {
        private string _attributeDesc = "";
        private readonly List<DanAttribute> _danAttributes = new List<DanAttribute>();
        private int _id;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="attributeDesc", DataFormat=DataFormat.Default)]
        public string attributeDesc
        {
            get
            {
                return this._attributeDesc;
            }
            set
            {
                this._attributeDesc = value;
            }
        }

        [ProtoMember(3, Name="danAttributes", DataFormat=DataFormat.Default)]
        public List<DanAttribute> danAttributes
        {
            get
            {
                return this._danAttributes;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
    }
}

