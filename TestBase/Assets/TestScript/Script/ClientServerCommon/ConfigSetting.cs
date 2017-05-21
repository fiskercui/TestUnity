namespace ClientServerCommon
{
    using System;
    using System.Collections.Generic;

    public class ConfigSetting
    {
        private Dictionary<Type, string> configList = new Dictionary<Type, string>();
        private int fileFormat;

        public ConfigSetting(int fileFormat)
        {
            this.fileFormat = fileFormat;
        }

        public string GetConfigName(Type type)
        {
            if (!this.configList.ContainsKey(type))
            {
                return "";
            }
            return this.configList[type];
        }

        private void SetConfigName(Type type, string value)
        {
            if (type != null)
            {
                if ((value == null) || (value == ""))
                {
                    if (this.configList.ContainsKey(type))
                    {
                        this.configList.Remove(type);
                    }
                }
                else if (this.configList.ContainsKey(type))
                {
                    this.configList[type] = value;
                }
                else
                {
                    this.configList.Add(type, value);
                }
            }
        }

        private string StringValue(string value)
        {
            if (value == null)
            {
                return "";
            }
            return value;
        }

        public string ActionConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.ActionConfig), value);
            }
        }

        public string AnimationConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.AnimationConfig), value);
            }
        }

        public string AppleGoodConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.AppleGoodConfig), value);
            }
        }

        public string ArenaConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.ArenaConfig), value);
            }
        }

        public string AssetDescConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.AssetDescConfig), value);
            }
        }

        public string AvatarAssetConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.AvatarAssetConfig), value);
            }
        }

        public string AvatarConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.AvatarConfig), value);
            }
        }

        public string BeastConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.BeastConfig), value);
            }
        }

        public string CampaignConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.CampaignConfig), value);
            }
        }

        public string ChangeNameConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.ChangeNameConfig), value);
            }
        }

        public string ClientConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.ClientConfig), value);
            }
        }

        public string ClientManifest
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.ClientManifest), value);
            }
        }

        public string DailySignInConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.DailySignInConfig), value);
            }
        }

        public string DanConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.DanConfig), value);
            }
        }

        public string DialogueConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.DialogueConfig), value);
            }
        }

        public string DinerConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.DinerConfig), value);
            }
        }

        public string DomineerConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.DomineerConfig), value);
            }
        }

        public string EquipmentConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.EquipmentConfig), value);
            }
        }

        public int FileFormat
        {
            get
            {
                return this.fileFormat;
            }
        }

        public string FriendCampaignConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.FriendCampaignConfig), value);
            }
        }

        public string FriendConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.FriendConfig), value);
            }
        }

        public string GameConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.GameConfig), value);
            }
        }

        public string GoodConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.GoodConfig), value);
            }
        }

        public string GuideConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.GuideConfig), value);
            }
        }

        public string GuildConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.GuildConfig), value);
            }
        }

        public string GuildExchangeShopConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.GuildExchangeShopConfig), value);
            }
        }

        public string GuildPrivateShopConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.GuildPrivateShopConfig), value);
            }
        }

        public string GuildPublicShopConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.GuildPublicShopConfig), value);
            }
        }

        public string GuildStageConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.GuildStageConfig), value);
            }
        }

        public string IllusionConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.IllusionConfig), value);
            }
        }

        public string IllustrationConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.IllustrationConfig), value);
            }
        }

        public string InitPlayerConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.InitPlayerConfig), value);
            }
        }

        public string ItemConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.ItemConfig), value);
            }
        }

        public string LevelConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.LevelConfig), value);
            }
        }

        public string LevelRewardConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.LevelRewardConfig), value);
            }
        }

        public string LocalNotificationConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.LocalNotificationConfig), value);
            }
        }

        public string MarvellousAdventureConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.MarvellousAdventureConfig), value);
            }
        }

        public string MelaleucaFloorConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.MelaleucaFloorConfig), value);
            }
        }

        public string MeridianConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.MeridianConfig), value);
            }
        }

        public string MonthCardConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.MonthCardConfig), value);
            }
        }

        public string MysteryerConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.MysteryerConfig), value);
            }
        }

        public string MysteryShopConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.MysteryShopConfig), value);
            }
        }

        public string OperationConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.OperationConfig), value);
            }
        }

        public string PartnerConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.PartnerConfig), value);
            }
        }

        public string PositionConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.PositionConfig), value);
            }
        }

        public string PowerConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.PowerConfig), value);
            }
        }

        public string PveConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.PveConfig), value);
            }
        }

        public string QinInfoConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.QinInfoConfig), value);
            }
        }

        public string QuestConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.QuestConfig), value);
            }
        }

        public string SceneConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.SceneConfig), value);
            }
        }

        public string SevenElevenGiftConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.SevenElevenGiftConfig), value);
            }
        }

        public string SkillConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.SkillConfig), value);
            }
        }

        public string SpecialGoodsConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.SpecialGoodsConfig), value);
            }
        }

        public string StartServerRewardConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.StartServerRewardConfig), value);
            }
        }

        public string StringsConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.StringsConfig), value);
            }
        }

        public string SuiteConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.SuiteConfig), value);
            }
        }

        public string TaskConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.TaskConfig), value);
            }
        }

        public string TavernConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.TavernConfig), value);
            }
        }

        public string TreasureBowlConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.TreasureBowlConfig), value);
            }
        }

        public string TutorialConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.TutorialConfig), value);
            }
        }

        public string VipConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.VipConfig), value);
            }
        }

        public string WolfSmokeConfig
        {
            set
            {
                this.SetConfigName(typeof(ClientServerCommon.WolfSmokeConfig), value);
            }
        }
    }
}

