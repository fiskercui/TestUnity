namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="BeastConfig")]
    public class BeastConfig : Configuration, IExtensible
    {
        private string _attributeDesc = "";
        private string _attributeIconId = "";
        private readonly List<BaseInfo> _baseInfos = new List<BaseInfo>();
        private readonly List<BeastBreakthought> _beastBreakthoughts = new List<BeastBreakthought>();
        private readonly List<BeastIcon> _beastIcons = new List<BeastIcon>();
        private readonly List<BeastLevelUp> _beastLevelUps = new List<BeastLevelUp>();
        private readonly List<BeastPartAttributeGroup> _beastPartAttriGroups = new List<BeastPartAttributeGroup>();
        private readonly List<BeastPart> _beastParts = new List<BeastPart>();
        private BeastPartShop _beastPartShops;
        private readonly List<BeastSkill> _beastSkills = new List<BeastSkill>();
        private readonly List<BreakthoughtAndLevel> _breakthoughtAndLevels = new List<BreakthoughtAndLevel>();
        private int _maxBreakthought;
        private int _maxLevel;
        private Dictionary<int, BeastSkill> beastSkillDic = new Dictionary<int, BeastSkill>();
        private IExtension extensionObject;

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            this.beastSkillDic.Clear();
            foreach (BeastSkill skill in this._beastSkills)
            {
                if (this.beastSkillDic.ContainsKey(skill.SkillId))
                {
                    Logger.Error(string.Format("BeastConfig Contains BeastSkillID :{0}", skill.SkillId.ToString("X8")), new object[0]);
                }
                else
                {
                    this.beastSkillDic.Add(skill.SkillId, skill);
                }
            }
            foreach (BreakthoughtAndLevel level in this._breakthoughtAndLevels)
            {
                foreach (BeastSkill skill2 in level.LevelSkills)
                {
                    if (this.beastSkillDic.ContainsKey(skill2.SkillId))
                    {
                        skill2.SkillName = this.beastSkillDic[skill2.SkillId].SkillName;
                        skill2.InterfaceSkills.Clear();
                        skill2.InterfaceSkills.AddRange(this.beastSkillDic[skill2.SkillId].InterfaceSkills);
                        skill2.PrevLevelSkillId = this.beastSkillDic[skill2.SkillId].PrevLevelSkillId;
                        skill2.Desc = skill2.Desc;
                    }
                }
                foreach (BeastSkill skill3 in level.StarSkills)
                {
                    if (this.beastSkillDic.ContainsKey(skill3.SkillId))
                    {
                        skill3.SkillName = this.beastSkillDic[skill3.SkillId].SkillName;
                        skill3.InterfaceSkills.Clear();
                        skill3.InterfaceSkills.AddRange(this.beastSkillDic[skill3.SkillId].InterfaceSkills);
                        skill3.Desc = this.beastSkillDic[skill3.SkillId].Desc;
                        skill3.PrevLevelSkillId = this.beastSkillDic[skill3.SkillId].PrevLevelSkillId;
                    }
                }
            }
        }

        public BaseInfo GetBaseInfoByBeastFragmentId(int id)
        {
            foreach (BaseInfo info in this._baseInfos)
            {
                if (info.FragmentId == id)
                {
                    return info;
                }
            }
            return null;
        }

        public BaseInfo GetBaseInfoByBeastId(int id)
        {
            foreach (BaseInfo info in this._baseInfos)
            {
                if (info.Id == id)
                {
                    return info;
                }
            }
            return null;
        }

        public BeastBreakthought GetBeastBreakthoughtByBreakthoughtNow(int breakthoughtNow)
        {
            foreach (BeastBreakthought breakthought in this._beastBreakthoughts)
            {
                if (breakthought.BreakthoughtNow == breakthoughtNow)
                {
                    return breakthought;
                }
            }
            return null;
        }

        public BeastIcon GetBeastIconByIconId(int id)
        {
            foreach (BeastIcon icon in this._beastIcons)
            {
                if (icon.IconId == id)
                {
                    return icon;
                }
            }
            return null;
        }

        public BeastIcon GetBeastIconByResourseIdAndBreakLevel(int resourcesId, int breakLevel)
        {
            foreach (BeastIcon icon in this._beastIcons)
            {
                if ((icon.ResourseId == resourcesId) && (icon.Breakthought == breakLevel))
                {
                    return icon;
                }
            }
            return null;
        }

        public BeastLevelUp GetBeastLevelUpByLevelNow(int levelNow)
        {
            foreach (BeastLevelUp up in this._beastLevelUps)
            {
                if (up.LevelNow == levelNow)
                {
                    return up;
                }
            }
            return null;
        }

        public BeastPartAttributeGroup GetBeastPartAttributeGroupById(int attributeGroupId)
        {
            foreach (BeastPartAttributeGroup group in this._beastPartAttriGroups)
            {
                if (group.Id == attributeGroupId)
                {
                    return group;
                }
            }
            Logger.Error("BeastPartAttributeGroup Id do not exist. id=" + attributeGroupId.ToString("X8"), new object[0]);
            return null;
        }

        public BeastPart GetBeastPartByBeastPartId(int partId)
        {
            foreach (BeastPart part in this._beastParts)
            {
                if (part.PartId == partId)
                {
                    return part;
                }
            }
            return null;
        }

        public BeastSkill GetBeastSkillByBeastSkillId(int skillId)
        {
            foreach (BeastSkill skill in this._beastSkills)
            {
                if (skill.SkillId == skillId)
                {
                    return skill;
                }
            }
            return null;
        }

        public BreakthoughtAndLevel GetBreakthoughtAndLevel(int beastId, int breakthought, int level)
        {
            foreach (BreakthoughtAndLevel level2 in this._breakthoughtAndLevels)
            {
                if (((level2.Id == beastId) && (level2.Breakthought == breakthought)) && (level2.Level == level))
                {
                    return level2;
                }
            }
            Logger.Error(string.Format("Beast BreakthoughtAndLevel Missed. beastId={0},brreakthrough={1},level={2}", beastId, breakthought, level), new object[0]);
            return null;
        }

        public int GetMinLevelSkillBeastLevelBySkillId(int skillId)
        {
            BreakthoughtAndLevel level = new BreakthoughtAndLevel();
            foreach (BreakthoughtAndLevel level2 in this._breakthoughtAndLevels)
            {
                foreach (BeastSkill skill in level2.LevelSkills)
                {
                    if ((skill.SkillId == skillId) && ((level.Level == 0) || (level2.Level < level.Level)))
                    {
                        level = level2;
                    }
                }
            }
            return level.Level;
        }

        public int GetMinStartSkillBeastLevelBySkillId(int skillId)
        {
            BreakthoughtAndLevel level = new BreakthoughtAndLevel();
            foreach (BreakthoughtAndLevel level2 in this._breakthoughtAndLevels)
            {
                foreach (BeastSkill skill in level2.StarSkills)
                {
                    if ((skill.SkillId == skillId) && ((level.Breakthought == 0) || (level2.Breakthought < level.Breakthought)))
                    {
                        level = level2;
                    }
                }
            }
            return level.Breakthought;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _PartIndex.Initialize();
            _BeastTraitType.Initialize();
        }

        public BaseInfo LoadBaseInfoFromXml(SecurityElement element)
        {
            BaseInfo info = new BaseInfo {
                Id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                BeastName = StrParser.ParseStr(element.Attribute("BeastName"), string.Empty),
                SmallIconId = StrParser.ParseStr(element.Attribute("SmallIconId"), string.Empty),
                BigIconId = StrParser.ParseStr(element.Attribute("BigIconId"), string.Empty),
                BeastType = TypeNameContainer<_BeastTraitType>.Parse(element.Attribute("BeastType"), 0),
                IsShow = StrParser.ParseBool(element.Attribute("IsShow"), false),
                Priority = StrParser.ParseDecInt(element.Attribute("Priority"), 0),
                MinActiveBreakthought = StrParser.ParseDecInt(element.Attribute("MinActiveBreakthought"), 0),
                FragmentId = StrParser.ParseHexInt(element.Attribute("FragmentId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "Desc")
                        {
                            if (tag == "DefaultGetWayDesc")
                            {
                                goto Label_0147;
                            }
                            if (tag == "GetWay")
                            {
                                goto Label_0155;
                            }
                        }
                        else
                        {
                            info.Desc = element2.Text;
                        }
                    }
                    continue;
                Label_0147:
                    info.DefaultGetWayDesc = element2.Text;
                    continue;
                Label_0155:
                    info.GetWay = GetWay.LoadFromXml(element2);
                }
            }
            return info;
        }

        public BeastBreakthought LoadBeastBreakthoughtFromXml(SecurityElement element)
        {
            BeastBreakthought breakthought = new BeastBreakthought {
                BreakthoughtNow = StrParser.ParseDecInt(element.Attribute("BreakthoughtNow"), 0),
                BreakthoughtAfter = StrParser.ParseDecInt(element.Attribute("BreakthoughtAfter"), 0),
                ActiveCostFragmentCount = StrParser.ParseDecInt(element.Attribute("ActiveCostFragmentCount"), 0),
                UpCostFragmentCount = StrParser.ParseDecInt(element.Attribute("UpCostFragmentCount"), 0)
            };
            Cost cost = new Cost {
                id = StrParser.ParseHexInt(element.Attribute("UpItemCostId"), 0),
                count = StrParser.ParseDecInt(element.Attribute("UpItemCostCount"), 0)
            };
            breakthought.UpItemCost = cost;
            breakthought.DecomposeCount = StrParser.ParseDecInt(element.Attribute("DecomposeCount"), 0);
            return breakthought;
        }

        private BeastIcon LoadBeastIconFromXml(SecurityElement element)
        {
            return new BeastIcon { 
                ResourseId = StrParser.ParseHexInt(element.Attribute("ResourseId"), 0),
                IconId = StrParser.ParseHexInt(element.Attribute("IconId"), 0),
                Breakthought = StrParser.ParseDecInt(element.Attribute("Breakthought"), 0)
            };
        }

        private void LoadBeastIconSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "BeastIcon"))
                    {
                        this.BeastIcons.Add(this.LoadBeastIconFromXml(element2));
                    }
                }
            }
        }

        public BeastLevelUp LoadBeastLevelUpFromXml(SecurityElement element)
        {
            return new BeastLevelUp { 
                LevelNow = StrParser.ParseDecInt(element.Attribute("LevelNow"), 0),
                LevelNext = StrParser.ParseDecInt(element.Attribute("LevelNext"), 0),
                Quality = StrParser.ParseDecInt(element.Attribute("Quality"), 0),
                AddLevel = StrParser.ParseDecInt(element.Attribute("AddLevel"), 0)
            };
        }

        public BeastPartActive LoadBeastPartActiveFromXml(SecurityElement element)
        {
            BeastPartActive active = new BeastPartActive {
                Index = StrParser.ParseDecInt(element.Attribute("Index"), 0)
            };
            Cost cost = new Cost {
                id = StrParser.ParseHexInt(element.Attribute("PartCostId"), 0),
                count = StrParser.ParseDecInt(element.Attribute("PartCostCount"), 0)
            };
            active.PartCost = cost;
            active.AttributeId = StrParser.ParseHexInt(element.Attribute("AttributeId"), 0);
            active.PartPower = StrParser.ParseDecInt(element.Attribute("PartPower"), 0);
            return active;
        }

        public BeastPartAttributeGroup LoadBeastPartAttributeGroupFromXml(SecurityElement element)
        {
            BeastPartAttributeGroup group = new BeastPartAttributeGroup {
                Id = StrParser.ParseHexInt(element.Attribute("Id"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Attribute")
                    {
                        group.Attributes.Add(ClientServerCommon.Attribute.LoadFromXml(element2));
                    }
                }
            }
            return group;
        }

        public BeastPart LoadBeastPartFromXml(SecurityElement element)
        {
            BeastPart part = new BeastPart {
                PartId = StrParser.ParseHexInt(element.Attribute("PartId"), 0),
                PartName = StrParser.ParseStr(element.Attribute("PartName"), ""),
                PartIconId = StrParser.ParseStr(element.Attribute("PartIconId"), ""),
                Breakthought = StrParser.ParseDecInt(element.Attribute("Breakthought"), 0),
                SortPart = StrParser.ParseDecInt(element.Attribute("SortPart"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "Desc")
                        {
                            if (tag == "DefaultGetWayDesc")
                            {
                                goto Label_00E7;
                            }
                            if (tag == "GetWay")
                            {
                                goto Label_00F5;
                            }
                        }
                        else
                        {
                            part.Desc = element2.Text;
                        }
                    }
                    continue;
                Label_00E7:
                    part.DefaultGetWayDesc = element2.Text;
                    continue;
                Label_00F5:
                    part.GetWays.Add(GetWay.LoadFromXml(element2));
                }
            }
            return part;
        }

        public BeastPartShop LoadBeastPartShopFromXml(SecurityElement element)
        {
            BeastPartShop shop = new BeastPartShop();
            Cost cost = new Cost {
                id = StrParser.ParseHexInt(element.Attribute("HandRefreshCostId"), 0),
                count = StrParser.ParseDecInt(element.Attribute("HandRefreshCostCount"), 0)
            };
            shop.HandRefreshCost = cost;
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Desc")
                        {
                            shop.Desc = element2.Text;
                        }
                        else if (tag == "RefreshInfo")
                        {
                            goto Label_009D;
                        }
                    }
                    continue;
                Label_009D:
                    shop.RefreshInfos.Add(this.LoadRefreshInfoFromXml(element2));
                }
            }
            return shop;
        }

        public BeastSkill LoadBeastSkillFromXml(SecurityElement element)
        {
            BeastSkill skill = new BeastSkill {
                SkillId = StrParser.ParseHexInt(element.Attribute("SkillId"), 0),
                SkillName = StrParser.ParseStr(element.Attribute("SkillName"), ""),
                PrevLevelSkillId = StrParser.ParseHexInt(element.Attribute("PrevLevelSkillId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Desc")
                        {
                            skill.Desc = element2.Text;
                        }
                        else if (tag == "InterfaceSkill")
                        {
                            goto Label_00A8;
                        }
                    }
                    continue;
                Label_00A8:
                    skill.InterfaceSkills.Add(StrParser.ParseHexInt(element2.Text, 0));
                }
            }
            return skill;
        }

        public BreakthoughtAndLevel LoadBreakthoughtAndLevelFromXml(SecurityElement element)
        {
            BreakthoughtAndLevel level = new BreakthoughtAndLevel {
                Id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                Breakthought = StrParser.ParseDecInt(element.Attribute("Breakthought"), 0),
                Level = StrParser.ParseDecInt(element.Attribute("Level"), 0),
                Power = StrParser.ParseDecInt(element.Attribute("Power"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "BeastPartActive")
                        {
                            if (tag == "Attribute")
                            {
                                goto Label_00EE;
                            }
                            if (tag == "PropertyModifier")
                            {
                                goto Label_0101;
                            }
                            if (tag == "LevelSkill")
                            {
                                goto Label_0114;
                            }
                            if (tag == "StarSkill")
                            {
                                goto Label_0128;
                            }
                        }
                        else
                        {
                            level.BeastPartActives.Add(this.LoadBeastPartActiveFromXml(element2));
                        }
                    }
                    continue;
                Label_00EE:
                    level.Attributes.Add(ClientServerCommon.Attribute.LoadFromXml(element2));
                    continue;
                Label_0101:
                    level.GuardModifiers.Add(PropertyModifier.LoadFromXml(element2));
                    continue;
                Label_0114:
                    level.LevelSkills.Add(this.LoadBeastSkillFromXml(element2));
                    continue;
                Label_0128:
                    level.StarSkills.Add(this.LoadBeastSkillFromXml(element2));
                }
            }
            return level;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "BeastConfig")
            {
                this._attributeIconId = StrParser.ParseStr(element.Attribute("AttributeIconId"), "");
                this._maxBreakthought = StrParser.ParseDecInt(element.Attribute("MaxBreakthought"), 5);
                this._maxLevel = StrParser.ParseDecInt(element.Attribute("MaxLevel"), 40);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        switch (element2.Tag)
                        {
                            case "AttributeDesc":
                                this._attributeDesc = StrParser.ParseStr(element2.Text, "", true);
                                break;

                            case "BeastIconSet":
                                this.LoadBeastIconSetFromXml(element2);
                                break;

                            case "BaseInfo":
                                this.BaseInfos.Add(this.LoadBaseInfoFromXml(element2));
                                break;

                            case "BreakthoughtAndLevel":
                                this.BreakthoughtAndLevels.Add(this.LoadBreakthoughtAndLevelFromXml(element2));
                                break;

                            case "BeastLevelUp":
                                this.BeastLevelUps.Add(this.LoadBeastLevelUpFromXml(element2));
                                break;

                            case "BeastBreakthought":
                                this.BeastBreakthoughts.Add(this.LoadBeastBreakthoughtFromXml(element2));
                                break;

                            case "BeastPart":
                                this.BeastParts.Add(this.LoadBeastPartFromXml(element2));
                                break;

                            case "BeastSkill":
                                this.BeastSkills.Add(this.LoadBeastSkillFromXml(element2));
                                break;

                            case "BeastPartShop":
                                this.BeastPartShops = this.LoadBeastPartShopFromXml(element2);
                                break;

                            case "BeastPartAttributeGroup":
                                this.BeastPartAttriGroups.Add(this.LoadBeastPartAttributeGroupFromXml(element2));
                                break;
                        }
                    }
                }
            }
        }

        public RefreshInfo LoadRefreshInfoFromXml(SecurityElement element)
        {
            return new RefreshInfo { 
                Index = StrParser.ParseDecInt(element.Attribute("Index"), 0),
                RefreshTime = StrParser.ParseDateTime(element.Attribute("RefreshTime"))
            };
        }

        public DateTime toDateTime(long time)
        {
            return new DateTime(time * 0x2710L);
        }

        [ProtoMember(2, IsRequired=false, Name="attributeDesc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string AttributeDesc
        {
            get
            {
                return this._attributeDesc;
            }
            set
            {
                this._attributeDesc = value;
            }
        }

        [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="attributeIconId", DataFormat=DataFormat.Default)]
        public string AttributeIconId
        {
            get
            {
                return this._attributeIconId;
            }
            set
            {
                this._attributeIconId = value;
            }
        }

        [ProtoMember(5, Name="baseInfos", DataFormat=DataFormat.Default)]
        public List<BaseInfo> BaseInfos
        {
            get
            {
                return this._baseInfos;
            }
        }

        [ProtoMember(8, Name="beastBreakthoughts", DataFormat=DataFormat.Default)]
        public List<BeastBreakthought> BeastBreakthoughts
        {
            get
            {
                return this._beastBreakthoughts;
            }
        }

        [ProtoMember(13, Name="beastIcons", DataFormat=DataFormat.Default)]
        public List<BeastIcon> BeastIcons
        {
            get
            {
                return this._beastIcons;
            }
        }

        [ProtoMember(7, Name="beastLevelUps", DataFormat=DataFormat.Default)]
        public List<BeastLevelUp> BeastLevelUps
        {
            get
            {
                return this._beastLevelUps;
            }
        }

        [ProtoMember(12, Name="beastPartAttriGroups", DataFormat=DataFormat.Default)]
        public List<BeastPartAttributeGroup> BeastPartAttriGroups
        {
            get
            {
                return this._beastPartAttriGroups;
            }
        }

        [ProtoMember(9, Name="beastParts", DataFormat=DataFormat.Default)]
        public List<BeastPart> BeastParts
        {
            get
            {
                return this._beastParts;
            }
        }

        [ProtoMember(11, IsRequired=false, Name="beastPartShops", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public BeastPartShop BeastPartShops
        {
            get
            {
                return this._beastPartShops;
            }
            set
            {
                this._beastPartShops = value;
            }
        }

        [ProtoMember(10, Name="beastSkills", DataFormat=DataFormat.Default)]
        public List<BeastSkill> BeastSkills
        {
            get
            {
                return this._beastSkills;
            }
        }

        [ProtoMember(6, Name="breakthoughtAndLevels", DataFormat=DataFormat.Default)]
        public List<BreakthoughtAndLevel> BreakthoughtAndLevels
        {
            get
            {
                return this._breakthoughtAndLevels;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="maxBreakthought", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int MaxBreakthought
        {
            get
            {
                return this._maxBreakthought;
            }
            set
            {
                this._maxBreakthought = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="maxLevel", DataFormat=DataFormat.TwosComplement)]
        public int MaxLevel
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

        public class _BeastTraitType : TypeNameContainer<BeastConfig._BeastTraitType>
        {
            public const int DPS = 1;
            public const int Heal = 3;
            public const int Support = 2;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<BeastConfig._BeastTraitType>.RegisterType("DPS", 1, "DPS");
                flag &= TypeNameContainer<BeastConfig._BeastTraitType>.RegisterType("Support", 2, "Support");
                return (flag & TypeNameContainer<BeastConfig._BeastTraitType>.RegisterType("Heal", 3, "Heal"));
            }
        }

        public class _PartIndex : TypeNameContainer<BeastConfig._PartIndex>
        {
            public const int AllPut = -1;
            public const int Five = 5;
            public const int Four = 4;
            public const int One = 1;
            public const int Three = 3;
            public const int Two = 2;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<BeastConfig._PartIndex>.RegisterType("AllPut", -1, "AllPut");
                flag &= TypeNameContainer<BeastConfig._PartIndex>.RegisterType("One", 1, "One");
                flag &= TypeNameContainer<BeastConfig._PartIndex>.RegisterType("Two", 2, "Two");
                flag &= TypeNameContainer<BeastConfig._PartIndex>.RegisterType("Three", 3, "Three");
                flag &= TypeNameContainer<BeastConfig._PartIndex>.RegisterType("Four", 4, "Four");
                return (flag & TypeNameContainer<BeastConfig._PartIndex>.RegisterType("Five", 5, "Five"));
            }
        }

        [ProtoContract(Name="BaseInfo")]
        public class BaseInfo : IExtensible
        {
            private string _beastName = "";
            private int _beastType;
            private string _bigIconId = "";
            private string _defaultGetWayDesc = "";
            private string _desc = "";
            private int _fragmentId;
            private ClientServerCommon.GetWay _getWay;
            private int _id;
            private bool _isShow;
            private int _minActiveBreakthought;
            private int _priority;
            private string _smallIconId = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="beastName", DataFormat=DataFormat.Default)]
            public string BeastName
            {
                get
                {
                    return this._beastName;
                }
                set
                {
                    this._beastName = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="beastType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int BeastType
            {
                get
                {
                    return this._beastType;
                }
                set
                {
                    this._beastType = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="bigIconId", DataFormat=DataFormat.Default), DefaultValue("")]
            public string BigIconId
            {
                get
                {
                    return this._bigIconId;
                }
                set
                {
                    this._bigIconId = value;
                }
            }

            [DefaultValue(""), ProtoMember(11, IsRequired=false, Name="defaultGetWayDesc", DataFormat=DataFormat.Default)]
            public string DefaultGetWayDesc
            {
                get
                {
                    return this._defaultGetWayDesc;
                }
                set
                {
                    this._defaultGetWayDesc = value;
                }
            }

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="desc", DataFormat=DataFormat.Default)]
            public string Desc
            {
                get
                {
                    return this._desc;
                }
                set
                {
                    this._desc = value;
                }
            }

            [DefaultValue(0), ProtoMember(10, IsRequired=false, Name="fragmentId", DataFormat=DataFormat.TwosComplement)]
            public int FragmentId
            {
                get
                {
                    return this._fragmentId;
                }
                set
                {
                    this._fragmentId = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(12, IsRequired=false, Name="getWay", DataFormat=DataFormat.Default)]
            public ClientServerCommon.GetWay GetWay
            {
                get
                {
                    return this._getWay;
                }
                set
                {
                    this._getWay = value;
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

            [DefaultValue(false), ProtoMember(7, IsRequired=false, Name="isShow", DataFormat=DataFormat.Default)]
            public bool IsShow
            {
                get
                {
                    return this._isShow;
                }
                set
                {
                    this._isShow = value;
                }
            }

            [ProtoMember(9, IsRequired=false, Name="minActiveBreakthought", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MinActiveBreakthought
            {
                get
                {
                    return this._minActiveBreakthought;
                }
                set
                {
                    this._minActiveBreakthought = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="priority", DataFormat=DataFormat.TwosComplement)]
            public int Priority
            {
                get
                {
                    return this._priority;
                }
                set
                {
                    this._priority = value;
                }
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="smallIconId", DataFormat=DataFormat.Default)]
            public string SmallIconId
            {
                get
                {
                    return this._smallIconId;
                }
                set
                {
                    this._smallIconId = value;
                }
            }
        }

        [ProtoContract(Name="BeastBreakthought")]
        public class BeastBreakthought : IExtensible
        {
            private int _activeCostFragmentCount;
            private int _breakthoughtAfter;
            private int _breakthoughtNow;
            private int _decomposeCount;
            private int _upCostFragmentCount;
            private Cost _upItemCost;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="activeCostFragmentCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ActiveCostFragmentCount
            {
                get
                {
                    return this._activeCostFragmentCount;
                }
                set
                {
                    this._activeCostFragmentCount = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="breakthoughtAfter", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int BreakthoughtAfter
            {
                get
                {
                    return this._breakthoughtAfter;
                }
                set
                {
                    this._breakthoughtAfter = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="breakthoughtNow", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int BreakthoughtNow
            {
                get
                {
                    return this._breakthoughtNow;
                }
                set
                {
                    this._breakthoughtNow = value;
                }
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="decomposeCount", DataFormat=DataFormat.TwosComplement)]
            public int DecomposeCount
            {
                get
                {
                    return this._decomposeCount;
                }
                set
                {
                    this._decomposeCount = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="upCostFragmentCount", DataFormat=DataFormat.TwosComplement)]
            public int UpCostFragmentCount
            {
                get
                {
                    return this._upCostFragmentCount;
                }
                set
                {
                    this._upCostFragmentCount = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="upItemCost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public Cost UpItemCost
            {
                get
                {
                    return this._upItemCost;
                }
                set
                {
                    this._upItemCost = value;
                }
            }
        }

        [ProtoContract(Name="BeastIcon")]
        public class BeastIcon : IExtensible
        {
            private int _breakthought;
            private int _iconId;
            private int _resourseId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="breakthought", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Breakthought
            {
                get
                {
                    return this._breakthought;
                }
                set
                {
                    this._breakthought = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int IconId
            {
                get
                {
                    return this._iconId;
                }
                set
                {
                    this._iconId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="resourseId", DataFormat=DataFormat.TwosComplement)]
            public int ResourseId
            {
                get
                {
                    return this._resourseId;
                }
                set
                {
                    this._resourseId = value;
                }
            }
        }

        [ProtoContract(Name="BeastLevelUp")]
        public class BeastLevelUp : IExtensible
        {
            private int _addLevel;
            private int _levelNext;
            private int _levelNow;
            private int _quality;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="addLevel", DataFormat=DataFormat.TwosComplement)]
            public int AddLevel
            {
                get
                {
                    return this._addLevel;
                }
                set
                {
                    this._addLevel = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="levelNext", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int LevelNext
            {
                get
                {
                    return this._levelNext;
                }
                set
                {
                    this._levelNext = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="levelNow", DataFormat=DataFormat.TwosComplement)]
            public int LevelNow
            {
                get
                {
                    return this._levelNow;
                }
                set
                {
                    this._levelNow = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="quality", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Quality
            {
                get
                {
                    return this._quality;
                }
                set
                {
                    this._quality = value;
                }
            }
        }

        [ProtoContract(Name="BeastPart")]
        public class BeastPart : IExtensible
        {
            private int _breakthought;
            private string _defaultGetWayDesc = "";
            private string _desc = "";
            private readonly List<GetWay> _getWays = new List<GetWay>();
            private string _partIconId = "";
            private int _partId;
            private string _partName = "";
            private int _sortPart;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, IsRequired=false, Name="breakthought", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Breakthought
            {
                get
                {
                    return this._breakthought;
                }
                set
                {
                    this._breakthought = value;
                }
            }

            [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="defaultGetWayDesc", DataFormat=DataFormat.Default)]
            public string DefaultGetWayDesc
            {
                get
                {
                    return this._defaultGetWayDesc;
                }
                set
                {
                    this._defaultGetWayDesc = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string Desc
            {
                get
                {
                    return this._desc;
                }
                set
                {
                    this._desc = value;
                }
            }

            [ProtoMember(8, Name="getWays", DataFormat=DataFormat.Default)]
            public List<GetWay> GetWays
            {
                get
                {
                    return this._getWays;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="partIconId", DataFormat=DataFormat.Default), DefaultValue("")]
            public string PartIconId
            {
                get
                {
                    return this._partIconId;
                }
                set
                {
                    this._partIconId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="partId", DataFormat=DataFormat.TwosComplement)]
            public int PartId
            {
                get
                {
                    return this._partId;
                }
                set
                {
                    this._partId = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="partName", DataFormat=DataFormat.Default)]
            public string PartName
            {
                get
                {
                    return this._partName;
                }
                set
                {
                    this._partName = value;
                }
            }

            [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="sortPart", DataFormat=DataFormat.TwosComplement)]
            public int SortPart
            {
                get
                {
                    return this._sortPart;
                }
                set
                {
                    this._sortPart = value;
                }
            }
        }

        [ProtoContract(Name="BeastPartActive")]
        public class BeastPartActive : IExtensible
        {
            private int _attributeId;
            private int _index;
            private Cost _partCost;
            private int _partPower;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="attributeId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int AttributeId
            {
                get
                {
                    return this._attributeId;
                }
                set
                {
                    this._attributeId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement)]
            public int Index
            {
                get
                {
                    return this._index;
                }
                set
                {
                    this._index = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="partCost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public Cost PartCost
            {
                get
                {
                    return this._partCost;
                }
                set
                {
                    this._partCost = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="partPower", DataFormat=DataFormat.TwosComplement)]
            public int PartPower
            {
                get
                {
                    return this._partPower;
                }
                set
                {
                    this._partPower = value;
                }
            }
        }

        [ProtoContract(Name="BeastPartAttributeGroup")]
        public class BeastPartAttributeGroup : IExtensible
        {
            private readonly List<ClientServerCommon.Attribute> _attributes = new List<ClientServerCommon.Attribute>();
            private int _id;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="attributes", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.Attribute> Attributes
            {
                get
                {
                    return this._attributes;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
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
        }

        [ProtoContract(Name="BeastPartShop")]
        public class BeastPartShop : IExtensible
        {
            private string _desc = "";
            private Cost _handRefreshCost;
            private readonly List<BeastConfig.RefreshInfo> _refreshInfos = new List<BeastConfig.RefreshInfo>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="desc", DataFormat=DataFormat.Default)]
            public string Desc
            {
                get
                {
                    return this._desc;
                }
                set
                {
                    this._desc = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="handRefreshCost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public Cost HandRefreshCost
            {
                get
                {
                    return this._handRefreshCost;
                }
                set
                {
                    this._handRefreshCost = value;
                }
            }

            [ProtoMember(3, Name="refreshInfos", DataFormat=DataFormat.Default)]
            public List<BeastConfig.RefreshInfo> RefreshInfos
            {
                get
                {
                    return this._refreshInfos;
                }
            }
        }

        [ProtoContract(Name="BeastSkill")]
        public class BeastSkill : IExtensible
        {
            private string _desc = "";
            private readonly List<int> _interfaceSkills = new List<int>();
            private int _prevLevelSkillId;
            private int _skillId;
            private string _skillName = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string Desc
            {
                get
                {
                    return this._desc;
                }
                set
                {
                    this._desc = value;
                }
            }

            [ProtoMember(5, Name="interfaceSkills", DataFormat=DataFormat.TwosComplement)]
            public List<int> InterfaceSkills
            {
                get
                {
                    return this._interfaceSkills;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="prevLevelSkillId", DataFormat=DataFormat.TwosComplement)]
            public int PrevLevelSkillId
            {
                get
                {
                    return this._prevLevelSkillId;
                }
                set
                {
                    this._prevLevelSkillId = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="skillId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int SkillId
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

            [ProtoMember(2, IsRequired=false, Name="skillName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string SkillName
            {
                get
                {
                    return this._skillName;
                }
                set
                {
                    this._skillName = value;
                }
            }
        }

        [ProtoContract(Name="BreakthoughtAndLevel")]
        public class BreakthoughtAndLevel : IExtensible
        {
            private readonly List<ClientServerCommon.Attribute> _attributes = new List<ClientServerCommon.Attribute>();
            private readonly List<BeastConfig.BeastPartActive> _beastPartActives = new List<BeastConfig.BeastPartActive>();
            private int _breakthought;
            private readonly List<PropertyModifier> _guardModifiers = new List<PropertyModifier>();
            private int _id;
            private int _level;
            private readonly List<BeastConfig.BeastSkill> _levelSkills = new List<BeastConfig.BeastSkill>();
            private int _power;
            private readonly List<BeastConfig.BeastSkill> _starSkills = new List<BeastConfig.BeastSkill>();
            private IExtension extensionObject;

            public List<int> GetAllInterfaceActionsIds()
            {
                List<int> list = new List<int>();
                List<BeastConfig.BeastSkill> collection = new List<BeastConfig.BeastSkill>();
                collection.AddRange(this.LevelSkills);
                using (List<BeastConfig.BeastSkill>.Enumerator enumerator = this.LevelSkills.GetEnumerator())
                {
                    BeastConfig.BeastSkill levelSkill;
                    while (enumerator.MoveNext())
                    {
                        levelSkill = enumerator.Current;
                        collection.RemoveAll(n => n.SkillId == levelSkill.PrevLevelSkillId);
                    }
                }
                List<BeastConfig.BeastSkill> list3 = new List<BeastConfig.BeastSkill>();
                list3.AddRange(this.StarSkills);
                using (List<BeastConfig.BeastSkill>.Enumerator enumerator2 = this.StarSkills.GetEnumerator())
                {
                    BeastConfig.BeastSkill starSkill;
                    while (enumerator2.MoveNext())
                    {
                        starSkill = enumerator2.Current;
                        list3.RemoveAll(n => n.SkillId == starSkill.PrevLevelSkillId);
                    }
                }
                List<BeastConfig.BeastSkill> list4 = new List<BeastConfig.BeastSkill>();
                list4.AddRange(collection);
                list4.AddRange(list3);
                foreach (BeastConfig.BeastSkill skill in list4)
                {
                    list.AddRange(skill.InterfaceSkills);
                }
                return list;
            }

            public BeastConfig.BeastPartActive GetBeastPartActiveByIndex(int index)
            {
                foreach (BeastConfig.BeastPartActive active in this._beastPartActives)
                {
                    if (active.Index == index)
                    {
                        return active;
                    }
                }
                return null;
            }

            public float GetBeastPartPowerByActiveId(int id)
            {
                foreach (BeastConfig.BeastPartActive active in this._beastPartActives)
                {
                    if (active.AttributeId == id)
                    {
                        return (float) active.PartPower;
                    }
                }
                return 0f;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, Name="attributes", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.Attribute> Attributes
            {
                get
                {
                    return this._attributes;
                }
            }

            [ProtoMember(5, Name="beastPartActives", DataFormat=DataFormat.Default)]
            public List<BeastConfig.BeastPartActive> BeastPartActives
            {
                get
                {
                    return this._beastPartActives;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="breakthought", DataFormat=DataFormat.TwosComplement)]
            public int Breakthought
            {
                get
                {
                    return this._breakthought;
                }
                set
                {
                    this._breakthought = value;
                }
            }

            [ProtoMember(7, Name="guardModifiers", DataFormat=DataFormat.Default)]
            public List<PropertyModifier> GuardModifiers
            {
                get
                {
                    return this._guardModifiers;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(3, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Level
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

            [ProtoMember(8, Name="levelSkills", DataFormat=DataFormat.Default)]
            public List<BeastConfig.BeastSkill> LevelSkills
            {
                get
                {
                    return this._levelSkills;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="power", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Power
            {
                get
                {
                    return this._power;
                }
                set
                {
                    this._power = value;
                }
            }

            [ProtoMember(9, Name="starSkills", DataFormat=DataFormat.Default)]
            public List<BeastConfig.BeastSkill> StarSkills
            {
                get
                {
                    return this._starSkills;
                }
            }
        }

        [ProtoContract(Name="RefreshInfo")]
        public class RefreshInfo : IExtensible
        {
            private int _index;
            private long _refreshTime;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Index
            {
                get
                {
                    return this._index;
                }
                set
                {
                    this._index = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="refreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
            public long RefreshTime
            {
                get
                {
                    return this._refreshTime;
                }
                set
                {
                    this._refreshTime = value;
                }
            }
        }
    }
}

