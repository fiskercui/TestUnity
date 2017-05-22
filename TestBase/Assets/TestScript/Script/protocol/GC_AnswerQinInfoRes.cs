namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_AnswerQinInfoRes")]
    public class GC_AnswerQinInfoRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private QinInfo _qinInfo;
        private int _result;
        private bool _rightFalse;
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default)]
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

        [DefaultValue((string) null), ProtoMember(5, IsRequired=false, Name="qinInfo", DataFormat=DataFormat.Default)]
        public QinInfo qinInfo
        {
            get
            {
                return this._qinInfo;
            }
            set
            {
                this._qinInfo = value;
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

        [ProtoMember(3, IsRequired=false, Name="rightFalse", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool rightFalse
        {
            get
            {
                return this._rightFalse;
            }
            set
            {
                this._rightFalse = value;
            }
        }
    }
}

