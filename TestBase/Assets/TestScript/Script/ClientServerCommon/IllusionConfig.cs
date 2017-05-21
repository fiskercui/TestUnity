namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="IllusionConfig")]
    public class IllusionConfig : Configuration, IExtensible
    {
        private readonly List<IllusionAvatar> _illusionAvatars = new List<IllusionAvatar>();
        private readonly List<IllusionMode> _illusionModes = new List<IllusionMode>();
        private readonly List<Illusion> _illusions = new List<Illusion>();
        private readonly List<ClientServerCommon.MainType> _mainTypes = new List<ClientServerCommon.MainType>();
        private IExtension extensionObject;

        public IllusionAvatar GetIllusionAvatarByAvatarId(int recourseId)
        {
            foreach (IllusionAvatar avatar in this._illusionAvatars)
            {
                if (avatar.RecourseId == recourseId)
                {
                    return avatar;
                }
            }
            return null;
        }

        public Illusion GetIllusionById(int id)
        {
            foreach (Illusion illusion in this._illusions)
            {
                if (illusion.Id == id)
                {
                    return illusion;
                }
            }
            return null;
        }

        public IllusionMode GetIllusionModeById(int modeId)
        {
            return this._illusionModes.Find(n => n.ModelId == modeId);
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _IllusionRenderIcon.Initialize();
            _UseStatus.Initialize();
            _ActivateType.Initialize();
            _IllusionType.Initialize();
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "IllusionConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "IllusionAvatarSet")
                        {
                            if (tag == "IllusionModeSet")
                            {
                                goto Label_0081;
                            }
                            if (tag == "IllusionSet")
                            {
                                goto Label_008A;
                            }
                            if (tag == "MainTypeSet")
                            {
                                goto Label_0093;
                            }
                        }
                        else
                        {
                            this.LoadIllusionAvatarSetFromXml(element2);
                        }
                    }
                    continue;
                Label_0081:
                    this.LoadIllusionModeSetFromXml(element2);
                    continue;
                Label_008A:
                    this.LoadIllusionSetFromXml(element2);
                    continue;
                Label_0093:
                    this.LoadMainTypeSetFromXml(element2);
                }
            }
        }

        private IllusionAvatar LoadIllusionAvatarFromXml(SecurityElement element)
        {
            IllusionAvatar avatar = new IllusionAvatar {
                RecourseId = StrParser.ParseHexInt(element.Attribute("RecourseId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Illusion"))
                    {
                        avatar.IllusionIds.Add(StrParser.ParseHexInt(element2.Attribute("IllusionId"), 0));
                    }
                }
            }
            return avatar;
        }

        private void LoadIllusionAvatarSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "IllusionAvatar"))
                    {
                        this.IllusionAvatars.Add(this.LoadIllusionAvatarFromXml(element2));
                    }
                }
            }
        }

        private Illusion LoadIllusionFromXml(SecurityElement element)
        {
            Illusion illusion = new Illusion {
                Id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                ContinueTime = StrParser.ParseDecInt(element.Attribute("ContinueTime"), 0),
                ModelId = StrParser.ParseHexInt(element.Attribute("ModelId"), 0),
                GetWay = StrParser.ParseStr(element.Attribute("GetWay"), ""),
                ModifierSetDesc = StrParser.ParseStr(element.Attribute("ModifierSetDesc"), "", true),
                SortIndex = StrParser.ParseDecInt(element.Attribute("SortIndex"), 0),
                IllusionPower = StrParser.ParseFloat(element.Attribute("IllusionPower"), 0f)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    PropertyModifier modifier;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "Cost")
                        {
                            if (tag == "PropertyModifier")
                            {
                                goto Label_011E;
                            }
                            if (tag == "DanAttributeId")
                            {
                                goto Label_0133;
                            }
                        }
                        else
                        {
                            illusion.ActivateCost = Cost.LoadFromXml(element2);
                        }
                    }
                    continue;
                Label_011E:
                    modifier = PropertyModifier.LoadFromXml(element2);
                    illusion.IllusionModifers.Add(modifier);
                    continue;
                Label_0133:
                    illusion.DanAttributeIds.Add(StrParser.ParseHexInt(element2.Text, 0));
                }
            }
            return illusion;
        }

        private IllusionMode LoadIllusionModeFromXml(SecurityElement element)
        {
            return new IllusionMode { 
                ModelId = StrParser.ParseHexInt(element.Attribute("ModelId"), 0),
                WeaponId1 = StrParser.ParseHexInt(element.Attribute("WeaponId1"), 0),
                BoneName1 = StrParser.ParseStr(element.Attribute("BoneName1"), ""),
                WeaponId2 = StrParser.ParseHexInt(element.Attribute("WeaponId2"), 0),
                BoneName2 = StrParser.ParseStr(element.Attribute("BoneName2"), "")
            };
        }

        private void LoadIllusionModeSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "IllusionMode"))
                    {
                        this.IllusionModes.Add(this.LoadIllusionModeFromXml(element2));
                    }
                }
            }
        }

        private void LoadIllusionSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Illusion"))
                    {
                        this.Illusions.Add(this.LoadIllusionFromXml(element2));
                    }
                }
            }
        }

        private ClientServerCommon.MainType LoadMainTypeFromXml(SecurityElement element)
        {
            ClientServerCommon.MainType type = new ClientServerCommon.MainType {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    ClientServerCommon.SubType item = this.LoadSubTypeFromXml(element2);
                    if (item != null)
                    {
                        type.subTypes.Add(item);
                    }
                }
            }
            return type;
        }

        private void LoadMainTypeSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "MainType")
                    {
                        this._mainTypes.Add(this.LoadMainTypeFromXml(element2));
                    }
                }
            }
        }

        private ClientServerCommon.SubType LoadSubTypeFromXml(SecurityElement element)
        {
            return new ClientServerCommon.SubType { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true),
                desc = StrParser.ParseStr(element.Attribute("Desc"), "", true),
                assetIconId = StrParser.ParseHexInt(element.Attribute("AssetIconId"), 0),
                assetIconType = TypeNameContainer<_IllusionRenderIcon>.Parse(element.Attribute("AssetIconType"), 0)
            };
        }

        [ProtoMember(1, Name="illusionAvatars", DataFormat=DataFormat.Default)]
        public List<IllusionAvatar> IllusionAvatars
        {
            get
            {
                return this._illusionAvatars;
            }
        }

        [ProtoMember(2, Name="illusionModes", DataFormat=DataFormat.Default)]
        public List<IllusionMode> IllusionModes
        {
            get
            {
                return this._illusionModes;
            }
        }

        [ProtoMember(3, Name="illusions", DataFormat=DataFormat.Default)]
        public List<Illusion> Illusions
        {
            get
            {
                return this._illusions;
            }
        }

        [ProtoMember(4, Name="mainTypes", DataFormat=DataFormat.Default)]
        public List<ClientServerCommon.MainType> MainTypes
        {
            get
            {
                return this._mainTypes;
            }
        }

        public class _ActivateType : TypeNameContainer<IllusionConfig._ActivateType>
        {
            public const int Activate = 1;
            public const int Renew = 2;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<IllusionConfig._ActivateType>.RegisterType("Activate", 1, "Activate");
                return (flag & TypeNameContainer<IllusionConfig._ActivateType>.RegisterType("Renew", 2, "Renew"));
            }
        }

        public class _IllusionRenderIcon : TypeNameContainer<IllusionConfig._IllusionRenderIcon>
        {
            public const int RenderLevel = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                return (flag & TypeNameContainer<IllusionConfig._IllusionRenderIcon>.RegisterType("RenderLevel", 1, "RenderLevel"));
            }
        }

        public class _IllusionType : TypeNameContainer<IllusionConfig._IllusionType>
        {
            public const int CancelIllusion = 2;
            public const int Illusion = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<IllusionConfig._IllusionType>.RegisterType("Illusion", 1, "Illusion");
                return (flag & TypeNameContainer<IllusionConfig._IllusionType>.RegisterType("CancelIllusion", 2, "CancelIllusion"));
            }
        }

        public class _UseStatus : TypeNameContainer<IllusionConfig._UseStatus>
        {
            public const int Unknow = 0;
            public const int UnUse = 1;
            public const int UseAll = 2;
            public const int UseAttr = 4;
            public const int UseFacade = 3;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<IllusionConfig._UseStatus>.RegisterType("UnUse", 1, "UnUse");
                flag &= TypeNameContainer<IllusionConfig._UseStatus>.RegisterType("UseAll", 2, "UseAll");
                flag &= TypeNameContainer<IllusionConfig._UseStatus>.RegisterType("UseFacade", 3, "UseFacade");
                return (flag & TypeNameContainer<IllusionConfig._UseStatus>.RegisterType("UseAttr", 4, "UseAttr"));
            }
        }

        [ProtoContract(Name="Illusion")]
        public class Illusion : IExtensible
        {
            private Cost _activateCost;
            private int _continueTime;
            private readonly List<int> _DanAttributeIds = new List<int>();
            private string _getWay = "";
            private int _id;
            private readonly List<PropertyModifier> _illusionModifers = new List<PropertyModifier>();
            private float _illusionPower;
            private int _modelId;
            private string _modifierSetDesc = "";
            private int _sortIndex;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="activateCost", DataFormat=DataFormat.Default)]
            public Cost ActivateCost
            {
                get
                {
                    return this._activateCost;
                }
                set
                {
                    this._activateCost = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="continueTime", DataFormat=DataFormat.TwosComplement)]
            public int ContinueTime
            {
                get
                {
                    return this._continueTime;
                }
                set
                {
                    this._continueTime = value;
                }
            }

            [ProtoMember(8, Name="DanAttributeIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> DanAttributeIds
            {
                get
                {
                    return this._DanAttributeIds;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="getWay", DataFormat=DataFormat.Default), DefaultValue("")]
            public string GetWay
            {
                get
                {
                    return this._getWay;
                }
                set
                {
                    this._getWay = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
            public int Id
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

            [ProtoMember(7, Name="illusionModifers", DataFormat=DataFormat.Default)]
            public List<PropertyModifier> IllusionModifers
            {
                get
                {
                    return this._illusionModifers;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(10, IsRequired=false, Name="illusionPower", DataFormat=DataFormat.FixedSize)]
            public float IllusionPower
            {
                get
                {
                    return this._illusionPower;
                }
                set
                {
                    this._illusionPower = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="modelId", DataFormat=DataFormat.TwosComplement)]
            public int ModelId
            {
                get
                {
                    return this._modelId;
                }
                set
                {
                    this._modelId = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="modifierSetDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string ModifierSetDesc
            {
                get
                {
                    return this._modifierSetDesc;
                }
                set
                {
                    this._modifierSetDesc = value;
                }
            }

            [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="sortIndex", DataFormat=DataFormat.TwosComplement)]
            public int SortIndex
            {
                get
                {
                    return this._sortIndex;
                }
                set
                {
                    this._sortIndex = value;
                }
            }
        }

        [ProtoContract(Name="IllusionAvatar")]
        public class IllusionAvatar : IExtensible
        {
            private readonly List<int> _illusionIds = new List<int>();
            private int _recourseId;
            private IExtension extensionObject;

            public bool ContainIllusion(int illusionId)
            {
                foreach (int num in this._illusionIds)
                {
                    if (num == illusionId)
                    {
                        return true;
                    }
                }
                return false;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="illusionIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> IllusionIds
            {
                get
                {
                    return this._illusionIds;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="recourseId", DataFormat=DataFormat.TwosComplement)]
            public int RecourseId
            {
                get
                {
                    return this._recourseId;
                }
                set
                {
                    this._recourseId = value;
                }
            }
        }

        [ProtoContract(Name="IllusionMode")]
        public class IllusionMode : IExtensible
        {
            private string _boneName1 = "";
            private string _boneName2 = "";
            private int _modelId;
            private int _weaponId1;
            private int _weaponId2;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="boneName1", DataFormat=DataFormat.Default)]
            public string BoneName1
            {
                get
                {
                    return this._boneName1;
                }
                set
                {
                    this._boneName1 = value;
                }
            }

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="boneName2", DataFormat=DataFormat.Default)]
            public string BoneName2
            {
                get
                {
                    return this._boneName2;
                }
                set
                {
                    this._boneName2 = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="modelId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ModelId
            {
                get
                {
                    return this._modelId;
                }
                set
                {
                    this._modelId = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="weaponId1", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int WeaponId1
            {
                get
                {
                    return this._weaponId1;
                }
                set
                {
                    this._weaponId1 = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="weaponId2", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int WeaponId2
            {
                get
                {
                    return this._weaponId2;
                }
                set
                {
                    this._weaponId2 = value;
                }
            }
        }
    }
}

