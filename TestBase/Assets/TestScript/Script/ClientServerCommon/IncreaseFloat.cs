namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="IncreaseFloat")]
    public class IncreaseFloat : IExtensible
    {
        private int _fromStep;
        private float _increase;
        private float _value;
        private IExtension extensionObject;

        public static float GetValue(List<IncreaseFloat> increaseList, int step)
        {
            IncreaseFloat num = null;
            foreach (IncreaseFloat num2 in increaseList)
            {
                if (((num == null) || (num._fromStep <= num2._fromStep)) && (step >= num2._fromStep))
                {
                    num = num2;
                }
            }
            if (num == null)
            {
                return 0f;
            }
            return num._value;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static IncreaseFloat LoadFromXml(SecurityElement element)
        {
            return new IncreaseFloat { 
                _value = StrParser.ParseFloat(element.Attribute("Value"), 0f),
                _fromStep = StrParser.ParseDecInt(element.Attribute("FromStep"), 0),
                _increase = StrParser.ParseFloat(element.Attribute("Increase"), 0f)
            };
        }

        [ProtoMember(2, IsRequired=false, Name="fromStep", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int fromStep
        {
            get
            {
                return this._fromStep;
            }
            set
            {
                this._fromStep = value;
            }
        }

        [DefaultValue((float) 0f), ProtoMember(3, IsRequired=false, Name="increase", DataFormat=DataFormat.FixedSize)]
        public float increase
        {
            get
            {
                return this._increase;
            }
            set
            {
                this._increase = value;
            }
        }

        [DefaultValue((float) 0f), ProtoMember(1, IsRequired=false, Name="value", DataFormat=DataFormat.FixedSize)]
        public float value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
}

