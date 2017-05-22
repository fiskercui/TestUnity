namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryInitInfoRes")]
    public class GC_QueryInitInfoRes : IExtensible
    {
        private readonly List<ActivityData> _activityData = new List<ActivityData>();
        private int _assisantNum;
        private int _callback;
        private readonly List<State> _functionStates = new List<State>();
        private readonly List<Goods> _goods = new List<Goods>();
        private Function _isFunctionOpen;
        private long _nextRefreshTime;
        private readonly List<Notice> _notices = new List<Notice>();
        private Player _player;
        private int _result;
        private int _serverType;
        private bool _showNotice;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, Name="activityData", DataFormat=DataFormat.Default)]
        public List<ActivityData> activityData
        {
            get
            {
                return this._activityData;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="assisantNum", DataFormat=DataFormat.TwosComplement)]
        public int assisantNum
        {
            get
            {
                return this._assisantNum;
            }
            set
            {
                this._assisantNum = value;
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

        [ProtoMember(10, Name="functionStates", DataFormat=DataFormat.Default)]
        public List<State> functionStates
        {
            get
            {
                return this._functionStates;
            }
        }

        [ProtoMember(11, Name="goods", DataFormat=DataFormat.Default)]
        public List<Goods> goods
        {
            get
            {
                return this._goods;
            }
        }

        [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="isFunctionOpen", DataFormat=DataFormat.Default)]
        public Function isFunctionOpen
        {
            get
            {
                return this._isFunctionOpen;
            }
            set
            {
                this._isFunctionOpen = value;
            }
        }

        [ProtoMember(12, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [ProtoMember(5, Name="notices", DataFormat=DataFormat.Default)]
        public List<Notice> notices
        {
            get
            {
                return this._notices;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="player", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Player player
        {
            get
            {
                return this._player;
            }
            set
            {
                this._player = value;
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

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="serverType", DataFormat=DataFormat.TwosComplement)]
        public int serverType
        {
            get
            {
                return this._serverType;
            }
            set
            {
                this._serverType = value;
            }
        }

        [DefaultValue(false), ProtoMember(6, IsRequired=false, Name="showNotice", DataFormat=DataFormat.Default)]
        public bool showNotice
        {
            get
            {
                return this._showNotice;
            }
            set
            {
                this._showNotice = value;
            }
        }
    }
}

