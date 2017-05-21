namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="StartServerRewardConfig")]
    public class StartServerRewardConfig : Configuration, IExtensible
    {
        private long _resetTime;
        private readonly List<StartServerReward> _startServerRewards = new List<StartServerReward>();
        private IExtension extensionObject;

        public StartServerReward GetStartServerRewardByDay(int day)
        {
            foreach (StartServerReward reward in this._startServerRewards)
            {
                if (reward.day == day)
                {
                    return reward;
                }
            }
            return null;
        }

        public StartServerReward GetStartServerRewardByID(int id)
        {
            foreach (StartServerReward reward in this._startServerRewards)
            {
                if (reward.id == id)
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

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "StartServerRewardConfig")
            {
                this._resetTime = StrParser.ParseDateTime(element.Attribute("ResetTime"));
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string str;
                        if (((str = element2.Tag) != null) && (str == "StartServerReward"))
                        {
                            StartServerReward item = this.LoadStartServerRewardFromXml(element2);
                            this._startServerRewards.Add(item);
                        }
                    }
                }
            }
        }

        private StartServerReward LoadStartServerRewardFromXml(SecurityElement element)
        {
            StartServerReward reward = new StartServerReward {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                day = StrParser.ParseDecInt(element.Attribute("Day"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Reward"))
                    {
                        Reward item = Reward.LoadFromXml(element2);
                        reward.rewards.Add(item);
                    }
                }
            }
            return reward;
        }

        public DateTime resetDateTime
        {
            get
            {
                return new DateTime(this._resetTime * 0x2710L);
            }
        }

        [DefaultValue((long) 0L), ProtoMember(1, IsRequired=false, Name="resetTime", DataFormat=DataFormat.TwosComplement)]
        public long resetTime
        {
            get
            {
                return this._resetTime;
            }
            set
            {
                this._resetTime = value;
            }
        }

        [ProtoMember(2, Name="startServerRewards", DataFormat=DataFormat.Default)]
        public List<StartServerReward> startServerRewards
        {
            get
            {
                return this._startServerRewards;
            }
        }

        [ProtoContract(Name="StartServerReward")]
        public class StartServerReward : IExtensible
        {
            private int _day;
            private int _id;
            private readonly List<Reward> _rewards = new List<Reward>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="day", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int day
            {
                get
                {
                    return this._day;
                }
                set
                {
                    this._day = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(3, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> rewards
            {
                get
                {
                    return this._rewards;
                }
            }
        }
    }
}

