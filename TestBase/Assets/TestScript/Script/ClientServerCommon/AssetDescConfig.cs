namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="AssetDescConfig")]
    public class AssetDescConfig : Configuration, IExtensible
    {
        private readonly List<AssetDescSet> _assetDescSets = new List<AssetDescSet>();
        private string _combineInputPath = "";
        private string _combineOutputPath = "";
        private readonly List<CombineSetting> _combineSettings = new List<CombineSetting>();
        private string _iconPath = "";
        private IExtension extensionObject;
        private Dictionary<int, AssetDesc> id_assetDescMap = new Dictionary<int, AssetDesc>();
        private Dictionary<string, CombineSetting> output_CombineSettingMap = new Dictionary<string, CombineSetting>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (AssetDescSet set in this.assetDescSets)
            {
                if (set != null)
                {
                    foreach (AssetDesc desc in set.assetDescs)
                    {
                        if (desc != null)
                        {
                            if (this.id_assetDescMap.ContainsKey(desc.id))
                            {
                                Logger.Error(base.GetType().Name + " ContainsKey 0x" + desc.id.ToString("X"), new object[0]);
                            }
                            else
                            {
                                this.id_assetDescMap.Add(desc.id, desc);
                            }
                        }
                    }
                }
            }
            foreach (CombineSetting setting in this._combineSettings)
            {
                if (setting != null)
                {
                    if (this.output_CombineSettingMap.ContainsKey(setting.outputIcon))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey " + setting.outputIcon, new object[0]);
                    }
                    else
                    {
                        this.output_CombineSettingMap.Add(setting.outputIcon, setting);
                    }
                }
            }
        }

        public AssetDesc GetAssetDescById(int id)
        {
            AssetDesc desc;
            if (!this.id_assetDescMap.TryGetValue(id, out desc))
            {
                return null;
            }
            return desc;
        }

        public List<AssetDesc> GetAssetDescs()
        {
            List<AssetDesc> list = new List<AssetDesc>();
            foreach (KeyValuePair<int, AssetDesc> pair in this.id_assetDescMap)
            {
                list.Add(pair.Value);
            }
            return list;
        }

        public CombineSetting GetCombineSetting(string outputIcon)
        {
            CombineSetting setting;
            if (!this.output_CombineSettingMap.TryGetValue(outputIcon, out setting))
            {
                return null;
            }
            return setting;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        private AssetDesc LoadAssetDescFromXml(SecurityElement element)
        {
            return new AssetDesc { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true),
                desc = StrParser.ParseStr(element.Attribute("Desc"), "", true),
                extraDesc = StrParser.ParseStr(element.Attribute("ExtraDesc"), "", true),
                icon = StrParser.ParseStr(element.Attribute("Icon"), ""),
                uv = rect.LoadFromXml(element.Attribute("UV")),
                originalIcon = StrParser.ParseStr(element.Attribute("OriginalIcon"), ""),
                outputIcon = StrParser.ParseStr(element.Attribute("OutputIcon"), "")
            };
        }

        private AssetDescSet LoadAssetDescSetFromXml(SecurityElement element)
        {
            if (element.Children == null)
            {
                return null;
            }
            AssetDescSet set = new AssetDescSet {
                assetType = TypeNameContainer<IDSeg>.Parse(element.Attribute("Type"), 0)
            };
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "AssetDesc")
                {
                    set.assetDescs.Add(this.LoadAssetDescFromXml(element2));
                }
            }
            return set;
        }

        private CombineSetting LoadCombineSettingFromXml(SecurityElement element)
        {
            CombineSetting setting = new CombineSetting {
                outputIcon = StrParser.ParseStr(element.Attribute("OutputIcon"), "").ToLower(),
                combine = StrParser.ParseBool(element.Attribute("Combine"), false)
            };
            setting.maxCombinedTextureSize = StrParser.ParseDecInt(element.Attribute("MaxCombinedTextureSize"), setting.maxCombinedTextureSize);
            setting.textureFormat = StrParser.ParseStr(element.Attribute("TextureFormat"), "");
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "QualitySetting")
                    {
                        setting.qualitySettings.Add(this.LoadQualitySettingFromXml(element2));
                    }
                }
            }
            return setting;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "AssetDescConfig")
            {
                this._iconPath = StrParser.ParseStr(element.Attribute("IconPath"), "");
                this._combineInputPath = StrParser.ParseStr(element.Attribute("CombineInputPath"), "");
                this._combineOutputPath = StrParser.ParseStr(element.Attribute("CombineOutputPath"), "");
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag == "AssetDescSet")
                            {
                                this._assetDescSets.Add(this.LoadAssetDescSetFromXml(element2));
                            }
                            else if (tag == "CombineSetting")
                            {
                                goto Label_00C3;
                            }
                        }
                        continue;
                    Label_00C3:
                        this.combineSettings.Add(this.LoadCombineSettingFromXml(element2));
                    }
                }
            }
        }

        private QualitySetting LoadQualitySettingFromXml(SecurityElement element)
        {
            QualitySetting setting = new QualitySetting();
            setting.qualityLevel = StrParser.ParseDecInt(element.Attribute("QualityLevel"), setting.qualityLevel);
            setting.border = StrParser.ParseStr(element.Attribute("Border"), "");
            return setting;
        }

        [ProtoMember(4, Name="assetDescSets", DataFormat=DataFormat.Default)]
        public List<AssetDescSet> assetDescSets
        {
            get
            {
                return this._assetDescSets;
            }
        }

        public string combineInputPath
        {
            get
            {
                return this._combineInputPath;
            }
            set
            {
                this._combineInputPath = value;
            }
        }

        public string combineOutputPath
        {
            get
            {
                return this._combineOutputPath;
            }
            set
            {
                this._combineOutputPath = value;
            }
        }

        public List<CombineSetting> combineSettings
        {
            get
            {
                return this._combineSettings;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="iconPath", DataFormat=DataFormat.Default), DefaultValue("")]
        public string iconPath
        {
            get
            {
                return this._iconPath;
            }
            set
            {
                this._iconPath = value;
            }
        }

        [ProtoContract(Name="AssetDesc")]
        public class AssetDesc : IExtensible
        {
            private string _desc = "";
            private string _extraDesc = "";
            private string _icon = "";
            private int _id;
            private string _name = "";
            private string _originalIcon = "";
            private string _outputIcon = "";
            private rect _uv;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            public void SetUV(rect uv)
            {
                if (((uv.x == 0f) && (uv.y == 0f)) && ((uv.xMax == 1f) && (uv.yMax == 1f)))
                {
                    this._uv = null;
                }
                else
                {
                    this._uv = uv;
                }
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

            [ProtoMember(4, IsRequired=false, Name="extraDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string extraDesc
            {
                get
                {
                    return this._extraDesc;
                }
                set
                {
                    this._extraDesc = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="icon", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(6, IsRequired=false, Name="originalIcon", DataFormat=DataFormat.Default), DefaultValue("")]
            public string originalIcon
            {
                get
                {
                    return this._originalIcon;
                }
                set
                {
                    this._originalIcon = value;
                }
            }

            [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="outputIcon", DataFormat=DataFormat.Default)]
            public string outputIcon
            {
                get
                {
                    return this._outputIcon;
                }
                set
                {
                    this._outputIcon = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="uv", DataFormat=DataFormat.Default)]
            public rect uv
            {
                get
                {
                    return this._uv;
                }
                set
                {
                    this._uv = value;
                }
            }
        }

        [ProtoContract(Name="AssetDescSet")]
        public class AssetDescSet : IExtensible
        {
            private readonly List<AssetDescConfig.AssetDesc> _assetDescs = new List<AssetDescConfig.AssetDesc>();
            private int _assetType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, Name="assetDescs", DataFormat=DataFormat.Default)]
            public List<AssetDescConfig.AssetDesc> assetDescs
            {
                get
                {
                    return this._assetDescs;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="assetType", DataFormat=DataFormat.TwosComplement)]
            public int assetType
            {
                get
                {
                    return this._assetType;
                }
                set
                {
                    this._assetType = value;
                }
            }
        }

        public class CombineSetting
        {
            private bool _combine;
            private int _maxCombinedTextureSize = 0x200;
            private string _outputIcon = "";
            private readonly List<AssetDescConfig.QualitySetting> _qualitySettings = new List<AssetDescConfig.QualitySetting>();
            private string _textureFormat = "";

            public bool combine
            {
                get
                {
                    return this._combine;
                }
                set
                {
                    this._combine = value;
                }
            }

            public int maxCombinedTextureSize
            {
                get
                {
                    return this._maxCombinedTextureSize;
                }
                set
                {
                    this._maxCombinedTextureSize = value;
                }
            }

            public string outputIcon
            {
                get
                {
                    return this._outputIcon;
                }
                set
                {
                    this._outputIcon = value;
                }
            }

            public List<AssetDescConfig.QualitySetting> qualitySettings
            {
                get
                {
                    return this._qualitySettings;
                }
            }

            public string textureFormat
            {
                get
                {
                    return this._textureFormat;
                }
                set
                {
                    this._textureFormat = value;
                }
            }
        }

        public class QualitySetting
        {
            private string _border = "";
            private int _qualityLevel;

            public string border
            {
                get
                {
                    return this._border;
                }
                set
                {
                    this._border = value;
                }
            }

            public int qualityLevel
            {
                get
                {
                    return this._qualityLevel;
                }
                set
                {
                    this._qualityLevel = value;
                }
            }
        }
    }
}

