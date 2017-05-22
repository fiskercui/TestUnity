namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GetTutorialAvatarAndSetPlayerNameRes")]
    public class GC_GetTutorialAvatarAndSetPlayerNameRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private PositionData _positionData;
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(3, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="positionData", DataFormat=DataFormat.Default)]
        public PositionData positionData
        {
            get
            {
                return this._positionData;
            }
            set
            {
                this._positionData = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="result", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

