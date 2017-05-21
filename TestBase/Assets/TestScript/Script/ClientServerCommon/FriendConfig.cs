namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="FriendConfig")]
    public class FriendConfig : Configuration, IExtensible
    {
        private FriendCombatInfo _friendCombat;
        private int _maxRandomCount;
        private long _refreshTime;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        private void LoadFriendCombatInfoFromXml(SecurityElement element)
        {
            FriendCombatInfo info = new FriendCombatInfo {
                MaxGetCombatRewardCount = StrParser.ParseDecInt(element.Attribute("MaxGetCombatRewardCount"), 0),
                GetCombatRewardPercent = StrParser.ParseFloat(element.Attribute("GetCombatRewardPercent"), 0f),
                MaxCombatRound = StrParser.ParseDecInt(element.Attribute("MaxCombatRound"), 0),
                MaxRoundWhoWin = TypeNameContainer<ClientServerCommon._CampType>.Parse(element.Attribute("MaxRoundWhoWin"), 0),
                SenceId = StrParser.ParseHexInt(element.Attribute("SenceId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "FriendCombatReward"))
                    {
                        info.FriendCombatRewards.Add(this.LoadFriendCombatRewardFromXml(element2));
                    }
                }
            }
            this._friendCombat = info;
        }

        private FriendCombatReward LoadFriendCombatRewardFromXml(SecurityElement element)
        {
            FriendCombatReward reward = new FriendCombatReward {
                RewardId = StrParser.ParseHexInt(element.Attribute("RewardId"), 0),
                Weight = StrParser.ParseDecInt(element.Attribute("Weight"), 0)
            };
            foreach (SecurityElement element2 in element.Children)
            {
                string str;
                if (((str = element2.Tag) != null) && (str == "Reward"))
                {
                    Reward item = Reward.LoadFromXml(element2);
                    reward.Rewards.Add(item);
                }
            }
            return reward;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "FriendConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "MaxRandomCount")
                        {
                            if (tag == "RefreshTime")
                            {
                                goto Label_007F;
                            }
                            if (tag == "FriendCombatInfo")
                            {
                                goto Label_0092;
                            }
                        }
                        else
                        {
                            this._maxRandomCount = StrParser.ParseDecInt(element2.Text, 0);
                        }
                    }
                    continue;
                Label_007F:
                    this._refreshTime = StrParser.ParseDateTime(element2.Text);
                    continue;
                Label_0092:
                    this.LoadFriendCombatInfoFromXml(element2);
                }
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="friendCombat", DataFormat=DataFormat.Default)]
        public FriendCombatInfo FriendCombat
        {
            get
            {
                return this._friendCombat;
            }
            set
            {
                this._friendCombat = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="maxRandomCount", DataFormat=DataFormat.TwosComplement)]
        public int MaxRandomCount
        {
            get
            {
                return this._maxRandomCount;
            }
            set
            {
                this._maxRandomCount = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="refreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long RefreshTime
        {
            get
            {
                return this._refreshTime;
            }
            set
            {
                this._refreshTime = value;
            }
        }

        public DateTime RefreshTimeDateTime
        {
            get
            {
                return new DateTime(this._refreshTime * 0x2710L);
            }
        }

        [ProtoContract(Name="FriendCombatInfo")]
        public class FriendCombatInfo : IExtensible
        {
            private readonly List<ClientServerCommon.FriendConfig.FriendCombatReward> _friendCombatRewards = new List<ClientServerCommon.FriendConfig.FriendCombatReward>();
            private float _getCombatRewardPercent;
            private int _maxCombatRound;
            private int _maxGetCombatRewardCount;
            private int _maxRoundWhoWin;
            private int _senceId;
            private IExtension extensionObject;

            public ClientServerCommon.FriendConfig.FriendCombatReward GetCombatRewardById(int combatRewardId)
            {
                foreach (ClientServerCommon.FriendConfig.FriendCombatReward reward in this._friendCombatRewards)
                {
                    if (reward.RewardId == combatRewardId)
                    {
                        return reward;
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, Name="friendCombatRewards", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.FriendConfig.FriendCombatReward> FriendCombatRewards
            {
                get
                {
                    return this._friendCombatRewards;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(5, IsRequired=false, Name="getCombatRewardPercent", DataFormat=DataFormat.FixedSize)]
            public float GetCombatRewardPercent
            {
                get
                {
                    return this._getCombatRewardPercent;
                }
                set
                {
                    this._getCombatRewardPercent = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="maxCombatRound", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MaxCombatRound
            {
                get
                {
                    return this._maxCombatRound;
                }
                set
                {
                    this._maxCombatRound = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="maxGetCombatRewardCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MaxGetCombatRewardCount
            {
                get
                {
                    return this._maxGetCombatRewardCount;
                }
                set
                {
                    this._maxGetCombatRewardCount = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="maxRoundWhoWin", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(3, IsRequired=false, Name="senceId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int SenceId
            {
                get
                {
                    return this._senceId;
                }
                set
                {
                    this._senceId = value;
                }
            }
        }

        [ProtoContract(Name="FriendCombatReward")]
        public class FriendCombatReward : IExtensible
        {
            private int _rewardId;
            private readonly List<Reward> _rewards = new List<Reward>();
            private int _weight;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="rewardId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(3, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> Rewards
            {
                get
                {
                    return this._rewards;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="weight", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Weight
            {
                get
                {
                    return this._weight;
                }
                set
                {
                    this._weight = value;
                }
            }
        }
    }
}

