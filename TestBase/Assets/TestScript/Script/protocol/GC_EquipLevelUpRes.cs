namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_EquipLevelUpRes")]
    public class GC_EquipLevelUpRes : IExtensible
    {
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private int _critCount;
        private int _levelAfter;
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

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="critCount", DataFormat=DataFormat.TwosComplement)]
        public int critCount
        {
            get
            {
                return this._critCount;
            }
            set
            {
                this._critCount = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="levelAfter", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int levelAfter
        {
            get
            {
                return this._levelAfter;
            }
            set
            {
                this._levelAfter = value;
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

