namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Attachment")]
    public class Attachment : IExtensible
    {
        private int _count;
        private int _data1;
        private int _data2;
        private int _data3;
        private string _expression = "";
        private int _id;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="data1", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int data1
        {
            get
            {
                return this._data1;
            }
            set
            {
                this._data1 = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="data2", DataFormat=DataFormat.TwosComplement)]
        public int data2
        {
            get
            {
                return this._data2;
            }
            set
            {
                this._data2 = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="data3", DataFormat=DataFormat.TwosComplement)]
        public int data3
        {
            get
            {
                return this._data3;
            }
            set
            {
                this._data3 = value;
            }
        }

        [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="expression", DataFormat=DataFormat.Default)]
        public string expression
        {
            get
            {
                return this._expression;
            }
            set
            {
                this._expression = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
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

