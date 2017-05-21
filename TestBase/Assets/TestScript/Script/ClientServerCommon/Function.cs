namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Function")]
    public class Function : IExtensible
    {
        private string _name = "";
        private string _value = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="name", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="value", DataFormat=DataFormat.Default)]
        public string value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
}

