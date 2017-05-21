namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="OperationConfig")]
    public class OperationConfig : Configuration, IExtensible
    {
        private Operation _operations;
        private IExtension extensionObject;
        private Dictionary<int, Operation> operationDic = new Dictionary<int, Operation>();
        private Dictionary<int, OperationItem> operationItemDic = new Dictionary<int, OperationItem>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            if (this._operations != null)
            {
                if (this.operationDic.ContainsKey(this._operations.ActivityId))
                {
                    Logger.Error(base.GetType().Name + " ContainsKey 0x" + this._operations.ActivityId.ToString("X"), new object[0]);
                }
                this.operationDic.Add(this._operations.ActivityId, this._operations);
                foreach (OperationInfo info in this._operations.OperationInfos)
                {
                    foreach (OperationItem item in info.OperationItems)
                    {
                        if (item != null)
                        {
                            if (this.operationItemDic.ContainsKey(item.ItemId))
                            {
                                Logger.Error(base.GetType().Name + " ContainsKey 0x" + item.ItemId.ToString("X"), new object[0]);
                            }
                            else
                            {
                                this.operationItemDic.Add(item.ItemId, item);
                            }
                        }
                    }
                }
            }
        }

        public Operation GetOperationActivityById(int operationId)
        {
            if (this._operations.ActivityId == operationId)
            {
                return this._operations;
            }
            return null;
        }

        public List<int> GetOperationActivityIds()
        {
            return new List<int> { this._operations.ActivityId };
        }

        public Operation getOperationById(int id)
        {
            return this.operationDic[id];
        }

        public OperationInfo getOperationInfoByIndex(int id, int index)
        {
            return this.operationDic[id].OperationInfos[index];
        }

        public OperationItem getOperationItemById(int id)
        {
            if (this.operationItemDic.ContainsKey(id))
            {
                return this.operationItemDic[id];
            }
            return null;
        }

        public int GetOperationTypeById(int activityId)
        {
            int operationType = 0;
            if ((this._operations.ActivityId == activityId) && (this._operations.OperationInfos.Count > 0))
            {
                operationType = this._operations.OperationType;
            }
            return operationType;
        }

        public int GetUIByOperationType(int type)
        {
            switch (type)
            {
                case 0:
                    return 0;

                case 1:
                    return 0;

                case 2:
                    return 0x240;

                case 3:
                    return 0;

                case 4:
                    return 0;

                case 5:
                    return 0;

                case 6:
                    return 0;

                case 7:
                    return 0;
            }
            return 0;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _OperationType.Initialize();
        }

        public bool JudgeOperationIdAndGreenType(int activityId, int type)
        {
            bool flag = false;
            int operationTypeById = this.GetOperationTypeById(activityId);
            int num2 = type;
            if ((num2 == -6) && (operationTypeById == 2))
            {
                flag = true;
            }
            return flag;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "OperationConfig")
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Operation")
                    {
                        this._operations = this.LoadOperationFromXml(element2);
                    }
                }
            }
        }

        private Operation LoadOperationFromXml(SecurityElement element)
        {
            Operation operation = new Operation {
                ActivityId = StrParser.ParseHexInt(element.Attribute("ActivityId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "OperationInfo"))
                    {
                        this.LoadOperationInfoFromXml(element2, operation);
                    }
                }
            }
            return operation;
        }

        private void LoadOperationInfoFromXml(SecurityElement element, Operation operation)
        {
            OperationInfo item = new OperationInfo {
                OperationSubIndex = StrParser.ParseDecInt(element.Attribute("OperationSubIndex"), 0),
                OperationName = element.Attribute("OperationName")
            };
            operation.OperationIcon = StrParser.ParseHexInt(element.Attribute("OperationIcon"), 0);
            item.OperationDesc = element.Attribute("OperationDesc");
            operation.Priority = StrParser.ParseDecInt(element.Attribute("Priority"), 0);
            operation.OperationType = TypeNameContainer<_OperationType>.GetTypeByName(element.Attribute("OperationType"));
            item.AbsolutePurchaseStartTime = element.Attribute("AbsolutePurchaseStartTime");
            item.AbsolutePurchaseCloseTime = element.Attribute("AbsolutePurchaseCloseTime");
            item.RelativePurchaseStartTime = element.Attribute("RelativePurchaseStartTime");
            item.RelativePurchaseCloseTime = element.Attribute("RelativePurchaseCloseTime");
            item.AbsolutePickRewardStartTime = element.Attribute("AbsolutePickRewardStartTime");
            item.AbsolutePickRewardCloseTime = element.Attribute("AbsolutePickRewardCloseTime");
            item.RelativePickRewardStartTime = element.Attribute("RelativePickRewardStartTime");
            item.RelativePickRewardCloseTime = element.Attribute("RelativePickRewardCloseTime");
            item.RefreshCycle = StrParser.ParseDecInt(element.Attribute("RefreshCycle"), 0);
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "OperationItem"))
                    {
                        item.OperationItems.Add(this.LoadOperationItemFromXml(element2));
                    }
                }
            }
            operation.OperationInfos.Add(item);
        }

        private OperationItem LoadOperationItemFromXml(SecurityElement element)
        {
            OperationItem item = new OperationItem {
                ItemId = StrParser.ParseHexInt(element.Attribute("ItemId"), 0),
                ItemName = element.Attribute("ItemName"),
                ItemIcon = StrParser.ParseHexInt(element.Attribute("ItemIcon"), 0),
                ItemDesc = element.Attribute("ItemDesc"),
                CompareType = TypeNameContainer<_ConditionValueCompareType>.GetTypeByName(element.Attribute("CompareType")),
                CompareValue = StrParser.ParseDecInt(element.Attribute("CompareValue"), 0),
                CycleMaxCount = StrParser.ParseDecInt(element.Attribute("CycleMaxCount"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Reward"))
                    {
                        item.Rewards.Add(LoadRewardFromXml(element2));
                    }
                }
            }
            return item;
        }

        public static Reward LoadRewardFromXml(SecurityElement element)
        {
            return new Reward { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                level = StrParser.ParseDecInt(element.Attribute("Level"), 1),
                breakthoughtLevel = StrParser.ParseDecInt(element.Attribute("BreakthoughtLevel"), 0),
                count = StrParser.ParseDecInt(element.Attribute("Count"), 0)
            };
        }

        [ProtoMember(1, IsRequired=false, Name="operations", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Operation Operations
        {
            get
            {
                return this._operations;
            }
            set
            {
                this._operations = value;
            }
        }

        public class _OperationType : TypeNameContainer<OperationConfig._OperationType>
        {
            public const int AvatarBreakThroughActivity = 7;
            public const int EquipmentBreakThroughActivity = 6;
            public const int MelaleucaFloorRankActivity = 5;
            public const int PveRankActivity = 4;
            public const int SinglePurchase = 1;
            public const int TotalConsume = 3;
            public const int TotalPurchase = 2;
            public const int UnKnown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<OperationConfig._OperationType>.RegisterType("UnKnown", 0);
                flag &= TypeNameContainer<OperationConfig._OperationType>.RegisterType("SinglePurchase", 1);
                flag &= TypeNameContainer<OperationConfig._OperationType>.RegisterType("TotalPurchase", 2);
                flag &= TypeNameContainer<OperationConfig._OperationType>.RegisterType("TotalConsume", 3);
                flag &= TypeNameContainer<OperationConfig._OperationType>.RegisterType("PveRankActivity", 4);
                flag &= TypeNameContainer<OperationConfig._OperationType>.RegisterType("MelaleucaFloorRankActivity", 5);
                flag &= TypeNameContainer<OperationConfig._OperationType>.RegisterType("EquipmentBreakThroughActivity", 6);
                return (flag & TypeNameContainer<OperationConfig._OperationType>.RegisterType("AvatarBreakThroughActivity", 7));
            }
        }

        [ProtoContract(Name="Operation")]
        public class Operation : IExtensible
        {
            private int _activityId;
            private int _operationIcon;
            private readonly List<OperationConfig.OperationInfo> _operationInfos = new List<OperationConfig.OperationInfo>();
            private int _operationType;
            private int _priority;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

            [ProtoMember(3, IsRequired=false, Name="operationIcon", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int OperationIcon
            {
                get
                {
                    return this._operationIcon;
                }
                set
                {
                    this._operationIcon = value;
                }
            }

            [ProtoMember(2, Name="operationInfos", DataFormat=DataFormat.Default)]
            public List<OperationConfig.OperationInfo> OperationInfos
            {
                get
                {
                    return this._operationInfos;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="operationType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int OperationType
            {
                get
                {
                    return this._operationType;
                }
                set
                {
                    this._operationType = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="priority", DataFormat=DataFormat.TwosComplement)]
            public int Priority
            {
                get
                {
                    return this._priority;
                }
                set
                {
                    this._priority = value;
                }
            }
        }

        [ProtoContract(Name="OperationInfo")]
        public class OperationInfo : IExtensible
        {
            private string _absolutePickRewardCloseTime = "";
            private string _absolutePickRewardStartTime = "";
            private string _absolutePurchaseCloseTime = "";
            private string _absolutePurchaseStartTime = "";
            private string _operationDesc = "";
            private readonly List<OperationConfig.OperationItem> _operationItems = new List<OperationConfig.OperationItem>();
            private string _operationName = "";
            private int _operationSubIndex;
            private int _refreshCycle;
            private string _relativePickRewardCloseTime = "";
            private string _relativePickRewardStartTime = "";
            private string _relativePurchaseCloseTime = "";
            private string _relativePurchaseStartTime = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(9, IsRequired=false, Name="absolutePickRewardCloseTime", DataFormat=DataFormat.Default), DefaultValue("")]
            public string AbsolutePickRewardCloseTime
            {
                get
                {
                    return this._absolutePickRewardCloseTime;
                }
                set
                {
                    this._absolutePickRewardCloseTime = value;
                }
            }

            [DefaultValue(""), ProtoMember(8, IsRequired=false, Name="absolutePickRewardStartTime", DataFormat=DataFormat.Default)]
            public string AbsolutePickRewardStartTime
            {
                get
                {
                    return this._absolutePickRewardStartTime;
                }
                set
                {
                    this._absolutePickRewardStartTime = value;
                }
            }

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="absolutePurchaseCloseTime", DataFormat=DataFormat.Default)]
            public string AbsolutePurchaseCloseTime
            {
                get
                {
                    return this._absolutePurchaseCloseTime;
                }
                set
                {
                    this._absolutePurchaseCloseTime = value;
                }
            }

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="absolutePurchaseStartTime", DataFormat=DataFormat.Default)]
            public string AbsolutePurchaseStartTime
            {
                get
                {
                    return this._absolutePurchaseStartTime;
                }
                set
                {
                    this._absolutePurchaseStartTime = value;
                }
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="operationDesc", DataFormat=DataFormat.Default)]
            public string OperationDesc
            {
                get
                {
                    return this._operationDesc;
                }
                set
                {
                    this._operationDesc = value;
                }
            }

            [ProtoMember(13, Name="operationItems", DataFormat=DataFormat.Default)]
            public List<OperationConfig.OperationItem> OperationItems
            {
                get
                {
                    return this._operationItems;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="operationName", DataFormat=DataFormat.Default)]
            public string OperationName
            {
                get
                {
                    return this._operationName;
                }
                set
                {
                    this._operationName = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="operationSubIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int OperationSubIndex
            {
                get
                {
                    return this._operationSubIndex;
                }
                set
                {
                    this._operationSubIndex = value;
                }
            }

            [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="refreshCycle", DataFormat=DataFormat.TwosComplement)]
            public int RefreshCycle
            {
                get
                {
                    return this._refreshCycle;
                }
                set
                {
                    this._refreshCycle = value;
                }
            }

            [DefaultValue(""), ProtoMember(11, IsRequired=false, Name="relativePickRewardCloseTime", DataFormat=DataFormat.Default)]
            public string RelativePickRewardCloseTime
            {
                get
                {
                    return this._relativePickRewardCloseTime;
                }
                set
                {
                    this._relativePickRewardCloseTime = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="relativePickRewardStartTime", DataFormat=DataFormat.Default), DefaultValue("")]
            public string RelativePickRewardStartTime
            {
                get
                {
                    return this._relativePickRewardStartTime;
                }
                set
                {
                    this._relativePickRewardStartTime = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="relativePurchaseCloseTime", DataFormat=DataFormat.Default), DefaultValue("")]
            public string RelativePurchaseCloseTime
            {
                get
                {
                    return this._relativePurchaseCloseTime;
                }
                set
                {
                    this._relativePurchaseCloseTime = value;
                }
            }

            [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="relativePurchaseStartTime", DataFormat=DataFormat.Default)]
            public string RelativePurchaseStartTime
            {
                get
                {
                    return this._relativePurchaseStartTime;
                }
                set
                {
                    this._relativePurchaseStartTime = value;
                }
            }
        }

        [ProtoContract(Name="OperationItem")]
        public class OperationItem : IExtensible
        {
            private int _compareType;
            private int _compareValue;
            private int _cycleMaxCount;
            private string _itemDesc = "";
            private int _itemIcon;
            private int _itemId;
            private string _itemName = "";
            private readonly List<Reward> _rewards = new List<Reward>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, IsRequired=false, Name="compareType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CompareType
            {
                get
                {
                    return this._compareType;
                }
                set
                {
                    this._compareType = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="compareValue", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CompareValue
            {
                get
                {
                    return this._compareValue;
                }
                set
                {
                    this._compareValue = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="cycleMaxCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CycleMaxCount
            {
                get
                {
                    return this._cycleMaxCount;
                }
                set
                {
                    this._cycleMaxCount = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="itemDesc", DataFormat=DataFormat.Default), DefaultValue("")]
            public string ItemDesc
            {
                get
                {
                    return this._itemDesc;
                }
                set
                {
                    this._itemDesc = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="itemIcon", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ItemIcon
            {
                get
                {
                    return this._itemIcon;
                }
                set
                {
                    this._itemIcon = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="itemId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int ItemId
            {
                get
                {
                    return this._itemId;
                }
                set
                {
                    this._itemId = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="itemName", DataFormat=DataFormat.Default)]
            public string ItemName
            {
                get
                {
                    return this._itemName;
                }
                set
                {
                    this._itemName = value;
                }
            }

            [ProtoMember(8, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> Rewards
            {
                get
                {
                    return this._rewards;
                }
            }
        }
    }
}

