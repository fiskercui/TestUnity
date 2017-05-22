namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_PickQuestRewardRes")]
    public class GC_PickQuestRewardRes : IExtensible
    {
        private int _callback;
        private readonly List<Quest> _changedQuests = new List<Quest>();
        private CostAndRewardAndSync _costAndRewardAndSync;
        private int _questId;
        private QuestQuick _questQuick;
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [ProtoMember(5, Name="changedQuests", DataFormat=DataFormat.Default)]
        public List<Quest> changedQuests
        {
            get
            {
                return this._changedQuests;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public CostAndRewardAndSync costAndRewardAndSync
        {
            get
            {
                return this._costAndRewardAndSync;
            }
            set
            {
                this._costAndRewardAndSync = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="questId", DataFormat=DataFormat.TwosComplement)]
        public int questId
        {
            get
            {
                return this._questId;
            }
            set
            {
                this._questId = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(6, IsRequired=false, Name="questQuick", DataFormat=DataFormat.Default)]
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

