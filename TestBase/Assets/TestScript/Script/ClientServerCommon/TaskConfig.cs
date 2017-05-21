namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="TaskConfig")]
    public class TaskConfig : Configuration, IExtensible
    {
        private readonly List<TaskGuid> _taskGuids = new List<TaskGuid>();
        private readonly List<Task> _tasks = new List<Task>();
        private Dictionary<int, TaskGuid> dic_guids = new Dictionary<int, TaskGuid>();
        private Dictionary<int, Task> dic_tasks = new Dictionary<int, Task>();
        private IExtension extensionObject;

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Task task in this._tasks)
            {
                if (task != null)
                {
                    if (task.TaskId == 0)
                    {
                        Logger.Error(base.GetType().Name + " Has InValid Key" + task.TaskId.ToString("X8"), new object[0]);
                    }
                    else if (this.dic_tasks.ContainsKey(task.TaskId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + task.TaskId.ToString("X8"), new object[0]);
                    }
                    else
                    {
                        this.dic_tasks.Add(task.TaskId, task);
                    }
                }
            }
            foreach (TaskGuid guid in this._taskGuids)
            {
                if ((guid != null) && !this.dic_guids.ContainsKey(guid.TaskType))
                {
                    this.dic_guids.Add(guid.TaskType, guid);
                }
            }
        }

        public Task GetTaskById(int taskId)
        {
            if (this.dic_tasks.ContainsKey(taskId))
            {
                return this.dic_tasks[taskId];
            }
            return null;
        }

        public TaskGuid GetTaskGuidByType(int taskType)
        {
            if (this.dic_guids.ContainsKey(taskType))
            {
                return this.dic_guids[taskType];
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _TaskType.Initialize();
            _GachaAssistValueType.Initialize();
            _SecretAssistValueType.Initialize();
            _DungeonAssistValueType.Initialize();
            _MonthCardAssistValueType.Initialize();
            _ArenaShopRealMoneyAssistantValueType.Initialize();
            _ShopGoodsAssistantValueType.Initialize();
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "TaskConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Task")
                        {
                            Task item = this.LoadTaskFromXml(element2);
                            this._tasks.Add(item);
                        }
                        else if (tag == "TaskGuidSet")
                        {
                            goto Label_0071;
                        }
                    }
                    continue;
                Label_0071:
                    this.LoadTaskGuidSetFromXml(element2);
                }
            }
        }

        private Task LoadTaskFromXml(SecurityElement element)
        {
            Task task = new Task {
                TaskId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                Priority = StrParser.ParseDecInt(element.Attribute("Priority"), 0),
                TaskType = TypeNameContainer<_TaskType>.Parse(element.Attribute("TaskType"), 0),
                GotoUI = TypeNameContainer<_UIType>.Parse(element.Attribute("GotoUI"), 0),
                IsOpen = StrParser.ParseBool(element.Attribute("IsOpen"), false)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Data"))
                    {
                        if (((task.TaskType == 2) || (task.TaskType == 5)) || (((task.TaskType == 0x1a) || (task.TaskType == 0x1d)) || (task.TaskType == 30)))
                        {
                            task.Datas.Add(StrParser.ParseHexInt(element2.Attribute("Value"), 0));
                        }
                        else if (task.TaskType == 14)
                        {
                            task.Datas.Add(TypeNameContainer<_DungeonDifficulity>.Parse(element2.Attribute("Value"), 1));
                        }
                    }
                }
            }
            return task;
        }

        private void LoadTaskGuidSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "TaskGuid")
                    {
                        TaskGuid item = new TaskGuid {
                            TaskType = TypeNameContainer<_TaskType>.Parse(element2.Attribute("Type"), 0),
                            AttachConParent = StrParser.ParseStr(element2.Attribute("AttachComponentParent"), string.Empty)
                        };
                        this._taskGuids.Add(item);
                    }
                }
            }
        }

        [ProtoMember(2, Name="taskGuids", DataFormat=DataFormat.Default)]
        public List<TaskGuid> TaskGuids
        {
            get
            {
                return this._taskGuids;
            }
        }

        [ProtoMember(1, Name="tasks", DataFormat=DataFormat.Default)]
        public List<Task> Tasks
        {
            get
            {
                return this._tasks;
            }
        }

        public class _ArenaShopRealMoneyAssistantValueType : TypeNameContainer<TaskConfig._ArenaShopRealMoneyAssistantValueType>
        {
            public const int GoodsId = 0;

            public static bool Initialize()
            {
                bool flag = false;
                return (flag & TypeNameContainer<TaskConfig._ArenaShopRealMoneyAssistantValueType>.RegisterType("GoodsId", 0, "GoodsId"));
            }
        }

        public class _DungeonAssistValueType : TypeNameContainer<TaskConfig._DungeonAssistValueType>
        {
            public const int Diffity = 0;

            public static bool Initialize()
            {
                bool flag = false;
                return (flag & TypeNameContainer<TaskConfig._DungeonAssistValueType>.RegisterType("Diffity", 0, "Diffity"));
            }
        }

        public class _GachaAssistValueType : TypeNameContainer<TaskConfig._GachaAssistValueType>
        {
            public const int GachaId = 0;

            public static bool Initialize()
            {
                bool flag = false;
                return (flag & TypeNameContainer<TaskConfig._GachaAssistValueType>.RegisterType("GachaId", 0, "GachaId"));
            }
        }

        public class _MonthCardAssistValueType : TypeNameContainer<TaskConfig._MonthCardAssistValueType>
        {
            public const int MonthCardId = 0;

            public static bool Initialize()
            {
                bool flag = false;
                return (flag & TypeNameContainer<TaskConfig._MonthCardAssistValueType>.RegisterType("MonthCardId", 0, "MonthCardId"));
            }
        }

        public class _SecretAssistValueType : TypeNameContainer<TaskConfig._SecretAssistValueType>
        {
            public const int CommonDungeonId = 2;
            public const int EasyDungeonId = 1;
            public const int ZoneId = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TaskConfig._SecretAssistValueType>.RegisterType("ZoneId", 0, "ZoneId");
                flag &= TypeNameContainer<TaskConfig._SecretAssistValueType>.RegisterType("EasyDungeonId", 1, "EasyDungeonId");
                return (flag & TypeNameContainer<TaskConfig._SecretAssistValueType>.RegisterType("CommonDungeonId", 2, "CommonDungeonId"));
            }
        }

        public class _ShopGoodsAssistantValueType : TypeNameContainer<TaskConfig._ShopGoodsAssistantValueType>
        {
            public const int GroupId = 0;

            public static bool Initialize()
            {
                bool flag = false;
                return (flag & TypeNameContainer<TaskConfig._ShopGoodsAssistantValueType>.RegisterType("GroupId", 0, "GroupId"));
            }
        }

        public class _TaskType : TypeNameContainer<TaskConfig._TaskType>
        {
            public const int AccumulatePurchaseAssistant = 0x11;
            public const int ArenaAssistant = 13;
            public const int ArenaShopRealMoneyAssistant = 0x1d;
            public const int AvatarIllustrationAssistant = 10;
            public const int BeastActiveAssistant = 0x2c;
            public const int BeastBreakthoughtAssistant = 0x2d;
            public const int BuyStaminaAssistant = 0x12;
            public const int CreateAccountRewardAssistant = 9;
            public const int DailySignAssistant = 3;
            public const int DanHomeReward = 0x27;
            public const int DungeonAchieveAssistant = 15;
            public const int DungeonCanCombatAssistant = 14;
            public const int DungeonCombatAssistant = 0x13;
            public const int DungeonStarRewardAssistant = 1;
            public const int EquipIllustrationAssistant = 11;
            public const int FixTimeRewardAssistant = 8;
            public const int FriendCampaignNotAchieveAssistant = 0x20;
            public const int FriendCampaignNotJoinAssistant = 0x1f;
            public const int FriendCampaignResetAchieveAssistant = 0x21;
            public const int FriendCampaignResetAllDeadAssistant = 0x22;
            public const int GachaAssistant = 2;
            public const int GuildConstructionAssisstant = 0x2a;
            public const int GuildFreeBossChallengeAssisstant = 0x29;
            public const int GuildMoveCountAssisstant = 40;
            public const int InviteCodeRewardAssistant = 0x2b;
            public const int LevelRewardAssistant = 6;
            public const int MarvellousAdventureNotJoinAssistant = 0x23;
            public const int MarvellousDelayRewardAssistant = 0x24;
            public const int MelaleucaDailyPassAssistant = 20;
            public const int MelaleucaWeekRankRewardAssistant = 0x1b;
            public const int MonthCardAssistant = 0x1a;
            public const int MysteryShopAssistant = 0x10;
            public const int QinInfoAssistant = 0x19;
            public const int RemedySignAssistant = 4;
            public const int SecretDungeonAssistant = 5;
            public const int ShopGoodsAssistant = 30;
            public const int SkillIllustrationAssistant = 12;
            public const int TavernAssistant = 7;
            public const int Unkonw = 0;
            public const int VipLevelGoodsAssistant = 0x1c;
            public const int WolfSmokeChallengeNotAchieveAssistant = 0x16;
            public const int WolfSmokeChallengeNotJoinAssistant = 0x15;
            public const int WolfSmokeResetAchieveAssistant = 0x17;
            public const int WolfSmokeResetNotAchieveAssistant = 0x18;
            public const int ZentiaGoods = 0x25;
            public const int ZentiaServerReward = 0x26;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("Unkonw", 0, "DinerRefreshType_Unkonw");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("DungeonStarRewardAssistant", 1, "DungeonStarRewardAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("GachaAssistant", 2, "GachaAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("DailySignAssistant", 3, "DailySignAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("RemedySignAssistant", 4, "RemedySignAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("SecretDungeonAssistant", 5, "SecretDungeonAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("LevelRewardAssistant", 6, "LevelRewardAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("TavernAssistant", 7, "TavernAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("FixTimeRewardAssistant", 8, "FixTimeRewardAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("CreateAccountRewardAssistant", 9, "CreateAccountRewardAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("AvatarIllustrationAssistant", 10, "AvatarIllustrationAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("EquipIllustrationAssistant", 11, "EquipIllustrationAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("SkillIllustrationAssistant", 12, "SkillIllustrationAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("ArenaAssistant", 13, "ArenaAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("DungeonCanCombatAssistant", 14, "DungeonCanCombatAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("DungeonAchieveAssistant", 15, "DungeonAchieveAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("MysteryShopAssistant", 0x10, "MysteryShopAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("AccumulatePurchaseAssistant", 0x11, "AccumulatePurchaseAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("BuyStaminaAssistant", 0x12, "BuyStaminaAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("DungeonCombatAssistant", 0x13, "DungeonCombatAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("MelaleucaDailyPassAssistant", 20, "MelaleucaDailyPassAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("WolfSmokeChallengeNotJoinAssistant", 0x15, "WolfSmokeChallengeNotJoinAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("WolfSmokeChallengeNotAchieveAssistant", 0x16, "WolfSmokeChallengeNotAchieveAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("WolfSmokeResetAchieveAssistant", 0x17, "WolfSmokeResetAchieveAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("WolfSmokeResetNotAchieveAssistant", 0x18, "WolfSmokeResetNotAchieveAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("QinInfoAssistant", 0x19, "QinInfoAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("MonthCardAssistant", 0x1a, "MonthCardAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("MelaleucaWeekRankRewardAssistant", 0x1b, "MelaleucaWeekRankRewardAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("VipLevelGoodsAssistant", 0x1c, "VipLevelGoodsAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("ArenaShopRealMoneyAssistant", 0x1d, "ArenaShopRealMoneyAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("ShopGoodsAssistant", 30, "ShopGoodsAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("FriendCampaignNotJoinAssistant", 0x1f, "FriendCampaignNotJoinAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("FriendCampaignNotAchieveAssistant", 0x20, "FriendCampaignNotAchieveAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("FriendCampaignResetAchieveAssistant", 0x21, "FriendCampaignResetAchieveAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("FriendCampaignResetAllDeadAssistant", 0x22, "FriendCampaignResetAllDeadAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("MarvellousAdventureNotJoinAssistant", 0x23, "MarvellousAdventureNotJoinAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("MarvellousDelayRewardAssistant", 0x24, "MarvellousDelayRewardAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("ZentiaGoods", 0x25, "ZentiaGoods");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("ZentiaServerReward", 0x26, "ZentiaServerReward");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("DanHomeReward", 0x27, "DanHomeReward");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("GuildMoveCountAssisstant", 40, "GuildMoveCountAssisstant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("GuildFreeBossChallengeAssisstant", 0x29, "GuildFreeBossChallengeAssisstant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("GuildConstructionAssisstant", 0x2a, "GuildConstructionAssisstant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("InviteCodeRewardAssistant", 0x2b, "InviteCodeRewardAssistant");
                flag &= TypeNameContainer<TaskConfig._TaskType>.RegisterType("BeastActiveAssistant", 0x2c, "BeastActiveAssistant");
                return (flag & TypeNameContainer<TaskConfig._TaskType>.RegisterType("BeastBreakthoughtAssistant", 0x2d, "BeastBreakthoughtAssistant"));
            }
        }

        [ProtoContract(Name="Task")]
        public class Task : IExtensible
        {
            private readonly List<int> _datas = new List<int>();
            private int _gotoUI;
            private bool _isOpen;
            private int _priority;
            private int _taskId;
            private int _taskType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, Name="datas", DataFormat=DataFormat.TwosComplement)]
            public List<int> Datas
            {
                get
                {
                    return this._datas;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="gotoUI", DataFormat=DataFormat.TwosComplement)]
            public int GotoUI
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

            [ProtoMember(7, IsRequired=false, Name="isOpen", DataFormat=DataFormat.Default), DefaultValue(false)]
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

            [ProtoMember(8, IsRequired=false, Name="priority", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(1, IsRequired=false, Name="taskId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int TaskId
            {
                get
                {
                    return this._taskId;
                }
                set
                {
                    this._taskId = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="taskType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int TaskType
            {
                get
                {
                    return this._taskType;
                }
                set
                {
                    this._taskType = value;
                }
            }
        }

        [ProtoContract(Name="TaskGuid")]
        public class TaskGuid : IExtensible
        {
            private string _attachConParent = "";
            private int _taskType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="attachConParent", DataFormat=DataFormat.Default), DefaultValue("")]
            public string AttachConParent
            {
                get
                {
                    return this._attachConParent;
                }
                set
                {
                    this._attachConParent = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="taskType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int TaskType
            {
                get
                {
                    return this._taskType;
                }
                set
                {
                    this._taskType = value;
                }
            }
        }
    }
}

