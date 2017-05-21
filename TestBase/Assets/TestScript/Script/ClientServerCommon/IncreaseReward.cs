namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="IncreaseReward")]
    public class IncreaseReward : IExtensible
    {
        private int _fromStep;
        private readonly List<Reward> _rewards = new List<Reward>();
        private IExtension extensionObject;

        public static List<Reward> GetRewards(List<IncreaseReward> increaseCosts, int step)
        {
            IncreaseReward reward = null;
            foreach (IncreaseReward reward2 in increaseCosts)
            {
                if (((reward == null) || (reward._fromStep <= reward2._fromStep)) && (step >= reward2._fromStep))
                {
                    reward = reward2;
                }
            }
            List<Reward> list = new List<Reward>();
            if (reward != null)
            {
                foreach (Reward reward3 in reward.rewards)
                {
                    Reward item = new Reward {
                        id = reward3.id,
                        level = reward3.level,
                        breakthoughtLevel = reward3.breakthoughtLevel,
                        possibility = reward3.possibility,
                        count = reward3.count + ((step - reward.fromStep) * reward3.increase)
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static IncreaseReward LoadFromXml(SecurityElement element)
        {
            IncreaseReward reward = new IncreaseReward {
                _fromStep = StrParser.ParseDecInt(element.Attribute("FromStep"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Reward"))
                    {
                        reward._rewards.Add(Reward.LoadFromXml(element2));
                    }
                }
            }
            return reward;
        }

        [ProtoMember(1, IsRequired=false, Name="fromStep", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int fromStep
        {
            get
            {
                return this._fromStep;
            }
            set
            {
                this._fromStep = value;
            }
        }

        [ProtoMember(2, Name="rewards", DataFormat=DataFormat.Default)]
        public List<Reward> rewards
        {
            get
            {
                return this._rewards;
            }
        }
    }
}

