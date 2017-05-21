namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="IncreaseString")]
    public class IncreaseString : IExtensible
    {
        private int _fromStep;
        private string _value = "";
        private IExtension extensionObject;

        public static string GetValue(List<IncreaseString> increaseList, int step)
        {
            IncreaseString str = null;
            foreach (IncreaseString str2 in increaseList)
            {
                if (((str == null) || (str._fromStep <= str2._fromStep)) && (step >= str2._fromStep))
                {
                    str = str2;
                }
            }
            if (str == null)
            {
                return "";
            }
            return str._value;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static IncreaseString LoadFromXml(SecurityElement element)
        {
            return new IncreaseString { 
                _value = StrParser.ParseStr(element.Attribute("Value"), ""),
                _fromStep = StrParser.ParseDecInt(element.Attribute("FromStep"), 0)
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

        [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="value", DataFormat=DataFormat.Default)]
        public string value
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

