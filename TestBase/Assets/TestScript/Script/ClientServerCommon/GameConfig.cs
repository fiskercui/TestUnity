namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="GameConfig")]
    public class GameConfig : Configuration, IExtensible
    {
        private readonly List<OfficialSetting> _activeCodeSet = new List<OfficialSetting>();
        private AndroidEscapeKey _androidEscapeKey;
        private BattleScore _campaignBattleScore;
        private CombatMusic _combatMusic;
        private CombatSetting _combatSetting;
        private readonly List<CombatSkipSetting> _combatSkipSettings = new List<CombatSkipSetting>();
        private int _consignmentAmountEveryPage;
        private int _consignmentExpiredTime;
        private ContinueCombat _continueCombat;
        private bool _disableRecharge;
        private int _energyGenerateTime;
        private FriendConfig _friendConfig;
        private InitAvatarConfig _initAvatarConfig;
        private bool _isConvertExpain;
        private bool _isInviteCode;
        private bool _isShowAc;
        private bool _isShowAd;
        private bool _isShowAvatarUpDan;
        private bool _isShowFacebook;
        private bool _isShowWebPage;
        private readonly List<LoadingSetting> _loadingSettings = new List<LoadingSetting>();
        private int _maxColumnInFormation;
        private int _maxConsignmentCount;
        private int _maxEnergy;
        private int _maxRowInFormation;
        private int _maxRowInFormationCanUse;
        private int _minConsignmentLevel;
        private readonly List<OfficialSetting> _officialForumURLs = new List<OfficialSetting>();
        private readonly List<OfficialSetting> _officialInfos = new List<OfficialSetting>();
        private readonly List<OperationActivity> _operationActivitys = new List<OperationActivity>();
        private BattleScore _otherBattleScore;
        private int _playerNameMax;
        private int _pvpStaminaGenerateTime;
        private int _queryConsignmentListCount;
        private readonly List<RecordLocalBattle> _recordLocalBattleAngles = new List<RecordLocalBattle>();
        private readonly List<RecordLocalBattle> _recordLocalPositions = new List<RecordLocalBattle>();
        private RecoveryConfig _recoveryConfig;
        private long _restoreResetDungeonCompleteTime;
        private long _restoreUseEnergyItemTime;
        private long _restoreUsePvpStaminaItemTime;
        private long _restoreUseStaminaItemTime;
        private RobConfig _robEquipConfig;
        private RobConfig _robSkillConfig;
        private int _robSkillScrollMatchDeltaAdd;
        private int _robSkillScrollMatchDeltaSub;
        private Setting _setting;
        private readonly List<ShowingAttribute> _showingAttributes = new List<ShowingAttribute>();
        private int _staminaGenerateTime;
        private readonly List<TrainingFactor> _trainingFactors = new List<TrainingFactor>();
        private UIShowSetting _uiShowSetting;
        private WorldChatConfig _worldChatCfg;
        private WuXiaFengYunContinueLoginReward _wuXiaLoginReward;
        private IExtension extensionObject;

        public bool CanAttributeShow(int attributeType)
        {
            for (int i = 0; i < this._showingAttributes.Count; i++)
            {
                if (this._showingAttributes[i].attributeType == attributeType)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetActiveCodeGetUrl(int platformType, int channelId)
        {
            OfficialSetting setting = null;
            foreach (OfficialSetting setting2 in this._activeCodeSet)
            {
                if (setting2.type == platformType)
                {
                    setting = setting2;
                    break;
                }
            }
            if (setting == null)
            {
                return string.Empty;
            }
            foreach (ChannelSetting setting3 in setting.channelSetting)
            {
                if (setting3.channelId == channelId)
                {
                    return setting3.value;
                }
            }
            return setting.value;
        }

        public int GetColumnIndexInFormation(int posiition)
        {
            return (posiition % this.maxRowInFormation);
        }

        public CombatSkipSetting GetCombatSkipSetting(int combatType, int rating)
        {
            foreach (CombatSkipSetting setting in this._combatSkipSettings)
            {
                if ((setting.combatType == combatType) && (setting.rating == rating))
                {
                    return setting;
                }
            }
            return null;
        }

        public long GetContinueCombatCoolDownTime(int minutes, int lastContinueCombatCount)
        {
            if ((lastContinueCombatCount > this._continueCombat.maxContinueCombatCount) || (lastContinueCombatCount < 0))
            {
                lastContinueCombatCount = this._continueCombat.maxContinueCombatCount;
            }
            return (long) (((minutes * 0xea60) * lastContinueCombatCount) / this._continueCombat.maxContinueCombatCount);
        }

        public bool GetLocalBattleAngleByCombatType(int combatType)
        {
            foreach (RecordLocalBattle battle in this.recordLocalBattleAngles)
            {
                if (battle.battleType == combatType)
                {
                    return battle.record;
                }
            }
            return false;
        }

        public bool GetLocalRecordStateByCombatType(int combatType)
        {
            foreach (RecordLocalBattle battle in this.recordLocalPositions)
            {
                if (battle.battleType == combatType)
                {
                    return battle.record;
                }
            }
            return false;
        }

        public string GetOffficialForumURLs(int platformType, int channelId)
        {
            OfficialSetting setting = null;
            foreach (OfficialSetting setting2 in this._officialForumURLs)
            {
                if (setting2.type == platformType)
                {
                    setting = setting2;
                    break;
                }
            }
            if (setting == null)
            {
                return string.Empty;
            }
            foreach (ChannelSetting setting3 in setting.channelSetting)
            {
                if (setting3.channelId == channelId)
                {
                    return setting3.value;
                }
            }
            return setting.value;
        }

        public string GetOfficialInfos(int platformType, int channelId)
        {
            OfficialSetting setting = null;
            foreach (OfficialSetting setting2 in this._officialInfos)
            {
                if (setting2.type == platformType)
                {
                    setting = setting2;
                    break;
                }
            }
            if (setting == null)
            {
                return string.Empty;
            }
            foreach (ChannelSetting setting3 in setting.channelSetting)
            {
                if (setting3.channelId == channelId)
                {
                    return setting3.value;
                }
            }
            return setting.value;
        }

        public OperationActivity GetOperationActivityByType(int activityType)
        {
            foreach (OperationActivity activity in this.operationActivitys)
            {
                if (activity.activityType == activityType)
                {
                    return activity;
                }
            }
            return null;
        }

        public int GetRowIndexInFormation(int position)
        {
            return (position / this.maxColumnInFormation);
        }

        public int GetShowAttributeSortIndex(int attributeType)
        {
            for (int i = 0; i < this._showingAttributes.Count; i++)
            {
                if (this._showingAttributes[i].attributeType == attributeType)
                {
                    return this._showingAttributes[i].attributeSortIndex;
                }
            }
            return 0;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        private void LoadActiveCodeSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Setting")
                    {
                        this._activeCodeSet.Add(this.LoadOfficialSetting(element2));
                    }
                }
            }
        }

        private AndroidEscapeKey LoadAndroidEscapeKeyConfigFromXml(SecurityElement element)
        {
            AndroidEscapeKey key = new AndroidEscapeKey {
                open = StrParser.ParseBool(element.Attribute("Open"), false)
            };
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "IgnoreUI")
                {
                    key.ignoreUI.Add(TypeNameContainer<_UIType>.Parse(element2.Text, 0));
                }
            }
            return key;
        }

        private BattleDefault LoadBattleDefaultFromXml(SecurityElement element)
        {
            BattleDefault default2 = new BattleDefault();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "BattleDefaultItem"))
                    {
                        default2.battleDefaultItems.Add(this.LoadBattleDefaultItemFromXml(element2));
                    }
                }
            }
            return default2;
        }

        private BattleDefault.BattleDefaultItem LoadBattleDefaultItemFromXml(SecurityElement element)
        {
            return new BattleDefault.BattleDefaultItem { 
                combatType = TypeNameContainer<_CombatType>.Parse(element.Attribute("CombatType"), 0),
                sceneCamAngleHDefault = StrParser.ParseFloat(element.Attribute("SceneCamAngleHDefault"), 0f)
            };
        }

        private BattleScore LoadBattleScroe(SecurityElement element)
        {
            return new BattleScore { 
                star2Factor = StrParser.ParseDecInt(element.Attribute("Star2Factor"), 0),
                star3Factor = StrParser.ParseDecInt(element.Attribute("Star3Factor"), 0)
            };
        }

        private CombatMusic LoadCombatMusicConfigFromXml(SecurityElement element)
        {
            CombatMusic music = new CombatMusic();
            if (element.Tag == "CombatMusic")
            {
                music.combatWin = StrParser.ParseStr(element.Attribute("Win"), "");
                music.combatFail = StrParser.ParseStr(element.Attribute("Fail"), "");
            }
            return music;
        }

        private CombatSetting LoadCombatSettingFromXml(SecurityElement element)
        {
            CombatSetting setting = new CombatSetting();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    switch (element2.Tag)
                    {
                        case "BattleDefault":
                            setting.battleDefault = this.LoadBattleDefaultFromXml(element2);
                            break;

                        case "DamageFloatFactor":
                            setting.damageFloatFactor = StrParser.ParseFloat(element2.Text, 0f);
                            break;

                        case "RunSpeed":
                            setting.runSpeed = StrParser.ParseFloat(element2.Text, 1f);
                            break;

                        case "RunToBossSpeed":
                            setting.runToBossSpeed = StrParser.ParseFloat(element2.Text, 1f);
                            break;

                        case "AttackRunSpeed":
                            setting.attackRunSpeed = StrParser.ParseFloat(element2.Text, 1f);
                            break;

                        case "JumpSpeed":
                            setting.jumpSpeed = StrParser.ParseFloat(element2.Text, 1f);
                            break;

                        case "CoverPostionSpeed":
                            setting.coverPostionSpeed = StrParser.ParseFloat(element2.Text, 1f);
                            break;

                        case "SwitchColumnSpeed":
                            setting.switchColumnSpeed = StrParser.ParseFloat(element2.Text, 1f);
                            break;

                        case "CameraTraceOffset":
                            setting.cameraTraceOffset = StrParser.ParseFloat(element2.Text, 0f);
                            break;

                        case "BaseAttribute":
                            setting.baseAttributes.Add(ClientServerCommon.Attribute.LoadFromXml(element2));
                            break;

                        case "MaxSkillPower":
                            setting.maxSkillPower = StrParser.ParseFloat(element2.Text, 0f);
                            break;

                        case "RoundSkillPowerDelta":
                            setting.roundSkillPowerDelta = StrParser.ParseStr(element2.Text, "");
                            break;

                        case "KillSkillPowerDelta":
                            setting.killSkillPowerDelta = StrParser.ParseFloat(element2.Text, 0f);
                            break;

                        case "NormalAttackDelayTime":
                            setting.normalAttackDelayTime = StrParser.ParseFloat(element2.Text, 0f);
                            break;

                        case "TeamAttribute":
                            setting.teamAttributes.Add(ClientServerCommon.Attribute.LoadFromXml(element2));
                            break;

                        case "MaxRound":
                            setting.maxRound = StrParser.ParseDecInt(element2.Text, 0);
                            break;

                        case "DmgHealStartDuration":
                            setting.dmgHealStartDuration = StrParser.ParseFloat(element2.Text, 0.2f);
                            break;

                        case "DmgHealEventDelta":
                            setting.dmgHealEventDelta = StrParser.ParseFloat(element2.Text, 0.2f);
                            break;
                    }
                }
            }
            return setting;
        }

        private void LoadCombatSkipSetting(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Setting")
                    {
                        CombatSkipSetting item = new CombatSkipSetting {
                            combatType = TypeNameContainer<_CombatType>.Parse(element2.Attribute("CombatType"), 0),
                            rating = StrParser.ParseDecInt(element2.Attribute("Rating"), 0),
                            canSkip = StrParser.ParseBool(element2.Attribute("CanSkip"), false),
                            delayTime = StrParser.ParseDecInt(element2.Attribute("DelayTime"), 0),
                            playerLevel = StrParser.ParseDecInt(element2.Attribute("PlayerLevel"), 0),
                            vipLevel = StrParser.ParseDecInt(element2.Attribute("VipLevel"), 0)
                        };
                        this._combatSkipSettings.Add(item);
                    }
                }
            }
        }

        private ContinueCombat LoadContinueCombatSetting(SecurityElement element)
        {
            ContinueCombat combat = new ContinueCombat();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "MaxContinueCombatCount")
                        {
                            if (tag == "ContinueCombatOpenLevel")
                            {
                                goto Label_0085;
                            }
                            if (tag == "EnableThreeStarLimit")
                            {
                                goto Label_0099;
                            }
                            if (tag == "ClearCoolDownCost")
                            {
                                goto Label_00AD;
                            }
                        }
                        else
                        {
                            combat.maxContinueCombatCount = StrParser.ParseDecInt(element2.Text, 0);
                        }
                    }
                    continue;
                Label_0085:
                    combat.continueCombatOpenLevel = StrParser.ParseDecInt(element2.Text, 0);
                    continue;
                Label_0099:
                    combat.enableThreeStarLimit = StrParser.ParseBool(element2.Text, false);
                    continue;
                Label_00AD:
                    combat.clearCoolDownCosts.Add(Cost.LoadFromXml(element2));
                }
            }
            return combat;
        }

        private FriendConfig LoadFriendConfigFromXml(SecurityElement element)
        {
            return new FriendConfig { randomFriendNum = StrParser.ParseDecInt(element.Attribute("RandomFriendNum"), 1) };
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "GameConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    switch (element2.Tag)
                    {
                        case "CombatSetting":
                            this._combatSetting = this.LoadCombatSettingFromXml(element2);
                            break;

                        case "StaminaGenerateTime":
                            this._staminaGenerateTime = StrParser.ParseDecInt(element2.Text, this._staminaGenerateTime);
                            break;

                        case "PVPStaminaGenerateTime":
                            this._pvpStaminaGenerateTime = StrParser.ParseDecInt(element2.Text, this._pvpStaminaGenerateTime);
                            break;

                        case "RestoreUseStaminaItemTime":
                            this._restoreUseStaminaItemTime = StrParser.ParseDateTime(element2.Text);
                            break;

                        case "RestoreUsePvpStaminaItemTime":
                            this._restoreUsePvpStaminaItemTime = StrParser.ParseDateTime(element2.Text);
                            break;

                        case "RestoreResetDungeonCompleteTime":
                            this._restoreResetDungeonCompleteTime = StrParser.ParseDateTime(element2.Text);
                            break;

                        case "EnergyGenerateTime":
                            this._energyGenerateTime = StrParser.ParseDecInt(element2.Text, this._energyGenerateTime);
                            break;

                        case "RestoreUseEnergyItemTime":
                            this._restoreUseEnergyItemTime = StrParser.ParseDateTime(element2.Text);
                            break;

                        case "MaxEnergy":
                            this._maxEnergy = StrParser.ParseDecInt(element2.Text, this._maxEnergy);
                            break;

                        case "MaxRowInFormation":
                            this._maxRowInFormation = StrParser.ParseDecInt(element2.Text, this._maxRowInFormation);
                            break;

                        case "MaxRowInFormationCanUse":
                            this._maxRowInFormationCanUse = StrParser.ParseDecInt(element2.Text, this._maxRowInFormationCanUse);
                            break;

                        case "MaxColumnInFormation":
                            this._maxColumnInFormation = StrParser.ParseDecInt(element2.Text, this._maxColumnInFormation);
                            break;

                        case "ConsignmentExpiredTime":
                            this._consignmentExpiredTime = StrParser.ParseDecInt(element2.Text, this._consignmentExpiredTime);
                            break;

                        case "ConsignmentAmountEveryPage":
                            this._consignmentAmountEveryPage = StrParser.ParseDecInt(element2.Text, this._consignmentAmountEveryPage);
                            break;

                        case "MinConsignmentLevel":
                            this._minConsignmentLevel = StrParser.ParseDecInt(element2.Text, this._minConsignmentLevel);
                            break;

                        case "MaxConsignmentCount":
                            this._maxConsignmentCount = StrParser.ParseDecInt(element2.Text, this._maxConsignmentCount);
                            break;

                        case "TrainingFactor":
                            this._trainingFactors.Add(this.LoadTrainingFactorFromXml(element2));
                            break;

                        case "QueryConsignmentListCount":
                            this._queryConsignmentListCount = StrParser.ParseDecInt(element2.Text, this._queryConsignmentListCount);
                            break;

                        case "Setting":
                            this._setting = this.LoadSettingFromXml(element2);
                            break;

                        case "FriendConfig":
                            this._friendConfig = this.LoadFriendConfigFromXml(element2);
                            break;

                        case "WorldChatConfig":
                            this._worldChatCfg = this.LoadWorldChatConfigFromXml(element2);
                            break;

                        case "CampaignBattleScore":
                            this.campaignBattleScore = this.LoadBattleScroe(element2);
                            break;

                        case "OtherBattleScore":
                            this.otherBattleScore = this.LoadBattleScroe(element2);
                            break;

                        case "RobSkillConfig":
                            this._robSkillConfig = this.LoadRobConfigFromXml(element2);
                            break;

                        case "RobEquipConfig":
                            this._robEquipConfig = this.LoadRobConfigFromXml(element2);
                            break;

                        case "RecoveryConfig":
                            this._recoveryConfig = this.LoadRecoveryConfigFromXml(element2);
                            break;

                        case "InitAvatarConfig":
                            this._initAvatarConfig = this.LoadInitAvatarConfigFromXml(element2);
                            break;

                        case "CombatMusic":
                            this._combatMusic = this.LoadCombatMusicConfigFromXml(element2);
                            break;

                        case "PlayerNameMax":
                            this._playerNameMax = StrParser.ParseDecInt(element2.Text, this._playerNameMax);
                            break;

                        case "UIShowSetting":
                            this._uiShowSetting = this.LoadUIShowSettingFromXml(element2);
                            break;

                        case "CombatSkipSetting":
                            this.LoadCombatSkipSetting(element2);
                            break;

                        case "ContinueCombat":
                            this._continueCombat = this.LoadContinueCombatSetting(element2);
                            break;

                        case "WuXiaFengYunContinueLoginReward":
                            this._wuXiaLoginReward = this.LoadWuXiaFengYunContinueLoginReward(element2);
                            break;

                        case "OfficialSetting":
                            this.LoadOfficialSettings(element2);
                            break;

                        case "DisableRecharge":
                            this._disableRecharge = StrParser.ParseBool(element2.Text, false);
                            break;

                        case "ShowingAttributeSet":
                            this.LoadShowingAttributeFromXml(element2);
                            break;

                        case "LoadingSetting":
                            this.LoadLoadingSettingFromXml(element2);
                            break;

                        case "IsShowAd":
                            this._isShowAd = StrParser.ParseBool(element2.Text, false);
                            break;

                        case "IsShowWebPage":
                            this._isShowWebPage = StrParser.ParseBool(element2.Text, false);
                            break;

                        case "IsShowFacebook":
                            this._isShowFacebook = StrParser.ParseBool(element2.Text, false);
                            break;

                        case "RecordPositionSet":
                            this.LoadRecordPositionSetFormXml(element2);
                            break;

                        case "RecordBattleAngleSet":
                            this.LoadRecordBattleAngleSetFormXml(element2);
                            break;

                        case "isShowAc":
                            this._isShowAc = StrParser.ParseBool(element2.Text, false);
                            break;

                        case "ActiveCodeSet":
                            this.LoadActiveCodeSetFromXml(element2);
                            break;

                        case "AndroidEscapeKey":
                            this._androidEscapeKey = this.LoadAndroidEscapeKeyConfigFromXml(element2);
                            break;

                        case "IsInviteCode":
                            this._isInviteCode = StrParser.ParseBool(element2.Text, false);
                            break;

                        case "IsShowAvatarUpDan":
                            this._isShowAvatarUpDan = StrParser.ParseBool(element2.Text, false);
                            break;

                        case "IsConvertExpain":
                            this._isConvertExpain = StrParser.ParseBool(element2.Text, false);
                            break;

                        case "OperationActivitySet":
                            this.LoadOperationActivitySetFromXml(element2);
                            break;
                    }
                }
            }
        }

        private InitAvatarConfig LoadInitAvatarConfigFromXml(SecurityElement element)
        {
            InitAvatarConfig config = new InitAvatarConfig {
                selectPlayerAvatarTutorialId = StrParser.ParseHexInt(element.Attribute("SelectPlayerAvatarTutorialID"), 0),
                forceTutorialEndId = StrParser.ParseHexInt(element.Attribute("ForceTutorialEndID"), 0),
                tutorialAnimationId = StrParser.ParseHexInt(element.Attribute("TutorialAnimationId"), 0),
                defaultNormalCampaignIndex = StrParser.ParseDecInt(element.Attribute("DefaultNormalCampaignIndex"), 0),
                combatEndId = StrParser.ParseHexInt(element.Attribute("CombatEndId"), 0),
                assistantParticleCloseLevel = StrParser.ParseDecInt(element.Attribute("AssistantParticleCloseLevel"), 0),
                tutorialEndLevel = StrParser.ParseDecInt(element.Attribute("TutorialEndLevel"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "InitAvatar")
                    {
                        InitAvatarConfig.InitAvatar item = new InitAvatarConfig.InitAvatar {
                            avatarResourceId = StrParser.ParseHexInt(element2.Attribute("Id"), 0),
                            avatarDesc = StrParser.ParseStr(element2.Attribute("Desc"), string.Empty, true),
                            avatarTraitDesc = StrParser.ParseStr(element2.Attribute("TraitDesc"), string.Empty, true)
                        };
                        config.initAvatars.Add(item);
                    }
                }
            }
            return config;
        }

        private void LoadLoadingSettingFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Loading")
                    {
                        LoadingSetting item = new LoadingSetting {
                            id = StrParser.ParseHexInt(element2.Attribute("Id"), 0)
                        };
                        this._loadingSettings.Add(item);
                    }
                }
            }
        }

        private OfficialSetting LoadOfficialSetting(SecurityElement element)
        {
            OfficialSetting setting = new OfficialSetting {
                type = TypeNameContainer<_PlatformType>.Parse(element.Attribute("Type"), 0),
                value = StrParser.ParseStr(element.Attribute("Value"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "ChannelSetting")
                    {
                        ChannelSetting item = new ChannelSetting {
                            channelId = StrParser.ParseDecInt(element2.Attribute("ChannelId"), 0),
                            value = StrParser.ParseStr(element2.Attribute("Value"), "")
                        };
                        setting.channelSetting.Add(item);
                    }
                }
            }
            return setting;
        }

        private void LoadOfficialSettings(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "OfficialForumURLSet")
                        {
                            if (element2.Children != null)
                            {
                                foreach (SecurityElement element3 in element2.Children)
                                {
                                    if (element3.Tag == "Setting")
                                    {
                                        this._officialForumURLs.Add(this.LoadOfficialSetting(element3));
                                    }
                                }
                            }
                        }
                        else if (tag == "OfficialInfoSet")
                        {
                            goto Label_00C2;
                        }
                    }
                    continue;
                Label_00C2:
                    if (element2.Children != null)
                    {
                        foreach (SecurityElement element4 in element2.Children)
                        {
                            if (element4.Tag == "Setting")
                            {
                                this._officialInfos.Add(this.LoadOfficialSetting(element4));
                            }
                        }
                    }
                }
            }
        }

        private void LoadOperationActivitySetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "OperationActivity")
                    {
                        OperationActivity item = new OperationActivity {
                            activityType = TypeNameContainer<ClientServerCommon._ActivityType>.Parse(element2.Attribute("ActivityType"), 0),
                            activityIndex = StrParser.ParseDecInt(element2.Attribute("ActivityIndex"), 0),
                            activityIcon = StrParser.ParseHexInt(element2.Attribute("ActivityIcon"), 0)
                        };
                        this.operationActivitys.Add(item);
                    }
                }
            }
        }

        private void LoadRecordBattleAngleSetFormXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "RecordBattleAngle")
                    {
                        RecordLocalBattle item = new RecordLocalBattle {
                            battleType = TypeNameContainer<_CombatType>.Parse(element2.Attribute("CombatType"), 0),
                            record = StrParser.ParseBool(element2.Attribute("Record"), false)
                        };
                        this._recordLocalBattleAngles.Add(item);
                    }
                }
            }
        }

        private void LoadRecordPositionSetFormXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "RecordLocalPosition")
                    {
                        RecordLocalBattle item = new RecordLocalBattle {
                            battleType = TypeNameContainer<_CombatType>.Parse(element2.Attribute("CombatType"), 0),
                            record = StrParser.ParseBool(element2.Attribute("Record"), false)
                        };
                        this._recordLocalPositions.Add(item);
                    }
                }
            }
        }

        private RecoveryConfig LoadRecoveryConfigFromXml(SecurityElement element)
        {
            RecoveryConfig config = new RecoveryConfig();
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "RecoveryItem")
                    {
                        RecoveryItem item = new RecoveryItem {
                            assetId = StrParser.ParseHexInt(element2.Attribute("AssetId"), 0),
                            goodsId = StrParser.ParseHexInt(element2.Attribute("GoodsId"), 0)
                        };
                        config.recoveryItems.Add(item);
                    }
                }
            }
            return config;
        }

        private RobConfig LoadRobConfigFromXml(SecurityElement element)
        {
            RobConfig config = new RobConfig {
                robberMaxNum = StrParser.ParseDecInt(element.Attribute("RobberMaxNum"), 20),
                robberShowNum = StrParser.ParseDecInt(element.Attribute("RobberShowNum"), 3),
                robShowNum = StrParser.ParseDecInt(element.Attribute("RobShowNum"), 3),
                randRateExpression = StrParser.ParseStr(element.Attribute("RandRateExpression"), "0.1"),
                dLevelLower = StrParser.ParseDecInt(element.Attribute("DLevelLower"), 1),
                dLevelUpper = StrParser.ParseDecInt(element.Attribute("DLevelUpper"), 3),
                combatLoserGiveFactor_Experience = StrParser.ParseFloat(element.Attribute("CombatLoserGiveFactor_Experience"), 0f)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "RobCost"))
                    {
                        config.cost = Cost.LoadFromXml(element2);
                    }
                }
            }
            return config;
        }

        private Setting LoadSettingFromXml(SecurityElement element)
        {
            return new Setting { 
                forumURL = StrParser.ParseStr(element.Attribute("ForumURL"), ""),
                officialInfo = StrParser.ParseStr(element.Attribute("OfficialInfo"), ""),
                showInvite = StrParser.ParseBool(element.Attribute("ShowInvite"), false)
            };
        }

        private void LoadShowingAttributeFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "ShowingAttribute")
                    {
                        ShowingAttribute item = new ShowingAttribute {
                            attributeType = TypeNameContainer<_AvatarAttributeType>.Parse(element2.Attribute("Type"), 0),
                            attributeSortIndex = StrParser.ParseDecInt(element2.Attribute("SortIndex"), 0)
                        };
                        this._showingAttributes.Add(item);
                    }
                }
            }
        }

        private TrainingFactor LoadTrainingFactorFromXml(SecurityElement element)
        {
            return new TrainingFactor { 
                attributeType = TypeNameContainer<_AvatarAttributeType>.Parse(element.Attribute("AttributeType"), 0),
                factor = StrParser.ParseFloat(element.Attribute("Factor"), 0f)
            };
        }

        private UIShowSetting LoadUIShowSettingFromXml(SecurityElement element)
        {
            return new UIShowSetting { 
                maxCountItemInUI = StrParser.ParseDecInt(element.Attribute("MaxCountItemInUI"), 0),
                piecePageCount = StrParser.ParseDecInt(element.Attribute("PiecePageCount"), 0)
            };
        }

        private WorldChatConfig LoadWorldChatConfigFromXml(SecurityElement element)
        {
            WorldChatConfig config = new WorldChatConfig();
            if (element.Tag == "WorldChatConfig")
            {
                config.count = StrParser.ParseDecInt(element.Attribute("Count"), 10);
                config.resetTime = StrParser.ParseDateTime(element.Attribute("ResetTime"));
            }
            return config;
        }

        private WuXiaFengYunContinueLoginReward LoadWuXiaFengYunContinueLoginReward(SecurityElement element)
        {
            return new WuXiaFengYunContinueLoginReward { rewardSetId = StrParser.ParseHexInt(element.Attribute("Id"), 0) };
        }

        [ProtoMember(0x2b, Name="activeCodeSet", DataFormat=DataFormat.Default)]
        public List<OfficialSetting> activeCodeSet
        {
            get
            {
                return this._activeCodeSet;
            }
        }

        [ProtoMember(0x2c, IsRequired=false, Name="androidEscapeKey", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public AndroidEscapeKey androidEscapeKey
        {
            get
            {
                return this._androidEscapeKey;
            }
            set
            {
                this._androidEscapeKey = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x13, IsRequired=false, Name="campaignBattleScore", DataFormat=DataFormat.Default)]
        public BattleScore campaignBattleScore
        {
            get
            {
                return this._campaignBattleScore;
            }
            set
            {
                this._campaignBattleScore = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x18, IsRequired=false, Name="combatMusic", DataFormat=DataFormat.Default)]
        public CombatMusic combatMusic
        {
            get
            {
                return this._combatMusic;
            }
            set
            {
                this._combatMusic = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(1, IsRequired=false, Name="combatSetting", DataFormat=DataFormat.Default)]
        public CombatSetting combatSetting
        {
            get
            {
                return this._combatSetting;
            }
            set
            {
                this._combatSetting = value;
            }
        }

        [ProtoMember(0x1f, Name="combatSkipSettings", DataFormat=DataFormat.Default)]
        public List<CombatSkipSetting> combatSkipSettings
        {
            get
            {
                return this._combatSkipSettings;
            }
        }

        [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="consignmentAmountEveryPage", DataFormat=DataFormat.TwosComplement)]
        public int consignmentAmountEveryPage
        {
            get
            {
                return this._consignmentAmountEveryPage;
            }
            set
            {
                this._consignmentAmountEveryPage = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="consignmentExpiredTime", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int consignmentExpiredTime
        {
            get
            {
                return this._consignmentExpiredTime;
            }
            set
            {
                this._consignmentExpiredTime = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x20, IsRequired=false, Name="continueCombat", DataFormat=DataFormat.Default)]
        public ContinueCombat continueCombat
        {
            get
            {
                return this._continueCombat;
            }
            set
            {
                this._continueCombat = value;
            }
        }

        [ProtoMember(0x24, IsRequired=false, Name="disableRecharge", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool disableRecharge
        {
            get
            {
                return this._disableRecharge;
            }
            set
            {
                this._disableRecharge = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x2d, IsRequired=false, Name="energyGenerateTime", DataFormat=DataFormat.TwosComplement)]
        public int energyGenerateTime
        {
            get
            {
                return this._energyGenerateTime;
            }
            set
            {
                this._energyGenerateTime = value;
            }
        }

        [ProtoMember(0x11, IsRequired=false, Name="friendConfig", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public FriendConfig friendConfig
        {
            get
            {
                return this._friendConfig;
            }
            set
            {
                this._friendConfig = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x17, IsRequired=false, Name="initAvatarConfig", DataFormat=DataFormat.Default)]
        public InitAvatarConfig initAvatarConfig
        {
            get
            {
                return this._initAvatarConfig;
            }
            set
            {
                this._initAvatarConfig = value;
            }
        }

        [DefaultValue(false), ProtoMember(50, IsRequired=false, Name="isConvertExpain", DataFormat=DataFormat.Default)]
        public bool isConvertExpain
        {
            get
            {
                return this._isConvertExpain;
            }
            set
            {
                this._isConvertExpain = value;
            }
        }

        [ProtoMember(0x31, IsRequired=false, Name="isInviteCode", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isInviteCode
        {
            get
            {
                return this._isInviteCode;
            }
            set
            {
                this._isInviteCode = value;
            }
        }

        [DefaultValue(false), ProtoMember(0x2a, IsRequired=false, Name="isShowAc", DataFormat=DataFormat.Default)]
        public bool isShowAc
        {
            get
            {
                return this._isShowAc;
            }
            set
            {
                this._isShowAc = value;
            }
        }

        [ProtoMember(0x27, IsRequired=false, Name="isShowAd", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isShowAd
        {
            get
            {
                return this._isShowAd;
            }
            set
            {
                this._isShowAd = value;
            }
        }

        [ProtoMember(0x33, IsRequired=false, Name="isShowAvatarUpDan", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isShowAvatarUpDan
        {
            get
            {
                return this._isShowAvatarUpDan;
            }
            set
            {
                this._isShowAvatarUpDan = value;
            }
        }

        [ProtoMember(0x35, IsRequired=false, Name="isShowFacebook", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isShowFacebook
        {
            get
            {
                return this._isShowFacebook;
            }
            set
            {
                this._isShowFacebook = value;
            }
        }

        [DefaultValue(false), ProtoMember(0x34, IsRequired=false, Name="isShowWebPage", DataFormat=DataFormat.Default)]
        public bool isShowWebPage
        {
            get
            {
                return this._isShowWebPage;
            }
            set
            {
                this._isShowWebPage = value;
            }
        }

        [ProtoMember(0x26, Name="loadingSettings", DataFormat=DataFormat.Default)]
        public List<LoadingSetting> loadingSettings
        {
            get
            {
                return this._loadingSettings;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="maxColumnInFormation", DataFormat=DataFormat.TwosComplement)]
        public int maxColumnInFormation
        {
            get
            {
                return this._maxColumnInFormation;
            }
            set
            {
                this._maxColumnInFormation = value;
            }
        }

        [ProtoMember(13, IsRequired=false, Name="maxConsignmentCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int maxConsignmentCount
        {
            get
            {
                return this._maxConsignmentCount;
            }
            set
            {
                this._maxConsignmentCount = value;
            }
        }

        [ProtoMember(0x2e, IsRequired=false, Name="maxEnergy", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int maxEnergy
        {
            get
            {
                return this._maxEnergy;
            }
            set
            {
                this._maxEnergy = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="maxRowInFormation", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int maxRowInFormation
        {
            get
            {
                return this._maxRowInFormation;
            }
            set
            {
                this._maxRowInFormation = value;
            }
        }

        [ProtoMember(0x1c, IsRequired=false, Name="maxRowInFormationCanUse", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int maxRowInFormationCanUse
        {
            get
            {
                return this._maxRowInFormationCanUse;
            }
            set
            {
                this._maxRowInFormationCanUse = value;
            }
        }

        [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="minConsignmentLevel", DataFormat=DataFormat.TwosComplement)]
        public int minConsignmentLevel
        {
            get
            {
                return this._minConsignmentLevel;
            }
            set
            {
                this._minConsignmentLevel = value;
            }
        }

        [ProtoMember(0x22, Name="officialForumURLs", DataFormat=DataFormat.Default)]
        public List<OfficialSetting> officialForumURLs
        {
            get
            {
                return this._officialForumURLs;
            }
        }

        [ProtoMember(0x23, Name="officialInfos", DataFormat=DataFormat.Default)]
        public List<OfficialSetting> officialInfos
        {
            get
            {
                return this._officialInfos;
            }
        }

        [ProtoMember(0x30, Name="operationActivitys", DataFormat=DataFormat.Default)]
        public List<OperationActivity> operationActivitys
        {
            get
            {
                return this._operationActivitys;
            }
        }

        [DefaultValue((string) null), ProtoMember(20, IsRequired=false, Name="otherBattleScore", DataFormat=DataFormat.Default)]
        public BattleScore otherBattleScore
        {
            get
            {
                return this._otherBattleScore;
            }
            set
            {
                this._otherBattleScore = value;
            }
        }

        [ProtoMember(0x19, IsRequired=false, Name="playerNameMax", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int playerNameMax
        {
            get
            {
                return this._playerNameMax;
            }
            set
            {
                this._playerNameMax = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="pvpStaminaGenerateTime", DataFormat=DataFormat.TwosComplement)]
        public int pvpStaminaGenerateTime
        {
            get
            {
                return this._pvpStaminaGenerateTime;
            }
            set
            {
                this._pvpStaminaGenerateTime = value;
            }
        }

        [ProtoMember(15, IsRequired=false, Name="queryConsignmentListCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int queryConsignmentListCount
        {
            get
            {
                return this._queryConsignmentListCount;
            }
            set
            {
                this._queryConsignmentListCount = value;
            }
        }

        [ProtoMember(0x29, Name="recordLocalBattleAngles", DataFormat=DataFormat.Default)]
        public List<RecordLocalBattle> recordLocalBattleAngles
        {
            get
            {
                return this._recordLocalBattleAngles;
            }
        }

        [ProtoMember(40, Name="recordLocalPositions", DataFormat=DataFormat.Default)]
        public List<RecordLocalBattle> recordLocalPositions
        {
            get
            {
                return this._recordLocalPositions;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x16, IsRequired=false, Name="recoveryConfig", DataFormat=DataFormat.Default)]
        public RecoveryConfig recoveryConfig
        {
            get
            {
                return this._recoveryConfig;
            }
            set
            {
                this._recoveryConfig = value;
            }
        }

        public DateTime restoreResetDungeonCompleteDataTime
        {
            get
            {
                return new DateTime(this._restoreResetDungeonCompleteTime * 0x2710L);
            }
        }

        [ProtoMember(0x1b, IsRequired=false, Name="restoreResetDungeonCompleteTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long restoreResetDungeonCompleteTime
        {
            get
            {
                return this._restoreResetDungeonCompleteTime;
            }
            set
            {
                this._restoreResetDungeonCompleteTime = value;
            }
        }

        public DateTime restoreUseEnergyItemDataTime
        {
            get
            {
                return new DateTime(this._restoreUseEnergyItemTime * 0x2710L);
            }
        }

        [DefaultValue((long) 0L), ProtoMember(0x2f, IsRequired=false, Name="restoreUseEnergyItemTime", DataFormat=DataFormat.TwosComplement)]
        public long restoreUseEnergyItemTime
        {
            get
            {
                return this._restoreUseEnergyItemTime;
            }
            set
            {
                this._restoreUseEnergyItemTime = value;
            }
        }

        public DateTime restoreUsePvpStaminaItemDataTime
        {
            get
            {
                return new DateTime(this._restoreUsePvpStaminaItemTime * 0x2710L);
            }
        }

        [ProtoMember(5, IsRequired=false, Name="restoreUsePvpStaminaItemTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long restoreUsePvpStaminaItemTime
        {
            get
            {
                return this._restoreUsePvpStaminaItemTime;
            }
            set
            {
                this._restoreUsePvpStaminaItemTime = value;
            }
        }

        public DateTime restoreUseStaminaItemDataTime
        {
            get
            {
                return new DateTime(this._restoreUseStaminaItemTime * 0x2710L);
            }
        }

        [DefaultValue((long) 0L), ProtoMember(3, IsRequired=false, Name="restoreUseStaminaItemTime", DataFormat=DataFormat.TwosComplement)]
        public long restoreUseStaminaItemTime
        {
            get
            {
                return this._restoreUseStaminaItemTime;
            }
            set
            {
                this._restoreUseStaminaItemTime = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x1a, IsRequired=false, Name="robEquipConfig", DataFormat=DataFormat.Default)]
        public RobConfig robEquipConfig
        {
            get
            {
                return this._robEquipConfig;
            }
            set
            {
                this._robEquipConfig = value;
            }
        }

        [ProtoMember(0x15, IsRequired=false, Name="robSkillConfig", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public RobConfig robSkillConfig
        {
            get
            {
                return this._robSkillConfig;
            }
            set
            {
                this._robSkillConfig = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="robSkillScrollMatchDeltaAdd", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int robSkillScrollMatchDeltaAdd
        {
            get
            {
                return this._robSkillScrollMatchDeltaAdd;
            }
            set
            {
                this._robSkillScrollMatchDeltaAdd = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="robSkillScrollMatchDeltaSub", DataFormat=DataFormat.TwosComplement)]
        public int robSkillScrollMatchDeltaSub
        {
            get
            {
                return this._robSkillScrollMatchDeltaSub;
            }
            set
            {
                this._robSkillScrollMatchDeltaSub = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x10, IsRequired=false, Name="setting", DataFormat=DataFormat.Default)]
        public Setting setting
        {
            get
            {
                return this._setting;
            }
            set
            {
                this._setting = value;
            }
        }

        [ProtoMember(0x25, Name="showingAttributes", DataFormat=DataFormat.Default)]
        public List<ShowingAttribute> showingAttributes
        {
            get
            {
                return this._showingAttributes;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="staminaGenerateTime", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int staminaGenerateTime
        {
            get
            {
                return this._staminaGenerateTime;
            }
            set
            {
                this._staminaGenerateTime = value;
            }
        }

        [ProtoMember(14, Name="trainingFactors", DataFormat=DataFormat.Default)]
        public List<TrainingFactor> trainingFactors
        {
            get
            {
                return this._trainingFactors;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x1d, IsRequired=false, Name="uiShowSetting", DataFormat=DataFormat.Default)]
        public UIShowSetting uiShowSetting
        {
            get
            {
                return this._uiShowSetting;
            }
            set
            {
                this._uiShowSetting = value;
            }
        }

        [ProtoMember(0x12, IsRequired=false, Name="worldChatCfg", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public WorldChatConfig worldChatCfg
        {
            get
            {
                return this._worldChatCfg;
            }
            set
            {
                this._worldChatCfg = value;
            }
        }

        [ProtoMember(0x21, IsRequired=false, Name="wuXiaLoginReward", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public WuXiaFengYunContinueLoginReward wuXiaLoginReward
        {
            get
            {
                return this._wuXiaLoginReward;
            }
            set
            {
                this._wuXiaLoginReward = value;
            }
        }

        [ProtoContract(Name="AndroidEscapeKey")]
        public class AndroidEscapeKey : IExtensible
        {
            private readonly List<int> _ignoreUI = new List<int>();
            private bool _open;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="ignoreUI", DataFormat=DataFormat.TwosComplement)]
            public List<int> ignoreUI
            {
                get
                {
                    return this._ignoreUI;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="open", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool open
            {
                get
                {
                    return this._open;
                }
                set
                {
                    this._open = value;
                }
            }
        }

        [ProtoContract(Name="BattleDefault")]
        public class BattleDefault : IExtensible
        {
            private readonly List<BattleDefaultItem> _battleDefaultItems = new List<BattleDefaultItem>();
            private IExtension extensionObject;

            public BattleDefaultItem GetBattleDefaultItemByCombatType(int combatType)
            {
                return this.battleDefaultItems.Find(n => n.combatType == combatType);
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, Name="battleDefaultItems", DataFormat=DataFormat.Default)]
            public List<BattleDefaultItem> battleDefaultItems
            {
                get
                {
                    return this._battleDefaultItems;
                }
            }

            [ProtoContract(Name="BattleDefaultItem")]
            public class BattleDefaultItem : IExtensible
            {
                private int _combatType;
                private float _sceneCamAngleHDefault;
                private IExtension extensionObject;

                IExtension IExtensible.GetExtensionObject(bool createIfMissing)
                {
                    return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
                }

                [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="combatType", DataFormat=DataFormat.TwosComplement)]
                public int combatType
                {
                    get
                    {
                        return this._combatType;
                    }
                    set
                    {
                        this._combatType = value;
                    }
                }

                [DefaultValue((float) 0f), ProtoMember(2, IsRequired=false, Name="sceneCamAngleHDefault", DataFormat=DataFormat.FixedSize)]
                public float sceneCamAngleHDefault
                {
                    get
                    {
                        return this._sceneCamAngleHDefault;
                    }
                    set
                    {
                        this._sceneCamAngleHDefault = value;
                    }
                }
            }
        }

        [ProtoContract(Name="BattleScore")]
        public class BattleScore : IExtensible
        {
            private int _star2Factor;
            private int _star3Factor;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="star2Factor", DataFormat=DataFormat.TwosComplement)]
            public int star2Factor
            {
                get
                {
                    return this._star2Factor;
                }
                set
                {
                    this._star2Factor = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="star3Factor", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int star3Factor
            {
                get
                {
                    return this._star3Factor;
                }
                set
                {
                    this._star3Factor = value;
                }
            }
        }

        [ProtoContract(Name="ChannelSetting")]
        public class ChannelSetting : IExtensible
        {
            private int _channelId;
            private string _value = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="channelId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int channelId
            {
                get
                {
                    return this._channelId;
                }
                set
                {
                    this._channelId = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="value", DataFormat=DataFormat.Default)]
            public string value
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

        [ProtoContract(Name="CombatMusic")]
        public class CombatMusic : IExtensible
        {
            private string _combatFail = "";
            private string _combatWin = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="combatFail", DataFormat=DataFormat.Default), DefaultValue("")]
            public string combatFail
            {
                get
                {
                    return this._combatFail;
                }
                set
                {
                    this._combatFail = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="combatWin", DataFormat=DataFormat.Default), DefaultValue("")]
            public string combatWin
            {
                get
                {
                    return this._combatWin;
                }
                set
                {
                    this._combatWin = value;
                }
            }
        }

        [ProtoContract(Name="CombatSetting")]
        public class CombatSetting : IExtensible
        {
            private float _attackRunSpeed;
            private readonly List<ClientServerCommon.Attribute> _baseAttributes = new List<ClientServerCommon.Attribute>();
            private GameConfig.BattleDefault _battleDefault;
            private float _cameraTraceOffset;
            private float _coverPostionSpeed;
            private float _damageFloatFactor;
            private float _dmgHealEventDelta;
            private float _dmgHealStartDuration;
            private float _jumpSpeed;
            private float _killSkillPowerDelta;
            private int _maxRound;
            private float _maxSkillPower;
            private float _normalAttackDelayTime;
            private string _roundSkillPowerDelta = "";
            private float _runSpeed;
            private float _runToBossSpeed;
            private float _switchColumnSpeed;
            private readonly List<ClientServerCommon.Attribute> _teamAttributes = new List<ClientServerCommon.Attribute>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((float) 0f), ProtoMember(3, IsRequired=false, Name="attackRunSpeed", DataFormat=DataFormat.FixedSize)]
            public float attackRunSpeed
            {
                get
                {
                    return this._attackRunSpeed;
                }
                set
                {
                    this._attackRunSpeed = value;
                }
            }

            [ProtoMember(8, Name="baseAttributes", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.Attribute> baseAttributes
            {
                get
                {
                    return this._baseAttributes;
                }
            }

            [ProtoMember(0x10, IsRequired=false, Name="battleDefault", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public GameConfig.BattleDefault battleDefault
            {
                get
                {
                    return this._battleDefault;
                }
                set
                {
                    this._battleDefault = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="cameraTraceOffset", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float cameraTraceOffset
            {
                get
                {
                    return this._cameraTraceOffset;
                }
                set
                {
                    this._cameraTraceOffset = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(5, IsRequired=false, Name="coverPostionSpeed", DataFormat=DataFormat.FixedSize)]
            public float coverPostionSpeed
            {
                get
                {
                    return this._coverPostionSpeed;
                }
                set
                {
                    this._coverPostionSpeed = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(1, IsRequired=false, Name="damageFloatFactor", DataFormat=DataFormat.FixedSize)]
            public float damageFloatFactor
            {
                get
                {
                    return this._damageFloatFactor;
                }
                set
                {
                    this._damageFloatFactor = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(0x12, IsRequired=false, Name="dmgHealEventDelta", DataFormat=DataFormat.FixedSize)]
            public float dmgHealEventDelta
            {
                get
                {
                    return this._dmgHealEventDelta;
                }
                set
                {
                    this._dmgHealEventDelta = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(0x11, IsRequired=false, Name="dmgHealStartDuration", DataFormat=DataFormat.FixedSize)]
            public float dmgHealStartDuration
            {
                get
                {
                    return this._dmgHealStartDuration;
                }
                set
                {
                    this._dmgHealStartDuration = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="jumpSpeed", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float jumpSpeed
            {
                get
                {
                    return this._jumpSpeed;
                }
                set
                {
                    this._jumpSpeed = value;
                }
            }

            [ProtoMember(11, IsRequired=false, Name="killSkillPowerDelta", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float killSkillPowerDelta
            {
                get
                {
                    return this._killSkillPowerDelta;
                }
                set
                {
                    this._killSkillPowerDelta = value;
                }
            }

            [ProtoMember(14, IsRequired=false, Name="maxRound", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int maxRound
            {
                get
                {
                    return this._maxRound;
                }
                set
                {
                    this._maxRound = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(9, IsRequired=false, Name="maxSkillPower", DataFormat=DataFormat.FixedSize)]
            public float maxSkillPower
            {
                get
                {
                    return this._maxSkillPower;
                }
                set
                {
                    this._maxSkillPower = value;
                }
            }

            [ProtoMember(12, IsRequired=false, Name="normalAttackDelayTime", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float normalAttackDelayTime
            {
                get
                {
                    return this._normalAttackDelayTime;
                }
                set
                {
                    this._normalAttackDelayTime = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="roundSkillPowerDelta", DataFormat=DataFormat.Default), DefaultValue("")]
            public string roundSkillPowerDelta
            {
                get
                {
                    return this._roundSkillPowerDelta;
                }
                set
                {
                    this._roundSkillPowerDelta = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(2, IsRequired=false, Name="runSpeed", DataFormat=DataFormat.FixedSize)]
            public float runSpeed
            {
                get
                {
                    return this._runSpeed;
                }
                set
                {
                    this._runSpeed = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(15, IsRequired=false, Name="runToBossSpeed", DataFormat=DataFormat.FixedSize)]
            public float runToBossSpeed
            {
                get
                {
                    return this._runToBossSpeed;
                }
                set
                {
                    this._runToBossSpeed = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="switchColumnSpeed", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float switchColumnSpeed
            {
                get
                {
                    return this._switchColumnSpeed;
                }
                set
                {
                    this._switchColumnSpeed = value;
                }
            }

            [ProtoMember(13, Name="teamAttributes", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.Attribute> teamAttributes
            {
                get
                {
                    return this._teamAttributes;
                }
            }
        }

        [ProtoContract(Name="CombatSkipSetting")]
        public class CombatSkipSetting : IExtensible
        {
            private bool _canSkip;
            private int _combatType;
            private int _delayTime;
            private int _playerLevel;
            private int _rating;
            private int _vipLevel;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="canSkip", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool canSkip
            {
                get
                {
                    return this._canSkip;
                }
                set
                {
                    this._canSkip = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="combatType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int combatType
            {
                get
                {
                    return this._combatType;
                }
                set
                {
                    this._combatType = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="delayTime", DataFormat=DataFormat.TwosComplement)]
            public int delayTime
            {
                get
                {
                    return this._delayTime;
                }
                set
                {
                    this._delayTime = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="rating", DataFormat=DataFormat.TwosComplement)]
            public int rating
            {
                get
                {
                    return this._rating;
                }
                set
                {
                    this._rating = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoContract(Name="ContinueCombat")]
        public class ContinueCombat : IExtensible
        {
            private readonly List<Cost> _clearCoolDownCosts = new List<Cost>();
            private int _continueCombatOpenLevel;
            private bool _enableThreeStarLimit;
            private int _maxContinueCombatCount;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, Name="clearCoolDownCosts", DataFormat=DataFormat.Default)]
            public List<Cost> clearCoolDownCosts
            {
                get
                {
                    return this._clearCoolDownCosts;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="continueCombatOpenLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int continueCombatOpenLevel
            {
                get
                {
                    return this._continueCombatOpenLevel;
                }
                set
                {
                    this._continueCombatOpenLevel = value;
                }
            }

            [DefaultValue(false), ProtoMember(4, IsRequired=false, Name="enableThreeStarLimit", DataFormat=DataFormat.Default)]
            public bool enableThreeStarLimit
            {
                get
                {
                    return this._enableThreeStarLimit;
                }
                set
                {
                    this._enableThreeStarLimit = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="maxContinueCombatCount", DataFormat=DataFormat.TwosComplement)]
            public int maxContinueCombatCount
            {
                get
                {
                    return this._maxContinueCombatCount;
                }
                set
                {
                    this._maxContinueCombatCount = value;
                }
            }
        }

        [ProtoContract(Name="FriendConfig")]
        public class FriendConfig : IExtensible
        {
            private int _randomFriendNum;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="randomFriendNum", DataFormat=DataFormat.TwosComplement)]
            public int randomFriendNum
            {
                get
                {
                    return this._randomFriendNum;
                }
                set
                {
                    this._randomFriendNum = value;
                }
            }
        }

        [ProtoContract(Name="InitAvatarConfig")]
        public class InitAvatarConfig : IExtensible
        {
            private int _assistantParticleCloseLevel;
            private int _combatEndId;
            private int _defaultNormalCampaignIndex;
            private int _forceTutorialEndId;
            private readonly List<InitAvatar> _initAvatars = new List<InitAvatar>();
            private int _selectPlayerAvatarTutorialId;
            private int _tutorialAnimationId;
            private int _tutorialEndLevel;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="assistantParticleCloseLevel", DataFormat=DataFormat.TwosComplement)]
            public int assistantParticleCloseLevel
            {
                get
                {
                    return this._assistantParticleCloseLevel;
                }
                set
                {
                    this._assistantParticleCloseLevel = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="combatEndId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int combatEndId
            {
                get
                {
                    return this._combatEndId;
                }
                set
                {
                    this._combatEndId = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="defaultNormalCampaignIndex", DataFormat=DataFormat.TwosComplement)]
            public int defaultNormalCampaignIndex
            {
                get
                {
                    return this._defaultNormalCampaignIndex;
                }
                set
                {
                    this._defaultNormalCampaignIndex = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="forceTutorialEndId", DataFormat=DataFormat.TwosComplement)]
            public int forceTutorialEndId
            {
                get
                {
                    return this._forceTutorialEndId;
                }
                set
                {
                    this._forceTutorialEndId = value;
                }
            }

            [ProtoMember(1, Name="initAvatars", DataFormat=DataFormat.Default)]
            public List<InitAvatar> initAvatars
            {
                get
                {
                    return this._initAvatars;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="selectPlayerAvatarTutorialId", DataFormat=DataFormat.TwosComplement)]
            public int selectPlayerAvatarTutorialId
            {
                get
                {
                    return this._selectPlayerAvatarTutorialId;
                }
                set
                {
                    this._selectPlayerAvatarTutorialId = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="tutorialAnimationId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int tutorialAnimationId
            {
                get
                {
                    return this._tutorialAnimationId;
                }
                set
                {
                    this._tutorialAnimationId = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="tutorialEndLevel", DataFormat=DataFormat.TwosComplement)]
            public int tutorialEndLevel
            {
                get
                {
                    return this._tutorialEndLevel;
                }
                set
                {
                    this._tutorialEndLevel = value;
                }
            }

            [ProtoContract(Name="InitAvatar")]
            public class InitAvatar : IExtensible
            {
                private string _avatarDesc = "";
                private int _avatarResourceId;
                private string _avatarTraitDesc = "";
                private IExtension extensionObject;

                IExtension IExtensible.GetExtensionObject(bool createIfMissing)
                {
                    return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
                }

                [ProtoMember(2, IsRequired=false, Name="avatarDesc", DataFormat=DataFormat.Default), DefaultValue("")]
                public string avatarDesc
                {
                    get
                    {
                        return this._avatarDesc;
                    }
                    set
                    {
                        this._avatarDesc = value;
                    }
                }

                [ProtoMember(1, IsRequired=false, Name="avatarResourceId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
                public int avatarResourceId
                {
                    get
                    {
                        return this._avatarResourceId;
                    }
                    set
                    {
                        this._avatarResourceId = value;
                    }
                }

                [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="avatarTraitDesc", DataFormat=DataFormat.Default)]
                public string avatarTraitDesc
                {
                    get
                    {
                        return this._avatarTraitDesc;
                    }
                    set
                    {
                        this._avatarTraitDesc = value;
                    }
                }
            }
        }

        [ProtoContract(Name="LoadingSetting")]
        public class LoadingSetting : IExtensible
        {
            private int _id;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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
        }

        [ProtoContract(Name="OfficialSetting")]
        public class OfficialSetting : IExtensible
        {
            private readonly List<GameConfig.ChannelSetting> _channelSetting = new List<GameConfig.ChannelSetting>();
            private int _type;
            private string _value = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, Name="channelSetting", DataFormat=DataFormat.Default)]
            public List<GameConfig.ChannelSetting> channelSetting
            {
                get
                {
                    return this._channelSetting;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
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

            [ProtoMember(2, IsRequired=false, Name="value", DataFormat=DataFormat.Default), DefaultValue("")]
            public string value
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

        [ProtoContract(Name="OperationActivity")]
        public class OperationActivity : IExtensible
        {
            private int _activityIcon;
            private int _activityIndex;
            private int _activityType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="activityIcon", DataFormat=DataFormat.TwosComplement)]
            public int activityIcon
            {
                get
                {
                    return this._activityIcon;
                }
                set
                {
                    this._activityIcon = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="activityIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int activityIndex
            {
                get
                {
                    return this._activityIndex;
                }
                set
                {
                    this._activityIndex = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="activityType", DataFormat=DataFormat.TwosComplement)]
            public int activityType
            {
                get
                {
                    return this._activityType;
                }
                set
                {
                    this._activityType = value;
                }
            }
        }

        [ProtoContract(Name="RecordLocalBattle")]
        public class RecordLocalBattle : IExtensible
        {
            private int _battleType;
            private bool _record;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="battleType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int battleType
            {
                get
                {
                    return this._battleType;
                }
                set
                {
                    this._battleType = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="record", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool record
            {
                get
                {
                    return this._record;
                }
                set
                {
                    this._record = value;
                }
            }
        }

        [ProtoContract(Name="RecoveryConfig")]
        public class RecoveryConfig : IExtensible
        {
            private readonly List<GameConfig.RecoveryItem> _recoveryItems = new List<GameConfig.RecoveryItem>();
            private IExtension extensionObject;

            public int GetGoodsIdByAssetId(int assetId)
            {
                foreach (GameConfig.RecoveryItem item in this.recoveryItems)
                {
                    if (item.assetId == assetId)
                    {
                        return item.goodsId;
                    }
                }
                return 0;
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, Name="recoveryItems", DataFormat=DataFormat.Default)]
            public List<GameConfig.RecoveryItem> recoveryItems
            {
                get
                {
                    return this._recoveryItems;
                }
            }
        }

        [ProtoContract(Name="RecoveryItem")]
        public class RecoveryItem : IExtensible
        {
            private int _assetId;
            private int _goodsId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="assetId", DataFormat=DataFormat.TwosComplement)]
            public int assetId
            {
                get
                {
                    return this._assetId;
                }
                set
                {
                    this._assetId = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="goodsId", DataFormat=DataFormat.TwosComplement)]
            public int goodsId
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
        }

        [ProtoContract(Name="RobConfig")]
        public class RobConfig : IExtensible
        {
            private float _combatLoserGiveFactor_Experience;
            private Cost _cost;
            private int _dLevelLower;
            private int _dLevelUpper;
            private string _randRateExpression = "";
            private int _robberMaxNum;
            private int _robberShowNum;
            private int _robShowNum;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((float) 0f), ProtoMember(8, IsRequired=false, Name="combatLoserGiveFactor_Experience", DataFormat=DataFormat.FixedSize)]
            public float combatLoserGiveFactor_Experience
            {
                get
                {
                    return this._combatLoserGiveFactor_Experience;
                }
                set
                {
                    this._combatLoserGiveFactor_Experience = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="cost", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public Cost cost
            {
                get
                {
                    return this._cost;
                }
                set
                {
                    this._cost = value;
                }
            }

            [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="dLevelLower", DataFormat=DataFormat.TwosComplement)]
            public int dLevelLower
            {
                get
                {
                    return this._dLevelLower;
                }
                set
                {
                    this._dLevelLower = value;
                }
            }

            [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="dLevelUpper", DataFormat=DataFormat.TwosComplement)]
            public int dLevelUpper
            {
                get
                {
                    return this._dLevelUpper;
                }
                set
                {
                    this._dLevelUpper = value;
                }
            }

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="randRateExpression", DataFormat=DataFormat.Default)]
            public string randRateExpression
            {
                get
                {
                    return this._randRateExpression;
                }
                set
                {
                    this._randRateExpression = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="robberMaxNum", DataFormat=DataFormat.TwosComplement)]
            public int robberMaxNum
            {
                get
                {
                    return this._robberMaxNum;
                }
                set
                {
                    this._robberMaxNum = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="robberShowNum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int robberShowNum
            {
                get
                {
                    return this._robberShowNum;
                }
                set
                {
                    this._robberShowNum = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="robShowNum", DataFormat=DataFormat.TwosComplement)]
            public int robShowNum
            {
                get
                {
                    return this._robShowNum;
                }
                set
                {
                    this._robShowNum = value;
                }
            }
        }

        [ProtoContract(Name="Setting")]
        public class Setting : IExtensible
        {
            private string _forumURL = "";
            private string _officialInfo = "";
            private bool _showInvite;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="forumURL", DataFormat=DataFormat.Default), DefaultValue("")]
            public string forumURL
            {
                get
                {
                    return this._forumURL;
                }
                set
                {
                    this._forumURL = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="officialInfo", DataFormat=DataFormat.Default), DefaultValue("")]
            public string officialInfo
            {
                get
                {
                    return this._officialInfo;
                }
                set
                {
                    this._officialInfo = value;
                }
            }

            [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="showInvite", DataFormat=DataFormat.Default)]
            public bool showInvite
            {
                get
                {
                    return this._showInvite;
                }
                set
                {
                    this._showInvite = value;
                }
            }
        }

        [ProtoContract(Name="ShowingAttribute")]
        public class ShowingAttribute : IExtensible
        {
            private int _attributeSortIndex;
            private int _attributeType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="attributeSortIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int attributeSortIndex
            {
                get
                {
                    return this._attributeSortIndex;
                }
                set
                {
                    this._attributeSortIndex = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="attributeType", DataFormat=DataFormat.TwosComplement)]
            public int attributeType
            {
                get
                {
                    return this._attributeType;
                }
                set
                {
                    this._attributeType = value;
                }
            }
        }

        [ProtoContract(Name="TrainingFactor")]
        public class TrainingFactor : IExtensible
        {
            private int _attributeType;
            private float _factor;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="attributeType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int attributeType
            {
                get
                {
                    return this._attributeType;
                }
                set
                {
                    this._attributeType = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(2, IsRequired=false, Name="factor", DataFormat=DataFormat.FixedSize)]
            public float factor
            {
                get
                {
                    return this._factor;
                }
                set
                {
                    this._factor = value;
                }
            }
        }

        [ProtoContract(Name="UIShowSetting")]
        public class UIShowSetting : IExtensible
        {
            private int _maxCountItemInUI;
            private int _piecePageCount;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="maxCountItemInUI", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int maxCountItemInUI
            {
                get
                {
                    return this._maxCountItemInUI;
                }
                set
                {
                    this._maxCountItemInUI = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="piecePageCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int piecePageCount
            {
                get
                {
                    return this._piecePageCount;
                }
                set
                {
                    this._piecePageCount = value;
                }
            }
        }

        [ProtoContract(Name="WorldChatConfig")]
        public class WorldChatConfig : IExtensible
        {
            private int _count;
            private long _resetTime;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
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

            [DefaultValue((long) 0L), ProtoMember(2, IsRequired=false, Name="resetTime", DataFormat=DataFormat.TwosComplement)]
            public long resetTime
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

            public DateTime worldChatResetTime
            {
                get
                {
                    return new DateTime(this._resetTime * 0x2710L);
                }
            }
        }

        [ProtoContract(Name="WuXiaFengYunContinueLoginReward")]
        public class WuXiaFengYunContinueLoginReward : IExtensible
        {
            private int _rewardSetId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="rewardSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int rewardSetId
            {
                get
                {
                    return this._rewardSetId;
                }
                set
                {
                    this._rewardSetId = value;
                }
            }
        }
    }
}

