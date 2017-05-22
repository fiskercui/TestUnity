namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CostAndRewardAndSync")]
    public class CostAndRewardAndSync : IExtensible
    {
        private readonly List<Cost> _costs = new List<Cost>();
        private Cost _notEnoughCost;
        private Reward _reward;
        private Reward _viewFixReward;
        private Reward _viewRandomreward;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="costs", DataFormat=DataFormat.Default)]
        public List<Cost> costs
        {
            get
            {
                return this._costs;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="notEnoughCost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Cost notEnoughCost
        {
            get
            {
                return this._notEnoughCost;
            }
            set
            {
                this._notEnoughCost = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="reward", DataFormat=DataFormat.Default)]
        public Reward reward
        {
            get
            {
                return this._reward;
            }
            set
            {
                this._reward = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="viewFixReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Reward viewFixReward
        {
            get
            {
                return this._viewFixReward;
            }
            set
            {
                this._viewFixReward = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="viewRandomreward", DataFormat=DataFormat.Default)]
        public Reward viewRandomreward
        {
            get
            {
                return this._viewRandomreward;
            }
            set
            {
                this._viewRandomreward = value;
            }
        }
    }
}

