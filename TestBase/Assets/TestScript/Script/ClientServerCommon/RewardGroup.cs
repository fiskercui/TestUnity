namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="RewardGroup")]
    public class RewardGroup : IExtensible
    {
        private float _possibility;
        private int _rewardGroupId;
        private readonly List<Reward> _rewards = new List<Reward>();
        private readonly List<RewardTypeCount> _rewardTypeCounts = new List<RewardTypeCount>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static RewardGroup LoadXml(SecurityElement element)
        {
            RewardGroup group = new RewardGroup {
                possibility = StrParser.ParseFloat(element.Attribute("Possibility"), 1f),
                rewardGroupId = StrParser.ParseHexInt(element.Attribute("Id"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "RewardTypeCount")
                        {
                            group.rewardTypeCounts.Add(RewardTypeCount.LoadFromXml(element2));
                        }
                        else if (tag == "Reward")
                        {
                            goto Label_0096;
                        }
                    }
                    continue;
                Label_0096:
                    group.rewards.Add(Reward.LoadFromXml(element2));
                }
            }
            return group;
        }

        [ProtoMember(1, IsRequired=false, Name="possibility", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float possibility
        {
            get
            {
                return this._possibility;
            }
            set
            {
                this._possibility = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="rewardGroupId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int rewardGroupId
        {
            get
            {
                return this._rewardGroupId;
            }
            set
            {
                this._rewardGroupId = value;
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

        [ProtoMember(2, Name="rewardTypeCounts", DataFormat=DataFormat.Default)]
        public List<RewardTypeCount> rewardTypeCounts
        {
            get
            {
                return this._rewardTypeCounts;
            }
        }
    }
}

