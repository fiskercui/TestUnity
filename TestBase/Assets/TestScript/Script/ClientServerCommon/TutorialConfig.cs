namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="TutorialConfig")]
    public class TutorialConfig : Configuration, IExtensible
    {
        private CampaignGuid _campaignGuid;
        private CombatFailGuid _combatFailGuid;
        private int _tavernGuidID;
        private TutorialCombat _tutorialCombat;
        private readonly List<Tutorial> _tutorials = new List<Tutorial>();
        private IExtension extensionObject;
        private Dictionary<int, Tutorial> id_TutorialMap = new Dictionary<int, Tutorial>();

        public bool CompareConditionValue(Condition condition, bool value)
        {
            switch (condition.valueCompareType)
            {
                case 3:
                    return (condition.boolValue == value);

                case 6:
                    return (condition.boolValue != value);
            }
            return true;
        }

        public bool CompareConditionValue(Condition condition, int value)
        {
            switch (condition.valueCompareType)
            {
                case 1:
                    return (value < condition.intValue);

                case 2:
                    return (value <= condition.intValue);

                case 3:
                    return (value == condition.intValue);

                case 4:
                    return (value >= condition.intValue);

                case 5:
                    return (value > condition.intValue);

                case 6:
                    return (value != condition.intValue);
            }
            return false;
        }

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Tutorial tutorial in this._tutorials)
            {
                if (tutorial != null)
                {
                    foreach (Step step in tutorial.steps)
                    {
                        step.ConstructLogicData();
                    }
                    if (this.id_TutorialMap.ContainsKey(tutorial.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + tutorial.id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_TutorialMap.Add(tutorial.id, tutorial);
                    }
                }
            }
        }

        public Tutorial GetTutorialById(int id)
        {
            Tutorial tutorial;
            if (!this.id_TutorialMap.TryGetValue(id, out tutorial))
            {
                return null;
            }
            return tutorial;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _ActionType.Initialize();
            _ConditionType.Initialize();
            _Phase.Initialize();
            _ArrowRotation.Initialize();
            _NPCDirection.Initialize();
        }

        private void LoadCampaignGuidXml(SecurityElement element)
        {
            this._campaignGuid = new CampaignGuid();
            this._campaignGuid.playerLevel = StrParser.ParseDecInt(element.Attribute("PlayerLevel"), 0);
            this._campaignGuid.openTutorial = StrParser.ParseBool(element.Attribute("OpenTutorial"), false);
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "FirstCampaignRewardAction")
                        {
                            this._campaignGuid.firstCampaignRewardAction = Action.LoadActionFromXml(element2);
                        }
                        else if (tag == "CampaignUnLockAction")
                        {
                            goto Label_00A1;
                        }
                    }
                    continue;
                Label_00A1:
                    this._campaignGuid.campaignUnLockActions.Add(this.LoadCampaignUnLockSet(element2));
                }
            }
        }

        private CampaignUnLockAction LoadCampaignUnLockSet(SecurityElement element)
        {
            CampaignUnLockAction action = new CampaignUnLockAction {
                zoneId = StrParser.ParseHexInt(element.Attribute("ZoneID"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Action"))
                    {
                        action.action = Action.LoadActionFromXml(element2);
                    }
                }
            }
            return action;
        }

        private void LoadCombatFailAvatarGuidAction(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Action"))
                    {
                        Action item = Action.LoadActionFromXml(element2);
                        item.phase = StrParser.ParseBool(element2.Attribute("NewAvatar"), false) ? 1 : 0;
                        this._combatFailGuid.avatarGuids.Add(item);
                    }
                }
            }
        }

        private void LoadCombatFailEquipGuidAction(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Action"))
                    {
                        Action item = Action.LoadActionFromXml(element2);
                        item.phase = TypeNameContainer<EquipmentConfig._Type>.Parse(element2.Attribute("EquipType"), 0);
                        this._combatFailGuid.equipGuids.Add(item);
                    }
                }
            }
        }

        private void LoadCombatFailGuid(SecurityElement element)
        {
            this._combatFailGuid = new CombatFailGuid();
            this._combatFailGuid.openFuncPlayerLevel = StrParser.ParseDecInt(element.Attribute("OpenFuncPlayerLevel"), 0);
            this._combatFailGuid.particleCloseLevel = StrParser.ParseDecInt(element.Attribute("ParticleCloseLevel"), 0);
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "Avatar")
                        {
                            if (tag == "Equip")
                            {
                                goto Label_00A4;
                            }
                            if (tag == "Skill")
                            {
                                goto Label_00AD;
                            }
                        }
                        else
                        {
                            this.LoadCombatFailAvatarGuidAction(element2);
                        }
                    }
                    continue;
                Label_00A4:
                    this.LoadCombatFailEquipGuidAction(element2);
                    continue;
                Label_00AD:
                    this.LoadCombatFailSkillGuidAction(element2);
                }
            }
        }

        private void LoadCombatFailSkillGuidAction(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Action"))
                    {
                        Action item = Action.LoadActionFromXml(element2);
                        item.phase = StrParser.ParseDecInt(element2.Attribute("SkillIndex"), 0);
                        this._combatFailGuid.skillGuids.Add(item);
                    }
                }
            }
        }

        private Condition LoadConditionFromXml(SecurityElement element)
        {
            Condition condition = new Condition {
                phase = TypeNameContainer<_Phase>.Parse(element.Attribute("Phase"), 0),
                valueCompareType = TypeNameContainer<_ConditionValueCompareType>.Parse(element.Attribute("ValueCompareType"), 0),
                type = TypeNameContainer<_ConditionType>.Parse(element.Attribute("Type"), 0)
            };
            switch (condition.type)
            {
                case 1:
                case 2:
                case 10:
                case 11:
                    condition.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("UIComponentIndex"), 1);
                    condition.extraValue = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                    return condition;

                case 3:
                    condition.intValue = TypeNameContainer<_UIType>.Parse(element.Attribute("UIPanelName"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 4:
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("TutorialID"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 5:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    condition.intValue = TypeNameContainer<EquipmentConfig._Type>.Parse(element.Attribute("EquipmentType"), 0);
                    return condition;

                case 6:
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("PlayerLevel"), 1);
                    return condition;

                case 7:
                    condition.strValue = StrParser.ParseStr(element.Attribute("CurrentState"), "");
                    return condition;

                case 8:
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("AvatarLineUpCount"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 9:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 12:
                    condition.strValue = StrParser.ParseStr(element.Attribute("ScrollListName"), "");
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("ScrollListItemCount"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 13:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 14:
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("PveLevel"), 0);
                    condition.extraValue = StrParser.ParseBool(element.Attribute("PveSkipCombat"), false);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 15:
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("DailyQuestId"), 0);
                    condition.extraIntValue = TypeNameContainer<QuestConfig._PhaseType>.Parse(element.Attribute("DailyQuestParse"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 0x10:
                    condition.extraIntValue = StrParser.ParseHexInt(element.Attribute("CampaignZoneID"), 0);
                    condition.intValue = TypeNameContainer<_ZoneStatus>.Parse(element.Attribute("CampaignZoneState"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 0x11:
                    condition.strValue = TypeNameContainer<_ClientDynamicValueType>.GetNameByType(TypeNameContainer<_ClientDynamicValueType>.Parse(element.Attribute("ClientValueType"), 0));
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("ClientValue"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 0x12:
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("ActivityId"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 0x13:
                    condition.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    condition.iconStrValue = StrParser.ParseStr(element.Attribute("IconComponentName"), "");
                    return condition;

                case 20:
                    condition.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 0x15:
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("ZoneId"), 0);
                    condition.extraIntValue = StrParser.ParseDecInt(element.Attribute("StarRewardIndex"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x16:
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x17:
                    condition.strValue = StrParser.ParseStr(element.Attribute("ScrollListName"), "");
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0);
                    condition.extraValue = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                    return condition;

                case 0x18:
                    condition.strValue = StrParser.ParseStr(element.Attribute("ScrollListName"), "");
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x19:
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("ZoneId"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x1a:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    condition.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                    return condition;

                case 0x1b:
                    condition.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x1c:
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("Level"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x1d:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 30:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("ConsumableId"), 0);
                    return condition;

                case 0x1f:
                    condition.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("UIComponentIndex"), 1);
                    condition.extraValue = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                    return condition;

                case 0x20:
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("Count"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x21:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x22:
                    condition.strValue = StrParser.ParseStr(element.Attribute("GameStateName"), "");
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x23:
                    condition.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    condition.iconStrValue = StrParser.ParseStr(element.Attribute("AnimationName"), "");
                    return condition;

                case 0x24:
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("AvatarId"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x25:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    return condition;

                case 0x26:
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("DungeonId"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x27:
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("AvatarId"), 0);
                    condition.levelValue = TypeNameContainer<EquipmentConfig._Type>.Parse(element.Attribute("EquipmentType"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 40:
                    return condition;

                case 0x29:
                    condition.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), true);
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                    condition.extraValue = StrParser.ParseBool(element.Attribute("IsScrollItem"), true);
                    return condition;

                case 0x2a:
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x2b:
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("AvatarId"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x2c:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Open"), true);
                    return condition;

                case 0x2d:
                    condition.intValue = StrParser.ParseDecInt(element.Attribute("Index"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    return condition;

                case 0x2e:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                    condition.intValue = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                    return condition;
            }
            return condition;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "TutorialConfig")
            {
                this._tavernGuidID = StrParser.ParseHexInt(element.Attribute("TavernGuidID"), 0);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag != "Tutorial")
                            {
                                if (tag == "TutorialCombat")
                                {
                                    goto Label_0098;
                                }
                                if (tag == "CampaignGuid")
                                {
                                    goto Label_00A1;
                                }
                                if (tag == "CombatFailGuid")
                                {
                                    goto Label_00AA;
                                }
                            }
                            else
                            {
                                this.LoadTutorialFromXml(element2);
                            }
                        }
                        continue;
                    Label_0098:
                        this.LoadTutorialCombatFromXml(element2);
                        continue;
                    Label_00A1:
                        this.LoadCampaignGuidXml(element2);
                        continue;
                    Label_00AA:
                        this.LoadCombatFailGuid(element2);
                    }
                }
            }
        }

        private Step LoadStepFromXml(SecurityElement element)
        {
            Step step = new Step {
                skipWhenInaction = StrParser.ParseBool(element.Attribute("SkipWhenInaction"), false)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    Action action;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Condition")
                        {
                            Condition item = this.LoadConditionFromXml(element2);
                            if (item != null)
                            {
                                step.conditions.Add(item);
                            }
                        }
                        else if (tag == "Action")
                        {
                            goto Label_0086;
                        }
                    }
                    continue;
                Label_0086:
                    action = Action.LoadActionFromXml(element2);
                    if (action != null)
                    {
                        step.actions.Add(action);
                    }
                }
            }
            return step;
        }

        private void LoadTutorialCombatFromXml(SecurityElement element)
        {
            this._tutorialCombat = new TutorialCombat();
            this._tutorialCombat.speed = StrParser.ParseDecInt(element.Attribute("Speed"), 0);
            this._tutorialCombat.sceneId = StrParser.ParseHexInt(element.Attribute("SceneId"), 0);
        }

        private void LoadTutorialFromXml(SecurityElement element)
        {
            Tutorial item = new Tutorial {
                id = StrParser.ParseHexInt(element.Attribute("ID"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Step"))
                    {
                        Step step = this.LoadStepFromXml(element2);
                        if (step != null)
                        {
                            item.steps.Add(step);
                        }
                    }
                }
            }
            this._tutorials.Add(item);
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="campaignGuid", DataFormat=DataFormat.Default)]
        public CampaignGuid campaignGuid
        {
            get
            {
                return this._campaignGuid;
            }
            set
            {
                this._campaignGuid = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="combatFailGuid", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public CombatFailGuid combatFailGuid
        {
            get
            {
                return this._combatFailGuid;
            }
            set
            {
                this._combatFailGuid = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="tavernGuidID", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int tavernGuidID
        {
            get
            {
                return this._tavernGuidID;
            }
            set
            {
                this._tavernGuidID = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="tutorialCombat", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public TutorialCombat tutorialCombat
        {
            get
            {
                return this._tutorialCombat;
            }
            set
            {
                this._tutorialCombat = value;
            }
        }

        [ProtoMember(1, Name="tutorials", DataFormat=DataFormat.Default)]
        public List<Tutorial> tutorials
        {
            get
            {
                return this._tutorials;
            }
        }

        public class _ActionType : TypeNameContainer<TutorialConfig._ActionType>
        {
            public const int AddDragDelegate = 12;
            public const int AddParticle = 0x1b;
            public const int AddPtrListener = 0x21;
            public const int ChangeGameState = 5;
            public const int HighestQualityLevel = 20;
            public const int LockUIInput = 3;
            public const int LockUIInputArena = 0x19;
            public const int LockUIInputByHighestLevel = 0x16;
            public const int LockUIInputByQualityLevel = 0x10;
            public const int LockUIInputByStartServerReward = 0x11;
            public const int LockUIIputQualityLevel = 0x1d;
            public const int MarkQuestFinished = 4;
            public const int MoveCamera = 0x17;
            public const int PlayBattle = 0x20;
            public const int RemoveClientDynamicValue = 9;
            public const int RemoveParticle = 0x1f;
            public const int SceneScrollToItem = 15;
            public const int ScrollListEnableTouch = 10;
            public const int ScrollToItem = 7;
            public const int ScrollToItemArena = 0x1a;
            public const int ScrollToItemByStartServerReward = 0x13;
            public const int SetClientDynamicValue = 8;
            public const int SetScrollState = 30;
            public const int ShowAdviserTip = 6;
            public const int ShowDlgMessageForShowUI = 11;
            public const int ShowDragAnimation = 13;
            public const int ShowPanel = 1;
            public const int ShowTip = 2;
            public const int ShowTipArena = 0x18;
            public const int ShowTipByHighestLevel = 0x15;
            public const int ShowTipByStartServerReward = 0x12;
            public const int ShowTipQualityLevel = 0x1c;
            public const int ShowTutorialReward = 14;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ShowPanel", 1);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ShowTip", 2);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("LockUIInput", 3);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("MarkQuestFinished", 4);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ChangeGameState", 5);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ShowAdviserTip", 6);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ScrollToItem", 7);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("SetClientDynamicValue", 8);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("RemoveClientDynamicValue", 9);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ScrollListEnableTouch", 10);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ShowDlgMessageForShowUI", 11);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("AddDragDelegate", 12);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ShowDragAnimation", 13);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ShowTutorialReward", 14);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("SceneScrollToItem", 15);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("LockUIInputByQualityLevel", 0x10);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("LockUIInputByStartServerReward", 0x11);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ShowTipByStartServerReward", 0x12);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ScrollToItemByStartServerReward", 0x13);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("HighestQualityLevel", 20);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ShowTipByHighestLevel", 0x15);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("LockUIInputByHighestLevel", 0x16);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("MoveCamera", 0x17);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ShowTipArena", 0x18);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("LockUIInputArena", 0x19);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ScrollToItemArena", 0x1a);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("AddParticle", 0x1b);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("ShowTipQualityLevel", 0x1c);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("LockUIIputQualityLevel", 0x1d);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("SetScrollState", 30);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("RemoveParticle", 0x1f);
                flag &= TypeNameContainer<TutorialConfig._ActionType>.RegisterType("PlayBattle", 0x20);
                return (flag & TypeNameContainer<TutorialConfig._ActionType>.RegisterType("AddPtrListener", 0x21));
            }
        }

        public class _ArrowRotation : TypeNameContainer<TutorialConfig._ArrowRotation>
        {
            public const int Down = 4;
            public const int Left = 1;
            public const int Right = 2;
            public const int Unknown = 0;
            public const int Up = 3;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TutorialConfig._ArrowRotation>.RegisterType("Left", 1);
                flag &= TypeNameContainer<TutorialConfig._ArrowRotation>.RegisterType("Right", 2);
                flag &= TypeNameContainer<TutorialConfig._ArrowRotation>.RegisterType("Up", 3);
                return (flag & TypeNameContainer<TutorialConfig._ArrowRotation>.RegisterType("Down", 4));
            }
        }

        public class _ConditionType : TypeNameContainer<TutorialConfig._ConditionType>
        {
            public const int AnimationIsPlaying = 0x23;
            public const int AvatarBreakThrough = 0x1c;
            public const int AvatarLineUpCount = 8;
            public const int BreakThroughConditon = 0x24;
            public const int ButtonLocked = 20;
            public const int CameraIsScrolling = 0x22;
            public const int CampaignZoneState = 0x10;
            public const int CheckActivityState = 0x12;
            public const int CheckClientDynamicValue = 0x11;
            public const int ContentQualityLevel = 0x16;
            public const int CurrentState = 7;
            public const int DailyGuid = 15;
            public const int GameMoneyEnough = 0x20;
            public const int HasAssistantUI = 0x21;
            public const int HasAvatarByIndex = 0x2d;
            public const int HasEquipmentOnAvatar = 5;
            public const int HasEquipmentOrAvatar = 0x2e;
            public const int HasEquipOnAvatar = 0x27;
            public const int HasSkillOnAvatar = 13;
            public const int HasStartServerReward = 0x1a;
            public const int IsAssistant = 0x1b;
            public const int IsCameraMove = 0x1d;
            public const int IsClose = 0x25;
            public const int IsOpenHardDifficulity = 0x19;
            public const int LastDungeonId = 0x26;
            public const int MoveIcon = 0x13;
            public const int PlayerLevel = 6;
            public const int PressControl = 2;
            public const int PressControlByData = 0x29;
            public const int PressControlByQualityLevel = 0x17;
            public const int PressControlQualityLevel = 0x1f;
            public const int PveSkipCombat = 14;
            public const int QualityLevelAvatarsCount = 0x2a;
            public const int QuestCurrentStepActived = 9;
            public const int QuestFinished = 4;
            public const int ScrollListItemData = 0x18;
            public const int SearchAvatar = 0x2b;
            public const int SearchConsumable = 30;
            public const int StarReward = 0x15;
            public const int TutorialOpen = 0x2c;
            public const int UIButtonEnable = 1;
            public const int UIButtonExist = 11;
            public const int UIObjActive = 10;
            public const int UIScrollListItemCount = 12;
            public const int UIShown = 3;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("UIButtonEnable", 1);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("PressControl", 2);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("UIShown", 3);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("QuestFinished", 4);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("HasEquipmentOnAvatar", 5);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("PlayerLevel", 6);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("CurrentState", 7);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("AvatarLineUpCount", 8);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("QuestActived", 9);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("UIObjActive", 10);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("UIButtonExist", 11);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("UIScrollListItemCount", 12);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("HasSkillOnAvatar", 13);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("PveSkipCombat", 14);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("DailyGuid", 15);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("CampaignZoneState", 0x10);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("CheckClientDynamicValue", 0x11);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("CheckActivityState", 0x12);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("MoveIcon", 0x13);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("ButtonLocked", 20);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("StarReward", 0x15);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("ContentQualityLevel", 0x16);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("PressControlByQualityLevel", 0x17);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("ScrollListItemData", 0x18);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("IsOpenHardDifficulity", 0x19);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("HasStartServerReward", 0x1a);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("IsAssistant", 0x1b);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("AvatarBreakThrough", 0x1c);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("IsCameraMove", 0x1d);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("SearchConsumable", 30);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("PressControlQualityLevel", 0x1f);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("GameMoneyEnough", 0x20);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("HasAssistantUI", 0x21);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("CameraIsScrolling", 0x22);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("AnimationIsPlaying", 0x23);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("BreakThroughConditon", 0x24);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("IsClose", 0x25);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("LastDungeonId", 0x26);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("HasEquipOnAvatar", 0x27);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("PressControlByData", 0x29);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("QualityLevelAvatarsCount", 0x2a);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("SearchAvatar", 0x2b);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("TutorialOpen", 0x2c);
                flag &= TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("HasAvatarByIndex", 0x2d);
                return (flag & TypeNameContainer<TutorialConfig._ConditionType>.RegisterType("HasEquipmentOrAvatar", 0x2e));
            }
        }

        public class _NPCDirection : TypeNameContainer<TutorialConfig._NPCDirection>
        {
            public const int Left = 1;
            public const int Right = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TutorialConfig._NPCDirection>.RegisterType("Left", 1);
                return (flag & TypeNameContainer<TutorialConfig._NPCDirection>.RegisterType("Right", 2));
            }
        }

        public class _Phase : TypeNameContainer<TutorialConfig._Phase>
        {
            public const int Active = 1;
            public const int Finish = 2;
            public const int Terminal = 3;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TutorialConfig._Phase>.RegisterType("Active", 1);
                flag &= TypeNameContainer<TutorialConfig._Phase>.RegisterType("Finish", 2);
                return (flag & TypeNameContainer<TutorialConfig._Phase>.RegisterType("Terminal", 3));
            }
        }

        [ProtoContract(Name="Action")]
        public class Action : IExtensible
        {
            private int _arrowDirection;
            private vector3 _arrowPosOffset;
            private int _arrowRotateTimes;
            private int _arrowRotation;
            private vector3 _arrowScale;
            private string _attachComponentName = "";
            private bool _boolValue;
            private int _buttonData;
            private bool _componentType;
            private string _dlgMessageCancel = "";
            private string _dlgMessageOk = "";
            private string _iconStrValue = "";
            private int _intValue;
            private bool _isSkillOrEquip;
            private int _npcIconId;
            private vector3 _panelSize;
            private int _phase;
            private bool _showMessageAuto;
            private bool _showNpc;
            private string _strValue = "";
            private bool _tapClose;
            private int _tapCloseUIType;
            private string _text = "";
            private int _type;
            private vector3 _uiPostion;
            private string _voice = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            public static TutorialConfig.Action LoadActionFromXml(SecurityElement element)
            {
                TutorialConfig.Action action = new TutorialConfig.Action {
                    phase = TypeNameContainer<TutorialConfig._Phase>.Parse(element.Attribute("Phase"), 0),
                    type = TypeNameContainer<TutorialConfig._ActionType>.Parse(element.Attribute("Type"), 0)
                };
                switch (action.type)
                {
                    case 1:
                        action.boolValue = StrParser.ParseBool(element.Attribute("Show"), true);
                        action.intValue = TypeNameContainer<_UIType>.Parse(element.Attribute("UIPanelName"), 0);
                        action.buttonData = StrParser.ParseHexInt(element.Attribute("AssetId"), 0);
                        return action;

                    case 2:
                        action.showNpc = StrParser.ParseBool(element.Attribute("ShowNPC"), true);
                        action.uiPostion = vector3.LoadFromXml(element.Attribute("UIPosition"));
                        action.panelSize = vector3.LoadFromXml(element.Attribute("PanelSize"));
                        action.attachComponentName = StrParser.ParseStr(element.Attribute("AttachComponentName"), "");
                        action.intValue = StrParser.ParseDecInt(element.Attribute("AttachComponentIndex"), 1);
                        action.arrowScale = vector3.LoadFromXml(element.Attribute("ArrowScale"));
                        action.arrowPosOffset = vector3.LoadFromXml(element.Attribute("ArrowPositionOffset"));
                        action.strValue = StrParser.ParseStr(element.Attribute("TipMessage"), "", true);
                        action.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                        action.tapClose = StrParser.ParseBool(element.Attribute("TapClose"), false);
                        action.npcIconId = StrParser.ParseHexInt(element.Attribute("NPCIcon"), 0);
                        action.arrowRotateTimes = StrParser.ParseDecInt(element.Attribute("ArrowRotateTimes"), -1);
                        action.componentType = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                        action.showMessageAuto = StrParser.ParseBool(element.Attribute("ShowMessageAuto"), false);
                        action.tapCloseUIType = TypeNameContainer<_UIType>.Parse(element.Attribute("TapCloseUIType"), 0);
                        action.arrowRotation = TypeNameContainer<TutorialConfig._ArrowRotation>.Parse(element.Attribute("ArrowRotation"), 1);
                        action.buttonData = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                        action.isSkillOrEquip = StrParser.ParseBool(element.Attribute("IsSkillOrEquip"), false);
                        action._arrowDirection = TypeNameContainer<TutorialConfig._NPCDirection>.Parse(element.Attribute("NPCDirection"), 2);
                        action.voice = StrParser.ParseStr(element.Attribute("Voice"), "");
                        return action;

                    case 3:
                        action.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                        action.boolValue = StrParser.ParseBool(element.Attribute("Lock"), true);
                        action.intValue = StrParser.ParseDecInt(element.Attribute("UIComponentIndex"), 1);
                        action.componentType = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                        action.iconStrValue = StrParser.ParseStr(element.Attribute("IconComponentName"), "");
                        action.buttonData = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                        action.isSkillOrEquip = StrParser.ParseBool(element.Attribute("IsSkillOrEquip"), false);
                        return action;

                    case 4:
                        action.intValue = StrParser.ParseHexInt(element.Attribute("TutorialID"), 0);
                        action.boolValue = StrParser.ParseBool(element.Attribute("MakeLocal"), false);
                        return action;

                    case 5:
                        action.strValue = StrParser.ParseStr(element.Attribute("GameSateName"), "");
                        return action;

                    case 6:
                        action.boolValue = StrParser.ParseBool(element.Attribute("Show"), true);
                        action.intValue = StrParser.ParseHexInt(element.Attribute("DialoguesID"), 0);
                        return action;

                    case 7:
                        action.strValue = StrParser.ParseStr(element.Attribute("ScrollListName"), "");
                        action.intValue = StrParser.ParseDecInt(element.Attribute("ScrollToItemIndex"), 0);
                        action.buttonData = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                        action.iconStrValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                        return action;

                    case 8:
                    case 9:
                        action.strValue = TypeNameContainer<_ClientDynamicValueType>.GetNameByType(TypeNameContainer<_ClientDynamicValueType>.Parse(element.Attribute("ClientValueType"), 0));
                        action.intValue = StrParser.ParseHexInt(element.Attribute("ClientValue"), 0);
                        return action;

                    case 10:
                        action.strValue = StrParser.ParseStr(element.Attribute("ScrollListName"), "");
                        action.boolValue = StrParser.ParseBool(element.Attribute("EnabelScroll"), false);
                        return action;

                    case 11:
                        action.text = StrParser.ParseStr(element.Attribute("DlgMessageTitle"), "");
                        action.strValue = StrParser.ParseStr(element.Attribute("DlgMessage"), "");
                        action.intValue = TypeNameContainer<_UIType>.Parse(element.Attribute("UIPanelName"), 0);
                        action.dlgMessageCancel = StrParser.ParseStr(element.Attribute("CancelStr"), "");
                        action.dlgMessageOk = StrParser.ParseStr(element.Attribute("OkStr"), "");
                        return action;

                    case 12:
                        action.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                        return action;

                    case 13:
                        action.strValue = StrParser.ParseStr(element.Attribute("FromComponentName"), "");
                        action.attachComponentName = StrParser.ParseStr(element.Attribute("ToComponentName"), "");
                        action.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                        action.voice = StrParser.ParseStr(element.Attribute("Voice"), "");
                        return action;

                    case 14:
                        action.intValue = StrParser.ParseHexInt(element.Attribute("AssetId"), 0);
                        action.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                        return action;

                    case 15:
                        action.intValue = StrParser.ParseDecInt(element.Attribute("Index"), 0);
                        return action;

                    case 0x10:
                        action.strValue = StrParser.ParseStr(element.Attribute("ScrollListName"), "");
                        action.boolValue = StrParser.ParseBool(element.Attribute("Lock"), true);
                        action.intValue = StrParser.ParseDecInt(element.Attribute("QualityLevel"), 0);
                        return action;

                    case 0x11:
                        action.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                        action.boolValue = StrParser.ParseBool(element.Attribute("Lock"), true);
                        action.intValue = StrParser.ParseDecInt(element.Attribute("UIComponentIndex"), 1);
                        action.componentType = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                        action.iconStrValue = StrParser.ParseStr(element.Attribute("IconComponentName"), "");
                        action.buttonData = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                        action.isSkillOrEquip = StrParser.ParseBool(element.Attribute("IsSkillOrEquip"), false);
                        return action;

                    case 0x12:
                        action.showNpc = StrParser.ParseBool(element.Attribute("ShowNPC"), true);
                        action.uiPostion = vector3.LoadFromXml(element.Attribute("UIPosition"));
                        action.panelSize = vector3.LoadFromXml(element.Attribute("PanelSize"));
                        action.attachComponentName = StrParser.ParseStr(element.Attribute("AttachComponentName"), "");
                        action.intValue = StrParser.ParseDecInt(element.Attribute("AttachComponentIndex"), 1);
                        action.arrowScale = vector3.LoadFromXml(element.Attribute("ArrowScale"));
                        action.arrowPosOffset = vector3.LoadFromXml(element.Attribute("ArrowPositionOffset"));
                        action.strValue = StrParser.ParseStr(element.Attribute("TipMessage"), "", true);
                        action.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                        action.tapClose = StrParser.ParseBool(element.Attribute("TapClose"), false);
                        action.npcIconId = StrParser.ParseHexInt(element.Attribute("NPCIcon"), 0);
                        action.arrowRotateTimes = StrParser.ParseDecInt(element.Attribute("ArrowRotateTimes"), -1);
                        action.componentType = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                        action.showMessageAuto = StrParser.ParseBool(element.Attribute("ShowMessageAuto"), false);
                        action.tapCloseUIType = TypeNameContainer<_UIType>.Parse(element.Attribute("TapCloseUIType"), 0);
                        action.arrowRotation = TypeNameContainer<TutorialConfig._ArrowRotation>.Parse(element.Attribute("ArrowRotation"), 1);
                        action.buttonData = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                        action.isSkillOrEquip = StrParser.ParseBool(element.Attribute("IsSkillOrEquip"), false);
                        action.voice = StrParser.ParseStr(element.Attribute("Voice"), "");
                        return action;

                    case 0x13:
                        action.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                        action.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                        return action;

                    case 20:
                    case 0x15:
                    case 0x16:
                        return action;

                    case 0x17:
                        action.intValue = StrParser.ParseDecInt(element.Attribute("TargetBuilding"), 0);
                        action.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                        return action;

                    case 0x18:
                        action.showNpc = StrParser.ParseBool(element.Attribute("ShowNPC"), true);
                        action.uiPostion = vector3.LoadFromXml(element.Attribute("UIPosition"));
                        action.arrowScale = vector3.LoadFromXml(element.Attribute("ArrowScale"));
                        action.arrowPosOffset = vector3.LoadFromXml(element.Attribute("ArrowPositionOffset"));
                        action.attachComponentName = StrParser.ParseStr(element.Attribute("AttachComponentName"), "", true);
                        action.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                        action.componentType = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                        action.showMessageAuto = StrParser.ParseBool(element.Attribute("ShowMessageAuto"), false);
                        action.arrowRotation = TypeNameContainer<TutorialConfig._ArrowRotation>.Parse(element.Attribute("ArrowRotation"), 1);
                        action.buttonData = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                        action.voice = StrParser.ParseStr(element.Attribute("Voice"), "");
                        return action;

                    case 0x19:
                        action.attachComponentName = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                        action.boolValue = StrParser.ParseBool(element.Attribute("Lock"), true);
                        action.componentType = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                        return action;

                    case 0x1a:
                        action.attachComponentName = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                        action.intValue = StrParser.ParseDecInt(element.Attribute("ScrollToItemIndex"), 0);
                        action.buttonData = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                        action.iconStrValue = StrParser.ParseStr(element.Attribute("ScrollListName"), "");
                        return action;

                    case 0x1b:
                        action.attachComponentName = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                        action.strValue = StrParser.ParseStr(element.Attribute("ParticleName"), "");
                        return action;

                    case 0x1c:
                        action.showNpc = StrParser.ParseBool(element.Attribute("ShowNPC"), true);
                        action.uiPostion = vector3.LoadFromXml(element.Attribute("UIPosition"));
                        action.attachComponentName = StrParser.ParseStr(element.Attribute("AttachComponentName"), "");
                        action.arrowScale = vector3.LoadFromXml(element.Attribute("ArrowScale"));
                        action.arrowPosOffset = vector3.LoadFromXml(element.Attribute("ArrowPositionOffset"));
                        action.strValue = StrParser.ParseStr(element.Attribute("TipMessage"), "", true);
                        action.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                        action.tapClose = StrParser.ParseBool(element.Attribute("TapClose"), false);
                        action.npcIconId = StrParser.ParseHexInt(element.Attribute("NPCIcon"), 0);
                        action.arrowRotateTimes = StrParser.ParseDecInt(element.Attribute("ArrowRotateTimes"), -1);
                        action.componentType = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                        action.showMessageAuto = StrParser.ParseBool(element.Attribute("ShowMessageAuto"), false);
                        action.tapCloseUIType = TypeNameContainer<_UIType>.Parse(element.Attribute("TapCloseUIType"), 0);
                        action.arrowRotation = TypeNameContainer<TutorialConfig._ArrowRotation>.Parse(element.Attribute("ArrowRotation"), 1);
                        action.buttonData = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                        action.isSkillOrEquip = StrParser.ParseBool(element.Attribute("IsSkillOrEquip"), false);
                        action._arrowDirection = TypeNameContainer<TutorialConfig._NPCDirection>.Parse(element.Attribute("NPCDirection"), 2);
                        action.voice = StrParser.ParseStr(element.Attribute("Voice"), "");
                        return action;

                    case 0x1d:
                        action.strValue = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                        action.boolValue = StrParser.ParseBool(element.Attribute("Lock"), true);
                        action.componentType = StrParser.ParseBool(element.Attribute("IsScrollItem"), false);
                        action.iconStrValue = StrParser.ParseStr(element.Attribute("IconComponentName"), "");
                        action.buttonData = StrParser.ParseHexInt(element.Attribute("ButtonData"), 0);
                        action.isSkillOrEquip = StrParser.ParseBool(element.Attribute("IsSkillOrEquip"), false);
                        return action;

                    case 30:
                        action.boolValue = StrParser.ParseBool(element.Attribute("State"), false);
                        return action;

                    case 0x1f:
                        action.attachComponentName = StrParser.ParseStr(element.Attribute("UIComponentName"), "");
                        action.strValue = StrParser.ParseStr(element.Attribute("ParticleName"), "");
                        return action;

                    case 0x20:
                        action.intValue = StrParser.ParseHexInt(element.Attribute("DungeonId"), 0);
                        return action;

                    case 0x21:
                        action.boolValue = StrParser.ParseBool(element.Attribute("Value"), false);
                        return action;
                }
                return action;
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="arrowDirection", DataFormat=DataFormat.TwosComplement)]
            public int arrowDirection
            {
                get
                {
                    return this._arrowDirection;
                }
                set
                {
                    this._arrowDirection = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(14, IsRequired=false, Name="arrowPosOffset", DataFormat=DataFormat.Default)]
            public vector3 arrowPosOffset
            {
                get
                {
                    return this._arrowPosOffset;
                }
                set
                {
                    this._arrowPosOffset = value;
                }
            }

            [ProtoMember(0x10, IsRequired=false, Name="arrowRotateTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int arrowRotateTimes
            {
                get
                {
                    return this._arrowRotateTimes;
                }
                set
                {
                    this._arrowRotateTimes = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x17, IsRequired=false, Name="arrowRotation", DataFormat=DataFormat.TwosComplement)]
            public int arrowRotation
            {
                get
                {
                    return this._arrowRotation;
                }
                set
                {
                    this._arrowRotation = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="arrowScale", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public vector3 arrowScale
            {
                get
                {
                    return this._arrowScale;
                }
                set
                {
                    this._arrowScale = value;
                }
            }

            [DefaultValue(""), ProtoMember(9, IsRequired=false, Name="attachComponentName", DataFormat=DataFormat.Default)]
            public string attachComponentName
            {
                get
                {
                    return this._attachComponentName;
                }
                set
                {
                    this._attachComponentName = value;
                }
            }

            [DefaultValue(false), ProtoMember(13, IsRequired=false, Name="boolValue", DataFormat=DataFormat.Default)]
            public bool boolValue
            {
                get
                {
                    return this._boolValue;
                }
                set
                {
                    this._boolValue = value;
                }
            }

            [ProtoMember(0x18, IsRequired=false, Name="buttonData", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int buttonData
            {
                get
                {
                    return this._buttonData;
                }
                set
                {
                    this._buttonData = value;
                }
            }

            [DefaultValue(false), ProtoMember(0x11, IsRequired=false, Name="componentType", DataFormat=DataFormat.Default)]
            public bool componentType
            {
                get
                {
                    return this._componentType;
                }
                set
                {
                    this._componentType = value;
                }
            }

            [DefaultValue(""), ProtoMember(0x15, IsRequired=false, Name="dlgMessageCancel", DataFormat=DataFormat.Default)]
            public string dlgMessageCancel
            {
                get
                {
                    return this._dlgMessageCancel;
                }
                set
                {
                    this._dlgMessageCancel = value;
                }
            }

            [DefaultValue(""), ProtoMember(20, IsRequired=false, Name="dlgMessageOk", DataFormat=DataFormat.Default)]
            public string dlgMessageOk
            {
                get
                {
                    return this._dlgMessageOk;
                }
                set
                {
                    this._dlgMessageOk = value;
                }
            }

            [DefaultValue(""), ProtoMember(0x16, IsRequired=false, Name="iconStrValue", DataFormat=DataFormat.Default)]
            public string iconStrValue
            {
                get
                {
                    return this._iconStrValue;
                }
                set
                {
                    this._iconStrValue = value;
                }
            }

            [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="intValue", DataFormat=DataFormat.TwosComplement)]
            public int intValue
            {
                get
                {
                    return this._intValue;
                }
                set
                {
                    this._intValue = value;
                }
            }

            [DefaultValue(false), ProtoMember(0x19, IsRequired=false, Name="isSkillOrEquip", DataFormat=DataFormat.Default)]
            public bool isSkillOrEquip
            {
                get
                {
                    return this._isSkillOrEquip;
                }
                set
                {
                    this._isSkillOrEquip = value;
                }
            }

            [DefaultValue(0), ProtoMember(15, IsRequired=false, Name="npcIconId", DataFormat=DataFormat.TwosComplement)]
            public int npcIconId
            {
                get
                {
                    return this._npcIconId;
                }
                set
                {
                    this._npcIconId = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="panelSize", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public vector3 panelSize
            {
                get
                {
                    return this._panelSize;
                }
                set
                {
                    this._panelSize = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="phase", DataFormat=DataFormat.TwosComplement)]
            public int phase
            {
                get
                {
                    return this._phase;
                }
                set
                {
                    this._phase = value;
                }
            }

            [DefaultValue(false), ProtoMember(0x12, IsRequired=false, Name="showMessageAuto", DataFormat=DataFormat.Default)]
            public bool showMessageAuto
            {
                get
                {
                    return this._showMessageAuto;
                }
                set
                {
                    this._showMessageAuto = value;
                }
            }

            [DefaultValue(false), ProtoMember(4, IsRequired=false, Name="showNpc", DataFormat=DataFormat.Default)]
            public bool showNpc
            {
                get
                {
                    return this._showNpc;
                }
                set
                {
                    this._showNpc = value;
                }
            }

            [ProtoMember(11, IsRequired=false, Name="strValue", DataFormat=DataFormat.Default), DefaultValue("")]
            public string strValue
            {
                get
                {
                    return this._strValue;
                }
                set
                {
                    this._strValue = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="tapClose", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool tapClose
            {
                get
                {
                    return this._tapClose;
                }
                set
                {
                    this._tapClose = value;
                }
            }

            [ProtoMember(0x13, IsRequired=false, Name="tapCloseUIType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int tapCloseUIType
            {
                get
                {
                    return this._tapCloseUIType;
                }
                set
                {
                    this._tapCloseUIType = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="text", DataFormat=DataFormat.Default), DefaultValue("")]
            public string text
            {
                get
                {
                    return this._text;
                }
                set
                {
                    this._text = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="uiPostion", DataFormat=DataFormat.Default)]
            public vector3 uiPostion
            {
                get
                {
                    return this._uiPostion;
                }
                set
                {
                    this._uiPostion = value;
                }
            }

            [DefaultValue(""), ProtoMember(0x1a, IsRequired=false, Name="voice", DataFormat=DataFormat.Default)]
            public string voice
            {
                get
                {
                    return this._voice;
                }
                set
                {
                    this._voice = value;
                }
            }
        }

        [ProtoContract(Name="CampaignGuid")]
        public class CampaignGuid : IExtensible
        {
            private readonly List<TutorialConfig.CampaignUnLockAction> _campaignUnLockActions = new List<TutorialConfig.CampaignUnLockAction>();
            private TutorialConfig.Action _firstCampaignRewardAction;
            private bool _openTutorial;
            private int _playerLevel;
            private IExtension extensionObject;

            public TutorialConfig.CampaignUnLockAction GetCampaignUnLockActionByZoneID(int zoneID)
            {
                if ((this.campaignUnLockActions != null) && (this.campaignUnLockActions.Count > 0))
                {
                    foreach (TutorialConfig.CampaignUnLockAction action in this.campaignUnLockActions)
                    {
                        if (action.zoneId == zoneID)
                        {
                            return action;
                        }
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, Name="campaignUnLockActions", DataFormat=DataFormat.Default)]
            public List<TutorialConfig.CampaignUnLockAction> campaignUnLockActions
            {
                get
                {
                    return this._campaignUnLockActions;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="firstCampaignRewardAction", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public TutorialConfig.Action firstCampaignRewardAction
            {
                get
                {
                    return this._firstCampaignRewardAction;
                }
                set
                {
                    this._firstCampaignRewardAction = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="openTutorial", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool openTutorial
            {
                get
                {
                    return this._openTutorial;
                }
                set
                {
                    this._openTutorial = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement)]
            public int playerLevel
            {
                get
                {
                    return this._playerLevel;
                }
                set
                {
                    this._playerLevel = value;
                }
            }
        }

        [ProtoContract(Name="CampaignUnLockAction")]
        public class CampaignUnLockAction : IExtensible
        {
            private TutorialConfig.Action _action;
            private int _zoneId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="action", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public TutorialConfig.Action action
            {
                get
                {
                    return this._action;
                }
                set
                {
                    this._action = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="zoneId", DataFormat=DataFormat.TwosComplement)]
            public int zoneId
            {
                get
                {
                    return this._zoneId;
                }
                set
                {
                    this._zoneId = value;
                }
            }
        }

        [ProtoContract(Name="CombatFailGuid")]
        public class CombatFailGuid : IExtensible
        {
            private readonly List<TutorialConfig.Action> _avatarGuids = new List<TutorialConfig.Action>();
            private readonly List<TutorialConfig.Action> _equipGuids = new List<TutorialConfig.Action>();
            private int _openFuncPlayerLevel;
            private int _particleCloseLevel;
            private readonly List<TutorialConfig.Action> _skillGuids = new List<TutorialConfig.Action>();
            private IExtension extensionObject;

            public TutorialConfig.Action GetAvatarActionByType(bool newAvatar, int index)
            {
                if (this._avatarGuids != null)
                {
                    int num = newAvatar ? 1 : 0;
                    foreach (TutorialConfig.Action action in this._avatarGuids)
                    {
                        if (action.phase == num)
                        {
                            if (newAvatar)
                            {
                                action.intValue = index;
                            }
                            return action;
                        }
                    }
                }
                return null;
            }

            public TutorialConfig.Action GetEquipActionByType(int equipType)
            {
                if (this._equipGuids != null)
                {
                    foreach (TutorialConfig.Action action in this._equipGuids)
                    {
                        if (action.phase == equipType)
                        {
                            return action;
                        }
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="avatarGuids", DataFormat=DataFormat.Default)]
            public List<TutorialConfig.Action> avatarGuids
            {
                get
                {
                    return this._avatarGuids;
                }
            }

            [ProtoMember(3, Name="equipGuids", DataFormat=DataFormat.Default)]
            public List<TutorialConfig.Action> equipGuids
            {
                get
                {
                    return this._equipGuids;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="openFuncPlayerLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int openFuncPlayerLevel
            {
                get
                {
                    return this._openFuncPlayerLevel;
                }
                set
                {
                    this._openFuncPlayerLevel = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="particleCloseLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int particleCloseLevel
            {
                get
                {
                    return this._particleCloseLevel;
                }
                set
                {
                    this._particleCloseLevel = value;
                }
            }

            [ProtoMember(4, Name="skillGuids", DataFormat=DataFormat.Default)]
            public List<TutorialConfig.Action> skillGuids
            {
                get
                {
                    return this._skillGuids;
                }
            }
        }

        [ProtoContract(Name="Condition")]
        public class Condition : IExtensible
        {
            private bool _boolValue;
            private int _extraIntValue;
            private bool _extraValue;
            private string _iconStrValue = "";
            private int _intValue;
            private int _levelValue;
            private int _phase;
            private string _strValue = "";
            private int _type;
            private int _valueCompareType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(false), ProtoMember(6, IsRequired=false, Name="boolValue", DataFormat=DataFormat.Default)]
            public bool boolValue
            {
                get
                {
                    return this._boolValue;
                }
                set
                {
                    this._boolValue = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="extraIntValue", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int extraIntValue
            {
                get
                {
                    return this._extraIntValue;
                }
                set
                {
                    this._extraIntValue = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="extraValue", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool extraValue
            {
                get
                {
                    return this._extraValue;
                }
                set
                {
                    this._extraValue = value;
                }
            }

            [DefaultValue(""), ProtoMember(9, IsRequired=false, Name="iconStrValue", DataFormat=DataFormat.Default)]
            public string iconStrValue
            {
                get
                {
                    return this._iconStrValue;
                }
                set
                {
                    this._iconStrValue = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="intValue", DataFormat=DataFormat.TwosComplement)]
            public int intValue
            {
                get
                {
                    return this._intValue;
                }
                set
                {
                    this._intValue = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="levelValue", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int levelValue
            {
                get
                {
                    return this._levelValue;
                }
                set
                {
                    this._levelValue = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="phase", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int phase
            {
                get
                {
                    return this._phase;
                }
                set
                {
                    this._phase = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="strValue", DataFormat=DataFormat.Default), DefaultValue("")]
            public string strValue
            {
                get
                {
                    return this._strValue;
                }
                set
                {
                    this._strValue = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="valueCompareType", DataFormat=DataFormat.TwosComplement)]
            public int valueCompareType
            {
                get
                {
                    return this._valueCompareType;
                }
                set
                {
                    this._valueCompareType = value;
                }
            }
        }

        [ProtoContract(Name="Step")]
        public class Step : IExtensible
        {
            private readonly List<TutorialConfig.Action> _actions = new List<TutorialConfig.Action>();
            private readonly List<TutorialConfig.Condition> _conditions = new List<TutorialConfig.Condition>();
            private bool _skipWhenInaction;
            private Dictionary<int, List<TutorialConfig.Action>> _type_actionssMap = new Dictionary<int, List<TutorialConfig.Action>>();
            private Dictionary<int, List<TutorialConfig.Condition>> _type_conditionsMap = new Dictionary<int, List<TutorialConfig.Condition>>();
            private IExtension extensionObject;

            public void ConstructLogicData()
            {
                foreach (TutorialConfig.Condition condition in this._conditions)
                {
                    List<TutorialConfig.Condition> conditionByType = this.GetConditionByType(condition.phase);
                    if (conditionByType == null)
                    {
                        conditionByType = new List<TutorialConfig.Condition>();
                        this._type_conditionsMap.Add(condition.phase, conditionByType);
                    }
                    conditionByType.Add(condition);
                }
                foreach (TutorialConfig.Action action in this._actions)
                {
                    List<TutorialConfig.Action> actionByType = this.GetActionByType(action.phase);
                    if (actionByType == null)
                    {
                        actionByType = new List<TutorialConfig.Action>();
                        this._type_actionssMap.Add(action.phase, actionByType);
                    }
                    actionByType.Add(action);
                }
            }

            public List<TutorialConfig.Action> GetActionByType(int actionType)
            {
                List<TutorialConfig.Action> list;
                if (!this._type_actionssMap.TryGetValue(actionType, out list))
                {
                    return null;
                }
                return list;
            }

            public List<TutorialConfig.Condition> GetConditionByType(int conditionType)
            {
                List<TutorialConfig.Condition> list = null;
                if (!this._type_conditionsMap.TryGetValue(conditionType, out list))
                {
                    return null;
                }
                return list;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, Name="actions", DataFormat=DataFormat.Default)]
            public List<TutorialConfig.Action> actions
            {
                get
                {
                    return this._actions;
                }
            }

            [ProtoMember(2, Name="conditions", DataFormat=DataFormat.Default)]
            public List<TutorialConfig.Condition> conditions
            {
                get
                {
                    return this._conditions;
                }
            }

            [DefaultValue(false), ProtoMember(1, IsRequired=false, Name="skipWhenInaction", DataFormat=DataFormat.Default)]
            public bool skipWhenInaction
            {
                get
                {
                    return this._skipWhenInaction;
                }
                set
                {
                    this._skipWhenInaction = value;
                }
            }
        }

        [ProtoContract(Name="Tutorial")]
        public class Tutorial : IExtensible
        {
            private int _id;
            private readonly List<TutorialConfig.Step> _steps = new List<TutorialConfig.Step>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [ProtoMember(2, Name="steps", DataFormat=DataFormat.Default)]
            public List<TutorialConfig.Step> steps
            {
                get
                {
                    return this._steps;
                }
            }
        }

        [ProtoContract(Name="TutorialCombat")]
        public class TutorialCombat : IExtensible
        {
            private readonly List<ClientServerCommon.Npc> _opponentTeam = new List<ClientServerCommon.Npc>();
            private int _sceneId;
            private int _speed;
            private readonly List<ClientServerCommon.Npc> _sponorTeam = new List<ClientServerCommon.Npc>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, Name="opponentTeam", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.Npc> opponentTeam
            {
                get
                {
                    return this._opponentTeam;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="sceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int sceneId
            {
                get
                {
                    return this._sceneId;
                }
                set
                {
                    this._sceneId = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="speed", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int speed
            {
                get
                {
                    return this._speed;
                }
                set
                {
                    this._speed = value;
                }
            }

            [ProtoMember(2, Name="sponorTeam", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.Npc> sponorTeam
            {
                get
                {
                    return this._sponorTeam;
                }
            }
        }
    }
}

