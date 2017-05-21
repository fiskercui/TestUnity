namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="InitPlayerConfig")]
    public class InitPlayerConfig : Configuration, IExtensible
    {
        private Player _player;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        private Avatar LoadAvatarFromXml(SecurityElement element)
        {
            if (element.Tag != "Avatar")
            {
                return null;
            }
            return new Avatar { 
                resource_id = StrParser.ParseHexInt(element.Attribute("resource_id"), 0),
                level = StrParser.ParseDecInt(element.Attribute("level"), 1),
                experience = StrParser.ParseDecInt(element.Attribute("experience"), 0),
                breakthought_level = StrParser.ParseDecInt(element.Attribute("breakthought_level"), 0)
            };
        }

        private Consumable LoadConsumableFromXml(SecurityElement element)
        {
            return new Consumable { 
                consumable_id = StrParser.ParseHexInt(element.Attribute("consumable_id"), 0),
                amount = StrParser.ParseDecInt(element.Attribute("amount"), 0)
            };
        }

        private Equipment LoadEquipmentFromXml(SecurityElement element)
        {
            return new Equipment { 
                resource_id = StrParser.ParseHexInt(element.Attribute("resource_id"), 0),
                level = StrParser.ParseDecInt(element.Attribute("level"), 0),
                experience = StrParser.ParseDecInt(element.Attribute("experience"), 0),
                breakthought_level = StrParser.ParseDecInt(element.Attribute("breakthought_level"), 0)
            };
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "InitPlayerConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Player"))
                    {
                        this.LoadPlayerFromXml(element2);
                    }
                }
            }
        }

        private void LoadPlayerFromXml(SecurityElement element)
        {
            if (element.Tag == "Player")
            {
                this._player = new Player();
                this._player.player_level = StrParser.ParseDecInt(element.Attribute("player_level"), 1);
                this._player.player_experience = StrParser.ParseDecInt(element.Attribute("player_experience"), 0);
                this._player.game_money = StrParser.ParseDecInt(element.Attribute("game_money"), 0);
                this._player.real_money = StrParser.ParseDecInt(element.Attribute("real_money"), 0);
                this._player.strength_point = StrParser.ParseDecInt(element.Attribute("strength_point"), 0);
                this._player.grade_point = StrParser.ParseDecInt(element.Attribute("grade_point"), 0);
                this._player.vip_level = StrParser.ParseDecInt(element.Attribute("vip_level"), 0);
                this._player.soulCount = StrParser.ParseDecInt(element.Attribute("soul_count"), 0);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        Skill skill;
                        Equipment equipment;
                        Consumable consumable;
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag != "Avatar")
                            {
                                if (tag == "Skill")
                                {
                                    goto Label_018E;
                                }
                                if (tag == "Equipment")
                                {
                                    goto Label_01AC;
                                }
                                if (tag == "Consumable")
                                {
                                    goto Label_01CA;
                                }
                            }
                            else
                            {
                                Avatar item = this.LoadAvatarFromXml(element2);
                                if (item != null)
                                {
                                    this._player.avatars.Add(item);
                                }
                            }
                        }
                        continue;
                    Label_018E:
                        skill = this.LoadSkillFromXml(element2);
                        if (skill != null)
                        {
                            this._player.skills.Add(skill);
                        }
                        continue;
                    Label_01AC:
                        equipment = this.LoadEquipmentFromXml(element2);
                        if (equipment != null)
                        {
                            this._player.equipments.Add(equipment);
                        }
                        continue;
                    Label_01CA:
                        consumable = this.LoadConsumableFromXml(element2);
                        if (consumable != null)
                        {
                            this._player.consumables.Add(consumable);
                        }
                    }
                }
            }
        }

        private Skill LoadSkillFromXml(SecurityElement element)
        {
            return new Skill { 
                resource_id = StrParser.ParseHexInt(element.Attribute("resource_id"), 0),
                level = StrParser.ParseDecInt(element.Attribute("level"), 0),
                experience = StrParser.ParseDecInt(element.Attribute("experience"), 0)
            };
        }

        [DefaultValue((string) null), ProtoMember(1, IsRequired=false, Name="player", DataFormat=DataFormat.Default)]
        public Player player
        {
            get
            {
                return this._player;
            }
            set
            {
                this._player = value;
            }
        }

        [ProtoContract(Name="Avatar")]
        public class Avatar : IExtensible
        {
            private int _battle_position;
            private bool _bind;
            private int _breakthought_level;
            private readonly List<InitPlayerConfig.Equipment> _equipments = new List<InitPlayerConfig.Equipment>();
            private int _experience;
            private InitPlayerConfig.GeniusSkill _geniusSkill;
            private int _level;
            private int _resource_id;
            private readonly List<InitPlayerConfig.Skill> _skills = new List<InitPlayerConfig.Skill>();
            private int _train_attack;
            private int _train_blood;
            private int _train_defence;
            private int _unsaved_attack;
            private int _unsaved_blood;
            private int _unsaved_defence;
            private int _unsigned_attribute_point;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="battle_position", DataFormat=DataFormat.TwosComplement)]
            public int battle_position
            {
                get
                {
                    return this._battle_position;
                }
                set
                {
                    this._battle_position = value;
                }
            }

            [ProtoMember(0x10, IsRequired=false, Name="bind", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool bind
            {
                get
                {
                    return this._bind;
                }
                set
                {
                    this._bind = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="breakthought_level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int breakthought_level
            {
                get
                {
                    return this._breakthought_level;
                }
                set
                {
                    this._breakthought_level = value;
                }
            }

            [ProtoMember(14, Name="equipments", DataFormat=DataFormat.Default)]
            public List<InitPlayerConfig.Equipment> equipments
            {
                get
                {
                    return this._equipments;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="experience", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int experience
            {
                get
                {
                    return this._experience;
                }
                set
                {
                    this._experience = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(15, IsRequired=false, Name="geniusSkill", DataFormat=DataFormat.Default)]
            public InitPlayerConfig.GeniusSkill geniusSkill
            {
                get
                {
                    return this._geniusSkill;
                }
                set
                {
                    this._geniusSkill = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(2, IsRequired=false, Name="resource_id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int resource_id
            {
                get
                {
                    return this._resource_id;
                }
                set
                {
                    this._resource_id = value;
                }
            }

            [ProtoMember(13, Name="skills", DataFormat=DataFormat.Default)]
            public List<InitPlayerConfig.Skill> skills
            {
                get
                {
                    return this._skills;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="train_attack", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int train_attack
            {
                get
                {
                    return this._train_attack;
                }
                set
                {
                    this._train_attack = value;
                }
            }

            [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="train_blood", DataFormat=DataFormat.TwosComplement)]
            public int train_blood
            {
                get
                {
                    return this._train_blood;
                }
                set
                {
                    this._train_blood = value;
                }
            }

            [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="train_defence", DataFormat=DataFormat.TwosComplement)]
            public int train_defence
            {
                get
                {
                    return this._train_defence;
                }
                set
                {
                    this._train_defence = value;
                }
            }

            [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="unsaved_attack", DataFormat=DataFormat.TwosComplement)]
            public int unsaved_attack
            {
                get
                {
                    return this._unsaved_attack;
                }
                set
                {
                    this._unsaved_attack = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="unsaved_blood", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int unsaved_blood
            {
                get
                {
                    return this._unsaved_blood;
                }
                set
                {
                    this._unsaved_blood = value;
                }
            }

            [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="unsaved_defence", DataFormat=DataFormat.TwosComplement)]
            public int unsaved_defence
            {
                get
                {
                    return this._unsaved_defence;
                }
                set
                {
                    this._unsaved_defence = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="unsigned_attribute_point", DataFormat=DataFormat.TwosComplement)]
            public int unsigned_attribute_point
            {
                get
                {
                    return this._unsigned_attribute_point;
                }
                set
                {
                    this._unsigned_attribute_point = value;
                }
            }
        }

        [ProtoContract(Name="Consumable")]
        public class Consumable : IExtensible
        {
            private int _amount;
            private bool _bind;
            private int _consumable_id;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="amount", DataFormat=DataFormat.TwosComplement)]
            public int amount
            {
                get
                {
                    return this._amount;
                }
                set
                {
                    this._amount = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="bind", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool bind
            {
                get
                {
                    return this._bind;
                }
                set
                {
                    this._bind = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="consumable_id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int consumable_id
            {
                get
                {
                    return this._consumable_id;
                }
                set
                {
                    this._consumable_id = value;
                }
            }
        }

        [ProtoContract(Name="Equipment")]
        public class Equipment : IExtensible
        {
            private int _breakthought_level;
            private int _experience;
            private int _level;
            private int _resource_id;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, IsRequired=false, Name="breakthought_level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int breakthought_level
            {
                get
                {
                    return this._breakthought_level;
                }
                set
                {
                    this._breakthought_level = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="experience", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int experience
            {
                get
                {
                    return this._experience;
                }
                set
                {
                    this._experience = value;
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

            [ProtoMember(1, IsRequired=false, Name="resource_id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int resource_id
            {
                get
                {
                    return this._resource_id;
                }
                set
                {
                    this._resource_id = value;
                }
            }
        }

        [ProtoContract(Name="GeniusSkill")]
        public class GeniusSkill : IExtensible
        {
            private int _experience;
            private int _level;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="experience", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int experience
            {
                get
                {
                    return this._experience;
                }
                set
                {
                    this._experience = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoContract(Name="Player")]
        public class Player : IExtensible
        {
            private readonly List<InitPlayerConfig.Avatar> _avatars = new List<InitPlayerConfig.Avatar>();
            private int _badge;
            private readonly List<int> _card_ids = new List<int>();
            private int _challenge_point;
            private int _chatCount;
            private readonly List<InitPlayerConfig.Consumable> _consumables = new List<InitPlayerConfig.Consumable>();
            private readonly List<InitPlayerConfig.Equipment> _equipments = new List<InitPlayerConfig.Equipment>();
            private int _game_money;
            private int _grade_point;
            private int _negong_point;
            private int _player_experience;
            private int _player_level;
            private int _real_money;
            private readonly List<InitPlayerConfig.Skill> _skills = new List<InitPlayerConfig.Skill>();
            private int _soulCount;
            private int _strength_point;
            private int _vip_level;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(14, Name="avatars", DataFormat=DataFormat.Default)]
            public List<InitPlayerConfig.Avatar> avatars
            {
                get
                {
                    return this._avatars;
                }
            }

            [ProtoMember(11, IsRequired=false, Name="badge", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int badge
            {
                get
                {
                    return this._badge;
                }
                set
                {
                    this._badge = value;
                }
            }

            [ProtoMember(10, Name="card_ids", DataFormat=DataFormat.TwosComplement)]
            public List<int> card_ids
            {
                get
                {
                    return this._card_ids;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="challenge_point", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int challenge_point
            {
                get
                {
                    return this._challenge_point;
                }
                set
                {
                    this._challenge_point = value;
                }
            }

            [DefaultValue(0), ProtoMember(13, IsRequired=false, Name="chatCount", DataFormat=DataFormat.TwosComplement)]
            public int chatCount
            {
                get
                {
                    return this._chatCount;
                }
                set
                {
                    this._chatCount = value;
                }
            }

            [ProtoMember(15, Name="consumables", DataFormat=DataFormat.Default)]
            public List<InitPlayerConfig.Consumable> consumables
            {
                get
                {
                    return this._consumables;
                }
            }

            [ProtoMember(0x11, Name="equipments", DataFormat=DataFormat.Default)]
            public List<InitPlayerConfig.Equipment> equipments
            {
                get
                {
                    return this._equipments;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="game_money", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int game_money
            {
                get
                {
                    return this._game_money;
                }
                set
                {
                    this._game_money = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="grade_point", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int grade_point
            {
                get
                {
                    return this._grade_point;
                }
                set
                {
                    this._grade_point = value;
                }
            }

            [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="negong_point", DataFormat=DataFormat.TwosComplement)]
            public int negong_point
            {
                get
                {
                    return this._negong_point;
                }
                set
                {
                    this._negong_point = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="player_experience", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int player_experience
            {
                get
                {
                    return this._player_experience;
                }
                set
                {
                    this._player_experience = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="player_level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int player_level
            {
                get
                {
                    return this._player_level;
                }
                set
                {
                    this._player_level = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="real_money", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int real_money
            {
                get
                {
                    return this._real_money;
                }
                set
                {
                    this._real_money = value;
                }
            }

            [ProtoMember(0x10, Name="skills", DataFormat=DataFormat.Default)]
            public List<InitPlayerConfig.Skill> skills
            {
                get
                {
                    return this._skills;
                }
            }

            [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="soulCount", DataFormat=DataFormat.TwosComplement)]
            public int soulCount
            {
                get
                {
                    return this._soulCount;
                }
                set
                {
                    this._soulCount = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="strength_point", DataFormat=DataFormat.TwosComplement)]
            public int strength_point
            {
                get
                {
                    return this._strength_point;
                }
                set
                {
                    this._strength_point = value;
                }
            }

            [ProtoMember(9, IsRequired=false, Name="vip_level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int vip_level
            {
                get
                {
                    return this._vip_level;
                }
                set
                {
                    this._vip_level = value;
                }
            }
        }

        [ProtoContract(Name="Skill")]
        public class Skill : IExtensible
        {
            private int _experience;
            private int _level;
            private int _resource_id;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="experience", DataFormat=DataFormat.TwosComplement)]
            public int experience
            {
                get
                {
                    return this._experience;
                }
                set
                {
                    this._experience = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="resource_id", DataFormat=DataFormat.TwosComplement)]
            public int resource_id
            {
                get
                {
                    return this._resource_id;
                }
                set
                {
                    this._resource_id = value;
                }
            }
        }
    }
}

