namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="DanConfig")]
    public class DanConfig : Configuration, IExtensible
    {
        private readonly List<AttributeRefreshCost> _attributeRefreshCosts = new List<AttributeRefreshCost>();
        private readonly List<string> _danAttrInfos = new List<string>();
        private readonly List<DanHelpInfo> _danHelpInfos = new List<DanHelpInfo>();
        private readonly List<DanIcon> _danIcons = new List<DanIcon>();
        private readonly List<Dan> _dans = new List<Dan>();
        private int _maxBreakthought;
        private int _maxLevel;
        private IExtension extensionObject;

        public Dan GetDanById(int id)
        {
            foreach (Dan dan in this._dans)
            {
                if (dan.ResourseId == id)
                {
                    return dan;
                }
            }
            return null;
        }

        public DanHelpInfo GetDanHelpByInfoType(int infoType)
        {
            foreach (DanHelpInfo info in this._danHelpInfos)
            {
                if (info.InfoTpye == infoType)
                {
                    return info;
                }
            }
            return null;
        }

        public DanIcon GetDanIconByIconId(int id)
        {
            foreach (DanIcon icon in this._danIcons)
            {
                if (icon.IconId == id)
                {
                    return icon;
                }
            }
            return null;
        }

        public DanIcon GetDanIconByResourseIdAndBreakLevel(int resourcesId, int breakLevel)
        {
            foreach (DanIcon icon in this._danIcons)
            {
                if ((icon.ResourseId == resourcesId) && (icon.Breakthought == breakLevel))
                {
                    return icon;
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
            _IntroduceType.Initialize();
            _OperateType.Initialize();
            _ActivityType.Initialize();
            _UpgradeType.Initialize();
            _LockType.Initialize();
            _DecomposeType.Initialize();
            _ResultType.Initialize();
            _DanType.Initialize();
            _ActivityDetailType.Initialize();
            _Type.Initialize();
            _DanFuncType.Initialize();
            _DanFuncParam.Initialize();
        }

        private AttributeRefreshCost LoadAttributeRefreshCostFromXml(SecurityElement element)
        {
            AttributeRefreshCost cost = new AttributeRefreshCost {
                Breakthought = StrParser.ParseDecInt(element.Attribute("Breakthought"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "MoneyCost")
                        {
                            cost.MoneyCost = Cost.LoadFromXml(element2);
                        }
                        else if (tag == "Cost")
                        {
                            goto Label_0073;
                        }
                    }
                    continue;
                Label_0073:
                    cost.Costs.Add(Cost.LoadFromXml(element2));
                }
            }
            return cost;
        }

        private void LoadAttributeRefreshCostSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "AttributeRefreshCost"))
                    {
                        this.AttributeRefreshCosts.Add(this.LoadAttributeRefreshCostFromXml(element2));
                    }
                }
            }
        }

        private BreakthoughtDetial LoadBreakthoughtDetialFromXml(SecurityElement element)
        {
            BreakthoughtDetial detial = new BreakthoughtDetial {
                LevelBefore = StrParser.ParseDecInt(element.Attribute("LevelBefore"), 0),
                BreakthoughtResultDesc = StrParser.ParseStr(element.Attribute("BreakthoughtResultDesc"), string.Empty)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                }
            }
            return detial;
        }

        private BreakthoughtInfo LoadBreakthoughtInfoFromXml(SecurityElement element)
        {
            BreakthoughtInfo info = new BreakthoughtInfo {
                Breakthought = StrParser.ParseDecInt(element.Attribute("Breakthought"), 0),
                MinLevel = StrParser.ParseDecInt(element.Attribute("MinLevel"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "MoneyCost")
                        {
                            if (tag == "Cost")
                            {
                                goto Label_009A;
                            }
                            if (tag == "BreakthoughtDetial")
                            {
                                goto Label_00AD;
                            }
                        }
                        else
                        {
                            info.MoneyCost = Cost.LoadFromXml(element2);
                        }
                    }
                    continue;
                Label_009A:
                    info.Costs.Add(Cost.LoadFromXml(element2));
                    continue;
                Label_00AD:
                    info.BreakthoughtDetials.Add(this.LoadBreakthoughtDetialFromXml(element2));
                }
            }
            return info;
        }

        private void LoadDanAttrInfosFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "DanAttribute"))
                    {
                        this.DanAttrInfos.Add(StrParser.ParseStr(element2.Attribute("attrInfos"), ""));
                    }
                }
            }
        }

        private Dan LoadDanFromXml(SecurityElement element)
        {
            Dan dan = new Dan {
                ResourseId = StrParser.ParseHexInt(element.Attribute("ResourseId"), 0),
                Type = TypeNameContainer<_DanType>.Parse(element.Attribute("Type"), 0),
                Name = StrParser.ParseStr(element.Attribute("Name"), string.Empty)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "LevelInfo")
                        {
                            dan.LevelInfos.Add(this.LoadLevelInfoFromXml(element2));
                        }
                        else if (tag == "BreakthoughtInfo")
                        {
                            goto Label_00AE;
                        }
                    }
                    continue;
                Label_00AE:
                    dan.BreakthoughtInfos.Add(this.LoadBreakthoughtInfoFromXml(element2));
                }
            }
            return dan;
        }

        private DanHelpInfo LoadDanHelapFromXml(SecurityElement element)
        {
            return new DanHelpInfo { 
                InfoTpye = TypeNameContainer<_IntroduceType>.Parse(element.Attribute("InfoType"), 0),
                IconId = StrParser.ParseHexInt(element.Attribute("iconId"), 0),
                Name = StrParser.ParseStr(element.Attribute("Name"), ""),
                Desc = StrParser.ParseStr(element.Attribute("Desc"), "", true)
            };
        }

        private void LoadDanHelapSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "AlchemyActivity"))
                    {
                        this.DanHelpInfos.Add(this.LoadDanHelapFromXml(element2));
                    }
                }
            }
        }

        private DanIcon LoadDanIconFromXml(SecurityElement element)
        {
            return new DanIcon { 
                ResourseId = StrParser.ParseHexInt(element.Attribute("ResourseId"), 0),
                IconId = StrParser.ParseHexInt(element.Attribute("IconId"), 0),
                Breakthought = StrParser.ParseDecInt(element.Attribute("Breakthought"), 0)
            };
        }

        private void LoadDanIconSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "DanIcon"))
                    {
                        this.DanIcons.Add(this.LoadDanIconFromXml(element2));
                    }
                }
            }
        }

        private void LoadDanSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Dan"))
                    {
                        this.Dans.Add(this.LoadDanFromXml(element2));
                    }
                }
            }
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "DanConfig") && (element.Children != null))
            {
                this._maxLevel = StrParser.ParseDecInt(element.Attribute("MaxLevel"), 0);
                this._maxBreakthought = StrParser.ParseDecInt(element.Attribute("MaxBreakthought"), 0);
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "DanSet")
                        {
                            if (tag == "DanIconSet")
                            {
                                goto Label_00BF;
                            }
                            if (tag == "DanHelapSet")
                            {
                                goto Label_00C8;
                            }
                            if (tag == "DanAttrSet")
                            {
                                goto Label_00D1;
                            }
                            if (tag == "AttributeRefreshCostSet")
                            {
                                goto Label_00DA;
                            }
                        }
                        else
                        {
                            this.LoadDanSetFromXml(element2);
                        }
                    }
                    continue;
                Label_00BF:
                    this.LoadDanIconSetFromXml(element2);
                    continue;
                Label_00C8:
                    this.LoadDanHelapSetFromXml(element2);
                    continue;
                Label_00D1:
                    this.LoadDanAttrInfosFromXml(element2);
                    continue;
                Label_00DA:
                    this.LoadAttributeRefreshCostSetFromXml(element2);
                }
            }
        }

        private LevelInfo LoadLevelInfoFromXml(SecurityElement element)
        {
            LevelInfo info = new LevelInfo {
                Breakthought = StrParser.ParseDecInt(element.Attribute("Breakthought"), 0),
                Level = StrParser.ParseDecInt(element.Attribute("Level"), 0),
                LevelUpResultDesc = StrParser.ParseStr(element.Attribute("LevelUpResultDesc"), string.Empty)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "MoneyCost")
                        {
                            info.MoneyCost = Cost.LoadFromXml(element2);
                        }
                        else if (tag == "Cost")
                        {
                            goto Label_00A5;
                        }
                    }
                    continue;
                Label_00A5:
                    info.Costs.Add(Cost.LoadFromXml(element2));
                }
            }
            return info;
        }

        [ProtoMember(5, Name="attributeRefreshCosts", DataFormat=DataFormat.Default)]
        public List<AttributeRefreshCost> AttributeRefreshCosts
        {
            get
            {
                return this._attributeRefreshCosts;
            }
        }

        [ProtoMember(4, Name="danAttrInfos", DataFormat=DataFormat.Default)]
        public List<string> DanAttrInfos
        {
            get
            {
                return this._danAttrInfos;
            }
        }

        [ProtoMember(3, Name="danHelpInfos", DataFormat=DataFormat.Default)]
        public List<DanHelpInfo> DanHelpInfos
        {
            get
            {
                return this._danHelpInfos;
            }
        }

        [ProtoMember(2, Name="danIcons", DataFormat=DataFormat.Default)]
        public List<DanIcon> DanIcons
        {
            get
            {
                return this._danIcons;
            }
        }

        [ProtoMember(1, Name="dans", DataFormat=DataFormat.Default)]
        public List<Dan> Dans
        {
            get
            {
                return this._dans;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="maxBreakthought", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="maxLevel", DataFormat=DataFormat.TwosComplement)]
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

        public class _ActivityDetailType : TypeNameContainer<DanConfig._ActivityDetailType>
        {
            public const int Box = 2;
            public const int DecomposeCount = 3;
            public const int DecomposePosibility = 5;
            public const int DecomposeResult = 4;
            public const int SpecialDan = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DanConfig._ActivityDetailType>.RegisterType("SpecialDan", 1, "SpecialDan");
                flag &= TypeNameContainer<DanConfig._ActivityDetailType>.RegisterType("Box", 2, "Box");
                flag &= TypeNameContainer<DanConfig._ActivityDetailType>.RegisterType("DecomposeCount", 3, "DecomposeCount");
                flag &= TypeNameContainer<DanConfig._ActivityDetailType>.RegisterType("DecomposeResult", 4, "DecomposeResult");
                return (flag & TypeNameContainer<DanConfig._ActivityDetailType>.RegisterType("DecomposePosibility", 5, "DecomposePosibility"));
            }
        }

        public class _ActivityType : TypeNameContainer<DanConfig._ActivityType>
        {
            public const int Alchemy = 1;
            public const int Decompose = 2;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DanConfig._ActivityType>.RegisterType("Alchemy", 1, "Alchemy");
                return (flag & TypeNameContainer<DanConfig._ActivityType>.RegisterType("Decompose", 2, "Decompose"));
            }
        }

        public class _DanFuncParam : TypeNameContainer<DanConfig._DanFuncParam>
        {
            public const int AllDmg = 4;
            public const int CompositeSkillRate = 12;
            public const int CounterDmg = 3;
            public const int CounterRate = 10;
            public const int CriticalDmg = 2;
            public const int CtrlRate = 11;
            public const int Damage = 1;
            public const int DmgHealByAP = 0x15;
            public const int DmgHealByDmg = 20;
            public const int DmgHealByMaxHP = 0x16;
            public const int Invalid = 0;

            public static bool Initialize()
            {
                TypeNameContainer<DanConfig._DanFuncParam>.RegisterType("Damage", 1);
                TypeNameContainer<DanConfig._DanFuncParam>.RegisterType("CriticalDmg", 2);
                TypeNameContainer<DanConfig._DanFuncParam>.RegisterType("CounterDmg", 3);
                TypeNameContainer<DanConfig._DanFuncParam>.RegisterType("AllDmg", 4);
                TypeNameContainer<DanConfig._DanFuncParam>.RegisterType("CounterRate", 10);
                TypeNameContainer<DanConfig._DanFuncParam>.RegisterType("CtrlRate", 11);
                TypeNameContainer<DanConfig._DanFuncParam>.RegisterType("CompositeSkillRate", 12);
                TypeNameContainer<DanConfig._DanFuncParam>.RegisterType("DmgHealByDmg", 20);
                TypeNameContainer<DanConfig._DanFuncParam>.RegisterType("DmgHealByAP", 0x15);
                TypeNameContainer<DanConfig._DanFuncParam>.RegisterType("DmgHealByMaxHP", 0x16);
                return false;
            }
        }

        public class _DanFuncType : TypeNameContainer<DanConfig._DanFuncType>
        {
            public const int AttributeModifyAfterInit_P = 7;
            public const int AttributeModifyAfterInit_V = 8;
            public const int AttributeModifyInBattle_P = 11;
            public const int AttributeModifyInBattle_V = 12;
            public const int DamageHeal = 10;
            public const int DamageModify = 1;
            public const int DamageModify_Defense = 2;
            public const int EquipStrengthen = 9;
            public const int HealModify = 3;
            public const int TriggerRate = 5;
            public const int TriggerRate_Defense = 6;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DanConfig._DanFuncType>.RegisterType("DamageModify", 1);
                flag &= TypeNameContainer<DanConfig._DanFuncType>.RegisterType("DamageModify_Defense", 2);
                flag &= TypeNameContainer<DanConfig._DanFuncType>.RegisterType("HealModify", 3);
                flag &= TypeNameContainer<DanConfig._DanFuncType>.RegisterType("TriggerRate", 5);
                flag &= TypeNameContainer<DanConfig._DanFuncType>.RegisterType("TriggerRate_Defense", 6);
                flag &= TypeNameContainer<DanConfig._DanFuncType>.RegisterType("AttributeModifyAfterInit_P", 7);
                flag &= TypeNameContainer<DanConfig._DanFuncType>.RegisterType("AttributeModifyAfterInit_V", 8);
                flag &= TypeNameContainer<DanConfig._DanFuncType>.RegisterType("EquipStrengthen", 9);
                flag &= TypeNameContainer<DanConfig._DanFuncType>.RegisterType("DamageHeal", 10);
                flag &= TypeNameContainer<DanConfig._DanFuncType>.RegisterType("AttributeModifyInBattle_P", 11);
                return (flag & TypeNameContainer<DanConfig._DanFuncType>.RegisterType("AttributeModifyInBattle_V", 12));
            }
        }

        public class _DanType : TypeNameContainer<DanConfig._DanType>
        {
            public const int Earth = 2;
            public const int Ghost = 4;
            public const int God = 5;
            public const int Human = 3;
            public const int Sky = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DanConfig._DanType>.RegisterType("Sky", 1, "Dan_Type_Sky");
                flag &= TypeNameContainer<DanConfig._DanType>.RegisterType("Earth", 2, "Dan_Type_Earth");
                flag &= TypeNameContainer<DanConfig._DanType>.RegisterType("Human", 3, "Dan_Type_Human");
                flag &= TypeNameContainer<DanConfig._DanType>.RegisterType("Ghost", 4, "Dan_Type_Ghost");
                return (flag & TypeNameContainer<DanConfig._DanType>.RegisterType("God", 5, "Dan_Type_God"));
            }
        }

        public class _DecomposeType : TypeNameContainer<DanConfig._DecomposeType>
        {
            public const int Charge = 2;
            public const int Free = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DanConfig._DecomposeType>.RegisterType("Free", 1, "Free");
                return (flag & TypeNameContainer<DanConfig._DecomposeType>.RegisterType("Charge", 2, "Charge"));
            }
        }

        public class _IntroduceType : TypeNameContainer<DanConfig._IntroduceType>
        {
            public const int DanAttic = 3;
            public const int DanAttri = 10;
            public const int DanBreakUp = 8;
            public const int DanDecompose = 4;
            public const int DanEquip = 6;
            public const int DanFurnace = 2;
            public const int DanIntroduce = 1;
            public const int DanLevelUp = 7;
            public const int DanMaterial = 5;
            public const int DanWish = 9;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DanConfig._IntroduceType>.RegisterType("DanIntroduce", 1, "DanIntroduce");
                flag &= TypeNameContainer<DanConfig._IntroduceType>.RegisterType("DanFurnace", 2, "DanFurnace");
                flag &= TypeNameContainer<DanConfig._IntroduceType>.RegisterType("DanAttic", 3, "DanAttic");
                flag &= TypeNameContainer<DanConfig._IntroduceType>.RegisterType("DanDecompose", 4, "DanDecompose");
                flag &= TypeNameContainer<DanConfig._IntroduceType>.RegisterType("DanMaterial", 5, "DanMaterial");
                flag &= TypeNameContainer<DanConfig._IntroduceType>.RegisterType("DanEquip", 6, "DanEquip");
                flag &= TypeNameContainer<DanConfig._IntroduceType>.RegisterType("DanLevelUp", 7, "DanLevelUp");
                flag &= TypeNameContainer<DanConfig._IntroduceType>.RegisterType("DanBreakUp", 8, "DanBreakUp");
                flag &= TypeNameContainer<DanConfig._IntroduceType>.RegisterType("DanWish", 9, "DanWish");
                return (flag & TypeNameContainer<DanConfig._IntroduceType>.RegisterType("DanAttri", 10, "DanAttri"));
            }
        }

        public class _LockType : TypeNameContainer<DanConfig._LockType>
        {
            public const int Locked = 1;
            public const int Unknow = 0;
            public const int Unlock = 2;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DanConfig._LockType>.RegisterType("Locked", 1, "Locked");
                return (flag & TypeNameContainer<DanConfig._LockType>.RegisterType("Unlock", 2, "Unlock"));
            }
        }

        public class _OperateType : TypeNameContainer<DanConfig._OperateType>
        {
            public const int Alchemy = 1;
            public const int BatchAlchemy = 2;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DanConfig._OperateType>.RegisterType("Alchemy", 1, "Alchemy");
                return (flag & TypeNameContainer<DanConfig._OperateType>.RegisterType("BatchAlchemy", 2, "BatchAlchemy"));
            }
        }

        public class _ResultType : TypeNameContainer<DanConfig._ResultType>
        {
            public const int Failed = 1;
            public const int SucceedAndDemotion = 2;
            public const int SucceedNotDemotion = 3;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DanConfig._ResultType>.RegisterType("Failed", 1, "Failed");
                flag &= TypeNameContainer<DanConfig._ResultType>.RegisterType("SucceedAndDemotion", 2, "SucceedAndDemotion");
                return (flag & TypeNameContainer<DanConfig._ResultType>.RegisterType("SucceedNotDemotion", 3, "SucceedNotDemotion"));
            }
        }

        public class _Type : TypeNameContainer<DanConfig._Type>
        {
            public const int Dan = 0;
            public const int Icon = 0x90;

            public static bool Initialize()
            {
                bool flag = false;
                TypeNameContainer<DanConfig._Type>.SetTextSectionName("DanType");
                flag &= TypeNameContainer<DanConfig._Type>.RegisterType("Dan", 0, "Dan");
                return (flag & TypeNameContainer<DanConfig._Type>.RegisterType("Icon", 0x90, "Icon"));
            }

            public static int ToItemType(int id)
            {
                return ((id & 0xff0000) >> 0x10);
            }
        }

        public class _UpgradeType : TypeNameContainer<DanConfig._UpgradeType>
        {
            public const int AttributeRefresh = 3;
            public const int BreakThought = 2;
            public const int LevelUp = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DanConfig._UpgradeType>.RegisterType("LevelUp", 1, "LevelUp");
                flag &= TypeNameContainer<DanConfig._UpgradeType>.RegisterType("BreakThought", 2, "BreakThought");
                return (flag & TypeNameContainer<DanConfig._UpgradeType>.RegisterType("AttributeRefresh", 3, "AttributeRefresh"));
            }
        }

        [ProtoContract(Name="AttributeRefreshCost")]
        public class AttributeRefreshCost : IExtensible
        {
            private int _breakthought;
            private readonly List<Cost> _costs = new List<Cost>();
            private Cost _moneyCost;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="breakthought", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(2, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> Costs
            {
                get
                {
                    return this._costs;
                }
            }

            [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="moneyCost", DataFormat=DataFormat.Default)]
            public Cost MoneyCost
            {
                get
                {
                    return this._moneyCost;
                }
                set
                {
                    this._moneyCost = value;
                }
            }
        }

        [ProtoContract(Name="BreakthoughtDetial")]
        public class BreakthoughtDetial : IExtensible
        {
            private string _breakthoughtResultDesc = "";
            private int _levelBefore;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="breakthoughtResultDesc", DataFormat=DataFormat.Default)]
            public string BreakthoughtResultDesc
            {
                get
                {
                    return this._breakthoughtResultDesc;
                }
                set
                {
                    this._breakthoughtResultDesc = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="levelBefore", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int LevelBefore
            {
                get
                {
                    return this._levelBefore;
                }
                set
                {
                    this._levelBefore = value;
                }
            }
        }

        [ProtoContract(Name="BreakthoughtInfo")]
        public class BreakthoughtInfo : IExtensible
        {
            private int _breakthought;
            private readonly List<DanConfig.BreakthoughtDetial> _breakthoughtDetials = new List<DanConfig.BreakthoughtDetial>();
            private readonly List<Cost> _costs = new List<Cost>();
            private int _minLevel;
            private Cost _moneyCost;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="breakthought", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(5, Name="breakthoughtDetials", DataFormat=DataFormat.Default)]
            public List<DanConfig.BreakthoughtDetial> BreakthoughtDetials
            {
                get
                {
                    return this._breakthoughtDetials;
                }
            }

            [ProtoMember(4, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> Costs
            {
                get
                {
                    return this._costs;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="minLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MinLevel
            {
                get
                {
                    return this._minLevel;
                }
                set
                {
                    this._minLevel = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="moneyCost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public Cost MoneyCost
            {
                get
                {
                    return this._moneyCost;
                }
                set
                {
                    this._moneyCost = value;
                }
            }
        }

        [ProtoContract(Name="Dan")]
        public class Dan : IExtensible
        {
            private readonly List<DanConfig.BreakthoughtInfo> _breakthoughtInfos = new List<DanConfig.BreakthoughtInfo>();
            private readonly List<DanConfig.LevelInfo> _levelInfos = new List<DanConfig.LevelInfo>();
            private string _name = "";
            private int _resourseId;
            private int _type;
            private IExtension extensionObject;

            public DanConfig.BreakthoughtInfo GetBreakthoughtInfoByBreakthought(int breakthought)
            {
                foreach (DanConfig.BreakthoughtInfo info in this._breakthoughtInfos)
                {
                    if (info.Breakthought == breakthought)
                    {
                        return info;
                    }
                }
                return null;
            }

            public DanConfig.LevelInfo GetLevelInfoByBreakAndLevel(int breakthought, int level)
            {
                foreach (DanConfig.LevelInfo info in this._levelInfos)
                {
                    if ((info.Breakthought == breakthought) && (info.Level == level))
                    {
                        return info;
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, Name="breakthoughtInfos", DataFormat=DataFormat.Default)]
            public List<DanConfig.BreakthoughtInfo> BreakthoughtInfos
            {
                get
                {
                    return this._breakthoughtInfos;
                }
            }

            [ProtoMember(4, Name="levelInfos", DataFormat=DataFormat.Default)]
            public List<DanConfig.LevelInfo> LevelInfos
            {
                get
                {
                    return this._levelInfos;
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
        }

        [ProtoContract(Name="DanHelpInfo")]
        public class DanHelpInfo : IExtensible
        {
            private string _desc = "";
            private int _iconId;
            private int _infoTpye;
            private string _name = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="desc", DataFormat=DataFormat.Default)]
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

            [ProtoMember(1, IsRequired=false, Name="infoTpye", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int InfoTpye
            {
                get
                {
                    return this._infoTpye;
                }
                set
                {
                    this._infoTpye = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="name", DataFormat=DataFormat.Default), DefaultValue("")]
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
        }

        [ProtoContract(Name="DanIcon")]
        public class DanIcon : IExtensible
        {
            private int _breakthought;
            private int _iconId;
            private int _resourseId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="breakthought", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(1, IsRequired=false, Name="resourseId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoContract(Name="LevelInfo")]
        public class LevelInfo : IExtensible
        {
            private int _breakthought;
            private readonly List<Cost> _costs = new List<Cost>();
            private int _level;
            private string _levelUpResultDesc = "";
            private Cost _moneyCost;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="breakthought", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(4, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> Costs
            {
                get
                {
                    return this._costs;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="levelUpResultDesc", DataFormat=DataFormat.Default)]
            public string LevelUpResultDesc
            {
                get
                {
                    return this._levelUpResultDesc;
                }
                set
                {
                    this._levelUpResultDesc = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="moneyCost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public Cost MoneyCost
            {
                get
                {
                    return this._moneyCost;
                }
                set
                {
                    this._moneyCost = value;
                }
            }
        }
    }
}

