namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="SevenElevenGiftConfig")]
    public class SevenElevenGiftConfig : Configuration, IExtensible
    {
        private int _activityId;
        private string _bridefDesc = "";
        private string _minuteDesc = "";
        private readonly List<NumberConvert> _numberConverts = new List<NumberConvert>();
        private readonly List<NumberPosition> _numberPositions = new List<NumberPosition>();
        private readonly List<RewardCounter> _rewardCounters = new List<RewardCounter>();
        private IExtension extensionObject;

        public NumberConvert getNumberConvertByNumber(int number)
        {
            foreach (NumberConvert convert in this._numberConverts)
            {
                if (convert.Number == number)
                {
                    return convert;
                }
            }
            return null;
        }

        public NumberPosition GetnumberPositionByType(int type)
        {
            foreach (NumberPosition position in this._numberPositions)
            {
                if (position.NumberPositionType == type)
                {
                    return position;
                }
            }
            return null;
        }

        public Reward getRewardByConvertNumber(int convertNumber)
        {
            foreach (NumberConvert convert in this._numberConverts)
            {
                if (convert.Number == convertNumber)
                {
                    return convert.Reward;
                }
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public RewardCounter isCounterContainOfPosition(int position)
        {
            foreach (RewardCounter counter in this._rewardCounters)
            {
                if (counter.NumberPositionType == position)
                {
                    return counter;
                }
            }
            return null;
        }

        public int isLuckyCounter(RewardCounter rewardCounter, int counter)
        {
            foreach (NumberMapping mapping in rewardCounter.NumberMappings)
            {
                if (mapping.Counter == counter)
                {
                    return mapping.Number;
                }
            }
            return -1;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "SevenElevenGiftConfig")
            {
                this._activityId = StrParser.ParseHexInt(element.Attribute("ActivityId"), 0);
                this._bridefDesc = StrParser.ParseStr(element.Attribute("BridefDesc"), string.Empty, true);
                this._minuteDesc = StrParser.ParseStr(element.Attribute("MinuteDesc"), string.Empty, true);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag != "NumberPosition")
                            {
                                if (tag == "NumberConvert")
                                {
                                    goto Label_00CE;
                                }
                                if (tag == "RewardCounter")
                                {
                                    goto Label_00E2;
                                }
                            }
                            else
                            {
                                this._numberPositions.Add(this.LoadNumberPositionFromXml(element2));
                            }
                        }
                        continue;
                    Label_00CE:
                        this._numberConverts.Add(this.LoadNumberConvertFromXml(element2));
                        continue;
                    Label_00E2:
                        this._rewardCounters.Add(this.LoadRewardCounterFromXml(element2));
                    }
                }
            }
        }

        private NumberConvert LoadNumberConvertFromXml(SecurityElement element)
        {
            NumberConvert convert = new NumberConvert {
                Number = StrParser.ParseDecInt(element.Attribute("Number"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Reward"))
                    {
                        convert.Reward = Reward.LoadFromXml(element2);
                    }
                }
            }
            return convert;
        }

        private NumberMapping LoadNumberMappingFromXml(SecurityElement element)
        {
            return new NumberMapping { 
                Counter = StrParser.ParseDecInt(element.Attribute("Counter"), 0),
                Number = StrParser.ParseDecInt(element.Attribute("Number"), 0)
            };
        }

        private NumberPosition LoadNumberPositionFromXml(SecurityElement element)
        {
            NumberPosition position = new NumberPosition {
                NumberPositionType = TypeNameContainer<_NumberPositionType>.Parse(element.Attribute("NumberPositionType"), 0),
                NeedLevel = StrParser.ParseDecInt(element.Attribute("NeedLevel"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "NumberWeight"))
                    {
                        NumberWeight item = new NumberWeight {
                            Number = StrParser.ParseDecInt(element2.Attribute("Number"), 0),
                            Weight = StrParser.ParseDecInt(element2.Attribute("Weight"), 0)
                        };
                        position.NumberWeights.Add(item);
                    }
                }
            }
            return position;
        }

        private RewardCounter LoadRewardCounterFromXml(SecurityElement element)
        {
            RewardCounter counter = new RewardCounter {
                NumberPositionType = TypeNameContainer<_NumberPositionType>.Parse(element.Attribute("NumberPositionType"), 0),
                FunctionOpen = StrParser.ParseBool(element.Attribute("FunctionOpen"), false),
                CounterStartPoint = StrParser.ParseDecInt(element.Attribute("CounterStartPoint"), 0),
                ActiveTimes = StrParser.ParseDecInt(element.Attribute("ActiveTimes"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "NumberMapping"))
                    {
                        counter.NumberMappings.Add(this.LoadNumberMappingFromXml(element2));
                    }
                }
            }
            return counter;
        }

        [ProtoMember(1, IsRequired=false, Name="activityId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int ActivityId
        {
            get
            {
                return this._activityId;
            }
            set
            {
                this._activityId = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="bridefDesc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string BridefDesc
        {
            get
            {
                return this._bridefDesc;
            }
            set
            {
                this._bridefDesc = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="minuteDesc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string MinuteDesc
        {
            get
            {
                return this._minuteDesc;
            }
            set
            {
                this._minuteDesc = value;
            }
        }

        [ProtoMember(3, Name="numberConverts", DataFormat=DataFormat.Default)]
        public List<NumberConvert> NumberConverts
        {
            get
            {
                return this._numberConverts;
            }
        }

        [ProtoMember(2, Name="numberPositions", DataFormat=DataFormat.Default)]
        public List<NumberPosition> NumberPositions
        {
            get
            {
                return this._numberPositions;
            }
        }

        [ProtoMember(6, Name="rewardCounters", DataFormat=DataFormat.Default)]
        public List<RewardCounter> RewardCounters
        {
            get
            {
                return this._rewardCounters;
            }
        }

        [ProtoContract(Name="NumberConvert")]
        public class NumberConvert : IExtensible
        {
            private int _number;
            private ClientServerCommon.Reward _reward;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="number", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Number
            {
                get
                {
                    return this._number;
                }
                set
                {
                    this._number = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="reward", DataFormat=DataFormat.Default)]
            public ClientServerCommon.Reward Reward
            {
                get
                {
                    return this._reward;
                }
                set
                {
                    this._reward = value;
                }
            }
        }

        [ProtoContract(Name="NumberMapping")]
        public class NumberMapping : IExtensible
        {
            private int _counter;
            private int _number;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="counter", DataFormat=DataFormat.TwosComplement)]
            public int Counter
            {
                get
                {
                    return this._counter;
                }
                set
                {
                    this._counter = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="number", DataFormat=DataFormat.TwosComplement)]
            public int Number
            {
                get
                {
                    return this._number;
                }
                set
                {
                    this._number = value;
                }
            }
        }

        [ProtoContract(Name="NumberPosition")]
        public class NumberPosition : IExtensible
        {
            private int _needLevel;
            private int _numberPositionType;
            private readonly List<SevenElevenGiftConfig.NumberWeight> _numberWeights = new List<SevenElevenGiftConfig.NumberWeight>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="needLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int NeedLevel
            {
                get
                {
                    return this._needLevel;
                }
                set
                {
                    this._needLevel = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="numberPositionType", DataFormat=DataFormat.TwosComplement)]
            public int NumberPositionType
            {
                get
                {
                    return this._numberPositionType;
                }
                set
                {
                    this._numberPositionType = value;
                }
            }

            [ProtoMember(3, Name="numberWeights", DataFormat=DataFormat.Default)]
            public List<SevenElevenGiftConfig.NumberWeight> NumberWeights
            {
                get
                {
                    return this._numberWeights;
                }
            }
        }

        [ProtoContract(Name="NumberWeight")]
        public class NumberWeight : IExtensible
        {
            private int _number;
            private int _weight;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="number", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Number
            {
                get
                {
                    return this._number;
                }
                set
                {
                    this._number = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="weight", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Weight
            {
                get
                {
                    return this._weight;
                }
                set
                {
                    this._weight = value;
                }
            }
        }

        [ProtoContract(Name="RewardCounter")]
        public class RewardCounter : IExtensible
        {
            private int _activeTimes;
            private int _counterStartPoint;
            private bool _functionOpen;
            private readonly List<SevenElevenGiftConfig.NumberMapping> _numberMappings = new List<SevenElevenGiftConfig.NumberMapping>();
            private int _numberPositionType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="activeTimes", DataFormat=DataFormat.TwosComplement)]
            public int ActiveTimes
            {
                get
                {
                    return this._activeTimes;
                }
                set
                {
                    this._activeTimes = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="counterStartPoint", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CounterStartPoint
            {
                get
                {
                    return this._counterStartPoint;
                }
                set
                {
                    this._counterStartPoint = value;
                }
            }

            [DefaultValue(false), ProtoMember(2, IsRequired=false, Name="functionOpen", DataFormat=DataFormat.Default)]
            public bool FunctionOpen
            {
                get
                {
                    return this._functionOpen;
                }
                set
                {
                    this._functionOpen = value;
                }
            }

            [ProtoMember(5, Name="numberMappings", DataFormat=DataFormat.Default)]
            public List<SevenElevenGiftConfig.NumberMapping> NumberMappings
            {
                get
                {
                    return this._numberMappings;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="numberPositionType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int NumberPositionType
            {
                get
                {
                    return this._numberPositionType;
                }
                set
                {
                    this._numberPositionType = value;
                }
            }
        }
    }
}

