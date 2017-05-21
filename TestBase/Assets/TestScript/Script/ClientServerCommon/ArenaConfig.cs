namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="ArenaConfig")]
    public class ArenaConfig : Configuration, IExtensible
    {
        private readonly List<ArenaGrade> _arenaGrades = new List<ArenaGrade>();
        private readonly List<Cost> _combatCosts = new List<Cost>();
        private long _restoreArenaChallengeTime;
        private Strategy _strategy;
        private IExtension extensionObject;

        public ArenaGrade GetArenaGradeById(int arenaGradeId)
        {
            for (int i = 0; i < this.arenaGrades.Count; i++)
            {
                if (this.arenaGrades[i].arenaGradeId == arenaGradeId)
                {
                    return this.arenaGrades[i];
                }
            }
            return null;
        }

        public string GetDescByGradeID(int arenaGradeId)
        {
            for (int i = 0; i < this.arenaGrades.Count; i++)
            {
                if (this.arenaGrades[i].arenaGradeId == arenaGradeId)
                {
                    return this.arenaGrades[i].desc;
                }
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        private ArenaGrade LoadArenaGradeFromXml(SecurityElement element)
        {
            ArenaGrade grade = new ArenaGrade();
            grade.arenaGradeId = StrParser.ParseHexInt(element.Attribute("ArenaGradeId"), grade.arenaGradeId);
            grade.fromLevel = StrParser.ParseDecInt(element.Attribute("FromLevel"), grade.fromLevel);
            grade.keepRandInterval = StrParser.ParseDecInt(element.Attribute("KeepRandInterval"), grade.keepRandInterval);
            grade.desc = StrParser.ParseStr(element.Attribute("Desc"), grade.desc);
            return grade;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "ArenaConfig")
            {
                this._restoreArenaChallengeTime = StrParser.ParseDateTime(element.Attribute("RestoreArenaChallengeTime"));
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag != "CombatCost")
                            {
                                if (tag == "ArenaGrade")
                                {
                                    goto Label_0094;
                                }
                                if (tag == "Strategy")
                                {
                                    goto Label_00A8;
                                }
                            }
                            else
                            {
                                this.combatCosts.Add(Cost.LoadFromXml(element2));
                            }
                        }
                        continue;
                    Label_0094:
                        this.arenaGrades.Add(this.LoadArenaGradeFromXml(element2));
                        continue;
                    Label_00A8:
                        this._strategy = this.LoadRandStrategyFromXml(element2);
                    }
                }
            }
        }

        private Strategy LoadRandStrategyFromXml(SecurityElement element)
        {
            Strategy strategy = new Strategy();
            strategy.title = StrParser.ParseStr(element.Attribute("Title"), strategy.title);
            strategy.desc = StrParser.ParseStr(element.Attribute("Desc"), strategy.desc, true);
            return strategy;
        }

        public DateTime toResetTime(long time)
        {
            return new DateTime(time * 0x2710L);
        }

        [ProtoMember(3, Name="arenaGrades", DataFormat=DataFormat.Default)]
        public List<ArenaGrade> arenaGrades
        {
            get
            {
                return this._arenaGrades;
            }
        }

        [ProtoMember(2, Name="combatCosts", DataFormat=DataFormat.Default)]
        public List<Cost> combatCosts
        {
            get
            {
                return this._combatCosts;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(1, IsRequired=false, Name="restoreArenaChallengeTime", DataFormat=DataFormat.TwosComplement)]
        public long restoreArenaChallengeTime
        {
            get
            {
                return this._restoreArenaChallengeTime;
            }
            set
            {
                this._restoreArenaChallengeTime = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="strategy", DataFormat=DataFormat.Default)]
        public Strategy strategy
        {
            get
            {
                return this._strategy;
            }
            set
            {
                this._strategy = value;
            }
        }

        [ProtoContract(Name="ArenaGrade")]
        public class ArenaGrade : IExtensible
        {
            private int _arenaGradeId;
            private string _desc = "";
            private int _fromLevel;
            private int _keepRandInterval;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="arenaGradeId", DataFormat=DataFormat.TwosComplement)]
            public int arenaGradeId
            {
                get
                {
                    return this._arenaGradeId;
                }
                set
                {
                    this._arenaGradeId = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="fromLevel", DataFormat=DataFormat.TwosComplement)]
            public int fromLevel
            {
                get
                {
                    return this._fromLevel;
                }
                set
                {
                    this._fromLevel = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="keepRandInterval", DataFormat=DataFormat.TwosComplement)]
            public int keepRandInterval
            {
                get
                {
                    return this._keepRandInterval;
                }
                set
                {
                    this._keepRandInterval = value;
                }
            }
        }

        [ProtoContract(Name="Strategy")]
        public class Strategy : IExtensible
        {
            private string _desc = "";
            private string _title = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="desc", DataFormat=DataFormat.Default), DefaultValue("")]
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

            [ProtoMember(1, IsRequired=false, Name="title", DataFormat=DataFormat.Default), DefaultValue("")]
            public string title
            {
                get
                {
                    return this._title;
                }
                set
                {
                    this._title = value;
                }
            }
        }
    }
}

