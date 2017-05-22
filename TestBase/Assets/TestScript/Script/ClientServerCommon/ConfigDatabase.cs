namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class ConfigDatabase
    {
        //private ClientServerCommon.AttributeCalculator attributeCalculator = new ClientServerCommon.AttributeCalculator();
        private Dictionary<Type, Configuration> configurations = new Dictionary<Type, Configuration>();
        private static ConfigDatabase defaultCfg;
        private static DelayLoadFileDelegate delayLoadFileDel = null;
        private static bool isInitialized = false;
        private static IMathParserFactory mathParserFactory;

        public static void AddLogger(ILogger logger)
        {
            LoggerManager.Instance.AddLogger(logger);
        }

        public void DelayUnloadConfig()
        {
            foreach (KeyValuePair<Type, Configuration> pair in this.configurations)
            {
                pair.Value.DelayUnload = true;
            }
        }

        private T GetConfiguration<T>() where T: Configuration, new()
        {
            return this.GetConfiguration<T>(true);
        }

        private T GetConfiguration<T>(bool supportDelayLoad) where T: Configuration, new()
        {
            Configuration configuration = null;
            if ((!this.configurations.TryGetValue(typeof(T), out configuration) || (supportDelayLoad && configuration.DelayUnload)) && supportDelayLoad)
            {
                configuration = LoadDelayedConfig<T>(this);
                if (configuration != null)
                {
                    this.configurations[typeof(T)] = configuration;
                }
                else
                {
                    LoggerManager.Instance.Debug("LoadDelayedConfig failed : " + typeof(T), new object[0]);
                }
            }
            return (T) configuration;
        }

        public static void Initialize(IMathParserFactory mathParserFactory, bool supportProtoBuf, bool protoUseTypeMode)
        {
            if (!isInitialized)
            {
                isInitialized = true;
                ConfigDatabase.mathParserFactory = mathParserFactory;
                if (supportProtoBuf)
                {
                    DataSerializer.Initialize(protoUseTypeMode);
                }
                _AccumulationStatus.Initialize();
                _AccumulationType.Initialize();
                _ServerAreaStatus.Initialize();
                _TrainType.Initialize();
                _SignCount.Initialize();
                _DungeonType.Initialize();
                _DungeonDifficulity.Initialize();
                _ConditionValueCompareType.Initialize();
                _DeviceType.Initialize();
                _Difficulty.Initialize();
                _ZoneStatus.Initialize();
                _DungeonStatus.Initialize();
                _Goods.Initialize();
                _MelaleucaLimitType.Initialize();
                _WolfSmokeLimitType.Initialize();
                _FriendStatus.Initialize();
                _FriendEmailStatus.Initialize();
                _AvatarBattlePositionType.Initialize();
                _AvatarAttributeType.Initialize();
                _AvatarAbilityType.Initialize();
                _RequirementType.Initialize();
                _TimeDurationType.Initialize();
                _TimeType.Initialize();
                _UIType.Initialize();
                _GoodsStatusType.Initialize();
                IDSeg.Initialize();
                ClientServerCommon.Condition._Type.Initialize();
                PropertyModifier._Type.Initialize();
                PropertyModifier._ValueModifyType.Initialize();
                ClientServerCommon.AvatarConfig.Initialize();
                ClientServerCommon.AvatarAssetConfig.Initialize();
                ClientServerCommon.EquipmentConfig.Initizlize();
                ClientServerCommon.ActionConfig.Initialize();
                ClientServerCommon.ItemConfig.Initialize();
                ClientServerCommon.PveConfig.Initizlize();
                ClientServerCommon.LocalNotificationConfig.Initialize();
                ClientServerCommon.TutorialConfig.Initialize();
                ClientServerCommon.DialogueConfig.Initialize();
                ClientServerCommon.VipConfig.Initialize();
                _OpenFunctionType.Initialize();
                ClientServerCommon.CampaignConfig.Initialize();
                ClientServerCommon.QuestConfig.Initialize();
                _CombatFailGuidType.Initialize();
                _ClientDynamicValueType.Initialize();
                ClientServerCommon.MeridianConfig.Initizlize();
                _PlatformType.Initialize();
                SpecialSkillType.Initialize();
                ClientServerCommon.DomineerConfig.Initialize();
                ClientServerCommon.PositionConfig.Initialize();
                ClientServerCommon.DinerConfig.Initialize();
                ClientServerCommon.DailySignInConfig.Initialize();
                ClientServerCommon.SuiteConfig.Initialize();
                _Isvalid.Initialize();
                ClientServerCommon.TaskConfig.Initialize();
                ClientServerCommon.TavernConfig.Initialize();
                ClientServerCommon.MysteryShopConfig.Initialize();
                ClientServerCommon.WolfSmokeConfig.Initialize();
                ClientServerCommon.IllusionConfig.Initialize();
                ClientServerCommon.FriendCampaignConfig.Initialize();
                _CombatRoundType.Initialize();
                _AvatarType.Initialize();
                ClientServerCommon.GuideConfig.Initialize();
                ClientServerCommon._ActivityType.Initialize();
                ClientServerCommon.QinInfoConfig.Initialize();
                MonthCardType.Initialize();
                MonthCardRewardType.Initialize();
                PurchaseType.Initialize();
                GreenPointType.Initialize();
                ClientServerCommon.OperationConfig.Initialize();
                _MultiSelectType.Initialize();
                _DoubleSelectType.Initialize();
                _MarvellousCampType.Initialize();
                ClientServerCommon.MarvellousAdventureConfig.Initialize();
                ClientServerCommon.MysteryerConfig.Initialize();
                _InviteCodeRewardPickState.Initialize();
                _TavernRecruitStage.Initialize();
                _NumberPositionType.Initialize();
                _NumberConvertType.Initialize();
                _CurrencyType.Initialize();
                ClientServerCommon.DanConfig.Initialize();
                ClientServerCommon.GuildStageConfig.Initialize();
                _CounterType.Initialize();
                ClientServerCommon.GuildConfig.Initialize();
                ClientServerCommon.GuildPublicShopConfig.Initialize();
                ClientServerCommon.GuildPrivateShopConfig.Initialize();
                ClientServerCommon.GuildExchangeShopConfig.Initialize();
                ClientServerCommon.BeastConfig.Initialize();
            }
        }

        public void LoadAll(IFileLoader fileLoader, ConfigSetting cfgSetting)
        {
            this.LoadConfig<ClientServerCommon.ClientConfig>(fileLoader, cfgSetting);
            this.LoadGameConfig(fileLoader, cfgSetting);
        }

        public void LoadConfig<T>(IFileLoader fileLoader, ConfigSetting cfgSetting) where T: Configuration, new()
        {
            T local = LoadConfig<T>(this, fileLoader, cfgSetting.FileFormat, cfgSetting.GetConfigName(typeof(T)));
            if (local != null)
            {
                this.configurations[typeof(T)] = local;
            }
        }

        public static T LoadConfig<T>(ConfigDatabase cfgDB, IFileLoader fileLoader, int fileFormat, string filePath) where T: Configuration, new()
        {
            T local = default(T);
            switch (fileFormat)
            {
                case 1:
                    local = Activator.CreateInstance<T>();
                    local.LoadFromXml(fileLoader.LoadAsXML(filePath));
                    break;

                case 2:
                    local = (T) DataSerializer.Deserialize(fileLoader.LoadAsSteam(filePath), typeof(T));
                    break;
            }
            if (local != null)
            {
                local.ConstructLogicData(cfgDB, fileFormat);
            }
            return local;
        }

        private static T LoadDelayedConfig<T>(ConfigDatabase cfgDB) where T: Configuration, new()
        {
            string str;
            if (delayLoadFileDel == null)
            {
                return default(T);
            }
            int fileFormat = 0;
            IFileLoader fileLoader = delayLoadFileDel(typeof(T), out str, out fileFormat);
            return LoadConfig<T>(cfgDB, fileLoader, fileFormat, str);
        }

        public void LoadGameConfig(IFileLoader fileLoader, ConfigSetting cfgSetting)
        {
            this.LoadConfig<ClientServerCommon.PartnerConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.StringsConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.SceneConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.AvatarAssetConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.AnimationConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.ActionConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.EquipmentConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.AvatarConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.LevelConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.GameConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.AssetDescConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.ItemConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.GoodConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.SkillConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.CampaignConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.ArenaConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.DailySignInConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.InitPlayerConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.PveConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.ClientManifest>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.GuideConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.AppleGoodConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.VipConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.TaskConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.DialogueConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.LocalNotificationConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.LevelRewardConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.TavernConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.TutorialConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.QuestConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.MeridianConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.MysteryShopConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.StartServerRewardConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.DomineerConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.PositionConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.SuiteConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.DinerConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.IllustrationConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.LevelRewardConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.TreasureBowlConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.MonthCardConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.MarvellousAdventureConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.MelaleucaFloorConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.WolfSmokeConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.DanConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.IllusionConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.FriendCampaignConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.SpecialGoodsConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.QinInfoConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.FriendConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.OperationConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.SevenElevenGiftConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.GuildConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.GuildPublicShopConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.GuildPrivateShopConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.GuildExchangeShopConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.GuildStageConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.ChangeNameConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.PowerConfig>(fileLoader, cfgSetting);
            this.LoadConfig<ClientServerCommon.BeastConfig>(fileLoader, cfgSetting);
        }

        public static void RemoveLogger(ILogger logger)
        {
            LoggerManager.Instance.RemoveLogger(logger);
        }

        public static long Serialize(Configuration config, Stream steam)
        {
            config.BeforSerialize();
            Serializer.NonGeneric.Serialize(steam, config);
            config.AfterSerialize();
            return steam.Length;
        }

        public void UnloadConfig(params Type[] exceptType)
        {
            List<Configuration> list = new List<Configuration>();
            foreach (Type type in exceptType)
            {
                Configuration configuration;
                if (this.configurations.TryGetValue(type, out configuration))
                {
                    list.Add(configuration);
                }
            }
            this.configurations.Clear();
            foreach (Configuration configuration2 in list)
            {
                this.configurations.Add(configuration2.GetType(), configuration2);
            }
        }

        public ClientServerCommon.ActionConfig ActionConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.ActionConfig>();
            }
        }

        public ClientServerCommon.AnimationConfig AnimationConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.AnimationConfig>();
            }
        }

        public ClientServerCommon.AppleGoodConfig AppleGoodConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.AppleGoodConfig>();
            }
        }

        public ClientServerCommon.ArenaConfig ArenaConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.ArenaConfig>();
            }
        }

        public ClientServerCommon.AssetDescConfig AssetDescConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.AssetDescConfig>();
            }
        }

        //public ClientServerCommon.AttributeCalculator AttributeCalculator
        //{
        //    get
        //    {
        //        return this.attributeCalculator;
        //    }
        //}

        public ClientServerCommon.AvatarAssetConfig AvatarAssetConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.AvatarAssetConfig>();
            }
        }

        public ClientServerCommon.AvatarConfig AvatarConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.AvatarConfig>();
            }
        }

        public ClientServerCommon.BeastConfig BeastConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.BeastConfig>();
            }
        }

        public ClientServerCommon.CampaignConfig CampaignConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.CampaignConfig>();
            }
        }

        public ClientServerCommon.ChangeNameConfig ChangeNameConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.ChangeNameConfig>();
            }
        }

        public ClientServerCommon.ClientConfig ClientConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.ClientConfig>(false);
            }
        }

        public ClientServerCommon.ClientManifest ClientManifest
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.ClientManifest>(false);
            }
        }

        public Dictionary<Type, Configuration> Configurations
        {
            get
            {
                return this.configurations;
            }
        }

        public ClientServerCommon.DailySignInConfig DailySignInConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.DailySignInConfig>();
            }
        }

        public ClientServerCommon.DanConfig DanConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.DanConfig>();
            }
        }

        public static ConfigDatabase DefaultCfg
        {
            get
            {
                if (defaultCfg == null)
                {
                    defaultCfg = new ConfigDatabase();
                }
                return defaultCfg;
            }
            set
            {
                defaultCfg = value;
            }
        }

        public static DelayLoadFileDelegate DelayLoadFileDel
        {
            get
            {
                return delayLoadFileDel;
            }
            set
            {
                delayLoadFileDel = value;
            }
        }

        public ClientServerCommon.DialogueConfig DialogueConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.DialogueConfig>();
            }
        }

        public ClientServerCommon.DinerConfig DinerConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.DinerConfig>();
            }
        }

        public ClientServerCommon.DomineerConfig DomineerConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.DomineerConfig>();
            }
        }

        public ClientServerCommon.EquipmentConfig EquipmentConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.EquipmentConfig>();
            }
        }

        public ClientServerCommon.FriendCampaignConfig FriendCampaignConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.FriendCampaignConfig>();
            }
        }

        public ClientServerCommon.FriendConfig FriendConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.FriendConfig>();
            }
        }

        public ClientServerCommon.GameConfig GameConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.GameConfig>();
            }
        }

        public ClientServerCommon.GoodConfig GoodConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.GoodConfig>();
            }
        }

        public ClientServerCommon.GuideConfig GuideConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.GuideConfig>();
            }
        }

        public ClientServerCommon.GuildConfig GuildConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.GuildConfig>();
            }
        }

        public ClientServerCommon.GuildExchangeShopConfig GuildExchangeShopConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.GuildExchangeShopConfig>();
            }
        }

        public ClientServerCommon.GuildPrivateShopConfig GuildPrivateShopConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.GuildPrivateShopConfig>();
            }
        }

        public ClientServerCommon.GuildPublicShopConfig GuildPublicShopConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.GuildPublicShopConfig>();
            }
        }

        public ClientServerCommon.GuildStageConfig GuildStageConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.GuildStageConfig>();
            }
        }

        public ClientServerCommon.IllusionConfig IllusionConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.IllusionConfig>();
            }
        }

        public ClientServerCommon.IllustrationConfig IllustrationConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.IllustrationConfig>();
            }
        }

        public ClientServerCommon.InitPlayerConfig InitPlayerConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.InitPlayerConfig>();
            }
        }

        public static bool IsInitialized
        {
            get
            {
                return isInitialized;
            }
        }

        public ClientServerCommon.ItemConfig ItemConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.ItemConfig>();
            }
        }

        public ClientServerCommon.LevelConfig LevelConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.LevelConfig>();
            }
        }

        public ClientServerCommon.LevelRewardConfig LevelRewardConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.LevelRewardConfig>();
            }
        }

        public ClientServerCommon.LocalNotificationConfig LocalNotificationConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.LocalNotificationConfig>();
            }
        }

        public ClientServerCommon.MarvellousAdventureConfig MarvellousAdventureConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.MarvellousAdventureConfig>();
            }
        }

        public static IMathParserFactory MathParserFactory
        {
            get
            {
                return mathParserFactory;
            }
            set
            {
                mathParserFactory = value;
            }
        }

        public ClientServerCommon.MelaleucaFloorConfig MelaleucaFloorConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.MelaleucaFloorConfig>();
            }
        }

        public ClientServerCommon.MeridianConfig MeridianConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.MeridianConfig>();
            }
        }

        public ClientServerCommon.MonthCardConfig MonthCardConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.MonthCardConfig>();
            }
        }

        public ClientServerCommon.MysteryerConfig MysteryerConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.MysteryerConfig>();
            }
        }

        public ClientServerCommon.MysteryShopConfig MysteryShopConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.MysteryShopConfig>();
            }
        }

        public ClientServerCommon.OperationConfig OperationConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.OperationConfig>();
            }
        }

        public ClientServerCommon.PartnerConfig PartnerConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.PartnerConfig>();
            }
        }

        public ClientServerCommon.PositionConfig PositionConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.PositionConfig>();
            }
        }

        public ClientServerCommon.PowerConfig PowerConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.PowerConfig>();
            }
        }

        public ClientServerCommon.PveConfig PveConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.PveConfig>();
            }
        }

        public ClientServerCommon.QinInfoConfig QinInfoConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.QinInfoConfig>();
            }
        }

        public ClientServerCommon.QuestConfig QuestConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.QuestConfig>();
            }
        }

        public ClientServerCommon.SceneConfig SceneConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.SceneConfig>();
            }
        }

        public ClientServerCommon.SevenElevenGiftConfig SevenElevenGiftConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.SevenElevenGiftConfig>();
            }
        }

        public ClientServerCommon.SkillConfig SkillConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.SkillConfig>();
            }
        }

        public ClientServerCommon.SpecialGoodsConfig SpecialGoodsConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.SpecialGoodsConfig>();
            }
        }

        public ClientServerCommon.StartServerRewardConfig StartServerRewardConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.StartServerRewardConfig>();
            }
        }

        public ClientServerCommon.StringsConfig StringsConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.StringsConfig>();
            }
        }

        public ClientServerCommon.SuiteConfig SuiteConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.SuiteConfig>();
            }
        }

        public ClientServerCommon.TaskConfig TaskConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.TaskConfig>();
            }
        }

        public ClientServerCommon.TavernConfig TavernConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.TavernConfig>();
            }
        }

        public ClientServerCommon.TreasureBowlConfig TreasureBowlConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.TreasureBowlConfig>();
            }
        }

        public ClientServerCommon.TutorialConfig TutorialConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.TutorialConfig>();
            }
        }

        public ClientServerCommon.VipConfig VipConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.VipConfig>();
            }
        }

        public ClientServerCommon.WolfSmokeConfig WolfSmokeConfig
        {
            get
            {
                return this.GetConfiguration<ClientServerCommon.WolfSmokeConfig>();
            }
        }

        public delegate IFileLoader DelayLoadFileDelegate(Type configType, out string fileName, out int fileFormat);
    }
}

