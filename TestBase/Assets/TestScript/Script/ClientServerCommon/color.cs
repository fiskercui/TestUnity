namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="color")]
    public class color : IExtensible
    {
        private float _a;
        private float _b;
        private float _g;
        private float _r;
        private IExtension extensionObject;

        public static color CopyFrom(color other)
        {
            if (other == null)
            {
                return null;
            }
            return new color { 
                _a = other.a,
                _r = other.r,
                _g = other.g,
                _b = other.b
            };
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static color LoadFromXml(string value)
        {
            color color = new color {
                _a = 1f,
                _r = 1f,
                _g = 1f,
                _b = 1f
            };
            if (value != null)
            {
                string[] strArray = value.Split(StrParser.splitter);
                if (strArray.Length >= 4)
                {
                    color._r = StrParser.ParseFloat(strArray[0], 1f);
                    color._g = StrParser.ParseFloat(strArray[1], 1f);
                    color._b = StrParser.ParseFloat(strArray[2], 1f);
                    color._a = StrParser.ParseFloat(strArray[3], 1f);
                }
            }
            return color;
        }

        [DefaultValue((float) 0f), ProtoMember(4, IsRequired=false, Name="a", DataFormat=DataFormat.FixedSize)]
        public float a
        {
            get
            {
                return this._a;
            }
            set
            {
                this._a = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="b", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float b
        {
            get
            {
                return this._b;
            }
            set
            {
                this._b = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="g", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float g
        {
            get
            {
                return this._g;
            }
            set
            {
                this._g = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="r", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float r
        {
            get
            {
                return this._r;
            }
            set
            {
                this._r = value;
            }
        }
    }
}

