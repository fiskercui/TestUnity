namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="TavernConfig")]
    public class TavernConfig : Configuration, IExtensible
    {
        private readonly List<Tavern> _taverns = new List<Tavern>();
        private IExtension extensionObject;
        private Dictionary<int, Tavern> id_tavernMap = new Dictionary<int, Tavern>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Tavern tavern in this._taverns)
            {
                if (tavern != null)
                {
                    if (this.id_tavernMap.ContainsKey(tavern.Id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + tavern.Id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_tavernMap.Add(tavern.Id, tavern);
                    }
                }
            }
        }

        public Tavern GetTavernById(int id)
        {
            Tavern tavern = null;
            if (!this.id_tavernMap.TryGetValue(id, out tavern))
            {
                return null;
            }
            return tavern;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _TavernType.Initialize();
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "TavernConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Tavern"))
                    {
                        this._taverns.Add(this.LoadTavernFromXml(element2));
                    }
                }
            }
        }

        private Tavern LoadTavernFromXml(SecurityElement element)
        {
            Tavern tavern = new Tavern {
                Id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                RecruitStage = _TavernRecruitStage.ParseStage(element.Attribute("RecruitStage"), 0),
                RecruitDesc = StrParser.ParseStr(element.Attribute("RecruitDesc"), ""),
                RewardDesc = StrParser.ParseStr(element.Attribute("RewardDesc"), ""),
                Priority = StrParser.ParseDecInt(element.Attribute("Priority"), 0),
                Level = StrParser.ParseDecInt(element.Attribute("Level"), 0),
                VipLevel = StrParser.ParseDecInt(element.Attribute("VipLevel"), 0),
                CoolDownTime = StrParser.ParseDecInt(element.Attribute("CoolDownTime"), 0),
                QualityIconId = StrParser.ParseHexInt(element.Attribute("QualityIconId"), 0),
                CountyIconId = StrParser.ParseHexInt(element.Attribute("CountyIconId"), 0),
                BackGroundId = StrParser.ParseHexInt(element.Attribute("BackGroundId"), 0),
                IsOpen = StrParser.ParseBool(element.Attribute("IsOpen"), false),
                CanTenTavern = StrParser.ParseBool(element.Attribute("CanTenTavern"), false),
                NormalFirstDesc = StrParser.ParseStr(element.Attribute("NormalFirstDesc"), ""),
                TenTavernFristDesc = StrParser.ParseStr(element.Attribute("TenTavernFristDesc"), ""),
                SepicalRewardContext = StrParser.ParseStr(element.Attribute("SepicalRewardContext"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    switch (element2.Tag)
                    {
                        case "Cost":
                            tavern.Cost = Cost.LoadFromXml(element2);
                            break;

                        case "TenTavernCost":
                            tavern.TenTavernCost = Cost.LoadFromXml(element2);
                            break;

                        case "TenTavernOriginalCost":
                            tavern.TenTavernOriginalCost = Cost.LoadFromXml(element2);
                            break;

                        case "Reward":
                            tavern.Reward = Reward.LoadFromXml(element2);
                            break;

                        case "Reward1":
                            tavern.Reward1 = Reward.LoadFromXml(element2);
                            break;

                        case "TenTavernReward":
                            tavern.TenTavernReward = Reward.LoadFromXml(element2);
                            break;

                        case "TenTavernReward1":
                            tavern.TenTavernReward1 = Reward.LoadFromXml(element2);
                            break;

                        case "ShowResourceId":
                            tavern.ShowResourceIds.Add(StrParser.ParseHexInt(element2.Attribute("Id"), 0));
                            break;

                        case "SepicalRewardId":
                            tavern.SepicalRewardId.Add(StrParser.ParseHexInt(element2.Attribute("Id"), 0));
                            break;
                    }
                }
            }
            return tavern;
        }

        [ProtoMember(1, Name="taverns", DataFormat=DataFormat.Default)]
        public List<Tavern> Taverns
        {
            get
            {
                return this._taverns;
            }
        }

        public class _TavernType : TypeNameContainer<TavernConfig._TavernType>
        {
            public const int NormalTavern = 1;
            public const int TenTavern = 2;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TavernConfig._TavernType>.RegisterType("NormalTavern", 1);
                return (flag & TypeNameContainer<TavernConfig._TavernType>.RegisterType("TenTavern", 2));
            }
        }

        [ProtoContract(Name="Tavern")]
        public class Tavern : IExtensible
        {
            private int _backGroundId;
            private bool _canTenTavern;
            private int _coolDownTime;
            private ClientServerCommon.Cost _cost;
            private int _countyIconId;
            private int _freeCardGroupId;
            private int _freeFirstCardGroupId;
            private int _id;
            private bool _isOpen;
            private int _level;
            private int _normalFirstCardGroupId;
            private string _normalFirstDesc = "";
            private int _priority;
            private int _qualityIconId;
            private string _recruitDesc = "";
            private int _recruitId;
            private int _recruitStage;
            private ClientServerCommon.Reward _reward;
            private ClientServerCommon.Reward _reward1;
            private string _rewardDesc = "";
            private string _sepicalRewardContext = "";
            private readonly List<int> _sepicalRewardId = new List<int>();
            private readonly List<int> _showResourceIds = new List<int>();
            private ClientServerCommon.Cost _tenTavernCost;
            private string _tenTavernFristDesc = "";
            private ClientServerCommon.Cost _tenTavernOriginalCost;
            private ClientServerCommon.Reward _tenTavernReward;
            private ClientServerCommon.Reward _tenTavernReward1;
            private int _vipLevel;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(0x12, IsRequired=false, Name="backGroundId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int BackGroundId
            {
                get
                {
                    return this._backGroundId;
                }
                set
                {
                    this._backGroundId = value;
                }
            }

            [DefaultValue(false), ProtoMember(20, IsRequired=false, Name="canTenTavern", DataFormat=DataFormat.Default)]
            public bool CanTenTavern
            {
                get
                {
                    return this._canTenTavern;
                }
                set
                {
                    this._canTenTavern = value;
                }
            }

            [ProtoMember(13, IsRequired=false, Name="coolDownTime", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CoolDownTime
            {
                get
                {
                    return this._coolDownTime;
                }
                set
                {
                    this._coolDownTime = value;
                }
            }

            [ProtoMember(14, IsRequired=false, Name="cost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public ClientServerCommon.Cost Cost
            {
                get
                {
                    return this._cost;
                }
                set
                {
                    this._cost = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x10, IsRequired=false, Name="countyIconId", DataFormat=DataFormat.TwosComplement)]
            public int CountyIconId
            {
                get
                {
                    return this._countyIconId;
                }
                set
                {
                    this._countyIconId = value;
                }
            }

            [DefaultValue(0), ProtoMember(10, IsRequired=false, Name="freeCardGroupId", DataFormat=DataFormat.TwosComplement)]
            public int FreeCardGroupId
            {
                get
                {
                    return this._freeCardGroupId;
                }
                set
                {
                    this._freeCardGroupId = value;
                }
            }

            [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="freeFirstCardGroupId", DataFormat=DataFormat.TwosComplement)]
            public int FreeFirstCardGroupId
            {
                get
                {
                    return this._freeFirstCardGroupId;
                }
                set
                {
                    this._freeFirstCardGroupId = value;
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

            [ProtoMember(0x13, IsRequired=false, Name="isOpen", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool IsOpen
            {
                get
                {
                    return this._isOpen;
                }
                set
                {
                    this._isOpen = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="normalFirstCardGroupId", DataFormat=DataFormat.TwosComplement)]
            public int NormalFirstCardGroupId
            {
                get
                {
                    return this._normalFirstCardGroupId;
                }
                set
                {
                    this._normalFirstCardGroupId = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="normalFirstDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string NormalFirstDesc
            {
                get
                {
                    return this._normalFirstDesc;
                }
                set
                {
                    this._normalFirstDesc = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="priority", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(0x11, IsRequired=false, Name="qualityIconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int QualityIconId
            {
                get
                {
                    return this._qualityIconId;
                }
                set
                {
                    this._qualityIconId = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="recruitDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string RecruitDesc
            {
                get
                {
                    return this._recruitDesc;
                }
                set
                {
                    this._recruitDesc = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="recruitId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int RecruitId
            {
                get
                {
                    return this._recruitId;
                }
                set
                {
                    this._recruitId = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x1b, IsRequired=false, Name="recruitStage", DataFormat=DataFormat.TwosComplement)]
            public int RecruitStage
            {
                get
                {
                    return this._recruitStage;
                }
                set
                {
                    this._recruitStage = value;
                }
            }

            [ProtoMember(11, IsRequired=false, Name="reward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public ClientServerCommon.Reward Reward
            {
                get
                {
                    return this._reward;
                }
                set
                {
                    this._reward = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(0x1c, IsRequired=false, Name="reward1", DataFormat=DataFormat.Default)]
            public ClientServerCommon.Reward Reward1
            {
                get
                {
                    return this._reward1;
                }
                set
                {
                    this._reward1 = value;
                }
            }

            [ProtoMember(12, IsRequired=false, Name="rewardDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string RewardDesc
            {
                get
                {
                    return this._rewardDesc;
                }
                set
                {
                    this._rewardDesc = value;
                }
            }

            [DefaultValue(""), ProtoMember(0x1a, IsRequired=false, Name="sepicalRewardContext", DataFormat=DataFormat.Default)]
            public string SepicalRewardContext
            {
                get
                {
                    return this._sepicalRewardContext;
                }
                set
                {
                    this._sepicalRewardContext = value;
                }
            }

            [ProtoMember(0x19, Name="sepicalRewardId", DataFormat=DataFormat.TwosComplement)]
            public List<int> SepicalRewardId
            {
                get
                {
                    return this._sepicalRewardId;
                }
            }

            [ProtoMember(15, Name="showResourceIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> ShowResourceIds
            {
                get
                {
                    return this._showResourceIds;
                }
            }

            [DefaultValue((string) null), ProtoMember(0x15, IsRequired=false, Name="tenTavernCost", DataFormat=DataFormat.Default)]
            public ClientServerCommon.Cost TenTavernCost
            {
                get
                {
                    return this._tenTavernCost;
                }
                set
                {
                    this._tenTavernCost = value;
                }
            }

            [ProtoMember(0x18, IsRequired=false, Name="tenTavernFristDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string TenTavernFristDesc
            {
                get
                {
                    return this._tenTavernFristDesc;
                }
                set
                {
                    this._tenTavernFristDesc = value;
                }
            }

            [ProtoMember(0x16, IsRequired=false, Name="tenTavernOriginalCost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public ClientServerCommon.Cost TenTavernOriginalCost
            {
                get
                {
                    return this._tenTavernOriginalCost;
                }
                set
                {
                    this._tenTavernOriginalCost = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(0x17, IsRequired=false, Name="tenTavernReward", DataFormat=DataFormat.Default)]
            public ClientServerCommon.Reward TenTavernReward
            {
                get
                {
                    return this._tenTavernReward;
                }
                set
                {
                    this._tenTavernReward = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(0x1d, IsRequired=false, Name="tenTavernReward1", DataFormat=DataFormat.Default)]
            public ClientServerCommon.Reward TenTavernReward1
            {
                get
                {
                    return this._tenTavernReward1;
                }
                set
                {
                    this._tenTavernReward1 = value;
                }
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement)]
            public int VipLevel
            {
                get
                {
                    return this._vipLevel;
                }
                set
                {
                    this._vipLevel = value;
                }
            }
        }
    }
}

