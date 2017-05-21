namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="SkillConfig")]
    public class SkillConfig : Configuration, IExtensible
    {
        private readonly List<Skill> _skills = new List<Skill>();
        private readonly List<SkillUpgradeSetting> _skillUpgradeSettings = new List<SkillUpgradeSetting>();
        private IExtension extensionObject;
        private Dictionary<int, Skill> id_skillMap = new Dictionary<int, Skill>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Skill skill in this._skills)
            {
                if (skill != null)
                {
                    if (this.id_skillMap.ContainsKey(skill.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + skill.id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_skillMap.Add(skill.id, skill);
                    }
                }
            }
        }

        public float GetOneSkillBasePower(int skillId, int level)
        {
            Skill skillById = this.GetSkillById(skillId);
            if (skillById == null)
            {
                Logger.Warn("Invalid Skill Id :{0:X}", new object[] { skillId });
                return 0f;
            }
            PowerAttribute powerAttributes = skillById.powerAttributes;
            if (powerAttributes == null)
            {
                Logger.Warn("Skill PowerBuffer is Not Find!", new object[0]);
                return 0f;
            }
            return powerAttributes.GetValue(level);
        }

        public Skill GetSkillById(int skillId)
        {
            Skill skill;
            if (!this.id_skillMap.TryGetValue(skillId, out skill))
            {
                return null;
            }
            return skill;
        }

        public SkillUpgradeSetting GetSkillUpgradeSettingByQualityLevel(int qualityLevel)
        {
            foreach (SkillUpgradeSetting setting in this._skillUpgradeSettings)
            {
                if (setting.qualityLevel == qualityLevel)
                {
                    return setting;
                }
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _Type.Initialize();
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "SkillConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "SkillSet")
                        {
                            this.LoadSkillSetFromXml(element2);
                        }
                        else if (tag == "SkillUpgradeSetting")
                        {
                            goto Label_0064;
                        }
                    }
                    continue;
                Label_0064:
                    this._skillUpgradeSettings.Add(this.LoadSkillUpgradeSettingFromXml(element2));
                }
            }
        }

        private Skill LoadSkillFromXml(SecurityElement element)
        {
            Skill skill = new Skill {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                type = TypeNameContainer<CombatTurn._Type>.Parse(element.Attribute("Type"), 0),
                sortIndex = StrParser.ParseDecInt(element.Attribute("SortIndex"), 0),
                qualityLevel = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0)
            };
            skill.uiPfxName = StrParser.ParseStr(element.Attribute("UIPfxName"), skill.uiPfxName);
            skill.needSkillScrollToRobShow = StrParser.ParseBool(element.Attribute("NeedSkillScrollToRobShow"), false);
            skill.activeableAssembleDesc = StrParser.ParseStr(element.Attribute("ActiveableAssembleDesc"), string.Empty);
            skill.isSuperSkill = StrParser.ParseBool(element.Attribute("IsSuperSkill"), false);
            skill.roleVoiceName = element.Attribute("RoleVoiceName");
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "LevelDesc")
                        {
                            if (tag == "LevelModiferSets")
                            {
                                goto Label_0163;
                            }
                            if (tag == "GetWay")
                            {
                                goto Label_0176;
                            }
                            if (tag == "SkillUnlockDesc")
                            {
                                goto Label_0189;
                            }
                            if (tag == "PowerAttribute")
                            {
                                goto Label_019D;
                            }
                        }
                        else
                        {
                            skill.levelDescs.Add(IncreaseString.LoadFromXml(element2));
                        }
                    }
                    continue;
                Label_0163:
                    skill.levelModiferSets.Add(PropertyModifierSet.LoadFromXml(element2));
                    continue;
                Label_0176:
                    skill.getways.Add(GetWay.LoadFromXml(element2));
                    continue;
                Label_0189:
                    skill.skillUnlockDescs.Add(this.LoadSkillUnlockDescFromXml(element2));
                    continue;
                Label_019D:
                    skill.powerAttributes = PowerAttribute.LoadFromXml(element2);
                }
            }
            return skill;
        }

        private void LoadSkillSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Skill")
                    {
                        Skill item = this.LoadSkillFromXml(element2);
                        this.skills.Add(item);
                    }
                }
            }
        }

        private SkillUnlockDesc LoadSkillUnlockDescFromXml(SecurityElement element)
        {
            return new SkillUnlockDesc { 
                level = StrParser.ParseDecInt(element.Attribute("Level"), 0),
                unlockDesc = StrParser.ParseStr(element.Attribute("UnlockDesc"), "")
            };
        }

        private SkillUpgrade LoadSkillUpgradeFromXml(SecurityElement element)
        {
            SkillUpgrade upgrade = new SkillUpgrade {
                upgrateExperiences = StrParser.ParseDecInt(element.Attribute("UpgrateExperience"), 0),
                supplyExperiences = StrParser.ParseDecInt(element.Attribute("SupplyExperience"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "SellReward")
                        {
                            upgrade.sellRewards.Add(Reward.LoadFromXml(element2));
                        }
                        else if (tag == "UpgrateCost")
                        {
                            goto Label_0092;
                        }
                    }
                    continue;
                Label_0092:
                    upgrade.upgrateCosts.Add(Cost.LoadFromXml(element2));
                }
            }
            return upgrade;
        }

        private SkillUpgradeSetting LoadSkillUpgradeSettingFromXml(SecurityElement element)
        {
            SkillUpgradeSetting setting = new SkillUpgradeSetting {
                qualityLevel = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0),
                maxLevel = StrParser.ParseDecInt(element.Attribute("MaxLevel"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "SkillUpgrade"))
                    {
                        setting.skillUpgrades.Add(this.LoadSkillUpgradeFromXml(element2));
                    }
                }
            }
            return setting;
        }

        [ProtoMember(1, Name="skills", DataFormat=DataFormat.Default)]
        public List<Skill> skills
        {
            get
            {
                return this._skills;
            }
        }

        [ProtoMember(2, Name="skillUpgradeSettings", DataFormat=DataFormat.Default)]
        public List<SkillUpgradeSetting> skillUpgradeSettings
        {
            get
            {
                return this._skillUpgradeSettings;
            }
        }

        public class _Type : TypeNameContainer<SkillConfig._Type>
        {
            public const int BaozouSkill = 3;
            public const int BaqiSkill = 6;
            public const int DeadSkill = 5;
            public const int EntranceSkill = 4;
            public const int PassiveSkill = 1;
            public const int PowerSkill = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<SkillConfig._Type>.RegisterType("PassiveSkill", 1, "SkillType_PassiveSkill");
                flag &= TypeNameContainer<SkillConfig._Type>.RegisterType("PowerSkill", 2, "SkillType_PowerSkill");
                flag &= TypeNameContainer<SkillConfig._Type>.RegisterType("BaozouSkill", 3, "SkillType_BaozouSkill");
                flag &= TypeNameContainer<SkillConfig._Type>.RegisterType("EntranceSkill", 4, "SkillType_EntranceSkill");
                flag &= TypeNameContainer<SkillConfig._Type>.RegisterType("DeadSkill", 5, "SkillType_DeadSkill");
                return (flag & TypeNameContainer<SkillConfig._Type>.RegisterType("BaqiSkill", 6, "SkillType_BaqiSkill"));
            }
        }

        [ProtoContract(Name="Skill")]
        public class Skill : IExtensible
        {
            private string _activeableAssembleDesc = "";
            private readonly List<GetWay> _getways = new List<GetWay>();
            private int _id;
            private bool _isSuperSkill;
            private readonly List<IncreaseString> _levelDescs = new List<IncreaseString>();
            private readonly List<PropertyModifierSet> _levelModiferSets = new List<PropertyModifierSet>();
            private bool _needSkillScrollToRobShow;
            private PowerAttribute _powerAttributes;
            private int _qualityLevel;
            private string _roleVoiceName = "";
            private readonly List<SkillConfig.SkillUnlockDesc> _skillUnlockDescs = new List<SkillConfig.SkillUnlockDesc>();
            private int _sortIndex;
            private int _type;
            private string _uiPfxName = "";
            private IExtension extensionObject;

            public CombatTurn GetCombatTurn()
            {
                return ConfigDatabase.DefaultCfg.ActionConfig.GetCombatTurnByID(this._id);
            }

            public string GetLevelDesc(int level)
            {
                return IncreaseString.GetValue(this.levelDescs, level);
            }

            public List<PropertyModifier> GetLevelModifers(int level)
            {
                return PropertyModifierSet.GetIncreasedModifier(this._levelModiferSets, level);
            }

            public List<Reward> GetSellRewards(int level)
            {
                SkillConfig.SkillUpgradeSetting skillUpgradeSettingByQualityLevel = ConfigDatabase.DefaultCfg.SkillConfig.GetSkillUpgradeSettingByQualityLevel(this.qualityLevel);
                if (((skillUpgradeSettingByQualityLevel != null) && (level >= 0)) && (level <= skillUpgradeSettingByQualityLevel.skillUpgrades.Count))
                {
                    return skillUpgradeSettingByQualityLevel.skillUpgrades[level - 1].sellRewards;
                }
                return null;
            }

            public int GetSupplyExperience(int level)
            {
                SkillConfig.SkillUpgradeSetting skillUpgradeSettingByQualityLevel = ConfigDatabase.DefaultCfg.SkillConfig.GetSkillUpgradeSettingByQualityLevel(this.qualityLevel);
                if (((skillUpgradeSettingByQualityLevel != null) && (level >= 0)) && (level <= skillUpgradeSettingByQualityLevel.skillUpgrades.Count))
                {
                    return skillUpgradeSettingByQualityLevel.skillUpgrades[level - 1].supplyExperiences;
                }
                return 0;
            }

            public List<Cost> GetUpgrateCosts(int level)
            {
                SkillConfig.SkillUpgradeSetting skillUpgradeSettingByQualityLevel = ConfigDatabase.DefaultCfg.SkillConfig.GetSkillUpgradeSettingByQualityLevel(this.qualityLevel);
                if (((skillUpgradeSettingByQualityLevel != null) && (level >= 0)) && (level <= skillUpgradeSettingByQualityLevel.skillUpgrades.Count))
                {
                    return skillUpgradeSettingByQualityLevel.skillUpgrades[level - 1].upgrateCosts;
                }
                return null;
            }

            public int GetUpgrateExperience(int level)
            {
                SkillConfig.SkillUpgradeSetting skillUpgradeSettingByQualityLevel = ConfigDatabase.DefaultCfg.SkillConfig.GetSkillUpgradeSettingByQualityLevel(this.qualityLevel);
                if (((skillUpgradeSettingByQualityLevel != null) && (level >= 0)) && (level <= skillUpgradeSettingByQualityLevel.skillUpgrades.Count))
                {
                    return skillUpgradeSettingByQualityLevel.skillUpgrades[level - 1].upgrateExperiences;
                }
                return 0;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="activeableAssembleDesc", DataFormat=DataFormat.Default)]
            public string activeableAssembleDesc
            {
                get
                {
                    return this._activeableAssembleDesc;
                }
                set
                {
                    this._activeableAssembleDesc = value;
                }
            }

            [ProtoMember(11, Name="getways", DataFormat=DataFormat.Default)]
            public List<GetWay> getways
            {
                get
                {
                    return this._getways;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int id
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

            [DefaultValue(false), ProtoMember(5, IsRequired=false, Name="isSuperSkill", DataFormat=DataFormat.Default)]
            public bool isSuperSkill
            {
                get
                {
                    return this._isSuperSkill;
                }
                set
                {
                    this._isSuperSkill = value;
                }
            }

            [ProtoMember(9, Name="levelDescs", DataFormat=DataFormat.Default)]
            public List<IncreaseString> levelDescs
            {
                get
                {
                    return this._levelDescs;
                }
            }

            [ProtoMember(10, Name="levelModiferSets", DataFormat=DataFormat.Default)]
            public List<PropertyModifierSet> levelModiferSets
            {
                get
                {
                    return this._levelModiferSets;
                }
            }

            public int maxLevel
            {
                get
                {
                    if (this.type == 7)
                    {
                        int levelFilter = 1;
                        foreach (PropertyModifierSet set in this.levelModiferSets)
                        {
                            if (set.levelFilter > levelFilter)
                            {
                                levelFilter = set.levelFilter;
                            }
                        }
                        return levelFilter;
                    }
                    SkillConfig.SkillUpgradeSetting skillUpgradeSettingByQualityLevel = ConfigDatabase.DefaultCfg.SkillConfig.GetSkillUpgradeSettingByQualityLevel(this.qualityLevel);
                    if (skillUpgradeSettingByQualityLevel == null)
                    {
                        return 1;
                    }
                    return skillUpgradeSettingByQualityLevel.maxLevel;
                }
            }

            [DefaultValue(false), ProtoMember(6, IsRequired=false, Name="needSkillScrollToRobShow", DataFormat=DataFormat.Default)]
            public bool needSkillScrollToRobShow
            {
                get
                {
                    return this._needSkillScrollToRobShow;
                }
                set
                {
                    this._needSkillScrollToRobShow = value;
                }
            }

            [ProtoMember(14, IsRequired=false, Name="powerAttributes", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public PowerAttribute powerAttributes
            {
                get
                {
                    return this._powerAttributes;
                }
                set
                {
                    this._powerAttributes = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="qualityLevel", DataFormat=DataFormat.TwosComplement)]
            public int qualityLevel
            {
                get
                {
                    return this._qualityLevel;
                }
                set
                {
                    this._qualityLevel = value;
                }
            }

            [ProtoMember(13, IsRequired=false, Name="roleVoiceName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string roleVoiceName
            {
                get
                {
                    return this._roleVoiceName;
                }
                set
                {
                    this._roleVoiceName = value;
                }
            }

            [ProtoMember(8, Name="skillUnlockDescs", DataFormat=DataFormat.Default)]
            public List<SkillConfig.SkillUnlockDesc> skillUnlockDescs
            {
                get
                {
                    return this._skillUnlockDescs;
                }
            }

            [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="sortIndex", DataFormat=DataFormat.TwosComplement)]
            public int sortIndex
            {
                get
                {
                    return this._sortIndex;
                }
                set
                {
                    this._sortIndex = value;
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

            [ProtoMember(4, IsRequired=false, Name="uiPfxName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string uiPfxName
            {
                get
                {
                    return this._uiPfxName;
                }
                set
                {
                    this._uiPfxName = value;
                }
            }
        }

        [ProtoContract(Name="SkillUnlockDesc")]
        public class SkillUnlockDesc : IExtensible
        {
            private int _level;
            private string _unlockDesc = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int level
            {
                get
                {
                    return this._level;
                }
                set
                {
                    this._level = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="unlockDesc", DataFormat=DataFormat.Default)]
            public string unlockDesc
            {
                get
                {
                    return this._unlockDesc;
                }
                set
                {
                    this._unlockDesc = value;
                }
            }
        }

        [ProtoContract(Name="SkillUpgrade")]
        public class SkillUpgrade : IExtensible
        {
            private readonly List<Reward> _sellRewards = new List<Reward>();
            private int _supplyExperiences;
            private readonly List<Cost> _upgrateCosts = new List<Cost>();
            private int _upgrateExperiences;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, Name="sellRewards", DataFormat=DataFormat.Default)]
            public List<Reward> sellRewards
            {
                get
                {
                    return this._sellRewards;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="supplyExperiences", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int supplyExperiences
            {
                get
                {
                    return this._supplyExperiences;
                }
                set
                {
                    this._supplyExperiences = value;
                }
            }

            [ProtoMember(4, Name="upgrateCosts", DataFormat=DataFormat.Default)]
            public List<Cost> upgrateCosts
            {
                get
                {
                    return this._upgrateCosts;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="upgrateExperiences", DataFormat=DataFormat.TwosComplement)]
            public int upgrateExperiences
            {
                get
                {
                    return this._upgrateExperiences;
                }
                set
                {
                    this._upgrateExperiences = value;
                }
            }
        }

        [ProtoContract(Name="SkillUpgradeSetting")]
        public class SkillUpgradeSetting : IExtensible
        {
            private int _maxLevel;
            private int _qualityLevel;
            private readonly List<SkillConfig.SkillUpgrade> _skillUpgrades = new List<SkillConfig.SkillUpgrade>();
            private IExtension extensionObject;

            public SkillConfig.SkillUpgrade GetSkillUpgradeByLevel(int level)
            {
                if (this._skillUpgrades.Count < level)
                {
                    return null;
                }
                return this._skillUpgrades[level - 1];
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="maxLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int maxLevel
            {
                get
                {
                    return this._maxLevel;
                }
                set
                {
                    this._maxLevel = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="qualityLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int qualityLevel
            {
                get
                {
                    return this._qualityLevel;
                }
                set
                {
                    this._qualityLevel = value;
                }
            }

            [ProtoMember(3, Name="skillUpgrades", DataFormat=DataFormat.Default)]
            public List<SkillConfig.SkillUpgrade> skillUpgrades
            {
                get
                {
                    return this._skillUpgrades;
                }
            }
        }
    }
}

