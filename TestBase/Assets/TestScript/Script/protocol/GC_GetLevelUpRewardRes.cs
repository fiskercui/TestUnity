namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GetLevelUpRewardRes")]
    public class GC_GetLevelUpRewardRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private int _curPickedLevel;
        private LevelAttrib _levelAttri;
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

        [ProtoMember(5, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="curPickedLevel", DataFormat=DataFormat.TwosComplement)]
        public int curPickedLevel
        {
            get
            {
                return this._curPickedLevel;
            }
            set
            {
                this._curPickedLevel = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="levelAttri", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public LevelAttrib levelAttri
        {
            get
            {
                return this._levelAttri;
            }
            set
            {
                this._levelAttri = value;
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

