namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="PowerConfig")]
    public class PowerConfig : Configuration, IExtensible
    {
        private string _calPower = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "PowerConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "CalPower"))
                    {
                        this._calPower = StrParser.ParseStr(element2.Text, "");
                    }
                }
            }
        }

        [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="calPower", DataFormat=DataFormat.Default)]
        public string CalPower
        {
            get
            {
                return this._calPower;
            }
            set
            {
                this._calPower = value;
            }
        }
    }
}

