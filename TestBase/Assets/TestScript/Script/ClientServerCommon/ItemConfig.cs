namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="ItemConfig")]
    public class ItemConfig : Configuration, IExtensible
    {
        private int _avatarBreakThroughItemId;
        private int _avatarUpDan;
        private int _changeMeridianItemId;
        private int _cheerActiveItemId;
        private int _chestItem;
        private int _domineerItemId;
        private int _equipmentBreakThroughItemId;
        private int _exploreItem;
        private int _illusionStoneId;
        private readonly List<Item> _items = new List<Item>();
        private int _knifeCoin;
        private int _nurseMeridianItemId;
        private int _setGuildNameId;
        private int _setPlayerNameId;
        private int _worldChatItemId;
        private IExtension extensionObject;
        private Dictionary<int, Item> id_itemMap = new Dictionary<int, Item>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Item item in this._items)
            {
                if (item != null)
                {
                    if (this.id_itemMap.ContainsKey(item.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + item.id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_itemMap.Add(item.id, item);
                    }
                }
            }
        }

        public Item GetItemById(int id)
        {
            Item item = null;
            if (!this.id_itemMap.TryGetValue(id, out item))
            {
                Logger.Warn(string.Format("{0} can not find item with id : 0x{1:X}", base.GetType().Name, id), new object[0]);
                return null;
            }
            return item;
        }

        public Item GetItemByType(int type)
        {
            for (int i = 0; i < this._items.Count; i++)
            {
                Item item = this._items[i];
                if (_Type.ToItemType(item.id) == type)
                {
                    return item;
                }
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _Type.Initialize();
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "ItemConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    switch (element2.Tag)
                    {
                        case "Item":
                            this._items.Add(this.LoadItemFromXml(element2));
                            break;

                        case "AvatarBreakThroughItem":
                            this.avatarBreakThroughItemId = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "EquipmentBreakThroughItem":
                            this.equipmentBreakThroughItemId = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "DomineerItem":
                            this.domineerItemId = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "ChangeMeridianItem":
                            this.changeMeridianItemId = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "NurseMeridianItem":
                            this.nurseMeridianItemId = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "WorldChatItem":
                            this.worldChatItemId = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "CheerActiveItem":
                            this.cheerActiveItemId = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "ChestItem":
                            this.chestItem = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "KnifeCoin":
                            this.knifeCoin = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "IllusionStone":
                            this.illusionStoneId = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "AvatarUpDan":
                            this.avatarUpDan = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "ExploreItem":
                            this.exploreItem = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "SetPlayerNameId":
                            this.setPlayerNameId = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;

                        case "SetGuildNameId":
                            this.setGuildNameId = StrParser.ParseHexInt(element2.Attribute("Id"), 0);
                            break;
                    }
                }
            }
        }

        private Group LoadGroupFromXml(SecurityElement element, int defaultIndex)
        {
            Group group = new Group {
                name = StrParser.ParseStr(element.Attribute("Name"), ""),
                desc = StrParser.ParseStr(element.Attribute("Desc"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "ConsumeReward")
                        {
                            group.consumeReward.Add(Reward.LoadFromXml(element2));
                        }
                        else if (tag == "FixReward")
                        {
                            goto Label_009A;
                        }
                    }
                    continue;
                Label_009A:
                    group.fixReward.Add(Reward.LoadFromXml(element2));
                }
            }
            return group;
        }

        private Item LoadItemFromXml(SecurityElement element)
        {
            Item item = new Item {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                hideInPackage = StrParser.ParseBool(element.Attribute("HideInPackage"), false),
                maxUseCount = StrParser.ParseDecInt(element.Attribute("MaxUseCount"), 0),
                playerLevel = StrParser.ParseDecInt(element.Attribute("PlayerLevel"), 0),
                vipLevel = StrParser.ParseDecInt(element.Attribute("VIPLevel"), 0),
                cannotUseTip = StrParser.ParseStr(element.Attribute("CannotUseTip"), ""),
                sortIdx = StrParser.ParseDecInt(element.Attribute("SortIdx"), 0),
                firstOpenRewardGroupId = StrParser.ParseHexInt(element.Attribute("FirstOpenRewardGroupId"), 0),
                normalOpenRewardGroupId = StrParser.ParseHexInt(element.Attribute("NormalOpenRewardGroupId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "FixReward")
                        {
                            if (tag == "RandReward")
                            {
                                goto Label_0157;
                            }
                            if (tag == "ConsumeCost")
                            {
                                goto Label_016A;
                            }
                            if (tag == "Group")
                            {
                                goto Label_017D;
                            }
                        }
                        else
                        {
                            item.fixRewardPreviews.Add(Reward.LoadFromXml(element2));
                        }
                    }
                    continue;
                Label_0157:
                    item.randRewardPreviews.Add(Reward.LoadFromXml(element2));
                    continue;
                Label_016A:
                    item.consumeCost.Add(Cost.LoadFromXml(element2));
                    continue;
                Label_017D:
                    item.consumeRewardGroup.Add(this.LoadGroupFromXml(element2, (item.consumeRewardGroup != null) ? item.consumeRewardGroup.Count : 0));
                }
            }
            return item;
        }

        [ProtoMember(4, IsRequired=false, Name="avatarBreakThroughItemId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int avatarBreakThroughItemId
        {
            get
            {
                return this._avatarBreakThroughItemId;
            }
            set
            {
                this._avatarBreakThroughItemId = value;
            }
        }

        [ProtoMember(14, IsRequired=false, Name="avatarUpDan", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int avatarUpDan
        {
            get
            {
                return this._avatarUpDan;
            }
            set
            {
                this._avatarUpDan = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="changeMeridianItemId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int changeMeridianItemId
        {
            get
            {
                return this._changeMeridianItemId;
            }
            set
            {
                this._changeMeridianItemId = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="cheerActiveItemId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int cheerActiveItemId
        {
            get
            {
                return this._cheerActiveItemId;
            }
            set
            {
                this._cheerActiveItemId = value;
            }
        }

        [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="chestItem", DataFormat=DataFormat.TwosComplement)]
        public int chestItem
        {
            get
            {
                return this._chestItem;
            }
            set
            {
                this._chestItem = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="domineerItemId", DataFormat=DataFormat.TwosComplement)]
        public int domineerItemId
        {
            get
            {
                return this._domineerItemId;
            }
            set
            {
                this._domineerItemId = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="equipmentBreakThroughItemId", DataFormat=DataFormat.TwosComplement)]
        public int equipmentBreakThroughItemId
        {
            get
            {
                return this._equipmentBreakThroughItemId;
            }
            set
            {
                this._equipmentBreakThroughItemId = value;
            }
        }

        [ProtoMember(15, IsRequired=false, Name="exploreItem", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int exploreItem
        {
            get
            {
                return this._exploreItem;
            }
            set
            {
                this._exploreItem = value;
            }
        }

        [DefaultValue(0), ProtoMember(13, IsRequired=false, Name="illusionStoneId", DataFormat=DataFormat.TwosComplement)]
        public int illusionStoneId
        {
            get
            {
                return this._illusionStoneId;
            }
            set
            {
                this._illusionStoneId = value;
            }
        }

        [ProtoMember(1, Name="items", DataFormat=DataFormat.Default)]
        public List<Item> items
        {
            get
            {
                return this._items;
            }
        }

        [ProtoMember(12, IsRequired=false, Name="knifeCoin", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int knifeCoin
        {
            get
            {
                return this._knifeCoin;
            }
            set
            {
                this._knifeCoin = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="nurseMeridianItemId", DataFormat=DataFormat.TwosComplement)]
        public int nurseMeridianItemId
        {
            get
            {
                return this._nurseMeridianItemId;
            }
            set
            {
                this._nurseMeridianItemId = value;
            }
        }

        [ProtoMember(0x11, IsRequired=false, Name="setGuildNameId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int setGuildNameId
        {
            get
            {
                return this._setGuildNameId;
            }
            set
            {
                this._setGuildNameId = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x10, IsRequired=false, Name="setPlayerNameId", DataFormat=DataFormat.TwosComplement)]
        public int setPlayerNameId
        {
            get
            {
                return this._setPlayerNameId;
            }
            set
            {
                this._setPlayerNameId = value;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="worldChatItemId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int worldChatItemId
        {
            get
            {
                return this._worldChatItemId;
            }
            set
            {
                this._worldChatItemId = value;
            }
        }

        public class _Type : TypeNameContainer<ItemConfig._Type>
        {
            public const int AddArenaChallengeTimes = 12;
            public const int AddEnergy = 15;
            public const int AddExp = 10;
            public const int AddGameMoney = 9;
            public const int AddSoul = 11;
            public const int AddStamina = 8;
            public const int AvatarScorll = 7;
            public const int BeastPart = 0x16;
            public const int BeastScroll = 0x15;
            public const int DanAttributeRefreshMaterial = 0x13;
            public const int DanBreakthoughtMaterial = 0x12;
            public const int DanLevelUpMaterial = 0x11;
            public const int EquipScroll = 6;
            public const int Gacha = 3;
            public const int IllusionCostItem = 0x10;
            public const int KeyItem = 5;
            public const int MoveCount = 20;
            public const int Package = 2;
            public const int SecertKey = 14;
            public const int SkillScroll = 4;
            public const int SpecialItem = 1;
            public const int TelFee = 13;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                TypeNameContainer<ItemConfig._Type>.SetTextSectionName("ItemType");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("Package", 2, "Package");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("Gacha", 3, "Gacha");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("SkillScroll", 4, "SkillScroll");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("KeyItem", 5, "KeyItem");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("EquipScroll", 6, "EquipScroll");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("AvatarScorll", 7, "AvatarScorll");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("AddStamina", 8, "AddStamina");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("AddGameMoney", 9, "AddGameMoney");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("AddExp", 10, "AddExp");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("AddSoul", 11, "AddSoul");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("AddArenaChallengeTimes", 12, "AddArenaChallengeTimes");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("TelFee", 13, "TelFee");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("SecertKey", 14, "SecertKey");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("AddEnergy", 15, "AddEnergy");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("IllusionCostItem", 0x10, "IllusionCostItem");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("DanLevelUpMaterial", 0x11, "DanLevelUpMaterial");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("DanBreakthoughtMaterial", 0x12, "DanBreakthoughtMaterial");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("DanAttributeRefreshMaterial", 0x13, "DanAttributeRefreshMaterial");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("MoveCount", 20, "MoveCount");
                flag &= TypeNameContainer<ItemConfig._Type>.RegisterType("BeastScroll", 0x15, "BeastScroll");
                return (flag & TypeNameContainer<ItemConfig._Type>.RegisterType("BeastPart", 0x16, "BeastPart"));
            }

            public static int ToItemType(int id)
            {
                return ((id & 0xff0000) >> 0x10);
            }
        }

        [ProtoContract(Name="Group")]
        public class Group : IExtensible
        {
            private readonly List<Reward> _consumeReward = new List<Reward>();
            private string _desc = "";
            private readonly List<Reward> _fixReward = new List<Reward>();
            private string _name = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, Name="consumeReward", DataFormat=DataFormat.Default)]
            public List<Reward> consumeReward
            {
                get
                {
                    return this._consumeReward;
                }
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

            [ProtoMember(4, Name="fixReward", DataFormat=DataFormat.Default)]
            public List<Reward> fixReward
            {
                get
                {
                    return this._fixReward;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="name", DataFormat=DataFormat.Default), DefaultValue("")]
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
        }

        [ProtoContract(Name="Item")]
        public class Item : IExtensible
        {
            private string _cannotUseTip = "";
            private readonly List<Cost> _consumeCost = new List<Cost>();
            private readonly List<ItemConfig.Group> _consumeRewardGroup = new List<ItemConfig.Group>();
            private int _firstOpenRewardGroupId;
            private readonly List<Reward> _fixRewardPreviews = new List<Reward>();
            private bool _hideInPackage;
            private int _id;
            private int _maxUseCount;
            private int _normalOpenRewardGroupId;
            private int _playerLevel;
            private readonly List<Reward> _randRewardPreviews = new List<Reward>();
            private int _sortIdx;
            private int _vipLevel;
            private IExtension extensionObject;

            public Reward GetConsumeReward(int index)
            {
                return this.GetConsumeReward(0, index);
            }

            public Reward GetConsumeReward(int groupIndex, int index)
            {
                if (((groupIndex >= 0) && (index >= 0)) && ((groupIndex < this._consumeRewardGroup.Count) && (index < this._consumeRewardGroup[groupIndex].consumeReward.Count)))
                {
                    return this._consumeRewardGroup[groupIndex].consumeReward[index];
                }
                return null;
            }

            public int GetConsumeRewardCount()
            {
                return this.GetConsumeRewardCount(0);
            }

            public int GetConsumeRewardCount(int groupIndex)
            {
                if ((groupIndex >= 0) && (groupIndex < this._consumeRewardGroup.Count))
                {
                    return this._consumeRewardGroup[groupIndex].consumeReward.Count;
                }
                return 0;
            }

            public Reward GetFixReward(int index)
            {
                return this.GetFixReward(0, index);
            }

            public Reward GetFixReward(int groupIndex, int index)
            {
                if (((groupIndex >= 0) && (index >= 0)) && ((groupIndex < this._consumeRewardGroup.Count) && (index < this._consumeRewardGroup[groupIndex].fixReward.Count)))
                {
                    return this._consumeRewardGroup[groupIndex].fixReward[index];
                }
                return null;
            }

            public int GetFixRewardCount()
            {
                return this.GetFixRewardCount(0);
            }

            public int GetFixRewardCount(int groupIndex)
            {
                if ((groupIndex >= 0) && (groupIndex < this._consumeRewardGroup.Count))
                {
                    return this._consumeRewardGroup[groupIndex].fixReward.Count;
                }
                return 0;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            public bool HasConsumeReward()
            {
                if ((this._consumeRewardGroup.Count == 0) && (this.firstOpenRewardGroupId == 0))
                {
                    return (this.normalOpenRewardGroupId != 0);
                }
                return true;
            }

            [ProtoMember(6, IsRequired=false, Name="cannotUseTip", DataFormat=DataFormat.Default), DefaultValue("")]
            public string cannotUseTip
            {
                get
                {
                    return this._cannotUseTip;
                }
                set
                {
                    this._cannotUseTip = value;
                }
            }

            [ProtoMember(7, Name="consumeCost", DataFormat=DataFormat.Default)]
            public List<Cost> consumeCost
            {
                get
                {
                    return this._consumeCost;
                }
            }

            [ProtoMember(8, Name="consumeRewardGroup", DataFormat=DataFormat.Default)]
            public List<ItemConfig.Group> consumeRewardGroup
            {
                get
                {
                    return this._consumeRewardGroup;
                }
            }

            [DefaultValue(0), ProtoMember(10, IsRequired=false, Name="firstOpenRewardGroupId", DataFormat=DataFormat.TwosComplement)]
            public int firstOpenRewardGroupId
            {
                get
                {
                    return this._firstOpenRewardGroupId;
                }
                set
                {
                    this._firstOpenRewardGroupId = value;
                }
            }

            [ProtoMember(12, Name="fixRewardPreviews", DataFormat=DataFormat.Default)]
            public List<Reward> fixRewardPreviews
            {
                get
                {
                    return this._fixRewardPreviews;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="hideInPackage", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool hideInPackage
            {
                get
                {
                    return this._hideInPackage;
                }
                set
                {
                    this._hideInPackage = value;
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

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="maxUseCount", DataFormat=DataFormat.TwosComplement)]
            public int maxUseCount
            {
                get
                {
                    return this._maxUseCount;
                }
                set
                {
                    this._maxUseCount = value;
                }
            }

            [ProtoMember(11, IsRequired=false, Name="normalOpenRewardGroupId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int normalOpenRewardGroupId
            {
                get
                {
                    return this._normalOpenRewardGroupId;
                }
                set
                {
                    this._normalOpenRewardGroupId = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int playerLevel
            {
                get
                {
                    return this._playerLevel;
                }
                set
                {
                    this._playerLevel = value;
                }
            }

            [ProtoMember(13, Name="randRewardPreviews", DataFormat=DataFormat.Default)]
            public List<Reward> randRewardPreviews
            {
                get
                {
                    return this._randRewardPreviews;
                }
            }

            [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="sortIdx", DataFormat=DataFormat.TwosComplement)]
            public int sortIdx
            {
                get
                {
                    return this._sortIdx;
                }
                set
                {
                    this._sortIdx = value;
                }
            }

            public int type
            {
                get
                {
                    return ItemConfig._Type.ToItemType(this._id);
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement)]
            public int vipLevel
            {
                get
                {
                    return this._vipLevel;
                }
                set
                {
                    this._vipLevel = value;
                }
            }
        }
    }
}

