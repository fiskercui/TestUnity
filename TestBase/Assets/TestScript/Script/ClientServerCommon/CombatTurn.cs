namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CombatTurn")]
    public class CombatTurn : IExtensible
    {
        private float _castRate;
        private int _costSkillPower;
        private int _id;
        private readonly List<Stage> _stages = new List<Stage>();
        private int _testType;
        private int _type;
        private IExtension extensionObject;

        public Stage GetStage(int stageType)
        {
            foreach (Stage stage in this._stages)
            {
                if (stage.type == stageType)
                {
                    return stage;
                }
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(6, IsRequired=false, Name="castRate", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float castRate
        {
            get
            {
                return this._castRate;
            }
            set
            {
                this._castRate = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="costSkillPower", DataFormat=DataFormat.TwosComplement)]
        public int costSkillPower
        {
            get
            {
                return this._costSkillPower;
            }
            set
            {
                this._costSkillPower = value;
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

        [ProtoMember(5, Name="stages", DataFormat=DataFormat.Default)]
        public List<Stage> stages
        {
            get
            {
                return this._stages;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="testType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int testType
        {
            get
            {
                return this._testType;
            }
            set
            {
                this._testType = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        public class _TestType : TypeNameContainer<CombatTurn._TestType>
        {
            public const int All = -1;
            public const int Countered = 8;
            public const int CriticalHit = 4;
            public const int Dodged = 2;
            public const int None = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<CombatTurn._TestType>.RegisterType("None", 0);
                flag &= TypeNameContainer<CombatTurn._TestType>.RegisterType("Dodged", 2);
                flag &= TypeNameContainer<CombatTurn._TestType>.RegisterType("CriticalHit", 4);
                flag &= TypeNameContainer<CombatTurn._TestType>.RegisterType("Countered", 8);
                return (flag & TypeNameContainer<CombatTurn._TestType>.RegisterType("All", -1));
            }
        }

        public class _Type : TypeNameContainer<CombatTurn._Type>
        {
            public const int ActiveSkill = 1;
            public const int All = -1;
            public const int CompositeSkill = 7;
            public const int DeathSkill = 4;
            public const int DomineerSkill = 6;
            public const int EnterBattleSkill = 3;
            public const int NormalSkill = 2;
            public const int PassiveSkill = 5;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<CombatTurn._Type>.RegisterType("ActiveSkill", 1);
                flag &= TypeNameContainer<CombatTurn._Type>.RegisterType("NormalSkill", 2);
                flag &= TypeNameContainer<CombatTurn._Type>.RegisterType("EnterBattleSkill", 3);
                flag &= TypeNameContainer<CombatTurn._Type>.RegisterType("DeathSkill", 4);
                flag &= TypeNameContainer<CombatTurn._Type>.RegisterType("PassiveSkill", 5);
                flag &= TypeNameContainer<CombatTurn._Type>.RegisterType("DomineerSkill", 6);
                flag &= TypeNameContainer<CombatTurn._Type>.RegisterType("CompositeSkill", 7);
                return (flag & TypeNameContainer<CombatTurn._Type>.RegisterType("All", -1));
            }
        }

        [ProtoContract(Name="Stage")]
        public class Stage : IExtensible
        {
            private int _type;
            private int _value;
            private int _valueType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [ProtoMember(3, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int value
            {
                get
                {
                    return this._value;
                }
                set
                {
                    this._value = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="valueType", DataFormat=DataFormat.TwosComplement)]
            public int valueType
            {
                get
                {
                    return this._valueType;
                }
                set
                {
                    this._valueType = value;
                }
            }

            public class _StageType : TypeNameContainer<CombatTurn.Stage._StageType>
            {
                public const int Awake = 0;
                public const int Back = 4;
                public const int Count = 7;
                public const int Counter = 6;
                public const int End = 5;
                public const int Main = 3;
                public const int Rush = 1;
                public const int Start = 2;

                public static bool Initialize()
                {
                    bool flag = false;
                    flag &= TypeNameContainer<CombatTurn.Stage._StageType>.RegisterType("Awake", 0);
                    flag &= TypeNameContainer<CombatTurn.Stage._StageType>.RegisterType("Rush", 1);
                    flag &= TypeNameContainer<CombatTurn.Stage._StageType>.RegisterType("Start", 2);
                    flag &= TypeNameContainer<CombatTurn.Stage._StageType>.RegisterType("Main", 3);
                    flag &= TypeNameContainer<CombatTurn.Stage._StageType>.RegisterType("Back", 4);
                    return (flag & TypeNameContainer<CombatTurn.Stage._StageType>.RegisterType("End", 5));
                }
            }

            public class _ValueType : TypeNameContainer<CombatTurn.Stage._ValueType>
            {
                public const int ActionId = 1;
                public const int ActionType = 2;
                public const int Unknown = 0;

                public static bool Initialize()
                {
                    bool flag = false;
                    flag &= TypeNameContainer<CombatTurn.Stage._ValueType>.RegisterType("ActionId", 1);
                    return (flag & TypeNameContainer<CombatTurn.Stage._ValueType>.RegisterType("ActionType", 2));
                }
            }
        }
    }
}

