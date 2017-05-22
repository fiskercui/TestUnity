namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GuildTaskInfo")]
    public class GuildTaskInfo : IExtensible
    {
        private int _completedTaskCount;
        private Cost _diceCost;
        private int _doingTaskProgress;
        private RewardView _extRewardView;
        private int _freeDiceCount;
        private int _freeRefreshCountPerDay;
        private readonly List<int> _lastDiceResults = new List<int>();
        private int _maxCompletedTaskPerDay;
        private int _maxFreeDiceCountPerDay;
        private long _nextRefreshTime;
        private Cost _refreshCost;
        private int _refreshCount;
        private readonly List<RewardView> _rewardViews = new List<RewardView>();
        private string _taskDesc = "";
        private string _taskExtRewardDesc = "";
        private int _taskIconId;
        private int _taskId;
        private string _taskName = "";
        private string _taskParamList = "";
        private int _taskQuality;
        private int _taskType;
        private int _total;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(0x11, IsRequired=false, Name="completedTaskCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int completedTaskCount
        {
            get
            {
                return this._completedTaskCount;
            }
            set
            {
                this._completedTaskCount = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(20, IsRequired=false, Name="diceCost", DataFormat=DataFormat.Default)]
        public Cost diceCost
        {
            get
            {
                return this._diceCost;
            }
            set
            {
                this._diceCost = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x12, IsRequired=false, Name="doingTaskProgress", DataFormat=DataFormat.TwosComplement)]
        public int doingTaskProgress
        {
            get
            {
                return this._doingTaskProgress;
            }
            set
            {
                this._doingTaskProgress = value;
            }
        }

        [ProtoMember(11, IsRequired=false, Name="extRewardView", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public RewardView extRewardView
        {
            get
            {
                return this._extRewardView;
            }
            set
            {
                this._extRewardView = value;
            }
        }

        [ProtoMember(15, IsRequired=false, Name="freeDiceCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int freeDiceCount
        {
            get
            {
                return this._freeDiceCount;
            }
            set
            {
                this._freeDiceCount = value;
            }
        }

        [ProtoMember(14, IsRequired=false, Name="freeRefreshCountPerDay", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int freeRefreshCountPerDay
        {
            get
            {
                return this._freeRefreshCountPerDay;
            }
            set
            {
                this._freeRefreshCountPerDay = value;
            }
        }

        [ProtoMember(0x15, Name="lastDiceResults", DataFormat=DataFormat.TwosComplement)]
        public List<int> lastDiceResults
        {
            get
            {
                return this._lastDiceResults;
            }
        }

        [ProtoMember(12, IsRequired=false, Name="maxCompletedTaskPerDay", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int maxCompletedTaskPerDay
        {
            get
            {
                return this._maxCompletedTaskPerDay;
            }
            set
            {
                this._maxCompletedTaskPerDay = value;
            }
        }

        [ProtoMember(13, IsRequired=false, Name="maxFreeDiceCountPerDay", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int maxFreeDiceCountPerDay
        {
            get
            {
                return this._maxFreeDiceCountPerDay;
            }
            set
            {
                this._maxFreeDiceCountPerDay = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(0x16, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement)]
        public long nextRefreshTime
        {
            get
            {
                return this._nextRefreshTime;
            }
            set
            {
                this._nextRefreshTime = value;
            }
        }

        [ProtoMember(0x13, IsRequired=false, Name="refreshCost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Cost refreshCost
        {
            get
            {
                return this._refreshCost;
            }
            set
            {
                this._refreshCost = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x10, IsRequired=false, Name="refreshCount", DataFormat=DataFormat.TwosComplement)]
        public int refreshCount
        {
            get
            {
                return this._refreshCount;
            }
            set
            {
                this._refreshCount = value;
            }
        }

        [ProtoMember(9, Name="rewardViews", DataFormat=DataFormat.Default)]
        public List<RewardView> rewardViews
        {
            get
            {
                return this._rewardViews;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="taskDesc", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [DefaultValue(""), ProtoMember(10, IsRequired=false, Name="taskExtRewardDesc", DataFormat=DataFormat.Default)]
        public string taskExtRewardDesc
        {
            get
            {
                return this._taskExtRewardDesc;
            }
            set
            {
                this._taskExtRewardDesc = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="taskIconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(1, IsRequired=false, Name="taskId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="taskName", DataFormat=DataFormat.Default)]
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

        [DefaultValue(""), ProtoMember(8, IsRequired=false, Name="taskParamList", DataFormat=DataFormat.Default)]
        public string taskParamList
        {
            get
            {
                return this._taskParamList;
            }
            set
            {
                this._taskParamList = value;
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

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="taskType", DataFormat=DataFormat.TwosComplement)]
        public int taskType
        {
            get
            {
                return this._taskType;
            }
            set
            {
                this._taskType = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="total", DataFormat=DataFormat.TwosComplement)]
        public int total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
    }
}

