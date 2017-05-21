namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="PropertyModifierSet")]
    public class PropertyModifierSet : IExtensible
    {
        private int _levelFilter;
        private readonly List<PropertyModifier> _modifiers = new List<PropertyModifier>();
        private IExtension extensionObject;

        public void AddOneModifier(PropertyModifier mf)
        {
            this.modifiers.Add(mf);
        }

        public static PropertyModifierSet CopyFrom(PropertyModifierSet other)
        {
            PropertyModifierSet set = new PropertyModifierSet {
                levelFilter = other.levelFilter
            };
            foreach (PropertyModifier modifier in other.modifiers)
            {
                set.modifiers.Add(PropertyModifier.CopyFrom(modifier));
            }
            return set;
        }

        public static PropertyModifierSet genPropertyModifierSetByHp(int hp)
        {
            PropertyModifierSet set = new PropertyModifierSet {
                _levelFilter = 0
            };
            PropertyModifier mf = new PropertyModifier {
                type = 1,
                attributeType = 2,
                modifyType = 1,
                attributeValue = hp
            };
            set.AddOneModifier(mf);
            return set;
        }

        public static PropertyModifierSet genPropertyModifierSetBySp(int sp)
        {
            PropertyModifierSet set = new PropertyModifierSet {
                _levelFilter = 0
            };
            PropertyModifier mf = new PropertyModifier {
                type = 1,
                attributeType = 0x11,
                modifyType = 1,
                attributeValue = sp
            };
            set.AddOneModifier(mf);
            return set;
        }

        public static List<PropertyModifier> GetIncreasedModifier(List<PropertyModifierSet> increaseList, int step)
        {
            PropertyModifierSet set = null;
            foreach (PropertyModifierSet set2 in increaseList)
            {
                if (((set == null) || (set._levelFilter <= set2._levelFilter)) && (step >= set2._levelFilter))
                {
                    set = set2;
                }
            }
            List<PropertyModifier> list = new List<PropertyModifier>();
            if (set != null)
            {
                foreach (PropertyModifier modifier in set.modifiers)
                {
                    PropertyModifier item = PropertyModifier.CopyFrom(modifier);
                    item.attributeValue += (step - set._levelFilter) * modifier.attributeIncrease;
                    list.Add(item);
                }
            }
            return list;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static PropertyModifierSet LoadFromXml(SecurityElement element)
        {
            PropertyModifierSet set = new PropertyModifierSet {
                levelFilter = StrParser.ParseDecInt(element.Attribute("LevelFilter"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Modifier")
                    {
                        set.modifiers.Add(PropertyModifier.LoadFromXml(element2));
                    }
                }
            }
            return set;
        }

        public static void replacePropertyModifierHp(PropertyModifierSet propertyModifierSet, int hp)
        {
            if ((propertyModifierSet.modifiers != null) && (propertyModifierSet.modifiers.Count >= 1))
            {
                propertyModifierSet.modifiers[0].attributeValue = hp;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="levelFilter", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int levelFilter
        {
            get
            {
                return this._levelFilter;
            }
            set
            {
                this._levelFilter = value;
            }
        }

        [ProtoMember(2, Name="modifiers", DataFormat=DataFormat.Default)]
        public List<PropertyModifier> modifiers
        {
            get
            {
                return this._modifiers;
            }
        }
    }
}

