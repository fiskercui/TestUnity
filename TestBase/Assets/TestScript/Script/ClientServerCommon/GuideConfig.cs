namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="GuideConfig")]
    public class GuideConfig : Configuration, IExtensible
    {
        private readonly List<MainType> _freshmanAdvises = new List<MainType>();
        private readonly List<MainType> _mainTypes = new List<MainType>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _GuideType.Initialize();
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "GuideConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "MainTypeSet")
                    {
                        this.LoadGuideSetFromXml(element2);
                    }
                }
            }
        }

        private void LoadGuideSetFromXml(SecurityElement element)
        {
            int num = TypeNameContainer<_GuideType>.Parse(element.Attribute("GuideType"), 0);
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag.Equals("MainType"))
                    {
                        switch (num)
                        {
                            case 1:
                                this._mainTypes.Add(this.LoadMainTypeFromXml(element2));
                                break;

                            case 2:
                                this._freshmanAdvises.Add(this.LoadMainTypeFromXml(element2));
                                break;
                        }
                    }
                }
            }
        }

        private MainType LoadMainTypeFromXml(SecurityElement element)
        {
            MainType type = new MainType {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true),
                icon = StrParser.ParseStr(element.Attribute("Icon"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag.Equals("SubType"))
                    {
                        SubType item = this.LoadSubTypeFromXml(element2);
                        if (item != null)
                        {
                            type.subTypes.Add(item);
                        }
                    }
                }
            }
            return type;
        }

        private SubType LoadSubTypeFromXml(SecurityElement element)
        {
            if (element.Tag != "SubType")
            {
                return null;
            }
            return new SubType { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true),
                desc = StrParser.ParseStr(element.Attribute("Desc"), "", true),
                gotoUI = TypeNameContainer<_UIType>.Parse(element.Attribute("GoToUI"), 0),
                handBookParam = StrParser.ParseHexInt(element.Attribute("HandBookParam"), 0)
            };
        }

        [ProtoMember(2, Name="freshmanAdvises", DataFormat=DataFormat.Default)]
        public List<MainType> freshmanAdvises
        {
            get
            {
                return this._freshmanAdvises;
            }
        }

        [ProtoMember(1, Name="mainTypes", DataFormat=DataFormat.Default)]
        public List<MainType> mainTypes
        {
            get
            {
                return this._mainTypes;
            }
        }

        public class _GuideType : TypeNameContainer<GuideConfig._GuideType>
        {
            public const int FreshmanAdvise = 2;
            public const int Main = 1;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<GuideConfig._GuideType>.RegisterType("UnKnow", 0);
                flag &= TypeNameContainer<GuideConfig._GuideType>.RegisterType("Main", 1);
                return (flag & TypeNameContainer<GuideConfig._GuideType>.RegisterType("FreshmanAdvise", 2));
            }
        }

        [ProtoContract(Name="MainType")]
        public class MainType : IExtensible
        {
            private string _icon = "";
            private int _id;
            private string _name = "";
            private readonly List<GuideConfig.SubType> _subTypes = new List<GuideConfig.SubType>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="icon", DataFormat=DataFormat.Default)]
            public string icon
            {
                get
                {
                    return this._icon;
                }
                set
                {
                    this._icon = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int id
            {
                get
                {
                    return this._id;
                }
                set
                {
                    this._id = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
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

            [ProtoMember(3, Name="subTypes", DataFormat=DataFormat.Default)]
            public List<GuideConfig.SubType> subTypes
            {
                get
                {
                    return this._subTypes;
                }
            }
        }

        [ProtoContract(Name="SubType")]
        public class SubType : IExtensible
        {
            private string _desc = "";
            private int _gotoUI;
            private int _handBookParam;
            private int _id;
            private string _name = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="desc", DataFormat=DataFormat.Default)]
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

            [ProtoMember(4, IsRequired=false, Name="gotoUI", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int gotoUI
            {
                get
                {
                    return this._gotoUI;
                }
                set
                {
                    this._gotoUI = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="handBookParam", DataFormat=DataFormat.TwosComplement)]
            public int handBookParam
            {
                get
                {
                    return this._handBookParam;
                }
                set
                {
                    this._handBookParam = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int id
            {
                get
                {
                    return this._id;
                }
                set
                {
                    this._id = value;
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
        }
    }
}

