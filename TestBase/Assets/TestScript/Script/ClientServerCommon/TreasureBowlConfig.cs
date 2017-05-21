namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="TreasureBowlConfig")]
    public class TreasureBowlConfig : Configuration, IExtensible
    {
        private int _activityId;
        private readonly List<OneTreasure> _treasureBowlList = new List<OneTreasure>();
        private IExtension extensionObject;
        private Dictionary<int, OneTreasure> treasureBowlMap = new Dictionary<int, OneTreasure>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (OneTreasure treasure in this._treasureBowlList)
            {
                if (!this.treasureBowlMap.ContainsKey(treasure.Index))
                {
                    this.treasureBowlMap.Add(treasure.Index, treasure);
                }
            }
        }

        public int GetActivityId()
        {
            return this.ActivityId;
        }

        public OneTreasure GetOneTreasureById(int index)
        {
            if (this.treasureBowlMap.ContainsKey(index))
            {
                return this.treasureBowlMap[index];
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "TreasureBowlConfig")
            {
                this.ActivityId = StrParser.ParseHexInt(element.Attribute("ActivityId"), 0);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        if (element2.Tag == "OneTreasure")
                        {
                            OneTreasure item = new OneTreasure {
                                Index = StrParser.ParseDecInt(element2.Attribute("Index"), 0),
                                Hours = StrParser.ParseDecInt(element2.Attribute("Hours"), 0),
                                Count = StrParser.ParseDecInt(element2.Attribute("Count"), 0),
                                ExchangeJmpIndex = StrParser.ParseDecInt(element2.Attribute("ExchangeJmpIndex"), 0),
                                NoneExchangeJmpIndex = StrParser.ParseDecInt(element2.Attribute("NoneExchangeJmpIndex"), 0)
                            };
                            foreach (SecurityElement element3 in element2.Children)
                            {
                                if (element3.Tag == "Cost")
                                {
                                    item.Costs.Add(Cost.LoadFromXml(element3));
                                }
                                if (element3.Tag == "Reward")
                                {
                                    item.Reward = Reward.LoadFromXml(element3);
                                }
                            }
                            this._treasureBowlList.Add(item);
                        }
                    }
                }
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="activityId", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(2, Name="treasureBowlList", DataFormat=DataFormat.Default)]
        public List<OneTreasure> TreasureBowlList
        {
            get
            {
                return this._treasureBowlList;
            }
        }

        [ProtoContract(Name="OneTreasure")]
        public class OneTreasure : IExtensible
        {
            private readonly List<Cost> _costs = new List<Cost>();
            private int _count;
            private int _exchangeJmpIndex;
            private int _hours;
            private int _index;
            private int _noneExchangeJmpIndex;
            private ClientServerCommon.Reward _reward;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(6, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> Costs
            {
                get
                {
                    return this._costs;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
            public int Count
            {
                get
                {
                    return this._count;
                }
                set
                {
                    this._count = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="exchangeJmpIndex", DataFormat=DataFormat.TwosComplement)]
            public int ExchangeJmpIndex
            {
                get
                {
                    return this._exchangeJmpIndex;
                }
                set
                {
                    this._exchangeJmpIndex = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="hours", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Hours
            {
                get
                {
                    return this._hours;
                }
                set
                {
                    this._hours = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement)]
            public int Index
            {
                get
                {
                    return this._index;
                }
                set
                {
                    this._index = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="noneExchangeJmpIndex", DataFormat=DataFormat.TwosComplement)]
            public int NoneExchangeJmpIndex
            {
                get
                {
                    return this._noneExchangeJmpIndex;
                }
                set
                {
                    this._noneExchangeJmpIndex = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="reward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
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
    }
}

