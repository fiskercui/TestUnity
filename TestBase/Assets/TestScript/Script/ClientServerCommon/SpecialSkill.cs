namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="SpecialSkill")]
    public class SpecialSkill : IExtensible
    {
        private float _rate;
        private int _skillId;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static SpecialSkill LoadFromXml(SecurityElement element)
        {
            return new SpecialSkill { 
                skillId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                type = TypeNameContainer<SpecialSkillType>.Parse(element.Attribute("Type"), 0),
                rate = StrParser.ParseFloat(element.Attribute("Rate"), 0f)
            };
        }

        [DefaultValue((float) 0f), ProtoMember(3, IsRequired=false, Name="rate", DataFormat=DataFormat.FixedSize)]
        public float rate
        {
            get
            {
                return this._rate;
            }
            set
            {
                this._rate = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="skillId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int skillId
        {
            get
            {
                return this._skillId;
            }
            set
            {
                this._skillId = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

