namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="DailySignInConfig")]
    public class DailySignInConfig : Configuration, IExtensible
    {
        private readonly List<Reward> _dailyRewards = new List<Reward>();
        private int _freeRemedySignInTimes;
        private int _maxRemedySignInTimes;
        private readonly List<MonthReward> _monthRewards = new List<MonthReward>();
        private readonly List<Reward> _remedyRewards = new List<Reward>();
        private int _remedySignInCostDelta;
        private readonly List<Cost> _remedySignInCosts = new List<Cost>();
        private bool _remedySignStatus;
        private IExtension extensionObject;
        private Dictionary<int, MonthReward> monthRewardMap = new Dictionary<int, MonthReward>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (MonthReward reward in this._monthRewards)
            {
                if (reward != null)
                {
                    if (this.monthRewardMap.ContainsKey(reward.month))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey " + reward.month.ToString(), new object[0]);
                    }
                    else
                    {
                        this.monthRewardMap.Add(reward.month, reward);
                    }
                }
            }
        }

        public MonthReward GetMonthRewardByMonth(int month)
        {
            if (this.monthRewardMap.ContainsKey(month))
            {
                return this.monthRewardMap[month];
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _SignType.Initialize();
        }

        public void LoadBasicSetFromXml(SecurityElement element)
        {
            this.freeRemedySignInTimes = StrParser.ParseDecInt(element.Attribute("FreeRemedySignInTimes"), 0);
            this.remedySignInCostDelta = StrParser.ParseDecInt(element.Attribute("RemedySignInCostDelta"), 0);
            this.remedySignStatus = StrParser.ParseBool(element.Attribute("RemedySignStatus"), false);
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "DailyReward")
                        {
                            if (tag == "RemedyReward")
                            {
                                goto Label_00B0;
                            }
                            if (tag == "RemedySignInCost")
                            {
                                goto Label_00C3;
                            }
                        }
                        else
                        {
                            this._dailyRewards.AddRange(LoadRewardsFromXml(element2));
                        }
                    }
                    continue;
                Label_00B0:
                    this._remedyRewards.AddRange(LoadRewardsFromXml(element2));
                    continue;
                Label_00C3:
                    this._remedySignInCosts.AddRange(LoadCostsFromXml(element2));
                }
            }
        }

        public static List<Cost> LoadCostsFromXml(SecurityElement element)
        {
            List<Cost> list = new List<Cost>();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Cost"))
                    {
                        Cost item = Cost.LoadFromXml(element2);
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "DailySignInConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "BasicSet")
                        {
                            this.LoadBasicSetFromXml(element2);
                        }
                        else if (tag == "MonthReward")
                        {
                            goto Label_0064;
                        }
                    }
                    continue;
                Label_0064:
                    this._monthRewards.Add(this.LoadMonthRewardFromXml(element2));
                }
            }
        }

        public MonthReward LoadMonthRewardFromXml(SecurityElement element)
        {
            MonthReward reward = new MonthReward();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "StepRewardSet"))
                    {
                        reward.stepRewards.AddRange(this.LoadStepRewardSetFromXml(element2));
                    }
                }
            }
            reward.month = StrParser.ParseDecInt(element.Attribute("Month"), 0);
            return reward;
        }

        public static List<Reward> LoadRewardsFromXml(SecurityElement element)
        {
            List<Reward> list = new List<Reward>();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Reward"))
                    {
                        list.Add(Reward.LoadFromXml(element2));
                    }
                }
            }
            return list;
        }

        public List<StepReward> LoadStepRewardSetFromXml(SecurityElement element)
        {
            List<StepReward> list = new List<StepReward>();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    StepReward item = new StepReward();
                    if (((str = element2.Tag) != null) && (str == "Step"))
                    {
                        item.signInCount = StrParser.ParseDecInt(element2.Attribute("SignInCount"), 0);
                        item.rewards.AddRange(LoadRewardsFromXml(element2));
                    }
                    list.Add(item);
                }
            }
            return list;
        }

        [ProtoMember(5, Name="dailyRewards", DataFormat=DataFormat.Default)]
        public List<Reward> dailyRewards
        {
            get
            {
                return this._dailyRewards;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="freeRemedySignInTimes", DataFormat=DataFormat.TwosComplement)]
        public int freeRemedySignInTimes
        {
            get
            {
                return this._freeRemedySignInTimes;
            }
            set
            {
                this._freeRemedySignInTimes = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="maxRemedySignInTimes", DataFormat=DataFormat.TwosComplement)]
        public int maxRemedySignInTimes
        {
            get
            {
                return this._maxRemedySignInTimes;
            }
            set
            {
                this._maxRemedySignInTimes = value;
            }
        }

        [ProtoMember(4, Name="monthRewards", DataFormat=DataFormat.Default)]
        public List<MonthReward> monthRewards
        {
            get
            {
                return this._monthRewards;
            }
        }

        [ProtoMember(6, Name="remedyRewards", DataFormat=DataFormat.Default)]
        public List<Reward> remedyRewards
        {
            get
            {
                return this._remedyRewards;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="remedySignInCostDelta", DataFormat=DataFormat.TwosComplement)]
        public int remedySignInCostDelta
        {
            get
            {
                return this._remedySignInCostDelta;
            }
            set
            {
                this._remedySignInCostDelta = value;
            }
        }

        [ProtoMember(3, Name="remedySignInCosts", DataFormat=DataFormat.Default)]
        public List<Cost> remedySignInCosts
        {
            get
            {
                return this._remedySignInCosts;
            }
        }

        [DefaultValue(false), ProtoMember(8, IsRequired=false, Name="remedySignStatus", DataFormat=DataFormat.Default)]
        public bool remedySignStatus
        {
            get
            {
                return this._remedySignStatus;
            }
            set
            {
                this._remedySignStatus = value;
            }
        }

        public class _SignType : TypeNameContainer<DailySignInConfig._SignType>
        {
            public const int RemedySign = 1;
            public const int Sign = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DailySignInConfig._SignType>.RegisterType("Sign", 0, "Sign");
                return (flag & TypeNameContainer<DailySignInConfig._SignType>.RegisterType("RemedySign", 1, "RemedySign"));
            }
        }

        [ProtoContract(Name="MonthReward")]
        public class MonthReward : IExtensible
        {
            private int _month;
            private readonly List<DailySignInConfig.StepReward> _stepRewards = new List<DailySignInConfig.StepReward>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="month", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int month
            {
                get
                {
                    return this._month;
                }
                set
                {
                    this._month = value;
                }
            }

            [ProtoMember(2, Name="stepRewards", DataFormat=DataFormat.Default)]
            public List<DailySignInConfig.StepReward> stepRewards
            {
                get
                {
                    return this._stepRewards;
                }
            }
        }

        [ProtoContract(Name="StepReward")]
        public class StepReward : IExtensible
        {
            private readonly List<Reward> _rewards = new List<Reward>();
            private int _signInCount;
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

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="signInCount", DataFormat=DataFormat.TwosComplement)]
            public int signInCount
            {
                get
                {
                    return this._signInCount;
                }
                set
                {
                    this._signInCount = value;
                }
            }
        }
    }
}

