namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="MysteryerRefresh")]
    public class MysteryerRefresh : IExtensible
    {
        private Cost _cost;
        private int _remainTimes;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="cost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Cost cost
        {
            get
            {
                return this._cost;
            }
            set
            {
                this._cost = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="remainTimes", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int remainTimes
        {
            get
            {
                return this._remainTimes;
            }
            set
            {
                this._remainTimes = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

