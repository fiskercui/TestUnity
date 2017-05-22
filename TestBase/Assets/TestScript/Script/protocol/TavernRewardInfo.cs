namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="TavernRewardInfo")]
    public class TavernRewardInfo : IExtensible
    {
        private Consumable _reward;
        private int _tavernId;
        private Consumable _tenTavernReward;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="reward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Consumable reward
        {
            get
            {
                return this._reward;
            }
            set
            {
                this._reward = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="tavernId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int tavernId
        {
            get
            {
                return this._tavernId;
            }
            set
            {
                this._tavernId = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="tenTavernReward", DataFormat=DataFormat.Default)]
        public Consumable tenTavernReward
        {
            get
            {
                return this._tenTavernReward;
            }
            set
            {
                this._tenTavernReward = value;
            }
        }
    }
}

