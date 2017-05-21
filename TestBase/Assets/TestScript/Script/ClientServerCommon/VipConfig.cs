namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="VipConfig")]
    public class VipConfig : Configuration, IExtensible
    {
        private int _maxVipLevel;
        private readonly List<Vip> _vipList = new List<Vip>();
        private IExtension extensionObject;
        private Dictionary<int, Vip> id_vipMap = new Dictionary<int, Vip>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Vip vip in this._vipList)
            {
                if (vip != null)
                {
                    if (this.id_vipMap.ContainsKey(vip.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + vip.id.ToString("X"), new object[0]);
                    }
                    else if (vip.vipLimitCount != null)
                    {
                        this.id_vipMap.Add(vip.id, vip);
                    }
                }
            }
        }

        public int GetGoodIdByVipId(int vipId)
        {
            Vip vipById = this.GetVipById(vipId);
            if (vipById == null)
            {
                return 0;
            }
            return vipById.goodId;
        }

        public int GetGoodIdByVipLevel(int vipLevel)
        {
            Vip vipByLevel = this.GetVipByLevel(vipLevel);
            if (vipByLevel == null)
            {
                return 0;
            }
            return vipByLevel.goodId;
        }

        public Vip GetVipById(int id)
        {
            Vip vip = null;
            if (!this.id_vipMap.TryGetValue(id, out vip))
            {
                return null;
            }
            return vip;
        }

        public Vip GetVipByLevel(int level)
        {
            foreach (Vip vip in this.vipList)
            {
                if (vip.level == level)
                {
                    return vip;
                }
            }
            return null;
        }

        public int GetVipLevelByOpenFunctionType(int functionType)
        {
            foreach (Vip vip in this._vipList)
            {
                foreach (int num in vip.openFuncitons)
                {
                    if (num == functionType)
                    {
                        return vip.level;
                    }
                }
            }
            return -1;
        }

        public int GetVipLimitByVipLevel(int vipLevel, int limitType)
        {
            Vip vipByLevel = this.GetVipByLevel(vipLevel);
            if (vipByLevel != null)
            {
                foreach (VipLimitCount count in vipByLevel.vipLimitCount)
                {
                    if (count.type == limitType)
                    {
                        return count.count;
                    }
                }
            }
            return 0;
        }

        public int GetVipLotteryCountByLotteryIndex(int vipLevel, int lotteryIndex)
        {
            Vip vipByLevel = this.GetVipByLevel(vipLevel);
            if (vipByLevel != null)
            {
                foreach (VipLotteryCount count in vipByLevel.vipLotteryCount)
                {
                    if (count.lotteryIndex == lotteryIndex)
                    {
                        return count.count;
                    }
                }
            }
            return 0;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _VipLimitType.Initialize();
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "VipConfig")
            {
                this._maxVipLevel = StrParser.ParseDecInt(element.Attribute("MaxVipLevel"), this.maxVipLevel);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        if (element2.Tag == "Vip")
                        {
                            this.vipList.Add(this.LoadVipFromXml(element2));
                        }
                    }
                }
            }
        }

        private Privilege LoadPrivilegesFromXml(SecurityElement element)
        {
            return new Privilege { desc = StrParser.ParseStr(element.Attribute("Desc"), "", true) };
        }

        private Vip LoadVipFromXml(SecurityElement element)
        {
            Vip vip = new Vip {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                level = StrParser.ParseDecInt(element.Attribute("Level"), 1),
                costRMB = StrParser.ParseDecInt(element.Attribute("CostRMB"), 0),
                goodId = StrParser.ParseHexInt(element.Attribute("GoodId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "Privilege")
                        {
                            if (tag == "VipLimitCount")
                            {
                                goto Label_00E1;
                            }
                            if (tag == "VipLotteryCount")
                            {
                                goto Label_00F5;
                            }
                            if (tag == "OpenFunction")
                            {
                                goto Label_0109;
                            }
                        }
                        else
                        {
                            vip.privileges.Add(this.LoadPrivilegesFromXml(element2));
                        }
                    }
                    continue;
                Label_00E1:
                    vip.vipLimitCount.Add(this.LoadVipLimitCountFromXml(element2));
                    continue;
                Label_00F5:
                    vip.vipLotteryCount.Add(this.LoadVipLotteryCountFromXml(element2));
                    continue;
                Label_0109:
                    vip.openFuncitons.Add(TypeNameContainer<_OpenFunctionType>.Parse(element2.Text, 0));
                }
            }
            return vip;
        }

        private VipLimitCount LoadVipLimitCountFromXml(SecurityElement element)
        {
            return new VipLimitCount { 
                type = TypeNameContainer<_VipLimitType>.Parse(element.Attribute("Type"), 0),
                count = StrParser.ParseDecInt(element.Attribute("Count"), 0)
            };
        }

        private VipLotteryCount LoadVipLotteryCountFromXml(SecurityElement element)
        {
            return new VipLotteryCount { 
                lotteryIndex = StrParser.ParseDecInt(element.Attribute("LotteryIndex"), 0),
                count = StrParser.ParseDecInt(element.Attribute("Count"), 0)
            };
        }

        [ProtoMember(2, IsRequired=false, Name="maxVipLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int maxVipLevel
        {
            get
            {
                return this._maxVipLevel;
            }
            set
            {
                this._maxVipLevel = value;
            }
        }

        [ProtoMember(1, Name="vipList", DataFormat=DataFormat.Default)]
        public List<Vip> vipList
        {
            get
            {
                return this._vipList;
            }
        }

        public class _VipLimitType : TypeNameContainer<VipConfig._VipLimitType>
        {
            public const int BuyEnergyCount = 0x25;
            public const int BuyStaminaCount = 0x20;
            public const int ContinueCombatCDTime = 9;
            public const int DailyArenaCombatCount = 5;
            public const int DailyMysteryShopChangeCount = 10;
            public const int DailyPvpStaminaItemCount = 4;
            public const int DailySignInRemedyCount = 20;
            public const int DailyStaminaItemCount = 2;
            public const int DanDecomposeCount = 0x26;
            public const int DanItemDecomposeCount = 0x27;
            public const int DanMaxCount = 40;
            public const int DinerEliRefreshAllCount = 13;
            public const int DinerEliRefreshSpecialCount = 14;
            public const int DinerHireEliteCount = 0x12;
            public const int DinerHireNormalCount = 0x11;
            public const int DinerHireRareCount = 0x13;
            public const int DinerNorRefreshAllCount = 11;
            public const int DinerNorRefreshSpecialCount = 12;
            public const int DinerRareRefreshAllCount = 15;
            public const int DinerRareRefreshSpecialCount = 0x10;
            public const int DungeonAddCommonResetCount = 0x15;
            public const int DungeonAddHardResetCount = 0x16;
            public const int DungeonAddNightmareResetCount = 0x17;
            public const int DungeonSecretAddCommonResetCount = 0x18;
            public const int DungeonSecretAddHardResetCount = 0x19;
            public const int DungeonSecretAddNightmareResetCount = 0x1a;
            public const int FiveHangersEmploymentCount = 0x1d;
            public const int FourHangersEmploymentCount = 0x1c;
            public const int FriendCampaignResetCount = 0x22;
            public const int MaxEnergy = 0x23;
            public const int MaxFriendCount = 7;
            public const int MaxPvpStamina = 3;
            public const int MaxStamina = 1;
            public const int MelaleucaFloorChallengeCount = 0x24;
            public const int PackageCapacity = 8;
            public const int ThreeHangersEmploymentCount = 0x1b;
            public const int Unknown = 0;
            public const int WolfSmokeAddCanFaildCount = 30;
            public const int WolfSmokeAddResetCount = 0x1f;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("MaxStamina", 1);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DailyStaminaItemCount", 2);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("MaxPvpStamina", 3);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DailyPvpStaminaItemCount", 4);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DailyArenaCombatCount", 5);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("MaxFriendCount", 7);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("PackageCapacity", 8);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("ContinueCombatCDTime", 9);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DailyMysteryShopChangeCount", 10);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DinerNorRefreshAllCount", 11);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DinerNorRefreshSpecialCount", 12);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DinerEliRefreshAllCount", 13);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DinerEliRefreshSpecialCount", 14);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DinerRareRefreshAllCount", 15);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DinerRareRefreshSpecialCount", 0x10);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DinerHireNormalCount", 0x11);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DinerHireEliteCount", 0x12);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DinerHireRareCount", 0x13);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DailySignInRemedyCount", 20);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DungeonAddCommonResetCount", 0x15);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DungeonAddHardResetCount", 0x16);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DungeonAddNightmareResetCount", 0x17);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DungeonSecretAddCommonResetCount", 0x18);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DungeonSecretAddHardResetCount", 0x19);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DungeonSecretAddNightmareResetCount", 0x1a);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("ThreeHangersEmploymentCount", 0x1b);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("FourHangersEmploymentCount", 0x1c);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("FiveHangersEmploymentCount", 0x1d);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("MelaleucaFloorChallengeCount", 0x24);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("WolfSmokeAddCanFaildCount", 30);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("WolfSmokeAddResetCount", 0x1f);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("BuyStaminaCount", 0x20);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("BuyEnergyCount", 0x25);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("MaxEnergy", 0x23);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("FriendCampaignResetCount", 0x22);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DanDecomposeCount", 0x26);
                flag &= TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DanItemDecomposeCount", 0x27);
                return (flag & TypeNameContainer<VipConfig._VipLimitType>.RegisterType("DanMaxCount", 40));
            }
        }

        [ProtoContract(Name="Privilege")]
        public class Privilege : IExtensible
        {
            private string _desc = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="desc", DataFormat=DataFormat.Default)]
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
        }

        [ProtoContract(Name="Vip")]
        public class Vip : IExtensible
        {
            private int _costRMB;
            private int _goodId;
            private int _id;
            private int _level;
            private readonly List<int> _openFuncitons = new List<int>();
            private readonly List<VipConfig.Privilege> _privileges = new List<VipConfig.Privilege>();
            private readonly List<VipConfig.VipLimitCount> _vipLimitCount = new List<VipConfig.VipLimitCount>();
            private readonly List<VipConfig.VipLotteryCount> _vipLotteryCount = new List<VipConfig.VipLotteryCount>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="costRMB", DataFormat=DataFormat.TwosComplement)]
            public int costRMB
            {
                get
                {
                    return this._costRMB;
                }
                set
                {
                    this._costRMB = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="goodId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int goodId
            {
                get
                {
                    return this._goodId;
                }
                set
                {
                    this._goodId = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(8, Name="openFuncitons", DataFormat=DataFormat.TwosComplement)]
            public List<int> openFuncitons
            {
                get
                {
                    return this._openFuncitons;
                }
            }

            [ProtoMember(5, Name="privileges", DataFormat=DataFormat.Default)]
            public List<VipConfig.Privilege> privileges
            {
                get
                {
                    return this._privileges;
                }
            }

            [ProtoMember(6, Name="vipLimitCount", DataFormat=DataFormat.Default)]
            public List<VipConfig.VipLimitCount> vipLimitCount
            {
                get
                {
                    return this._vipLimitCount;
                }
            }

            [ProtoMember(7, Name="vipLotteryCount", DataFormat=DataFormat.Default)]
            public List<VipConfig.VipLotteryCount> vipLotteryCount
            {
                get
                {
                    return this._vipLotteryCount;
                }
            }
        }

        [ProtoContract(Name="VipLimitCount")]
        public class VipLimitCount : IExtensible
        {
            private int _count;
            private int _type;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
            public int count
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
        }

        [ProtoContract(Name="VipLotteryCount")]
        public class VipLotteryCount : IExtensible
        {
            private int _count;
            private int _lotteryIndex;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
            public int count
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

            [ProtoMember(1, IsRequired=false, Name="lotteryIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int lotteryIndex
            {
                get
                {
                    return this._lotteryIndex;
                }
                set
                {
                    this._lotteryIndex = value;
                }
            }
        }
    }
}

