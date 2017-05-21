namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="EquipmentConfig")]
    public class EquipmentConfig : Configuration, IExtensible
    {
        private readonly List<Equipment> _equipments = new List<Equipment>();
        private readonly List<PowerUpCost> _powerUpCosts = new List<PowerUpCost>();
        private readonly List<SellGeneralReward> _sellGeneralRewards = new List<SellGeneralReward>();
        private string _sellPrice_Expression = "";
        private IExtension extensionObject;
        private Dictionary<int, Equipment> id_equipMap = new Dictionary<int, Equipment>();
        private Dictionary<int, SellGeneralReward> level_sellGeneralRewardMap = new Dictionary<int, SellGeneralReward>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (SellGeneralReward reward in this.sellGeneralRewards)
            {
                this.level_sellGeneralRewardMap.Add(reward.level, reward);
            }
            foreach (Equipment equipment in this._equipments)
            {
                if (equipment != null)
                {
                    if (this.id_equipMap.ContainsKey(equipment.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + equipment.id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        foreach (EquipBreakthrough breakthrough in equipment.equipBreakthroughs)
                        {
                            foreach (GrowthAttribute attribute in equipment.equipBreakthroughs[0].baseGrowthAttributes)
                            {
                                for (int i = 0; i < breakthrough.breakThrough.growthAttributes.Count; i++)
                                {
                                    GrowthAttribute attribute2 = breakthrough.breakThrough.growthAttributes[i];
                                    if (attribute.type == attribute2.type)
                                    {
                                        break;
                                    }
                                    if (i == (breakthrough.breakThrough.growthAttributes.Count - 1))
                                    {
                                        breakthrough.breakThrough.growthAttributes.Add(attribute);
                                    }
                                }
                            }
                        }
                        this.id_equipMap.Add(equipment.id, equipment);
                    }
                }
            }
        }

        public Equipment GetEquipmentById(int equipId)
        {
            Equipment equipment;
            if (!this.id_equipMap.TryGetValue(equipId, out equipment))
            {
                return null;
            }
            return equipment;
        }

        public float GetOneEquipmentBasePower(int equipmentId, int level, int breakthrough)
        {
            Equipment equipmentById = this.GetEquipmentById(equipmentId);
            if (equipmentById == null)
            {
                Logger.Warn("Invalid Equipment Id : {0:X}", new object[] { equipmentId });
                return 0f;
            }
            EquipBreakthrough breakthroughByTimes = equipmentById.GetBreakthroughByTimes(breakthrough);
            if (breakthroughByTimes == null)
            {
                Logger.Warn("Invalid Equipment Breakthrough : {0:X}", new object[] { breakthrough });
                return 0f;
            }
            PowerAttribute powerAttributes = breakthroughByTimes.powerAttributes;
            if (powerAttributes == null)
            {
                Logger.Warn("Invalid Equipment Breakthrough PowerBuffer is Not Find!", new object[0]);
                return 0f;
            }
            return powerAttributes.GetValue(level);
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

        public static void Initizlize()
        {
            _Type.Initialize();
            _WeaponType.Initialize();
        }

        private EquipBreakthrough LoadEquipmentBreakthroughFromXml(SecurityElement element)
        {
            EquipBreakthrough breakthrough = new EquipBreakthrough {
                canGetSellItemGeneralRewards = StrParser.ParseBool(element.Attribute("CanGetSellItemGeneralRewards"), false)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "UpgradeRequirementAddtionalCost")
                        {
                            if (tag == "Breakthrough")
                            {
                                goto Label_00B4;
                            }
                            if (tag == "SellReward")
                            {
                                goto Label_00C5;
                            }
                            if (tag == "BaseAttributes")
                            {
                                goto Label_00DB;
                            }
                            if (tag == "PowerAttribute")
                            {
                                goto Label_016B;
                            }
                        }
                        else
                        {
                            breakthrough.upgradeRequirementAddtionalCost = Cost.LoadFromXml(element2);
                        }
                    }
                    continue;
                Label_00B4:
                    breakthrough.breakThrough = Breakthrough.LoadFromXml(element2);
                    continue;
                Label_00C5:
                    breakthrough.sellRewards.Add(Reward.LoadFromXml(element2));
                    continue;
                Label_00DB:
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
                Label_016B:
                    breakthrough.powerAttributes = PowerAttribute.LoadFromXml(element2);
                }
            }
            return breakthrough;
        }

        private Equipment LoadEquipmentFromXml(SecurityElement element)
        {
            Equipment equipment = new Equipment {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                sortIndex = StrParser.ParseDecInt(element.Attribute("SortIndex"), 0),
                type = TypeNameContainer<_Type>.Parse(element.Attribute("Type"), 0),
                qualityLevel = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0),
                weaponType = TypeNameContainer<_WeaponType>.Parse(element.Attribute("WeaponType"), 0),
                activeableAssembleDesc = StrParser.ParseStr(element.Attribute("ActiveableAssembleDesc"), string.Empty, true)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "EquipmentBreakthrough")
                        {
                            equipment.equipBreakthroughs.Add(this.LoadEquipmentBreakthroughFromXml(element2));
                        }
                        else if (tag == "GetWay")
                        {
                            goto Label_00F4;
                        }
                    }
                    continue;
                Label_00F4:
                    equipment.getways.Add(GetWay.LoadFromXml(element2));
                }
            }
            return equipment;
        }

        private void LoadEquipmentSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Equipment")
                    {
                        this.equipments.Add(this.LoadEquipmentFromXml(element2));
                    }
                }
            }
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "EquipmentConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "EquipmentSet")
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
                            this.LoadEquipmentSetFromXml(element2);
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

        [ProtoMember(1, Name="equipments", DataFormat=DataFormat.Default)]
        public List<Equipment> equipments
        {
            get
            {
                return this._equipments;
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

        public class _Type : TypeNameContainer<EquipmentConfig._Type>
        {
            public const int AllEquipType = -1;
            public const int Armor = 2;
            public const int Decoration = 4;
            public const int Shoe = 3;
            public const int Treasure = 5;
            public const int Unknown = 0;
            public const int Weapon = 1;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<EquipmentConfig._Type>.RegisterType("Weapon", 1, "EquipType_Weapon");
                flag &= TypeNameContainer<EquipmentConfig._Type>.RegisterType("Armor", 2, "EquipType_Armor");
                flag &= TypeNameContainer<EquipmentConfig._Type>.RegisterType("Shoe", 3, "EquipType_Shoe");
                flag &= TypeNameContainer<EquipmentConfig._Type>.RegisterType("Decoration", 4, "EquipType_Decoration");
                flag &= TypeNameContainer<EquipmentConfig._Type>.RegisterType("Treasure", 5, "EquipType_Treasure");
                return (flag & TypeNameContainer<EquipmentConfig._Type>.RegisterType("AllEquipType", -1));
            }
        }

        public class _WeaponType : TypeNameContainer<EquipmentConfig._WeaponType>
        {
            public const int Dart = 3;
            public const int DualWield = 4;
            public const int Empty = 0;
            public const int Heavy = 2;
            public const int Light = 1;

            public static bool Initialize()
            {
                bool flag = true;
                TypeNameContainer<EquipmentConfig._WeaponType>.SetTextSectionName("Code_WeaponType");
                flag &= TypeNameContainer<EquipmentConfig._WeaponType>.RegisterType("Empty", 0, "WeaponType_Empty");
                flag &= TypeNameContainer<EquipmentConfig._WeaponType>.RegisterType("Light", 1, "WeaponType_Light");
                flag &= TypeNameContainer<EquipmentConfig._WeaponType>.RegisterType("Heavy", 2, "WeaponType_Heavy");
                flag &= TypeNameContainer<EquipmentConfig._WeaponType>.RegisterType("Dart", 3, "WeaponType_Dart");
                return (flag & TypeNameContainer<EquipmentConfig._WeaponType>.RegisterType("DualWield", 4, "WeaponType_DualWield"));
            }

            public static bool IsMeleeWeapon(int type)
            {
                return (type != 3);
            }
        }

        [ProtoContract(Name="EquipBreakthrough")]
        public class EquipBreakthrough : IExtensible
        {
            private readonly List<GrowthAttribute> _baseGrowthAttributes = new List<GrowthAttribute>();
            private Breakthrough _breakThrough;
            private bool _canGetSellItemGeneralRewards;
            private PowerAttribute _powerAttributes;
            private readonly List<Reward> _sellRewards = new List<Reward>();
            private Cost _upgradeRequirementAddtionalCost;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, Name="baseGrowthAttributes", DataFormat=DataFormat.Default)]
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

            [DefaultValue(false), ProtoMember(6, IsRequired=false, Name="canGetSellItemGeneralRewards", DataFormat=DataFormat.Default)]
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

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="powerAttributes", DataFormat=DataFormat.Default)]
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

            [ProtoMember(3, Name="sellRewards", DataFormat=DataFormat.Default)]
            public List<Reward> sellRewards
            {
                get
                {
                    return this._sellRewards;
                }
            }

            [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="upgradeRequirementAddtionalCost", DataFormat=DataFormat.Default)]
            public Cost upgradeRequirementAddtionalCost
            {
                get
                {
                    return this._upgradeRequirementAddtionalCost;
                }
                set
                {
                    this._upgradeRequirementAddtionalCost = value;
                }
            }
        }

        [ProtoContract(Name="Equipment")]
        public class Equipment : IExtensible
        {
            private string _activeableAssembleDesc = "";
            private readonly List<EquipmentConfig.EquipBreakthrough> _equipBreakthroughs = new List<EquipmentConfig.EquipBreakthrough>();
            private readonly List<GetWay> _getways = new List<GetWay>();
            private int _id;
            private int _qualityLevel;
            private int _sortIndex;
            private int _type;
            private int _weaponType;
            private IExtension extensionObject;

            public EquipmentConfig.EquipBreakthrough GetBreakthroughByTimes(int breakTimes)
            {
                foreach (EquipmentConfig.EquipBreakthrough breakthrough in this.equipBreakthroughs)
                {
                    if (breakthrough.breakThrough.fromTimes == breakTimes)
                    {
                        return breakthrough;
                    }
                }
                return null;
            }

            public int GetMaxBreakthoughtLevel()
            {
                int fromTimes = 0;
                foreach (EquipmentConfig.EquipBreakthrough breakthrough in this._equipBreakthroughs)
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

            [ProtoMember(0x15, IsRequired=false, Name="activeableAssembleDesc", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [ProtoMember(20, Name="equipBreakthroughs", DataFormat=DataFormat.Default)]
            public List<EquipmentConfig.EquipBreakthrough> equipBreakthroughs
            {
                get
                {
                    return this._equipBreakthroughs;
                }
            }

            [ProtoMember(0x16, Name="getways", DataFormat=DataFormat.Default)]
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

            [DefaultValue(0), ProtoMember(0x17, IsRequired=false, Name="sortIndex", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(5, IsRequired=false, Name="weaponType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int weaponType
            {
                get
                {
                    return this._weaponType;
                }
                set
                {
                    this._weaponType = value;
                }
            }
        }
    }
}

