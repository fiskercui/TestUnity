namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="TargetCondition")]
    public class TargetCondition : IExtensible
    {
        private bool _boolValue;
        private double _doubleValue;
        private double _doubleValue1;
        private readonly List<int> _enumList = new List<int>();
        private int _intValue;
        private int _intValue1;
        private string _stringValue = "";
        private int _type;
        private IExtension extensionObject;

        public static int CompareTargetCondition(TargetCondition c1, TargetCondition c2)
        {
            return (c1.type - c2.type);
        }

        public static TargetCondition CopyFrom(TargetCondition other)
        {
            TargetCondition condition = new TargetCondition {
                boolValue = other.boolValue,
                doubleValue = other.doubleValue
            };
            condition.enumList.AddRange(other.enumList);
            condition.intValue = other.intValue;
            condition.intValue1 = other.intValue1;
            condition.type = other.type;
            condition.stringValue = other.stringValue;
            return condition;
        }

        public void EnumListAddValue(int val)
        {
            if (!this.enumList.Contains(val))
            {
                this.enumList.Add(val);
            }
        }

        public override bool Equals(object obj)
        {
            Predicate<int> match = null;
            if (obj is TargetCondition)
            {
                TargetCondition tc = obj as TargetCondition;
                if ((((tc.type == this.type) && (tc.intValue == this.intValue)) && ((tc.intValue1 == this.intValue1) && (tc.doubleValue == this.doubleValue))) && (((tc.boolValue == this.boolValue) && (tc.stringValue == this.stringValue)) && (tc.enumList.Count == this.enumList.Count)))
                {
                    if (match == null)
                    {
                        match = n => this.enumList.Contains(n);
                    }
                    if (tc.enumList.TrueForAll(match))
                    {
                        return this.enumList.TrueForAll(n => tc.enumList.Contains(n));
                    }
                }
            }
            return false;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public bool IsEnumContained(int val)
        {
            return this.enumList.Contains(val);
        }

        public static TargetCondition LoadFromXml(SecurityElement element)
        {
            int num = TypeNameContainer<_Type>.Parse(element.Attribute("Type"), 0);
            if (num == 0)
            {
                return null;
            }
            TargetCondition condition = new TargetCondition {
                type = num
            };
            switch (num)
            {
                case 1:
                case 2:
                case 3:
                    condition.intValue = TypeNameContainer<_SubType>.Parse(element.Text, 0);
                    return condition;

                case 4:
                case 5:
                case 0x10:
                case 0x11:
                    return condition;

                case 6:
                    condition.stringValue = StrParser.ParseStr(element.Text, condition.stringValue);
                    condition.intValue = TypeNameContainer<_ConditionValueCompareType>.Parse(element.Attribute("Compare"), condition.intValue);
                    condition.doubleValue = StrParser.ParseDouble(element.Attribute("CompareValue"), condition.doubleValue);
                    return condition;

                case 7:
                case 8:
                    condition.boolValue = StrParser.ParseBool(element.Attribute("SingleRowColumn"), false);
                    condition.intValue = TypeNameContainer<_SubType>.Parse(element.Text, 0);
                    return condition;

                case 9:
                    condition.intValue = StrParser.ParseDecInt(element.Text, 0);
                    return condition;

                case 10:
                    condition.intValue = TypeNameContainer<_SubType>.Parse(element.Text, 0);
                    condition.intValue1 = TypeNameContainer<_AvatarAttributeType>.Parse(element.Attribute("AttributeType"), 0);
                    condition.boolValue = StrParser.ParseBool(element.Attribute("AscendingSort"), true);
                    return condition;

                case 11:
                    condition.intValue = TypeNameContainer<AvatarConfig._AvatarCountryType>.ParseBitList(element.Text, 0);
                    return condition;

                case 12:
                {
                    string[] strArray = element.Text.Split(new char[] { ',' });
                    condition.intValue = StrParser.ParseDecInt(strArray[0], 1);
                    condition.intValue1 = StrParser.ParseDecInt(strArray[1], 1);
                    return condition;
                }
                case 13:
                    condition.intValue = TypeNameContainer<AvatarConfig._CharacterType>.Parse(element.Text, 0);
                    return condition;

                case 14:
                    condition.intValue = StrParser.ParseHexInt(element.Text, 0);
                    return condition;

                case 15:
                    condition.enumList.AddRange(TypeNameContainer<CombatTurn._Type>.ParseList(element.Text, 0));
                    return condition;

                case 0x12:
                    condition.intValue = TypeNameContainer<ClientServerCommon.Buff._BuffType>.Parse(element.Attribute("BuffType"), 0);
                    condition.intValue1 = StrParser.ParseHexInt(element.Attribute("BuffId"), 0);
                    return condition;

                case 0x13:
                    condition.stringValue = StrParser.ParseStr(element.Text, condition.stringValue);
                    condition.intValue = TypeNameContainer<_ConditionValueCompareType>.Parse(element.Attribute("Compare"), 0);
                    condition.doubleValue = StrParser.ParseDouble(element.Attribute("CompareValue"), 0.0);
                    condition.intValue1 = TypeNameContainer<_ConditionValueCompareType>.Parse(element.Attribute("CountCompare"), 0);
                    condition.doubleValue1 = StrParser.ParseDouble(element.Attribute("CountCompareValue"), 0.0);
                    return condition;

                case 20:
                    condition.intValue = TypeNameContainer<_SubType>.Parse(element.Text, 0);
                    return condition;

                case 0x15:
                    condition.stringValue = StrParser.ParseStr(element.Text, string.Empty);
                    condition.intValue = TypeNameContainer<_ConditionValueCompareType>.Parse(element.Attribute("Compare"), 0);
                    condition.doubleValue = StrParser.ParseDouble(element.Attribute("CompareValue"), 0.0);
                    return condition;

                case 0x16:
                    condition.enumList.AddRange(TypeNameContainer<_SubType>.ParseList(element.Text, 0));
                    return condition;

                case 0x17:
                    condition.intValue = TypeNameContainer<_SubType>.Parse(element.Text, 0);
                    return condition;

                case 0x18:
                    condition.intValue = TypeNameContainer<AvatarAction.Event._Type>.Parse(element.Text, 0);
                    condition.intValue1 = TypeNameContainer<ClientServerCommon.Buff._BuffType>.Parse(element.Attribute("BuffType"), 0);
                    return condition;
            }
            return condition;
        }

        [ProtoMember(4, IsRequired=false, Name="boolValue", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool boolValue
        {
            get
            {
                return this._boolValue;
            }
            set
            {
                this._boolValue = value;
            }
        }

        [DefaultValue((double) 0.0), ProtoMember(6, IsRequired=false, Name="doubleValue", DataFormat=DataFormat.TwosComplement)]
        public double doubleValue
        {
            get
            {
                return this._doubleValue;
            }
            set
            {
                this._doubleValue = value;
            }
        }

        [DefaultValue((double) 0.0), ProtoMember(8, IsRequired=false, Name="doubleValue1", DataFormat=DataFormat.TwosComplement)]
        public double doubleValue1
        {
            get
            {
                return this._doubleValue1;
            }
            set
            {
                this._doubleValue1 = value;
            }
        }

        [ProtoMember(7, Name="enumList", DataFormat=DataFormat.TwosComplement)]
        public List<int> enumList
        {
            get
            {
                return this._enumList;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="intValue", DataFormat=DataFormat.TwosComplement)]
        public int intValue
        {
            get
            {
                return this._intValue;
            }
            set
            {
                this._intValue = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="intValue1", DataFormat=DataFormat.TwosComplement)]
        public int intValue1
        {
            get
            {
                return this._intValue1;
            }
            set
            {
                this._intValue1 = value;
            }
        }

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="stringValue", DataFormat=DataFormat.Default)]
        public string stringValue
        {
            get
            {
                return this._stringValue;
            }
            set
            {
                this._stringValue = value;
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

        public class _SortType : TypeNameContainer<TargetCondition._SortType>
        {
            public const int Ascending = 1;
            public const int Descending = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TargetCondition._SortType>.RegisterType("Ascending", 1);
                return (flag & TypeNameContainer<TargetCondition._SortType>.RegisterType("Descending", 2));
            }
        }

        public class _SubType : TypeNameContainer<TargetCondition._SubType>
        {
            public const int Alive = 5;
            public const int Allies = 2;
            public const int AlliesWithoutSelf = 14;
            public const int Attacker = 0x13;
            public const int AttackerAllies = 20;
            public const int AttackerColumn = 0x17;
            public const int AttackerRow = 0x16;
            public const int AttackerTeemates = 0x15;
            public const int BeforeRoundEnd = 0x2a;
            public const int CompositeSupporter = 0x12;
            public const int CurrentPercentage = 0x11;
            public const int CurrentValue = 15;
            public const int Dead = 4;
            public const int Defender = 0x18;
            public const int DefenderAllies = 0x19;
            public const int DefenderColumn = 0x1c;
            public const int DefenderRow = 0x1b;
            public const int DefenderTeemates = 0x1a;
            public const int Enemy = 1;
            public const int Formation_First = 8;
            public const int Formation_First_Random = 11;
            public const int Formation_Last = 9;
            public const int Formation_Last_Random = 12;
            public const int Formation_Same = 10;
            public const int Formation_Same_Random = 13;
            public const int Invalid = 0;
            public const int Pet = 7;
            public const int Player = 6;
            public const int ReduceValue = 0x10;
            public const int RoundStart = 0x29;
            public const int Self = 3;
            public const int State_BeCritical = 0x2e;
            public const int State_BeDodged = 0x2c;
            public const int State_Critical = 0x2d;
            public const int State_Dodged = 0x2b;
            public const int State_OnBeKilled = 0x31;
            public const int State_OnEnemyBeKilled = 50;
            public const int State_OnKillTarget = 0x30;
            public const int State_OnSkillCasted = 0x34;
            public const int State_OnTeemateBeKilled = 0x2f;
            public const int State_OnWillCastSkill = 0x33;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Enemy", 1);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Allies", 2);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Dead", 4);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Alive", 5);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Self", 3);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Player", 6);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Pet", 7);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Formation_First", 8);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Formation_Last", 9);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Formation_Same", 10);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Formation_First_Random", 11);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Formation_Last_Random", 12);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Formation_Same_Random", 13);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("AlliesWithoutSelf", 14);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("CurrentValue", 15);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("ReduceValue", 0x10);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("CurrentPercentage", 0x11);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("CompositeSupporter", 0x12);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Attacker", 0x13);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("AttackerAllies", 20);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("AtackerTeemates", 0x15);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("AttackerRow", 0x16);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("AttackerColumn", 0x17);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("Defender", 0x18);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("DefenderAllies", 0x19);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("DefenderTeemates", 0x1a);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("DefenderRow", 0x1b);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("DefenderColumn", 0x1c);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("RoundStart", 0x29);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("BeforeRoundEnd", 0x2a);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("State_Dodged", 0x2b);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("State_BeDodged", 0x2c);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("State_Critical", 0x2d);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("State_BeCritical", 0x2e);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("State_OnKillTarget", 0x30);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("State_OnBeKilled", 0x31);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("State_OnTeemateBeKilled", 0x2f);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("State_OnEnemyBeKilled", 50);
                flag &= TypeNameContainer<TargetCondition._SubType>.RegisterType("State_OnWillCastSkill", 0x33);
                return (flag & TypeNameContainer<TargetCondition._SubType>.RegisterType("State_OnSkillCasted", 0x34));
            }
        }

        public class _Type : TypeNameContainer<TargetCondition._Type>
        {
            public const int AliveOrDead = 2;
            public const int Attribute = 10;
            public const int AvatarId = 14;
            public const int AvatarType = 3;
            public const int CharacterType = 13;
            public const int CombatState = 0x16;
            public const int CombatTurnType = 15;
            public const int ContextCountExpression = 0x13;
            public const int ContextExpression = 0x15;
            public const int CountryType = 11;
            public const int EquipStrengthen = 0x10;
            public const int EventType = 0x18;
            public const int Expression = 6;
            public const int FormationColumn = 8;
            public const int FormationRow = 7;
            public const int InterfaceTarget = 20;
            public const int RandomTargetCount = 12;
            public const int Relationship = 1;
            public const int RoundState = 0x17;
            public const int TargetCount = 9;
            public const int Unknown = 0;
            public const int WithBuff = 0x12;
            public const int WithStatus = 5;
            public const int WithWeapon = 4;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("Relationship", 1);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("AliveOrDead", 2);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("AvatarType", 3);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("WithWeapon", 4);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("WithStatus", 5);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("Expression", 6);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("FormationRow", 7);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("FormationColumn", 8);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("TargetCount", 9);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("Attribute", 10);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("CountryType", 11);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("RandomTargetCount", 12);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("CharacterType", 13);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("AvatarId", 14);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("CombatTurnType", 15);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("EquipStrengthen", 0x10);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("WithBuff", 0x12);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("ContextCountExpression", 0x13);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("InterfaceTarget", 20);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("ContextExpression", 0x15);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("CombatState", 0x16);
                flag &= TypeNameContainer<TargetCondition._Type>.RegisterType("RoundState", 0x17);
                return (flag & TypeNameContainer<TargetCondition._Type>.RegisterType("EventType", 0x18));
            }
        }
    }
}

