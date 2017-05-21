namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="PositionConfig")]
    public class PositionConfig : Configuration, IExtensible
    {
        private readonly List<EmBattleAttribute> _emBattleAttributes = new List<EmBattleAttribute>();
        private readonly List<Position> _positions = new List<Position>();
        private Dictionary<int, Position> dic_Positions = new Dictionary<int, Position>();
        private IExtension extensionObject;

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Position position in this._positions)
            {
                if (this.dic_Positions.ContainsKey(position.Id))
                {
                    Logger.Error(base.GetType().Name + " ContainsKey 0x" + position.Id.ToString("X8"), new object[0]);
                }
                else
                {
                    this.dic_Positions.Add(position.Id, position);
                }
            }
        }

        public int GetBattleIndexByBattlePosition(int battlePosition)
        {
            int num = (battlePosition >> 0x10) & 0xffff;
            int num2 = battlePosition & 0xffff;
            return ((num * base.CfgDB.GameConfig.maxColumnInFormation) + num2);
        }

        public EmBattleAttribute GetEmBattleAttributeByType(int type)
        {
            foreach (EmBattleAttribute attribute in this.EmBattleAttributes)
            {
                if (attribute.type == type)
                {
                    return attribute;
                }
            }
            return null;
        }

        public Position GetPositionById(int id)
        {
            if (this.dic_Positions.ContainsKey(id))
            {
                return this.dic_Positions[id];
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _PositionNumType.Initialize();
            _EmBattleType.Initialize();
        }

        private EmBattleAttribute LoadEmBattleAttributeFromXml(SecurityElement element)
        {
            EmBattleAttribute attribute = new EmBattleAttribute {
                type = TypeNameContainer<_EmBattleType>.Parse(element.Attribute("Type"), 0),
                desc = StrParser.ParseStr(element.Attribute("Desc"), "", true)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "PropertyModifier"))
                    {
                        PropertyModifier item = PropertyModifier.LoadFromXml(element2);
                        attribute.modifiers.Add(item);
                    }
                }
            }
            return attribute;
        }

        private void LoadEmBattleAttributeSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "EmBattleAttribute"))
                    {
                        this._emBattleAttributes.Add(this.LoadEmBattleAttributeFromXml(element2));
                    }
                }
            }
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "PositionConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "PositionSet")
                        {
                            this.LoadPositionSetFromXml(element2);
                        }
                        else if (tag == "EmBattleAttributeSet")
                        {
                            goto Label_0064;
                        }
                    }
                    continue;
                Label_0064:
                    this.LoadEmBattleAttributeSetFromXml(element2);
                }
            }
        }

        private Position LoadPositionFromXml(SecurityElement element)
        {
            Position position = new Position {
                Id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                OpenLevel = StrParser.ParseDecInt(element.Attribute("OpenLevel"), 0),
                OpenVipLevel = StrParser.ParseDecInt(element.Attribute("OpenVipLevel"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "PositionNum")
                        {
                            PositionNum item = new PositionNum {
                                Level = StrParser.ParseDecInt(element2.Attribute("Level"), 0),
                                OpenNum = StrParser.ParseDecInt(element2.Attribute("OpenNum"), 0)
                            };
                            position.PositionNums.Add(item);
                        }
                        else if (tag == "Cost")
                        {
                            goto Label_00DE;
                        }
                    }
                    continue;
                Label_00DE:
                    position.Costs.Add(Cost.LoadFromXml(element2));
                }
            }
            return position;
        }

        private void LoadPositionSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Position"))
                    {
                        this._positions.Add(this.LoadPositionFromXml(element2));
                    }
                }
            }
        }

        [ProtoMember(2, Name="emBattleAttributes", DataFormat=DataFormat.Default)]
        public List<EmBattleAttribute> EmBattleAttributes
        {
            get
            {
                return this._emBattleAttributes;
            }
        }

        [ProtoMember(1, Name="positions", DataFormat=DataFormat.Default)]
        public List<Position> Positions
        {
            get
            {
                return this._positions;
            }
        }

        public class _EmBattleType : TypeNameContainer<PositionConfig._EmBattleType>
        {
            public const int All = -1;
            public const int Back = 2;
            public const int Front = 1;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<PositionConfig._EmBattleType>.RegisterType("Front", 1, "EmBattle_Front");
                flag &= TypeNameContainer<PositionConfig._EmBattleType>.RegisterType("Back", 2, "EmBattle_Back");
                return (flag & TypeNameContainer<PositionConfig._EmBattleType>.RegisterType("All", -1, "EmBattle_All"));
            }
        }

        public class _PositionNumType : TypeNameContainer<PositionConfig._PositionNumType>
        {
            public const int Avatar = 1;
            public const int CheerAvatar = 3;
            public const int Recruit = 2;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<PositionConfig._PositionNumType>.RegisterType("Avatar", 1);
                flag &= TypeNameContainer<PositionConfig._PositionNumType>.RegisterType("Recruit", 2);
                return (flag & TypeNameContainer<PositionConfig._PositionNumType>.RegisterType("CheerAvatar", 3));
            }
        }

        [ProtoContract(Name="Position")]
        public class Position : IExtensible
        {
            private readonly List<Cost> _costs = new List<Cost>();
            private int _id;
            private int _openLevel;
            private int _openVipLevel;
            private readonly List<PositionConfig.PositionNum> _positionNums = new List<PositionConfig.PositionNum>();
            private IExtension extensionObject;

            public List<PositionConfig.PositionNum> GetAvatarSlot()
            {
                List<PositionConfig.PositionNum> list = new List<PositionConfig.PositionNum>();
                for (int i = 0; i < this.PositionNums.Count; i++)
                {
                    list.Add(this.PositionNums[i]);
                }
                return list;
            }

            public int GetAvatarSlotCountByLevel(int playerLevel)
            {
                int num = 1;
                for (int i = 0; i < this.PositionNums.Count; i++)
                {
                    PositionConfig.PositionNum num3 = this.PositionNums[i];
                    if (playerLevel >= num3.Level)
                    {
                        num = (num < num3.OpenNum) ? num3.OpenNum : num;
                    }
                }
                return num;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> Costs
            {
                get
                {
                    return this._costs;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="openLevel", DataFormat=DataFormat.TwosComplement)]
            public int OpenLevel
            {
                get
                {
                    return this._openLevel;
                }
                set
                {
                    this._openLevel = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="openVipLevel", DataFormat=DataFormat.TwosComplement)]
            public int OpenVipLevel
            {
                get
                {
                    return this._openVipLevel;
                }
                set
                {
                    this._openVipLevel = value;
                }
            }

            [ProtoMember(4, Name="positionNums", DataFormat=DataFormat.Default)]
            public List<PositionConfig.PositionNum> PositionNums
            {
                get
                {
                    return this._positionNums;
                }
            }
        }

        [ProtoContract(Name="PositionNum")]
        public class PositionNum : IExtensible
        {
            private int _level;
            private int _openNum;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Level
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

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="openNum", DataFormat=DataFormat.TwosComplement)]
            public int OpenNum
            {
                get
                {
                    return this._openNum;
                }
                set
                {
                    this._openNum = value;
                }
            }
        }
    }
}

