namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="MeridianConfig")]
    public class MeridianConfig : Configuration, IExtensible
    {
        private readonly List<Buff> _buffs = new List<Buff>();
        private readonly List<MeridianConfigSetting> _meridianConfigSettings = new List<MeridianConfigSetting>();
        private IExtension extensionObject;
        private Dictionary<int, Buff> id_BuffMap = new Dictionary<int, Buff>();
        private Dictionary<int, Meridian> id_MeridianMap = new Dictionary<int, Meridian>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (MeridianConfigSetting setting in this.meridianConfigSettings)
            {
                foreach (MeridianGroup group in setting.meridianGroups)
                {
                    foreach (Meridian meridian in group.meridians)
                    {
                        if (this.id_MeridianMap.ContainsKey(meridian.id))
                        {
                            Logger.Error("{0} duplicated Meridian id : {0:X}", new object[] { base.GetType().Name, meridian.id });
                        }
                        else
                        {
                            meridian.type = group.type;
                            this.id_MeridianMap.Add(meridian.id, meridian);
                        }
                    }
                }
            }
            foreach (Buff buff in this._buffs)
            {
                if (this.id_BuffMap.ContainsKey(buff.id))
                {
                    Logger.Error("{0} duplicated Meridian Buff id : {0:X}", new object[] { base.GetType().Name, buff.id });
                }
                else
                {
                    this.id_BuffMap.Add(buff.id, buff);
                }
            }
        }

        public Buff GetBuffById(int id)
        {
            Buff buff = null;
            if (!this.id_BuffMap.TryGetValue(id, out buff))
            {
                Logger.Warn("Invalid Meridian Buff Id : {0:X}", new object[] { id });
                return null;
            }
            return buff;
        }

        public Meridian GetMeridianById(int id)
        {
            Meridian meridian = null;
            if (!this.id_MeridianMap.TryGetValue(id, out meridian))
            {
                Logger.Warn("Invalid Meridian Id : {0:X}", new object[] { id });
                return null;
            }
            return meridian;
        }

        public Meridian GetMeridianByPreMeridianId(int preMeirdianId)
        {
            foreach (MeridianConfigSetting setting in this.meridianConfigSettings)
            {
                foreach (MeridianGroup group in setting.meridianGroups)
                {
                    foreach (Meridian meridian2 in group.meridians)
                    {
                        if (meridian2.preMeridianId == preMeirdianId)
                        {
                            return meridian2;
                        }
                    }
                }
            }
            return null;
        }

        public MeridianConfigSetting GetMeridianConfigSettingByQualityLevel(int qualityLevel)
        {
            foreach (MeridianConfigSetting setting in this.meridianConfigSettings)
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

        public static void Initizlize()
        {
            _MeridianType.Initialize();
        }

        private Buff LoadBuffFromXml(SecurityElement element)
        {
            Buff buff = new Buff {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                meridianPowerPercent = StrParser.ParseFloat(element.Attribute("MeridianPowerPercent"), 0f)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "ModifierSet"))
                    {
                        PropertyModifierSet set = PropertyModifierSet.LoadFromXml(element2);
                        if (buff.modifierSet == null)
                        {
                            buff.modifierSet = set;
                        }
                    }
                }
            }
            return buff;
        }

        private void LoadBuffSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Buff")
                    {
                        this._buffs.Add(this.LoadBuffFromXml(element2));
                    }
                }
            }
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "MeridianConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "MeridianConfigSet")
                        {
                            this.LoadMeridianConfigSetFromXml(element2);
                        }
                        else if (tag == "BuffSet")
                        {
                            goto Label_0064;
                        }
                    }
                    continue;
                Label_0064:
                    this.LoadBuffSetFromXml(element2);
                }
            }
        }

        private void LoadMeridianConfigSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "MeridianConfigSetting"))
                    {
                        MeridianConfigSetting item = this.LoadMeridianConfigSettingFromXml(element2);
                        this._meridianConfigSettings.Add(item);
                    }
                }
            }
        }

        public MeridianConfigSetting LoadMeridianConfigSettingFromXml(SecurityElement element)
        {
            MeridianConfigSetting setting = new MeridianConfigSetting {
                qualityLevel = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "MeridianGroup"))
                    {
                        MeridianGroup item = this.LoadMeridianGroupFromXml(element2);
                        setting.meridianGroups.Add(item);
                    }
                }
            }
            return setting;
        }

        private Meridian LoadMeridianFromXml(SecurityElement element)
        {
            Meridian meridian = new Meridian {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), ""),
                level = StrParser.ParseDecInt(element.Attribute("Level"), 1),
                preMeridianId = StrParser.ParseHexInt(element.Attribute("PreMeridianId"), 0),
                buffAddition = StrParser.ParseFloat(element.Attribute("BuffAddition"), 0f)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    MeridianBuff buff;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "IncreaseCost")
                        {
                            meridian.increaseCosts.Add(IncreaseCost.LoadFromXml(element2));
                        }
                        else if (tag == "Buff")
                        {
                            goto Label_00E5;
                        }
                    }
                    continue;
                Label_00E5:
                    buff = new MeridianBuff();
                    buff.id = StrParser.ParseHexInt(element2.Attribute("BuffId"), 0);
                    buff.weight = StrParser.ParseDecInt(element2.Attribute("Weight"), 1);
                    meridian.meridianBuffs.Add(buff);
                }
            }
            return meridian;
        }

        private MeridianGroup LoadMeridianGroupFromXml(SecurityElement element)
        {
            MeridianGroup group = new MeridianGroup {
                type = TypeNameContainer<_MeridianType>.Parse(element.Attribute("Type"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Meridian"))
                    {
                        Meridian item = this.LoadMeridianFromXml(element2);
                        group.meridians.Add(item);
                    }
                }
            }
            return group;
        }

        [ProtoMember(1, Name="buffs", DataFormat=DataFormat.Default)]
        public List<Buff> buffs
        {
            get
            {
                return this._buffs;
            }
        }

        [ProtoMember(2, Name="meridianConfigSettings", DataFormat=DataFormat.Default)]
        public List<MeridianConfigSetting> meridianConfigSettings
        {
            get
            {
                return this._meridianConfigSettings;
            }
        }

        public class _MeridianType : TypeNameContainer<MeridianConfig._MeridianType>
        {
            public const int Eight = 2;
            public const int Twelve = 1;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<MeridianConfig._MeridianType>.RegisterType("Twelve", 1, "MeridianType_Twelve");
                return (flag & TypeNameContainer<MeridianConfig._MeridianType>.RegisterType("Eight", 2, "MeridianType_Eight"));
            }
        }

        [ProtoContract(Name="Buff")]
        public class Buff : IExtensible
        {
            private int _id;
            private float _meridianPowerPercent;
            private PropertyModifierSet _modifierSet;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [ProtoMember(3, IsRequired=false, Name="meridianPowerPercent", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float meridianPowerPercent
            {
                get
                {
                    return this._meridianPowerPercent;
                }
                set
                {
                    this._meridianPowerPercent = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="modifierSet", DataFormat=DataFormat.Default)]
            public PropertyModifierSet modifierSet
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
        }

        [ProtoContract(Name="Meridian")]
        public class Meridian : IExtensible
        {
            private float _buffAddition;
            private int _id;
            private readonly List<IncreaseCost> _increaseCosts = new List<IncreaseCost>();
            private int _level;
            private readonly List<MeridianConfig.MeridianBuff> _meridianBuffs = new List<MeridianConfig.MeridianBuff>();
            private string _name = "";
            private int _preMeridianId;
            private IExtension extensionObject;
            public int type;

            public List<Cost> GetCostsByMeridianTimes(int times)
            {
                return IncreaseCost.GetCosts(this._increaseCosts, times);
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(8, IsRequired=false, Name="buffAddition", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float buffAddition
            {
                get
                {
                    return this._buffAddition;
                }
                set
                {
                    this._buffAddition = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(6, Name="increaseCosts", DataFormat=DataFormat.Default)]
            public List<IncreaseCost> increaseCosts
            {
                get
                {
                    return this._increaseCosts;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(7, Name="meridianBuffs", DataFormat=DataFormat.Default)]
            public List<MeridianConfig.MeridianBuff> meridianBuffs
            {
                get
                {
                    return this._meridianBuffs;
                }
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
            public string name
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

            [ProtoMember(5, IsRequired=false, Name="preMeridianId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int preMeridianId
            {
                get
                {
                    return this._preMeridianId;
                }
                set
                {
                    this._preMeridianId = value;
                }
            }
        }

        [ProtoContract(Name="MeridianBuff")]
        public class MeridianBuff : IExtensible
        {
            private int _id;
            private int _weight;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="weight", DataFormat=DataFormat.TwosComplement)]
            public int weight
            {
                get
                {
                    return this._weight;
                }
                set
                {
                    this._weight = value;
                }
            }
        }

        [ProtoContract(Name="MeridianConfigSetting")]
        public class MeridianConfigSetting : IExtensible
        {
            private readonly List<MeridianConfig.MeridianGroup> _meridianGroups = new List<MeridianConfig.MeridianGroup>();
            private int _qualityLevel;
            private IExtension extensionObject;

            public List<MeridianConfig.Meridian> GetMeridiansByType(int type)
            {
                foreach (MeridianConfig.MeridianGroup group in this.meridianGroups)
                {
                    if (group.type == type)
                    {
                        return group.meridians;
                    }
                }
                Logger.Warn("Invalid Meridian Type : {0}", new object[] { type });
                return new List<MeridianConfig.Meridian>();
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="meridianGroups", DataFormat=DataFormat.Default)]
            public List<MeridianConfig.MeridianGroup> meridianGroups
            {
                get
                {
                    return this._meridianGroups;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="qualityLevel", DataFormat=DataFormat.TwosComplement)]
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
        }

        [ProtoContract(Name="MeridianGroup")]
        public class MeridianGroup : IExtensible
        {
            private readonly List<MeridianConfig.Meridian> _meridians = new List<MeridianConfig.Meridian>();
            private int _type;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="meridians", DataFormat=DataFormat.Default)]
            public List<MeridianConfig.Meridian> meridians
            {
                get
                {
                    return this._meridians;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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
}

