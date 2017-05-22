namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryNotifyRes")]
    public class GC_QueryNotifyRes : IExtensible
    {
        private readonly List<ActivityData> _activityData = new List<ActivityData>();
        private int _assisantNum;
        private int _callback;
        private readonly List<Quest> _changedQuests = new List<Quest>();
        private readonly List<State> _functionStates = new List<State>();
        private QuestQuick _questQuick;
        private int _result;
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

        [ProtoMember(3, IsRequired=true, Name="assisantNum", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(6, Name="changedQuests", DataFormat=DataFormat.Default)]
        public List<Quest> changedQuests
        {
            get
            {
                return this._changedQuests;
            }
        }

        [ProtoMember(5, Name="functionStates", DataFormat=DataFormat.Default)]
        public List<State> functionStates
        {
            get
            {
                return this._functionStates;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="questQuick", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public QuestQuick questQuick
        {
            get
            {
                return this._questQuick;
            }
            set
            {
                this._questQuick = value;
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
    }
}

