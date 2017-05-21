namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="MainType")]
    public class MainType : IExtensible
    {
        private int _id;
        private string _name = "";
        private readonly List<ClientServerCommon.SubType> _subTypes = new List<ClientServerCommon.SubType>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [ProtoMember(3, Name="subTypes", DataFormat=DataFormat.Default)]
        public List<ClientServerCommon.SubType> subTypes
        {
            get
            {
                return this._subTypes;
            }
        }
    }
}

