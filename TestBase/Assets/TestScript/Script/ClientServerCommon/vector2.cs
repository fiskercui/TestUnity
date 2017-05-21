namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="vector2")]
    public class vector2 : IExtensible
    {
        private float _x;
        private float _y;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static vector2 LoadFromXml(string value)
        {
            vector2 vector = new vector2 {
                _x = 0f,
                _y = 0f
            };
            if (value != null)
            {
                string[] strArray = value.Split(StrParser.splitter);
                if (strArray.Length >= 2)
                {
                    vector._x = StrParser.ParseFloat(strArray[0], 0f);
                    vector._y = StrParser.ParseFloat(strArray[1], 0f);
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
    }
}

