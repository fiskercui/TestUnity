namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CombatAvatarData")]
    public class CombatAvatarData : IExtensible
    {
        private readonly List<com.kodgames.corgi.protocol.Attribute> _attributes = new List<com.kodgames.corgi.protocol.Attribute>();
        private int _avatarType;
        private int _battlePosition;
        private int _breakThrough;
        private readonly List<BuffData> _buffs = new List<BuffData>();
        private int _countryType;
        private string _displayName = "";
        private readonly List<EquipmentData> _equips = new List<EquipmentData>();
        private int _evaluation;
        private int _illusionId;
        private LevelAttrib _levelAttrib;
        private readonly List<ModifierSet> _modifierSets = new List<ModifierSet>();
        private int _npcId;
        private int _npcType;
        private int _resourceId;
        private float _scale;
        private readonly List<SkillData> _skills = new List<SkillData>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(7, Name="attributes", DataFormat=DataFormat.Default)]
        public List<com.kodgames.corgi.protocol.Attribute> attributes
        {
            get
            {
                return this._attributes;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="avatarType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int avatarType
        {
            get
            {
                return this._avatarType;
            }
            set
            {
                this._avatarType = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="battlePosition", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int battlePosition
        {
            get
            {
                return this._battlePosition;
            }
            set
            {
                this._battlePosition = value;
            }
        }

        [ProtoMember(14, IsRequired=false, Name="breakThrough", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int breakThrough
        {
            get
            {
                return this._breakThrough;
            }
            set
            {
                this._breakThrough = value;
            }
        }

        [ProtoMember(15, Name="buffs", DataFormat=DataFormat.Default)]
        public List<BuffData> buffs
        {
            get
            {
                return this._buffs;
            }
        }

        [ProtoMember(0x10, IsRequired=false, Name="countryType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int countryType
        {
            get
            {
                return this._countryType;
            }
            set
            {
                this._countryType = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="displayName", DataFormat=DataFormat.Default), DefaultValue("")]
        public string displayName
        {
            get
            {
                return this._displayName;
            }
            set
            {
                this._displayName = value;
            }
        }

        [ProtoMember(6, Name="equips", DataFormat=DataFormat.Default)]
        public List<EquipmentData> equips
        {
            get
            {
                return this._equips;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="evaluation", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(0x11, IsRequired=false, Name="illusionId", DataFormat=DataFormat.TwosComplement)]
        public int illusionId
        {
            get
            {
                return this._illusionId;
            }
            set
            {
                this._illusionId = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="levelAttrib", DataFormat=DataFormat.Default)]
        public LevelAttrib levelAttrib
        {
            get
            {
                return this._levelAttrib;
            }
            set
            {
                this._levelAttrib = value;
            }
        }

        [ProtoMember(13, Name="modifierSets", DataFormat=DataFormat.Default)]
        public List<ModifierSet> modifierSets
        {
            get
            {
                return this._modifierSets;
            }
        }

        [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="npcId", DataFormat=DataFormat.TwosComplement)]
        public int npcId
        {
            get
            {
                return this._npcId;
            }
            set
            {
                this._npcId = value;
            }
        }

        [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="npcType", DataFormat=DataFormat.TwosComplement)]
        public int npcType
        {
            get
            {
                return this._npcType;
            }
            set
            {
                this._npcType = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="resourceId", DataFormat=DataFormat.TwosComplement)]
        public int resourceId
        {
            get
            {
                return this._resourceId;
            }
            set
            {
                this._resourceId = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="scale", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
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

        [ProtoMember(8, Name="skills", DataFormat=DataFormat.Default)]
        public List<SkillData> skills
        {
            get
            {
                return this._skills;
            }
        }
    }
}

