namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="PlotNpcConfig")]
    public class PlotNpcConfig : Configuration, IExtensible
    {
        private readonly List<Npc> _npcs = new List<Npc>();
        private IExtension extensionObject;
        private Dictionary<int, Npc> id_npcMap = new Dictionary<int, Npc>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Npc npc in this._npcs)
            {
                if (npc != null)
                {
                    if (this.id_npcMap.ContainsKey(npc.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + npc.id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_npcMap.Add(npc.id, npc);
                    }
                }
            }
        }

        public Npc GetNpcById(int npcId)
        {
            Npc npc;
            if (!this.id_npcMap.TryGetValue(npcId, out npc))
            {
                return null;
            }
            return npc;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        private Equipment LoadEquipmentFromXml(SecurityElement element)
        {
            return new Equipment { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                level = StrParser.ParseDecInt(element.Attribute("Level"), 1),
                breakthroughLevel = StrParser.ParseDecInt(element.Attribute("BreakthroughLevel"), 0)
            };
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "PlotNpcConfig")
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Npc")
                    {
                        Npc item = this.LoadNpcFromXml(element2);
                        this.npcs.Add(item);
                    }
                }
            }
        }

        private Npc LoadNpcFromXml(SecurityElement element)
        {
            Npc npc = new Npc {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                level = StrParser.ParseDecInt(element.Attribute("Level"), 1),
                avatarId = StrParser.ParseHexInt(element.Attribute("AvatarId"), 0),
                breakthroughLevel = StrParser.ParseDecInt(element.Attribute("BreakthroughLevel"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "NPCNAME")
            };
            npc.evaluation = StrParser.ParseDecInt(element.Attribute("Evaluation"), npc.evaluation);
            npc.avatarDefaultSkillId = StrParser.ParseHexInt(element.Attribute("AvatarDefaultSkillId"), npc.avatarDefaultSkillId);
            npc.avatarDefaultSkillLevel = StrParser.ParseDecInt(element.Attribute("AvatarDefaultSkillLevel"), npc.avatarDefaultSkillLevel);
            npc.breakthroughLevel = StrParser.ParseDecInt(element.Attribute("BreakthroughLevel"), 0);
            npc.scale = StrParser.ParseFloat(element.Attribute("Scale"), 0f);
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "Equipment")
                        {
                            if (tag == "Attribute")
                            {
                                goto Label_017F;
                            }
                            if (tag == "Skill")
                            {
                                goto Label_0192;
                            }
                            if (tag == "ModifierSet")
                            {
                                goto Label_01A6;
                            }
                        }
                        else
                        {
                            npc.equipments.Add(this.LoadEquipmentFromXml(element2));
                        }
                    }
                    continue;
                Label_017F:
                    npc.attribs.Add(ClientServerCommon.Attribute.LoadFromXml(element2));
                    continue;
                Label_0192:
                    npc.skills.Add(this.LoadSkillFromXml(element2));
                    continue;
                Label_01A6:
                    npc.modifierSet = PropertyModifierSet.LoadFromXml(element2);
                }
            }
            return npc;
        }

        private Skill LoadSkillFromXml(SecurityElement element)
        {
            return new Skill { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                level = StrParser.ParseDecInt(element.Attribute("Level"), 0)
            };
        }

        [ProtoMember(1, Name="npcs", DataFormat=DataFormat.Default)]
        public List<Npc> npcs
        {
            get
            {
                return this._npcs;
            }
        }

        [ProtoContract(Name="Equipment")]
        public class Equipment : IExtensible
        {
            private int _breakthroughLevel;
            private int _id;
            private int _level;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="breakthroughLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int breakthroughLevel
            {
                get
                {
                    return this._breakthroughLevel;
                }
                set
                {
                    this._breakthroughLevel = value;
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

            [ProtoMember(2, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int level
            {
                get
                {
                    return this._level;
                }
                set
                {
                    this._level = value;
                }
            }
        }

        [ProtoContract(Name="Npc")]
        public class Npc : IExtensible
        {
            private readonly List<ClientServerCommon.Attribute> _attribs = new List<ClientServerCommon.Attribute>();
            private int _avatarDefaultSkillId;
            private int _avatarDefaultSkillLevel;
            private int _avatarId;
            private int _breakthroughLevel;
            private readonly List<PlotNpcConfig.Equipment> _equipments = new List<PlotNpcConfig.Equipment>();
            private int _evaluation;
            private int _id;
            private int _level;
            private PropertyModifierSet _modifierSet;
            private string _name = "";
            private float _scale;
            private readonly List<PlotNpcConfig.Skill> _skills = new List<PlotNpcConfig.Skill>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(9, Name="attribs", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.Attribute> attribs
            {
                get
                {
                    return this._attribs;
                }
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="avatarDefaultSkillId", DataFormat=DataFormat.TwosComplement)]
            public int avatarDefaultSkillId
            {
                get
                {
                    return this._avatarDefaultSkillId;
                }
                set
                {
                    this._avatarDefaultSkillId = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="avatarDefaultSkillLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int avatarDefaultSkillLevel
            {
                get
                {
                    return this._avatarDefaultSkillLevel;
                }
                set
                {
                    this._avatarDefaultSkillLevel = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="avatarId", DataFormat=DataFormat.TwosComplement)]
            public int avatarId
            {
                get
                {
                    return this._avatarId;
                }
                set
                {
                    this._avatarId = value;
                }
            }

            [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="breakthroughLevel", DataFormat=DataFormat.TwosComplement)]
            public int breakthroughLevel
            {
                get
                {
                    return this._breakthroughLevel;
                }
                set
                {
                    this._breakthroughLevel = value;
                }
            }

            [ProtoMember(8, Name="equipments", DataFormat=DataFormat.Default)]
            public List<PlotNpcConfig.Equipment> equipments
            {
                get
                {
                    return this._equipments;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="evaluation", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int evaluation
            {
                get
                {
                    return this._evaluation;
                }
                set
                {
                    this._evaluation = value;
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

            [ProtoMember(2, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int level
            {
                get
                {
                    return this._level;
                }
                set
                {
                    this._level = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(12, IsRequired=false, Name="modifierSet", DataFormat=DataFormat.Default)]
            public PropertyModifierSet modifierSet
            {
                get
                {
                    return this._modifierSet;
                }
                set
                {
                    this._modifierSet = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="name", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue((float) 0f), ProtoMember(13, IsRequired=false, Name="scale", DataFormat=DataFormat.FixedSize)]
            public float scale
            {
                get
                {
                    return this._scale;
                }
                set
                {
                    this._scale = value;
                }
            }

            [ProtoMember(10, Name="skills", DataFormat=DataFormat.Default)]
            public List<PlotNpcConfig.Skill> skills
            {
                get
                {
                    return this._skills;
                }
            }
        }

        [ProtoContract(Name="Skill")]
        public class Skill : IExtensible
        {
            private int _id;
            private int _level;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [ProtoMember(2, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int level
            {
                get
                {
                    return this._level;
                }
                set
                {
                    this._level = value;
                }
            }
        }
    }
}

