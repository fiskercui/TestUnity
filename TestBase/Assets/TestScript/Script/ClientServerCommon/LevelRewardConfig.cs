namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="LevelRewardConfig")]
    public class LevelRewardConfig : Configuration, IExtensible
    {
        private int _activityId;
        private readonly List<UpgradeReward> _upgradeRewards = new List<UpgradeReward>();
        private IExtension extensionObject;
        private Dictionary<int, UpgradeReward> id_upgradeReward = new Dictionary<int, UpgradeReward>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (UpgradeReward reward in this.upgradeRewards)
            {
                if (reward != null)
                {
                    if (this.id_upgradeReward.ContainsKey(reward.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + reward.id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_upgradeReward.Add(reward.id, reward);
                    }
                }
            }
        }

        public UpgradeReward GetLevelRewardById(int id)
        {
            UpgradeReward reward = null;
            if (!this.id_upgradeReward.TryGetValue(id, out reward))
            {
                return null;
            }
            return reward;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "LevelRewardConfig")
            {
                this.activityId = StrParser.ParseHexInt(element.Attribute("ActivityId"), 0);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        if (element2.Tag == "UpgradeReward")
                        {
                            this.upgradeRewards.Add(this.LoadUpgradeRewardFromXml(element2));
                        }
                    }
                }
            }
        }

        private UpgradeReward LoadUpgradeRewardFromXml(SecurityElement element)
        {
            UpgradeReward reward = new UpgradeReward {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                level = StrParser.ParseDecInt(element.Attribute("Level"), 0)
            };
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "Reward")
                {
                    reward.rewards.Add(Reward.LoadFromXml(element2));
                }
            }
            reward.iconId = StrParser.ParseHexInt(element.Attribute("IconId"), 0);
            reward.title = StrParser.ParseStr(element.Attribute("Title"), "");
            reward.desc = StrParser.ParseStr(element.Attribute("Desc"), "");
            return reward;
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="activityId", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(1, Name="upgradeRewards", DataFormat=DataFormat.Default)]
        public List<UpgradeReward> upgradeRewards
        {
            get
            {
                return this._upgradeRewards;
            }
        }

        [ProtoContract(Name="UpgradeReward")]
        public class UpgradeReward : IExtensible
        {
            private string _desc = "";
            private int _iconId;
            private int _id;
            private int _level;
            private readonly List<Reward> _rewards = new List<Reward>();
            private string _title = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement)]
            public int iconId
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

            [ProtoMember(2, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(3, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> rewards
            {
                get
                {
                    return this._rewards;
                }
            }

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="title", DataFormat=DataFormat.Default)]
            public string title
            {
                get
                {
                    return this._title;
                }
                set
                {
                    this._title = value;
                }
            }
        }
    }
}

