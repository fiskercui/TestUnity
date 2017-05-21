namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="rect")]
    public class rect : IExtensible
    {
        private float _x;
        private float _xMax;
        private float _y;
        private float _yMax;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static rect LoadFromXml(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            float num = 0f;
            float num2 = 0f;
            float num3 = 1f;
            float num4 = 1f;
            string[] strArray = value.Split(StrParser.splitter);
            if (strArray.Length >= 4)
            {
                num = StrParser.ParseFloat(strArray[0], 0f);
                num2 = StrParser.ParseFloat(strArray[1], 0f);
                num3 = StrParser.ParseFloat(strArray[2], 1f);
                num4 = StrParser.ParseFloat(strArray[3], 1f);
            }
            if (((num == 0f) && (num2 == 0f)) && ((num3 == 1f) && (num4 == 1f)))
            {
                return null;
            }
            return new rect { 
                _x = num,
                _y = num2,
                _xMax = num3,
                _yMax = num4
            };
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", new object[] { this.x, this.y, this.xMax, this.yMax });
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

        [ProtoMember(3, IsRequired=false, Name="xMax", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float xMax
        {
            get
            {
                return this._xMax;
            }
            set
            {
                this._xMax = value;
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

        [ProtoMember(4, IsRequired=false, Name="yMax", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float yMax
        {
            get
            {
                return this._yMax;
            }
            set
            {
                this._yMax = value;
            }
        }
    }
}

