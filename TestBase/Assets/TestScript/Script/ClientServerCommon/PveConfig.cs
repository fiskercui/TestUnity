namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="PveConfig")]
    public class PveConfig : Configuration, IExtensible
    {
        private PveSetting _pveSetting;
        private IExtension extensionObject;
        private Dictionary<int, NPCGroup> id_npcGroupMap = new Dictionary<int, NPCGroup>();
        private Dictionary<int, PveLevel> level_pveLevelMap = new Dictionary<int, PveLevel>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            if (this._pveSetting == null)
            {
                Logger.Error(base.GetType().Name + "Invalid _pveSetting", new object[0]);
            }
            else if (this._pveSetting.game == null)
            {
                Logger.Error(base.GetType().Name + "Invalid _pveSetting.game", new object[0]);
            }
            else
            {
                foreach (PveLevel level in this._pveSetting.game.pveLevels)
                {
                    if (level != null)
                    {
                        if (this.level_pveLevelMap.ContainsKey(level.level))
                        {
                            Logger.Error(base.GetType().Name + " ContainsKey " + level.level, new object[0]);
                        }
                        else
                        {
                            this.level_pveLevelMap.Add(level.level, level);
                            foreach (PveGroup group in level.pveGroups)
                            {
                                foreach (NPCGroup group2 in group.npcGroups)
                                {
                                    if (group2 != null)
                                    {
                                        if (this.id_npcGroupMap.ContainsKey(group2.id))
                                        {
                                            Logger.Error(base.GetType().Name + " ContainsKey 0x" + group2.id.ToString("X"), new object[0]);
                                        }
                                        else
                                        {
                                            this.id_npcGroupMap.Add(group2.id, group2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (PveGroup group3 in this._pveSetting.game.pveLevelCommon.pveGroups)
                {
                    foreach (NPCGroup group4 in group3.npcGroups)
                    {
                        if (group4 != null)
                        {
                            if (this.id_npcGroupMap.ContainsKey(group4.id))
                            {
                                Logger.Error(base.GetType().Name + " ContainsKey 0x" + group4.id.ToString("X"), new object[0]);
                            }
                            else
                            {
                                this.id_npcGroupMap.Add(group4.id, group4);
                            }
                        }
                    }
                }
            }
        }

        public GridTutorial GetGridTutorialByPos(int pos)
        {
            foreach (GridTutorial tutorial in this._pveSetting.tutorial.grids)
            {
                if (tutorial.pos == pos)
                {
                    return tutorial;
                }
            }
            return null;
        }

        public NPCGroup GetNpcGroupById(int id)
        {
            NPCGroup group = null;
            if (!this.id_npcGroupMap.TryGetValue(id, out group))
            {
                return null;
            }
            return group;
        }

        public PveLevel GetPveLevelByLevel(int level)
        {
            PveLevel level2 = null;
            if (!this.level_pveLevelMap.TryGetValue(level, out level2))
            {
                return this._pveSetting.game.pveLevelCommon;
            }
            return level2;
        }

        public PveLevel GetPveLevelByMaxDefault()
        {
            if (this._pveSetting.game.pveLevels.Count > 0)
            {
                return this._pveSetting.game.pveLevels[this._pveSetting.game.pveLevels.Count - 1];
            }
            return null;
        }

        public PveLevelExpression GetPveLevelExpressionByLevel(int level)
        {
            foreach (PveLevelExpression expression in this._pveSetting.game.pveLevelExpressions)
            {
                if (expression.level == level)
                {
                    return expression;
                }
            }
            return this._pveSetting.game.pveLevelExpressionCommon;
        }

        public int GetPveNpcActiveSkillLevelByLevel(int level)
        {
            foreach (PveNpcActiveSkillLevel level2 in this._pveSetting.game.pveNpcActiveSkillLevels)
            {
                if (level2.level == level)
                {
                    return level2.activeSkillLevel;
                }
            }
            if ((level > 0) && (this._pveSetting.game.pveNpcActiveSkillLevels.Count > 0))
            {
                return this._pveSetting.game.pveNpcActiveSkillLevels[this._pveSetting.game.pveNpcActiveSkillLevels.Count - 1].activeSkillLevel;
            }
            return 0;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initizlize()
        {
            _PveBuffType.Initialize();
            _PVEGridType.Initialize();
        }

        private AddAttribute LoadAddAttributeFromXml(SecurityElement element)
        {
            AddAttribute attribute = new AddAttribute {
                costPvePoint = StrParser.ParseDecInt(element.Attribute("CostPvePoint"), 0),
                addAttributeValue = StrParser.ParseFloat(element.Attribute("AddAttributeValue"), 0f)
            };
            foreach (int num in StrParser.ParseHexIntList(element.Attribute("PveBuffIds"), 0))
            {
                attribute.pveBuffIds.Add(num);
            }
            return attribute;
        }

        private int LoadContinuousRankReward_RewardSetIdFromXml(SecurityElement element)
        {
            if (element.Tag != "ContinuousRankReward_RewardSetId")
            {
                return 0;
            }
            return StrParser.ParseHexInt(element.Attribute("RewardSetId"), 0);
        }

        private EventSetting LoadEventSettingFromXml(SecurityElement element)
        {
            if (element.Tag != "EventSetting")
            {
                return null;
            }
            return new EventSetting { 
                emptyGridNum = StrParser.ParseDecInt(element.Attribute("EmptyGridNum"), 0),
                maxEventNum = StrParser.ParseDecInt(element.Attribute("MaxEventNum"), 0),
                stepTrapMin = StrParser.ParseDecInt(element.Attribute("StepTrapMin"), 0),
                stepTrapMax = StrParser.ParseDecInt(element.Attribute("StepTrapMax"), 0),
                attributeTrapMin = StrParser.ParseDecInt(element.Attribute("AttributeTrapMin"), 0),
                attributeTrapMax = StrParser.ParseDecInt(element.Attribute("AttributeTrapMax"), 0),
                guessWinPercent = StrParser.ParseDecInt(element.Attribute("GuessWinPercent"), 1),
                guessDrawPercent = StrParser.ParseDecInt(element.Attribute("GuessDrawPercent"), 1),
                guessLosePercent = StrParser.ParseDecInt(element.Attribute("GuessLosePercent"), 1)
            };
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "PveConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "PveSetting"))
                    {
                        this.LoadPveSettingFromXml(element2);
                    }
                }
            }
        }

        private Game LoadGameFromXml(SecurityElement element)
        {
            if (element.Tag != "Game")
            {
                return null;
            }
            Game game = new Game {
                maxStep = StrParser.ParseDecInt(element.Attribute("MaxStep"), 1),
                maxRow = StrParser.ParseDecInt(element.Attribute("MaxRow"), 1),
                maxColumn = StrParser.ParseDecInt(element.Attribute("MaxColumn"), 1),
                posStart = StrParser.ParseDecInt(element.Attribute("PosStart"), 1),
                posEnd = StrParser.ParseDecInt(element.Attribute("PosEnd"), 1),
                rankMaxRecordNum = StrParser.ParseDecInt(element.Attribute("RankMaxRecordNum"), 1),
                maxStartGameNum = StrParser.ParseDecInt(element.Attribute("MaxStartGameNum"), 1),
                addAttributePerBattleCount = StrParser.ParseDecInt(element.Attribute("AddAttributePerBattleCount"), 1),
                maxRandomRewardGridNum = StrParser.ParseDecInt(element.Attribute("MaxRandomRewardGridNum"), 1)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    PveLevelExpression expression;
                    PveLevelExpression expression2;
                    PveLevel level2;
                    PveNpcActiveSkillLevel level3;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "PveLevel")
                        {
                            if (tag == "PveLevelExpression")
                            {
                                goto Label_0182;
                            }
                            if (tag == "PveLevelExpressionCommon")
                            {
                                goto Label_019B;
                            }
                            if (tag == "PveLevelCommon")
                            {
                                goto Label_01B2;
                            }
                            if (tag == "PveNpcActiveSkillLevel")
                            {
                                goto Label_01C9;
                            }
                        }
                        else
                        {
                            PveLevel item = this.LoadPveLevelFromXml(element2);
                            if (item != null)
                            {
                                game.pveLevels.Add(item);
                            }
                        }
                    }
                    continue;
                Label_0182:
                    expression = this.LoadPveLevelExpressionFromXml(element2);
                    if (expression != null)
                    {
                        game.pveLevelExpressions.Add(expression);
                    }
                    continue;
                Label_019B:
                    expression2 = this.LoadPveLevelExpressionFromXml(element2);
                    if (expression2 != null)
                    {
                        game.pveLevelExpressionCommon = expression2;
                    }
                    continue;
                Label_01B2:
                    level2 = this.LoadPveLevelFromXml(element2);
                    if (level2 != null)
                    {
                        game.pveLevelCommon = level2;
                    }
                    continue;
                Label_01C9:
                    level3 = this.LoadPveNpcActiveSkillLevelFromXml(element2);
                    if (level3 != null)
                    {
                        game.pveNpcActiveSkillLevels.Add(level3);
                    }
                }
            }
            return game;
        }

        private GameReward LoadGameRewardFromXml(SecurityElement element)
        {
            if (element.Tag != "GameReward")
            {
                return null;
            }
            GameReward reward = new GameReward();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    switch (element2.Tag)
                    {
                        case "PrevAddAttributeReward":
                        {
                            PrevAddAttributeReward item = this.LoadPrevAddAttributeRewardFromXml(element2);
                            if (item != null)
                            {
                                reward.prevAddAttributeRewards.Add(item);
                            }
                            break;
                        }
                        case "Reward_Random":
                        {
                            int num = this.LoadReward_RandomFromXml(element2);
                            reward.rewardRandom_RewardSetId = num;
                            break;
                        }
                        case "LevelReward":
                        {
                            LevelReward reward3 = this.LoadLevelRewardFromXml(element2);
                            if (reward3 != null)
                            {
                                reward.rewardPass_levelRecords.Add(reward3);
                            }
                            break;
                        }
                        case "AddAttributes_Low":
                            reward.addAttributes_Low = this.LoadAddAttributeFromXml(element2);
                            break;

                        case "AddAttributes_Normal":
                            reward.addAttributes_Normal = this.LoadAddAttributeFromXml(element2);
                            break;

                        case "AddAttributes_High":
                            reward.addAttributes_High = this.LoadAddAttributeFromXml(element2);
                            break;

                        case "RankReward":
                        {
                            RankReward reward4 = this.LoadRankRewardFromXml(element2);
                            if (reward4 != null)
                            {
                                reward.rankRewards.Add(reward4);
                            }
                            break;
                        }
                        case "ContinuousRankReward_RewardSetId":
                        {
                            int num2 = this.LoadContinuousRankReward_RewardSetIdFromXml(element2);
                            reward.continuousRankReward_RewardSetId = num2;
                            break;
                        }
                        case "OneKeySweep":
                        {
                            OneKeySweep sweep = this.LoadOneKeySweepFromXml(element2);
                            if (sweep != null)
                            {
                                reward.oneKeySweeps.Add(sweep);
                            }
                            break;
                        }
                    }
                }
            }
            return reward;
        }

        private GameTutorial LoadGameTutorialFromXml(SecurityElement element)
        {
            if (element.Tag != "GameTutorial")
            {
                return null;
            }
            GameTutorial tutorial = new GameTutorial {
                maxStep = StrParser.ParseDecInt(element.Attribute("MaxStep"), 0),
                maxRow = StrParser.ParseDecInt(element.Attribute("MaxRow"), 0),
                maxColumn = StrParser.ParseDecInt(element.Attribute("MaxColumn"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "GridTutorial")
                    {
                        tutorial.grids.Add(this.LoadGripTutorialFromXml(element2));
                    }
                }
            }
            return tutorial;
        }

        private GenNumDifficulty LoadGenNumDifficultyFromXml(SecurityElement element)
        {
            if (element.Tag != "GenNumDifficulty")
            {
                return null;
            }
            return new GenNumDifficulty { 
                increaseAttribute = StrParser.ParseStr(element.Attribute("IncreaseAttribute"), ""),
                genNum = StrParser.ParseDecInt(element.Attribute("GenNum"), 0)
            };
        }

        private GridTutorial LoadGripTutorialFromXml(SecurityElement element)
        {
            GridTutorial tutorial = new GridTutorial {
                pos = StrParser.ParseDecInt(element.Attribute("Pos"), 0),
                addStep = StrParser.ParseDecInt(element.Attribute("AddStep"), 0),
                rewardRandom_RewardSetId = StrParser.ParseHexInt(element.Attribute("RewardSetId"), 0),
                gridTutorialType = TypeNameContainer<_PVEGridType>.Parse(element.Attribute("GridTutorialType"), 8),
                factor = StrParser.ParseDecInt(element.Attribute("Factor"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "NPCGroup")
                        {
                            tutorial.npcGroup = this.LoadNPCGroupFromXml(element2);
                        }
                        else if (tag == "TutorialAction")
                        {
                            goto Label_00D3;
                        }
                    }
                    goto Label_00E5;
                Label_00D3:
                    tutorial.tutorialActions.Add(this.LoadTutorialActionFromXml(element2));
                Label_00E5:
                    bool flag1 = element2.Tag != "NPCGroup";
                }
            }
            return tutorial;
        }

        private LevelReward LoadLevelRewardFromXml(SecurityElement element)
        {
            if (element.Tag != "LevelReward")
            {
                return null;
            }
            return new LevelReward { 
                levelMin = StrParser.ParseDecInt(element.Attribute("LevelMin"), 0),
                levelMax = StrParser.ParseDecInt(element.Attribute("LevelMax"), 0),
                rewardSetId = StrParser.ParseHexInt(element.Attribute("RewardSetId"), 0)
            };
        }

        private NPCGroup LoadNPCGroupFromXml(SecurityElement element)
        {
            if (element.Tag != "NPCGroup")
            {
                return null;
            }
            NPCGroup group = new NPCGroup {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "NpcGroupName")
            };
            foreach (int num in StrParser.ParseHexIntList(element.Attribute("NpcResourceIds"), 0))
            {
                group.npcResourceIds.Add(num);
            }
            return group;
        }

        private OneKeySweep LoadOneKeySweepFromXml(SecurityElement element)
        {
            if (element.Tag != "OneKeySweep")
            {
                return null;
            }
            return new OneKeySweep { 
                playerLevelMin = StrParser.ParseDecInt(element.Attribute("PlayerLevelMin"), 0),
                playerLevelMax = StrParser.ParseDecInt(element.Attribute("PlayerLevelMax"), 0),
                vipLevelMin = StrParser.ParseDecInt(element.Attribute("VipLevelMin"), 0),
                vipLevelMax = StrParser.ParseDecInt(element.Attribute("VipLevelMax"), 0),
                ratePvePointToAttribute = StrParser.ParseFloat(element.Attribute("RatePvePointToAttribute"), 0f),
                randRate = StrParser.ParseFloat(element.Attribute("RandRate"), 0f),
                front_MaxHP = StrParser.ParseDecInt(element.Attribute("Front_MaxHP"), 1),
                front_AP = StrParser.ParseDecInt(element.Attribute("Front_AP"), 1),
                front_DP = StrParser.ParseDecInt(element.Attribute("Front_DP"), 1),
                back_MaxHP = StrParser.ParseDecInt(element.Attribute("Back_MaxHP"), 1),
                back_AP = StrParser.ParseDecInt(element.Attribute("Back_AP"), 1),
                back_DP = StrParser.ParseDecInt(element.Attribute("Back_DP"), 1)
            };
        }

        private PrevAddAttributeReward LoadPrevAddAttributeRewardFromXml(SecurityElement element)
        {
            if (element.Tag != "PrevAddAttributeReward")
            {
                return null;
            }
            PrevAddAttributeReward reward = new PrevAddAttributeReward {
                pvePointMin = StrParser.ParseDecInt(element.Attribute("PvePointMin"), 0),
                pvePointMax = StrParser.ParseDecInt(element.Attribute("PvePointMax"), 0),
                addAttributeValue = StrParser.ParseFloat(element.Attribute("AddAttributeValue"), 0f)
            };
            foreach (int num in StrParser.ParseHexIntList(element.Attribute("PveBuffIds"), 0))
            {
                reward.pveBuffIds.Add(num);
            }
            return reward;
        }

        private PveGroup LoadPveGroupFromXml(SecurityElement element)
        {
            if (element.Tag != "PveGroup")
            {
                return null;
            }
            PveGroup group = new PveGroup {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                factor = StrParser.ParseDecInt(element.Attribute("Factor"), 1)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    GenNumDifficulty difficulty;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "NPCGroup")
                        {
                            NPCGroup item = this.LoadNPCGroupFromXml(element2);
                            if (item != null)
                            {
                                item.pveGroup = group;
                                group.npcGroups.Add(item);
                            }
                        }
                        else if (tag == "GenNumDifficulty")
                        {
                            goto Label_00B8;
                        }
                    }
                    continue;
                Label_00B8:
                    difficulty = this.LoadGenNumDifficultyFromXml(element2);
                    if (difficulty != null)
                    {
                        group.genNumDifficultys.Add(difficulty);
                    }
                }
            }
            return group;
        }

        private PveLevelExpression LoadPveLevelExpressionFromXml(SecurityElement element)
        {
            if ((element.Tag != "PveLevelExpression") && (element.Tag != "PveLevelExpressionCommon"))
            {
                return null;
            }
            return new PveLevelExpression { 
                level = StrParser.ParseDecInt(element.Attribute("Level"), 0),
                expresion_front_hp = StrParser.ParseStr(element.Attribute("Expresion_Front_HP"), ""),
                expresion_front_ap = StrParser.ParseStr(element.Attribute("Expresion_Front_AP"), ""),
                expresion_front_dp = StrParser.ParseStr(element.Attribute("Expresion_Front_DP"), ""),
                expresion_back_hp = StrParser.ParseStr(element.Attribute("Expresion_Back_HP"), ""),
                expresion_back_ap = StrParser.ParseStr(element.Attribute("Expresion_Back_AP"), ""),
                expresion_back_dp = StrParser.ParseStr(element.Attribute("Expresion_Back_DP"), "")
            };
        }

        private PveLevel LoadPveLevelFromXml(SecurityElement element)
        {
            if ((element.Tag != "PveLevel") && (element.Tag != "PveLevelCommon"))
            {
                return null;
            }
            PveLevel level = new PveLevel {
                level = StrParser.ParseDecInt(element.Attribute("Level"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "PveGroup"))
                    {
                        PveGroup item = this.LoadPveGroupFromXml(element2);
                        if (item != null)
                        {
                            level.pveGroups.Add(item);
                        }
                    }
                }
            }
            return level;
        }

        private PveNpcActiveSkillLevel LoadPveNpcActiveSkillLevelFromXml(SecurityElement element)
        {
            if (element.Tag != "PveNpcActiveSkillLevel")
            {
                return null;
            }
            return new PveNpcActiveSkillLevel { 
                level = StrParser.ParseDecInt(element.Attribute("Level"), 0),
                activeSkillLevel = StrParser.ParseDecInt(element.Attribute("ActiveSkillLevel"), 1)
            };
        }

        private void LoadPveSettingFromXml(SecurityElement element)
        {
            if (element.Tag == "PveSetting")
            {
                this._pveSetting = new PveSetting();
                this._pveSetting.activityId = StrParser.ParseHexInt(element.Attribute("ActivityId"), 0);
                this._pveSetting.exchange = StrParser.ParseDecInt(element.Attribute("Exchange"), 0);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag != "Game")
                            {
                                if (tag == "GameReward")
                                {
                                    goto Label_00D5;
                                }
                                if (tag == "EventSetting")
                                {
                                    goto Label_00E9;
                                }
                                if (tag == "GameTutorial")
                                {
                                    goto Label_00FD;
                                }
                            }
                            else
                            {
                                this._pveSetting.game = this.LoadGameFromXml(element2);
                            }
                        }
                        continue;
                    Label_00D5:
                        this._pveSetting.gameReward = this.LoadGameRewardFromXml(element2);
                        continue;
                    Label_00E9:
                        this._pveSetting.eventSetting = this.LoadEventSettingFromXml(element2);
                        continue;
                    Label_00FD:
                        this._pveSetting.tutorial = this.LoadGameTutorialFromXml(element2);
                    }
                }
            }
        }

        private RankReward LoadRankRewardFromXml(SecurityElement element)
        {
            if (element.Tag != "RankReward")
            {
                return null;
            }
            return new RankReward { 
                rankMin = StrParser.ParseDecInt(element.Attribute("RankMin"), 0),
                rankMax = StrParser.ParseDecInt(element.Attribute("RankMax"), 0),
                rewardSetId = StrParser.ParseHexInt(element.Attribute("RewardSetId"), 0)
            };
        }

        private int LoadReward_RandomFromXml(SecurityElement element)
        {
            if (element.Tag != "Reward_Random")
            {
                return 0;
            }
            return StrParser.ParseHexInt(element.Attribute("RewardSetId"), 0);
        }

        private GameTutorialAction LoadTutorialActionFromXml(SecurityElement element)
        {
            GameTutorialAction action = new GameTutorialAction();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "ShowTips")
                        {
                            action.tutorialAction = TutorialConfig.Action.LoadActionFromXml(element2);
                        }
                        else if (tag == "AttachComponent")
                        {
                            goto Label_0062;
                        }
                    }
                    continue;
                Label_0062:
                    action.attachComponentName = StrParser.ParseStr(element2.Attribute("ComponentName"), "");
                    action.attachOffset = vector2.LoadFromXml(element2.Attribute("Offset"));
                    action.attachSize = vector2.LoadFromXml(element2.Attribute("Size"));
                }
            }
            return action;
        }

        [ProtoMember(1, IsRequired=false, Name="pveSetting", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public PveSetting pveSetting
        {
            get
            {
                return this._pveSetting;
            }
            set
            {
                this._pveSetting = value;
            }
        }

        public class _PveBuffType : TypeNameContainer<PveConfig._PveBuffType>
        {
            public const int AvatarAll = 1;
            public const int AvatarBack = 3;
            public const int AvatarFront = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                TypeNameContainer<PveConfig._PveBuffType>.SetTextSectionName("PveBuffType");
                flag &= TypeNameContainer<PveConfig._PveBuffType>.RegisterType("AvatarAll", 1, "AvatarAll");
                flag &= TypeNameContainer<PveConfig._PveBuffType>.RegisterType("AvatarFront", 2, "AvatarFront");
                return (flag & TypeNameContainer<PveConfig._PveBuffType>.RegisterType("AvatarBack", 3, "AvatarBack"));
            }
        }

        [ProtoContract(Name="AddAttribute")]
        public class AddAttribute : IExtensible
        {
            private float _addAttributeValue;
            private int _costPvePoint;
            private readonly List<int> _pveBuffIds = new List<int>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="addAttributeValue", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float addAttributeValue
            {
                get
                {
                    return this._addAttributeValue;
                }
                set
                {
                    this._addAttributeValue = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="costPvePoint", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int costPvePoint
            {
                get
                {
                    return this._costPvePoint;
                }
                set
                {
                    this._costPvePoint = value;
                }
            }

            [ProtoMember(3, Name="pveBuffIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> pveBuffIds
            {
                get
                {
                    return this._pveBuffIds;
                }
            }
        }

        [ProtoContract(Name="EventSetting")]
        public class EventSetting : IExtensible
        {
            private int _attributeTrapMax;
            private int _attributeTrapMin;
            private int _emptyGridNum;
            private int _guessDrawPercent;
            private int _guessLosePercent;
            private int _guessWinPercent;
            private int _maxEventNum;
            private int _stepTrapMax;
            private int _stepTrapMin;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, IsRequired=false, Name="attributeTrapMax", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int attributeTrapMax
            {
                get
                {
                    return this._attributeTrapMax;
                }
                set
                {
                    this._attributeTrapMax = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="attributeTrapMin", DataFormat=DataFormat.TwosComplement)]
            public int attributeTrapMin
            {
                get
                {
                    return this._attributeTrapMin;
                }
                set
                {
                    this._attributeTrapMin = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="emptyGridNum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int emptyGridNum
            {
                get
                {
                    return this._emptyGridNum;
                }
                set
                {
                    this._emptyGridNum = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="guessDrawPercent", DataFormat=DataFormat.TwosComplement)]
            public int guessDrawPercent
            {
                get
                {
                    return this._guessDrawPercent;
                }
                set
                {
                    this._guessDrawPercent = value;
                }
            }

            [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="guessLosePercent", DataFormat=DataFormat.TwosComplement)]
            public int guessLosePercent
            {
                get
                {
                    return this._guessLosePercent;
                }
                set
                {
                    this._guessLosePercent = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="guessWinPercent", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int guessWinPercent
            {
                get
                {
                    return this._guessWinPercent;
                }
                set
                {
                    this._guessWinPercent = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="maxEventNum", DataFormat=DataFormat.TwosComplement)]
            public int maxEventNum
            {
                get
                {
                    return this._maxEventNum;
                }
                set
                {
                    this._maxEventNum = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="stepTrapMax", DataFormat=DataFormat.TwosComplement)]
            public int stepTrapMax
            {
                get
                {
                    return this._stepTrapMax;
                }
                set
                {
                    this._stepTrapMax = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="stepTrapMin", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int stepTrapMin
            {
                get
                {
                    return this._stepTrapMin;
                }
                set
                {
                    this._stepTrapMin = value;
                }
            }
        }

        [ProtoContract(Name="Game")]
        public class Game : IExtensible
        {
            private int _addAttributePerBattleCount;
            private int _maxColumn;
            private int _maxRandomRewardGridNum;
            private int _maxRow;
            private int _maxStartGameNum;
            private int _maxStep;
            private int _posEnd;
            private int _posStart;
            private PveConfig.PveLevel _pveLevelCommon;
            private PveConfig.PveLevelExpression _pveLevelExpressionCommon;
            private readonly List<PveConfig.PveLevelExpression> _pveLevelExpressions = new List<PveConfig.PveLevelExpression>();
            private readonly List<PveConfig.PveLevel> _pveLevels = new List<PveConfig.PveLevel>();
            private readonly List<PveConfig.PveNpcActiveSkillLevel> _pveNpcActiveSkillLevels = new List<PveConfig.PveNpcActiveSkillLevel>();
            private int _rankMaxRecordNum;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="addAttributePerBattleCount", DataFormat=DataFormat.TwosComplement)]
            public int addAttributePerBattleCount
            {
                get
                {
                    return this._addAttributePerBattleCount;
                }
                set
                {
                    this._addAttributePerBattleCount = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="maxColumn", DataFormat=DataFormat.TwosComplement)]
            public int maxColumn
            {
                get
                {
                    return this._maxColumn;
                }
                set
                {
                    this._maxColumn = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="maxRandomRewardGridNum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int maxRandomRewardGridNum
            {
                get
                {
                    return this._maxRandomRewardGridNum;
                }
                set
                {
                    this._maxRandomRewardGridNum = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="maxRow", DataFormat=DataFormat.TwosComplement)]
            public int maxRow
            {
                get
                {
                    return this._maxRow;
                }
                set
                {
                    this._maxRow = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="maxStartGameNum", DataFormat=DataFormat.TwosComplement)]
            public int maxStartGameNum
            {
                get
                {
                    return this._maxStartGameNum;
                }
                set
                {
                    this._maxStartGameNum = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="maxStep", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int maxStep
            {
                get
                {
                    return this._maxStep;
                }
                set
                {
                    this._maxStep = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="posEnd", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int posEnd
            {
                get
                {
                    return this._posEnd;
                }
                set
                {
                    this._posEnd = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="posStart", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int posStart
            {
                get
                {
                    return this._posStart;
                }
                set
                {
                    this._posStart = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(12, IsRequired=false, Name="pveLevelCommon", DataFormat=DataFormat.Default)]
            public PveConfig.PveLevel pveLevelCommon
            {
                get
                {
                    return this._pveLevelCommon;
                }
                set
                {
                    this._pveLevelCommon = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(13, IsRequired=false, Name="pveLevelExpressionCommon", DataFormat=DataFormat.Default)]
            public PveConfig.PveLevelExpression pveLevelExpressionCommon
            {
                get
                {
                    return this._pveLevelExpressionCommon;
                }
                set
                {
                    this._pveLevelExpressionCommon = value;
                }
            }

            [ProtoMember(11, Name="pveLevelExpressions", DataFormat=DataFormat.Default)]
            public List<PveConfig.PveLevelExpression> pveLevelExpressions
            {
                get
                {
                    return this._pveLevelExpressions;
                }
            }

            [ProtoMember(6, Name="pveLevels", DataFormat=DataFormat.Default)]
            public List<PveConfig.PveLevel> pveLevels
            {
                get
                {
                    return this._pveLevels;
                }
            }

            [ProtoMember(14, Name="pveNpcActiveSkillLevels", DataFormat=DataFormat.Default)]
            public List<PveConfig.PveNpcActiveSkillLevel> pveNpcActiveSkillLevels
            {
                get
                {
                    return this._pveNpcActiveSkillLevels;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="rankMaxRecordNum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int rankMaxRecordNum
            {
                get
                {
                    return this._rankMaxRecordNum;
                }
                set
                {
                    this._rankMaxRecordNum = value;
                }
            }
        }

        [ProtoContract(Name="GameReward")]
        public class GameReward : IExtensible
        {
            private PveConfig.AddAttribute _addAttributes_High;
            private PveConfig.AddAttribute _addAttributes_Low;
            private PveConfig.AddAttribute _addAttributes_Normal;
            private int _continuousRankReward_RewardSetId;
            private readonly List<PveConfig.OneKeySweep> _oneKeySweeps = new List<PveConfig.OneKeySweep>();
            private readonly List<PveConfig.PrevAddAttributeReward> _prevAddAttributeRewards = new List<PveConfig.PrevAddAttributeReward>();
            private readonly List<PveConfig.RankReward> _rankRewards = new List<PveConfig.RankReward>();
            private readonly List<PveConfig.LevelReward> _rewardPass_levelRecords = new List<PveConfig.LevelReward>();
            private int _rewardRandom_RewardSetId;
            private IExtension extensionObject;

            public PveConfig.OneKeySweep GetOneKeySweepByPlayerLevelAndVipLevel(int playerLevel, int vipLevel)
            {
                for (int i = 0; i < this._oneKeySweeps.Count; i++)
                {
                    PveConfig.OneKeySweep sweep = this._oneKeySweeps[i];
                    if ((vipLevel >= sweep.vipLevelMin) && (vipLevel <= sweep.vipLevelMax))
                    {
                        return sweep;
                    }
                    if ((playerLevel >= sweep.playerLevelMin) && (playerLevel <= sweep.playerLevelMax))
                    {
                        return sweep;
                    }
                }
                return this._oneKeySweeps[0];
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, IsRequired=false, Name="addAttributes_High", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public PveConfig.AddAttribute addAttributes_High
            {
                get
                {
                    return this._addAttributes_High;
                }
                set
                {
                    this._addAttributes_High = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="addAttributes_Low", DataFormat=DataFormat.Default)]
            public PveConfig.AddAttribute addAttributes_Low
            {
                get
                {
                    return this._addAttributes_Low;
                }
                set
                {
                    this._addAttributes_Low = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="addAttributes_Normal", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public PveConfig.AddAttribute addAttributes_Normal
            {
                get
                {
                    return this._addAttributes_Normal;
                }
                set
                {
                    this._addAttributes_Normal = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="continuousRankReward_RewardSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int continuousRankReward_RewardSetId
            {
                get
                {
                    return this._continuousRankReward_RewardSetId;
                }
                set
                {
                    this._continuousRankReward_RewardSetId = value;
                }
            }

            [ProtoMember(9, Name="oneKeySweeps", DataFormat=DataFormat.Default)]
            public List<PveConfig.OneKeySweep> oneKeySweeps
            {
                get
                {
                    return this._oneKeySweeps;
                }
            }

            [ProtoMember(1, Name="prevAddAttributeRewards", DataFormat=DataFormat.Default)]
            public List<PveConfig.PrevAddAttributeReward> prevAddAttributeRewards
            {
                get
                {
                    return this._prevAddAttributeRewards;
                }
            }

            [ProtoMember(7, Name="rankRewards", DataFormat=DataFormat.Default)]
            public List<PveConfig.RankReward> rankRewards
            {
                get
                {
                    return this._rankRewards;
                }
            }

            [ProtoMember(3, Name="rewardPass_levelRecords", DataFormat=DataFormat.Default)]
            public List<PveConfig.LevelReward> rewardPass_levelRecords
            {
                get
                {
                    return this._rewardPass_levelRecords;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="rewardRandom_RewardSetId", DataFormat=DataFormat.TwosComplement)]
            public int rewardRandom_RewardSetId
            {
                get
                {
                    return this._rewardRandom_RewardSetId;
                }
                set
                {
                    this._rewardRandom_RewardSetId = value;
                }
            }
        }

        [ProtoContract(Name="GameTutorial")]
        public class GameTutorial : IExtensible
        {
            private readonly List<PveConfig.GridTutorial> _grids = new List<PveConfig.GridTutorial>();
            private int _maxColumn;
            private int _maxRow;
            private int _maxStep;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, Name="grids", DataFormat=DataFormat.Default)]
            public List<PveConfig.GridTutorial> grids
            {
                get
                {
                    return this._grids;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="maxColumn", DataFormat=DataFormat.TwosComplement)]
            public int maxColumn
            {
                get
                {
                    return this._maxColumn;
                }
                set
                {
                    this._maxColumn = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="maxRow", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int maxRow
            {
                get
                {
                    return this._maxRow;
                }
                set
                {
                    this._maxRow = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="maxStep", DataFormat=DataFormat.TwosComplement)]
            public int maxStep
            {
                get
                {
                    return this._maxStep;
                }
                set
                {
                    this._maxStep = value;
                }
            }
        }

        [ProtoContract(Name="GameTutorialAction")]
        public class GameTutorialAction : IExtensible
        {
            private string _attachComponentName = "";
            private vector2 _attachOffset;
            private vector2 _attachSize;
            private TutorialConfig.Action _tutorialAction;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="attachComponentName", DataFormat=DataFormat.Default)]
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

            [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="attachOffset", DataFormat=DataFormat.Default)]
            public vector2 attachOffset
            {
                get
                {
                    return this._attachOffset;
                }
                set
                {
                    this._attachOffset = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="attachSize", DataFormat=DataFormat.Default)]
            public vector2 attachSize
            {
                get
                {
                    return this._attachSize;
                }
                set
                {
                    this._attachSize = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="tutorialAction", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public TutorialConfig.Action tutorialAction
            {
                get
                {
                    return this._tutorialAction;
                }
                set
                {
                    this._tutorialAction = value;
                }
            }
        }

        [ProtoContract(Name="GenNumDifficulty")]
        public class GenNumDifficulty : IExtensible
        {
            private int _genNum;
            private string _increaseAttribute = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="genNum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int genNum
            {
                get
                {
                    return this._genNum;
                }
                set
                {
                    this._genNum = value;
                }
            }

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="increaseAttribute", DataFormat=DataFormat.Default)]
            public string increaseAttribute
            {
                get
                {
                    return this._increaseAttribute;
                }
                set
                {
                    this._increaseAttribute = value;
                }
            }
        }

        [ProtoContract(Name="GridTutorial")]
        public class GridTutorial : IExtensible
        {
            private int _addStep;
            private int _factor;
            private int _gridTutorialType;
            private PveConfig.NPCGroup _npcGroup;
            private int _pos;
            private int _rewardRandom_RewardSetId;
            private readonly List<PveConfig.GameTutorialAction> _tutorialActions = new List<PveConfig.GameTutorialAction>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="addStep", DataFormat=DataFormat.TwosComplement)]
            public int addStep
            {
                get
                {
                    return this._addStep;
                }
                set
                {
                    this._addStep = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="factor", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int factor
            {
                get
                {
                    return this._factor;
                }
                set
                {
                    this._factor = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="gridTutorialType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int gridTutorialType
            {
                get
                {
                    return this._gridTutorialType;
                }
                set
                {
                    this._gridTutorialType = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="npcGroup", DataFormat=DataFormat.Default)]
            public PveConfig.NPCGroup npcGroup
            {
                get
                {
                    return this._npcGroup;
                }
                set
                {
                    this._npcGroup = value;
                }
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="pos", DataFormat=DataFormat.TwosComplement)]
            public int pos
            {
                get
                {
                    return this._pos;
                }
                set
                {
                    this._pos = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="rewardRandom_RewardSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int rewardRandom_RewardSetId
            {
                get
                {
                    return this._rewardRandom_RewardSetId;
                }
                set
                {
                    this._rewardRandom_RewardSetId = value;
                }
            }

            [ProtoMember(7, Name="tutorialActions", DataFormat=DataFormat.Default)]
            public List<PveConfig.GameTutorialAction> tutorialActions
            {
                get
                {
                    return this._tutorialActions;
                }
            }
        }

        [ProtoContract(Name="LevelReward")]
        public class LevelReward : IExtensible
        {
            private int _levelMax;
            private int _levelMin;
            private int _rewardSetId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="levelMax", DataFormat=DataFormat.TwosComplement)]
            public int levelMax
            {
                get
                {
                    return this._levelMax;
                }
                set
                {
                    this._levelMax = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="levelMin", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int levelMin
            {
                get
                {
                    return this._levelMin;
                }
                set
                {
                    this._levelMin = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="rewardSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int rewardSetId
            {
                get
                {
                    return this._rewardSetId;
                }
                set
                {
                    this._rewardSetId = value;
                }
            }
        }

        [ProtoContract(Name="NPCGroup")]
        public class NPCGroup : IExtensible
        {
            private int _id;
            private string _name = "";
            private readonly List<int> _npcResourceIds = new List<int>();
            private PveConfig.PveGroup _pveGroup;
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

            [ProtoMember(3, IsRequired=false, Name="name", DataFormat=DataFormat.Default), DefaultValue("")]
            public string name
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

            [ProtoMember(2, Name="npcResourceIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> npcResourceIds
            {
                get
                {
                    return this._npcResourceIds;
                }
            }

            public PveConfig.PveGroup pveGroup
            {
                get
                {
                    return this._pveGroup;
                }
                set
                {
                    this._pveGroup = value;
                }
            }
        }

        [ProtoContract(Name="OneKeySweep")]
        public class OneKeySweep : IExtensible
        {
            private int _back_AP;
            private int _back_DP;
            private int _back_MaxHP;
            private int _front_AP;
            private int _front_DP;
            private int _front_MaxHP;
            private int _playerLevelMax;
            private int _playerLevelMin;
            private float _randRate;
            private float _ratePvePointToAttribute;
            private int _vipLevelMax;
            private int _vipLevelMin;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(9, IsRequired=false, Name="back_AP", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int back_AP
            {
                get
                {
                    return this._back_AP;
                }
                set
                {
                    this._back_AP = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="back_DP", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int back_DP
            {
                get
                {
                    return this._back_DP;
                }
                set
                {
                    this._back_DP = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="back_MaxHP", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int back_MaxHP
            {
                get
                {
                    return this._back_MaxHP;
                }
                set
                {
                    this._back_MaxHP = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="front_AP", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int front_AP
            {
                get
                {
                    return this._front_AP;
                }
                set
                {
                    this._front_AP = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="front_DP", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int front_DP
            {
                get
                {
                    return this._front_DP;
                }
                set
                {
                    this._front_DP = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="front_MaxHP", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int front_MaxHP
            {
                get
                {
                    return this._front_MaxHP;
                }
                set
                {
                    this._front_MaxHP = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="playerLevelMax", DataFormat=DataFormat.TwosComplement)]
            public int playerLevelMax
            {
                get
                {
                    return this._playerLevelMax;
                }
                set
                {
                    this._playerLevelMax = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="playerLevelMin", DataFormat=DataFormat.TwosComplement)]
            public int playerLevelMin
            {
                get
                {
                    return this._playerLevelMin;
                }
                set
                {
                    this._playerLevelMin = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(12, IsRequired=false, Name="randRate", DataFormat=DataFormat.FixedSize)]
            public float randRate
            {
                get
                {
                    return this._randRate;
                }
                set
                {
                    this._randRate = value;
                }
            }

            [ProtoMember(11, IsRequired=false, Name="ratePvePointToAttribute", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float ratePvePointToAttribute
            {
                get
                {
                    return this._ratePvePointToAttribute;
                }
                set
                {
                    this._ratePvePointToAttribute = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="vipLevelMax", DataFormat=DataFormat.TwosComplement)]
            public int vipLevelMax
            {
                get
                {
                    return this._vipLevelMax;
                }
                set
                {
                    this._vipLevelMax = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="vipLevelMin", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int vipLevelMin
            {
                get
                {
                    return this._vipLevelMin;
                }
                set
                {
                    this._vipLevelMin = value;
                }
            }
        }

        [ProtoContract(Name="PrevAddAttributeReward")]
        public class PrevAddAttributeReward : IExtensible
        {
            private float _addAttributeValue;
            private readonly List<int> _pveBuffIds = new List<int>();
            private int _pvePointMax;
            private int _pvePointMin;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((float) 0f), ProtoMember(3, IsRequired=false, Name="addAttributeValue", DataFormat=DataFormat.FixedSize)]
            public float addAttributeValue
            {
                get
                {
                    return this._addAttributeValue;
                }
                set
                {
                    this._addAttributeValue = value;
                }
            }

            [ProtoMember(4, Name="pveBuffIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> pveBuffIds
            {
                get
                {
                    return this._pveBuffIds;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="pvePointMax", DataFormat=DataFormat.TwosComplement)]
            public int pvePointMax
            {
                get
                {
                    return this._pvePointMax;
                }
                set
                {
                    this._pvePointMax = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="pvePointMin", DataFormat=DataFormat.TwosComplement)]
            public int pvePointMin
            {
                get
                {
                    return this._pvePointMin;
                }
                set
                {
                    this._pvePointMin = value;
                }
            }
        }

        [ProtoContract(Name="PveGroup")]
        public class PveGroup : IExtensible
        {
            private int _factor;
            private readonly List<PveConfig.GenNumDifficulty> _genNumDifficultys = new List<PveConfig.GenNumDifficulty>();
            private int _id;
            private readonly List<PveConfig.NPCGroup> _npcGroups = new List<PveConfig.NPCGroup>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="factor", DataFormat=DataFormat.TwosComplement)]
            public int factor
            {
                get
                {
                    return this._factor;
                }
                set
                {
                    this._factor = value;
                }
            }

            [ProtoMember(4, Name="genNumDifficultys", DataFormat=DataFormat.Default)]
            public List<PveConfig.GenNumDifficulty> genNumDifficultys
            {
                get
                {
                    return this._genNumDifficultys;
                }
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

            [ProtoMember(3, Name="npcGroups", DataFormat=DataFormat.Default)]
            public List<PveConfig.NPCGroup> npcGroups
            {
                get
                {
                    return this._npcGroups;
                }
            }
        }

        [ProtoContract(Name="PveLevel")]
        public class PveLevel : IExtensible
        {
            private int _level;
            private readonly List<PveConfig.PveGroup> _pveGroups = new List<PveConfig.PveGroup>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
            public int level
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

            [ProtoMember(2, Name="pveGroups", DataFormat=DataFormat.Default)]
            public List<PveConfig.PveGroup> pveGroups
            {
                get
                {
                    return this._pveGroups;
                }
            }
        }

        [ProtoContract(Name="PveLevelExpression")]
        public class PveLevelExpression : IExtensible
        {
            private string _expresion_back_ap = "";
            private string _expresion_back_dp = "";
            private string _expresion_back_hp = "";
            private string _expresion_front_ap = "";
            private string _expresion_front_dp = "";
            private string _expresion_front_hp = "";
            private int _level;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, IsRequired=false, Name="expresion_back_ap", DataFormat=DataFormat.Default), DefaultValue("")]
            public string expresion_back_ap
            {
                get
                {
                    return this._expresion_back_ap;
                }
                set
                {
                    this._expresion_back_ap = value;
                }
            }

            [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="expresion_back_dp", DataFormat=DataFormat.Default)]
            public string expresion_back_dp
            {
                get
                {
                    return this._expresion_back_dp;
                }
                set
                {
                    this._expresion_back_dp = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="expresion_back_hp", DataFormat=DataFormat.Default), DefaultValue("")]
            public string expresion_back_hp
            {
                get
                {
                    return this._expresion_back_hp;
                }
                set
                {
                    this._expresion_back_hp = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="expresion_front_ap", DataFormat=DataFormat.Default), DefaultValue("")]
            public string expresion_front_ap
            {
                get
                {
                    return this._expresion_front_ap;
                }
                set
                {
                    this._expresion_front_ap = value;
                }
            }

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="expresion_front_dp", DataFormat=DataFormat.Default)]
            public string expresion_front_dp
            {
                get
                {
                    return this._expresion_front_dp;
                }
                set
                {
                    this._expresion_front_dp = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="expresion_front_hp", DataFormat=DataFormat.Default)]
            public string expresion_front_hp
            {
                get
                {
                    return this._expresion_front_hp;
                }
                set
                {
                    this._expresion_front_hp = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int level
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
        }

        [ProtoContract(Name="PveNpcActiveSkillLevel")]
        public class PveNpcActiveSkillLevel : IExtensible
        {
            private int _activeSkillLevel;
            private int _level;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="activeSkillLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int activeSkillLevel
            {
                get
                {
                    return this._activeSkillLevel;
                }
                set
                {
                    this._activeSkillLevel = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int level
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
        }

        [ProtoContract(Name="PveSetting")]
        public class PveSetting : IExtensible
        {
            private int _activityId;
            private PveConfig.EventSetting _eventSetting;
            private int _exchange;
            private PveConfig.Game _game;
            private PveConfig.GameReward _gameReward;
            private PveConfig.GameTutorial _tutorial;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="activityId", DataFormat=DataFormat.TwosComplement)]
            public int activityId
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

            [DefaultValue((string) null), ProtoMember(6, IsRequired=false, Name="eventSetting", DataFormat=DataFormat.Default)]
            public PveConfig.EventSetting eventSetting
            {
                get
                {
                    return this._eventSetting;
                }
                set
                {
                    this._eventSetting = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="exchange", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int exchange
            {
                get
                {
                    return this._exchange;
                }
                set
                {
                    this._exchange = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="game", DataFormat=DataFormat.Default)]
            public PveConfig.Game game
            {
                get
                {
                    return this._game;
                }
                set
                {
                    this._game = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="gameReward", DataFormat=DataFormat.Default)]
            public PveConfig.GameReward gameReward
            {
                get
                {
                    return this._gameReward;
                }
                set
                {
                    this._gameReward = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="tutorial", DataFormat=DataFormat.Default)]
            public PveConfig.GameTutorial tutorial
            {
                get
                {
                    return this._tutorial;
                }
                set
                {
                    this._tutorial = value;
                }
            }
        }

        [ProtoContract(Name="RankReward")]
        public class RankReward : IExtensible
        {
            private int _rankMax;
            private int _rankMin;
            private int _rewardSetId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="rankMax", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int rankMax
            {
                get
                {
                    return this._rankMax;
                }
                set
                {
                    this._rankMax = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="rankMin", DataFormat=DataFormat.TwosComplement)]
            public int rankMin
            {
                get
                {
                    return this._rankMin;
                }
                set
                {
                    this._rankMin = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="rewardSetId", DataFormat=DataFormat.TwosComplement)]
            public int rewardSetId
            {
                get
                {
                    return this._rewardSetId;
                }
                set
                {
                    this._rewardSetId = value;
                }
            }
        }
    }
}

