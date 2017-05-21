namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="vector3")]
    public class vector3 : IExtensible
    {
        private float _x;
        private float _y;
        private float _z;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static vector3 LoadFromXml(string value)
        {
            vector3 vector = new vector3 {
                _x = 0f,
                _y = 0f,
                _z = 0f
            };
            if (value != null)
            {
                string[] strArray = value.Split(StrParser.splitter);
                if (strArray.Length >= 3)
                {
                    vector._x = StrParser.ParseFloat(strArray[0], 0f);
                    vector._y = StrParser.ParseFloat(strArray[1], 0f);
                    vector._z = StrParser.ParseFloat(strArray[2], 0f);
                }
            }
            return vector;
        }

        [ProtoMember(1, IsRequired=false, Name="x", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float x
        {
            get
            {
                return this._x;
            }
            set
            {
                this._x = value;
            }
        }

        [DefaultValue((float) 0f), ProtoMember(2, IsRequired=false, Name="y", DataFormat=DataFormat.FixedSize)]
        public float y
        {
            get
            {
                return this._y;
            }
            set
            {
                this._y = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="z", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float z
        {
            get
            {
                return this._z;
            }
            set
            {
                this._z = value;
            }
        }
    }
}

