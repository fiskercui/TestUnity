namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="GuildConfig")]
    public class GuildConfig : Configuration, IExtensible
    {
        private int _announcementMaxLength;
        private int _applyShowMax;
        private int _changeLeaderVipLimit;
        private int _chatShowCount;
        private GuildConstruction _construction;
        private readonly List<Cost> _createCosts = new List<Cost>();
        private int _declarationMaxLength;
        private int _guildCountPerPage;
        private readonly List<GuildLevel> _guildLevels = new List<GuildLevel>();
        private readonly List<ClientServerCommon.MainType> _mainTypes = new List<ClientServerCommon.MainType>();
        private int _msgCountLimitPerDay;
        private long _msgCountRefreshTimePerDay;
        private int _msgDayLimit;
        private int _msgLengthLimit;
        private int _msgShowCount;
        private int _nameMaxLength;
        private int _newsShowCount;
        private int _roleIdLeader;
        private readonly List<Role> _roles = new List<Role>();
        private GuildTaskInfo _taskInfo;
        private Dictionary<int, ConstructionTask> constructionTaskMap = new Dictionary<int, ConstructionTask>();
        private IExtension extensionObject;
        private Dictionary<int, GuildOneTask> guildInvisibaleTaskMap = new Dictionary<int, GuildOneTask>();
        private Dictionary<int, GuildOneTask> guildTaskMap = new Dictionary<int, GuildOneTask>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (ConstructionTask task in this._construction.Tasks)
            {
                if (task != null)
                {
                    if (this.constructionTaskMap.ContainsKey(task.TaskId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey " + task.TaskId.ToString(), new object[0]);
                    }
                    else
                    {
                        this.constructionTaskMap.Add(task.TaskId, task);
                    }
                }
            }
            foreach (GuildOneTask task2 in this._taskInfo.Tasks)
            {
                if (task2 != null)
                {
                    if (this.guildTaskMap.ContainsKey(task2.TaskId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey " + task2.TaskId.ToString(), new object[0]);
                    }
                    else
                    {
                        this.guildTaskMap.Add(task2.TaskId, task2);
                    }
                }
            }
            foreach (GuildOneTask task3 in this._taskInfo.InvisibleTasks)
            {
                if (task3 != null)
                {
                    if (this.guildInvisibaleTaskMap.ContainsKey(task3.TaskId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey " + task3.TaskId.ToString(), new object[0]);
                    }
                    else
                    {
                        this.guildInvisibaleTaskMap.Add(task3.TaskId, task3);
                    }
                }
            }
            this._construction.init();
        }

        public ConstructionTask GetConstructionTaskById(int id)
        {
            if (this.constructionTaskMap.ContainsKey(id))
            {
                return this.constructionTaskMap[id];
            }
            return null;
        }

        public GuildLevel GetGuildLevelByLevel(int level)
        {
            foreach (GuildLevel level2 in this._guildLevels)
            {
                if (level2.Level == level)
                {
                    return level2;
                }
            }
            return null;
        }

        public GuildOneTask GetGuildTaskById(int id)
        {
            if (this.guildTaskMap.ContainsKey(id))
            {
                return this.guildTaskMap[id];
            }
            return null;
        }

        public GuildOneTask GetInvisibleGuildTaskById(int id)
        {
            if (this.guildInvisibaleTaskMap.ContainsKey(id))
            {
                return this.guildInvisibaleTaskMap[id];
            }
            return null;
        }

        public ClientServerCommon.MainType GetMainTypeByGuideType(int type)
        {
            foreach (ClientServerCommon.MainType type2 in this._mainTypes)
            {
                foreach (ClientServerCommon.SubType type3 in type2.subTypes)
                {
                    if (type3.assetIconType == type)
                    {
                        return type2;
                    }
                }
            }
            return null;
        }

        public Role GetRoleByRoleId(int roleId)
        {
            foreach (Role role in this._roles)
            {
                if (role.Id == roleId)
                {
                    return role;
                }
            }
            return null;
        }

        public Role GetRoleByRoleType(int roleType)
        {
            if ((roleType >= 0) && (roleType < this._roles.Count))
            {
                return this._roles[roleType];
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _RoleRightType.Initialize();
            _TaskType.Initialize();
            _GuideType.Initialize();
        }

        private ConstructionTask LoadConstructionTaskFromXml(SecurityElement element)
        {
            ConstructionTask task = new ConstructionTask {
                TaskId = StrParser.ParseHexInt(element.Attribute("TaskId"), 0),
                TaskName = StrParser.ParseStr(element.Attribute("TaskName"), ""),
                TaskQuality = StrParser.ParseDecInt(element.Attribute("TaskQuality"), 0),
                TaskIconId = StrParser.ParseHexInt(element.Attribute("TaskIcon"), 0),
                TaskDesc = StrParser.ParseStr(element.Attribute("TaskDesc"), ""),
                GuildConstruct = StrParser.ParseDecInt(element.Attribute("GuildConstruct"), 0),
                PlayerContribution = StrParser.ParseDecInt(element.Attribute("PlayerContribution"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "OneClickCompletedCost")
                        {
                            if (tag == "CostAsset")
                            {
                                goto Label_012A;
                            }
                            if (tag == "ItemEx")
                            {
                                goto Label_0138;
                            }
                            if (tag == "Reward")
                            {
                                goto Label_0146;
                            }
                        }
                        else
                        {
                            task.OneClickCompletedCosts.Add(Cost.LoadFromXml(element2));
                        }
                    }
                    continue;
                Label_012A:
                    task.CostAsset = CostAsset.LoadCostAssetFromXml(element2);
                    continue;
                Label_0138:
                    task.ItemEx = ItemEx.LoadItemExFromXml(element2);
                    continue;
                Label_0146:
                    task.Rewards.Add(Reward.LoadFromXml(element2));
                }
            }
            return task;
        }

        private Counter LoadCounterFromXml(SecurityElement element)
        {
            Counter counter = new Counter {
                CounterId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                Priority = StrParser.ParseDecInt(element.Attribute("Priority"), 0),
                ActiveThreshold = StrParser.ParseDecInt(element.Attribute("ActiveThreshold"), 0),
                ActiveDelta = StrParser.ParseDecInt(element.Attribute("ActiveDelta"), 0),
                MaxActiveCount = StrParser.ParseDecInt(element.Attribute("MaxActiveCount"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Task")
                    {
                        counter.Tasks.Add(this.LoadTaskMiniFromXml(element2));
                    }
                }
            }
            return counter;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "GuildConfig")
            {
                this._announcementMaxLength = StrParser.ParseDecInt(element.Attribute("AnnouncementMaxLength"), 0);
                this._nameMaxLength = StrParser.ParseDecInt(element.Attribute("NameMaxLength"), 0);
                this._guildCountPerPage = StrParser.ParseDecInt(element.Attribute("GuildCountPerPage"), 0);
                this._msgCountLimitPerDay = StrParser.ParseDecInt(element.Attribute("MsgCountLimitPerDay"), 0);
                this._msgCountRefreshTimePerDay = StrParser.ParseDateTime(element.Attribute("MsgCountRefreshTimePerDay"));
                this._msgDayLimit = StrParser.ParseDecInt(element.Attribute("MsgDayLimit"), 0);
                this._msgLengthLimit = StrParser.ParseDecInt(element.Attribute("MsgLengthLimit"), 0);
                this._newsShowCount = StrParser.ParseDecInt(element.Attribute("NewsShowCount"), 0);
                this._msgShowCount = StrParser.ParseDecInt(element.Attribute("MsgShowCount"), 0);
                this._chatShowCount = StrParser.ParseDecInt(element.Attribute("ChatShowCount"), 0);
                this._applyShowMax = StrParser.ParseDecInt(element.Attribute("ApplyShowMax"), 0);
                this._declarationMaxLength = StrParser.ParseDecInt(element.Attribute("DeclarationMaxLength"), 0);
                this._changeLeaderVipLimit = StrParser.ParseDecInt(element.Attribute("ChangeLeaderVipLimit"), 0);
                this._roleIdLeader = StrParser.ParseHexInt(element.Attribute("RoleIdLeader"), 0);
                this._construction = new GuildConstruction();
                this._taskInfo = new GuildTaskInfo();
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag != "CreateCost")
                            {
                                if (tag == "GuildLevel")
                                {
                                    goto Label_0202;
                                }
                                if (tag == "Role")
                                {
                                    goto Label_020B;
                                }
                                if (tag == "Construction")
                                {
                                    goto Label_0214;
                                }
                                if (tag == "GuildTask")
                                {
                                    goto Label_021D;
                                }
                                if (tag == "MainTypeSet")
                                {
                                    goto Label_0226;
                                }
                            }
                            else
                            {
                                this._createCosts.Add(Cost.LoadFromXml(element2));
                            }
                        }
                        continue;
                    Label_0202:
                        this.LoadGuildLevelFromXml(element2);
                        continue;
                    Label_020B:
                        this.LoadGuildRoleFromXml(element2);
                        continue;
                    Label_0214:
                        this.LoadGuildConstructionFromXml(element2);
                        continue;
                    Label_021D:
                        this.LoadGuildTaskFromXml(element2);
                        continue;
                    Label_0226:
                        this.LoadMainTypeSetFromXml(element2);
                    }
                }
            }
        }

        private void LoadGuildConstructionFromXml(SecurityElement element)
        {
            this._construction.WaitTime = StrParser.ParseDecInt(element.Attribute("WaitTime"), 0);
            this._construction.PlayerMaxCompletedTaskPerDay = StrParser.ParseDecInt(element.Attribute("PlayerMaxCompletedTaskPerDay"), 0);
            this._construction.RefreshTimePerDay = StrParser.ParseDateTime(element.Attribute("RefreshTimePerDay"));
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    switch (element2.Tag)
                    {
                        case "RefreshCost":
                            this._construction.RefershCosts.Add(Cost.LoadFromXml(element2));
                            break;

                        case "DefaultTaskGroup":
                            foreach (SecurityElement element3 in element2.Children)
                            {
                                this._construction.DefaultTaskGroup.Add(this.LoadTaskMiniFromXml(element3));
                            }
                            break;

                        case "DefaultRefreshTaskGroup":
                            foreach (SecurityElement element4 in element2.Children)
                            {
                                this._construction.DefaultRefreshTaskGroup.Add(this.LoadTaskMiniFromXml(element4));
                            }
                            break;

                        case "LastTaskGroup":
                            foreach (SecurityElement element5 in element2.Children)
                            {
                                this._construction.LastTaskGroup.Add(this.LoadTaskMiniFromXml(element5));
                            }
                            break;

                        case "CostRefreshTaskGroup":
                            foreach (SecurityElement element6 in element2.Children)
                            {
                                this._construction.CostRefreshTaskGroup.Add(this.LoadTaskMiniFromXml(element6));
                            }
                            break;

                        case "ConstructionCounter":
                            this._construction.Counters.Add(this.LoadCounterFromXml(element2));
                            break;

                        case "ConstructionTask":
                            this._construction.Tasks.Add(this.LoadConstructionTaskFromXml(element2));
                            break;
                    }
                }
            }
        }

        private void LoadGuildLevelFromXml(SecurityElement element)
        {
            GuildLevel item = new GuildLevel {
                Level = StrParser.ParseDecInt(element.Attribute("Level"), 0),
                MemberMax = StrParser.ParseDecInt(element.Attribute("MemberMax"), 0),
                NextLevelNeedConstruct = StrParser.ParseDecInt(element.Attribute("NextLevelNeedConstruct"), 0),
                MaxConstructionCountPerDay = StrParser.ParseDecInt(element.Attribute("MaxConstructionCountPerDay"), 0),
                StageTalentPointCount = StrParser.ParseDecInt(element.Attribute("StageTalentPointCount"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "CountLimit")
                    {
                        RoleLimit limit = new RoleLimit {
                            RoleId = StrParser.ParseHexInt(element2.Attribute("RoleId"), 0),
                            CountLimit = StrParser.ParseDecInt(element2.Attribute("Count"), 0)
                        };
                        item.RoleLimits.Add(limit);
                    }
                }
            }
            this._guildLevels.Add(item);
        }

        private GuildOneTask LoadGuildOneTaskFromXml(SecurityElement element)
        {
            GuildOneTask task = new GuildOneTask {
                TaskId = StrParser.ParseHexInt(element.Attribute("TaskId"), 0),
                TaskName = StrParser.ParseStr(element.Attribute("TaskName"), ""),
                TaskQuality = StrParser.ParseDecInt(element.Attribute("TaskQuality"), 0),
                TaskIconId = StrParser.ParseHexInt(element.Attribute("TaskIcon"), 0),
                TaskType = TypeNameContainer<_TaskType>.Parse(element.Attribute("TaskType"), 0),
                Total = StrParser.ParseDecInt(element.Attribute("Total"), 0),
                TaskParamList = StrParser.ParseStr(element.Attribute("ParamList"), ""),
                TaskDesc = StrParser.ParseStr(element.Attribute("TaskDesc"), ""),
                CompleteLimitPerDay = StrParser.ParseDecInt(element.Attribute("CompleteLimitPerDay"), 0),
                TaskExtRewardDesc = StrParser.ParseStr(element.Attribute("TaskExtRewardDesc"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Reward")
                    {
                        task.Rewards.Add(Reward.LoadFromXml(element2));
                    }
                    if (element2.Tag == "ExtReward")
                    {
                        task.ExtReward = Reward.LoadFromXml(element2);
                    }
                }
            }
            return task;
        }

        private void LoadGuildRoleFromXml(SecurityElement element)
        {
            Role item = new Role {
                Id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                Name = StrParser.ParseStr(element.Attribute("Name"), ""),
                CanOffered = StrParser.ParseBool(element.Attribute("CanOffered"), false),
                CanDownRole = StrParser.ParseBool(element.Attribute("CanDownRole"), true),
                Color = StrParser.ParseStr(element.Attribute("Color"), ""),
                SortIndex = StrParser.ParseDecInt(element.Attribute("SortIndex"), 0),
                AutoSort = StrParser.ParseBool(element.Attribute("AutoSort"), false)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Right")
                    {
                        int num = TypeNameContainer<_RoleRightType>.Parse(element2.Text, 0);
                        if (!item.Rights.Contains(num))
                        {
                            item.Rights.Add(num);
                        }
                    }
                }
            }
            this._roles.Add(item);
        }

        private void LoadGuildTaskFromXml(SecurityElement element)
        {
            this._taskInfo.MaxCompletedTaskPerDay = StrParser.ParseDecInt(element.Attribute("MaxCompletedTaskPerDay"), 0);
            this._taskInfo.FreeDiceCountPerDay = StrParser.ParseDecInt(element.Attribute("FreeDiceCountPerDay"), 0);
            this._taskInfo.FreeRefreshCountPerDay = StrParser.ParseDecInt(element.Attribute("FreeRefreshCountPerDay"), 0);
            this._taskInfo.RefreshTimePerDay = StrParser.ParseDateTime(element.Attribute("RefreshTimePerDay"));
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "DiceIncreaseCost")
                        {
                            if (tag == "RefreshIncreaseCost")
                            {
                                goto Label_010E;
                            }
                            if (tag == "TaskRefresh")
                            {
                                goto Label_0129;
                            }
                            if (tag == "TaskGroup")
                            {
                                goto Label_0145;
                            }
                            if (tag == "InvisibaleTaskGroup")
                            {
                                goto Label_0198;
                            }
                        }
                        else
                        {
                            this._taskInfo.DiceIncreaseCosts.Add(IncreaseCost.LoadFromXml(element2));
                        }
                    }
                    continue;
                Label_010E:
                    this._taskInfo.RefreshIncreaseCosts.Add(IncreaseCost.LoadFromXml(element2));
                    continue;
                Label_0129:
                    this._taskInfo.GuildTaskRefreshes.Add(this.LoadGuildTaskRefreshFromXml(element2));
                    continue;
                Label_0145:
                    foreach (SecurityElement element3 in element2.Children)
                    {
                        this._taskInfo.Tasks.Add(this.LoadGuildOneTaskFromXml(element3));
                    }
                    continue;
                Label_0198:
                    foreach (SecurityElement element4 in element2.Children)
                    {
                        this._taskInfo.InvisibleTasks.Add(this.LoadGuildOneTaskFromXml(element4));
                    }
                }
            }
        }

        private GuildTaskRefresh LoadGuildTaskRefreshFromXml(SecurityElement element)
        {
            GuildTaskRefresh refresh = new GuildTaskRefresh {
                CompleteCount = StrParser.ParseDecInt(element.Attribute("CompleteCount"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "DefaultRefreshTasks")
                        {
                            if (tag == "CostRefreshTasks")
                            {
                                goto Label_00D5;
                            }
                            if (tag == "TaskCounter")
                            {
                                goto Label_0123;
                            }
                        }
                        else
                        {
                            foreach (SecurityElement element3 in element2.Children)
                            {
                                refresh.DefaultRefreshTasks.Add(this.LoadTaskMiniFromXml(element3));
                            }
                        }
                    }
                    continue;
                Label_00D5:
                    foreach (SecurityElement element4 in element2.Children)
                    {
                        refresh.CostRefreshTasks.Add(this.LoadTaskMiniFromXml(element4));
                    }
                    continue;
                Label_0123:
                    refresh.Counter = this.LoadCounterFromXml(element2);
                }
            }
            return refresh;
        }

        private ClientServerCommon.MainType LoadMainTypeFromXml(SecurityElement element)
        {
            ClientServerCommon.MainType type = new ClientServerCommon.MainType {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    ClientServerCommon.SubType item = this.LoadSubTypeFromXml(element2);
                    if (item != null)
                    {
                        type.subTypes.Add(item);
                    }
                }
            }
            return type;
        }

        private void LoadMainTypeSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "MainType")
                    {
                        this._mainTypes.Add(this.LoadMainTypeFromXml(element2));
                    }
                }
            }
        }

        private ClientServerCommon.SubType LoadSubTypeFromXml(SecurityElement element)
        {
            return new ClientServerCommon.SubType { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true),
                desc = StrParser.ParseStr(element.Attribute("Desc"), "", true),
                assetIconId = StrParser.ParseHexInt(element.Attribute("AssetIconId"), 0),
                assetIconType = TypeNameContainer<_GuideType>.Parse(element.Attribute("AssetIconType"), 0)
            };
        }

        private TaskMini LoadTaskMiniFromXml(SecurityElement element)
        {
            return new TaskMini { 
                TaskId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                TaskWeight = StrParser.ParseDecInt(element.Attribute("Weight"), 0)
            };
        }

        [ProtoMember(1, IsRequired=false, Name="announcementMaxLength", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int AnnouncementMaxLength
        {
            get
            {
                return this._announcementMaxLength;
            }
            set
            {
                this._announcementMaxLength = value;
            }
        }

        [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="applyShowMax", DataFormat=DataFormat.TwosComplement)]
        public int ApplyShowMax
        {
            get
            {
                return this._applyShowMax;
            }
            set
            {
                this._applyShowMax = value;
            }
        }

        [DefaultValue(0), ProtoMember(13, IsRequired=false, Name="changeLeaderVipLimit", DataFormat=DataFormat.TwosComplement)]
        public int ChangeLeaderVipLimit
        {
            get
            {
                return this._changeLeaderVipLimit;
            }
            set
            {
                this._changeLeaderVipLimit = value;
            }
        }

        [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="chatShowCount", DataFormat=DataFormat.TwosComplement)]
        public int ChatShowCount
        {
            get
            {
                return this._chatShowCount;
            }
            set
            {
                this._chatShowCount = value;
            }
        }

        [ProtoMember(0x11, IsRequired=false, Name="construction", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public GuildConstruction Construction
        {
            get
            {
                return this._construction;
            }
            set
            {
                this._construction = value;
            }
        }

        [ProtoMember(0x10, Name="createCosts", DataFormat=DataFormat.Default)]
        public List<Cost> CreateCosts
        {
            get
            {
                return this._createCosts;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="declarationMaxLength", DataFormat=DataFormat.TwosComplement)]
        public int DeclarationMaxLength
        {
            get
            {
                return this._declarationMaxLength;
            }
            set
            {
                this._declarationMaxLength = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="guildCountPerPage", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int GuildCountPerPage
        {
            get
            {
                return this._guildCountPerPage;
            }
            set
            {
                this._guildCountPerPage = value;
            }
        }

        [ProtoMember(14, Name="guildLevels", DataFormat=DataFormat.Default)]
        public List<GuildLevel> GuildLevels
        {
            get
            {
                return this._guildLevels;
            }
        }

        [ProtoMember(0x13, Name="mainTypes", DataFormat=DataFormat.Default)]
        public List<ClientServerCommon.MainType> MainTypes
        {
            get
            {
                return this._mainTypes;
            }
        }

        public int MaxGuildLevel
        {
            get
            {
                int num = 0;
                foreach (GuildLevel level in this._guildLevels)
                {
                    if (level.Level > num)
                    {
                        num = level.Level;
                    }
                }
                return num;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="msgCountLimitPerDay", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int MsgCountLimitPerDay
        {
            get
            {
                return this._msgCountLimitPerDay;
            }
            set
            {
                this._msgCountLimitPerDay = value;
            }
        }

        public DateTime MsgCountRefreshDateTime
        {
            get
            {
                return new DateTime(this._msgCountRefreshTimePerDay * 0x2710L);
            }
        }

        [ProtoMember(6, IsRequired=false, Name="msgCountRefreshTimePerDay", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long MsgCountRefreshTimePerDay
        {
            get
            {
                return this._msgCountRefreshTimePerDay;
            }
            set
            {
                this._msgCountRefreshTimePerDay = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="msgDayLimit", DataFormat=DataFormat.TwosComplement)]
        public int MsgDayLimit
        {
            get
            {
                return this._msgDayLimit;
            }
            set
            {
                this._msgDayLimit = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="msgLengthLimit", DataFormat=DataFormat.TwosComplement)]
        public int MsgLengthLimit
        {
            get
            {
                return this._msgLengthLimit;
            }
            set
            {
                this._msgLengthLimit = value;
            }
        }

        [DefaultValue(0), ProtoMember(10, IsRequired=false, Name="msgShowCount", DataFormat=DataFormat.TwosComplement)]
        public int MsgShowCount
        {
            get
            {
                return this._msgShowCount;
            }
            set
            {
                this._msgShowCount = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="nameMaxLength", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int NameMaxLength
        {
            get
            {
                return this._nameMaxLength;
            }
            set
            {
                this._nameMaxLength = value;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="newsShowCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int NewsShowCount
        {
            get
            {
                return this._newsShowCount;
            }
            set
            {
                this._newsShowCount = value;
            }
        }

        [ProtoMember(20, IsRequired=false, Name="roleIdLeader", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int RoleIdLeader
        {
            get
            {
                return this._roleIdLeader;
            }
            set
            {
                this._roleIdLeader = value;
            }
        }

        [ProtoMember(15, Name="roles", DataFormat=DataFormat.Default)]
        public List<Role> Roles
        {
            get
            {
                return this._roles;
            }
        }

        [ProtoMember(0x12, IsRequired=false, Name="taskInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public GuildTaskInfo TaskInfo
        {
            get
            {
                return this._taskInfo;
            }
            set
            {
                this._taskInfo = value;
            }
        }

        public class _GuideType : TypeNameContainer<GuildConfig._GuideType>
        {
            public const int Construct = 6;
            public const int ExchangeShopGuide = 4;
            public const int GuildStage = 7;
            public const int InvisibleTask = 1;
            public const int LevelGuide = 5;
            public const int PrivateShopGuide = 3;
            public const int PublicShopGuide = 2;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildConfig._GuideType>.RegisterType("InvisibleTask", 1);
                flag &= TypeNameContainer<GuildConfig._GuideType>.RegisterType("PublicShopGuide", 2);
                flag &= TypeNameContainer<GuildConfig._GuideType>.RegisterType("PrivateShopGuide", 3);
                flag &= TypeNameContainer<GuildConfig._GuideType>.RegisterType("ExchangeShopGuide", 4);
                flag &= TypeNameContainer<GuildConfig._GuideType>.RegisterType("LevelGuide", 5);
                flag &= TypeNameContainer<GuildConfig._GuideType>.RegisterType("Construct", 6);
                return (flag & TypeNameContainer<GuildConfig._GuideType>.RegisterType("GuildStage", 7));
            }
        }

        public class _RoleRightType : TypeNameContainer<GuildConfig._RoleRightType>
        {
            public const int ChangeAnnouncement = 4;
            public const int ChangeDeclaration = 6;
            public const int ChangeLeader = 7;
            public const int ChangeRoleId = 3;
            public const int HandResetStage = 10;
            public const int KickMember = 2;
            public const int Quit = 9;
            public const int ResetBoss = 5;
            public const int SetAutoEnter = 8;
            public const int StageTalent = 11;
            public const int UnKnow = 0;
            public const int ViewApply = 1;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("ViewApply", 1);
                flag &= TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("KickMember", 2);
                flag &= TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("ChangeRoleId", 3);
                flag &= TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("ChangeAnnouncement", 4);
                flag &= TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("ResetBoss", 5);
                flag &= TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("ChangeDeclaration", 6);
                flag &= TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("ChangeLeader", 7);
                flag &= TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("SetAutoEnter", 8);
                flag &= TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("Quit", 9);
                flag &= TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("HandResetStage", 10);
                return (flag & TypeNameContainer<GuildConfig._RoleRightType>.RegisterType("StageTalent", 11));
            }
        }

        public class _TaskType : TypeNameContainer<GuildConfig._TaskType>
        {
            public const int Count = 1;
            public const int Same = 2;
            public const int SumGroup = 4;
            public const int SumRange = 3;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildConfig._TaskType>.RegisterType("Count", 1);
                flag &= TypeNameContainer<GuildConfig._TaskType>.RegisterType("Same", 2);
                flag &= TypeNameContainer<GuildConfig._TaskType>.RegisterType("SumRange", 3);
                return (flag & TypeNameContainer<GuildConfig._TaskType>.RegisterType("SumGroup", 4));
            }
        }

        [ProtoContract(Name="ConstructionTask")]
        public class ConstructionTask : IExtensible
        {
            private ClientServerCommon.CostAsset _costAsset;
            private int _guildConstruct;
            private ClientServerCommon.ItemEx _itemEx;
            private readonly List<Cost> _oneClickCompletedCosts = new List<Cost>();
            private int _playerContribution;
            private readonly List<Reward> _rewards = new List<Reward>();
            private string _taskDesc = "";
            private int _taskIconId;
            private int _taskId;
            private string _taskName = "";
            private int _taskQuality;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(7, IsRequired=false, Name="costAsset", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public ClientServerCommon.CostAsset CostAsset
            {
                get
                {
                    return this._costAsset;
                }
                set
                {
                    this._costAsset = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="guildConstruct", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int GuildConstruct
            {
                get
                {
                    return this._guildConstruct;
                }
                set
                {
                    this._guildConstruct = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="itemEx", DataFormat=DataFormat.Default)]
            public ClientServerCommon.ItemEx ItemEx
            {
                get
                {
                    return this._itemEx;
                }
                set
                {
                    this._itemEx = value;
                }
            }

            [ProtoMember(6, Name="oneClickCompletedCosts", DataFormat=DataFormat.Default)]
            public List<Cost> OneClickCompletedCosts
            {
                get
                {
                    return this._oneClickCompletedCosts;
                }
            }

            [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="playerContribution", DataFormat=DataFormat.TwosComplement)]
            public int PlayerContribution
            {
                get
                {
                    return this._playerContribution;
                }
                set
                {
                    this._playerContribution = value;
                }
            }

            [ProtoMember(9, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> Rewards
            {
                get
                {
                    return this._rewards;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="taskDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string TaskDesc
            {
                get
                {
                    return this._taskDesc;
                }
                set
                {
                    this._taskDesc = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="taskIconId", DataFormat=DataFormat.TwosComplement)]
            public int TaskIconId
            {
                get
                {
                    return this._taskIconId;
                }
                set
                {
                    this._taskIconId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="taskId", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(2, IsRequired=false, Name="taskName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string TaskName
            {
                get
                {
                    return this._taskName;
                }
                set
                {
                    this._taskName = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="taskQuality", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int TaskQuality
            {
                get
                {
                    return this._taskQuality;
                }
                set
                {
                    this._taskQuality = value;
                }
            }
        }

        [ProtoContract(Name="Counter")]
        public class Counter : IExtensible
        {
            private int _activeDelta;
            private int _activeThreshold;
            private int _counterId;
            private int _maxActiveCount;
            private int _priority;
            private readonly List<GuildConfig.TaskMini> _tasks = new List<GuildConfig.TaskMini>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, IsRequired=false, Name="activeDelta", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ActiveDelta
            {
                get
                {
                    return this._activeDelta;
                }
                set
                {
                    this._activeDelta = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="activeThreshold", DataFormat=DataFormat.TwosComplement)]
            public int ActiveThreshold
            {
                get
                {
                    return this._activeThreshold;
                }
                set
                {
                    this._activeThreshold = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="counterId", DataFormat=DataFormat.TwosComplement)]
            public int CounterId
            {
                get
                {
                    return this._counterId;
                }
                set
                {
                    this._counterId = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="maxActiveCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MaxActiveCount
            {
                get
                {
                    return this._maxActiveCount;
                }
                set
                {
                    this._maxActiveCount = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="priority", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(6, Name="tasks", DataFormat=DataFormat.Default)]
            public List<GuildConfig.TaskMini> Tasks
            {
                get
                {
                    return this._tasks;
                }
            }
        }

        [ProtoContract(Name="GuildConstruction")]
        public class GuildConstruction : IExtensible
        {
            private readonly List<GuildConfig.TaskMini> _costRefreshTaskGroup = new List<GuildConfig.TaskMini>();
            private readonly List<GuildConfig.Counter> _counters = new List<GuildConfig.Counter>();
            private readonly List<GuildConfig.TaskMini> _defaultRefreshTaskGroup = new List<GuildConfig.TaskMini>();
            private readonly List<GuildConfig.TaskMini> _defaultTaskGroup = new List<GuildConfig.TaskMini>();
            private readonly List<GuildConfig.TaskMini> _lastTaskGroup = new List<GuildConfig.TaskMini>();
            private int _playerMaxCompletedTaskPerDay;
            private readonly List<Cost> _refershCosts = new List<Cost>();
            private long _refreshTimePerDay;
            private readonly List<GuildConfig.ConstructionTask> _tasks = new List<GuildConfig.ConstructionTask>();
            private long _waitTime;
            private Dictionary<int, GuildConfig.Counter> counterMap = new Dictionary<int, GuildConfig.Counter>();
            private IExtension extensionObject;

            public GuildConfig.Counter GetCounterById(int id)
            {
                if (this.counterMap.ContainsKey(id))
                {
                    return this.counterMap[id];
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            public void init()
            {
                foreach (GuildConfig.Counter counter in this._counters)
                {
                    if (counter != null)
                    {
                        if (this.counterMap.ContainsKey(counter.CounterId))
                        {
                            Logger.Error(base.GetType().Name + " ContainsKey " + counter.CounterId.ToString(), new object[0]);
                        }
                        else
                        {
                            this.counterMap.Add(counter.CounterId, counter);
                        }
                    }
                }
            }

            [ProtoMember(7, Name="costRefreshTaskGroup", DataFormat=DataFormat.Default)]
            public List<GuildConfig.TaskMini> CostRefreshTaskGroup
            {
                get
                {
                    return this._costRefreshTaskGroup;
                }
            }

            [ProtoMember(8, Name="counters", DataFormat=DataFormat.Default)]
            public List<GuildConfig.Counter> Counters
            {
                get
                {
                    return this._counters;
                }
            }

            [ProtoMember(5, Name="defaultRefreshTaskGroup", DataFormat=DataFormat.Default)]
            public List<GuildConfig.TaskMini> DefaultRefreshTaskGroup
            {
                get
                {
                    return this._defaultRefreshTaskGroup;
                }
            }

            [ProtoMember(4, Name="defaultTaskGroup", DataFormat=DataFormat.Default)]
            public List<GuildConfig.TaskMini> DefaultTaskGroup
            {
                get
                {
                    return this._defaultTaskGroup;
                }
            }

            [ProtoMember(6, Name="lastTaskGroup", DataFormat=DataFormat.Default)]
            public List<GuildConfig.TaskMini> LastTaskGroup
            {
                get
                {
                    return this._lastTaskGroup;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="playerMaxCompletedTaskPerDay", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int PlayerMaxCompletedTaskPerDay
            {
                get
                {
                    return this._playerMaxCompletedTaskPerDay;
                }
                set
                {
                    this._playerMaxCompletedTaskPerDay = value;
                }
            }

            [ProtoMember(3, Name="refershCosts", DataFormat=DataFormat.Default)]
            public List<Cost> RefershCosts
            {
                get
                {
                    return this._refershCosts;
                }
            }

            public DateTime RefreshDateTime
            {
                get
                {
                    return new DateTime(this._refreshTimePerDay * 0x2710L);
                }
            }

            [ProtoMember(10, IsRequired=false, Name="refreshTimePerDay", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
            public long RefreshTimePerDay
            {
                get
                {
                    return this._refreshTimePerDay;
                }
                set
                {
                    this._refreshTimePerDay = value;
                }
            }

            [ProtoMember(9, Name="tasks", DataFormat=DataFormat.Default)]
            public List<GuildConfig.ConstructionTask> Tasks
            {
                get
                {
                    return this._tasks;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="waitTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
            public long WaitTime
            {
                get
                {
                    return this._waitTime;
                }
                set
                {
                    this._waitTime = value;
                }
            }
        }

        [ProtoContract(Name="GuildLevel")]
        public class GuildLevel : IExtensible
        {
            private int _level;
            private int _maxConstructionCountPerDay;
            private int _memberMax;
            private int _nextLevelNeedConstruct;
            private readonly List<GuildConfig.RoleLimit> _roleLimits = new List<GuildConfig.RoleLimit>();
            private int _stageTalentPointCount;
            private IExtension extensionObject;

            public int GetRoleLimitCoutByRoleId(int roleId)
            {
                foreach (GuildConfig.RoleLimit limit in this._roleLimits)
                {
                    if (limit.RoleId == roleId)
                    {
                        return limit.CountLimit;
                    }
                }
                return 0;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="maxConstructionCountPerDay", DataFormat=DataFormat.TwosComplement)]
            public int MaxConstructionCountPerDay
            {
                get
                {
                    return this._maxConstructionCountPerDay;
                }
                set
                {
                    this._maxConstructionCountPerDay = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="memberMax", DataFormat=DataFormat.TwosComplement)]
            public int MemberMax
            {
                get
                {
                    return this._memberMax;
                }
                set
                {
                    this._memberMax = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="nextLevelNeedConstruct", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int NextLevelNeedConstruct
            {
                get
                {
                    return this._nextLevelNeedConstruct;
                }
                set
                {
                    this._nextLevelNeedConstruct = value;
                }
            }

            [ProtoMember(4, Name="roleLimits", DataFormat=DataFormat.Default)]
            public List<GuildConfig.RoleLimit> RoleLimits
            {
                get
                {
                    return this._roleLimits;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="stageTalentPointCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int StageTalentPointCount
            {
                get
                {
                    return this._stageTalentPointCount;
                }
                set
                {
                    this._stageTalentPointCount = value;
                }
            }
        }

        [ProtoContract(Name="GuildOneTask")]
        public class GuildOneTask : IExtensible
        {
            private int _completeLimitPerDay;
            private Reward _extReward;
            private readonly List<Reward> _rewards = new List<Reward>();
            private string _taskDesc = "";
            private string _taskExtRewardDesc = "";
            private int _taskIconId;
            private int _taskId;
            private string _taskName = "";
            private string _taskParamList = "";
            private int _taskQuality;
            private int _taskType;
            private int _total;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(10, IsRequired=false, Name="completeLimitPerDay", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CompleteLimitPerDay
            {
                get
                {
                    return this._completeLimitPerDay;
                }
                set
                {
                    this._completeLimitPerDay = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(12, IsRequired=false, Name="extReward", DataFormat=DataFormat.Default)]
            public Reward ExtReward
            {
                get
                {
                    return this._extReward;
                }
                set
                {
                    this._extReward = value;
                }
            }

            [ProtoMember(9, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> Rewards
            {
                get
                {
                    return this._rewards;
                }
            }

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="taskDesc", DataFormat=DataFormat.Default)]
            public string TaskDesc
            {
                get
                {
                    return this._taskDesc;
                }
                set
                {
                    this._taskDesc = value;
                }
            }

            [ProtoMember(11, IsRequired=false, Name="taskExtRewardDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string TaskExtRewardDesc
            {
                get
                {
                    return this._taskExtRewardDesc;
                }
                set
                {
                    this._taskExtRewardDesc = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="taskIconId", DataFormat=DataFormat.TwosComplement)]
            public int TaskIconId
            {
                get
                {
                    return this._taskIconId;
                }
                set
                {
                    this._taskIconId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="taskId", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(2, IsRequired=false, Name="taskName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string TaskName
            {
                get
                {
                    return this._taskName;
                }
                set
                {
                    this._taskName = value;
                }
            }

            [DefaultValue(""), ProtoMember(8, IsRequired=false, Name="taskParamList", DataFormat=DataFormat.Default)]
            public string TaskParamList
            {
                get
                {
                    return this._taskParamList;
                }
                set
                {
                    this._taskParamList = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="taskQuality", DataFormat=DataFormat.TwosComplement)]
            public int TaskQuality
            {
                get
                {
                    return this._taskQuality;
                }
                set
                {
                    this._taskQuality = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="taskType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(7, IsRequired=false, Name="total", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Total
            {
                get
                {
                    return this._total;
                }
                set
                {
                    this._total = value;
                }
            }
        }

        [ProtoContract(Name="GuildTaskInfo")]
        public class GuildTaskInfo : IExtensible
        {
            private readonly List<IncreaseCost> _diceIncreaseCosts = new List<IncreaseCost>();
            private int _freeDiceCountPerDay;
            private int _freeRefreshCountPerDay;
            private readonly List<GuildConfig.GuildTaskRefresh> _guildTaskRefreshes = new List<GuildConfig.GuildTaskRefresh>();
            private readonly List<GuildConfig.GuildOneTask> _invisibleTasks = new List<GuildConfig.GuildOneTask>();
            private int _maxCompletedTaskPerDay;
            private readonly List<IncreaseCost> _refreshIncreaseCosts = new List<IncreaseCost>();
            private long _refreshTimePerDay;
            private readonly List<GuildConfig.GuildOneTask> _tasks = new List<GuildConfig.GuildOneTask>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, Name="diceIncreaseCosts", DataFormat=DataFormat.Default)]
            public List<IncreaseCost> DiceIncreaseCosts
            {
                get
                {
                    return this._diceIncreaseCosts;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="freeDiceCountPerDay", DataFormat=DataFormat.TwosComplement)]
            public int FreeDiceCountPerDay
            {
                get
                {
                    return this._freeDiceCountPerDay;
                }
                set
                {
                    this._freeDiceCountPerDay = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="freeRefreshCountPerDay", DataFormat=DataFormat.TwosComplement)]
            public int FreeRefreshCountPerDay
            {
                get
                {
                    return this._freeRefreshCountPerDay;
                }
                set
                {
                    this._freeRefreshCountPerDay = value;
                }
            }

            [ProtoMember(7, Name="guildTaskRefreshes", DataFormat=DataFormat.Default)]
            public List<GuildConfig.GuildTaskRefresh> GuildTaskRefreshes
            {
                get
                {
                    return this._guildTaskRefreshes;
                }
            }

            [ProtoMember(9, Name="invisibleTasks", DataFormat=DataFormat.Default)]
            public List<GuildConfig.GuildOneTask> InvisibleTasks
            {
                get
                {
                    return this._invisibleTasks;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="maxCompletedTaskPerDay", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MaxCompletedTaskPerDay
            {
                get
                {
                    return this._maxCompletedTaskPerDay;
                }
                set
                {
                    this._maxCompletedTaskPerDay = value;
                }
            }

            public DateTime RefreshDateTime
            {
                get
                {
                    return new DateTime(this._refreshTimePerDay * 0x2710L);
                }
            }

            [ProtoMember(6, Name="refreshIncreaseCosts", DataFormat=DataFormat.Default)]
            public List<IncreaseCost> RefreshIncreaseCosts
            {
                get
                {
                    return this._refreshIncreaseCosts;
                }
            }

            [DefaultValue((long) 0L), ProtoMember(4, IsRequired=false, Name="refreshTimePerDay", DataFormat=DataFormat.TwosComplement)]
            public long RefreshTimePerDay
            {
                get
                {
                    return this._refreshTimePerDay;
                }
                set
                {
                    this._refreshTimePerDay = value;
                }
            }

            [ProtoMember(8, Name="tasks", DataFormat=DataFormat.Default)]
            public List<GuildConfig.GuildOneTask> Tasks
            {
                get
                {
                    return this._tasks;
                }
            }
        }

        [ProtoContract(Name="GuildTaskRefresh")]
        public class GuildTaskRefresh : IExtensible
        {
            private int _completeCount;
            private readonly List<GuildConfig.TaskMini> _costRefreshTasks = new List<GuildConfig.TaskMini>();
            private ClientServerCommon.GuildConfig.Counter _counter;
            private readonly List<GuildConfig.TaskMini> _defaultRefreshTasks = new List<GuildConfig.TaskMini>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="completeCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CompleteCount
            {
                get
                {
                    return this._completeCount;
                }
                set
                {
                    this._completeCount = value;
                }
            }

            [ProtoMember(3, Name="costRefreshTasks", DataFormat=DataFormat.Default)]
            public List<GuildConfig.TaskMini> CostRefreshTasks
            {
                get
                {
                    return this._costRefreshTasks;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="counter", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public ClientServerCommon.GuildConfig.Counter Counter
            {
                get
                {
                    return this._counter;
                }
                set
                {
                    this._counter = value;
                }
            }

            [ProtoMember(2, Name="defaultRefreshTasks", DataFormat=DataFormat.Default)]
            public List<GuildConfig.TaskMini> DefaultRefreshTasks
            {
                get
                {
                    return this._defaultRefreshTasks;
                }
            }
        }

        [ProtoContract(Name="Role")]
        public class Role : IExtensible
        {
            private bool _autoSort;
            private bool _canDownRole;
            private bool _canOffered;
            private string _color = "";
            private int _id;
            private string _name = "";
            private readonly List<int> _rights = new List<int>();
            private int _sortIndex;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            public bool hasRight(int rightType)
            {
                foreach (int num in this._rights)
                {
                    if (num == rightType)
                    {
                        return true;
                    }
                }
                return false;
            }

            [ProtoMember(7, IsRequired=false, Name="autoSort", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool AutoSort
            {
                get
                {
                    return this._autoSort;
                }
                set
                {
                    this._autoSort = value;
                }
            }

            [DefaultValue(false), ProtoMember(8, IsRequired=false, Name="canDownRole", DataFormat=DataFormat.Default)]
            public bool CanDownRole
            {
                get
                {
                    return this._canDownRole;
                }
                set
                {
                    this._canDownRole = value;
                }
            }

            [DefaultValue(false), ProtoMember(5, IsRequired=false, Name="canOffered", DataFormat=DataFormat.Default)]
            public bool CanOffered
            {
                get
                {
                    return this._canOffered;
                }
                set
                {
                    this._canOffered = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="color", DataFormat=DataFormat.Default), DefaultValue("")]
            public string Color
            {
                get
                {
                    return this._color;
                }
                set
                {
                    this._color = value;
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

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
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

            [ProtoMember(3, Name="rights", DataFormat=DataFormat.TwosComplement)]
            public List<int> Rights
            {
                get
                {
                    return this._rights;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="sortIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int SortIndex
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
        }

        [ProtoContract(Name="RoleLimit")]
        public class RoleLimit : IExtensible
        {
            private int _countLimit;
            private int _roleId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="countLimit", DataFormat=DataFormat.TwosComplement)]
            public int CountLimit
            {
                get
                {
                    return this._countLimit;
                }
                set
                {
                    this._countLimit = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="roleId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int RoleId
            {
                get
                {
                    return this._roleId;
                }
                set
                {
                    this._roleId = value;
                }
            }
        }

        [ProtoContract(Name="TaskMini")]
        public class TaskMini : IExtensible
        {
            private int _taskId;
            private int _taskWeight;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [ProtoMember(2, IsRequired=false, Name="taskWeight", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int TaskWeight
            {
                get
                {
                    return this._taskWeight;
                }
                set
                {
                    this._taskWeight = value;
                }
            }
        }
    }
}

