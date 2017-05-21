namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="EmBattleAttribute")]
    public class EmBattleAttribute : IExtensible
    {
        private string _desc = "";
        private readonly List<PropertyModifier> _modifiers = new List<PropertyModifier>();
        private string _name = "";
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }

        [ProtoMember(2, Name="modifiers", DataFormat=DataFormat.Default)]
        public List<PropertyModifier> modifiers
        {
            get
            {
                return this._modifiers;
            }
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
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

