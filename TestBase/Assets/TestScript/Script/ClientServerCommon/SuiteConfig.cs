namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="SuiteConfig")]
    public class SuiteConfig : Configuration, IExtensible
    {
        private readonly List<AssembleSetting> _assembleSettings = new List<AssembleSetting>();
        private IExtension extensionObject;
        private Dictionary<int, AssembleSetting> id_AssembleSettingDict = new Dictionary<int, AssembleSetting>();
        private Dictionary<int, List<AssembleSetting>> requireId_EquipmentSuiteDict = new Dictionary<int, List<AssembleSetting>>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (AssembleSetting setting in this._assembleSettings)
            {
                if (this.id_AssembleSettingDict.ContainsKey(setting.Id))
                {
                    Logger.Warn("[SuiteConfig] Duplicated Id : " + setting.Id.ToString("X"), new object[0]);
                }
                else
                {
                    this.id_AssembleSettingDict.Add(setting.Id, setting);
                    if (setting.Type == 2)
                    {
                        foreach (AssembleSetting.Part part in setting.Parts)
                        {
                            foreach (AssembleSetting.Requirement requirement in part.Requiremets)
                            {
                                if (!this.requireId_EquipmentSuiteDict.ContainsKey(requirement.Value))
                                {
                                    this.requireId_EquipmentSuiteDict.Add(requirement.Value, new List<AssembleSetting>());
                                }
                                if (!this.requireId_EquipmentSuiteDict[requirement.Value].Contains(setting))
                                {
                                    this.requireId_EquipmentSuiteDict[requirement.Value].Add(setting);
                                }
                            }
                        }
                    }
                }
            }
        }

        public AssembleSetting GetAssembleSettingById(int id)
        {
            AssembleSetting setting = null;
            if (!this.id_AssembleSettingDict.TryGetValue(id, out setting))
            {
                return null;
            }
            return setting;
        }

        public List<AssembleSetting> GetAvatarAssembleByAvatarId(int avatarId)
        {
            List<AssembleSetting> list = new List<AssembleSetting>();
            AvatarConfig.Avatar avatarById = base.CfgDB.AvatarConfig.GetAvatarById(avatarId);
            if (avatarById != null)
            {
                foreach (int num in avatarById.assemableIds)
                {
                    AssembleSetting assembleSettingById = this.GetAssembleSettingById(num);
                    if (assembleSettingById != null)
                    {
                        list.Add(assembleSettingById);
                    }
                }
            }
            return list;
        }

        public List<AssembleSetting> GetEquipmentSuitesByRequireId(int requireId)
        {
            List<AssembleSetting> list = null;
            if (!this.requireId_EquipmentSuiteDict.TryGetValue(requireId, out list))
            {
                return null;
            }
            return list;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _Type.Initialize();
            AssembleSetting.Requirement._Type.Initialize();
        }

        private AssembleSetting LoadAssembleFromXml(SecurityElement element)
        {
            AssembleSetting setting = new AssembleSetting {
                Id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                Type = TypeNameContainer<_Type>.Parse(element.Attribute("Type"), 0),
                Name = StrParser.ParseStr(element.Attribute("Name"), string.Empty)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Part")
                        {
                            setting.Parts.Add(this.LoadSuitPartFromXml(element2));
                        }
                        else if (tag == "Assemble")
                        {
                            goto Label_00AE;
                        }
                    }
                    continue;
                Label_00AE:
                    setting.Assembles.Add(this.LoadSuiteAssembleFromXml(element2));
                }
            }
            return setting;
        }

        private void LoadAssembleSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "AssembleSetting")
                    {
                        this._assembleSettings.Add(this.LoadAssembleFromXml(element2));
                    }
                }
            }
        }

        public AssembleSetting.Requirement LoadAssembleSettingRequirementFromXml(SecurityElement element)
        {
            AssembleSetting.Requirement requirement = new AssembleSetting.Requirement();
            requirement.Type = TypeNameContainer<AssembleSetting.Requirement._Type>.Parse(element.Attribute("Type"), requirement.Type);
            requirement.Value = StrParser.ParseHexInt(element.Attribute("Value"), requirement.Value);
            return requirement;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "SuitConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "AssembleSet"))
                    {
                        this.LoadAssembleSetFromXml(element2);
                    }
                }
            }
        }

        private AssembleSetting.Assemble LoadSuiteAssembleFromXml(SecurityElement element)
        {
            return new AssembleSetting.Assemble { 
                RequiredCount = StrParser.ParseDecInt(element.Attribute("RequiredCount"), 0),
                AssembleEffectDesc = StrParser.ParseStr(element.Attribute("AssembleEffectDesc"), string.Empty, true),
                ModifierSet = PropertyModifierSet.LoadFromXml(element.SearchForChildByTag("ModifierSet")),
                AssemblePower = StrParser.ParseDecInt(element.Attribute("AssemblePower"), 0),
                AssemblePowerPercent = StrParser.ParseFloat(element.Attribute("AssemblePowerPercent"), 0f)
            };
        }

        private AssembleSetting.Part LoadSuitPartFromXml(SecurityElement element)
        {
            AssembleSetting.Part part = new AssembleSetting.Part();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Requirement")
                    {
                        AssembleSetting.Requirement item = this.LoadAssembleSettingRequirementFromXml(element2);
                        if (item != null)
                        {
                            part.Requiremets.Add(item);
                        }
                    }
                }
            }
            return part;
        }

        private static int SortAssembleByCount(AssembleSetting.Assemble a1, AssembleSetting.Assemble a2)
        {
            return (a1.RequiredCount - a2.RequiredCount);
        }

        [ProtoMember(1, Name="assembleSettings", DataFormat=DataFormat.Default)]
        public List<AssembleSetting> AssembleSettings
        {
            get
            {
                return this._assembleSettings;
            }
        }

        public class _Type : TypeNameContainer<SuiteConfig._Type>
        {
            public const int AvatarAssemble = 1;
            public const int EquipmentSuite = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<SuiteConfig._Type>.RegisterType("AvatarAssemble", 1);
                return (flag & TypeNameContainer<SuiteConfig._Type>.RegisterType("EquipmentSuite", 2));
            }
        }

        [ProtoContract(Name="AssembleSetting")]
        public class AssembleSetting : IExtensible
        {
            private readonly List<Assemble> _assembles = new List<Assemble>();
            private int _id;
            private string _name = "";
            private readonly List<Part> _parts = new List<Part>();
            private int _type;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, Name="assembles", DataFormat=DataFormat.Default)]
            public List<Assemble> Assembles
            {
                get
                {
                    return this._assembles;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Id
            {
                get
                {
                    return this._id;
                }
                set
                {
                    this._id = value;
                }
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
            public string Name
            {
                get
                {
                    return this._name;
                }
                set
                {
                    this._name = value;
                }
            }

            [ProtoMember(4, Name="parts", DataFormat=DataFormat.Default)]
            public List<Part> Parts
            {
                get
                {
                    return this._parts;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Type
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

            [ProtoContract(Name="Assemble")]
            public class Assemble : IExtensible
            {
                private string _assembleEffectDesc = "";
                private float _assemblePower;
                private float _assemblePowerPercent;
                private SuiteConfig.AssembleSetting _assembleSetting;
                private PropertyModifierSet _modifierSet;
                private int _requiredCount;
                private IExtension extensionObject;

                IExtension IExtensible.GetExtensionObject(bool createIfMissing)
                {
                    return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
                }

                [ProtoMember(2, IsRequired=false, Name="assembleEffectDesc", DataFormat=DataFormat.Default), DefaultValue("")]
                public string AssembleEffectDesc
                {
                    get
                    {
                        return this._assembleEffectDesc;
                    }
                    set
                    {
                        this._assembleEffectDesc = value;
                    }
                }

                [ProtoMember(4, IsRequired=false, Name="assemblePower", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
                public float AssemblePower
                {
                    get
                    {
                        return this._assemblePower;
                    }
                    set
                    {
                        this._assemblePower = value;
                    }
                }

                [DefaultValue((float) 0f), ProtoMember(5, IsRequired=false, Name="assemblePowerPercent", DataFormat=DataFormat.FixedSize)]
                public float AssemblePowerPercent
                {
                    get
                    {
                        return this._assemblePowerPercent;
                    }
                    set
                    {
                        this._assemblePowerPercent = value;
                    }
                }

                public SuiteConfig.AssembleSetting assembleSetting
                {
                    get
                    {
                        return this._assembleSetting;
                    }
                    set
                    {
                        this._assembleSetting = value;
                    }
                }

                [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="modifierSet", DataFormat=DataFormat.Default)]
                public PropertyModifierSet ModifierSet
                {
                    get
                    {
                        return this._modifierSet;
                    }
                    set
                    {
                        this._modifierSet = value;
                    }
                }

                [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="requiredCount", DataFormat=DataFormat.TwosComplement)]
                public int RequiredCount
                {
                    get
                    {
                        return this._requiredCount;
                    }
                    set
                    {
                        this._requiredCount = value;
                    }
                }
            }

            [ProtoContract(Name="Part")]
            public class Part : IExtensible
            {
                private readonly List<SuiteConfig.AssembleSetting.Requirement> _requiremets = new List<SuiteConfig.AssembleSetting.Requirement>();
                private IExtension extensionObject;

                IExtension IExtensible.GetExtensionObject(bool createIfMissing)
                {
                    return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
                }

                [ProtoMember(1, Name="requiremets", DataFormat=DataFormat.Default)]
                public List<SuiteConfig.AssembleSetting.Requirement> Requiremets
                {
                    get
                    {
                        return this._requiremets;
                    }
                }
            }

            [ProtoContract(Name="Requirement")]
            public class Requirement : IExtensible
            {
                private int _type;
                private int _value;
                private IExtension extensionObject;

                IExtension IExtensible.GetExtensionObject(bool createIfMissing)
                {
                    return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
                }

                [ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
                public int Type
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

                [ProtoMember(2, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
                public int Value
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

                public class _Type : TypeNameContainer<SuiteConfig.AssembleSetting.Requirement._Type>
                {
                    public const int Avatar = 1;
                    public const int CombatTurn = 3;
                    public const int Dan = 4;
                    public const int Equipment = 2;
                    public const int Unknown = 0;

                    public static bool Initialize()
                    {
                        bool flag = false;
                        flag &= TypeNameContainer<SuiteConfig.AssembleSetting.Requirement._Type>.RegisterType("Avatar", 1);
                        flag &= TypeNameContainer<SuiteConfig.AssembleSetting.Requirement._Type>.RegisterType("Equipment", 2);
                        flag &= TypeNameContainer<SuiteConfig.AssembleSetting.Requirement._Type>.RegisterType("CombatTurn", 3);
                        return (flag & TypeNameContainer<SuiteConfig.AssembleSetting.Requirement._Type>.RegisterType("Dan", 4));
                    }
                }
            }
        }
    }
}

