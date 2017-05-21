namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="AvatarAssetConfig")]
    public class AvatarAssetConfig : Configuration, IExtensible
    {
        private string _assetPath = "";
        private readonly List<Avatar> _avatars = new List<Avatar>();
        private readonly List<Part> _commonParts = new List<Part>();
        private Dictionary<int, Avatar> _id_AvatarMap = new Dictionary<int, Avatar>();
        private Dictionary<int, Component> _id_ComponentsMap = new Dictionary<int, Component>();
        private IExtension extensionObject;

        public static int ComponentIdToAvatarTypeId(int id)
        {
            return ((id >> 20) & 15);
        }

        public static int ComponentIdToPartTypeId(int id)
        {
            return ((id >> 0x10) & 15);
        }

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Part part in this._commonParts)
            {
                foreach (Component component in part.components)
                {
                    if (component != null)
                    {
                        if (this._id_ComponentsMap.ContainsKey(component.id))
                        {
                            Logger.Error(base.GetType().Name + " ContainsKey 0x" + component.id.ToString("X"), new object[0]);
                        }
                        else
                        {
                            component.Part = part;
                            this._id_ComponentsMap.Add(component.id, component);
                        }
                    }
                }
            }
            foreach (Avatar avatar in this._avatars)
            {
                if (avatar != null)
                {
                    if (this._id_AvatarMap.ContainsKey(avatar.typeId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + avatar.typeId.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this._id_AvatarMap.Add(avatar.typeId, avatar);
                        foreach (Part part2 in avatar.parts)
                        {
                            part2.Avatar = avatar;
                            foreach (Component component2 in part2.components)
                            {
                                if (component2 != null)
                                {
                                    if (this._id_ComponentsMap.ContainsKey(component2.id))
                                    {
                                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + component2.id.ToString("X"), new object[0]);
                                    }
                                    else
                                    {
                                        component2.Part = part2;
                                        this._id_ComponentsMap.Add(component2.id, component2);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public Avatar GetAvatarById(int typeId)
        {
            foreach (Avatar avatar in this._avatars)
            {
                if (avatar.typeId == typeId)
                {
                    return avatar;
                }
            }
            return null;
        }

        public Component GetComponentById(int id)
        {
            Component component;
            if (!this._id_ComponentsMap.TryGetValue(id, out component))
            {
                return null;
            }
            return component;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _AssembleType.Initialize();
        }

        public static bool IsCommomComponent(int id)
        {
            return (ComponentIdToAvatarTypeId(id) == 0);
        }

        private Avatar LoadAvatarFromXml(SecurityElement element)
        {
            Avatar avatar = new Avatar {
                typeId = StrParser.ParseHexInt(element.Attribute("TypeId"), 0),
                skeleton = StrParser.ParseStr(element.Attribute("Skeleton"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Part")
                    {
                        avatar.parts.Add(this.LoadPartFromXml(element2, avatar));
                    }
                }
            }
            return avatar;
        }

        private void LoadAvatarSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Avatar")
                    {
                        this._avatars.Add(this.LoadAvatarFromXml(element2));
                    }
                }
            }
        }

        private void LoadCommonPartsFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Part")
                    {
                        this._commonParts.Add(this.LoadPartFromXml(element2, null));
                    }
                }
            }
        }

        private Component LoadComponentFromXml(SecurityElement element, Part part)
        {
            return new Component { 
                Part = part,
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                asset = StrParser.ParseStr(element.Attribute("Asset"), "")
            };
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "AvatarAssetConfig")
            {
                this._assetPath = StrParser.ParseStr(element.Attribute("AssetPath"), "");
                if (element != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag == "CommonParts")
                            {
                                this.LoadCommonPartsFromXml(element2);
                            }
                            else if (tag == "AvatarSet")
                            {
                                goto Label_007A;
                            }
                        }
                        continue;
                    Label_007A:
                        this.LoadAvatarSetFromXml(element2);
                    }
                }
            }
        }

        private Part LoadPartFromXml(SecurityElement element, Avatar avatar)
        {
            Part part = new Part {
                Avatar = avatar,
                typeId = StrParser.ParseHexInt(element.Attribute("TypeId"), 0),
                assembleType = TypeNameContainer<_AssembleType>.Parse(element.Attribute("AssembleType"), 0),
                mountMarker = StrParser.ParseStr(element.Attribute("MountMarker"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Component")
                    {
                        part.components.Add(this.LoadComponentFromXml(element2, part));
                    }
                }
            }
            return part;
        }

        [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="assetPath", DataFormat=DataFormat.Default)]
        public string assetPath
        {
            get
            {
                return this._assetPath;
            }
            set
            {
                this._assetPath = value;
            }
        }

        [ProtoMember(3, Name="avatars", DataFormat=DataFormat.Default)]
        public List<Avatar> avatars
        {
            get
            {
                return this._avatars;
            }
        }

        [ProtoMember(2, Name="commonParts", DataFormat=DataFormat.Default)]
        public List<Part> commonParts
        {
            get
            {
                return this._commonParts;
            }
        }

        public class _AssembleType : TypeNameContainer<AvatarAssetConfig._AssembleType>
        {
            public const int Mount = 2;
            public const int Skin = 1;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<AvatarAssetConfig._AssembleType>.RegisterType("Skin", 1);
                return (flag & TypeNameContainer<AvatarAssetConfig._AssembleType>.RegisterType("Mount", 2));
            }
        }

        [ProtoContract(Name="Avatar")]
        public class Avatar : IExtensible
        {
            private readonly List<AvatarAssetConfig.Part> _parts = new List<AvatarAssetConfig.Part>();
            private string _skeleton = "";
            private int _typeId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, Name="parts", DataFormat=DataFormat.Default)]
            public List<AvatarAssetConfig.Part> parts
            {
                get
                {
                    return this._parts;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="skeleton", DataFormat=DataFormat.Default), DefaultValue("")]
            public string skeleton
            {
                get
                {
                    return this._skeleton;
                }
                set
                {
                    this._skeleton = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="typeId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int typeId
            {
                get
                {
                    return this._typeId;
                }
                set
                {
                    this._typeId = value;
                }
            }
        }

        [ProtoContract(Name="Component")]
        public class Component : IExtensible
        {
            private string _asset = "";
            private int _id;
            private ClientServerCommon.AvatarAssetConfig.Part _part;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="asset", DataFormat=DataFormat.Default)]
            public string asset
            {
                get
                {
                    return this._asset;
                }
                set
                {
                    this._asset = value;
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

            public ClientServerCommon.AvatarAssetConfig.Part Part
            {
                get
                {
                    return this._part;
                }
                set
                {
                    this._part = value;
                }
            }
        }

        [ProtoContract(Name="Part")]
        public class Part : IExtensible
        {
            private int _assembleType;
            private ClientServerCommon.AvatarAssetConfig.Avatar _avatar;
            private readonly List<AvatarAssetConfig.Component> _components = new List<AvatarAssetConfig.Component>();
            private string _mountMarker = "";
            private int _typeId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="assembleType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int assembleType
            {
                get
                {
                    return this._assembleType;
                }
                set
                {
                    this._assembleType = value;
                }
            }

            public ClientServerCommon.AvatarAssetConfig.Avatar Avatar
            {
                get
                {
                    return this._avatar;
                }
                set
                {
                    this._avatar = value;
                }
            }

            [ProtoMember(4, Name="components", DataFormat=DataFormat.Default)]
            public List<AvatarAssetConfig.Component> components
            {
                get
                {
                    return this._components;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="mountMarker", DataFormat=DataFormat.Default), DefaultValue("")]
            public string mountMarker
            {
                get
                {
                    return this._mountMarker;
                }
                set
                {
                    this._mountMarker = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="typeId", DataFormat=DataFormat.TwosComplement)]
            public int typeId
            {
                get
                {
                    return this._typeId;
                }
                set
                {
                    this._typeId = value;
                }
            }
        }
    }
}

