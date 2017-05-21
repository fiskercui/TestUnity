namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="MarvellousAdventureConfig")]
    public class MarvellousAdventureConfig : Configuration, IExtensible
    {
        private string _adventureExplicit = "";
        private MarvellousBuyType _buyType;
        private MarvellousCombatType _combatType;
        private ClientServerCommon.Cost _cost;
        private int _defaultBg;
        private readonly List<DelayRewardSet> _delayRewardSets = new List<DelayRewardSet>();
        private MarvellousDialogType _dialogType;
        private readonly List<Marvellous> _marvellouses = new List<Marvellous>();
        private readonly List<MarvellousScene> _marvellousScenes = new List<MarvellousScene>();
        private readonly List<MarvellousWorld> _marvellousWorlds = new List<MarvellousWorld>();
        private int _maxDelayRewardCount;
        private MarvellousRewardType _rewardType;
        private MarvellousSelectionType _selectionType;
        private Dictionary<int, object> eventMap = new Dictionary<int, object>();
        private IExtension extensionObject;
        private Dictionary<int, int> sceneMap = new Dictionary<int, int>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (DialogEvent event2 in this._dialogType.DialogEvents)
            {
                if (this.eventMap.ContainsKey(event2.EventId))
                {
                    Logger.Error(base.GetType().Name + " ContainsKey 0x" + event2.EventId.ToString("X"), new object[0]);
                }
                else
                {
                    this.eventMap.Add(event2.EventId, event2);
                }
            }
            foreach (RewardEvent event3 in this._rewardType.RewardEvents)
            {
                if (this.eventMap.ContainsKey(event3.EventId))
                {
                    Logger.Error(base.GetType().Name + " ContainsKey 0x" + event3.EventId.ToString("X"), new object[0]);
                }
                else
                {
                    this.eventMap.Add(event3.EventId, event3);
                }
            }
            foreach (SelectionEvent event4 in this._selectionType.SelectionEvents)
            {
                if (this.eventMap.ContainsKey(event4.EventId))
                {
                    Logger.Error(base.GetType().Name + " ContainsKey 0x" + event4.EventId.ToString("X"), new object[0]);
                }
                else
                {
                    this.eventMap.Add(event4.EventId, event4);
                }
            }
            foreach (CombatEvent event5 in this._combatType.CombatEvents)
            {
                if (this.eventMap.ContainsKey(event5.EventId))
                {
                    Logger.Error(base.GetType().Name + " ContainsKey 0x" + event5.EventId.ToString("X"), new object[0]);
                }
                else
                {
                    this.eventMap.Add(event5.EventId, event5);
                }
            }
            foreach (BuyEvent event6 in this._buyType.BuyEvents)
            {
                if (this.eventMap.ContainsKey(event6.EventId))
                {
                    Logger.Error(base.GetType().Name + " ContainsKey 0x" + event6.EventId.ToString("X"), new object[0]);
                }
                else
                {
                    this.eventMap.Add(event6.EventId, event6);
                }
            }
            foreach (MarvellousScene scene in this._marvellousScenes)
            {
                if (this.sceneMap.ContainsKey(scene.SceneId))
                {
                    Logger.Error(base.GetType().Name + " ContainsKey 0x" + scene.SceneId.ToString("X"), new object[0]);
                }
                else
                {
                    this.sceneMap.Add(scene.SceneId, scene.SceneTouchZoneCount);
                }
            }
        }

        public DelayRewardSet GetDelayRewardSetById(int id)
        {
            for (int i = 0; i < this._delayRewardSets.Count; i++)
            {
                if (id == this._delayRewardSets[i].DelayBackBgID)
                {
                    return this._delayRewardSets[i];
                }
            }
            return null;
        }

        public object GetEventById(int eventId)
        {
            if (this.eventMap.ContainsKey(eventId))
            {
                return this.eventMap[eventId];
            }
            return null;
        }

        public int GetEventTypeById(int eventId)
        {
            return ((eventId >> 0x10) & 0xff);
        }

        public Marvellous GetMarvellousById(int marvellousId)
        {
            for (int i = 0; i < this._marvellouses.Count; i++)
            {
                if (marvellousId == this._marvellouses[i].MarvellousId)
                {
                    return this._marvellouses[i];
                }
            }
            return null;
        }

        public MarvellousWorld GetMarvellousWorldById(int marvellousWorldId)
        {
            for (int i = 0; i < this._marvellousWorlds.Count; i++)
            {
                if (marvellousWorldId == this._marvellousWorlds[i].WorldId)
                {
                    return this._marvellousWorlds[i];
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
            _MarvellousDelayRewardType.Initialize();
            _MarvellousBuyType.Initialize();
            _MarvellousType.Initialize();
            _MarvellousRewardType.Initialize();
            _MarvellousZoneStaus.Initialize();
        }

        public List<BuyEvent> LoadBuyEventFromXml(SecurityElement element)
        {
            List<BuyEvent> list = new List<BuyEvent>();
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "BuyEvent")
                {
                    BuyEvent item = new BuyEvent {
                        EventId = StrParser.ParseHexInt(element2.Attribute("EventId"), 0),
                        DialogSetId = StrParser.ParseHexInt(element2.Attribute("DialogSetId"), 0),
                        BuyGoToEventId = StrParser.ParseHexInt(element2.Attribute("BuyGoToEventId"), 0),
                        RefuseBuyGoToEventId = StrParser.ParseHexInt(element2.Attribute("RefuseBuyGoToEventId"), 0),
                        EventType = TypeNameContainer<_MarvellousType>.Parse(element2.Attribute("EventType"), 0),
                        BuyType = TypeNameContainer<_MarvellousBuyType>.Parse(element2.Attribute("BuyType"), 0)
                    };
                    ClientServerCommon.Cost cost = new ClientServerCommon.Cost();
                    List<Reward> collection = new List<Reward>();
                    foreach (SecurityElement element3 in element2.Children)
                    {
                        if (element3.Tag == "Cost")
                        {
                            cost = ClientServerCommon.Cost.LoadFromXml(element3);
                        }
                        if (element3.Tag == "Reward")
                        {
                            collection.Add(Reward.LoadFromXml(element3));
                        }
                    }
                    item.Costs = cost;
                    item.Rewards.AddRange(collection);
                    list.Add(item);
                }
            }
            return list;
        }

        public List<CombatEvent> LoadCombatEventFromXml(SecurityElement element)
        {
            List<CombatEvent> list = new List<CombatEvent>();
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "CombatEvent")
                {
                    CombatEvent item = new CombatEvent {
                        SceneId = StrParser.ParseHexInt(element2.Attribute("SceneId"), 0),
                        EventId = StrParser.ParseHexInt(element2.Attribute("EventId"), 0),
                        FleeGoToEventId = StrParser.ParseHexInt(element2.Attribute("FleeGoToEventId"), 0),
                        CombatLoserGoToEventId = StrParser.ParseHexInt(element2.Attribute("CombatLoserGoToEventId"), 0),
                        CombatWinnerGoToEventId = StrParser.ParseHexInt(element2.Attribute("CombatWinnerGoToEventId"), 0),
                        RobotId = StrParser.ParseHexInt(element2.Attribute("RobotId"), 0),
                        RobotName = StrParser.ParseStr(element2.Attribute("RobotName"), ""),
                        AllDeadWhoWin = TypeNameContainer<ClientServerCommon._CampType>.Parse(element2.Attribute("AllDeadWhoWin"), 0),
                        MaxRound = StrParser.ParseDecInt(element2.Attribute("MaxRound"), 0),
                        MaxRoundWhoWin = TypeNameContainer<ClientServerCommon._CampType>.Parse(element2.Attribute("MaxRoundWhoWin"), 0),
                        EventType = TypeNameContainer<_MarvellousType>.Parse(element2.Attribute("EventType"), 0),
                        DialogSetId = StrParser.ParseHexInt(element2.Attribute("DialogSetId"), 0)
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public List<DelayRewardSet> LoadDelayRewardSetFromXml(SecurityElement element)
        {
            List<DelayRewardSet> list = new List<DelayRewardSet>();
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "DelayRewardSet")
                {
                    DelayRewardSet item = new DelayRewardSet {
                        DelayBackBgID = StrParser.ParseHexInt(element2.Attribute("Id"), 0),
                        DelayType = TypeNameContainer<_MarvellousDelayRewardType>.Parse(element2.Attribute("DelayType"), 0),
                        DelayDesc = StrParser.ParseStr(element2.Attribute("DelayDesc"), string.Empty)
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "MarvellousAdventureConfig")
            {
                this._maxDelayRewardCount = StrParser.ParseDecInt(element.Attribute("MaxDelayRewardCount"), 0);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        switch (element2.Tag)
                        {
                            case "MarvellousScene":
                                this.LoadMarvellousSceneFromXml(element2);
                                break;

                            case "MarvellousWorld":
                                this.LoadMarvellousWorldFromXml(element2);
                                break;

                            case "Marvellous":
                                this.LoadMarvellousFromXml(element2);
                                break;

                            case "MarvellousDialogType":
                                this.LoadMarvellousDialogFromXml(element2);
                                break;

                            case "MarvellousSelectionType":
                                this.LoadMarvellousSelectionTypeFromXml(element2);
                                break;

                            case "MarvellousCombatType":
                                this.LoadMarvellousCombatTypeFromXml(element2);
                                break;

                            case "MarvellousBuyType":
                                this.LoadMarvellousBuyTypeFromXml(element2);
                                break;

                            case "MarvellousRewardType":
                                this.LoadMarvellousRewardTypeFromXml(element2);
                                break;

                            case "Cost":
                                this._cost = ClientServerCommon.Cost.LoadFromXml(element2);
                                break;

                            case "AdventureExplicit":
                                this._adventureExplicit = StrParser.ParseStr(element2.Text, "", true);
                                break;

                            case "DefaultBg":
                                this._defaultBg = StrParser.ParseHexInt(element2.Text, 0);
                                break;

                            case "DelayRewardSets":
                                this.LoadMarvellousDelayRewardSetFromXml(element2);
                                break;
                        }
                    }
                }
            }
        }

        public void LoadMarvellousBuyTypeFromXml(SecurityElement element)
        {
            MarvellousBuyType type = new MarvellousBuyType();
            if (element.Children != null)
            {
                type.BuyEvents.AddRange(this.LoadBuyEventFromXml(element));
            }
            this._buyType = type;
        }

        public void LoadMarvellousCombatTypeFromXml(SecurityElement element)
        {
            MarvellousCombatType type = new MarvellousCombatType();
            if (element.Children != null)
            {
                type.CombatEvents.AddRange(this.LoadCombatEventFromXml(element));
            }
            this._combatType = type;
        }

        public void LoadMarvellousDelayRewardSetFromXml(SecurityElement element)
        {
            List<DelayRewardSet> collection = new List<DelayRewardSet>();
            if (element.Children != null)
            {
                collection.AddRange(this.LoadDelayRewardSetFromXml(element));
            }
            this._delayRewardSets.AddRange(collection);
        }

        public void LoadMarvellousDialogFromXml(SecurityElement element)
        {
            MarvellousDialogType type = new MarvellousDialogType();
            List<DialogEvent> collection = new List<DialogEvent>();
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "DialogEvent")
                {
                    DialogEvent item = new DialogEvent {
                        EventId = StrParser.ParseHexInt(element2.Attribute("EventId"), 0),
                        GoToEventId = StrParser.ParseHexInt(element2.Attribute("GoToEventId"), 0),
                        DialogSetId = StrParser.ParseHexInt(element2.Attribute("DialogSetId"), 0),
                        EventType = TypeNameContainer<_MarvellousType>.Parse(element2.Attribute("EventType"), 0)
                    };
                    collection.Add(item);
                }
            }
            type.DialogEvents.AddRange(collection);
            this._dialogType = type;
        }

        public void LoadMarvellousFromXml(SecurityElement element)
        {
            Marvellous item = new Marvellous {
                MarvellousId = StrParser.ParseHexInt(element.Attribute("MarvellousId"), 0),
                AvailableZoneCount = StrParser.ParseDecInt(element.Attribute("AvailableZoneCount"), 0),
                SceneId = StrParser.ParseHexInt(element.Attribute("SceneId"), 0)
            };
            item.MarvellousScenarios.AddRange(this.LoadMarvellousScenarioFromXml(element));
            this._marvellouses.Add(item);
        }

        public void LoadMarvellousRewardTypeFromXml(SecurityElement element)
        {
            MarvellousRewardType type = new MarvellousRewardType();
            if (element.Children != null)
            {
                type.RewardEvents.AddRange(this.LoadRewardEventFromXml(element));
            }
            this._rewardType = type;
        }

        public List<MarvellousScenario> LoadMarvellousScenarioFromXml(SecurityElement element)
        {
            List<MarvellousScenario> list = new List<MarvellousScenario>();
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "MarvellousScenario")
                {
                    MarvellousScenario item = new MarvellousScenario {
                        ScenarioId = StrParser.ParseHexInt(element2.Attribute("ScenarioId"), 0),
                        StartEventId = StrParser.ParseHexInt(element2.Attribute("StartEventId"), 0)
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public void LoadMarvellousSceneFromXml(SecurityElement element)
        {
            List<MarvellousScene> collection = new List<MarvellousScene>();
            if (element.Children != null)
            {
                collection.AddRange(this.LoadSceneFromXml(element));
            }
            this._marvellousScenes.AddRange(collection);
        }

        public List<MarvellousSelect> LoadMarvellousSelectFromXml(SecurityElement element)
        {
            List<MarvellousSelect> list = new List<MarvellousSelect>();
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "MarvellousSelect")
                {
                    MarvellousSelect item = new MarvellousSelect {
                        MarvellousId = StrParser.ParseHexInt(element2.Attribute("MarvellousId"), 0)
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public void LoadMarvellousSelectionTypeFromXml(SecurityElement element)
        {
            MarvellousSelectionType type = new MarvellousSelectionType();
            if (element.Children != null)
            {
                type.SelectionEvents.AddRange(this.LoadSelectionEventFromXml(element));
            }
            this._selectionType = type;
        }

        public void LoadMarvellousWorldFromXml(SecurityElement element)
        {
            MarvellousWorld item = new MarvellousWorld {
                WorldId = StrParser.ParseHexInt(element.Attribute("WorldId"), 0)
            };
            if (element.Children != null)
            {
                item.MarvellousSelects.AddRange(this.LoadMarvellousSelectFromXml(element));
            }
            this._marvellousWorlds.Add(item);
        }

        public List<RewardEvent> LoadRewardEventFromXml(SecurityElement element)
        {
            List<RewardEvent> list = new List<RewardEvent>();
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "RewardEvent")
                {
                    RewardEvent item = new RewardEvent {
                        EventId = StrParser.ParseHexInt(element2.Attribute("EventId"), 0),
                        GoToEventId = StrParser.ParseHexInt(element2.Attribute("GoToEventId"), 0),
                        OriginalIconId = StrParser.ParseHexInt(element2.Attribute("OriginalIconId"), 0),
                        DelayBackBg = StrParser.ParseHexInt(element2.Attribute("DelayBackBg"), 0),
                        EventType = TypeNameContainer<_MarvellousType>.Parse(element2.Attribute("EventType"), 0),
                        RewardType = TypeNameContainer<_MarvellousRewardType>.Parse(element2.Attribute("RewardType"), 0)
                    };
                    foreach (SecurityElement element3 in element2.Children)
                    {
                        if (element3.Tag == "DelayRewards")
                        {
                            item.DelayTime = StrParser.ParseDecLong(element3.Attribute("DelayTime"), 0L);
                            foreach (SecurityElement element4 in element3.Children)
                            {
                                if (element4.Tag == "Reward")
                                {
                                    item.DelayRewards.Add(Reward.LoadFromXml(element4));
                                }
                            }
                        }
                        if (element3.Tag == "FixedRewards")
                        {
                            foreach (SecurityElement element5 in element3.Children)
                            {
                                if (element5.Tag == "Reward")
                                {
                                    item.FixedRewards.Add(Reward.LoadFromXml(element5));
                                }
                            }
                        }
                    }
                    list.Add(item);
                }
            }
            return list;
        }

        public List<MarvellousScene> LoadSceneFromXml(SecurityElement element)
        {
            List<MarvellousScene> list = new List<MarvellousScene>();
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "Scene")
                {
                    MarvellousScene item = new MarvellousScene {
                        SceneId = StrParser.ParseHexInt(element2.Attribute("Id"), 0),
                        SceneTouchZoneCount = StrParser.ParseDecInt(element2.Attribute("AvailableZoneCount"), 0)
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public List<SelectionEvent> LoadSelectionEventFromXml(SecurityElement element)
        {
            List<SelectionEvent> list = new List<SelectionEvent>();
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "SelectEvent")
                {
                    SelectionEvent item = new SelectionEvent {
                        EventId = StrParser.ParseHexInt(element2.Attribute("EventId"), 0),
                        DialogSetId = StrParser.ParseHexInt(element2.Attribute("DialogSetId"), 0),
                        EventType = TypeNameContainer<_MarvellousType>.Parse(element2.Attribute("EventType"), 0)
                    };
                    item.SelectionItem.AddRange(this.LoadSelectItemFromXml(element2));
                    list.Add(item);
                }
            }
            return list;
        }

        public List<SelectionItem> LoadSelectItemFromXml(SecurityElement element)
        {
            List<SelectionItem> list = new List<SelectionItem>();
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "SelectItem")
                {
                    SelectionItem item = new SelectionItem {
                        Content = StrParser.ParseStr(element2.Attribute("Content"), ""),
                        GoToEventId = StrParser.ParseHexInt(element2.Attribute("GoToEventId"), 0)
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        [DefaultValue(""), ProtoMember(10, IsRequired=false, Name="adventureExplicit", DataFormat=DataFormat.Default)]
        public string AdventureExplicit
        {
            get
            {
                return this._adventureExplicit;
            }
            set
            {
                this._adventureExplicit = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="buyType", DataFormat=DataFormat.Default)]
        public MarvellousBuyType BuyType
        {
            get
            {
                return this._buyType;
            }
            set
            {
                this._buyType = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="combatType", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public MarvellousCombatType CombatType
        {
            get
            {
                return this._combatType;
            }
            set
            {
                this._combatType = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="cost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [ProtoMember(11, IsRequired=false, Name="defaultBg", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int DefaultBg
        {
            get
            {
                return this._defaultBg;
            }
            set
            {
                this._defaultBg = value;
            }
        }

        [ProtoMember(13, Name="delayRewardSets", DataFormat=DataFormat.Default)]
        public List<DelayRewardSet> DelayRewardSets
        {
            get
            {
                return this._delayRewardSets;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="dialogType", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public MarvellousDialogType DialogType
        {
            get
            {
                return this._dialogType;
            }
            set
            {
                this._dialogType = value;
            }
        }

        [ProtoMember(7, Name="marvellouses", DataFormat=DataFormat.Default)]
        public List<Marvellous> Marvellouses
        {
            get
            {
                return this._marvellouses;
            }
        }

        [ProtoMember(12, Name="marvellousScenes", DataFormat=DataFormat.Default)]
        public List<MarvellousScene> MarvellousScenes
        {
            get
            {
                return this._marvellousScenes;
            }
        }

        [ProtoMember(1, Name="marvellousWorlds", DataFormat=DataFormat.Default)]
        public List<MarvellousWorld> MarvellousWorlds
        {
            get
            {
                return this._marvellousWorlds;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="maxDelayRewardCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int MaxDelayRewardCount
        {
            get
            {
                return this._maxDelayRewardCount;
            }
            set
            {
                this._maxDelayRewardCount = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="rewardType", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public MarvellousRewardType RewardType
        {
            get
            {
                return this._rewardType;
            }
            set
            {
                this._rewardType = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="selectionType", DataFormat=DataFormat.Default)]
        public MarvellousSelectionType SelectionType
        {
            get
            {
                return this._selectionType;
            }
            set
            {
                this._selectionType = value;
            }
        }

        public class _MarvellousBuyType : TypeNameContainer<MarvellousAdventureConfig._MarvellousBuyType>
        {
            public const int Package = 2;
            public const int Recruit = 1;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<MarvellousAdventureConfig._MarvellousBuyType>.RegisterType("Recruit", 1, "Recruit");
                return (flag & TypeNameContainer<MarvellousAdventureConfig._MarvellousBuyType>.RegisterType("Package", 2, "Package"));
            }
        }

        public class _MarvellousDelayRewardType : TypeNameContainer<MarvellousAdventureConfig._MarvellousDelayRewardType>
        {
            public const int Practice = 1;
            public const int Study = 3;
            public const int Treasure = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<MarvellousAdventureConfig._MarvellousDelayRewardType>.RegisterType("Practice", 1, "Practice");
                flag &= TypeNameContainer<MarvellousAdventureConfig._MarvellousDelayRewardType>.RegisterType("Treasure", 2, "Treasure");
                return (flag & TypeNameContainer<MarvellousAdventureConfig._MarvellousDelayRewardType>.RegisterType("Study", 3, "Study"));
            }
        }

        public class _MarvellousRewardType : TypeNameContainer<MarvellousAdventureConfig._MarvellousRewardType>
        {
            public const int Normal = 1;
            public const int Package = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<MarvellousAdventureConfig._MarvellousRewardType>.RegisterType("Normal", 1, "Normal");
                return (flag & TypeNameContainer<MarvellousAdventureConfig._MarvellousRewardType>.RegisterType("Package", 2, "Package"));
            }
        }

        public class _MarvellousType : TypeNameContainer<MarvellousAdventureConfig._MarvellousType>
        {
            public const int BuyTypeEvent = 4;
            public const int CombatTypeEvent = 3;
            public const int DialogTypeEvent = 1;
            public const int RewardTypeEvent = 5;
            public const int SelectionTypeEvent = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<MarvellousAdventureConfig._MarvellousType>.RegisterType("DialogTypeEvent", 1, "DialogTypeEvent");
                flag &= TypeNameContainer<MarvellousAdventureConfig._MarvellousType>.RegisterType("SelectionTypeEvent", 2, "SelectionTypeEvent");
                flag &= TypeNameContainer<MarvellousAdventureConfig._MarvellousType>.RegisterType("CombatTypeEvent", 3, "CombatTypeEvent");
                flag &= TypeNameContainer<MarvellousAdventureConfig._MarvellousType>.RegisterType("BuyTypeEvent", 4, "BuyTypeEvent");
                return (flag & TypeNameContainer<MarvellousAdventureConfig._MarvellousType>.RegisterType("RewardTypeEvent", 5, "RewardTypeEvent"));
            }
        }

        public class _MarvellousZoneStaus : TypeNameContainer<MarvellousAdventureConfig._MarvellousZoneStaus>
        {
            public const int NotVisit = 0;
            public const int Visited = -1;
            public const int Visiting = 1;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<MarvellousAdventureConfig._MarvellousZoneStaus>.RegisterType("NotVisit", 0, "NotVisit");
                flag &= TypeNameContainer<MarvellousAdventureConfig._MarvellousZoneStaus>.RegisterType("Visiting", 1, "Visiting");
                return (flag & TypeNameContainer<MarvellousAdventureConfig._MarvellousZoneStaus>.RegisterType("Visited", -1, "Visited"));
            }
        }

        [ProtoContract(Name="BuyEvent")]
        public class BuyEvent : IExtensible
        {
            private int _buyGoToEventId;
            private int _buyType;
            private Cost _costs;
            private int _dialogSetId;
            private int _eventId;
            private int _eventType;
            private int _refuseBuyGoToEventId;
            private readonly List<Reward> _rewards = new List<Reward>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="buyGoToEventId", DataFormat=DataFormat.TwosComplement)]
            public int BuyGoToEventId
            {
                get
                {
                    return this._buyGoToEventId;
                }
                set
                {
                    this._buyGoToEventId = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="buyType", DataFormat=DataFormat.TwosComplement)]
            public int BuyType
            {
                get
                {
                    return this._buyType;
                }
                set
                {
                    this._buyType = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="costs", DataFormat=DataFormat.Default)]
            public Cost Costs
            {
                get
                {
                    return this._costs;
                }
                set
                {
                    this._costs = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="dialogSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int DialogSetId
            {
                get
                {
                    return this._dialogSetId;
                }
                set
                {
                    this._dialogSetId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="eventId", DataFormat=DataFormat.TwosComplement)]
            public int EventId
            {
                get
                {
                    return this._eventId;
                }
                set
                {
                    this._eventId = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="eventType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int EventType
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

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="refuseBuyGoToEventId", DataFormat=DataFormat.TwosComplement)]
            public int RefuseBuyGoToEventId
            {
                get
                {
                    return this._refuseBuyGoToEventId;
                }
                set
                {
                    this._refuseBuyGoToEventId = value;
                }
            }

            [ProtoMember(5, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> Rewards
            {
                get
                {
                    return this._rewards;
                }
            }
        }

        [ProtoContract(Name="CombatEvent")]
        public class CombatEvent : IExtensible
        {
            private int _allDeadWhoWin;
            private int _combatLoserGoToEventId;
            private int _combatWinnerGoToEventId;
            private int _dialogSetId;
            private int _eventId;
            private int _eventType;
            private int _fleeGoToEventId;
            private int _maxRound;
            private int _maxRoundWhoWin;
            private int _robotId;
            private string _robotName = "";
            private int _sceneId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(8, IsRequired=false, Name="allDeadWhoWin", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int AllDeadWhoWin
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

            [ProtoMember(6, IsRequired=false, Name="combatLoserGoToEventId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CombatLoserGoToEventId
            {
                get
                {
                    return this._combatLoserGoToEventId;
                }
                set
                {
                    this._combatLoserGoToEventId = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="combatWinnerGoToEventId", DataFormat=DataFormat.TwosComplement)]
            public int CombatWinnerGoToEventId
            {
                get
                {
                    return this._combatWinnerGoToEventId;
                }
                set
                {
                    this._combatWinnerGoToEventId = value;
                }
            }

            [ProtoMember(12, IsRequired=false, Name="dialogSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int DialogSetId
            {
                get
                {
                    return this._dialogSetId;
                }
                set
                {
                    this._dialogSetId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="eventId", DataFormat=DataFormat.TwosComplement)]
            public int EventId
            {
                get
                {
                    return this._eventId;
                }
                set
                {
                    this._eventId = value;
                }
            }

            [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="eventType", DataFormat=DataFormat.TwosComplement)]
            public int EventType
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

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="fleeGoToEventId", DataFormat=DataFormat.TwosComplement)]
            public int FleeGoToEventId
            {
                get
                {
                    return this._fleeGoToEventId;
                }
                set
                {
                    this._fleeGoToEventId = value;
                }
            }

            [ProtoMember(9, IsRequired=false, Name="maxRound", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MaxRound
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

            [DefaultValue(0), ProtoMember(10, IsRequired=false, Name="maxRoundWhoWin", DataFormat=DataFormat.TwosComplement)]
            public int MaxRoundWhoWin
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

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="robotId", DataFormat=DataFormat.TwosComplement)]
            public int RobotId
            {
                get
                {
                    return this._robotId;
                }
                set
                {
                    this._robotId = value;
                }
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="robotName", DataFormat=DataFormat.Default)]
            public string RobotName
            {
                get
                {
                    return this._robotName;
                }
                set
                {
                    this._robotName = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="sceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int SceneId
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
        }

        [ProtoContract(Name="DelayRewardSet")]
        public class DelayRewardSet : IExtensible
        {
            private int _delayBackBgID;
            private string _delayDesc = "";
            private int _delayType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="delayBackBgID", DataFormat=DataFormat.TwosComplement)]
            public int DelayBackBgID
            {
                get
                {
                    return this._delayBackBgID;
                }
                set
                {
                    this._delayBackBgID = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="delayDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string DelayDesc
            {
                get
                {
                    return this._delayDesc;
                }
                set
                {
                    this._delayDesc = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="delayType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int DelayType
            {
                get
                {
                    return this._delayType;
                }
                set
                {
                    this._delayType = value;
                }
            }
        }

        [ProtoContract(Name="DialogEvent")]
        public class DialogEvent : IExtensible
        {
            private int _dialogSetId;
            private int _eventId;
            private int _eventType;
            private int _goToEventId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="dialogSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int DialogSetId
            {
                get
                {
                    return this._dialogSetId;
                }
                set
                {
                    this._dialogSetId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="eventId", DataFormat=DataFormat.TwosComplement)]
            public int EventId
            {
                get
                {
                    return this._eventId;
                }
                set
                {
                    this._eventId = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="eventType", DataFormat=DataFormat.TwosComplement)]
            public int EventType
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

            [ProtoMember(2, IsRequired=false, Name="goToEventId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int GoToEventId
            {
                get
                {
                    return this._goToEventId;
                }
                set
                {
                    this._goToEventId = value;
                }
            }
        }

        [ProtoContract(Name="Marvellous")]
        public class Marvellous : IExtensible
        {
            private int _availableZoneCount;
            private int _marvellousId;
            private readonly List<MarvellousAdventureConfig.MarvellousScenario> _marvellousScenarios = new List<MarvellousAdventureConfig.MarvellousScenario>();
            private int _sceneId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="availableZoneCount", DataFormat=DataFormat.TwosComplement)]
            public int AvailableZoneCount
            {
                get
                {
                    return this._availableZoneCount;
                }
                set
                {
                    this._availableZoneCount = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="marvellousId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MarvellousId
            {
                get
                {
                    return this._marvellousId;
                }
                set
                {
                    this._marvellousId = value;
                }
            }

            [ProtoMember(4, Name="marvellousScenarios", DataFormat=DataFormat.Default)]
            public List<MarvellousAdventureConfig.MarvellousScenario> MarvellousScenarios
            {
                get
                {
                    return this._marvellousScenarios;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="sceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int SceneId
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
        }

        [ProtoContract(Name="MarvellousBuyType")]
        public class MarvellousBuyType : IExtensible
        {
            private readonly List<MarvellousAdventureConfig.BuyEvent> _buyEvents = new List<MarvellousAdventureConfig.BuyEvent>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, Name="buyEvents", DataFormat=DataFormat.Default)]
            public List<MarvellousAdventureConfig.BuyEvent> BuyEvents
            {
                get
                {
                    return this._buyEvents;
                }
            }
        }

        [ProtoContract(Name="MarvellousCombatType")]
        public class MarvellousCombatType : IExtensible
        {
            private readonly List<MarvellousAdventureConfig.CombatEvent> _combatEvents = new List<MarvellousAdventureConfig.CombatEvent>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, Name="combatEvents", DataFormat=DataFormat.Default)]
            public List<MarvellousAdventureConfig.CombatEvent> CombatEvents
            {
                get
                {
                    return this._combatEvents;
                }
            }
        }

        [ProtoContract(Name="MarvellousDialogType")]
        public class MarvellousDialogType : IExtensible
        {
            private readonly List<MarvellousAdventureConfig.DialogEvent> _dialogEvents = new List<MarvellousAdventureConfig.DialogEvent>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, Name="dialogEvents", DataFormat=DataFormat.Default)]
            public List<MarvellousAdventureConfig.DialogEvent> DialogEvents
            {
                get
                {
                    return this._dialogEvents;
                }
            }
        }

        [ProtoContract(Name="MarvellousRewardType")]
        public class MarvellousRewardType : IExtensible
        {
            private readonly List<MarvellousAdventureConfig.RewardEvent> _rewardEvents = new List<MarvellousAdventureConfig.RewardEvent>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, Name="rewardEvents", DataFormat=DataFormat.Default)]
            public List<MarvellousAdventureConfig.RewardEvent> RewardEvents
            {
                get
                {
                    return this._rewardEvents;
                }
            }
        }

        [ProtoContract(Name="MarvellousScenario")]
        public class MarvellousScenario : IExtensible
        {
            private int _scenarioId;
            private int _startEventId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="scenarioId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ScenarioId
            {
                get
                {
                    return this._scenarioId;
                }
                set
                {
                    this._scenarioId = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="startEventId", DataFormat=DataFormat.TwosComplement)]
            public int StartEventId
            {
                get
                {
                    return this._startEventId;
                }
                set
                {
                    this._startEventId = value;
                }
            }
        }

        [ProtoContract(Name="MarvellousScene")]
        public class MarvellousScene : IExtensible
        {
            private int _sceneId;
            private int _sceneTouchZoneCount;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="sceneId", DataFormat=DataFormat.TwosComplement)]
            public int SceneId
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

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="sceneTouchZoneCount", DataFormat=DataFormat.TwosComplement)]
            public int SceneTouchZoneCount
            {
                get
                {
                    return this._sceneTouchZoneCount;
                }
                set
                {
                    this._sceneTouchZoneCount = value;
                }
            }
        }

        [ProtoContract(Name="MarvellousSelect")]
        public class MarvellousSelect : IExtensible
        {
            private int _marvellousId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="marvellousId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MarvellousId
            {
                get
                {
                    return this._marvellousId;
                }
                set
                {
                    this._marvellousId = value;
                }
            }
        }

        [ProtoContract(Name="MarvellousSelectionType")]
        public class MarvellousSelectionType : IExtensible
        {
            private readonly List<MarvellousAdventureConfig.SelectionEvent> _selectionEvents = new List<MarvellousAdventureConfig.SelectionEvent>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, Name="selectionEvents", DataFormat=DataFormat.Default)]
            public List<MarvellousAdventureConfig.SelectionEvent> SelectionEvents
            {
                get
                {
                    return this._selectionEvents;
                }
            }
        }

        [ProtoContract(Name="MarvellousWorld")]
        public class MarvellousWorld : IExtensible
        {
            private readonly List<MarvellousAdventureConfig.MarvellousSelect> _marvellousSelects = new List<MarvellousAdventureConfig.MarvellousSelect>();
            private int _worldId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="marvellousSelects", DataFormat=DataFormat.Default)]
            public List<MarvellousAdventureConfig.MarvellousSelect> MarvellousSelects
            {
                get
                {
                    return this._marvellousSelects;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="worldId", DataFormat=DataFormat.TwosComplement)]
            public int WorldId
            {
                get
                {
                    return this._worldId;
                }
                set
                {
                    this._worldId = value;
                }
            }
        }

        [ProtoContract(Name="RewardEvent")]
        public class RewardEvent : IExtensible
        {
            private int _delayBackBg;
            private readonly List<Reward> _delayRewards = new List<Reward>();
            private long _delayTime;
            private int _eventId;
            private int _eventType;
            private readonly List<Reward> _fixedRewards = new List<Reward>();
            private int _goToEventId;
            private int _originalIconId;
            private int _rewardType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="delayBackBg", DataFormat=DataFormat.TwosComplement)]
            public int DelayBackBg
            {
                get
                {
                    return this._delayBackBg;
                }
                set
                {
                    this._delayBackBg = value;
                }
            }

            [ProtoMember(4, Name="delayRewards", DataFormat=DataFormat.Default)]
            public List<Reward> DelayRewards
            {
                get
                {
                    return this._delayRewards;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="delayTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
            public long DelayTime
            {
                get
                {
                    return this._delayTime;
                }
                set
                {
                    this._delayTime = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="eventId", DataFormat=DataFormat.TwosComplement)]
            public int EventId
            {
                get
                {
                    return this._eventId;
                }
                set
                {
                    this._eventId = value;
                }
            }

            [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="eventType", DataFormat=DataFormat.TwosComplement)]
            public int EventType
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

            [ProtoMember(5, Name="fixedRewards", DataFormat=DataFormat.Default)]
            public List<Reward> FixedRewards
            {
                get
                {
                    return this._fixedRewards;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="goToEventId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int GoToEventId
            {
                get
                {
                    return this._goToEventId;
                }
                set
                {
                    this._goToEventId = value;
                }
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="originalIconId", DataFormat=DataFormat.TwosComplement)]
            public int OriginalIconId
            {
                get
                {
                    return this._originalIconId;
                }
                set
                {
                    this._originalIconId = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="rewardType", DataFormat=DataFormat.TwosComplement)]
            public int RewardType
            {
                get
                {
                    return this._rewardType;
                }
                set
                {
                    this._rewardType = value;
                }
            }
        }

        [ProtoContract(Name="SelectionEvent")]
        public class SelectionEvent : IExtensible
        {
            private int _dialogSetId;
            private int _eventId;
            private int _eventType;
            private readonly List<ClientServerCommon.MarvellousAdventureConfig.SelectionItem> _selectionItem = new List<ClientServerCommon.MarvellousAdventureConfig.SelectionItem>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="dialogSetId", DataFormat=DataFormat.TwosComplement)]
            public int DialogSetId
            {
                get
                {
                    return this._dialogSetId;
                }
                set
                {
                    this._dialogSetId = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="eventId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int EventId
            {
                get
                {
                    return this._eventId;
                }
                set
                {
                    this._eventId = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="eventType", DataFormat=DataFormat.TwosComplement)]
            public int EventType
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

            [ProtoMember(2, Name="selectionItem", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.MarvellousAdventureConfig.SelectionItem> SelectionItem
            {
                get
                {
                    return this._selectionItem;
                }
            }
        }

        [ProtoContract(Name="SelectionItem")]
        public class SelectionItem : IExtensible
        {
            private string _content = "";
            private int _goToEventId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="content", DataFormat=DataFormat.Default), DefaultValue("")]
            public string Content
            {
                get
                {
                    return this._content;
                }
                set
                {
                    this._content = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="goToEventId", DataFormat=DataFormat.TwosComplement)]
            public int GoToEventId
            {
                get
                {
                    return this._goToEventId;
                }
                set
                {
                    this._goToEventId = value;
                }
            }
        }
    }
}

