namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="PropertyModifier")]
    public class PropertyModifier : IExtensible
    {
        private int _abilityType;
        private int _abilityValue;
        private float _attributeIncrease;
        private int _attributeType;
        private float _attributeValue;
        private int _buffType;
        private ClientServerCommon.color _color;
        private int _modifyType;
        private int _type;
        private IExtension extensionObject;

        public static PropertyModifier CopyFrom(PropertyModifier other)
        {
            if (other == null)
            {
                return null;
            }
            return new PropertyModifier { 
                _type = other._type,
                _modifyType = other._modifyType,
                _attributeType = other._attributeType,
                _attributeValue = other._attributeValue,
                _attributeIncrease = other._attributeIncrease,
                _color = ClientServerCommon.color.CopyFrom(other._color),
                _abilityType = other._abilityType,
                _abilityValue = other._abilityValue,
                _buffType = other._buffType
            };
        }

        public PropertyModifier DeepClone()
        {
            return new PropertyModifier { 
                abilityType = this.abilityType,
                abilityValue = this.abilityValue,
                attributeIncrease = this.attributeIncrease,
                attributeType = this.attributeType,
                attributeValue = this.attributeValue,
                buffType = this.buffType,
                color = ClientServerCommon.color.CopyFrom(this.color),
                modifyType = this.modifyType,
                type = this.type
            };
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static PropertyModifier LoadFromXml(SecurityElement element)
        {
            PropertyModifier modifier = new PropertyModifier();
            modifier._type = TypeNameContainer<_Type>.Parse(element.Attribute("Type"), modifier.type);
            modifier._modifyType = TypeNameContainer<_ValueModifyType>.Parse(element.Attribute("ModifyType"), modifier.modifyType);
            modifier._buffType = TypeNameContainer<ClientServerCommon.Buff._BuffType>.Parse(element.Attribute("BuffType"), 1);
            switch (modifier.type)
            {
                case 1:
                    modifier._attributeType = TypeNameContainer<_AvatarAttributeType>.Parse(element.Attribute("AttributeType"), modifier.attributeType);
                    modifier._attributeValue = StrParser.ParseFloat(element.Attribute("Value"), 0f);
                    modifier._attributeIncrease = StrParser.ParseFloat(element.Attribute("Increase"), 0f);
                    return modifier;

                case 2:
                    modifier._color = ClientServerCommon.color.LoadFromXml(element.Attribute("Color"));
                    return modifier;

                case 3:
                    modifier._abilityType = TypeNameContainer<_AvatarAbilityType>.Parse(element.Attribute("AbilityType"), modifier._abilityType);
                    if (modifier._abilityType == 1)
                    {
                        modifier._abilityValue = TypeNameContainer<ClientServerCommon.Buff._BuffType>.ParseBitList(element.Attribute("AbilityValue"), 0);
                    }
                    return modifier;
            }
            modifier._attributeValue = StrParser.ParseFloat(element.Attribute("Value"), 0f);
            return modifier;
        }

        [ProtoMember(7, IsRequired=false, Name="abilityType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int abilityType
        {
            get
            {
                return this._abilityType;
            }
            set
            {
                this._abilityType = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="abilityValue", DataFormat=DataFormat.TwosComplement)]
        public int abilityValue
        {
            get
            {
                return this._abilityValue;
            }
            set
            {
                this._abilityValue = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="attributeIncrease", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float attributeIncrease
        {
            get
            {
                return this._attributeIncrease;
            }
            set
            {
                this._attributeIncrease = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="attributeType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int attributeType
        {
            get
            {
                return this._attributeType;
            }
            set
            {
                this._attributeType = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="attributeValue", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float attributeValue
        {
            get
            {
                return this._attributeValue;
            }
            set
            {
                this._attributeValue = value;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="buffType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int buffType
        {
            get
            {
                return this._buffType;
            }
            set
            {
                this._buffType = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="color", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public ClientServerCommon.color color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="modifyType", DataFormat=DataFormat.TwosComplement)]
        public int modifyType
        {
            get
            {
                return this._modifyType;
            }
            set
            {
                this._modifyType = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
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

        public class _Type : TypeNameContainer<PropertyModifier._Type>
        {
            public const int AbilityModifier = 3;
            public const int AttributeModifier = 1;
            public const int ColorModifier = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<PropertyModifier._Type>.RegisterType("AttributeModifier", 1);
                flag &= TypeNameContainer<PropertyModifier._Type>.RegisterType("ColorModifier", 2);
                return (flag & TypeNameContainer<PropertyModifier._Type>.RegisterType("AbilityModifier", 3));
            }
        }

        public class _ValueModifyType : TypeNameContainer<PropertyModifier._ValueModifyType>
        {
            public const int Percentage = 3;
            public const int Replace = 1;
            public const int Unknown = 0;
            public const int Value = 2;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<PropertyModifier._ValueModifyType>.RegisterType("Replace", 1);
                flag &= TypeNameContainer<PropertyModifier._ValueModifyType>.RegisterType("Value", 2);
                return (flag & TypeNameContainer<PropertyModifier._ValueModifyType>.RegisterType("Percentage", 3));
            }
        }
    }
}

