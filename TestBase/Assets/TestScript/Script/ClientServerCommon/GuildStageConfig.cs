namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="GuildStageConfig")]
    public class GuildStageConfig : Configuration, IExtensible
    {
        private BaseInfo _baseInfos;
        private readonly List<GuildTalent> _guildTalents = new List<GuildTalent>();
        private IExtension extensionObject;

        public GuildTalent GetGuildTalentByTypeAndTalentId(int bossType, int talentId)
        {
            foreach (GuildTalent talent in this._guildTalents)
            {
                if ((talent.BossType == bossType) && (talent.TalentId == talentId))
                {
                    return talent;
                }
            }
            return null;
        }

        public GuildTalent GetTalentById(int talentId)
        {
            return this._guildTalents.Find(n => n.TalentId == talentId);
        }

        public double GetTalentValueByTalentIdAndLevel(int talentId, int pointLevel)
        {
            Predicate<TalentValue> match = null;
            foreach (GuildTalent talent in this._guildTalents)
            {
                if (talent.TalentId == talentId)
                {
                    if (match == null)
                    {
                        match = n => n.Level == pointLevel;
                    }
                    TalentValue value2 = talent.TalentValues.Find(match);
                    if (value2 != null)
                    {
                        return (value2.Value / 100.0);
                    }
                }
            }
            return 0.0;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _StageType.Initialize();
            _EventType.Initialize();
            _StageStatus.Initialize();
            _ChallengeType.Initialize();
            _TalentBossType.Initialize();
            _LayerType.Initialize();
            _RankType.Initialize();
            _MsgType.Initialize();
            _WeekType.Initialize();
            _ExploreOperateType.Initialize();
            _HandResetStatus.Initialize();
        }

        public BaseInfo LoadBaseInfoFromXml(SecurityElement element)
        {
            BaseInfo info = new BaseInfo {
                SevenDayRefreshTime = StrParser.ParseStr(element.Attribute("SevenDayRefreshTime"), string.Empty),
                ThreeDayRefreshTime = StrParser.ParseStr(element.Attribute("ThreeDayRefreshTime"), string.Empty),
                DayRefreshTime = StrParser.ParseDateTime(element.Attribute("DayRefreshTime")),
                DayReceivedBoxCount = StrParser.ParseDecInt(element.Attribute("DayReceivedBoxCount"), 0),
                ExploreRankSize = StrParser.ParseDecInt(element.Attribute("ExploreRankSize"), 0),
                BossHurtRankSize = StrParser.ParseDecInt(element.Attribute("BossHurtRankSize"), 0),
                GuildProgressRankSize = StrParser.ParseDecInt(element.Attribute("GuildProgressRankSize"), 0),
                GuildSpeedRankSize = StrParser.ParseDecInt(element.Attribute("GuildSpeedRankSize"), 0),
                //DayReceivedBoxCount = StrParser.ParseDecInt(element.Attribute("DayReceivedBoxCount"), 0),
                FreeChallengeCount = StrParser.ParseDecInt(element.Attribute("FreeChallengeCount"), 0),
                ActivityId = StrParser.ParseHexInt(element.Attribute("ActivityId"), 0),
                MaxMsgCount = StrParser.ParseDecInt(element.Attribute("MaxMsgCount"), 0),
                StageResetCount = StrParser.ParseDecInt(element.Attribute("StageResetCount"), 0),
                TalentResetCount = StrParser.ParseDecInt(element.Attribute("TalentResetCount"), 0),
                ExploreCostId = StrParser.ParseHexInt(element.Attribute("ExploreCostId"), 0),
                CompleteBoxIconId = StrParser.ParseHexInt(element.Attribute("CompleteBoxIconId"), 0),
                UnSearchPassBossIconId = StrParser.ParseHexInt(element.Attribute("UnSearchPassBossIconId"), 0),
                UnSearchChallengeBossIconId = StrParser.ParseHexInt(element.Attribute("UnSearchChallengeBossIconId"), 0),
                AdventureIconId = StrParser.ParseHexInt(element.Attribute("AdventureIconId"), 0),
                GuildBuildIconId = StrParser.ParseHexInt(element.Attribute("GuildBuildIconId"), 0),
                ShowBossCombatIconTime = StrParser.ParseDecLong(element.Attribute("ShowBossCombatIconTime"), 0L),
                BoxSendOpen = StrParser.ParseBool(element.Attribute("BoxSendOpen"), false)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "BossItemChallenge")
                        {
                            if (tag == "RankValueFix")
                            {
                                goto Label_0274;
                            }
                            if (tag == "TalentMapNumRange")
                            {
                                goto Label_0288;
                            }
                        }
                        else
                        {
                            info.BossItemChallenges.Add(this.LoadBossItemChallenge(element2));
                        }
                    }
                    continue;
                Label_0274:
                    info.RankValueFix.Add(this.LoadRankValueFix(element2));
                    continue;
                Label_0288:
                    info.TalentMapNumRanges.Add(this.LoadValueRangeFromXml(element2));
                }
            }
            return info;
        }

        public BossItemChallenge LoadBossItemChallenge(SecurityElement element)
        {
            BossItemChallenge challenge = new BossItemChallenge {
                ChallengeCount = StrParser.ParseDecInt(element.Attribute("ChallengeCount"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Cost"))
                    {
                        challenge.Cost = Cost.LoadFromXml(element2);
                    }
                }
            }
            return challenge;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "GuildStageConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "BaseInfo")
                        {
                            this._baseInfos = this.LoadBaseInfoFromXml(element2);
                        }
                        else if (tag == "GuildTalent")
                        {
                            goto Label_006A;
                        }
                    }
                    continue;
                Label_006A:
                    this.GuildTalents.Add(this.LoadGuildTalentFromXml(element2));
                }
            }
        }

        public GuildTalent LoadGuildTalentFromXml(SecurityElement element)
        {
            GuildTalent talent = new GuildTalent {
                BossType = TypeNameContainer<_TalentBossType>.Parse(element.Attribute("BossType"), 0),
                TalentId = StrParser.ParseHexInt(element.Attribute("TalentId"), 0),
                TalentName = StrParser.ParseStr(element.Attribute("TalentName"), ""),
                CostTalent = StrParser.ParseDecInt(element.Attribute("CostTalent"), 0),
                IconId = StrParser.ParseHexInt(element.Attribute("IconId"), 0),
                TalentDesc = StrParser.ParseStr(element.Attribute("TalentDesc"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "TalentValue")
                        {
                            talent.TalentValues.Add(this.LoadTalentValueFromXml(element2));
                        }
                        else if (tag == "MapNum")
                        {
                            goto Label_00F7;
                        }
                    }
                    continue;
                Label_00F7:
                    talent.MapNums.Add(StrParser.ParseDecInt(element2.Text, 0));
                }
            }
            return talent;
        }

        public RankValueFix LoadRankValueFix(SecurityElement element)
        {
            RankValueFix fix = new RankValueFix {
                ActivityNum = StrParser.ParseDecInt(element.Attribute("ActivityNum"), -1)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "ValueFix"))
                    {
                        fix.ValueFix.Add(this.LoadValueFixFromXml(element2));
                    }
                }
            }
            return fix;
        }

        public TalentValue LoadTalentValueFromXml(SecurityElement element)
        {
            return new TalentValue { 
                Level = StrParser.ParseDecInt(element.Attribute("Level"), 0),
                Value = StrParser.ParseDouble(element.Attribute("Value"), 0.0)
            };
        }

        public ValueFix LoadValueFixFromXml(SecurityElement element)
        {
            return new ValueFix { 
                Type = TypeNameContainer<_RankType>.Parse(element.Attribute("Type"), 0),
                SearchValue = StrParser.ParseDouble(element.Attribute("SearchValue"), 0.0),
                PassBossValue = StrParser.ParseDouble(element.Attribute("PassBossValue"), 0.0),
                ChallengeBossValue = StrParser.ParseDouble(element.Attribute("ChallengeBossValue"), 0.0)
            };
        }

        public ValueRange LoadValueRangeFromXml(SecurityElement element)
        {
            return new ValueRange { 
                Min = StrParser.ParseDecInt(element.Attribute("Min"), 0),
                Max = StrParser.ParseDecInt(element.Attribute("Max"), 0)
            };
        }

        [DefaultValue((string) null), ProtoMember(1, IsRequired=false, Name="baseInfos", DataFormat=DataFormat.Default)]
        public BaseInfo BaseInfos
        {
            get
            {
                return this._baseInfos;
            }
            set
            {
                this._baseInfos = value;
            }
        }

        [ProtoMember(2, Name="guildTalents", DataFormat=DataFormat.Default)]
        public List<GuildTalent> GuildTalents
        {
            get
            {
                return this._guildTalents;
            }
        }

        public DateTime RefreshTimeDateTime
        {
            get
            {
                return new DateTime(this._baseInfos.DayRefreshTime * 0x2710L);
            }
        }

        public class _ChallengeType : TypeNameContainer<GuildStageConfig._ChallengeType>
        {
            public const int Free = 1;
            public const int Item = 2;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._ChallengeType>.RegisterType("Free", 1, "Free");
                return (flag & TypeNameContainer<GuildStageConfig._ChallengeType>.RegisterType("Item", 2, "Item"));
            }
        }

        public class _EventType : TypeNameContainer<GuildStageConfig._EventType>
        {
            public const int Box = 5;
            public const int ChallengeBoss = 4;
            public const int Enemy = 1;
            public const int HiddenEnemy = 2;
            public const int PassBoss = 3;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._EventType>.RegisterType("Enemy", 1, "Enemy");
                flag &= TypeNameContainer<GuildStageConfig._EventType>.RegisterType("HiddenEnemy", 2, "HiddenEnemy");
                flag &= TypeNameContainer<GuildStageConfig._EventType>.RegisterType("PassBoss", 3, "PassBoss");
                flag &= TypeNameContainer<GuildStageConfig._EventType>.RegisterType("ChallengeBoss", 4, "ChallengeBoss");
                return (flag & TypeNameContainer<GuildStageConfig._EventType>.RegisterType("Box", 5, "Box"));
            }
        }

        public class _ExploreOperateType : TypeNameContainer<GuildStageConfig._ExploreOperateType>
        {
            public const int Explore = 1;
            public const int Query = 2;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._ExploreOperateType>.RegisterType("Explore", 1, "Explore");
                return (flag & TypeNameContainer<GuildStageConfig._ExploreOperateType>.RegisterType("Query", 2, "Query"));
            }
        }

        public class _HandResetStatus : TypeNameContainer<GuildStageConfig._HandResetStatus>
        {
            public const int AlreadyReset = 3;
            public const int CanReset = 2;
            public const int TimeNotCome = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._HandResetStatus>.RegisterType("TimeNotCome", 1, "TimeNotCome");
                flag &= TypeNameContainer<GuildStageConfig._HandResetStatus>.RegisterType("CanReset", 2, "CanReset");
                return (flag & TypeNameContainer<GuildStageConfig._HandResetStatus>.RegisterType("AlreadyReset", 3, "AlreadyReset"));
            }
        }

        public class _LayerType : TypeNameContainer<GuildStageConfig._LayerType>
        {
            public const int Next = 3;
            public const int Now = 1;
            public const int Previous = 2;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._LayerType>.RegisterType("Now", 1, "Now");
                flag &= TypeNameContainer<GuildStageConfig._LayerType>.RegisterType("Previous", 2, "Previous");
                return (flag & TypeNameContainer<GuildStageConfig._LayerType>.RegisterType("Next", 3, "Next"));
            }
        }

        public class _MsgType : TypeNameContainer<GuildStageConfig._MsgType>
        {
            public const int Guild = 2;
            public const int Person = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._MsgType>.RegisterType("Person", 1, "Person");
                return (flag & TypeNameContainer<GuildStageConfig._MsgType>.RegisterType("Guild", 2, "Guild"));
            }
        }

        public class _RankType : TypeNameContainer<GuildStageConfig._RankType>
        {
            public const int Boss = 6;
            public const int ChallengeBoss = 5;
            public const int Explore = 3;
            public const int PassBoss = 4;
            public const int Progress = 1;
            public const int Speed = 2;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._RankType>.RegisterType("Progress", 1, "Progress");
                flag &= TypeNameContainer<GuildStageConfig._RankType>.RegisterType("Speed", 2, "Speed");
                flag &= TypeNameContainer<GuildStageConfig._RankType>.RegisterType("Explore", 3, "Explore");
                flag &= TypeNameContainer<GuildStageConfig._RankType>.RegisterType("PassBoss", 4, "PassBoss");
                flag &= TypeNameContainer<GuildStageConfig._RankType>.RegisterType("ChallengeBoss", 5, "ChallengeBoss");
                return (flag & TypeNameContainer<GuildStageConfig._RankType>.RegisterType("Boss", 6, "Boss"));
            }
        }

        public class _StageStatus : TypeNameContainer<GuildStageConfig._StageStatus>
        {
            public const int Complete = 3;
            public const int Searching = 2;
            public const int Unknow = 0;
            public const int UnSearch = 1;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._StageStatus>.RegisterType("UnSearch", 1, "UnSearch");
                flag &= TypeNameContainer<GuildStageConfig._StageStatus>.RegisterType("Searching", 2, "Searching");
                return (flag & TypeNameContainer<GuildStageConfig._StageStatus>.RegisterType("Complete", 3, "Complete"));
            }
        }

        public class _StageType : TypeNameContainer<GuildStageConfig._StageType>
        {
            public const int ChallengeBoss = 5;
            public const int Init = 1;
            public const int PassBoss = 4;
            public const int Point = 3;
            public const int Road = 2;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._StageType>.RegisterType("Init", 1, "Init");
                flag &= TypeNameContainer<GuildStageConfig._StageType>.RegisterType("Road", 2, "Road");
                flag &= TypeNameContainer<GuildStageConfig._StageType>.RegisterType("Point", 3, "Point");
                flag &= TypeNameContainer<GuildStageConfig._StageType>.RegisterType("PassBoss", 4, "PassBoss");
                return (flag & TypeNameContainer<GuildStageConfig._StageType>.RegisterType("ChallengeBoss", 5, "ChallengeBoss"));
            }
        }

        public class _TalentBossType : TypeNameContainer<GuildStageConfig._TalentBossType>
        {
            public const int ChallengeBoss = 2;
            public const int PassBoss = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._TalentBossType>.RegisterType("PassBoss", 1, "PassBoss");
                return (flag & TypeNameContainer<GuildStageConfig._TalentBossType>.RegisterType("ChallengeBoss", 2, "ChallengeBoss"));
            }
        }

        public class _WeekType : TypeNameContainer<GuildStageConfig._WeekType>
        {
            public const int PreviousWeek = 2;
            public const int ThisWeek = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuildStageConfig._WeekType>.RegisterType("ThisWeek", 1, "ThisWeek");
                return (flag & TypeNameContainer<GuildStageConfig._WeekType>.RegisterType("PreviousWeek", 2, "PreviousWeek"));
            }
        }

        [ProtoContract(Name="BaseInfo")]
        public class BaseInfo : IExtensible
        {
            private int _activityId;
            private int _adventureIconId;
            private int _bossHurtRankSize;
            private readonly List<GuildStageConfig.BossItemChallenge> _bossItemChallenges = new List<GuildStageConfig.BossItemChallenge>();
            private bool _boxSendOpen;
            private int _completeBoxIconId;
            private int _dayReceivedBoxCount;
            private long _dayRefreshTime;
            private int _exploreCostId;
            private int _exploreRankSize;
            private int _freeChallengeCount;
            private int _guildBuildIconId;
            private int _guildProgressRankSize;
            private int _guildSpeedRankSize;
            private int _maxMsgCount;
            private readonly List<ClientServerCommon.GuildStageConfig.RankValueFix> _rankValueFix = new List<ClientServerCommon.GuildStageConfig.RankValueFix>();
            private string _sevenDayRefreshTime = "";
            private long _showBossCombatIconTime;
            private int _stageResetCount;
            private readonly List<GuildStageConfig.ValueRange> _talentMapNumRanges = new List<GuildStageConfig.ValueRange>();
            private int _talentResetCount;
            private string _threeDayRefreshTime = "";
            private int _unSearchChallengeBossIconId;
            private int _unSearchPassBossIconId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(11, IsRequired=false, Name="activityId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ActivityId
            {
                get
                {
                    return this._activityId;
                }
                set
                {
                    this._activityId = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x15, IsRequired=false, Name="adventureIconId", DataFormat=DataFormat.TwosComplement)]
            public int AdventureIconId
            {
                get
                {
                    return this._adventureIconId;
                }
                set
                {
                    this._adventureIconId = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="bossHurtRankSize", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int BossHurtRankSize
            {
                get
                {
                    return this._bossHurtRankSize;
                }
                set
                {
                    this._bossHurtRankSize = value;
                }
            }

            [ProtoMember(10, Name="bossItemChallenges", DataFormat=DataFormat.Default)]
            public List<GuildStageConfig.BossItemChallenge> BossItemChallenges
            {
                get
                {
                    return this._bossItemChallenges;
                }
            }

            [ProtoMember(0x18, IsRequired=false, Name="boxSendOpen", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool BoxSendOpen
            {
                get
                {
                    return this._boxSendOpen;
                }
                set
                {
                    this._boxSendOpen = value;
                }
            }

            [ProtoMember(0x12, IsRequired=false, Name="completeBoxIconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CompleteBoxIconId
            {
                get
                {
                    return this._completeBoxIconId;
                }
                set
                {
                    this._completeBoxIconId = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="dayReceivedBoxCount", DataFormat=DataFormat.TwosComplement)]
            public int DayReceivedBoxCount
            {
                get
                {
                    return this._dayReceivedBoxCount;
                }
                set
                {
                    this._dayReceivedBoxCount = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="dayRefreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
            public long DayRefreshTime
            {
                get
                {
                    return this._dayRefreshTime;
                }
                set
                {
                    this._dayRefreshTime = value;
                }
            }

            [ProtoMember(0x10, IsRequired=false, Name="exploreCostId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ExploreCostId
            {
                get
                {
                    return this._exploreCostId;
                }
                set
                {
                    this._exploreCostId = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="exploreRankSize", DataFormat=DataFormat.TwosComplement)]
            public int ExploreRankSize
            {
                get
                {
                    return this._exploreRankSize;
                }
                set
                {
                    this._exploreRankSize = value;
                }
            }

            [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="freeChallengeCount", DataFormat=DataFormat.TwosComplement)]
            public int FreeChallengeCount
            {
                get
                {
                    return this._freeChallengeCount;
                }
                set
                {
                    this._freeChallengeCount = value;
                }
            }

            [ProtoMember(0x16, IsRequired=false, Name="guildBuildIconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int GuildBuildIconId
            {
                get
                {
                    return this._guildBuildIconId;
                }
                set
                {
                    this._guildBuildIconId = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="guildProgressRankSize", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int GuildProgressRankSize
            {
                get
                {
                    return this._guildProgressRankSize;
                }
                set
                {
                    this._guildProgressRankSize = value;
                }
            }

            [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="guildSpeedRankSize", DataFormat=DataFormat.TwosComplement)]
            public int GuildSpeedRankSize
            {
                get
                {
                    return this._guildSpeedRankSize;
                }
                set
                {
                    this._guildSpeedRankSize = value;
                }
            }

            [ProtoMember(12, IsRequired=false, Name="maxMsgCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MaxMsgCount
            {
                get
                {
                    return this._maxMsgCount;
                }
                set
                {
                    this._maxMsgCount = value;
                }
            }

            [ProtoMember(13, Name="rankValueFix", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.GuildStageConfig.RankValueFix> RankValueFix
            {
                get
                {
                    return this._rankValueFix;
                }
            }

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="sevenDayRefreshTime", DataFormat=DataFormat.Default)]
            public string SevenDayRefreshTime
            {
                get
                {
                    return this._sevenDayRefreshTime;
                }
                set
                {
                    this._sevenDayRefreshTime = value;
                }
            }

            [ProtoMember(0x17, IsRequired=false, Name="showBossCombatIconTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
            public long ShowBossCombatIconTime
            {
                get
                {
                    return this._showBossCombatIconTime;
                }
                set
                {
                    this._showBossCombatIconTime = value;
                }
            }

            [DefaultValue(0), ProtoMember(14, IsRequired=false, Name="stageResetCount", DataFormat=DataFormat.TwosComplement)]
            public int StageResetCount
            {
                get
                {
                    return this._stageResetCount;
                }
                set
                {
                    this._stageResetCount = value;
                }
            }

            [ProtoMember(0x11, Name="talentMapNumRanges", DataFormat=DataFormat.Default)]
            public List<GuildStageConfig.ValueRange> TalentMapNumRanges
            {
                get
                {
                    return this._talentMapNumRanges;
                }
            }

            [DefaultValue(0), ProtoMember(15, IsRequired=false, Name="talentResetCount", DataFormat=DataFormat.TwosComplement)]
            public int TalentResetCount
            {
                get
                {
                    return this._talentResetCount;
                }
                set
                {
                    this._talentResetCount = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="threeDayRefreshTime", DataFormat=DataFormat.Default), DefaultValue("")]
            public string ThreeDayRefreshTime
            {
                get
                {
                    return this._threeDayRefreshTime;
                }
                set
                {
                    this._threeDayRefreshTime = value;
                }
            }

            [DefaultValue(0), ProtoMember(20, IsRequired=false, Name="unSearchChallengeBossIconId", DataFormat=DataFormat.TwosComplement)]
            public int UnSearchChallengeBossIconId
            {
                get
                {
                    return this._unSearchChallengeBossIconId;
                }
                set
                {
                    this._unSearchChallengeBossIconId = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x13, IsRequired=false, Name="unSearchPassBossIconId", DataFormat=DataFormat.TwosComplement)]
            public int UnSearchPassBossIconId
            {
                get
                {
                    return this._unSearchPassBossIconId;
                }
                set
                {
                    this._unSearchPassBossIconId = value;
                }
            }
        }

        [ProtoContract(Name="BossItemChallenge")]
        public class BossItemChallenge : IExtensible
        {
            private int _challengeCount;
            private ClientServerCommon.Cost _cost;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="challengeCount", DataFormat=DataFormat.TwosComplement)]
            public int ChallengeCount
            {
                get
                {
                    return this._challengeCount;
                }
                set
                {
                    this._challengeCount = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="cost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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
        }

        [ProtoContract(Name="GuildTalent")]
        public class GuildTalent : IExtensible
        {
            private int _bossType;
            private int _costTalent;
            private int _iconId;
            private readonly List<int> _mapNums = new List<int>();
            private string _talentDesc = "";
            private int _talentId;
            private string _talentName = "";
            private readonly List<GuildStageConfig.TalentValue> _talentValues = new List<GuildStageConfig.TalentValue>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="bossType", DataFormat=DataFormat.TwosComplement)]
            public int BossType
            {
                get
                {
                    return this._bossType;
                }
                set
                {
                    this._bossType = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="costTalent", DataFormat=DataFormat.TwosComplement)]
            public int CostTalent
            {
                get
                {
                    return this._costTalent;
                }
                set
                {
                    this._costTalent = value;
                }
            }

            [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(2, Name="mapNums", DataFormat=DataFormat.TwosComplement)]
            public List<int> MapNums
            {
                get
                {
                    return this._mapNums;
                }
            }

            [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="talentDesc", DataFormat=DataFormat.Default)]
            public string TalentDesc
            {
                get
                {
                    return this._talentDesc;
                }
                set
                {
                    this._talentDesc = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="talentId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int TalentId
            {
                get
                {
                    return this._talentId;
                }
                set
                {
                    this._talentId = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="talentName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string TalentName
            {
                get
                {
                    return this._talentName;
                }
                set
                {
                    this._talentName = value;
                }
            }

            [ProtoMember(8, Name="talentValues", DataFormat=DataFormat.Default)]
            public List<GuildStageConfig.TalentValue> TalentValues
            {
                get
                {
                    return this._talentValues;
                }
            }
        }

        [ProtoContract(Name="RankValueFix")]
        public class RankValueFix : IExtensible
        {
            private int _activityNum;
            private readonly List<ClientServerCommon.GuildStageConfig.ValueFix> _valueFix = new List<ClientServerCommon.GuildStageConfig.ValueFix>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="activityNum", DataFormat=DataFormat.TwosComplement)]
            public int ActivityNum
            {
                get
                {
                    return this._activityNum;
                }
                set
                {
                    this._activityNum = value;
                }
            }

            [ProtoMember(2, Name="valueFix", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.GuildStageConfig.ValueFix> ValueFix
            {
                get
                {
                    return this._valueFix;
                }
            }
        }

        [ProtoContract(Name="TalentValue")]
        public class TalentValue : IExtensible
        {
            private int _level;
            private double _value;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue((double) 0.0), ProtoMember(2, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement)]
            public double Value
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
        }

        [ProtoContract(Name="ValueFix")]
        public class ValueFix : IExtensible
        {
            private double _challengeBossValue;
            private double _passBossValue;
            private double _searchValue;
            private int _type;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((double) 0.0), ProtoMember(4, IsRequired=false, Name="challengeBossValue", DataFormat=DataFormat.TwosComplement)]
            public double ChallengeBossValue
            {
                get
                {
                    return this._challengeBossValue;
                }
                set
                {
                    this._challengeBossValue = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="passBossValue", DataFormat=DataFormat.TwosComplement), DefaultValue((double) 0.0)]
            public double PassBossValue
            {
                get
                {
                    return this._passBossValue;
                }
                set
                {
                    this._passBossValue = value;
                }
            }

            [DefaultValue((double) 0.0), ProtoMember(2, IsRequired=false, Name="searchValue", DataFormat=DataFormat.TwosComplement)]
            public double SearchValue
            {
                get
                {
                    return this._searchValue;
                }
                set
                {
                    this._searchValue = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoContract(Name="ValueRange")]
        public class ValueRange : IExtensible
        {
            private int _max;
            private int _min;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="max", DataFormat=DataFormat.TwosComplement)]
            public int Max
            {
                get
                {
                    return this._max;
                }
                set
                {
                    this._max = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="min", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Min
            {
                get
                {
                    return this._min;
                }
                set
                {
                    this._min = value;
                }
            }
        }
    }
}

