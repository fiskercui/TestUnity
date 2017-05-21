namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="AvatarConfig")]
    public class AvatarConfig : Configuration, IExtensible
    {
        private readonly List<Avatar> _avatars = new List<Avatar>();
        private readonly List<PowerUpCost> _powerUpCosts = new List<PowerUpCost>();
        private readonly List<SellGeneralReward> _sellGeneralRewards = new List<SellGeneralReward>();
        private string _sellPrice_Expression = "";
        private IExtension extensionObject;
        private Dictionary<int, Avatar> id_avatarDict = new Dictionary<int, Avatar>();
        private Dictionary<int, SellGeneralReward> level_sellGeneralRewardMap = new Dictionary<int, SellGeneralReward>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (SellGeneralReward reward in this.sellGeneralRewards)
            {
                this.level_sellGeneralRewardMap.Add(reward.level, reward);
            }
            for (int i = 0; i < this._avatars.Count; i++)
            {
                Avatar avatar = this._avatars[i];
                if (this.id_avatarDict.ContainsKey(avatar.id))
                {
                    Logger.Error(string.Format("Duplicate avatar Id : {0:X}", avatar.id), new object[0]);
                }
                else
                {
                    foreach (AvatarBreakthrough breakthrough in avatar.breakThroughs)
                    {
                        foreach (GrowthAttribute attribute in avatar.breakThroughs[0].baseGrowthAttributes)
                        {
                            for (int j = 0; j < breakthrough.breakThrough.growthAttributes.Count; j++)
                            {
                                GrowthAttribute attribute2 = breakthrough.breakThrough.growthAttributes[j];
                                if (attribute.type == attribute2.type)
                                {
                                    break;
                                }
                                if (j == (breakthrough.breakThrough.growthAttributes.Count - 1))
                                {
                                    breakthrough.breakThrough.growthAttributes.Add(attribute);
                                }
                            }
                        }
                    }
                    this.id_avatarDict.Add(avatar.id, avatar);
                }
            }
        }

        public Avatar GetAvatarById(int id)
        {
            Avatar avatar = null;
            if (!this.id_avatarDict.TryGetValue(id, out avatar))
            {
                Logger.Warn(string.Format("Missing avatar : {0:X}", id), new object[0]);
            }
            return avatar;
        }

        public QualityCost GetQualityCostByLevelAndQuality(int level, int quality)
        {
            foreach (PowerUpCost cost in this._powerUpCosts)
            {
                if (cost.level == level)
                {
                    foreach (QualityCost cost2 in cost.qualityCosts)
                    {
                        if (cost2.qualityLevel == quality)
                        {
                            return cost2;
                        }
                    }
                }
            }
            return null;
        }

        public List<Reward> GetSellGeneralRewardsByLevel(int level, int qualityLevel)
        {
            SellGeneralReward reward;
            List<Reward> list = new List<Reward>();
            if (this.level_sellGeneralRewardMap.TryGetValue(level, out reward))
            {
                for (int i = 0; i < reward.qualityRewards.Count; i++)
                {
                    if (reward.qualityRewards[i].qualityLevel == qualityLevel)
                    {
                        list.AddRange(reward.qualityRewards[i].rewards);
                    }
                }
            }
            return list;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _AvatarTraitType.Initialize();
            _CharacterType.Initialize();
            _AvatarCountryType.Initialize();
            _AvatarGender.Initialize();
            _AvatarActiveSkillType.Initialize();
            AssembleSetting.Requirement._Type.Initialize();
        }

        private AvatarBreakthrough LoadAvatarBreakThoughFromXml(SecurityElement element)
        {
            AvatarBreakthrough breakthrough = new AvatarBreakthrough {
                assetId = StrParser.ParseHexInt(element.Attribute("AvatarAssetId"), 0),
                highAssetId = StrParser.ParseHexInt(element.Attribute("HighAvatarAssetId"), 0),
                particleName = StrParser.ParseStr(element.Attribute("ParticleName"), string.Empty),
                canGetSellItemGeneralRewards = StrParser.ParseBool(element.Attribute("CanGetSellItemGeneralRewards"), false),
                leastSameCardCount = StrParser.ParseDecInt(element.Attribute("LeastSameCardCount"), 0),
                compositeSkillLevel = StrParser.ParseDecInt(element.Attribute("CompositeSkillLevel"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "Breakthrough")
                        {
                            if (tag == "SellReward")
                            {
                                goto Label_011D;
                            }
                            if (tag == "BaseAttributes")
                            {
                                goto Label_0133;
                            }
                            if (tag == "PowerAttribute")
                            {
                                goto Label_01C3;
                            }
                        }
                        else
                        {
                            breakthrough.breakThrough = Breakthrough.LoadFromXml(element2);
                        }
                    }
                    continue;
                Label_011D:
                    breakthrough.sellRewards.Add(Reward.LoadFromXml(element2));
                    continue;
                Label_0133:
                    if ((element2.Children != null) && (element2.Children.Count != 0))
                    {
                        foreach (SecurityElement element3 in element2.Children)
                        {
                            string str2;
                            if (((str2 = element3.Tag) != null) && (str2 == "Attribute"))
                            {
                                GrowthAttribute item = GrowthAttribute.LoadFromXml(element3);
                                if (item.baseValue != 0f)
                                {
                                    breakthrough.baseGrowthAttributes.Add(item);
                                }
                            }
                        }
                    }
                    continue;
                Label_01C3:
                    breakthrough.powerAttributes = PowerAttribute.LoadFromXml(element2);
                }
            }
            return breakthrough;
        }

        private Avatar LoadAvatarFromXml(SecurityElement element)
        {
            Avatar avatar = new Avatar {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                sortIndex = StrParser.ParseDecInt(element.Attribute("SortIndex"), 0)
            };
            avatar.qualityLevel = StrParser.ParseDecInt(element.Attribute("QualityLevel"), avatar.qualityLevel);
            avatar.gender = TypeNameContainer<_AvatarGender>.Parse(element.Attribute("Gender"), 0);
            avatar.growthDesc = StrParser.ParseStr(element.Attribute("GrowthDesc"), "", true);
            avatar.countryType = TypeNameContainer<_AvatarCountryType>.Parse(element.Attribute("CountryType"), 0);
            avatar.traitDesc = StrParser.ParseStr(element.Attribute("TraitDesc"), "", true);
            avatar.traitType = TypeNameContainer<_AvatarTraitType>.Parse(element.Attribute("TraitType"), 0);
            avatar.characterType = StrParser.ParseDecInt(element.Attribute("CharacterType"), 0);
            avatar.cardPicture = StrParser.ParseStr(element.Attribute("CardPicture"), "");
            avatar.npcDesc = StrParser.ParseStr(element.Attribute("NpcDesc"), "");
            avatar.smardCardRect = rect.LoadFromXml(element.Attribute("SmardCardRect"));
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    switch (element2.Tag)
                    {
                        case "Assemble":
                        {
                            int item = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            if (item != 0)
                            {
                                avatar.assemableIds.Add(item);
                            }
                            break;
                        }
                        case "AvatarBreakthrough":
                            avatar.breakThroughs.Add(this.LoadAvatarBreakThoughFromXml(element2));
                            break;

                        case "AvatarDefaultSkillId":
                        {
                            int num2 = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            if (num2 != 0)
                            {
                                avatar.avatarDefaultSkillIds.Add(num2);
                            }
                            break;
                        }
                        case "Voice":
                            avatar.voices.Add(StrParser.ParseStr(element2.Attribute("Name"), ""));
                            break;

                        case "GetWay":
                            avatar.getways.Add(GetWay.LoadFromXml(element2));
                            break;

                        case "WeaponAsset":
                            avatar.weaponAssets.Add(this.LoadWeaponAssetFromXml(element2));
                            break;

                        case "ShowWeaponAsset":
                            avatar.showWeaponAssets.Add(this.LoadWeaponAssetFromXml(element2));
                            break;

                        case "CompositeSkillId":
                            avatar.compositeSkillId = StrParser.ParseHexInt(element2.Text, 0);
                            break;
                    }
                }
            }
            return avatar;
        }

        private void LoadAvatarSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Avatar")
                    {
                        this._avatars.Add(this.LoadAvatarFromXml(element2));
                    }
                }
            }
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "AvatarConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "AvatarSet")
                        {
                            if (tag == "PowerUpCostSet")
                            {
                                goto Label_0081;
                            }
                            if (tag == "SellGeneralRewardSet")
                            {
                                goto Label_008A;
                            }
                            if (tag == "SellPrice_Expression")
                            {
                                goto Label_0093;
                            }
                        }
                        else
                        {
                            this.LoadAvatarSetFromXml(element2);
                        }
                    }
                    continue;
                Label_0081:
                    this.LoadPowerUpCostSetFromXml(element2);
                    continue;
                Label_008A:
                    this.LoadSellGeneralRewardSetFromXml(element2);
                    continue;
                Label_0093:
                    this._sellPrice_Expression = element2.Text;
                }
            }
        }

        private PowerUpCost LoadPowerUpCostFromXml(SecurityElement element)
        {
            PowerUpCost cost = new PowerUpCost {
                level = StrParser.ParseDecInt(element.Attribute("Level"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "QualityCost"))
                    {
                        cost.qualityCosts.Add(this.LoadQualityCostFromXml(element2));
                    }
                }
            }
            return cost;
        }

        private void LoadPowerUpCostSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "PowerUpCost"))
                    {
                        this._powerUpCosts.Add(this.LoadPowerUpCostFromXml(element2));
                    }
                }
            }
        }

        private QualityCost LoadQualityCostFromXml(SecurityElement element)
        {
            QualityCost cost = new QualityCost {
                qualityLevel = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Cost")
                    {
                        cost.costs.Add(Cost.LoadFromXml(element2));
                    }
                }
            }
            return cost;
        }

        private QualityReward LoadQualityRewardFromXml(SecurityElement element)
        {
            QualityReward reward = new QualityReward {
                qualityLevel = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Reward")
                    {
                        reward.rewards.Add(Reward.LoadFromXml(element2));
                    }
                }
            }
            return reward;
        }

        private SellGeneralReward LoadSellGeneralRewardFromXml(SecurityElement element)
        {
            SellGeneralReward reward = new SellGeneralReward {
                level = StrParser.ParseDecInt(element.Attribute("Level"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "QualityReward"))
                    {
                        reward.qualityRewards.Add(this.LoadQualityRewardFromXml(element2));
                    }
                }
            }
            return reward;
        }

        private void LoadSellGeneralRewardSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "SellGeneralReward"))
                    {
                        this._sellGeneralRewards.Add(this.LoadSellGeneralRewardFromXml(element2));
                    }
                }
            }
        }

        private WeaponAsset LoadWeaponAssetFromXml(SecurityElement element)
        {
            return new WeaponAsset { 
                avatarAssetId = StrParser.ParseHexInt(element.Attribute("AvatarAssetId"), 0),
                mountBone = StrParser.ParseStr(element.Attribute("MountBone"), "")
            };
        }

        [ProtoMember(1, Name="avatars", DataFormat=DataFormat.Default)]
        public List<Avatar> avatars
        {
            get
            {
                return this._avatars;
            }
        }

        [ProtoMember(2, Name="powerUpCosts", DataFormat=DataFormat.Default)]
        public List<PowerUpCost> powerUpCosts
        {
            get
            {
                return this._powerUpCosts;
            }
        }

        [ProtoMember(4, Name="sellGeneralRewards", DataFormat=DataFormat.Default)]
        public List<SellGeneralReward> sellGeneralRewards
        {
            get
            {
                return this._sellGeneralRewards;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="sellPrice_Expression", DataFormat=DataFormat.Default), DefaultValue("")]
        public string sellPrice_Expression
        {
            get
            {
                return this._sellPrice_Expression;
            }
            set
            {
                this._sellPrice_Expression = value;
            }
        }

        public class _AvatarActiveSkillType : TypeNameContainer<AvatarConfig._AvatarActiveSkillType>
        {
            public const int AvatarGender = 3;
            public const int PlayerLevel = 1;
            public const int Unkonw = 0;
            public const int VipLevel = 2;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<AvatarConfig._AvatarActiveSkillType>.RegisterType("Unkonw", 0, "Unkonw");
                flag &= TypeNameContainer<AvatarConfig._AvatarActiveSkillType>.RegisterType("PlayerLevel", 1, "PlayerLevel");
                flag &= TypeNameContainer<AvatarConfig._AvatarActiveSkillType>.RegisterType("VipLevel", 2, "VipLevel");
                return (flag & TypeNameContainer<AvatarConfig._AvatarActiveSkillType>.RegisterType("AvatarGender", 3, "AvatarGender"));
            }
        }

        public class _AvatarCountryType : TypeNameContainer<AvatarConfig._AvatarCountryType>
        {
            public const int All = -1;
            public const int ChuGuo = 8;
            public const int HanGuo = 0x10;
            public const int LiuGuo = 0x1d;
            public const int NoCountry = 0x40000000;
            public const int QinGuo = 2;
            public const int QunXiong = 1;
            public const int UnKnow = 0;
            public const int YanGuo = 4;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<AvatarConfig._AvatarCountryType>.RegisterType("QunXiong", 1, "Country_QunXiong");
                flag &= TypeNameContainer<AvatarConfig._AvatarCountryType>.RegisterType("QinGuo", 2, "Country_QinGuo");
                flag &= TypeNameContainer<AvatarConfig._AvatarCountryType>.RegisterType("YanGuo", 4, "Country_YanGuo");
                flag &= TypeNameContainer<AvatarConfig._AvatarCountryType>.RegisterType("ChuGuo", 8, "Country_ChuGuo");
                flag &= TypeNameContainer<AvatarConfig._AvatarCountryType>.RegisterType("HanGuo", 0x10, "Country_HanGuo");
                flag &= TypeNameContainer<AvatarConfig._AvatarCountryType>.RegisterType("All", -1, "Country_All");
                flag &= TypeNameContainer<AvatarConfig._AvatarCountryType>.RegisterType("LiuGuo", 0x1d);
                return (flag & TypeNameContainer<AvatarConfig._AvatarCountryType>.RegisterType("NoCountry", 0x40000000, "Country_NoCountry"));
            }
        }

        public class _AvatarGender : TypeNameContainer<AvatarConfig._AvatarGender>
        {
            public const int Female = 2;
            public const int Male = 1;
            public const int Unkonw = 0;

            public static bool Initialize()
            {
                bool flag = false;
                TypeNameContainer<AvatarConfig._AvatarGender>.SetTextSectionName("AvatarGender");
                flag &= TypeNameContainer<AvatarConfig._AvatarGender>.RegisterType("Unkonw", 0, "Unkonw");
                flag &= TypeNameContainer<AvatarConfig._AvatarGender>.RegisterType("Male", 1, "Male");
                return (flag & TypeNameContainer<AvatarConfig._AvatarGender>.RegisterType("Female", 2, "Female"));
            }
        }

        public class _AvatarTraitType : TypeNameContainer<AvatarConfig._AvatarTraitType>
        {
            public const int DPS = 1;
            public const int Heal = 4;
            public const int Support = 3;
            public const int Tank = 2;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<AvatarConfig._AvatarTraitType>.RegisterType("DPS", 1, "TraitType_DPS");
                flag &= TypeNameContainer<AvatarConfig._AvatarTraitType>.RegisterType("Tank", 2, "TraitType_Tank");
                flag &= TypeNameContainer<AvatarConfig._AvatarTraitType>.RegisterType("Support", 3, "TraitType_Suport");
                return (flag & TypeNameContainer<AvatarConfig._AvatarTraitType>.RegisterType("Heal", 4, "TraitType_Heal"));
            }
        }

        public class _CharacterType : TypeNameContainer<AvatarConfig._CharacterType>
        {
            public const int AllCharType = -1;
            public const int Magic = 2;
            public const int Physics = 1;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<AvatarConfig._CharacterType>.RegisterType("Physics", 1, "AvatarType_Physics");
                flag &= TypeNameContainer<AvatarConfig._CharacterType>.RegisterType("Magic", 2, "AvatarType_Magic");
                return (flag & TypeNameContainer<AvatarConfig._CharacterType>.RegisterType("AllCharType", -1));
            }
        }

        public class AssembleSetting
        {
            public class Requirement
            {
                public class _Type : TypeNameContainer<AvatarConfig.AssembleSetting.Requirement._Type>
                {
                    public const int Avatar = 1;
                    public const int Equipment = 2;
                    public const int Skill = 3;
                    public const int Unknown = 0;

                    public static bool Initialize()
                    {
                        bool flag = false;
                        flag &= TypeNameContainer<AvatarConfig.AssembleSetting.Requirement._Type>.RegisterType("Avatar", 1);
                        flag &= TypeNameContainer<AvatarConfig.AssembleSetting.Requirement._Type>.RegisterType("Equipment", 2);
                        return (flag & TypeNameContainer<AvatarConfig.AssembleSetting.Requirement._Type>.RegisterType("Skill", 3));
                    }
                }
            }
        }

        [ProtoContract(Name="Avatar")]
        public class Avatar : IExtensible
        {
            private readonly List<int> _assemableIds = new List<int>();
            private readonly List<int> _avatarDefaultSkillIds = new List<int>();
            private readonly List<AvatarConfig.AvatarBreakthrough> _breakThroughs = new List<AvatarConfig.AvatarBreakthrough>();
            private string _cardPicture = "";
            private int _characterType;
            private int _compositeSkillId;
            private int _countryType;
            private int _gender;
            private readonly List<GetWay> _getways = new List<GetWay>();
            private string _growthDesc = "";
            private int _id;
            private string _npcDesc = "";
            private int _qualityLevel;
            private readonly List<AvatarConfig.WeaponAsset> _showWeaponAssets = new List<AvatarConfig.WeaponAsset>();
            private rect _smardCardRect;
            private int _sortIndex;
            private string _traitDesc = "";
            private int _traitType;
            private readonly List<string> _voices = new List<string>();
            private readonly List<AvatarConfig.WeaponAsset> _weaponAssets = new List<AvatarConfig.WeaponAsset>();
            private IExtension extensionObject;

            public int GetAvatarAssetId(int breakTimes)
            {
                foreach (AvatarConfig.AvatarBreakthrough breakthrough in this._breakThroughs)
                {
                    if (breakthrough.breakThrough.fromTimes == breakTimes)
                    {
                        return breakthrough.assetId;
                    }
                }
                if (this._breakThroughs.Count > 0)
                {
                    return this._breakThroughs[0].assetId;
                }
                return 0;
            }

            public AvatarConfig.AvatarBreakthrough GetAvatarBreakthrough(int breakTimes)
            {
                foreach (AvatarConfig.AvatarBreakthrough breakthrough in this._breakThroughs)
                {
                    if (breakthrough.breakThrough.fromTimes == breakTimes)
                    {
                        return breakthrough;
                    }
                }
                return null;
            }

            public int GetBreakThoughtLevelByCompositeSkillLevel(int compositeSkillLevel)
            {
                foreach (AvatarConfig.AvatarBreakthrough breakthrough in this._breakThroughs)
                {
                    if (breakthrough.compositeSkillLevel == compositeSkillLevel)
                    {
                        return breakthrough.breakThrough.fromTimes;
                    }
                }
                return -1;
            }

            public int GetCompositeSkillLevelByBreakThroughLevel(int breakThroughLevel)
            {
                foreach (AvatarConfig.AvatarBreakthrough breakthrough in this._breakThroughs)
                {
                    if (breakthrough.breakThrough.fromTimes == breakThroughLevel)
                    {
                        return breakthrough.compositeSkillLevel;
                    }
                }
                return -1;
            }

            public int GetHighAvatarAssetId(int breakTimes)
            {
                foreach (AvatarConfig.AvatarBreakthrough breakthrough in this._breakThroughs)
                {
                    if (breakthrough.breakThrough.fromTimes == breakTimes)
                    {
                        return breakthrough.highAssetId;
                    }
                }
                if (this._breakThroughs.Count > 0)
                {
                    return this._breakThroughs[0].highAssetId;
                }
                return 0;
            }

            public int GetMaxBreakthoughtLevel()
            {
                int fromTimes = 0;
                foreach (AvatarConfig.AvatarBreakthrough breakthrough in this._breakThroughs)
                {
                    if (breakthrough.breakThrough.fromTimes > fromTimes)
                    {
                        fromTimes = breakthrough.breakThrough.fromTimes;
                    }
                }
                return fromTimes;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(0x19, Name="assemableIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> assemableIds
            {
                get
                {
                    return this._assemableIds;
                }
            }

            [ProtoMember(14, Name="avatarDefaultSkillIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> avatarDefaultSkillIds
            {
                get
                {
                    return this._avatarDefaultSkillIds;
                }
            }

            [ProtoMember(0x18, Name="breakThroughs", DataFormat=DataFormat.Default)]
            public List<AvatarConfig.AvatarBreakthrough> breakThroughs
            {
                get
                {
                    return this._breakThroughs;
                }
            }

            [ProtoMember(0x1a, IsRequired=false, Name="cardPicture", DataFormat=DataFormat.Default), DefaultValue("")]
            public string cardPicture
            {
                get
                {
                    return this._cardPicture;
                }
                set
                {
                    this._cardPicture = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x1d, IsRequired=false, Name="characterType", DataFormat=DataFormat.TwosComplement)]
            public int characterType
            {
                get
                {
                    return this._characterType;
                }
                set
                {
                    this._characterType = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x23, IsRequired=false, Name="compositeSkillId", DataFormat=DataFormat.TwosComplement)]
            public int compositeSkillId
            {
                get
                {
                    return this._compositeSkillId;
                }
                set
                {
                    this._compositeSkillId = value;
                }
            }

            [ProtoMember(0x17, IsRequired=false, Name="countryType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int countryType
            {
                get
                {
                    return this._countryType;
                }
                set
                {
                    this._countryType = value;
                }
            }

            [ProtoMember(0x12, IsRequired=false, Name="gender", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int gender
            {
                get
                {
                    return this._gender;
                }
                set
                {
                    this._gender = value;
                }
            }

            [ProtoMember(30, Name="getways", DataFormat=DataFormat.Default)]
            public List<GetWay> getways
            {
                get
                {
                    return this._getways;
                }
            }

            [DefaultValue(""), ProtoMember(0x10, IsRequired=false, Name="growthDesc", DataFormat=DataFormat.Default)]
            public string growthDesc
            {
                get
                {
                    return this._growthDesc;
                }
                set
                {
                    this._growthDesc = value;
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

            [ProtoMember(0x22, IsRequired=false, Name="npcDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string npcDesc
            {
                get
                {
                    return this._npcDesc;
                }
                set
                {
                    this._npcDesc = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="qualityLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(0x20, Name="showWeaponAssets", DataFormat=DataFormat.Default)]
            public List<AvatarConfig.WeaponAsset> showWeaponAssets
            {
                get
                {
                    return this._showWeaponAssets;
                }
            }

            [ProtoMember(0x1b, IsRequired=false, Name="smardCardRect", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public rect smardCardRect
            {
                get
                {
                    return this._smardCardRect;
                }
                set
                {
                    this._smardCardRect = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x21, IsRequired=false, Name="sortIndex", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue(""), ProtoMember(0x11, IsRequired=false, Name="traitDesc", DataFormat=DataFormat.Default)]
            public string traitDesc
            {
                get
                {
                    return this._traitDesc;
                }
                set
                {
                    this._traitDesc = value;
                }
            }

            [ProtoMember(20, IsRequired=false, Name="traitType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int traitType
            {
                get
                {
                    return this._traitType;
                }
                set
                {
                    this._traitType = value;
                }
            }

            [ProtoMember(0x1c, Name="voices", DataFormat=DataFormat.Default)]
            public List<string> voices
            {
                get
                {
                    return this._voices;
                }
            }

            [ProtoMember(0x1f, Name="weaponAssets", DataFormat=DataFormat.Default)]
            public List<AvatarConfig.WeaponAsset> weaponAssets
            {
                get
                {
                    return this._weaponAssets;
                }
            }
        }

        [ProtoContract(Name="AvatarBreakthrough")]
        public class AvatarBreakthrough : IExtensible
        {
            private int _assetId;
            private readonly List<GrowthAttribute> _baseGrowthAttributes = new List<GrowthAttribute>();
            private Breakthrough _breakThrough;
            private bool _canGetSellItemGeneralRewards;
            private int _compositeSkillLevel;
            private int _highAssetId;
            private int _leastSameCardCount;
            private string _particleName = "";
            private PowerAttribute _powerAttributes;
            private readonly List<Reward> _sellRewards = new List<Reward>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="assetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int assetId
            {
                get
                {
                    return this._assetId;
                }
                set
                {
                    this._assetId = value;
                }
            }

            [ProtoMember(6, Name="baseGrowthAttributes", DataFormat=DataFormat.Default)]
            public List<GrowthAttribute> baseGrowthAttributes
            {
                get
                {
                    return this._baseGrowthAttributes;
                }
            }

            [DefaultValue((string) null), ProtoMember(1, IsRequired=false, Name="breakThrough", DataFormat=DataFormat.Default)]
            public Breakthrough breakThrough
            {
                get
                {
                    return this._breakThrough;
                }
                set
                {
                    this._breakThrough = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="canGetSellItemGeneralRewards", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool canGetSellItemGeneralRewards
            {
                get
                {
                    return this._canGetSellItemGeneralRewards;
                }
                set
                {
                    this._canGetSellItemGeneralRewards = value;
                }
            }

            [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="compositeSkillLevel", DataFormat=DataFormat.TwosComplement)]
            public int compositeSkillLevel
            {
                get
                {
                    return this._compositeSkillLevel;
                }
                set
                {
                    this._compositeSkillLevel = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="highAssetId", DataFormat=DataFormat.TwosComplement)]
            public int highAssetId
            {
                get
                {
                    return this._highAssetId;
                }
                set
                {
                    this._highAssetId = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="leastSameCardCount", DataFormat=DataFormat.TwosComplement)]
            public int leastSameCardCount
            {
                get
                {
                    return this._leastSameCardCount;
                }
                set
                {
                    this._leastSameCardCount = value;
                }
            }

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="particleName", DataFormat=DataFormat.Default)]
            public string particleName
            {
                get
                {
                    return this._particleName;
                }
                set
                {
                    this._particleName = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="powerAttributes", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

            [ProtoMember(4, Name="sellRewards", DataFormat=DataFormat.Default)]
            public List<Reward> sellRewards
            {
                get
                {
                    return this._sellRewards;
                }
            }
        }

        [ProtoContract(Name="WeaponAsset")]
        public class WeaponAsset : IExtensible
        {
            private int _avatarAssetId;
            private string _mountBone = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="avatarAssetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int avatarAssetId
            {
                get
                {
                    return this._avatarAssetId;
                }
                set
                {
                    this._avatarAssetId = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="mountBone", DataFormat=DataFormat.Default), DefaultValue("")]
            public string mountBone
            {
                get
                {
                    return this._mountBone;
                }
                set
                {
                    this._mountBone = value;
                }
            }
        }
    }
}

