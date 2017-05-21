namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="IncreaseInt")]
    public class IncreaseInt : IExtensible
    {
        private int _fromStep;
        private int _increase;
        private int _value;
        private IExtension extensionObject;

        public static int GetValue(List<IncreaseInt> increaseList, int step)
        {
            IncreaseInt num = null;
            foreach (IncreaseInt num2 in increaseList)
            {
                if (((num == null) || (num._fromStep <= num2._fromStep)) && (step >= num2._fromStep))
                {
                    num = num2;
                }
            }
            if (num == null)
            {
                return 0;
            }
            return num._value;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static IncreaseInt LoadFromXml(SecurityElement element)
        {
            return new IncreaseInt { 
                _value = StrParser.ParseDecInt(element.Attribute("Value"), 0),
                _fromStep = StrParser.ParseDecInt(element.Attribute("FromStep"), 0),
                _increase = StrParser.ParseDecInt(element.Attribute("Increase"), 0)
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

        [ProtoMember(3, IsRequired=false, Name="increase", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int increase
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

        [ProtoMember(1, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int value
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

