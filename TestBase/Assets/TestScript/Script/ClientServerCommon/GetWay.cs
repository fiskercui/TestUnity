namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="GetWay")]
    public class GetWay : IExtensible
    {
        private int _data;
        private string _desc = "";
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static GetWay LoadFromXml(SecurityElement element)
        {
            return new GetWay { 
                type = _UIType.ParseUIType(element.Attribute("Type"), 0),
                data = StrParser.ParseHexInt(element.Attribute("Data"), 0),
                desc = StrParser.ParseStr(element.Attribute("Desc"), string.Empty)
            };
        }

        [ProtoMember(3, IsRequired=false, Name="data", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
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

