namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="TargetCondition")]
    public class TargetCondition : IExtensible
    {
        private bool _boolValue;
        private double _doubleValue;
        private int _intValue;
        private string _stringValue = "";
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(false), ProtoMember(4, IsRequired=false, Name="boolValue", DataFormat=DataFormat.Default)]
        public bool boolValue
        {
            get
            {
                return this._boolValue;
            }
            set
            {
                this._boolValue = value;
            }
        }

        [DefaultValue((double) 0.0), ProtoMember(5, IsRequired=false, Name="doubleValue", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="intValue", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(3, IsRequired=false, Name="stringValue", DataFormat=DataFormat.Default), DefaultValue("")]
        public string stringValue
        {
            get
            {
                return this._stringValue;
            }
            set
            {
                this._stringValue = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

