namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="ConstructionTask")]
    public class ConstructionTask : IExtensible
    {
        private string _color = "";
        private CostAsset _costAssets;
        private ItemEx _costs;
        private int _guildConstruct;
        private bool _isDoing;
        private readonly List<Cost> _oneClickCompletedCosts = new List<Cost>();
        private int _playerContribution;
        private readonly List<RewardView> _reward = new List<RewardView>();
        private string _taskDesc = "";
        private int _taskIconId;
        private int _taskId;
        private int _taskIndex;
        private string _taskName = "";
        private int _taskQuality;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(8, IsRequired=false, Name="color", DataFormat=DataFormat.Default)]
        public string color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(11, IsRequired=false, Name="costAssets", DataFormat=DataFormat.Default)]
        public CostAsset costAssets
        {
            get
            {
                return this._costAssets;
            }
            set
            {
                this._costAssets = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(10, IsRequired=false, Name="costs", DataFormat=DataFormat.Default)]
        public ItemEx costs
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

        [ProtoMember(13, IsRequired=false, Name="guildConstruct", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildConstruct
        {
            get
            {
                return this._guildConstruct;
            }
            set
            {
                this._guildConstruct = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="isDoing", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isDoing
        {
            get
            {
                return this._isDoing;
            }
            set
            {
                this._isDoing = value;
            }
        }

        [ProtoMember(9, Name="oneClickCompletedCosts", DataFormat=DataFormat.Default)]
        public List<Cost> oneClickCompletedCosts
        {
            get
            {
                return this._oneClickCompletedCosts;
            }
        }

        [DefaultValue(0), ProtoMember(14, IsRequired=false, Name="playerContribution", DataFormat=DataFormat.TwosComplement)]
        public int playerContribution
        {
            get
            {
                return this._playerContribution;
            }
            set
            {
                this._playerContribution = value;
            }
        }

        [ProtoMember(12, Name="reward", DataFormat=DataFormat.Default)]
        public List<RewardView> reward
        {
            get
            {
                return this._reward;
            }
        }

        [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="taskDesc", DataFormat=DataFormat.Default)]
        public string taskDesc
        {
            get
            {
                return this._taskDesc;
            }
            set
            {
                this._taskDesc = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="taskIconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int taskIconId
        {
            get
            {
                return this._taskIconId;
            }
            set
            {
                this._taskIconId = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="taskId", DataFormat=DataFormat.TwosComplement)]
        public int taskId
        {
            get
            {
                return this._taskId;
            }
            set
            {
                this._taskId = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="taskIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int taskIndex
        {
            get
            {
                return this._taskIndex;
            }
            set
            {
                this._taskIndex = value;
            }
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="taskName", DataFormat=DataFormat.Default)]
        public string taskName
        {
            get
            {
                return this._taskName;
            }
            set
            {
                this._taskName = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="taskQuality", DataFormat=DataFormat.TwosComplement)]
        public int taskQuality
        {
            get
            {
                return this._taskQuality;
            }
            set
            {
                this._taskQuality = value;
            }
        }
    }
}

