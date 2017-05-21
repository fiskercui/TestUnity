namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="RewardSet")]
    public class RewardSet : IExtensible
    {
        private bool _dropAll;
        private int _id;
        private readonly List<RewardGroup> _rewardGroups = new List<RewardGroup>();
        private IExtension extensionObject;
        public Dictionary<int, RewardGroup> id_RewardGroupMap = new Dictionary<int, RewardGroup>();

        public RewardGroup GetRewardGroupById(int id)
        {
            RewardGroup group;
            if (!this.id_RewardGroupMap.TryGetValue(id, out group))
            {
                return null;
            }
            return group;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static RewardSet LoadFromXml(SecurityElement element)
        {
            RewardSet set = new RewardSet {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                dropAll = StrParser.ParseBool(element.Attribute("DropAll"), false)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "RewardGroup")
                    {
                        RewardGroup item = RewardGroup.LoadXml(element2);
                        set.rewardGroups.Add(item);
                    }
                }
            }
            return set;
        }

        [ProtoMember(2, IsRequired=false, Name="dropAll", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool dropAll
        {
            get
            {
                return this._dropAll;
            }
            set
            {
                this._dropAll = value;
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

        [ProtoMember(3, Name="rewardGroups", DataFormat=DataFormat.Default)]
        public List<RewardGroup> rewardGroups
        {
            get
            {
                return this._rewardGroups;
            }
        }
    }
}

