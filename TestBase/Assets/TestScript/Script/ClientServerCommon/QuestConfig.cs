namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="QuestConfig")]
    public class QuestConfig : Configuration, IExtensible
    {
        private long _dailyResetTime;
        private readonly List<Quest> _quests = new List<Quest>();
        private IExtension extensionObject;
        private Dictionary<int, Quest> id_questMap = new Dictionary<int, Quest>();

        public static bool CompareConditionValue(Condition condition, int value)
        {
            switch (condition.valueCompareType)
            {
                case 1:
                    return (value < condition.value);

                case 2:
                    return (value <= condition.value);

                case 3:
                    return (value == condition.value);

                case 4:
                    return (value >= condition.value);

                case 5:
                    return (value > condition.value);

                case 6:
                    return (value != condition.value);
            }
            return false;
        }

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Quest quest in this._quests)
            {
                if (quest != null)
                {
                    if (this.id_questMap.ContainsKey(quest.questId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + quest.questId.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_questMap.Add(quest.questId, quest);
                    }
                }
            }
        }

        public Quest GetQuestById(int questId)
        {
            Quest quest;
            if (!this.id_questMap.TryGetValue(questId, out quest))
            {
                return null;
            }
            return quest;
        }

        public List<Quest> GetQuestsByType(int type)
        {
            List<Quest> list = new List<Quest>();
            foreach (Quest quest in this._quests)
            {
                if (quest.type == type)
                {
                    list.Add(quest);
                }
            }
            return list;
        }

        public bool GetQuestShowLevelControl(int questId, int level)
        {
            Quest questById = this.GetQuestById(questId);
            if (questById != null)
            {
                foreach (Condition condition in questById.conditions)
                {
                    if (condition.type == 0x18)
                    {
                        return CompareConditionValue(condition, level);
                    }
                }
            }
            return true;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _Type.Initialize();
            _PhaseType.Initialize();
            _EventType.Initialize();
            _CombatType.Initialize();
            _ConditionType.Initialize();
            _ConditionType_FragmentType.Initialize();
        }

        private Condition LoadConditionFromXml(SecurityElement element)
        {
            Condition condition = new Condition {
                phase = TypeNameContainer<_PhaseType>.Parse(element.Attribute("Phase"), 0),
                valueCompareType = TypeNameContainer<_ConditionValueCompareType>.Parse(element.Attribute("ValueCompareType"), 0),
                type = TypeNameContainer<_ConditionType>.Parse(element.Attribute("Type"), 0)
            };
            switch (condition.type)
            {
                case 1:
                    condition.value = TypeNameContainer<_CombatType>.Parse(element.Attribute("Value"), 0);
                    return condition;

                case 2:
                    condition.value = TypeNameContainer<_DungeonDifficulity>.Parse(element.Attribute("Value"), 0);
                    return condition;

                case 3:
                    condition.value = StrParser.ParseHexInt(element.Attribute("Value"), 0);
                    return condition;

                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 14:
                case 15:
                case 0x11:
                case 0x12:
                case 0x13:
                case 20:
                case 0x15:
                    condition.value = StrParser.ParseDecInt(element.Attribute("Value"), 0);
                    return condition;

                case 12:
                    condition.questId = StrParser.ParseHexInt(element.Attribute("QuestId"), 0);
                    condition.value = TypeNameContainer<_PhaseType>.Parse(element.Attribute("Value"), 0);
                    return condition;

                case 13:
                    condition.value = StrParser.ParseHexInt(element.Attribute("Value"), 0);
                    return condition;

                case 0x10:
                    condition.value = TypeNameContainer<_ConditionType_FragmentType>.Parse(element.Attribute("Value"), 0);
                    return condition;

                case 0x17:
                    condition.questType = TypeNameContainer<_Type>.Parse(element.Attribute("QuestType"), 0);
                    condition.value = TypeNameContainer<_PhaseType>.Parse(element.Attribute("Value"), 0);
                    return condition;
            }
            condition.value = StrParser.ParseDecInt(element.Attribute("Value"), 0);
            return condition;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "QuestConfig")
            {
                this._dailyResetTime = StrParser.ParseDateTime(element.Attribute("DailyResetTime"));
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string str;
                        if (((str = element2.Tag) != null) && (str == "Quest"))
                        {
                            this.LoadQuestFromXml(element2);
                        }
                    }
                }
            }
        }

        private void LoadQuestFromXml(SecurityElement element)
        {
            Quest item = new Quest {
                questId = StrParser.ParseHexInt(element.Attribute("QuestId"), 0),
                type = TypeNameContainer<_Type>.Parse(element.Attribute("Type"), 0),
                gotoUI = TypeNameContainer<_UIType>.Parse(element.Attribute("GoToUI"), 0),
                resetType = TypeNameContainer<_TimeDurationType>.Parse(element.Attribute("ResetType"), 0),
                eventType = TypeNameContainer<_EventType>.Parse(element.Attribute("EventType"), 0),
                totalStepCount = StrParser.ParseDecInt(element.Attribute("TotalStepCount"), 0),
                loopEvent = StrParser.ParseBool(element.Attribute("LoopEvent"), false),
                index = StrParser.ParseDecInt(element.Attribute("Index"), 0),
                showFx = StrParser.ParseBool(element.Attribute("ShowFx"), false),
                notHideWhenFinished = StrParser.ParseBool(element.Attribute("NotHideWhenFinished"), false)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    Reward reward;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Condition")
                        {
                            Condition condition = this.LoadConditionFromXml(element2);
                            item.conditions.Add(condition);
                        }
                        else if (tag == "Reward")
                        {
                            goto Label_0152;
                        }
                    }
                    continue;
                Label_0152:
                    reward = Reward.LoadFromXml(element2);
                    item.rewards.Add(reward);
                }
            }
            this._quests.Add(item);
        }

        public DateTime dailyResetDateTime
        {
            get
            {
                return new DateTime(this._dailyResetTime * 0x2710L);
            }
        }

        [ProtoMember(1, IsRequired=false, Name="dailyResetTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long dailyResetTime
        {
            get
            {
                return this._dailyResetTime;
            }
            set
            {
                this._dailyResetTime = value;
            }
        }

        [ProtoMember(2, Name="quests", DataFormat=DataFormat.Default)]
        public List<Quest> quests
        {
            get
            {
                return this._quests;
            }
        }

        public class _ConditionType : TypeNameContainer<QuestConfig._ConditionType>
        {
            public const int ActivityId = 13;
            public const int AreanRankLevel = 8;
            public const int AvatarValue = 0x15;
            public const int BattlePostionCount = 7;
            public const int CampaignDifficulty = 2;
            public const int CampaignDungeonId = 0x16;
            public const int CampaignZoneId = 3;
            public const int CombatType = 1;
            public const int FragementType = 0x10;
            public const int FriendCount = 14;
            public const int GamemoneyCount = 15;
            public const int Level = 5;
            public const int LineUpAvatarQuality56Count = 0x11;
            public const int LineUpAvatarQuality5Count = 9;
            public const int LineUpAvatarQuality6Count = 10;
            public const int PlayerLevel = 0x12;
            public const int PlayerShowLevel = 0x18;
            public const int PlayerValue = 20;
            public const int PveLevel = 11;
            public const int QualityLevel = 4;
            public const int QuestId = 0x17;
            public const int QuestPhase = 12;
            public const int TotalLineUpCount = 6;
            public const int Unknown = 0;
            public const int VipLevel = 0x13;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("CombatType", 1);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("CampaignDifficulty", 2);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("CampaignZoneId", 3);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("QualityLevel", 4);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("Level", 5);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("TotalLineUpCount", 6);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("BattlePostionCount", 7);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("AreanRankLevel", 8);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("LineUpAvatarQuality5Count", 9);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("LineUpAvatarQuality6Count", 10);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("LineUpAvatarQuality56Count", 0x11);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("PveLevel", 11);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("QuestPhase", 12);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("ActivityId", 13);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("FriendCount", 14);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("GamemoneyCount", 15);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("FragementType", 0x10);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("PlayerLevel", 0x12);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("VipLevel", 0x13);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("PlayerValue", 20);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("AvatarValue", 0x15);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("CampaignDungeonId", 0x16);
                flag &= TypeNameContainer<QuestConfig._ConditionType>.RegisterType("QuestId", 0x17);
                return (flag & TypeNameContainer<QuestConfig._ConditionType>.RegisterType("PlayerShowLevel", 0x18));
            }
        }

        public class _ConditionType_FragmentType : TypeNameContainer<QuestConfig._ConditionType_FragmentType>
        {
            public const int Equip = 1;
            public const int Skill = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<QuestConfig._ConditionType_FragmentType>.RegisterType("Equip", 1);
                return (flag & TypeNameContainer<QuestConfig._ConditionType_FragmentType>.RegisterType("Skill", 2));
            }
        }

        public class _EventType : TypeNameContainer<QuestConfig._EventType>
        {
            public const int ActiveMeridian = 0x19;
            public const int AnswerQuestion = 0x1b;
            public const int AreanRankChanged = 7;
            public const int AvatarBreakLevelUp = 10;
            public const int BuyTavern = 2;
            public const int ChangeMeridian = 0x1a;
            public const int Combat = 1;
            public const int CombatFriend = 0x20;
            public const int DoActivity = 3;
            public const int EarnEquipment = 15;
            public const int EquipBreakLevelUp = 0x10;
            public const int EquipStrengthen = 11;
            public const int FinishDailyQuest = 0x18;
            public const int InviteCode = 0x21;
            public const int JoinWolfSmoke = 0x1f;
            public const int LevelUp = 4;
            public const int LineUp = 0x17;
            public const int MixAvatar = 0x1c;
            public const int MixEquip = 0x12;
            public const int MixSkill = 0x11;
            public const int OwnFriend = 13;
            public const int OwnGamemoney = 14;
            public const int PlayerValueChange = 0x16;
            public const int PveFinish = 0x15;
            public const int PveStart = 8;
            public const int RevergeSuccess = 20;
            public const int SkillLevelUp = 9;
            public const int TowerChallenge = 0x1d;
            public const int TrainAvatar = 0x13;
            public const int Unknown = 0;
            public const int UnlockBattlePostion = 6;
            public const int UseGacha = 12;
            public const int UseStaminaItem = 30;
            public const int VipLevelUp = 5;
            public const int WebPage = 0x22;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("Combat", 1);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("BuyTavern", 2);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("DoActivity", 3);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("LevelUp", 4);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("VipLevelUp", 5);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("LineUp", 0x17);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("UnlockBattlePostion", 6);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("AreanRankChanged", 7);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("PveStart", 8);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("SkillLevelUp", 9);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("AvatarBreakLevelUp", 10);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("EquipStrengthen", 11);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("UseGacha", 12);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("OwnFriend", 13);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("OwnGamemoney", 14);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("EarnEquipment", 15);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("EquipBreakLevelUp", 0x10);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("MixEquip", 0x12);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("MixSkill", 0x11);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("TrainAvatar", 0x13);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("RevergeSuccess", 20);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("PveFinish", 0x15);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("PlayerValueChange", 0x16);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("FinishDailyQuest", 0x18);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("ActiveMeridian", 0x19);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("ChangeMeridian", 0x1a);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("AnswerQuestion", 0x1b);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("MixAvatar", 0x1c);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("TowerChallenge", 0x1d);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("UseStaminaItem", 30);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("JoinWolfSmoke", 0x1f);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("CombatFriend", 0x20);
                flag &= TypeNameContainer<QuestConfig._EventType>.RegisterType("InviteCode", 0x21);
                return (flag & TypeNameContainer<QuestConfig._EventType>.RegisterType("WebPage", 0x22));
            }
        }

        public class _PhaseType : TypeNameContainer<QuestConfig._PhaseType>
        {
            public const int Active = 2;
            public const int Closed = 6;
            public const int Finished = 3;
            public const int FinishedAndGotReward = 4;
            public const int FinishedAndHiden = 5;
            public const int Inactive = 1;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<QuestConfig._PhaseType>.RegisterType("Inactive", 1);
                flag &= TypeNameContainer<QuestConfig._PhaseType>.RegisterType("Active", 2);
                flag &= TypeNameContainer<QuestConfig._PhaseType>.RegisterType("Finished", 3);
                flag &= TypeNameContainer<QuestConfig._PhaseType>.RegisterType("FinishedAndHiden", 5);
                flag &= TypeNameContainer<QuestConfig._PhaseType>.RegisterType("FinishedAndGotReward", 4);
                return (flag & TypeNameContainer<QuestConfig._PhaseType>.RegisterType("Closed", 6));
            }
        }

        public class _Type : TypeNameContainer<QuestConfig._Type>
        {
            public const int DailyQuest = 1;
            public const int GoalQuest = 2;
            public const int RepeatedQuest = 3;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<QuestConfig._Type>.RegisterType("DailyQuest", 1);
                flag &= TypeNameContainer<QuestConfig._Type>.RegisterType("GoalQuest", 2);
                return (flag & TypeNameContainer<QuestConfig._Type>.RegisterType("RepeatedQuest", 3));
            }
        }

        [ProtoContract(Name="Condition")]
        public class Condition : IExtensible
        {
            private int _phase;
            private int _questId;
            private int _questType;
            private int _type;
            private int _value;
            private int _valueCompareType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="questId", DataFormat=DataFormat.TwosComplement)]
            public int questId
            {
                get
                {
                    return this._questId;
                }
                set
                {
                    this._questId = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="questType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int questType
            {
                get
                {
                    return this._questType;
                }
                set
                {
                    this._questType = value;
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

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement)]
            public int value
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

            [ProtoMember(4, IsRequired=false, Name="valueCompareType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoContract(Name="Quest")]
        public class Quest : IExtensible
        {
            private readonly List<QuestConfig.Condition> _conditions = new List<QuestConfig.Condition>();
            private int _eventType;
            private int _gotoUI;
            private int _index;
            private bool _loopEvent;
            private bool _notHideWhenFinished;
            private int _questId;
            private int _resetType;
            private readonly List<Reward> _rewards = new List<Reward>();
            private bool _showFx;
            private int _totalStepCount;
            private int _type;
            private IExtension extensionObject;

            public QuestConfig.Condition GetConditionByIndex(int index)
            {
                if ((index >= 0) && (index < this._conditions.Count))
                {
                    return this._conditions[index];
                }
                return null;
            }

            public List<QuestConfig.Condition> GetConditonsByPhase(int phase)
            {
                List<QuestConfig.Condition> list = new List<QuestConfig.Condition>();
                foreach (QuestConfig.Condition condition in this._conditions)
                {
                    if (condition.phase == phase)
                    {
                        list.Add(condition);
                    }
                }
                return list;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(11, Name="conditions", DataFormat=DataFormat.Default)]
            public List<QuestConfig.Condition> conditions
            {
                get
                {
                    return this._conditions;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="eventType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int eventType
            {
                get
                {
                    return this._eventType;
                }
                set
                {
                    this._eventType = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="gotoUI", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int gotoUI
            {
                get
                {
                    return this._gotoUI;
                }
                set
                {
                    this._gotoUI = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int index
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

            [DefaultValue(false), ProtoMember(9, IsRequired=false, Name="loopEvent", DataFormat=DataFormat.Default)]
            public bool loopEvent
            {
                get
                {
                    return this._loopEvent;
                }
                set
                {
                    this._loopEvent = value;
                }
            }

            [ProtoMember(13, IsRequired=false, Name="notHideWhenFinished", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool notHideWhenFinished
            {
                get
                {
                    return this._notHideWhenFinished;
                }
                set
                {
                    this._notHideWhenFinished = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="questId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int questId
            {
                get
                {
                    return this._questId;
                }
                set
                {
                    this._questId = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="resetType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int resetType
            {
                get
                {
                    return this._resetType;
                }
                set
                {
                    this._resetType = value;
                }
            }

            [ProtoMember(7, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> rewards
            {
                get
                {
                    return this._rewards;
                }
            }

            [DefaultValue(false), ProtoMember(12, IsRequired=false, Name="showFx", DataFormat=DataFormat.Default)]
            public bool showFx
            {
                get
                {
                    return this._showFx;
                }
                set
                {
                    this._showFx = value;
                }
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="totalStepCount", DataFormat=DataFormat.TwosComplement)]
            public int totalStepCount
            {
                get
                {
                    return this._totalStepCount;
                }
                set
                {
                    this._totalStepCount = value;
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
        }
    }
}

