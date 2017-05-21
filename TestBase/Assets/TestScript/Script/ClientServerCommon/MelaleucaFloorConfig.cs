namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="MelaleucaFloorConfig")]
    public class MelaleucaFloorConfig : Configuration, IExtensible
    {
        private int _challengeCostPerTimes;
        private int _challengeFailsPerDay;
        private readonly List<Reward> _challengeRewardPerDay = new List<Reward>();
        private readonly List<Challenge> _challenges = new List<Challenge>();
        private readonly List<Description> _descriptions = new List<Description>();
        private readonly List<Floor> _floors = new List<Floor>();
        private bool _isMelaleucaShopOpen;
        private long _lastWeekRankResetTime;
        private readonly List<RankReward> _rankRewards = new List<RankReward>();
        private readonly List<RankShowRule> _rankShowRules = new List<RankShowRule>();
        private long _thisWeeekRankResetTime;
        private readonly List<WeekRewardShow> _weekRewardShows = new List<WeekRewardShow>();
        private IExtension extensionObject;
        private Dictionary<int, Floor> floorMap = new Dictionary<int, Floor>();
        private DateTime lastWeekRankResetTime_;
        private int maxConfigedFloorLayer;
        private DateTime thisWeeekRankResetTime_;

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            this.maxConfigedFloorLayer = 0;
            foreach (Floor floor in this._floors)
            {
                if (floor != null)
                {
                    if (this.floorMap.ContainsKey(floor.Layer))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey " + floor.Layer.ToString(), new object[0]);
                    }
                    else
                    {
                        if (floor.Layer > this.maxConfigedFloorLayer)
                        {
                            this.maxConfigedFloorLayer = floor.Layer;
                        }
                        this.floorMap.Add(floor.Layer, floor);
                    }
                }
            }
        }

        public Challenge GetChallengeByLayers(int layers)
        {
            foreach (Challenge challenge in this._challenges)
            {
                if (challenge.Layers == layers)
                {
                    return challenge;
                }
            }
            return null;
        }

        public Floor GetFloorByLayer(int layer)
        {
            if (this.floorMap.ContainsKey(layer))
            {
                return this.floorMap[layer];
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        private Challenge LoadChallengeFromXml(SecurityElement element)
        {
            if (element.Tag != "Challenge")
            {
                return null;
            }
            return new Challenge { 
                Layers = StrParser.ParseDecInt(element.Attribute("Layers"), 0),
                IsConsequent = StrParser.ParseBool(element.Attribute("IsConsequent"), false),
                ConsequentLimit = StrParser.ParseDecInt(element.Attribute("ConsequentLimit"), 0),
                OpenByLayer = StrParser.ParseDecInt(element.Attribute("OpenByLayer"), 0),
                Point = StrParser.ParseDecInt(element.Attribute("Point"), 0)
            };
        }

        private Floor LoadFloorFromXml(SecurityElement element)
        {
            if (element.Tag != "Floor")
            {
                return null;
            }
            Floor floor = new Floor {
                Layer = StrParser.ParseDecInt(element.Attribute("Layer"), 0),
                Icon = StrParser.ParseStr(element.Attribute("IconId"), string.Empty),
                Guide = StrParser.ParseStr(element.Attribute("Guide"), string.Empty, true),
                CombatMaxRound = StrParser.ParseDecInt(element.Attribute("CombatMaxRound"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "PassReward")
                        {
                            foreach (SecurityElement element3 in element2.Children)
                            {
                                floor.PassReward.Add(Reward.LoadFromXml(element3));
                            }
                        }
                        else if (tag == "FirstPassReward")
                        {
                            goto Label_0125;
                        }
                    }
                    continue;
                Label_0125:
                    foreach (SecurityElement element4 in element2.Children)
                    {
                        floor.FirstPassReward.Add(Reward.LoadFromXml(element4));
                    }
                }
            }
            return floor;
        }

        public override void LoadFromXml(SecurityElement elementRoot)
        {
            if ((elementRoot.Tag == "MelaleucaFloorConfig") && (elementRoot.Children != null))
            {
                foreach (SecurityElement element in elementRoot.Children)
                {
                    switch (element.Tag)
                    {
                        case "FloorSet":
                            if (element.Children != null)
                            {
                                foreach (SecurityElement element2 in element.Children)
                                {
                                    this._floors.Add(this.LoadFloorFromXml(element2));
                                }
                            }
                            break;

                        case "ChallengeSet":
                            if (element.Children != null)
                            {
                                foreach (SecurityElement element3 in element.Children)
                                {
                                    this._challenges.Add(this.LoadChallengeFromXml(element3));
                                }
                            }
                            break;

                        case "RankRewardSet":
                            if (element.Children != null)
                            {
                                foreach (SecurityElement element4 in element.Children)
                                {
                                    this._rankRewards.Add(this.LoadRankRewardFromXml(element4));
                                }
                            }
                            break;

                        case "WeekRewardSet":
                            if (element.Children != null)
                            {
                                foreach (SecurityElement element5 in element.Children)
                                {
                                    this._weekRewardShows.Add(this.LoadWeekRewardFromXml(element5));
                                }
                            }
                            break;

                        case "RankShowRuleSet":
                            if (element.Children != null)
                            {
                                foreach (SecurityElement element6 in element.Children)
                                {
                                    RankShowRule item = new RankShowRule {
                                        From = StrParser.ParseDecInt(element6.Attribute("From"), 0),
                                        Step = StrParser.ParseDecInt(element6.Attribute("Step"), 0)
                                    };
                                    this._rankShowRules.Add(item);
                                }
                            }
                            break;

                        case "ChallengeRewardPerDay":
                            if (element.Children != null)
                            {
                                foreach (SecurityElement element7 in element.Children)
                                {
                                    this._challengeRewardPerDay.Add(Reward.LoadFromXml(element7));
                                }
                            }
                            break;

                        case "DescriptionSet":
                            if (element.Children != null)
                            {
                                foreach (SecurityElement element8 in element.Children)
                                {
                                    Description description = new Description {
                                        DescId = StrParser.ParseDecInt(element8.Attribute("DescId"), 0),
                                        Content = StrParser.ParseStr(element8.Attribute("Content"), "", true)
                                    };
                                    this._descriptions.Add(description);
                                }
                            }
                            break;

                        case "ChallengeFailsPerDay":
                            this._challengeFailsPerDay = StrParser.ParseDecInt(element.Text, 0);
                            break;

                        case "ChallengeCostPerTimes":
                            this._challengeCostPerTimes = StrParser.ParseDecInt(element.Text, 0);
                            break;

                        case "LastWeekRankResetTime":
                            this._lastWeekRankResetTime = StrParser.ParseDateTime(element.Text);
                            break;

                        case "ThisWeeekRankResetTime":
                            this._thisWeeekRankResetTime = StrParser.ParseDateTime(element.Text);
                            break;

                        case "IsMelaleucaShopOpen":
                            this._isMelaleucaShopOpen = StrParser.ParseBool(element.Text, true);
                            break;
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
            RankReward reward = new RankReward {
                From = StrParser.ParseDecInt(element.Attribute("From"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Reward"))
                    {
                        reward.Rewards.Add(Reward.LoadFromXml(element2));
                    }
                }
            }
            return reward;
        }

        private WeekRewardShow LoadWeekRewardFromXml(SecurityElement element)
        {
            if (element.Tag != "WeekReward")
            {
                return null;
            }
            WeekRewardShow show = new WeekRewardShow {
                From = StrParser.ParseStr(element.Attribute("From"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "ShowReward"))
                    {
                        show.RewardShow.Add(this.LoadWeekRewardShowFromXml(element2));
                    }
                }
            }
            return show;
        }

        private RewardShow LoadWeekRewardShowFromXml(SecurityElement element)
        {
            if (element.Tag != "ShowReward")
            {
                return null;
            }
            return new RewardShow { 
                RewardId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                Desc = StrParser.ParseStr(element.Attribute("Desc"), "")
            };
        }

        public DateTime ToDateTime(long time)
        {
            return new DateTime(time * 0x2710L);
        }

        [ProtoMember(5, IsRequired=false, Name="challengeCostPerTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int ChallengeCostPerTimes
        {
            get
            {
                return this._challengeCostPerTimes;
            }
            set
            {
                this._challengeCostPerTimes = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="challengeFailsPerDay", DataFormat=DataFormat.TwosComplement)]
        public int ChallengeFailsPerDay
        {
            get
            {
                return this._challengeFailsPerDay;
            }
            set
            {
                this._challengeFailsPerDay = value;
            }
        }

        [ProtoMember(3, Name="challengeRewardPerDay", DataFormat=DataFormat.Default)]
        public List<Reward> ChallengeRewardPerDay
        {
            get
            {
                return this._challengeRewardPerDay;
            }
        }

        [ProtoMember(2, Name="challenges", DataFormat=DataFormat.Default)]
        public List<Challenge> Challenges
        {
            get
            {
                return this._challenges;
            }
        }

        [ProtoMember(10, Name="descriptions", DataFormat=DataFormat.Default)]
        public List<Description> Descriptions
        {
            get
            {
                return this._descriptions;
            }
        }

        [ProtoMember(1, Name="floors", DataFormat=DataFormat.Default)]
        public List<Floor> Floors
        {
            get
            {
                return this._floors;
            }
        }

        [DefaultValue(false), ProtoMember(12, IsRequired=false, Name="isMelaleucaShopOpen", DataFormat=DataFormat.Default)]
        public bool IsMelaleucaShopOpen
        {
            get
            {
                return this._isMelaleucaShopOpen;
            }
            set
            {
                this._isMelaleucaShopOpen = value;
            }
        }

        public DateTime LastWeekRankResetDateTime
        {
            get
            {
                return this.lastWeekRankResetTime_;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(6, IsRequired=false, Name="lastWeekRankResetTime", DataFormat=DataFormat.TwosComplement)]
        public long LastWeekRankResetTime
        {
            get
            {
                return this._lastWeekRankResetTime;
            }
            set
            {
                this._lastWeekRankResetTime = value;
            }
        }

        public int MaxConfigedFloorLayer
        {
            get
            {
                return this.maxConfigedFloorLayer;
            }
        }

        [ProtoMember(8, Name="rankRewards", DataFormat=DataFormat.Default)]
        public List<RankReward> RankRewards
        {
            get
            {
                return this._rankRewards;
            }
        }

        [ProtoMember(9, Name="rankShowRules", DataFormat=DataFormat.Default)]
        public List<RankShowRule> RankShowRules
        {
            get
            {
                return this._rankShowRules;
            }
        }

        public DateTime ThisWeeekRankResetDateTime
        {
            get
            {
                return this.thisWeeekRankResetTime_;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(7, IsRequired=false, Name="thisWeeekRankResetTime", DataFormat=DataFormat.TwosComplement)]
        public long ThisWeeekRankResetTime
        {
            get
            {
                return this._thisWeeekRankResetTime;
            }
            set
            {
                this._thisWeeekRankResetTime = value;
            }
        }

        [ProtoMember(11, Name="weekRewardShows", DataFormat=DataFormat.Default)]
        public List<WeekRewardShow> WeekRewardShows
        {
            get
            {
                return this._weekRewardShows;
            }
        }

        [ProtoContract(Name="Challenge")]
        public class Challenge : IExtensible
        {
            private int _consequentLimit;
            private bool _isConsequent;
            private int _layers;
            private int _openByLayer;
            private int _point;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, IsRequired=false, Name="consequentLimit", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ConsequentLimit
            {
                get
                {
                    return this._consequentLimit;
                }
                set
                {
                    this._consequentLimit = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="isConsequent", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool IsConsequent
            {
                get
                {
                    return this._isConsequent;
                }
                set
                {
                    this._isConsequent = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="layers", DataFormat=DataFormat.TwosComplement)]
            public int Layers
            {
                get
                {
                    return this._layers;
                }
                set
                {
                    this._layers = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="openByLayer", DataFormat=DataFormat.TwosComplement)]
            public int OpenByLayer
            {
                get
                {
                    return this._openByLayer;
                }
                set
                {
                    this._openByLayer = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="point", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Point
            {
                get
                {
                    return this._point;
                }
                set
                {
                    this._point = value;
                }
            }
        }

        [ProtoContract(Name="Description")]
        public class Description : IExtensible
        {
            private string _content = "";
            private int _descId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="content", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [ProtoMember(1, IsRequired=false, Name="descId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int DescId
            {
                get
                {
                    return this._descId;
                }
                set
                {
                    this._descId = value;
                }
            }
        }

        [ProtoContract(Name="Floor")]
        public class Floor : IExtensible
        {
            private int _combatMaxRound;
            private readonly List<Reward> _firstPassReward = new List<Reward>();
            private string _guide = "";
            private string _icon = "";
            private int _layer;
            private readonly List<Reward> _passReward = new List<Reward>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="combatMaxRound", DataFormat=DataFormat.TwosComplement)]
            public int CombatMaxRound
            {
                get
                {
                    return this._combatMaxRound;
                }
                set
                {
                    this._combatMaxRound = value;
                }
            }

            [ProtoMember(4, Name="firstPassReward", DataFormat=DataFormat.Default)]
            public List<Reward> FirstPassReward
            {
                get
                {
                    return this._firstPassReward;
                }
            }

            [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="guide", DataFormat=DataFormat.Default)]
            public string Guide
            {
                get
                {
                    return this._guide;
                }
                set
                {
                    this._guide = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="icon", DataFormat=DataFormat.Default), DefaultValue("")]
            public string Icon
            {
                get
                {
                    return this._icon;
                }
                set
                {
                    this._icon = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="layer", DataFormat=DataFormat.TwosComplement)]
            public int Layer
            {
                get
                {
                    return this._layer;
                }
                set
                {
                    this._layer = value;
                }
            }

            [ProtoMember(3, Name="passReward", DataFormat=DataFormat.Default)]
            public List<Reward> PassReward
            {
                get
                {
                    return this._passReward;
                }
            }
        }

        [ProtoContract(Name="RankReward")]
        public class RankReward : IExtensible
        {
            private int _from;
            private readonly List<Reward> _rewards = new List<Reward>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="from", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int From
            {
                get
                {
                    return this._from;
                }
                set
                {
                    this._from = value;
                }
            }

            [ProtoMember(2, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> Rewards
            {
                get
                {
                    return this._rewards;
                }
            }
        }

        [ProtoContract(Name="RankShowRule")]
        public class RankShowRule : IExtensible
        {
            private int _from;
            private int _step;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="from", DataFormat=DataFormat.TwosComplement)]
            public int From
            {
                get
                {
                    return this._from;
                }
                set
                {
                    this._from = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="step", DataFormat=DataFormat.TwosComplement)]
            public int Step
            {
                get
                {
                    return this._step;
                }
                set
                {
                    this._step = value;
                }
            }
        }

        [ProtoContract(Name="RewardShow")]
        public class RewardShow : IExtensible
        {
            private string _desc = "";
            private int _rewardId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="rewardId", DataFormat=DataFormat.TwosComplement)]
            public int RewardId
            {
                get
                {
                    return this._rewardId;
                }
                set
                {
                    this._rewardId = value;
                }
            }
        }

        [ProtoContract(Name="WeekRewardShow")]
        public class WeekRewardShow : IExtensible
        {
            private string _from = "";
            private readonly List<ClientServerCommon.MelaleucaFloorConfig.RewardShow> _rewardShow = new List<ClientServerCommon.MelaleucaFloorConfig.RewardShow>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="from", DataFormat=DataFormat.Default), DefaultValue("")]
            public string From
            {
                get
                {
                    return this._from;
                }
                set
                {
                    this._from = value;
                }
            }

            [ProtoMember(2, Name="rewardShow", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.MelaleucaFloorConfig.RewardShow> RewardShow
            {
                get
                {
                    return this._rewardShow;
                }
            }
        }
    }
}

