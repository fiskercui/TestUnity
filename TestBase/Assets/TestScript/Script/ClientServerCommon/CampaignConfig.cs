namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="CampaignConfig")]
    public class CampaignConfig : Configuration, IExtensible
    {
        private int _gameMoneyGetDungeonId;
        private readonly List<Zone> _secretZones = new List<Zone>();
        private readonly List<StarReward> _starRewards = new List<StarReward>();
        private readonly List<TravelGood> _travelGoods = new List<TravelGood>();
        private int _travelTraderIconBuyAllId;
        private int _travelTraderIconCloseId;
        private int _travelTraderIconOpenId;
        private readonly List<TravelTrader> _travelTraders = new List<TravelTrader>();
        private readonly List<Zone> _zones = new List<Zone>();
        private IExtension extensionObject;
        private Dictionary<int, Dungeon> id_dungeonMap = new Dictionary<int, Dungeon>();
        private Dictionary<int, Zone> id_secretZoneMap = new Dictionary<int, Zone>();
        private Dictionary<int, TravelGood> id_travelGood = new Dictionary<int, TravelGood>();
        private Dictionary<int, TravelTrader> id_travelTrader = new Dictionary<int, TravelTrader>();
        private Dictionary<int, Zone> id_zoneMap = new Dictionary<int, Zone>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Zone zone in this._zones)
            {
                if (zone != null)
                {
                    if (this.id_zoneMap.ContainsKey(zone.zoneId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + zone.zoneId.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_zoneMap.Add(zone.zoneId, zone);
                        foreach (DungeonDifficulty difficulty in zone.dungeonDifficulties)
                        {
                            foreach (Dungeon dungeon in difficulty.dungeons)
                            {
                                if (dungeon != null)
                                {
                                    if (this.id_dungeonMap.ContainsKey(dungeon.dungeonId))
                                    {
                                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + dungeon.dungeonId.ToString("X"), new object[0]);
                                    }
                                    else
                                    {
                                        dungeon.ZoneId = zone.zoneId;
                                        dungeon.DungeonDifficulty = difficulty.difficultyType;
                                        this.id_dungeonMap.Add(dungeon.dungeonId, dungeon);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (Zone zone2 in this._secretZones)
            {
                if (zone2 != null)
                {
                    if (this.id_secretZoneMap.ContainsKey(zone2.zoneId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + zone2.zoneId.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_secretZoneMap.Add(zone2.zoneId, zone2);
                        foreach (DungeonDifficulty difficulty2 in zone2.dungeonDifficulties)
                        {
                            foreach (Dungeon dungeon2 in difficulty2.dungeons)
                            {
                                if (dungeon2 != null)
                                {
                                    if (this.id_dungeonMap.ContainsKey(dungeon2.dungeonId))
                                    {
                                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + dungeon2.dungeonId.ToString("X"), new object[0]);
                                    }
                                    else
                                    {
                                        dungeon2.ZoneId = zone2.zoneId;
                                        dungeon2.DungeonDifficulty = difficulty2.difficultyType;
                                        this.id_dungeonMap.Add(dungeon2.dungeonId, dungeon2);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (TravelTrader trader in this.travelTraders)
            {
                if (trader != null)
                {
                    if (this.id_travelTrader.ContainsKey(trader.dungeonId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + trader.dungeonId.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_travelTrader.Add(trader.dungeonId, trader);
                    }
                }
            }
            foreach (TravelGood good in this.travelGoods)
            {
                if (good != null)
                {
                    if (this.id_travelGood.ContainsKey(good.goodId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey Good Id 0x" + good.goodId.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_travelGood.Add(good.goodId, good);
                    }
                }
            }
        }

        public Dungeon GetDungeonById(int dungeonId)
        {
            Dungeon dungeon;
            if (!this.id_dungeonMap.TryGetValue(dungeonId, out dungeon))
            {
                return null;
            }
            return dungeon;
        }

        public StarReward GetStarRewardById(int startRewardId)
        {
            foreach (StarReward reward in this._starRewards)
            {
                if (reward.starRewardId == startRewardId)
                {
                    return reward;
                }
            }
            return null;
        }

        public TravelGood GetTravelGoodById(int id)
        {
            if (this.id_travelGood.ContainsKey(id))
            {
                return this.id_travelGood[id];
            }
            return null;
        }

        public TravelTrader GetTravelTradeByDungeonId(int dungeonId)
        {
            if (this.id_travelTrader.ContainsKey(dungeonId))
            {
                return this.id_travelTrader[dungeonId];
            }
            return null;
        }

        public Zone GetZoneByDungeonId(int dungeonId)
        {
            foreach (Zone zone in this._zones)
            {
                foreach (DungeonDifficulty difficulty in zone.dungeonDifficulties)
                {
                    foreach (Dungeon dungeon in difficulty.dungeons)
                    {
                        if (dungeon.dungeonId == dungeonId)
                        {
                            return zone;
                        }
                    }
                }
            }
            return null;
        }

        public Zone GetZoneById(int zoneId)
        {
            Zone zone = null;
            if (!this.id_zoneMap.TryGetValue(zoneId, out zone))
            {
                this.id_secretZoneMap.TryGetValue(zoneId, out zone);
            }
            return zone;
        }

        public int GetZonesIndexById(int zonesId)
        {
            for (int i = 0; i < this._zones.Count; i++)
            {
                if (this._zones[i].zoneId == zonesId)
                {
                    return i;
                }
            }
            return 0;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _NpcType.Initialize();
            _StateDialogueType.Initialize();
            _StarRewardEvaType.Initialize();
            ClientServerCommon._CampType.Initialize();
        }

        public bool IsActivityZoneId(int zoneId)
        {
            return this.id_secretZoneMap.ContainsKey(zoneId);
        }

        private DungeonDifficulty LoadDungeonDifficultyFromXml(SecurityElement element)
        {
            DungeonDifficulty difficulty = new DungeonDifficulty {
                difficultyType = TypeNameContainer<_DungeonDifficulity>.Parse(element.Attribute("DifficultyType"), 1),
                levelLimit = StrParser.ParseDecInt(element.Attribute("LevelLimit"), 0),
                positionName = StrParser.ParseStr(element.Attribute("PositionName"), string.Empty)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Dungeon")
                        {
                            difficulty.dungeons.Add(this.LoadDungeonFromXml(element2));
                        }
                        else if (tag == "StarRewardCondition")
                        {
                            goto Label_00AE;
                        }
                    }
                    continue;
                Label_00AE:
                    difficulty.starRewardConditions.Add(LoadStarRewardConditionFromXml(element2));
                }
            }
            return difficulty;
        }

        private Dungeon LoadDungeonFromXml(SecurityElement element)
        {
            Dungeon dungeon = new Dungeon {
                dungeonId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                iconOpen = StrParser.ParseHexInt(element.Attribute("IconOpen"), 0),
                iconClose = StrParser.ParseHexInt(element.Attribute("IconClose"), 0),
                sceneId = StrParser.ParseHexInt(element.Attribute("SceneId"), 0),
                levelLimit = StrParser.ParseDecInt(element.Attribute("LevelLimit"), 0),
                difficulty = TypeNameContainer<_Difficulty>.Parse(element.Attribute("Difficulty"), 1),
                enterCount = StrParser.ParseDecInt(element.Attribute("EnterCount"), 0),
                resetCount = StrParser.ParseDecInt(element.Attribute("ResetCount"), 0),
                canEmploy = StrParser.ParseBool(element.Attribute("CanEmploy"), false),
                passRewardSetId = StrParser.ParseHexInt(element.Attribute("PassRewardSetId"), 0),
                firstPassRewardSetId = StrParser.ParseHexInt(element.Attribute("FirstPassRewardSetId"), 0),
                firstThreeStarRewardSetId = StrParser.ParseHexInt(element.Attribute("FirstThreeStarRewardSetId"), 0),
                allDeadWhoWin = TypeNameContainer<ClientServerCommon._CampType>.Parse(element.Attribute("AllDeadWhoWin"), 0),
                maxRound = StrParser.ParseDecInt(element.Attribute("MaxRound"), 0),
                maxRoundWhoWin = TypeNameContainer<ClientServerCommon._CampType>.Parse(element.Attribute("MaxRoundWhoWin"), 0),
                canContinueCombat = StrParser.ParseBool(element.Attribute("CanContinueCombat"), false),
                hasGuide = StrParser.ParseBool(element.Attribute("HasGuide"), false),
                guideStageIndex = StrParser.ParseDecInt(element.Attribute("GuideStageIndex"), 0),
                guideDesc = StrParser.ParseStr(element.Attribute("GuideDesc"), string.Empty),
                plotCombatFile = StrParser.ParseStr(element.Attribute("PlotCombatFile"), string.Empty),
                recruiteDesc = StrParser.ParseStr(element.Attribute("RecruiteDesc"), string.Empty)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    switch (element2.Tag)
                    {
                        case "EmployableNpc":
                            dungeon.employableNpcs.Add(StrParser.ParseHexInt(element2.Attribute("Id"), 0));
                            break;

                        case "EnterCost":
                            dungeon.enterCosts.Add(Cost.LoadFromXml(element2));
                            break;

                        case "ResetCost":
                            dungeon.resetCosts.Add(Cost.LoadFromXml(element2));
                            break;

                        case "FixedReward":
                            dungeon.fixedRewards.Add(Reward.LoadFromXml(element2));
                            break;

                        case "DisplayReward":
                            dungeon.displayRewards.Add(Reward.LoadFromXml(element2));
                            break;

                        case "FirstPassReward":
                            dungeon.firstPassRewards.Add(Reward.LoadFromXml(element2));
                            break;

                        case "StarCondition":
                            dungeon.startCondition.Add(LoadStarConditionFromXml(element2));
                            break;

                        case "StageDialogue":
                            dungeon.stageDialogues.Add(LoadStageDialogueFromXml(element2));
                            break;
                    }
                }
            }
            return dungeon;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "CampaignConfig")
            {
                this._gameMoneyGetDungeonId = StrParser.ParseHexInt(element.Attribute("GameMoneyGetDungeonId"), 0);
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "ZoneSetting")
                        {
                            if (tag == "SecretZoneSetting")
                            {
                                goto Label_008D;
                            }
                            if (tag == "StarSetting")
                            {
                                goto Label_0096;
                            }
                            if (tag == "TravelSetting")
                            {
                                goto Label_009F;
                            }
                        }
                        else
                        {
                            this.LoadZoneSettingFromXml(element2);
                        }
                    }
                    continue;
                Label_008D:
                    this.LoadSecretZoneSettingFromXml(element2);
                    continue;
                Label_0096:
                    this.LoadStartSettingFromXml(element2);
                    continue;
                Label_009F:
                    this.LoadTravelSettingFromXml(element2);
                }
            }
        }

        private void LoadSecretZoneSettingFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Zone")
                    {
                        this._secretZones.Add(this.LoadZoneFromXml(element2));
                    }
                }
            }
        }

        public static StageDialogue LoadStageDialogueFromXml(SecurityElement element)
        {
            return new StageDialogue { 
                stageType = TypeNameContainer<_StateDialogueType>.Parse(element.Attribute("StageType"), 0),
                stageIndex = StrParser.ParseDecInt(element.Attribute("StageIndex"), 0),
                dialogueId = StrParser.ParseHexInt(element.Attribute("DialogueId"), 0)
            };
        }

        public static StarCondition LoadStarConditionFromXml(SecurityElement element)
        {
            return new StarCondition { 
                desc = StrParser.ParseStr(element.Attribute("Desc"), string.Empty),
                type = TypeNameContainer<_StarRewardEvaType>.Parse(element.Attribute("Type"), 0),
                compareType = TypeNameContainer<_ConditionValueCompareType>.Parse(element.Attribute("CompareType"), 0),
                compareIntValue = StrParser.ParseDecInt(element.Attribute("CompareIntValue"), 0),
                compareFloatValue = StrParser.ParseFloat(element.Attribute("CompareFloatValue"), 0f)
            };
        }

        public static StarRewardCondition LoadStarRewardConditionFromXml(SecurityElement element)
        {
            return new StarRewardCondition { 
                requireStarCount = StrParser.ParseDecInt(element.Attribute("RequireStarCount"), 0),
                starRewardId = StrParser.ParseHexInt(element.Attribute("StarRewardId"), 0)
            };
        }

        public static StarReward LoadStarRewardFromXml(SecurityElement element)
        {
            StarReward reward = new StarReward {
                starRewardId = StrParser.ParseHexInt(element.Attribute("Id"), 0)
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

        private void LoadStartSettingFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "StarReward")
                    {
                        this._starRewards.Add(LoadStarRewardFromXml(element2));
                    }
                }
            }
        }

        public static TravelGood LoadTravelGoodFromXml(SecurityElement element)
        {
            TravelGood good = new TravelGood {
                goodId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                continueTime = StrParser.ParseDecInt(element.Attribute("ContinueTime"), -1)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Cost")
                        {
                            good.costs.Add(Cost.LoadFromXml(element2));
                        }
                        else if (tag == "Reward")
                        {
                            goto Label_0092;
                        }
                    }
                    continue;
                Label_0092:
                    good.rewards.Add(Reward.LoadFromXml(element2));
                }
            }
            return good;
        }

        private void LoadTravelSettingFromXml(SecurityElement element)
        {
            this._travelTraderIconOpenId = StrParser.ParseHexInt(element.Attribute("TravelTraderIconOpenId"), 0);
            this._travelTraderIconCloseId = StrParser.ParseHexInt(element.Attribute("TravelTraderIconCloseId"), 0);
            this._travelTraderIconBuyAllId = StrParser.ParseHexInt(element.Attribute("TravelTraderIconBuyAllId"), 0);
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "TravelTrader")
                        {
                            this._travelTraders.Add(LoadTravelTraderFromXml(element2));
                        }
                        else if (tag == "TravelGood")
                        {
                            goto Label_00A0;
                        }
                    }
                    continue;
                Label_00A0:
                    this._travelGoods.Add(LoadTravelGoodFromXml(element2));
                }
            }
        }

        public static TravelTrader LoadTravelTraderFromXml(SecurityElement element)
        {
            TravelTrader trader = new TravelTrader {
                zoneId = StrParser.ParseHexInt(element.Attribute("ZoneId"), 0),
                dungeonId = StrParser.ParseHexInt(element.Attribute("DungeonId"), 0),
                openNeedStars = StrParser.ParseDecInt(element.Attribute("OpenNeedStars"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "CanBuyGoodsId")
                    {
                        trader.canBuyGoodsIds.Add(StrParser.ParseHexInt(element2.Attribute("GoodId"), 0));
                    }
                }
            }
            return trader;
        }

        private Zone LoadZoneFromXml(SecurityElement element)
        {
            Zone zone = new Zone {
                zoneId = StrParser.ParseHexInt(element.Attribute("Id"), 0)
            };
            zone.dialogueId = StrParser.ParseHexInt(element.Attribute("DialogueId"), zone.dialogueId);
            zone.activityId = StrParser.ParseHexInt(element.Attribute("ActivityId"), 0);
            zone.openDesc = StrParser.ParseStr(element.Attribute("OpenDesc"), "");
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "ZoneModelOpen")
                        {
                            if (tag == "ZoneModelClose")
                            {
                                goto Label_00D2;
                            }
                            if (tag == "DungeonDifficulty")
                            {
                                goto Label_00E1;
                            }
                        }
                        else
                        {
                            zone.zoneModelOpen = this.LoadZoneModelFromXml(element2);
                        }
                    }
                    continue;
                Label_00D2:
                    zone.zoneModelClose = this.LoadZoneModelFromXml(element2);
                    continue;
                Label_00E1:
                    zone.dungeonDifficulties.Add(this.LoadDungeonDifficultyFromXml(element2));
                }
            }
            return zone;
        }

        private ZoneModel LoadZoneModelFromXml(SecurityElement element)
        {
            return new ZoneModel { 
                modelName = StrParser.ParseStr(element.Attribute("ModelName"), string.Empty),
                modelIdleAnim = StrParser.ParseStr(element.Attribute("ModelIdleAnim"), string.Empty),
                modelEffectAnim = StrParser.ParseStr(element.Attribute("ModelEffectAnim"), string.Empty)
            };
        }

        private void LoadZoneSettingFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Zone")
                    {
                        this._zones.Add(this.LoadZoneFromXml(element2));
                    }
                }
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="gameMoneyGetDungeonId", DataFormat=DataFormat.TwosComplement)]
        public int gameMoneyGetDungeonId
        {
            get
            {
                return this._gameMoneyGetDungeonId;
            }
            set
            {
                this._gameMoneyGetDungeonId = value;
            }
        }

        [ProtoMember(2, Name="secretZones", DataFormat=DataFormat.Default)]
        public List<Zone> secretZones
        {
            get
            {
                return this._secretZones;
            }
        }

        [ProtoMember(3, Name="starRewards", DataFormat=DataFormat.Default)]
        public List<StarReward> starRewards
        {
            get
            {
                return this._starRewards;
            }
        }

        [ProtoMember(5, Name="travelGoods", DataFormat=DataFormat.Default)]
        public List<TravelGood> travelGoods
        {
            get
            {
                return this._travelGoods;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="travelTraderIconBuyAllId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int travelTraderIconBuyAllId
        {
            get
            {
                return this._travelTraderIconBuyAllId;
            }
            set
            {
                this._travelTraderIconBuyAllId = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="travelTraderIconCloseId", DataFormat=DataFormat.TwosComplement)]
        public int travelTraderIconCloseId
        {
            get
            {
                return this._travelTraderIconCloseId;
            }
            set
            {
                this._travelTraderIconCloseId = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="travelTraderIconOpenId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int travelTraderIconOpenId
        {
            get
            {
                return this._travelTraderIconOpenId;
            }
            set
            {
                this._travelTraderIconOpenId = value;
            }
        }

        [ProtoMember(4, Name="travelTraders", DataFormat=DataFormat.Default)]
        public List<TravelTrader> travelTraders
        {
            get
            {
                return this._travelTraders;
            }
        }

        [ProtoMember(1, Name="zones", DataFormat=DataFormat.Default)]
        public List<Zone> zones
        {
            get
            {
                return this._zones;
            }
        }

        [ProtoContract(Name="Dungeon")]
        public class Dungeon : IExtensible
        {
            private int _allDeadWhoWin;
            private bool _canContinueCombat;
            private bool _canEmploy;
            private int _difficulty;
            private readonly List<Reward> _displayRewards = new List<Reward>();
            private int _dungeonId;
            private readonly List<int> _employableNpcs = new List<int>();
            private readonly List<Cost> _enterCosts = new List<Cost>();
            private int _enterCount;
            private readonly List<Reward> _firstPassRewards = new List<Reward>();
            private int _firstPassRewardSetId;
            private int _firstThreeStarRewardSetId;
            private readonly List<Reward> _fixedRewards = new List<Reward>();
            private string _guideDesc = "";
            private int _guideStageIndex;
            private bool _hasGuide;
            private int _iconClose;
            private int _iconOpen;
            private int _levelLimit;
            private int _maxRound;
            private int _maxRoundWhoWin;
            private int _passRewardSetId;
            private string _plotCombatFile = "";
            private string _recruiteDesc = "";
            private readonly List<Cost> _resetCosts = new List<Cost>();
            private int _resetCount;
            private int _sceneId;
            private readonly List<CampaignConfig.StageDialogue> _stageDialogues = new List<CampaignConfig.StageDialogue>();
            private readonly List<CampaignConfig.StarCondition> _startCondition = new List<CampaignConfig.StarCondition>();
            private int dungeonDifficulty;
            private IExtension extensionObject;
            private int zoneId;

            public CampaignConfig.StageDialogue GetStageDialogue(int stageIndex, int stateType)
            {
                foreach (CampaignConfig.StageDialogue dialogue in this.stageDialogues)
                {
                    if (dialogue.stageType == stateType)
                    {
                        if (stateType == 1)
                        {
                            return dialogue;
                        }
                        if (dialogue.stageIndex == stageIndex)
                        {
                            return dialogue;
                        }
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(20, IsRequired=false, Name="allDeadWhoWin", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int allDeadWhoWin
            {
                get
                {
                    return this._allDeadWhoWin;
                }
                set
                {
                    this._allDeadWhoWin = value;
                }
            }

            [DefaultValue(false), ProtoMember(0x17, IsRequired=false, Name="canContinueCombat", DataFormat=DataFormat.Default)]
            public bool canContinueCombat
            {
                get
                {
                    return this._canContinueCombat;
                }
                set
                {
                    this._canContinueCombat = value;
                }
            }

            [DefaultValue(false), ProtoMember(12, IsRequired=false, Name="canEmploy", DataFormat=DataFormat.Default)]
            public bool canEmploy
            {
                get
                {
                    return this._canEmploy;
                }
                set
                {
                    this._canEmploy = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="difficulty", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int difficulty
            {
                get
                {
                    return this._difficulty;
                }
                set
                {
                    this._difficulty = value;
                }
            }

            [ProtoMember(0x12, Name="displayRewards", DataFormat=DataFormat.Default)]
            public List<Reward> displayRewards
            {
                get
                {
                    return this._displayRewards;
                }
            }

            public int DungeonDifficulty
            {
                get
                {
                    return this.dungeonDifficulty;
                }
                set
                {
                    this.dungeonDifficulty = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="dungeonId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int dungeonId
            {
                get
                {
                    return this._dungeonId;
                }
                set
                {
                    this._dungeonId = value;
                }
            }

            [ProtoMember(13, Name="employableNpcs", DataFormat=DataFormat.TwosComplement)]
            public List<int> employableNpcs
            {
                get
                {
                    return this._employableNpcs;
                }
            }

            [ProtoMember(9, Name="enterCosts", DataFormat=DataFormat.Default)]
            public List<Cost> enterCosts
            {
                get
                {
                    return this._enterCosts;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="enterCount", DataFormat=DataFormat.TwosComplement)]
            public int enterCount
            {
                get
                {
                    return this._enterCount;
                }
                set
                {
                    this._enterCount = value;
                }
            }

            [ProtoMember(0x1d, Name="firstPassRewards", DataFormat=DataFormat.Default)]
            public List<Reward> firstPassRewards
            {
                get
                {
                    return this._firstPassRewards;
                }
            }

            [ProtoMember(0x10, IsRequired=false, Name="firstPassRewardSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int firstPassRewardSetId
            {
                get
                {
                    return this._firstPassRewardSetId;
                }
                set
                {
                    this._firstPassRewardSetId = value;
                }
            }

            [ProtoMember(0x11, IsRequired=false, Name="firstThreeStarRewardSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int firstThreeStarRewardSetId
            {
                get
                {
                    return this._firstThreeStarRewardSetId;
                }
                set
                {
                    this._firstThreeStarRewardSetId = value;
                }
            }

            [ProtoMember(14, Name="fixedRewards", DataFormat=DataFormat.Default)]
            public List<Reward> fixedRewards
            {
                get
                {
                    return this._fixedRewards;
                }
            }

            [ProtoMember(0x1b, IsRequired=false, Name="guideDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string guideDesc
            {
                get
                {
                    return this._guideDesc;
                }
                set
                {
                    this._guideDesc = value;
                }
            }

            [ProtoMember(0x1a, IsRequired=false, Name="guideStageIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int guideStageIndex
            {
                get
                {
                    return this._guideStageIndex;
                }
                set
                {
                    this._guideStageIndex = value;
                }
            }

            [DefaultValue(false), ProtoMember(0x19, IsRequired=false, Name="hasGuide", DataFormat=DataFormat.Default)]
            public bool hasGuide
            {
                get
                {
                    return this._hasGuide;
                }
                set
                {
                    this._hasGuide = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="iconClose", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int iconClose
            {
                get
                {
                    return this._iconClose;
                }
                set
                {
                    this._iconClose = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="iconOpen", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int iconOpen
            {
                get
                {
                    return this._iconOpen;
                }
                set
                {
                    this._iconOpen = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="levelLimit", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int levelLimit
            {
                get
                {
                    return this._levelLimit;
                }
                set
                {
                    this._levelLimit = value;
                }
            }

            [ProtoMember(0x15, IsRequired=false, Name="maxRound", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int maxRound
            {
                get
                {
                    return this._maxRound;
                }
                set
                {
                    this._maxRound = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x16, IsRequired=false, Name="maxRoundWhoWin", DataFormat=DataFormat.TwosComplement)]
            public int maxRoundWhoWin
            {
                get
                {
                    return this._maxRoundWhoWin;
                }
                set
                {
                    this._maxRoundWhoWin = value;
                }
            }

            [DefaultValue(0), ProtoMember(15, IsRequired=false, Name="passRewardSetId", DataFormat=DataFormat.TwosComplement)]
            public int passRewardSetId
            {
                get
                {
                    return this._passRewardSetId;
                }
                set
                {
                    this._passRewardSetId = value;
                }
            }

            [DefaultValue(""), ProtoMember(0x1c, IsRequired=false, Name="plotCombatFile", DataFormat=DataFormat.Default)]
            public string plotCombatFile
            {
                get
                {
                    return this._plotCombatFile;
                }
                set
                {
                    this._plotCombatFile = value;
                }
            }

            [DefaultValue(""), ProtoMember(0x1f, IsRequired=false, Name="recruiteDesc", DataFormat=DataFormat.Default)]
            public string recruiteDesc
            {
                get
                {
                    return this._recruiteDesc;
                }
                set
                {
                    this._recruiteDesc = value;
                }
            }

            [ProtoMember(11, Name="resetCosts", DataFormat=DataFormat.Default)]
            public List<Cost> resetCosts
            {
                get
                {
                    return this._resetCosts;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="resetCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int resetCount
            {
                get
                {
                    return this._resetCount;
                }
                set
                {
                    this._resetCount = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="sceneId", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(0x18, Name="stageDialogues", DataFormat=DataFormat.Default)]
            public List<CampaignConfig.StageDialogue> stageDialogues
            {
                get
                {
                    return this._stageDialogues;
                }
            }

            [ProtoMember(0x13, Name="startCondition", DataFormat=DataFormat.Default)]
            public List<CampaignConfig.StarCondition> startCondition
            {
                get
                {
                    return this._startCondition;
                }
            }

            public int ZoneId
            {
                get
                {
                    return this.zoneId;
                }
                set
                {
                    this.zoneId = value;
                }
            }
        }

        [ProtoContract(Name="DungeonDifficulty")]
        public class DungeonDifficulty : IExtensible
        {
            private int _difficultyType;
            private readonly List<CampaignConfig.Dungeon> _dungeons = new List<CampaignConfig.Dungeon>();
            private int _levelLimit;
            private string _positionName = "";
            private readonly List<CampaignConfig.StarRewardCondition> _starRewardConditions = new List<CampaignConfig.StarRewardCondition>();
            private IExtension extensionObject;

            public CampaignConfig.Dungeon GetDungeonById(int dungeonId)
            {
                foreach (CampaignConfig.Dungeon dungeon in this._dungeons)
                {
                    if (dungeon.dungeonId == dungeonId)
                    {
                        return dungeon;
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="difficultyType", DataFormat=DataFormat.TwosComplement)]
            public int difficultyType
            {
                get
                {
                    return this._difficultyType;
                }
                set
                {
                    this._difficultyType = value;
                }
            }

            [ProtoMember(4, Name="dungeons", DataFormat=DataFormat.Default)]
            public List<CampaignConfig.Dungeon> dungeons
            {
                get
                {
                    return this._dungeons;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="levelLimit", DataFormat=DataFormat.TwosComplement)]
            public int levelLimit
            {
                get
                {
                    return this._levelLimit;
                }
                set
                {
                    this._levelLimit = value;
                }
            }

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="positionName", DataFormat=DataFormat.Default)]
            public string positionName
            {
                get
                {
                    return this._positionName;
                }
                set
                {
                    this._positionName = value;
                }
            }

            [ProtoMember(3, Name="starRewardConditions", DataFormat=DataFormat.Default)]
            public List<CampaignConfig.StarRewardCondition> starRewardConditions
            {
                get
                {
                    return this._starRewardConditions;
                }
            }
        }

        [ProtoContract(Name="StageDialogue")]
        public class StageDialogue : IExtensible
        {
            private int _dialogueId;
            private int _stageIndex;
            private int _stageType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="dialogueId", DataFormat=DataFormat.TwosComplement)]
            public int dialogueId
            {
                get
                {
                    return this._dialogueId;
                }
                set
                {
                    this._dialogueId = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="stageIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int stageIndex
            {
                get
                {
                    return this._stageIndex;
                }
                set
                {
                    this._stageIndex = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="stageType", DataFormat=DataFormat.TwosComplement)]
            public int stageType
            {
                get
                {
                    return this._stageType;
                }
                set
                {
                    this._stageType = value;
                }
            }
        }

        [ProtoContract(Name="StarCondition")]
        public class StarCondition : IExtensible
        {
            private float _compareFloatValue;
            private int _compareIntValue;
            private int _compareType;
            private string _desc = "";
            private int _type;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((float) 0f), ProtoMember(5, IsRequired=false, Name="compareFloatValue", DataFormat=DataFormat.FixedSize)]
            public float compareFloatValue
            {
                get
                {
                    return this._compareFloatValue;
                }
                set
                {
                    this._compareFloatValue = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="compareIntValue", DataFormat=DataFormat.TwosComplement)]
            public int compareIntValue
            {
                get
                {
                    return this._compareIntValue;
                }
                set
                {
                    this._compareIntValue = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="compareType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int compareType
            {
                get
                {
                    return this._compareType;
                }
                set
                {
                    this._compareType = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string desc
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
        }

        [ProtoContract(Name="StarReward")]
        public class StarReward : IExtensible
        {
            private readonly List<Reward> _rewards = new List<Reward>();
            private int _starRewardId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> rewards
            {
                get
                {
                    return this._rewards;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="starRewardId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int starRewardId
            {
                get
                {
                    return this._starRewardId;
                }
                set
                {
                    this._starRewardId = value;
                }
            }
        }

        [ProtoContract(Name="StarRewardCondition")]
        public class StarRewardCondition : IExtensible
        {
            private int _requireStarCount;
            private int _starRewardId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="requireStarCount", DataFormat=DataFormat.TwosComplement)]
            public int requireStarCount
            {
                get
                {
                    return this._requireStarCount;
                }
                set
                {
                    this._requireStarCount = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="starRewardId", DataFormat=DataFormat.TwosComplement)]
            public int starRewardId
            {
                get
                {
                    return this._starRewardId;
                }
                set
                {
                    this._starRewardId = value;
                }
            }
        }

        [ProtoContract(Name="TravelGood")]
        public class TravelGood : IExtensible
        {
            private int _continueTime;
            private readonly List<Cost> _costs = new List<Cost>();
            private int _goodId;
            private readonly List<Reward> _rewards = new List<Reward>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="continueTime", DataFormat=DataFormat.TwosComplement)]
            public int continueTime
            {
                get
                {
                    return this._continueTime;
                }
                set
                {
                    this._continueTime = value;
                }
            }

            [ProtoMember(3, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> costs
            {
                get
                {
                    return this._costs;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="goodId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int goodId
            {
                get
                {
                    return this._goodId;
                }
                set
                {
                    this._goodId = value;
                }
            }

            [ProtoMember(4, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> rewards
            {
                get
                {
                    return this._rewards;
                }
            }
        }

        [ProtoContract(Name="TravelTrader")]
        public class TravelTrader : IExtensible
        {
            private readonly List<int> _canBuyGoodsIds = new List<int>();
            private int _dungeonId;
            private int _openNeedStars;
            private int _zoneId;
            private IExtension extensionObject;

            public bool ContainGoodsId(int goodsId)
            {
                foreach (int num in this._canBuyGoodsIds)
                {
                    if (num == goodsId)
                    {
                        return true;
                    }
                }
                return false;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, Name="canBuyGoodsIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> canBuyGoodsIds
            {
                get
                {
                    return this._canBuyGoodsIds;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="dungeonId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int dungeonId
            {
                get
                {
                    return this._dungeonId;
                }
                set
                {
                    this._dungeonId = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="openNeedStars", DataFormat=DataFormat.TwosComplement)]
            public int openNeedStars
            {
                get
                {
                    return this._openNeedStars;
                }
                set
                {
                    this._openNeedStars = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="zoneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoContract(Name="Zone")]
        public class Zone : IExtensible
        {
            private int _activityId;
            private int _dialogueId;
            private readonly List<CampaignConfig.DungeonDifficulty> _dungeonDifficulties = new List<CampaignConfig.DungeonDifficulty>();
            private string _openDesc = "";
            private int _zoneId;
            private CampaignConfig.ZoneModel _zoneModelClose;
            private CampaignConfig.ZoneModel _zoneModelOpen;
            private IExtension extensionObject;

            public CampaignConfig.DungeonDifficulty GetDungeonDifficultyByDifficulty(int difficultyType)
            {
                foreach (CampaignConfig.DungeonDifficulty difficulty in this._dungeonDifficulties)
                {
                    if (difficulty.difficultyType == difficultyType)
                    {
                        return difficulty;
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="activityId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(2, IsRequired=false, Name="dialogueId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int dialogueId
            {
                get
                {
                    return this._dialogueId;
                }
                set
                {
                    this._dialogueId = value;
                }
            }

            [ProtoMember(4, Name="dungeonDifficulties", DataFormat=DataFormat.Default)]
            public List<CampaignConfig.DungeonDifficulty> dungeonDifficulties
            {
                get
                {
                    return this._dungeonDifficulties;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="openDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string openDesc
            {
                get
                {
                    return this._openDesc;
                }
                set
                {
                    this._openDesc = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="zoneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(6, IsRequired=false, Name="zoneModelClose", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public CampaignConfig.ZoneModel zoneModelClose
            {
                get
                {
                    return this._zoneModelClose;
                }
                set
                {
                    this._zoneModelClose = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="zoneModelOpen", DataFormat=DataFormat.Default)]
            public CampaignConfig.ZoneModel zoneModelOpen
            {
                get
                {
                    return this._zoneModelOpen;
                }
                set
                {
                    this._zoneModelOpen = value;
                }
            }
        }

        [ProtoContract(Name="ZoneModel")]
        public class ZoneModel : IExtensible
        {
            private string _modelEffectAnim = "";
            private string _modelIdleAnim = "";
            private string _modelName = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="modelEffectAnim", DataFormat=DataFormat.Default)]
            public string modelEffectAnim
            {
                get
                {
                    return this._modelEffectAnim;
                }
                set
                {
                    this._modelEffectAnim = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="modelIdleAnim", DataFormat=DataFormat.Default)]
            public string modelIdleAnim
            {
                get
                {
                    return this._modelIdleAnim;
                }
                set
                {
                    this._modelIdleAnim = value;
                }
            }

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="modelName", DataFormat=DataFormat.Default)]
            public string modelName
            {
                get
                {
                    return this._modelName;
                }
                set
                {
                    this._modelName = value;
                }
            }
        }
    }
}

