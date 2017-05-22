namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryFriendCampaignRes")]
    public class GC_QueryFriendCampaignRes : IExtensible
    {
        private int _alreadyResetCount;
        private int _callback;
        private readonly List<HpInfo> _enemyHpInfo = new List<HpInfo>();
        private Player _enemyPlayer;
        private readonly List<FriendCampaignPosition> _friendPositions = new List<FriendCampaignPosition>();
        private int _historyMaxDungeonId;
        private bool _isJoin;
        private int _lastFriendId;
        private readonly List<int> _lastFriendIds = new List<int>();
        private int _lastPositionId;
        private int _passStageId;
        private int _result;
        private RobotInfo _robotInfo;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(8, IsRequired=false, Name="alreadyResetCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int alreadyResetCount
        {
            get
            {
                return this._alreadyResetCount;
            }
            set
            {
                this._alreadyResetCount = value;
            }
        }

        [ProtoMember(1, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
        public int callback
        {
            get
            {
                return this._callback;
            }
            set
            {
                this._callback = value;
            }
        }

        [ProtoMember(10, Name="enemyHpInfo", DataFormat=DataFormat.Default)]
        public List<HpInfo> enemyHpInfo
        {
            get
            {
                return this._enemyHpInfo;
            }
        }

        [DefaultValue((string) null), ProtoMember(9, IsRequired=false, Name="enemyPlayer", DataFormat=DataFormat.Default)]
        public Player enemyPlayer
        {
            get
            {
                return this._enemyPlayer;
            }
            set
            {
                this._enemyPlayer = value;
            }
        }

        [ProtoMember(11, Name="friendPositions", DataFormat=DataFormat.Default)]
        public List<FriendCampaignPosition> friendPositions
        {
            get
            {
                return this._friendPositions;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="historyMaxDungeonId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int historyMaxDungeonId
        {
            get
            {
                return this._historyMaxDungeonId;
            }
            set
            {
                this._historyMaxDungeonId = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="isJoin", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isJoin
        {
            get
            {
                return this._isJoin;
            }
            set
            {
                this._isJoin = value;
            }
        }

        [ProtoMember(12, IsRequired=false, Name="lastFriendId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int lastFriendId
        {
            get
            {
                return this._lastFriendId;
            }
            set
            {
                this._lastFriendId = value;
            }
        }

        [ProtoMember(6, Name="lastFriendIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> lastFriendIds
        {
            get
            {
                return this._lastFriendIds;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="lastPositionId", DataFormat=DataFormat.TwosComplement)]
        public int lastPositionId
        {
            get
            {
                return this._lastPositionId;
            }
            set
            {
                this._lastPositionId = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="passStageId", DataFormat=DataFormat.TwosComplement)]
        public int passStageId
        {
            get
            {
                return this._passStageId;
            }
            set
            {
                this._passStageId = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
        public int result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }

        [ProtoMember(13, IsRequired=false, Name="robotInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public RobotInfo robotInfo
        {
            get
            {
                return this._robotInfo;
            }
            set
            {
                this._robotInfo = value;
            }
        }
    }
}

