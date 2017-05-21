namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="WolfSmokeConfig")]
    public class WolfSmokeConfig : Configuration, IExtensible
    {
        private readonly List<Addition> _additions = new List<Addition>();
        private readonly List<EggsEffect> _eggsEffects = new List<EggsEffect>();
        private bool _isActivtyShopOpen;
        private readonly List<ClientServerCommon.MainType> _mainTypes = new List<ClientServerCommon.MainType>();
        private readonly List<OpenLimit> _openLimits = new List<OpenLimit>();
        private long _resetTime;
        private WolfShop _shop;
        private readonly List<WolfStage> _stages = new List<WolfStage>();
        private IExtension extensionObject;

        public Addition GetAdditionById(int additionId)
        {
            foreach (Addition addition in this._additions)
            {
                if (addition.AdditionId == additionId)
                {
                    return addition;
                }
            }
            return null;
        }

        public WolfStage GetFirstStage()
        {
            return this._stages[0];
        }

        public int GetIndexByStageId(int stageId)
        {
            int num = 0;
            for (int i = 0; i < this._stages.Count; i++)
            {
                if (this._stages[i].StageId == stageId)
                {
                    num = i + 1;
                }
            }
            return num;
        }

        public WolfStage GetStageById(int stageId)
        {
            foreach (WolfStage stage in this._stages)
            {
                if (stage.StageId == stageId)
                {
                    return stage;
                }
            }
            return null;
        }

        public string GetStageNameById(int stageId)
        {
            if (stageId == 0)
            {
                return "";
            }
            string stageName = string.Empty;
            foreach (WolfStage stage in this._stages)
            {
                if (stage.StageId == stageId)
                {
                    stageName = stage.StageName;
                }
            }
            return stageName;
        }

        public int GetStageSequenceById(int stageId)
        {
            if (stageId == 0)
            {
                return 0;
            }
            int stageSequence = 0;
            foreach (WolfStage stage in this._stages)
            {
                if (stageId == stage.StageId)
                {
                    stageSequence = stage.StageSequence;
                }
            }
            return stageSequence;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _WolfSmokeOpenLimit.Initialize();
            _WolfSmokeRenderIcon.Initialize();
        }

        private Addition LoadAdditionFromXml(SecurityElement element)
        {
            Addition addition = new Addition {
                AdditionId = StrParser.ParseHexInt(element.Attribute("AdditionId"), 0)
            };
            foreach (SecurityElement element2 in element.Children)
            {
                string str;
                if (((str = element2.Tag) != null) && (str == "EmBattleAttribute"))
                {
                    addition.EmBattleAttribute = this.LoadAdditionsFromXml(element2);
                }
            }
            return addition;
        }

        private void LoadAdditionSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Addition"))
                    {
                        this.Additions.Add(this.LoadAdditionFromXml(element2));
                    }
                }
            }
        }

        private EmBattleAttribute LoadAdditionsFromXml(SecurityElement element)
        {
            EmBattleAttribute attribute = new EmBattleAttribute {
                type = TypeNameContainer<PositionConfig._EmBattleType>.Parse(element.Attribute("AffectType"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), null),
                desc = StrParser.ParseStr(element.Attribute("Desc"), null)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "PropertyModifier")
                    {
                        PropertyModifier item = PropertyModifier.LoadFromXml(element2);
                        attribute.modifiers.Add(item);
                    }
                }
            }
            return attribute;
        }

        private EggsEffect LoadEggsEffectFromXml(SecurityElement element)
        {
            return new EggsEffect { 
                RewardId = StrParser.ParseHexInt(element.Attribute("RewardId"), 0),
                Model = StrParser.ParseStr(element.Attribute("Model"), null),
                GetEffect = StrParser.ParseStr(element.Attribute("GetEffect"), null),
                FlyEffect = StrParser.ParseStr(element.Attribute("FlyEffect"), null)
            };
        }

        private void LoadEggsEffectSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "EggsEffect"))
                    {
                        this.EggsEffects.Add(this.LoadEggsEffectFromXml(element2));
                    }
                }
            }
        }

        private Eggs LoadEggsFromXml(SecurityElement element)
        {
            return new Eggs { 
                RewardId = StrParser.ParseHexInt(element.Attribute("RewardId"), 0),
                Weight = StrParser.ParseDecInt(element.Attribute("Weight"), 0),
                CountMin = StrParser.ParseDecInt(element.Attribute("CountMin"), 0),
                CountMax = StrParser.ParseDecInt(element.Attribute("CountMax"), 0)
            };
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "WolfSmokeConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    switch (element2.Tag)
                    {
                        case "WolfStageSet":
                            this.LoadWolfStagesFromXml(element2);
                            break;

                        case "WolfShop":
                            this.LoadWolfShopFromXml(element2);
                            break;

                        case "OpenLimit":
                            this.LoadOpenLimitFromXml(element2);
                            break;

                        case "ResetTime":
                            this._resetTime = StrParser.ParseDateTime(element2.Text);
                            break;

                        case "IsActivtyShopOpen":
                            this._isActivtyShopOpen = StrParser.ParseBool(element2.Text, false);
                            break;

                        case "AdditionSet":
                            this.LoadAdditionSetFromXml(element2);
                            break;

                        case "EggsEffectSet":
                            this.LoadEggsEffectSetFromXml(element2);
                            break;

                        case "MainTypeSet":
                            this.LoadMainTypeSetFromXml(element2);
                            break;
                    }
                }
            }
        }

        private Goods LoadGoodsFromXml(SecurityElement element)
        {
            Goods goods = new Goods {
                goodsId = StrParser.ParseHexInt(element.Attribute("GoodsId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Reward")
                    {
                        goods.reward = Reward.LoadFromXml(element2);
                    }
                    if (element2.Tag == "Cost")
                    {
                        goods.cost = Cost.LoadFromXml(element2);
                    }
                    if (element2.Tag == "DiscountCost")
                    {
                        goods.discountCost = Cost.LoadFromXml(element2);
                    }
                }
            }
            return goods;
        }

        private ClientServerCommon.MainType LoadMainTypeFromXml(SecurityElement element)
        {
            ClientServerCommon.MainType type = new ClientServerCommon.MainType {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    ClientServerCommon.SubType item = this.LoadSubTypeFromXml(element2);
                    if (item != null)
                    {
                        type.subTypes.Add(item);
                    }
                }
            }
            return type;
        }

        private void LoadMainTypeSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "MainType")
                    {
                        this._mainTypes.Add(this.LoadMainTypeFromXml(element2));
                    }
                }
            }
        }

        private void LoadOpenLimitFromXml(SecurityElement element)
        {
            OpenLimit item = new OpenLimit {
                Type = TypeNameContainer<_WolfSmokeOpenLimit>.Parse(element.Attribute("Type"), 0),
                Value = StrParser.ParseDecInt(element.Attribute("Value"), 0),
                Desc = StrParser.ParseStr(element.Attribute("Desc"), "")
            };
            this._openLimits.Add(item);
        }

        private ClientServerCommon.SubType LoadSubTypeFromXml(SecurityElement element)
        {
            return new ClientServerCommon.SubType { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true),
                desc = StrParser.ParseStr(element.Attribute("Desc"), "", true),
                assetIconId = StrParser.ParseHexInt(element.Attribute("AssetIconId"), 0),
                assetIconType = TypeNameContainer<_WolfSmokeRenderIcon>.Parse(element.Attribute("AssetIconType"), 0)
            };
        }

        private void LoadWolfShopFromXml(SecurityElement element)
        {
            WolfShop shop = new WolfShop();
            this.Shop = shop;
            this.Shop.MaxGoodsCount = StrParser.ParseDecInt(element.Attribute("MaxGoodsCount"), 0);
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "RefreshCost")
                        {
                            Cost item = Cost.LoadFromXml(element2);
                            this.Shop.RefreshCost.Add(item);
                        }
                        else if (tag == "Goods")
                        {
                            goto Label_0091;
                        }
                    }
                    continue;
                Label_0091:
                    this.Shop.Goods.Add(this.LoadGoodsFromXml(element2));
                }
            }
        }

        private WolfStage LoadWolfStageFromXml(SecurityElement element)
        {
            WolfStage stage = new WolfStage {
                StageId = StrParser.ParseHexInt(element.Attribute("StageId"), 0),
                StageName = StrParser.ParseStr(element.Attribute("StageName"), ""),
                StageSequence = StrParser.ParseDecInt(element.Attribute("StageSequence"), 0),
                SceneId = StrParser.ParseHexInt(element.Attribute("SceneId"), 0),
                Dialogue = StrParser.ParseHexInt(element.Attribute("Dialogue"), 0),
                ModelObjName = StrParser.ParseStr(element.Attribute("ModelObjName"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "PassRewards")
                        {
                            if (tag == "FirstPassRewards")
                            {
                                goto Label_015F;
                            }
                            if (tag == "AdditionId")
                            {
                                goto Label_01BA;
                            }
                        }
                        else if (element2.Children != null)
                        {
                            foreach (SecurityElement element3 in element2.Children)
                            {
                                Reward item = Reward.LoadFromXml(element3);
                                stage.PassRewards.Add(item);
                            }
                        }
                    }
                    continue;
                Label_015F:
                    if (element2.Children != null)
                    {
                        foreach (SecurityElement element4 in element2.Children)
                        {
                            Reward reward2 = Reward.LoadFromXml(element4);
                            stage.FirstPassRewards.Add(reward2);
                        }
                    }
                    continue;
                Label_01BA:
                    stage.AdditionIds.Add(StrParser.ParseHexInt(element2.Text, 0));
                }
            }
            return stage;
        }

        private void LoadWolfStagesFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "WolfStage"))
                    {
                        this.Stages.Add(this.LoadWolfStageFromXml(element2));
                    }
                }
            }
        }

        [ProtoMember(5, Name="additions", DataFormat=DataFormat.Default)]
        public List<Addition> Additions
        {
            get
            {
                return this._additions;
            }
        }

        [ProtoMember(6, Name="eggsEffects", DataFormat=DataFormat.Default)]
        public List<EggsEffect> EggsEffects
        {
            get
            {
                return this._eggsEffects;
            }
        }

        [DefaultValue(false), ProtoMember(9, IsRequired=false, Name="isActivtyShopOpen", DataFormat=DataFormat.Default)]
        public bool IsActivtyShopOpen
        {
            get
            {
                return this._isActivtyShopOpen;
            }
            set
            {
                this._isActivtyShopOpen = value;
            }
        }

        [ProtoMember(7, Name="mainTypes", DataFormat=DataFormat.Default)]
        public List<ClientServerCommon.MainType> MainTypes
        {
            get
            {
                return this._mainTypes;
            }
        }

        [ProtoMember(4, Name="openLimits", DataFormat=DataFormat.Default)]
        public List<OpenLimit> OpenLimits
        {
            get
            {
                return this._openLimits;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="resetTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long ResetTime
        {
            get
            {
                return this._resetTime;
            }
            set
            {
                this._resetTime = value;
            }
        }

        public DateTime ResetTimeDateTime
        {
            get
            {
                return new DateTime(this._resetTime * 0x2710L);
            }
        }

        [ProtoMember(3, IsRequired=false, Name="shop", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public WolfShop Shop
        {
            get
            {
                return this._shop;
            }
            set
            {
                this._shop = value;
            }
        }

        [ProtoMember(2, Name="stages", DataFormat=DataFormat.Default)]
        public List<WolfStage> Stages
        {
            get
            {
                return this._stages;
            }
        }

        public class _WolfSmokeOpenLimit : TypeNameContainer<WolfSmokeConfig._WolfSmokeOpenLimit>
        {
            public const int CreateAccountTime = 2;
            public const int OpenAreaTime = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<WolfSmokeConfig._WolfSmokeOpenLimit>.RegisterType("OpenAreaTime", 1, "OpenAreaTime");
                return (flag & TypeNameContainer<WolfSmokeConfig._WolfSmokeOpenLimit>.RegisterType("CreateAccountTime", 2, "CreateAccountTime"));
            }
        }

        public class _WolfSmokeRenderIcon : TypeNameContainer<WolfSmokeConfig._WolfSmokeRenderIcon>
        {
            public const int RenderEggs = 2;
            public const int RenderLevel = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<WolfSmokeConfig._WolfSmokeRenderIcon>.RegisterType("RenderLevel", 1, "RenderLevel");
                return (flag & TypeNameContainer<WolfSmokeConfig._WolfSmokeRenderIcon>.RegisterType("RenderEggs", 2, "RenderEggs"));
            }
        }

        [ProtoContract(Name="Addition")]
        public class Addition : IExtensible
        {
            private int _additionId;
            private ClientServerCommon.EmBattleAttribute _emBattleAttribute;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="additionId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int AdditionId
            {
                get
                {
                    return this._additionId;
                }
                set
                {
                    this._additionId = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="emBattleAttribute", DataFormat=DataFormat.Default)]
            public ClientServerCommon.EmBattleAttribute EmBattleAttribute
            {
                get
                {
                    return this._emBattleAttribute;
                }
                set
                {
                    this._emBattleAttribute = value;
                }
            }
        }

        [ProtoContract(Name="AvatarGoods")]
        public class AvatarGoods : IExtensible
        {
            private int _avatarId;
            private readonly List<ClientServerCommon.WolfSmokeConfig.GoodsWeight> _goodsWeight = new List<ClientServerCommon.WolfSmokeConfig.GoodsWeight>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="avatarId", DataFormat=DataFormat.TwosComplement)]
            public int AvatarId
            {
                get
                {
                    return this._avatarId;
                }
                set
                {
                    this._avatarId = value;
                }
            }

            [ProtoMember(2, Name="goodsWeight", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.WolfSmokeConfig.GoodsWeight> GoodsWeight
            {
                get
                {
                    return this._goodsWeight;
                }
            }
        }

        [ProtoContract(Name="Eggs")]
        public class Eggs : IExtensible
        {
            private int _countMax;
            private int _countMin;
            private int _rewardId;
            private int _weight;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="countMax", DataFormat=DataFormat.TwosComplement)]
            public int CountMax
            {
                get
                {
                    return this._countMax;
                }
                set
                {
                    this._countMax = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="countMin", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int CountMin
            {
                get
                {
                    return this._countMin;
                }
                set
                {
                    this._countMin = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="rewardId", DataFormat=DataFormat.TwosComplement)]
            public int RewardId
            {
                get
                {
                    return this._rewardId;
                }
                set
                {
                    this._rewardId = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="weight", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoContract(Name="EggsEffect")]
        public class EggsEffect : IExtensible
        {
            private string _flyEffect = "";
            private string _getEffect = "";
            private string _model = "";
            private int _rewardId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="flyEffect", DataFormat=DataFormat.Default)]
            public string FlyEffect
            {
                get
                {
                    return this._flyEffect;
                }
                set
                {
                    this._flyEffect = value;
                }
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="getEffect", DataFormat=DataFormat.Default)]
            public string GetEffect
            {
                get
                {
                    return this._getEffect;
                }
                set
                {
                    this._getEffect = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="model", DataFormat=DataFormat.Default), DefaultValue("")]
            public string Model
            {
                get
                {
                    return this._model;
                }
                set
                {
                    this._model = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="rewardId", DataFormat=DataFormat.TwosComplement)]
            public int RewardId
            {
                get
                {
                    return this._rewardId;
                }
                set
                {
                    this._rewardId = value;
                }
            }
        }

        [ProtoContract(Name="EggsPlace")]
        public class EggsPlace : IExtensible
        {
            private readonly List<ClientServerCommon.WolfSmokeConfig.Eggs> _eggs = new List<ClientServerCommon.WolfSmokeConfig.Eggs>();
            private int _placeIndex;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="eggs", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.WolfSmokeConfig.Eggs> Eggs
            {
                get
                {
                    return this._eggs;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="placeIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int PlaceIndex
            {
                get
                {
                    return this._placeIndex;
                }
                set
                {
                    this._placeIndex = value;
                }
            }
        }

        [ProtoContract(Name="GoodsWeight")]
        public class GoodsWeight : IExtensible
        {
            private int _goodsId;
            private int _weight;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="goodsId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int GoodsId
            {
                get
                {
                    return this._goodsId;
                }
                set
                {
                    this._goodsId = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="weight", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoContract(Name="OpenLimit")]
        public class OpenLimit : IExtensible
        {
            private string _desc = "";
            private int _type;
            private int _value;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="desc", DataFormat=DataFormat.Default)]
            public string Desc
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

            [ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Type
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

            [ProtoMember(2, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int Value
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
        }

        [ProtoContract(Name="RandomEnemy")]
        public class RandomEnemy : IExtensible
        {
            private int _maxNum;
            private readonly List<WolfSmokeConfig.RandomRange> _randomRanges = new List<WolfSmokeConfig.RandomRange>();
            private IExtension extensionObject;

            public WolfSmokeConfig.RandomRange GetRandomRangeByStageId(int stageId)
            {
                foreach (WolfSmokeConfig.RandomRange range in this._randomRanges)
                {
                    if (range.StageId == stageId)
                    {
                        return range;
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="maxNum", DataFormat=DataFormat.TwosComplement)]
            public int MaxNum
            {
                get
                {
                    return this._maxNum;
                }
                set
                {
                    this._maxNum = value;
                }
            }

            [ProtoMember(2, Name="randomRanges", DataFormat=DataFormat.Default)]
            public List<WolfSmokeConfig.RandomRange> RandomRanges
            {
                get
                {
                    return this._randomRanges;
                }
            }
        }

        [ProtoContract(Name="RandomRange")]
        public class RandomRange : IExtensible
        {
            private float _lowLimit;
            private int _stageId;
            private float _upLimit;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="lowLimit", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float LowLimit
            {
                get
                {
                    return this._lowLimit;
                }
                set
                {
                    this._lowLimit = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="stageId", DataFormat=DataFormat.TwosComplement)]
            public int StageId
            {
                get
                {
                    return this._stageId;
                }
                set
                {
                    this._stageId = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(2, IsRequired=false, Name="upLimit", DataFormat=DataFormat.FixedSize)]
            public float UpLimit
            {
                get
                {
                    return this._upLimit;
                }
                set
                {
                    this._upLimit = value;
                }
            }
        }

        [ProtoContract(Name="WolfShop")]
        public class WolfShop : IExtensible
        {
            private readonly List<ClientServerCommon.Goods> _goods = new List<ClientServerCommon.Goods>();
            private int _maxGoodsCount;
            private readonly List<Cost> _refreshCost = new List<Cost>();
            private IExtension extensionObject;

            public ClientServerCommon.Goods GetGoodsById(int goodsId)
            {
                foreach (ClientServerCommon.Goods goods in this._goods)
                {
                    if (goods.goodsId == goodsId)
                    {
                        return goods;
                    }
                }
                return null;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, Name="goods", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.Goods> Goods
            {
                get
                {
                    return this._goods;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="maxGoodsCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MaxGoodsCount
            {
                get
                {
                    return this._maxGoodsCount;
                }
                set
                {
                    this._maxGoodsCount = value;
                }
            }

            [ProtoMember(1, Name="refreshCost", DataFormat=DataFormat.Default)]
            public List<Cost> RefreshCost
            {
                get
                {
                    return this._refreshCost;
                }
            }
        }

        [ProtoContract(Name="WolfStage")]
        public class WolfStage : IExtensible
        {
            private readonly List<int> _additionIds = new List<int>();
            private int _dialogue;
            private readonly List<Reward> _firstPassRewards = new List<Reward>();
            private string _modelObjName = "";
            private readonly List<Reward> _passRewards = new List<Reward>();
            private int _sceneId;
            private int _stageId;
            private string _stageName = "";
            private int _stageSequence;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(7, Name="additionIds", DataFormat=DataFormat.TwosComplement)]
            public List<int> AdditionIds
            {
                get
                {
                    return this._additionIds;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="dialogue", DataFormat=DataFormat.TwosComplement)]
            public int Dialogue
            {
                get
                {
                    return this._dialogue;
                }
                set
                {
                    this._dialogue = value;
                }
            }

            [ProtoMember(6, Name="firstPassRewards", DataFormat=DataFormat.Default)]
            public List<Reward> FirstPassRewards
            {
                get
                {
                    return this._firstPassRewards;
                }
            }

            [DefaultValue(""), ProtoMember(9, IsRequired=false, Name="modelObjName", DataFormat=DataFormat.Default)]
            public string ModelObjName
            {
                get
                {
                    return this._modelObjName;
                }
                set
                {
                    this._modelObjName = value;
                }
            }

            [ProtoMember(5, Name="passRewards", DataFormat=DataFormat.Default)]
            public List<Reward> PassRewards
            {
                get
                {
                    return this._passRewards;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="sceneId", DataFormat=DataFormat.TwosComplement)]
            public int SceneId
            {
                get
                {
                    return this._sceneId;
                }
                set
                {
                    this._sceneId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="stageId", DataFormat=DataFormat.TwosComplement)]
            public int StageId
            {
                get
                {
                    return this._stageId;
                }
                set
                {
                    this._stageId = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="stageName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string StageName
            {
                get
                {
                    return this._stageName;
                }
                set
                {
                    this._stageName = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="stageSequence", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int StageSequence
            {
                get
                {
                    return this._stageSequence;
                }
                set
                {
                    this._stageSequence = value;
                }
            }
        }
    }
}

