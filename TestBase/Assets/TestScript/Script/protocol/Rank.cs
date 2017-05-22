namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Rank")]
    public class Rank : IExtensible
    {
        private double _damage;
        private double _doubleValue;
        private int _intValue;
        private string _name = "";
        private int _rankValue;
        private ShowReward _showReward;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, IsRequired=false, Name="damage", DataFormat=DataFormat.TwosComplement), DefaultValue((double) 0.0)]
        public double damage
        {
            get
            {
                return this._damage;
            }
            set
            {
                this._damage = value;
            }
        }

        [DefaultValue((double) 0.0), ProtoMember(4, IsRequired=false, Name="doubleValue", DataFormat=DataFormat.TwosComplement)]
        public double doubleValue
        {
            get
            {
                return this._doubleValue;
            }
            set
            {
                this._doubleValue = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="intValue", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int intValue
        {
            get
            {
                return this._intValue;
            }
            set
            {
                this._intValue = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="name", DataFormat=DataFormat.Default), DefaultValue("")]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="rankValue", DataFormat=DataFormat.TwosComplement)]
        public int rankValue
        {
            get
            {
                return this._rankValue;
            }
            set
            {
                this._rankValue = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="showReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public ShowReward showReward
        {
            get
            {
                return this._showReward;
            }
            set
            {
                this._showReward = value;
            }
        }
    }
}

