#include "ProtoPackTool.h"

#define MAX_PROTOBUF_MEM_SIZE 40960
/////////////////////////////////
FenjieRequest fenjierequest;
FenjieAnswer fenjieanswer;
MailInsertRequest mailinsertrequest;
CommonAnswer commonanswer;
CommonRequest commonrequest;
MailListAnswer maillistanswer;
MailOperRequest mailoperrequest;
MailGetItemAnswer mailgetitemanswer;
MailSendRequest mailsendrequest;
LoginRequest loginrequest;
LoginAnswer loginanswer;
KickRoleNotify kickrolenotify;
CreateRoleRequest createrolerequest;
CreateRoleAnswer createroleanswer;
EnterGameRequest entergamerequest;
EnterGameAnswer entergameanswer;
GetCardAttrRequest getcardattrrequest;
GetCardAttrAnswer getcardattranswer;
GetPlayerAttrRequest getplayerattrrequest;
GetPlayerAttrAnswer getplayerattranswer;
ListBagRequest listbagrequest;
ListBagAnswer listbaganswer;
GetPlayerInfoRequest getplayerinforequest;
PlayerInfo playerinfo;
BagNotEnoughNotify bagnotenoughnotify;
SystemUpdateNotify systemupdatenotify;
RenameRequest renamerequest;
RenameAnswer renameanswer;
HeartbeatRequest heartbeatrequest;
HeartbeatAnswer heartbeatanswer;
GmCmdRequest gmcmdrequest;
GmCmdAnswer gmcmdanswer;
HeroUpgradeLevelRequest heroupgradelevelrequest;
HeroUpgradeScalaRequest heroupgradescalarequest;
HeroCheerRequest herocheerrequest;
HeroEmbattleRequest heroembattlerequest;
HeroEmbattleNotify heroembattlenotify;
HeroUpgradeDestinyRequest heroupgradedestinyrequest;
HeroUpgradeDestinyAnswer heroupgradedestinyanswer;
HeroCultureRequest heroculturerequest;
HeroCultureReplaceRequest heroculturereplacerequest;
HeroInstallAwakenEquipRequest heroinstallawakenequiprequest;
ItemComposeRequest itemcomposerequest;
IncHeroNotify incheronotify;
HeroSellRequest herosellrequest;
CommonSellAnswer commonsellanswer;
UniteSkillShowNotify uniteskillshownotify;
EquipStrengthenRequest equipstrengthenrequest;
EquipStrengthenAnswer equipstrengthenanswer;
EquipUpgradeStarRequest equipupgradestarrequest;
EquipRefiningRequest equiprefiningrequest;
EquipDressRequest equipdressrequest;
AutoEquipStrengthenRequest autoequipstrengthenrequest;
EquipSellRequest equipsellrequest;
FightRequest fightrequest;
FightAnswer fightanswer;
RaidRecordAnswer raidrecordanswer;
RaidRewardRequest raidrewardrequest;
RaidRewardAnswer raidrewardanswer;
FriendDekaronRequest frienddekaronrequest;
MainRaidSweepRequest mainraidsweeprequest;
MainRaidSweepAnswer mainraidsweepanswer;
RaidResetRequest raidresetrequest;
RaidResetAnswer raidresetanswer;
UseItemRequest useitemrequest;
UseItemAnswer useitemanswer;
SellChipRequest sellchiprequest;
SellAwakenItemRequest sellawakenitemrequest;
FenjieAwakenItemRequest fenjieawakenitemrequest;
ChipMergeRequest chipmergerequest;
ChipMergeAnswer chipmergeanswer;
FriendNearAnswer friendnearanswer;
ArenaGetPlayerAnswer arenagetplayeranswer;
ArenaStartRequest arenastartrequest;
ArenaFlopAnswer arenaflopanswer;
ShopListAnswer shoplistanswer;
ShopBuyRequest shopbuyrequest;
ArenaMultiStartRequest arenamultistartrequest;
ArenaMultiStartAnswer arenamultistartanswer;
TowerLadderInfoAnswer towerladderinfoanswer;
TowerLadderAttrRequest towerladderattrrequest;
TowerLadderStartRequest towerladderstartrequest;
TowerLadderEliteRequest towerladdereliterequest;
TowerLadderRankAnswer towerladderrankanswer;
TowerLadderStartFloorRequest towerladderstartfloorrequest;
TowerLadderStartFloorAnswer towerladderstartflooranswer;
TowerLadderSweepAnswer towerladdersweepanswer;
HuangtingRequest huangtingrequest;
HuangtingAnswer huangtinganswer;
ChoukaRequest choukarequest;
ChoukaAnswer choukaanswer;
ChoukaActivityNotify choukaactivitynotify;
ChoukaShareLuckNotify choukasharelucknotify;
DrawLuckPackageRequest drawluckpackagerequest;
DrawLuckPackageAnswer drawluckpackageanswer;
RebelListAnswer rebellistanswer;
RebelShareRequest rebelsharerequest;
RebelShareAnswer rebelshareanswer;
RebelRaidStartRequest rebelraidstartrequest;
RebelHurtRankRequest rebelhurtrankrequest;
RebelRankAnswer rebelrankanswer;
RebelExploitRewardRequest rebelexploitrewardrequest;
RebelExploitRewardAnswer rebelexploitrewardanswer;
RebelBossListAnswer rebelbosslistanswer;
RebelShareFlagNotify rebelshareflagnotify;
RebelCreateFlagNotify rebelcreateflagnotify;
ShenjiangShopRequest shenjiangshoprequest;
ShenjiangShopBuyRequest shenjiangshopbuyrequest;
ShenjiangShopAnswer shenjiangshopanswer;
ShopPlayInfoRequest shopplayinforequest;
ShopPlayInfoAnswer shopplayinfoanswer;
ShopPlayBuyRequest shopplaybuyrequest;
ShopPlayBuyAnswer shopplaybuyanswer;
TreasureDressRequest treasuredressrequest;
TreasureStrengthenRequest treasurestrengthenrequest;
TreasureRefiningRequest treasurerefiningrequest;
TreasureForgeRequest treasureforgerequest;
TreasureSellRequest treasuresellrequest;
BlusherListAnswer blusherlistanswer;
BlusherWooRequest blusherwoorequest;
BlusherRewardAnswer blusherrewardanswer;
BlusherOperRequest blusheroperrequest;
BlusherRankAnswer blusherrankanswer;
ChatSendRequest chatsendrequest;
ChatSendAnswer chatsendanswer;
ChatMsgNotify chatmsgnotify;
BroadcastNotify broadcastnotify;
AnnouncementNotify announcementnotify;
ModuleSubscribeRequest modulesubscriberequest;
EatCucumberAnswer eatcucumberanswer;
TaskListAnswer tasklistanswer;
TaskGetRewardRequest taskgetrewardrequest;
TaskGetRewardAnswer taskgetrewardanswer;
SignRequest signrequest;
SignAnswer signanswer;
LuxurySignGetRewardRequest luxurysigngetrewardrequest;
LuxurySignGetRewardAnswer luxurysigngetrewardanswer;
MoneyTreeRequest moneytreerequest;
MoneyTreeAnswer moneytreeanswer;
ActivityListAnswer activitylistanswer;
ActivityRewardRequest activityrewardrequest;
DrawVipDailyWelfareRequest drawvipdailywelfarerequest;
DrawVipDailyWelfareAnswer drawvipdailywelfareanswer;
OpenSrvRankActivityInfo opensrvrankactivityinfo;
OpenSrvRankDrawAwardRequest opensrvrankdrawawardrequest;
OpenSrvRankDrawAwardAnswer opensrvrankdrawawardanswer;
VipWeekPackageInfoAnswer vipweekpackageinfoanswer;
VipWeekPackageBuyRequest vipweekpackagebuyrequest;
VipWeekPackageBuyAnswer vipweekpackagebuyanswer;
BlessingBagNotify blessingbagnotify;
EnterGameGuideNotify entergameguidenotify;
LevelUpNotify levelupnotify;
CommonRankRequest commonrankrequest;
CommonRankAnswer commonrankanswer;
CommonRankLikeRequest commonranklikerequest;
CommonRankLikeAnswer commonranklikeanswer;
ViewPlayerRequest viewplayerrequest;
ViewPlayerAnswer viewplayeranswer;
QiecuoStartRequest qiecuostartrequest;
QiecuoStartServerRequest qiecuostartserverrequest;
FriendListAnswer friendlistanswer;
FriendOperatorRequest friendoperatorrequest;
FriendOperatorAnswer friendoperatoranswer;
FriendRecvEnergyAnswer friendrecvenergyanswer;
FriendAddByNameRequest friendaddbynamerequest;
GuildCommitRequest guildcommitrequest;
UseCDKAnswer usecdkanswer;
SpecialAwardNotify specialawardnotify;
LegionCreateRequest legioncreaterequest;
LegionInfoAnswer legioninfoanswer;
LegionMemberListAnswer legionmemberlistanswer;
LegionEventAnswer legioneventanswer;
LegionListAnswer legionlistanswer;
LegionApplyRequest legionapplyrequest;
LegionApplyListAnswer legionapplylistanswer;
LegionOperateRequest legionoperaterequest;
LegionOperateAnswer legionoperateanswer;
LegionChangeLogoRequest legionchangelogorequest;
LegionChangeLogoAnswer legionchangelogoanswer;
LegionChangeBulletinRequest legionchangebulletinrequest;
LegionMessageAnswer legionmessageanswer;
LegionSendMessageRequest legionsendmessagerequest;
LegionSendMessageAnswer legionsendmessageanswer;
LegionStickyMessageRequest legionstickymessagerequest;
LegionStickyMessageAnswer legionstickymessageanswer;
LegionWorshipRequest legionworshiprequest;
LegionWorshipAnswer legionworshipanswer;
LegionWorshipOpenBoxRequest legionworshipopenboxrequest;
LegionWorshipOpenBoxAnswer legionworshipopenboxanswer;
LegionLimitShopInfo legionlimitshopinfo;
LegionLimitShopBuyRequest legionlimitshopbuyrequest;
LegionLimitShopBuyAnswer legionlimitshopbuyanswer;
LegionSkillInfoAnswer legionskillinfoanswer;
LegionSkillOperateRequest legionskilloperaterequest;
LegionRankAnswer legionrankanswer;
LegionChangeAcceptTypeRequest legionchangeaccepttyperequest;
LegionChangeAcceptTypeAnswer legionchangeaccepttypeanswer;
KingFightAnswer kingfightanswer;
KingFightStageInfoRequest kingfightstageinforequest;
KingFightStageInfoAnswer kingfightstageinfoanswer;
KingFightStartRequest kingfightstartrequest;
KingFightUseItemRequest kingfightuseitemrequest;
KingFightUseItemAnswer kingfightuseitemanswer;
KingFightBuyCntRequest kingfightbuycntrequest;
KingFightBuyCntAnswer kingfightbuycntanswer;
KingFightRankStarAnswer kingfightrankstaranswer;
KingFightRankDamageAnswer kingfightrankdamageanswer;
CrusadeFortressAllInfoAnswer crusadefortressallinfoanswer;
CrusadeFortressInfoRequest crusadefortressinforequest;
CrusadeFortressInfoAnswer crusadefortressinfoanswer;
CrusadeFortressFightRequest crusadefortressfightrequest;
CrusadeFortressOpenBoxRequest crusadefortressopenboxrequest;
CrusadeFortressOpenBoxAnswer crusadefortressopenboxanswer;
CrusadeFortressRewardRequest crusadefortressrewardrequest;
CrusadeFortressBattleRecordRequest crusadefortressbattlerecordrequest;
CrusadeFortressBattleRecordAnswer crusadefortressbattlerecordanswer;
CrusadeFortressReplayRequest crusadefortressreplayrequest;
CrusadeFortressBuyBuffRequest crusadefortressbuybuffrequest;
CrusadeFortressBuyBuffAnswer crusadefortressbuybuffanswer;
WudiPreselectRankAnswer wudipreselectrankanswer;
WudiInfoAnswer wudiinfoanswer;
WudiFightRequest wudifightrequest;
WudiHurtRankAnswer wudihurtrankanswer;
BuyWudiFightCntRequest buywudifightcntrequest;
BuyWudiFightCntAnswer buywudifightcntanswer;
BuyWudiFightBuffRequest buywudifightbuffrequest;
BuyWudiFightBuffAnswer buywudifightbuffanswer;
BuyWudiBossBuffRequest buywudibossbuffrequest;
BuyWudiBossBuffAnswer buywudibossbuffanswer;
WudiOpenNotify wudiopennotify;
VisitInfoAnswer visitinfoanswer;
VisitStartRequest visitstartrequest;
VisitGetRewardRequest visitgetrewardrequest;
VisitGetRewardAnswer visitgetrewardanswer;
VisitInfoRandomAnswer visitinforandomanswer;
VisitFriendListAnswer visitfriendlistanswer;
VisitFriendRequest visitfriendrequest;
VisitFriendRewardRequest visitfriendrewardrequest;
VisitFriendRewardAnswer visitfriendrewardanswer;
VisitFriendAccelerateRequest visitfriendacceleraterequest;
VisitFriendAccelerateAnswer visitfriendaccelerateanswer;
VisitSaveRouteRequest visitsaverouterequest;
VisitGetSaveRouteAnswer visitgetsaverouteanswer;
VisitOneKeyGetRewardRequest visitonekeygetrewardrequest;
VisitOneKeyGetRewardAnswer visitonekeygetrewardanswer;
OpenFundAnswer openfundanswer;
OpenFundGetRequest openfundgetrequest;
OpenFundGetAnswer openfundgetanswer;
MonthCardInfoAnswer monthcardinfoanswer;
MonthCardGetRequest monthcardgetrequest;
MonthCardGetAnswer monthcardgetanswer;
FirstRechargeAwardGetAnswer firstrechargeawardgetanswer;
RechargeNotify rechargenotify;
BuyMonthCardRequest buymonthcardrequest;
BuyMonthCardAnswer buymonthcardanswer;
LegionBossCommonRequest legionbosscommonrequest;
LegionBossInfoAnswer legionbossinfoanswer;
LegionBossGetRewardAnswer legionbossgetrewardanswer;
LegionBossFirstKillRankAnswer legionbossfirstkillrankanswer;
LegionBossTotalStageRankAnswer legionbosstotalstagerankanswer;
LegionBossLegionMaxDamageRankAnswer legionbosslegionmaxdamagerankanswer;
LegionBossMaxDamageRankAnswer legionbossmaxdamagerankanswer;
LegionBossKillCountRankAnswer legionbosskillcountrankanswer;
LegionBossTaskInfoAnswer legionbosstaskinfoanswer;
LegionBossTaskGetRequest legionbosstaskgetrequest;
FashionDressRequest fashiondressrequest;
FashionStrengthenRequest fashionstrengthenrequest;
TurntableNotify turntablenotify;
TurntableStartRequest turntablestartrequest;
TurntableStartAnswer turntablestartanswer;
TurntableRefreshRequest turntablerefreshrequest;
TurntableRefreshAnswer turntablerefreshanswer;
TurntableRecordAnswer turntablerecordanswer;
TurntableTaskListAnswer turntabletasklistanswer;
TurntableTaskRewardRequest turntabletaskrewardrequest;
TurntableTaskRewardAnswer turntabletaskrewardanswer;
ZhaocaimaoNotify zhaocaimaonotify;
ZhaocaimaoStartAnswer zhaocaimaostartanswer;
ZhaocaimaoRecordAnswer zhaocaimaorecordanswer;
ZhaocaimaoTaskListAnswer zhaocaimaotasklistanswer;
ZhaocaimaoTaskRewardRequest zhaocaimaotaskrewardrequest;
ZhaocaimaoTaskRewardAnswer zhaocaimaotaskrewardanswer;
OpenUIReport openuireport;
CSPointsRaceStateAnswer cspointsracestateanswer;
CSPointsRaceGetInfoAnswer cspointsracegetinfoanswer;
CSPointsRaceGetOpponentsAnswer cspointsracegetopponentsanswer;
CSPointsRaceFightRequest cspointsracefightrequest;
CSPointsRaceRevengeRequest cspointsracerevengerequest;
CSPointsRacePrepareFightRequest cspointsracepreparefightrequest;
CSPointsRacePrepareFightAnswer cspointsracepreparefightanswer;
CSPointsRaceRankAnswer cspointsracerankanswer;
CSPointsRaceDefendLogAnswer cspointsracedefendloganswer;
CSPointsRaceFightBuyRequest cspointsracefightbuyrequest;
FenjieGallantRequest fenjiegallantrequest;
FenjieGallantAnswer fenjiegallantanswer;
ComposeGallantRequest composegallantrequest;
GallantEntryInfoNotify gallantentryinfonotify;
GallantEntryActivateRequest gallantentryactivaterequest;
GallantRankAnswer gallantrankanswer;
GallantRaidInfoAnswer gallantraidinfoanswer;
LimitedTimeBuyNotify limitedtimebuynotify;
LimitedTimeBuyRequest limitedtimebuyrequest;
LimitedTimeBuyAnswer limitedtimebuyanswer;
RebateInfoNotify rebateinfonotify;
RebateReceiveAnswer rebatereceiveanswer;
PetDressRequest petdressrequest;
PetUplevelRequest petuplevelrequest;
PetStarUpgradeRequest petstarupgraderequest;
NianEventNotify nianeventnotify;
NianInfoAnswer nianinfoanswer;
NianBuyFireworksRequest nianbuyfireworksrequest;
NianUseFireworksAnswer nianusefireworksanswer;
NianGetRedPacketRequest niangetredpacketrequest;
NianGetRedPacketAnswer niangetredpacketanswer;
NianRankAnswer nianrankanswer;
NianTaskListAnswer niantasklistanswer;
NianTaskRewardRequest niantaskrewardrequest;
NianTaskRewardAnswer niantaskrewardanswer;
AchievementTaskListAnswer achievementtasklistanswer;
AchievementTaskRewardRequest achievementtaskrewardrequest;
AchievementTaskRewardAnswer achievementtaskrewardanswer;
AchievementOneKeyRewardAnswer achievementonekeyrewardanswer;
AchievementNewTaskCompleteNotify achievementnewtaskcompletenotify;
PetRaidInfoAnswer petraidinfoanswer;
PetRaidDeployAnswer petraiddeployanswer;
PetRaidFightRequest petraidfightrequest;
PetRaidBoxNotify petraidboxnotify;
PetRaidOneKeyPassAnswer petraidonekeypassanswer;
PetRaidPassCountRankAnswer petraidpasscountrankanswer;
CsRiverLanternFloatRequest csriverlanternfloatrequest;
CsRiverLanternFloatAnswer csriverlanternfloatanswer;
CsRiverLanternInfoAnswer csriverlanterninfoanswer;
CsRiverLanternNewFloatNotify csriverlanternnewfloatnotify;
CsRiverLanternNewRankNotify csriverlanternnewranknotify;
CsRiverLanternSelfRankUpdateNotify csriverlanternselfrankupdatenotify;
CsRiverLanternOthersGetItemNotify csriverlanternothersgetitemnotify;
CsGrouponInfoAnswer csgrouponinfoanswer;
CsGrouponCountUpdateNotify csgrouponcountupdatenotify;
/////////////////////////////////
void ProtoPackTool::getProtoFromByte(int msgId,const void* protoBuf,int len,char** result)
{
		/** 分解请求 **/
		if((NetMsgId)msgId==FENJIE_REQUEST){
		 fenjierequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&fenjierequest;
		}
		/** 分解应答 **/
		if((NetMsgId)msgId==FENJIE_ANSWER){
		 fenjieanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fenjieanswer;
		}
		/** 插入邮件列表请求 **/
		if((NetMsgId)msgId==MAIL_INSERT_REQUEST){
		 mailinsertrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&mailinsertrequest;
		}
		/** 插入邮件列表应答 **/
		if((NetMsgId)msgId==MAIL_INSERT_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 列表邮件列表 **/
		if((NetMsgId)msgId==MAIL_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 列表邮件回应 **/
		if((NetMsgId)msgId==MAIL_LIST_ANSWER){
		 maillistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&maillistanswer;
		}
		/** 领取邮件附件列表 **/
		if((NetMsgId)msgId==MAIL_GET_ITEM_REQUEST){
		 mailoperrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&mailoperrequest;
		}
		/** 领取邮件附件回应 **/
		if((NetMsgId)msgId==MAIL_GET_ITEM_ANSWER){
		 mailgetitemanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&mailgetitemanswer;
		}
		/** 新邮件通知 **/
		if((NetMsgId)msgId==MAIL_NEW_NOTIFY){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 邮件删除请求 **/
		if((NetMsgId)msgId==MAIL_DEL_REQUEST){
		 mailoperrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&mailoperrequest;
		}
		/** 邮件删除应答 **/
		if((NetMsgId)msgId==MAIL_DEL_ANSWER){
		 maillistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&maillistanswer;
		}
		/** 邮件读取请求 **/
		if((NetMsgId)msgId==MAIL_READER_REQUEST){
		 mailoperrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&mailoperrequest;
		}
		/** 发送邮件请求 **/
		if((NetMsgId)msgId==MAIL_SEND_REQUEST){
		 mailsendrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&mailsendrequest;
		}
		/** 发送邮件应答 **/
		if((NetMsgId)msgId==MAIL_SEND_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 邮件状态请求 **/
		if((NetMsgId)msgId==MAIL_STATUS_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 登录请求 **/
		if((NetMsgId)msgId==LOGIN_REQUEST){
		 loginrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&loginrequest;
		}
		/** 登录应答 **/
		if((NetMsgId)msgId==LOGIN_ANSWER){
		 loginanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&loginanswer;
		}
		/** 帐号被踢 **/
		if((NetMsgId)msgId==LOGIN_AGAIN_NOTIFY){
		 kickrolenotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&kickrolenotify;
		}
		/** 创建角色请求 **/
		if((NetMsgId)msgId==CREATE_ROLE_REQUEST){
		 createrolerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&createrolerequest;
		}
		/** 创建角色应答 **/
		if((NetMsgId)msgId==CREATE_ROLE_ANSWER){
		 createroleanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&createroleanswer;
		}
		/** 进入游戏请求 **/
		if((NetMsgId)msgId==ENTER_GAME_REQUEST){
		 entergamerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&entergamerequest;
		}
		/** 进入游戏应答 **/
		if((NetMsgId)msgId==ENTER_GAME_ANSWER){
		 entergameanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&entergameanswer;
		}
		/** 获取玩家的卡片属性请求 **/
		if((NetMsgId)msgId==GET_CARD_ATTR_REQUEST){
		 getcardattrrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&getcardattrrequest;
		}
		/** 获取玩家的卡片属性应答 **/
		if((NetMsgId)msgId==GET_CARD_ATTR_ANSWER){
		 getcardattranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&getcardattranswer;
		}
		/** 退出游戏请求 **/
		if((NetMsgId)msgId==EXIT_GAME_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 退出游戏应答 **/
		if((NetMsgId)msgId==EXIT_GAME_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 获取角色的属性请求 **/
		if((NetMsgId)msgId==GET_PLAYER_ATTR_REQUEST){
		 getplayerattrrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&getplayerattrrequest;
		}
		/** 获取角色的属性应答 **/
		if((NetMsgId)msgId==GET_PLAYER_ATTR_ANSWER){
		 getplayerattranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&getplayerattranswer;
		}
		/** 列举背包请求 **/
		if((NetMsgId)msgId==LIST_BAG_REQUEST){
		 listbagrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&listbagrequest;
		}
		/** 列举背包应答 **/
		if((NetMsgId)msgId==LIST_BAG_ANSWER){
		 listbaganswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&listbaganswer;
		}
		/** 获取角色信息请求 **/
		if((NetMsgId)msgId==GET_PLAYER_INFO_REQUEST){
		 getplayerinforequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&getplayerinforequest;
		}
		/** 获取角色信息应答 **/
		if((NetMsgId)msgId==GET_PLAYER_INFO_ANSWER){
		 playerinfo.ParseFromArray(protoBuf,len);
		 *result=(char*)&playerinfo;
		}
		/** 背包不足时通知 **/
		if((NetMsgId)msgId==BAG_NOT_ENOUGH_NOTIFY){
		 bagnotenoughnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&bagnotenoughnotify;
		}
		/** 系统更新通知 **/
		if((NetMsgId)msgId==SYSTEM_UPDATE_NOTIFY){
		 systemupdatenotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&systemupdatenotify;
		}
		/** 改名请求 **/
		if((NetMsgId)msgId==RENAME_REQUEST){
		 renamerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&renamerequest;
		}
		/** 改名应答 **/
		if((NetMsgId)msgId==RENAME_ANSWER){
		 renameanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&renameanswer;
		}
		/** 心跳请求 **/
		if((NetMsgId)msgId==HEARTBEAT_REQUEST){
		 heartbeatrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&heartbeatrequest;
		}
		/** 心跳应答 **/
		if((NetMsgId)msgId==HEARTBEAT_ANSWER){
		 heartbeatanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&heartbeatanswer;
		}
		/** GM增加物品请求 **/
		if((NetMsgId)msgId==GM_CMD_REQUEST){
		 gmcmdrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&gmcmdrequest;
		}
		/** GM增加物品请求 **/
		if((NetMsgId)msgId==GM_CMD_ANSWER){
		 gmcmdanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&gmcmdanswer;
		}
		/** 武将升级请求 **/
		if((NetMsgId)msgId==HERO_UPGRADE_LEVEL_REQUEST){
		 heroupgradelevelrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroupgradelevelrequest;
		}
		/** 武将升级应答 **/
		if((NetMsgId)msgId==HERO_UPGRADE_LEVEL_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 武将突破请求 **/
		if((NetMsgId)msgId==HERO_OVERSTEP_REQUEST){
		 heroupgradescalarequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroupgradescalarequest;
		}
		/** 武将突破应答 **/
		if((NetMsgId)msgId==HERO_OVERSTEP_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 武将上阵请求 **/
		if((NetMsgId)msgId==HERO_PLAY_REQUEST){
		 herocheerrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&herocheerrequest;
		}
		/** 武将上阵应答 **/
		if((NetMsgId)msgId==HERO_PLAY_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 武将助阵请求 **/
		if((NetMsgId)msgId==HERO_CHEER_REQUEST){
		 herocheerrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&herocheerrequest;
		}
		/** 武将助阵应答 **/
		if((NetMsgId)msgId==HERO_CHEER_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 武将布阵请求 **/
		if((NetMsgId)msgId==HERO_EMBATTLE_REQUEST){
		 heroembattlerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroembattlerequest;
		}
		/** 武将布阵应答 **/
		if((NetMsgId)msgId==HERO_EMBATTLE_ANSWER){
		 heroembattlenotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroembattlenotify;
		}
		/** 武将升级天命请求 **/
		if((NetMsgId)msgId==HERO_UPGRADE_DESTINY_REQUEST){
		 heroupgradedestinyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroupgradedestinyrequest;
		}
		/** 武将升级天命应答 **/
		if((NetMsgId)msgId==HERO_UPGRADE_DESTINY_ANSWER){
		 heroupgradedestinyanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroupgradedestinyanswer;
		}
		/** 武将培养请求 **/
		if((NetMsgId)msgId==HERO_CULTURE_REQUEST){
		 heroculturerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroculturerequest;
		}
		/** 武将培养应答 **/
		if((NetMsgId)msgId==HERO_CULTURE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 武将培养替换请求 **/
		if((NetMsgId)msgId==HERO_CULTURE_REPLACE_REQUEST){
		 heroculturereplacerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroculturereplacerequest;
		}
		/** 武将培养替换应答 **/
		if((NetMsgId)msgId==HERO_CULTURE_REPLACE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 武将觉醒请求 **/
		if((NetMsgId)msgId==HERO_UPGRADE_AWAKEN_REQUEST){
		 heroupgradedestinyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroupgradedestinyrequest;
		}
		/** 武将觉醒应答 **/
		if((NetMsgId)msgId==HERO_UPGRADE_AWAKEN_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 武将穿戴觉醒装备请求 **/
		if((NetMsgId)msgId==HERO_INSTALL_AWAKEN_EQUIP_REQUEST){
		 heroinstallawakenequiprequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroinstallawakenequiprequest;
		}
		/** 武将穿戴觉醒装备应答 **/
		if((NetMsgId)msgId==HERO_INSTALL_AWAKEN_EQUIP_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 一健装备觉醒装备请求 **/
		if((NetMsgId)msgId==AUTO_INSTALL_AWAKEN_REQUEST){
		 heroinstallawakenequiprequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&heroinstallawakenequiprequest;
		}
		/** 一健装备觉醒装备应答 **/
		if((NetMsgId)msgId==AUTO_INSTALL_AWAKEN_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 武将觉醒装备合成请求 **/
		if((NetMsgId)msgId==HERO_AWAKEN_EQUIP_COMPOSE_REQUEST){
		 itemcomposerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&itemcomposerequest;
		}
		/** 武将穿戴觉醒装备应答 **/
		if((NetMsgId)msgId==HERO_AWAKEN_EQUIP_COMPOSE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 武将下阵请求 **/
		if((NetMsgId)msgId==HERO_UNPLAY_REQUEST){
		 herocheerrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&herocheerrequest;
		}
		/** 武将下阵应答 **/
		if((NetMsgId)msgId==HERO_UNPLAY_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 增量推送武将 **/
		if((NetMsgId)msgId==INC_HOER_NOTIFY){
		 incheronotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&incheronotify;
		}
		/** 武将出售请求 **/
		if((NetMsgId)msgId==HERO_SELL_REQUEST){
		 herosellrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&herosellrequest;
		}
		/** 武将出售应答 **/
		if((NetMsgId)msgId==HERO_SELL_ANSWER){
		 commonsellanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonsellanswer;
		}
		/** 已展示过的合击武将通知 **/
		if((NetMsgId)msgId==UNITE_SKILL_SHOW_NOTIFY){
		 uniteskillshownotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&uniteskillshownotify;
		}
		/** 装备强化请求 **/
		if((NetMsgId)msgId==EQUIP_STRENGTHEN_REQUEST){
		 equipstrengthenrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&equipstrengthenrequest;
		}
		/** 装备强化应答 **/
		if((NetMsgId)msgId==EQUIP_STRENGTHEN_ANSWER){
		 equipstrengthenanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&equipstrengthenanswer;
		}
		/** 装备升星请求 **/
		if((NetMsgId)msgId==EQUIP_UPGRADE_STAR_REQUEST){
		 equipupgradestarrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&equipupgradestarrequest;
		}
		/** 装备升星应答 **/
		if((NetMsgId)msgId==EQUIP_UPGRADE_STAR_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 装备精练请求 **/
		if((NetMsgId)msgId==EQUIP_REFINING_REQUEST){
		 equiprefiningrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&equiprefiningrequest;
		}
		/** 装备精练应答 **/
		if((NetMsgId)msgId==EQUIP_REFINING_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 装备穿戴请求 **/
		if((NetMsgId)msgId==EQUIP_DRESS_REQUEST){
		 equipdressrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&equipdressrequest;
		}
		/** 装备穿戴应答 **/
		if((NetMsgId)msgId==EQUIP_DRESS_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 脱装备请求 **/
		if((NetMsgId)msgId==EQUIP_UNDRESS_REQUEST){
		 equipdressrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&equipdressrequest;
		}
		/** 脱装备应答 **/
		if((NetMsgId)msgId==EQUIP_UNDRESS_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 一键装备强化请求 **/
		if((NetMsgId)msgId==EQUIP_AUTO_STRENGTHEN_REQUEST){
		 autoequipstrengthenrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&autoequipstrengthenrequest;
		}
		/** 一键装备强化应答 **/
		if((NetMsgId)msgId==EQUIP_AUTO_STRENGTHEN_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 装备出售请求 **/
		if((NetMsgId)msgId==EQUIP_SELL_REQUEST){
		 equipsellrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&equipsellrequest;
		}
		/** 装备出售应答 **/
		if((NetMsgId)msgId==EQUIP_SELL_ANSWER){
		 commonsellanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonsellanswer;
		}
		/** 副本开始请求 **/
		if((NetMsgId)msgId==RAID_START_REQUEST){
		 fightrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightrequest;
		}
		/** 副本开始应答 **/
		if((NetMsgId)msgId==RAID_START_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 副本记录请求 **/
		if((NetMsgId)msgId==RAID_RECORD_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 副本记录应答 **/
		if((NetMsgId)msgId==RAID_RECORD_ANSWER){
		 raidrecordanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&raidrecordanswer;
		}
		/** 副本宝箱奖励请求 **/
		if((NetMsgId)msgId==RAID_REWARD_REQUEST){
		 raidrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&raidrewardrequest;
		}
		/** 副本宝箱奖励应答 **/
		if((NetMsgId)msgId==RAID_REWARD_ANSWER){
		 raidrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&raidrewardanswer;
		}
		/** 挑战好友请求 **/
		if((NetMsgId)msgId==FRIEND_DEKARON_REQUEST){
		 frienddekaronrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&frienddekaronrequest;
		}
		/** 挑战好友应答 **/
		if((NetMsgId)msgId==FRIEND_DEKARON_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 副本扫荡请求 **/
		if((NetMsgId)msgId==MAIN_RAID_SWEEP_REQUEST){
		 mainraidsweeprequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&mainraidsweeprequest;
		}
		/** 副本扫荡应答 **/
		if((NetMsgId)msgId==MAIN_RAID_SWEEP_ANSWER){
		 mainraidsweepanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&mainraidsweepanswer;
		}
		/** 副本重置请求 **/
		if((NetMsgId)msgId==RAID_RESET_REQUEST){
		 raidresetrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&raidresetrequest;
		}
		/** 副本重置应答 **/
		if((NetMsgId)msgId==RAID_RESET_ANSWER){
		 raidresetanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&raidresetanswer;
		}
		/** 使用物品请求 **/
		if((NetMsgId)msgId==USEITEM_REQUEST){
		 useitemrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&useitemrequest;
		}
		/** 使用物品应答 **/
		if((NetMsgId)msgId==USEITEM_ANSWER){
		 useitemanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&useitemanswer;
		}
		/** 出售碎片请求 **/
		if((NetMsgId)msgId==SELL_CHIP_REQUEST){
		 sellchiprequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&sellchiprequest;
		}
		/** 出售碎片应答 **/
		if((NetMsgId)msgId==SELL_CHIP_ANSWER){
		 commonsellanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonsellanswer;
		}
		/** 觉醒道具出售请求 **/
		if((NetMsgId)msgId==SELL_AWAKEN_ITEM_REQUEST){
		 sellawakenitemrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&sellawakenitemrequest;
		}
		/** 觉醒道具出售应答 **/
		if((NetMsgId)msgId==SELL_AWAKEN_ITEM_ANSWER){
		 commonsellanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonsellanswer;
		}
		/** 觉醒道具分解请求 **/
		if((NetMsgId)msgId==FENJIE_AWAKEN_ITEM_REQUEST){
		 fenjieawakenitemrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&fenjieawakenitemrequest;
		}
		/** 觉醒道具分解应答 **/
		if((NetMsgId)msgId==FENJIE_AWAKEN_ITEM_ANSWER){
		 commonsellanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonsellanswer;
		}
		/** 碎片合成请求 **/
		if((NetMsgId)msgId==CHIP_MERGE_REQUEST){
		 chipmergerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&chipmergerequest;
		}
		/** 碎片合成应答 **/
		if((NetMsgId)msgId==CHIP_MERGE_ANSWER){
		 chipmergeanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&chipmergeanswer;
		}
		/** 查看附近的玩家请求 **/
		if((NetMsgId)msgId==FRIEND_NEAR_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 查看附近的玩家应答 **/
		if((NetMsgId)msgId==FRIEND_NEAR_ANSWER){
		 friendnearanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendnearanswer;
		}
		/** 获取竞技场角色列表请求 **/
		if((NetMsgId)msgId==ARENA_GET_PLAYER_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 获取竞技场角色列表应答 **/
		if((NetMsgId)msgId==ARENA_GET_PLAYER_ANSWER){
		 arenagetplayeranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&arenagetplayeranswer;
		}
		/** 竞技场开始请求 **/
		if((NetMsgId)msgId==ARENA_START_REQUEST){
		 arenastartrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&arenastartrequest;
		}
		/** 竞技场开始应答 **/
		if((NetMsgId)msgId==ARENA_START_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 竞技场翻牌请求 **/
		if((NetMsgId)msgId==ARENA_FLOP_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 竞技场翻牌应答 **/
		if((NetMsgId)msgId==ARENA_FLOP_ANSWER){
		 arenaflopanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&arenaflopanswer;
		}
		/** 竞技场商店请求 **/
		if((NetMsgId)msgId==ARENA_SHOP_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 竞技场商店应答 **/
		if((NetMsgId)msgId==ARENA_SHOP_ANSWER){
		 shoplistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&shoplistanswer;
		}
		/** 竞技场商店购买请求 **/
		if((NetMsgId)msgId==ARENA_SHOP_BUY_REQUEST){
		 shopbuyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&shopbuyrequest;
		}
		/** 竞技场商店购买应答 **/
		if((NetMsgId)msgId==ARENA_SHOP_BUY_ANSWER){
		 shoplistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&shoplistanswer;
		}
		/** 竞技场前30名排行请求 **/
		if((NetMsgId)msgId==ARENA_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 竞技场前30名排行应答 **/
		if((NetMsgId)msgId==ARENA_RANK_ANSWER){
		 arenagetplayeranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&arenagetplayeranswer;
		}
		/** 竞技场批量战斗请求 **/
		if((NetMsgId)msgId==ARENA_MULTI_START_REQUEST){
		 arenamultistartrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&arenamultistartrequest;
		}
		/** 竞技场批量战斗应答 **/
		if((NetMsgId)msgId==ARENA_MULTI_START_ANSWER){
		 arenamultistartanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&arenamultistartanswer;
		}
		/** 爬塔信息请求 **/
		if((NetMsgId)msgId==TOWER_LADDER_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 爬塔信息应答 **/
		if((NetMsgId)msgId==TOWER_LADDER_INFO_ANSWER){
		 towerladderinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladderinfoanswer;
		}
		/** 爬塔重置请求 **/
		if((NetMsgId)msgId==TOWER_LADDER_RESET_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 爬塔重置应答 **/
		if((NetMsgId)msgId==TOWER_LADDER_RESET_ANSWER){
		 towerladderinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladderinfoanswer;
		}
		/** 爬塔选择属性请求 **/
		if((NetMsgId)msgId==TOWER_LADDER_ATTR_REQUEST){
		 towerladderattrrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladderattrrequest;
		}
		/** 爬塔选择属性应答 **/
		if((NetMsgId)msgId==TOWER_LADDER_ATTR_ANSWER){
		 towerladderinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladderinfoanswer;
		}
		/** 爬塔开始副本请求 **/
		if((NetMsgId)msgId==TOWER_LADDER_START_REQUEST){
		 towerladderstartrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladderstartrequest;
		}
		/** 爬塔开始副本应答 **/
		if((NetMsgId)msgId==TOWER_LADDER_START_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 爬塔开始精英副本请求 **/
		if((NetMsgId)msgId==TOWER_LADDER_ELITE_REQUEST){
		 towerladdereliterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladdereliterequest;
		}
		/** 爬塔开始精英副本应答 **/
		if((NetMsgId)msgId==TOWER_LADDER_ELITE_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 爬塔排行请求 **/
		if((NetMsgId)msgId==TOWER_LADDER_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 爬塔排行应答 **/
		if((NetMsgId)msgId==TOWER_LADDER_RANK_ANSWER){
		 towerladderrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladderrankanswer;
		}
		/** 爬塔购买精英次数请求 **/
		if((NetMsgId)msgId==TOWER_BUY_ELITE_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 爬塔购买精英次数应答 **/
		if((NetMsgId)msgId==TOWER_BUY_ELITE_ANSWER){
		 towerladderinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladderinfoanswer;
		}
		/** 爬塔购买推荐道具请求 **/
		if((NetMsgId)msgId==TOWER_BUY_PROP_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 爬塔购买推荐道具应答 **/
		if((NetMsgId)msgId==TOWER_BUY_PROP_ANSWER){
		 towerladderinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladderinfoanswer;
		}
		/** 爬塔挑战整层请求 **/
		if((NetMsgId)msgId==TOWER_LADDER_START_FLOOR_REQUEST){
		 towerladderstartfloorrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladderstartfloorrequest;
		}
		/** 爬塔挑战整层应答 **/
		if((NetMsgId)msgId==TOWER_LADDER_START_FLOOR_ANSWER){
		 towerladderstartflooranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladderstartflooranswer;
		}
		/** 爬塔扫荡请求 **/
		if((NetMsgId)msgId==TOWER_LADDER_SWEEP_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 爬塔扫荡应答 **/
		if((NetMsgId)msgId==TOWER_LADDER_SWEEP_ANSWER){
		 towerladdersweepanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&towerladdersweepanswer;
		}
		/** 点亮黄庭请求 **/
		if((NetMsgId)msgId==HUANGTING_REQUEST){
		 huangtingrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&huangtingrequest;
		}
		/** 点亮黄庭应答 **/
		if((NetMsgId)msgId==HUANGTING_ANSWER){
		 huangtinganswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&huangtinganswer;
		}
		/** 抽卡请求 **/
		if((NetMsgId)msgId==CHOUKA_REQUEST){
		 choukarequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&choukarequest;
		}
		/** 抽卡回应 **/
		if((NetMsgId)msgId==CHOUKA_ANSWER){
		 choukaanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&choukaanswer;
		}
		/** 抽卡活动通知 **/
		if((NetMsgId)msgId==CHOUKA_ACTIVITY_NOTIFY){
		 choukaactivitynotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&choukaactivitynotify;
		}
		/** 抽卡共享幸运值通知 **/
		if((NetMsgId)msgId==CHOUKA_SHARE_LUCK_NOTIFY){
		 choukasharelucknotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&choukasharelucknotify;
		}
		/** 领取幸运值奖励请求 **/
		if((NetMsgId)msgId==DRAW_LUCK_PACKAGE_REQUEST){
		 drawluckpackagerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&drawluckpackagerequest;
		}
		/** 领取幸运值奖励回应 **/
		if((NetMsgId)msgId==DRAW_LUCK_PACKAGE_ANSWER){
		 drawluckpackageanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&drawluckpackageanswer;
		}
		/** 判军列表请求 **/
		if((NetMsgId)msgId==REBEL_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 判军列表应答 **/
		if((NetMsgId)msgId==REBEL_LIST_ANSWER){
		 rebellistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebellistanswer;
		}
		/** 判军分享线好友请求 **/
		if((NetMsgId)msgId==REBEL_SHARE_REQUEST){
		 rebelsharerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelsharerequest;
		}
		/** 判军分享线好友应答 **/
		if((NetMsgId)msgId==REBEL_SHARE_ANSWER){
		 rebelshareanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelshareanswer;
		}
		/** 判军副本开始请求 **/
		if((NetMsgId)msgId==REBEL_RAID_START_REQUEST){
		 rebelraidstartrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelraidstartrequest;
		}
		/** 判军副本开始应答 **/
		if((NetMsgId)msgId==REBEL_RAID_START_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 判军伤害排行榜请求 **/
		if((NetMsgId)msgId==REBEL_HURT_RANK_REQUEST){
		 rebelhurtrankrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelhurtrankrequest;
		}
		/** 判军伤害排行榜应答 **/
		if((NetMsgId)msgId==REBEL_HURT_RANK_ANSWER){
		 rebelrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelrankanswer;
		}
		/** 判军每日累计排行奖励领取请求 **/
		if((NetMsgId)msgId==REBEL_EXPLOIT_REWARD_REQUEST){
		 rebelexploitrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelexploitrewardrequest;
		}
		/** 判军每日累计排行奖励领取应答 **/
		if((NetMsgId)msgId==REBEL_EXPLOIT_REWARD_ANSWER){
		 rebelexploitrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelexploitrewardanswer;
		}
		/** boss叛军请求 **/
		if((NetMsgId)msgId==REBEL_BOSS_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** boss叛军应答 **/
		if((NetMsgId)msgId==REBEL_BOSS_LIST_ANSWER){
		 rebelbosslistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelbosslistanswer;
		}
		/** boss判军功勋排行榜请求 **/
		if((NetMsgId)msgId==REBEL_BOSS_CREDIT_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** boss判军功勋排行榜应答 **/
		if((NetMsgId)msgId==REBEL_BOSS_CREDIT_RANK_ANSWER){
		 rebelrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelrankanswer;
		}
		/** 判军BOSS副本开始请求 **/
		if((NetMsgId)msgId==REBEL_BOSS_START_REQUEST){
		 rebelraidstartrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelraidstartrequest;
		}
		/** 判军BOSS副本开始应答 **/
		if((NetMsgId)msgId==REBEL_BOSS_START_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** BOSS判军伤害排行榜请求 **/
		if((NetMsgId)msgId==REBEL_BOSS_HURT_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** BOSS判军伤害排行榜应答 **/
		if((NetMsgId)msgId==REBEL_BOSS_HURT_RANK_ANSWER){
		 rebelrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelrankanswer;
		}
		/** 每日判军功勋排行榜请求 **/
		if((NetMsgId)msgId==REBEL_CREDIT_DAILY_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 每日判军功勋排行榜应答 **/
		if((NetMsgId)msgId==REBEL_CREDIT_DAILY_RANK_ANSWER){
		 rebelrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelrankanswer;
		}
		/** 每日判军伤害排行榜请求 **/
		if((NetMsgId)msgId==REBEL_HURT_DAILY_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 每日判军伤害排行榜应答 **/
		if((NetMsgId)msgId==REBEL_HURT_DAILY_RANK_ANSWER){
		 rebelrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelrankanswer;
		}
		/** 是否需要展示分享界面通知 **/
		if((NetMsgId)msgId==REBEL_SHARE_FLAG_NOTIFY){
		 rebelshareflagnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelshareflagnotify;
		}
		/** 新叛军通知 **/
		if((NetMsgId)msgId==REBEL_CREATE_FLAG_NOTIFY){
		 rebelcreateflagnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebelcreateflagnotify;
		}
		/** 神将商店请求 **/
		if((NetMsgId)msgId==SHENJIANG_SHOP_REQUEST){
		 shenjiangshoprequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&shenjiangshoprequest;
		}
		/** 神将商店请求 **/
		if((NetMsgId)msgId==SHENJIANG_SHOP_BUY_REQUEST){
		 shenjiangshopbuyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&shenjiangshopbuyrequest;
		}
		/** 神将商店应答 **/
		if((NetMsgId)msgId==SHENJIANG_SHOP_ANSWER){
		 shenjiangshopanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&shenjiangshopanswer;
		}
		/** 玩法商店请求 **/
		if((NetMsgId)msgId==SHOP_PLAY_INFO_REQUEST){
		 shopplayinforequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&shopplayinforequest;
		}
		/** 玩法商店应答 **/
		if((NetMsgId)msgId==SHOP_PLAY_ANSWER){
		 shopplayinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&shopplayinfoanswer;
		}
		/** 玩法商店购买请求 **/
		if((NetMsgId)msgId==SHOP_PLAY_BUY_REQUEST){
		 shopplaybuyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&shopplaybuyrequest;
		}
		/** 玩法商店购买应答 **/
		if((NetMsgId)msgId==SHOP_PLAY_BUY_ANSWER){
		 shopplaybuyanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&shopplaybuyanswer;
		}
		/** 穿宝物请求 **/
		if((NetMsgId)msgId==TREASURE_DRESS_REQUEST){
		 treasuredressrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&treasuredressrequest;
		}
		/** 穿宝物应答 **/
		if((NetMsgId)msgId==TREASURE_DRESS_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 脱宝物请求 **/
		if((NetMsgId)msgId==TREASURE_UNDRESS_REQUEST){
		 treasuredressrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&treasuredressrequest;
		}
		/** 脱宝物应答 **/
		if((NetMsgId)msgId==TREASURE_UNDRESS_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 宝物强化请求 **/
		if((NetMsgId)msgId==TREASURE_STRENGTHEN_REQUEST){
		 treasurestrengthenrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&treasurestrengthenrequest;
		}
		/** 宝物强化应答 **/
		if((NetMsgId)msgId==TREASURE_STRENGTHEN_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 宝物精练请求 **/
		if((NetMsgId)msgId==TREASURE_REFINING_REQUEST){
		 treasurerefiningrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&treasurerefiningrequest;
		}
		/** 宝物精练应答 **/
		if((NetMsgId)msgId==TREASURE_REFINING_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 宝物铸造请求 **/
		if((NetMsgId)msgId==TREASURE_FORGE_REQUEST){
		 treasureforgerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&treasureforgerequest;
		}
		/** 宝物铸造应答 **/
		if((NetMsgId)msgId==TREASURE_FORGE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 宝物出售请求 **/
		if((NetMsgId)msgId==TREASURE_SELL_REQUEST){
		 treasuresellrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&treasuresellrequest;
		}
		/** 宝物出售应答 **/
		if((NetMsgId)msgId==TREASURE_SELL_ANSWER){
		 commonsellanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonsellanswer;
		}
		/** 胭脂列表请求 **/
		if((NetMsgId)msgId==BLUSHER_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 胭脂列表应答 **/
		if((NetMsgId)msgId==BLUSHER_LIST_ANSWER){
		 blusherlistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&blusherlistanswer;
		}
		/** 胭脂取悦请求 **/
		if((NetMsgId)msgId==BLUSHER_WOO_REQUEST){
		 blusherwoorequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&blusherwoorequest;
		}
		/** 胭脂取悦应答 **/
		if((NetMsgId)msgId==BLUSHER_WOO_ANSWER){
		 blusherrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&blusherrewardanswer;
		}
		/** 胭脂点赞请求 **/
		if((NetMsgId)msgId==BLUSHER_ADMIRE_REQUEST){
		 blusheroperrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&blusheroperrequest;
		}
		/** 胭脂点赞应答 **/
		if((NetMsgId)msgId==BLUSHER_ADMIRE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 胭脂领取升级奖励请求 **/
		if((NetMsgId)msgId==BLUSHER_UPLV_REWARD_REQUEST){
		 blusheroperrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&blusheroperrequest;
		}
		/** 胭脂领取升级奖励应答 **/
		if((NetMsgId)msgId==BLUSHER_UPLV_REWARD_ANSWER){
		 blusherrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&blusherrewardanswer;
		}
		/** 胭脂领取奇遇奖励请求 **/
		if((NetMsgId)msgId==BLUSHER_LUCK_REWARD_REQUEST){
		 blusheroperrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&blusheroperrequest;
		}
		/** 胭脂领取奇遇奖励应答 **/
		if((NetMsgId)msgId==BLUSHER_LUCK_REWARD_ANSWER){
		 blusherrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&blusherrewardanswer;
		}
		/** 胭脂排行请求 **/
		if((NetMsgId)msgId==BLUSHER_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 胭脂排行应答 **/
		if((NetMsgId)msgId==BLUSHER_RANK_ANSWER){
		 blusherrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&blusherrankanswer;
		}
		/** 胭脂榜商店购买请求 **/
		if((NetMsgId)msgId==BLUSHER_SHOP_BUY_REQUEST){
		 shopbuyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&shopbuyrequest;
		}
		/** 胭脂榜商店购买应答 **/
		if((NetMsgId)msgId==BLUSHER_SHOP_BUY_ANSWER){
		 shopplaybuyanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&shopplaybuyanswer;
		}
		/** 发送聊天请求 **/
		if((NetMsgId)msgId==CHAT_SEND_REQUEST){
		 chatsendrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&chatsendrequest;
		}
		/** 发送聊天应答 **/
		if((NetMsgId)msgId==CHAT_SEND_ANSWER){
		 chatsendanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&chatsendanswer;
		}
		/** 聊天消息通知 **/
		if((NetMsgId)msgId==CHAT_MSG_NOTIFY){
		 chatmsgnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&chatmsgnotify;
		}
		/** 广播消息通知 **/
		if((NetMsgId)msgId==BROADCAST_NOTIFY){
		 broadcastnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&broadcastnotify;
		}
		/** 公告通知 **/
		if((NetMsgId)msgId==ANNOUNCEMENT_NOTIFY){
		 announcementnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&announcementnotify;
		}
		/** 模块订阅请求 **/
		if((NetMsgId)msgId==MODULE_SUBSCRIBE_REQUEST){
		 modulesubscriberequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&modulesubscriberequest;
		}
		/** 吃黄瓜请求 **/
		if((NetMsgId)msgId==EAT_CUCUMBER_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 吃黄瓜应答 **/
		if((NetMsgId)msgId==EAT_CUCUMBER_ANSWER){
		 eatcucumberanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&eatcucumberanswer;
		}
		/** 日常任务列表 **/
		if((NetMsgId)msgId==TASK_DAILY_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 日常任务应答 **/
		if((NetMsgId)msgId==TASK_DAILY_LIST_ANSWER){
		 tasklistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&tasklistanswer;
		}
		/** 日常任务获取奖励列表 **/
		if((NetMsgId)msgId==TASK_DAILY_GET_REWARD_REQUEST){
		 taskgetrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardrequest;
		}
		/** 日常任务获取奖励应答 **/
		if((NetMsgId)msgId==TASK_DAILY_GET_REWARD_ANSWER){
		 taskgetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardanswer;
		}
		/** 日常任务宝箱奖励请求 **/
		if((NetMsgId)msgId==TASK_DAILY_BOX_REWARD_REQUEST){
		 taskgetrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardrequest;
		}
		/** 日常任务宝箱奖励应答 **/
		if((NetMsgId)msgId==TASK_DAILY_BOX_REWARD_ANSWER){
		 taskgetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardanswer;
		}
		/** 主线任务列表 **/
		if((NetMsgId)msgId==TASK_SEVEN_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 主线任务应答 **/
		if((NetMsgId)msgId==TASK_SEVEN_LIST_ANSWER){
		 tasklistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&tasklistanswer;
		}
		/** 主线任务获取奖励列表 **/
		if((NetMsgId)msgId==TASK_SEVEN_GET_REWARD_REQUEST){
		 taskgetrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardrequest;
		}
		/** 主线任务获取奖励应答 **/
		if((NetMsgId)msgId==TASK_SEVEN_GET_REWARD_ANSWER){
		 taskgetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardanswer;
		}
		/** 七日半价购买请求 **/
		if((NetMsgId)msgId==TASK_SEVEN_BUY_REWARD_REQUEST){
		 taskgetrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardrequest;
		}
		/** 七日半价购买应答 **/
		if((NetMsgId)msgId==TASK_SEVEN_BUY_REWARD_ANSWER){
		 taskgetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardanswer;
		}
		/** 七日活动碎片奖励请求 **/
		if((NetMsgId)msgId==TASK_SEVEN_CHIP_REWARD_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 七日活动碎片奖励应答 **/
		if((NetMsgId)msgId==TASK_SEVEN_CHIP_REWARD_ANSWER){
		 taskgetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardanswer;
		}
		/** 成就任务列表 **/
		if((NetMsgId)msgId==TASK_VOSTRO_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 成就任务应答 **/
		if((NetMsgId)msgId==TASK_VOSTRO_LIST_ANSWER){
		 tasklistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&tasklistanswer;
		}
		/** 成就任务获取奖励列表 **/
		if((NetMsgId)msgId==TASK_VOSTRO_GET_REWARD_REQUEST){
		 taskgetrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardrequest;
		}
		/** 成就任务获取奖励应答 **/
		if((NetMsgId)msgId==TASK_VOSTRO_GET_REWARD_ANSWER){
		 taskgetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardanswer;
		}
		/** 签到请求 **/
		if((NetMsgId)msgId==SIGN_REQUEST){
		 signrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&signrequest;
		}
		/** 签到应答 **/
		if((NetMsgId)msgId==SIGN_ANSWER){
		 signanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&signanswer;
		}
		/** 豪华签到领取奖励请求 **/
		if((NetMsgId)msgId==LUXURY_SIGN_GET_REWARD_REQUEST){
		 luxurysigngetrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&luxurysigngetrewardrequest;
		}
		/** 豪华签到领取奖励应答 **/
		if((NetMsgId)msgId==LUXURY_SIGN_GET_REWARD_ANSWER){
		 luxurysigngetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&luxurysigngetrewardanswer;
		}
		/** 摇钱树请求 **/
		if((NetMsgId)msgId==MONEY_TREE_REQUEST){
		 moneytreerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&moneytreerequest;
		}
		/** 摇钱树应答 **/
		if((NetMsgId)msgId==MONEY_TREE_ANSWER){
		 moneytreeanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&moneytreeanswer;
		}
		/** 活动列表请求 **/
		if((NetMsgId)msgId==ACTIVITY_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 活动列表应答 **/
		if((NetMsgId)msgId==ACTIVITY_LIST_ANSWER){
		 activitylistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&activitylistanswer;
		}
		/** 活动领取奖励请求 **/
		if((NetMsgId)msgId==ACTIVITY_REWARD_REQUEST){
		 activityrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&activityrewardrequest;
		}
		/** 活动领取奖励应答 **/
		if((NetMsgId)msgId==ACTIVITY_REWARD_ANSWER){
		 taskgetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&taskgetrewardanswer;
		}
		/** 领取VIP每日福利请求 **/
		if((NetMsgId)msgId==DRAW_VIP_WELFARE_REQUEST){
		 drawvipdailywelfarerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&drawvipdailywelfarerequest;
		}
		/** 领取VIP每日福利应答 **/
		if((NetMsgId)msgId==DRAW_VIP_WELFARE_ANSWER){
		 drawvipdailywelfareanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&drawvipdailywelfareanswer;
		}
		/** 开服排行活动信息请求 **/
		if((NetMsgId)msgId==OPENSRV_RANK_ACTIVITY_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 开服排行活动信息 **/
		if((NetMsgId)msgId==OPENSRV_RANK_ACTIVITY_ANSWER){
		 opensrvrankactivityinfo.ParseFromArray(protoBuf,len);
		 *result=(char*)&opensrvrankactivityinfo;
		}
		/** 开服排行活动领取奖励请求 **/
		if((NetMsgId)msgId==OPENSRV_RANK_DRAW_AWARD_REQUEST){
		 opensrvrankdrawawardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&opensrvrankdrawawardrequest;
		}
		/** 开服排行活动领取奖励应答 **/
		if((NetMsgId)msgId==OPENSRV_RANK_DRAW_AWARD_ANSWER){
		 opensrvrankdrawawardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&opensrvrankdrawawardanswer;
		}
		/** vip周礼包信息请求 **/
		if((NetMsgId)msgId==VIP_WEEK_PACKAGE_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** vip周礼包信息应答 **/
		if((NetMsgId)msgId==VIP_WEEK_PACKAGE_INFO_ANSWER){
		 vipweekpackageinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&vipweekpackageinfoanswer;
		}
		/** vip周礼购买请求 **/
		if((NetMsgId)msgId==VIP_WEEK_PACKAGE_BUY_REQUEST){
		 vipweekpackagebuyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&vipweekpackagebuyrequest;
		}
		/** vip周礼购买应答 **/
		if((NetMsgId)msgId==VIP_WEEK_PACKAGE_BUY_ANSWER){
		 vipweekpackagebuyanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&vipweekpackagebuyanswer;
		}
		/** 福袋通知 **/
		if((NetMsgId)msgId==BLESSING_BAG_NOTIFY){
		 blessingbagnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&blessingbagnotify;
		}
		/** 登录公告通知 **/
		if((NetMsgId)msgId==ENTER_GAME_GUIDE_NOTIFY){
		 entergameguidenotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&entergameguidenotify;
		}
		/** 主角升级通知 **/
		if((NetMsgId)msgId==LEVEL_UP_NOTIFY){
		 levelupnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&levelupnotify;
		}
		/** 排行榜请求 **/
		if((NetMsgId)msgId==COMMON_RANK_REQUEST){
		 commonrankrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrankrequest;
		}
		/** 排行榜应答 **/
		if((NetMsgId)msgId==COMMON_RANK_ANSWER){
		 commonrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrankanswer;
		}
		/** 排行榜点赞请求 **/
		if((NetMsgId)msgId==COMMON_RANK_LIKE_REQUEST){
		 commonranklikerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonranklikerequest;
		}
		/** 排行榜点赞应答 **/
		if((NetMsgId)msgId==COMMON_RANK_LIKE_ANSWER){
		 commonranklikeanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonranklikeanswer;
		}
		/** 查看玩家请求 **/
		if((NetMsgId)msgId==VIEW_PLAYER_REQUEST){
		 viewplayerrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&viewplayerrequest;
		}
		/** 查看玩家应答 **/
		if((NetMsgId)msgId==VIEW_PLAYER_ANSWER){
		 viewplayeranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&viewplayeranswer;
		}
		/** 切磋请求 **/
		if((NetMsgId)msgId==QIECUO_START_REQUEST){
		 qiecuostartrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&qiecuostartrequest;
		}
		/** 切磋开始请求(排行服-游戏服) **/
		if((NetMsgId)msgId==QIECUO_START_SERVER_REQUEST){
		 qiecuostartserverrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&qiecuostartserverrequest;
		}
		/** 切磋应答 **/
		if((NetMsgId)msgId==QIECUO_START_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 好友列表请求 **/
		if((NetMsgId)msgId==FRIEND_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 好友列表应答 **/
		if((NetMsgId)msgId==FRIEND_LIST_ANSWER){
		 friendlistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendlistanswer;
		}
		/** 好友申请请求 **/
		if((NetMsgId)msgId==FRIEND_APPLY_ADD_REQUEST){
		 friendoperatorrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatorrequest;
		}
		/** 好友申请应答 **/
		if((NetMsgId)msgId==FRIEND_APPLY_ADD_ANSWER){
		 friendoperatoranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatoranswer;
		}
		/** 好友申请同意请求 **/
		if((NetMsgId)msgId==FRIEND_AGREE_REQUEST){
		 friendoperatorrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatorrequest;
		}
		/** 好友申请同意应答 **/
		if((NetMsgId)msgId==FRIEND_AGREE_ANSWER){
		 friendoperatoranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatoranswer;
		}
		/** 好友申请拒绝请求 **/
		if((NetMsgId)msgId==FRIEND_REFUSE_REQUEST){
		 friendoperatorrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatorrequest;
		}
		/** 好友申请拒绝应答 **/
		if((NetMsgId)msgId==FRIEND_REFUSE_ANSWER){
		 friendoperatoranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatoranswer;
		}
		/** 删除好友请求 **/
		if((NetMsgId)msgId==FRIEND_DEL_REQUEST){
		 friendoperatorrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatorrequest;
		}
		/** 删除好友应答 **/
		if((NetMsgId)msgId==FRIEND_DEL_ANSWER){
		 friendoperatoranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatoranswer;
		}
		/** 赠送精力请求 **/
		if((NetMsgId)msgId==FRIEND_SEND_ENERGY_REQUEST){
		 friendoperatorrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatorrequest;
		}
		/** 赠送精力应答 **/
		if((NetMsgId)msgId==FRIEND_SEND_ENERGY_ANSWER){
		 friendoperatoranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatoranswer;
		}
		/** 接受精力请求 **/
		if((NetMsgId)msgId==FRIEND_RECV_ENERGY_REQUEST){
		 friendoperatorrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatorrequest;
		}
		/** 接受精力应答 **/
		if((NetMsgId)msgId==FRIEND_RECV_ENERGY_ANSWER){
		 friendrecvenergyanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendrecvenergyanswer;
		}
		/** 好友申请列表请求 **/
		if((NetMsgId)msgId==FRIEND_APPLY_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 好友申请列表应答 **/
		if((NetMsgId)msgId==FRIEND_APPLY_LIST_ANSWER){
		 friendlistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendlistanswer;
		}
		/** 好友推荐请求 **/
		if((NetMsgId)msgId==FRIEND_RECOMMEND_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 好友推荐应答 **/
		if((NetMsgId)msgId==FRIEND_RECOMMEND_ANSWER){
		 friendlistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendlistanswer;
		}
		/** 设置好友黑名单请求 **/
		if((NetMsgId)msgId==FRIEND_BLACKLIST_REQUEST){
		 friendoperatorrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatorrequest;
		}
		/** 设置好友黑名单应答 **/
		if((NetMsgId)msgId==FRIEND_BLACKLIST_ANSWER){
		 friendoperatoranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatoranswer;
		}
		/** 取消好友黑名单请求 **/
		if((NetMsgId)msgId==FRIEND_CANCEL_BLACKLIST_REQUEST){
		 friendoperatorrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatorrequest;
		}
		/** 取消好友黑名单应答 **/
		if((NetMsgId)msgId==FRIEND_CANCEL_BLACKLIST_ANSWER){
		 friendoperatoranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendoperatoranswer;
		}
		/** 黑名单列表请求 **/
		if((NetMsgId)msgId==BLACK_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 黑名单列表应答 **/
		if((NetMsgId)msgId==BLACK_LIST_ANSWER){
		 friendlistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendlistanswer;
		}
		/** 根据名字增加好友请求 **/
		if((NetMsgId)msgId==FRIEND_ADD_BY_NAME_REQUEST){
		 friendaddbynamerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&friendaddbynamerequest;
		}
		/** 新手引导提交 **/
		if((NetMsgId)msgId==GUILD_COMMIT_REQUEST){
		 guildcommitrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&guildcommitrequest;
		}
		/** 新手引导提交 **/
		if((NetMsgId)msgId==GUILD_COMMIT_ANSWER){
		 guildcommitrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&guildcommitrequest;
		}
		/** 使用兑换码结果 **/
		if((NetMsgId)msgId==USE_CDK_ANSWER){
		 usecdkanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&usecdkanswer;
		}
		/** 特殊奖励通知 **/
		if((NetMsgId)msgId==SPECIAL_AWARD_NOTIFY){
		 specialawardnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&specialawardnotify;
		}
		/** 帮派创建请求 **/
		if((NetMsgId)msgId==LEGION_CREATE_REQUEST){
		 legioncreaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legioncreaterequest;
		}
		/** 帮派创建应答 **/
		if((NetMsgId)msgId==LEGION_CREATE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 帮派解散请求 **/
		if((NetMsgId)msgId==LEGION_DELETE_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派解散应答 **/
		if((NetMsgId)msgId==LEGION_DELETE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 帮派信息请求 **/
		if((NetMsgId)msgId==LEGION_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派信息应答 **/
		if((NetMsgId)msgId==LEGION_INFO_ANSWER){
		 legioninfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legioninfoanswer;
		}
		/** 帮派成员列表请求 **/
		if((NetMsgId)msgId==LEGION_MEMBER_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派成员列表应答 **/
		if((NetMsgId)msgId==LEGION_MEMBER_LIST_ANSWER){
		 legionmemberlistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionmemberlistanswer;
		}
		/** 帮派动态请求 **/
		if((NetMsgId)msgId==LEGION_EVENT_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派动态应答 **/
		if((NetMsgId)msgId==LEGION_EVENT_ANSWER){
		 legioneventanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legioneventanswer;
		}
		/** 帮派列表请求 **/
		if((NetMsgId)msgId==LEGION_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派列表应答 **/
		if((NetMsgId)msgId==LEGION_LIST_ANSWER){
		 legionlistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionlistanswer;
		}
		/** 帮派入帮申请请求 **/
		if((NetMsgId)msgId==LEGION_APPLY_REQUEST){
		 legionapplyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionapplyrequest;
		}
		/** 帮派入帮申请应答 **/
		if((NetMsgId)msgId==LEGION_APPLY_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 帮派撤销申请请求 **/
		if((NetMsgId)msgId==LEGION_CANCEL_APPLY_REQUEST){
		 legionapplyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionapplyrequest;
		}
		/** 帮派撤销申请应答 **/
		if((NetMsgId)msgId==LEGION_CANCEL_APPLY_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 帮派申请列表请求 **/
		if((NetMsgId)msgId==LEGION_APPLY_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派申请列表应答 **/
		if((NetMsgId)msgId==LEGION_APPLY_LIST_ANSWER){
		 legionapplylistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionapplylistanswer;
		}
		/** 帮派接受入帮申请请求 **/
		if((NetMsgId)msgId==LEGION_ACCEPT_APPLY_REQUEST){
		 legionoperaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperaterequest;
		}
		/** 帮派接受入帮申请应答 **/
		if((NetMsgId)msgId==LEGION_ACCEPT_APPLY_ANSWER){
		 legionoperateanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperateanswer;
		}
		/** 帮派拒绝入帮申请请求 **/
		if((NetMsgId)msgId==LEGION_REFUSE_APPLY_REQUEST){
		 legionoperaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperaterequest;
		}
		/** 帮派拒绝入帮申请应答 **/
		if((NetMsgId)msgId==LEGION_REFUSE_APPLY_ANSWER){
		 legionoperateanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperateanswer;
		}
		/** 帮派任命副帮主请求 **/
		if((NetMsgId)msgId==LEGION_APPOINT_REQUEST){
		 legionoperaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperaterequest;
		}
		/** 帮派任命副帮主应答 **/
		if((NetMsgId)msgId==LEGION_APPOINT_ANSWER){
		 legionoperateanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperateanswer;
		}
		/** 帮派罢免副帮主请求 **/
		if((NetMsgId)msgId==LEGION_DISMISS_REQUEST){
		 legionoperaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperaterequest;
		}
		/** 帮派罢免副帮主应答 **/
		if((NetMsgId)msgId==LEGION_DISMISS_ANSWER){
		 legionoperateanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperateanswer;
		}
		/** 帮派移交帮主请求 **/
		if((NetMsgId)msgId==LEGION_TRANSFER_REQUEST){
		 legionoperaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperaterequest;
		}
		/** 帮派移交帮主应答 **/
		if((NetMsgId)msgId==LEGION_TRANSFER_ANSWER){
		 legionoperateanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperateanswer;
		}
		/** 帮派踢出请求 **/
		if((NetMsgId)msgId==LEGION_MEMBER_DEL_REQUEST){
		 legionoperaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperaterequest;
		}
		/** 帮派踢出应答 **/
		if((NetMsgId)msgId==LEGION_MEMBER_DEL_ANSWER){
		 legionoperateanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperateanswer;
		}
		/** 帮派退出请求 **/
		if((NetMsgId)msgId==LEGION_QUIT_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派退出应答 **/
		if((NetMsgId)msgId==LEGION_QUIT_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 帮派弹劾请求 **/
		if((NetMsgId)msgId==LEGION_IMPEACH_REQUEST){
		 legionoperaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionoperaterequest;
		}
		/** 帮派弹劾应答 **/
		if((NetMsgId)msgId==LEGION_IMPEACH_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 帮派标志修改请求 **/
		if((NetMsgId)msgId==LEGION_CHANGE_LOGO_REQUEST){
		 legionchangelogorequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionchangelogorequest;
		}
		/** 帮派标志修改应答 **/
		if((NetMsgId)msgId==LEGION_CHANGE_LOGO_ANSWER){
		 legionchangelogoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionchangelogoanswer;
		}
		/** 帮派修改宣言请求 **/
		if((NetMsgId)msgId==LEGION_CHANGE_DECLARATION_REQUEST){
		 legionchangebulletinrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionchangebulletinrequest;
		}
		/** 帮派修改宣言应答 **/
		if((NetMsgId)msgId==LEGION_CHANGE_DECLARATION_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 帮派修改公告请求 **/
		if((NetMsgId)msgId==LEGION_CHANGE_BULLETIN_REQUEST){
		 legionchangebulletinrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionchangebulletinrequest;
		}
		/** 帮派修改公告应答 **/
		if((NetMsgId)msgId==LEGION_CHANGE_BULLETIN_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 帮派留言板请求 **/
		if((NetMsgId)msgId==LEGION_MESSAGE_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派留言板应答 **/
		if((NetMsgId)msgId==LEGION_MESSAGE_ANSWER){
		 legionmessageanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionmessageanswer;
		}
		/** 帮派留言请求 **/
		if((NetMsgId)msgId==LEGION_SEND_MESSAGE_REQUEST){
		 legionsendmessagerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionsendmessagerequest;
		}
		/** 帮派留言应答 **/
		if((NetMsgId)msgId==LEGION_SEND_MESSAGE_ANSWER){
		 legionsendmessageanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionsendmessageanswer;
		}
		/** 帮派置顶留言请求 **/
		if((NetMsgId)msgId==LEGION_STICKY_MESSAGE_REQUEST){
		 legionstickymessagerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionstickymessagerequest;
		}
		/** 帮派置顶留言应答 **/
		if((NetMsgId)msgId==LEGION_STICKY_MESSAGE_ANSWER){
		 legionstickymessageanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionstickymessageanswer;
		}
		/** 帮派取消置顶留言请求 **/
		if((NetMsgId)msgId==LEGION_CANCEL_STICKY_MESSAGE_REQUEST){
		 legionstickymessagerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionstickymessagerequest;
		}
		/** 帮派取消置顶留言应答 **/
		if((NetMsgId)msgId==LEGION_CANCEL_STICKY_MESSAGE_ANSWER){
		 legionstickymessageanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionstickymessageanswer;
		}
		/** 帮派祭天请求 **/
		if((NetMsgId)msgId==LEGION_WORSHIP_REQUEST){
		 legionworshiprequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionworshiprequest;
		}
		/** 帮派祭天应答 **/
		if((NetMsgId)msgId==LEGION_WORSHIP_ANSWER){
		 legionworshipanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionworshipanswer;
		}
		/** 帮派祭天开箱子请求 **/
		if((NetMsgId)msgId==LEGION_WORSHIP_OPEN_BOX_REQUEST){
		 legionworshipopenboxrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionworshipopenboxrequest;
		}
		/** 帮派祭天开箱子应答 **/
		if((NetMsgId)msgId==LEGION_WORSHIP_OPEN_BOX_ANSWER){
		 legionworshipopenboxanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionworshipopenboxanswer;
		}
		/** 军团限时商店信息请求 **/
		if((NetMsgId)msgId==LEGION_LIMIT_SHOP_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 军团限时商店信息 **/
		if((NetMsgId)msgId==LEGION_LIMIT_SHOP_INFO_ANSWER){
		 legionlimitshopinfo.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionlimitshopinfo;
		}
		/** 军团限时商店购买请求 **/
		if((NetMsgId)msgId==LEGION_LIMIT_SHOP_BUY_REQUEST){
		 legionlimitshopbuyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionlimitshopbuyrequest;
		}
		/** 军团限时商店购买应答 **/
		if((NetMsgId)msgId==LEGION_LIMIT_SHOP_BUY_ANSWER){
		 legionlimitshopbuyanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionlimitshopbuyanswer;
		}
		/** 帮派技能信息请求 **/
		if((NetMsgId)msgId==LEGION_SKILL_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派技能信息应答 **/
		if((NetMsgId)msgId==LEGION_SKILL_INFO_ANSWER){
		 legionskillinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionskillinfoanswer;
		}
		/** 帮派技能升级请求 **/
		if((NetMsgId)msgId==LEGION_SKILL_UPLEVEL_REQUEST){
		 legionskilloperaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionskilloperaterequest;
		}
		/** 帮派技能升级应答 **/
		if((NetMsgId)msgId==LEGION_SKILL_UPLEVEL_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 帮派技能提升等级上限请求 **/
		if((NetMsgId)msgId==LEGION_SKILL_UPLIMIT_REQUEST){
		 legionskilloperaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionskilloperaterequest;
		}
		/** 帮派技能提升等级上限应答 **/
		if((NetMsgId)msgId==LEGION_SKILL_UPLIMIT_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 帮派排行榜请求 **/
		if((NetMsgId)msgId==LEGION_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派排行榜应答 **/
		if((NetMsgId)msgId==LEGION_RANK_ANSWER){
		 legionrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionrankanswer;
		}
		/** 帮派修改收人条件请求 **/
		if((NetMsgId)msgId==LEGION_CHANGE_ACCEPT_TPYE_REQUEST){
		 legionchangeaccepttyperequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionchangeaccepttyperequest;
		}
		/** 帮派修改收人条件应答 **/
		if((NetMsgId)msgId==LEGION_CHANGE_ACCEPT_TPYE_ANSWER){
		 legionchangeaccepttypeanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionchangeaccepttypeanswer;
		}
		/** 占山为王进度请求 **/
		if((NetMsgId)msgId==KING_FIGHT_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 占山为王进度应答 **/
		if((NetMsgId)msgId==KING_FIGHT_ANSWER){
		 kingfightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightanswer;
		}
		/** 占山为王关卡数据请求 **/
		if((NetMsgId)msgId==KING_FIGHT_STAGE_INFO_REQUEST){
		 kingfightstageinforequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightstageinforequest;
		}
		/** 占山为王关卡数据应答 **/
		if((NetMsgId)msgId==KING_FIGHT_STAGE_INFO_ANSWER){
		 kingfightstageinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightstageinfoanswer;
		}
		/** 挑战占山为王关卡请求 **/
		if((NetMsgId)msgId==KING_FIGHT_START_REQUEST){
		 kingfightstartrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightstartrequest;
		}
		/** 挑战占山为王关卡应答 **/
		if((NetMsgId)msgId==KING_FIGHT_START_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 占山为王道具使用请求 **/
		if((NetMsgId)msgId==KING_FIGHT_USE_ITEM_REQUEST){
		 kingfightuseitemrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightuseitemrequest;
		}
		/** 占山为王道具使用应答 **/
		if((NetMsgId)msgId==KING_FIGHT_USE_ITEM_ANSWER){
		 kingfightuseitemanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightuseitemanswer;
		}
		/** 占山为王购买次数请求 **/
		if((NetMsgId)msgId==KING_FIGHT_BUY_CNT_REQUEST){
		 kingfightbuycntrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightbuycntrequest;
		}
		/** 占山为王购买次数应答 **/
		if((NetMsgId)msgId==KING_FIGHT_BUY_CNT_ANSWER){
		 kingfightbuycntanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightbuycntanswer;
		}
		/** 占山为王星级排行请求 **/
		if((NetMsgId)msgId==KING_FIGHT_RANK_STAR_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 占山为王星级排行应答 **/
		if((NetMsgId)msgId==KING_FIGHT_RANK_STAR_ANSWER){
		 kingfightrankstaranswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightrankstaranswer;
		}
		/** 占山为王伤害排行请求 **/
		if((NetMsgId)msgId==KING_FIGHT_RANK_DAMAGE_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 占山为王伤害排行应答 **/
		if((NetMsgId)msgId==KING_FIGHT_RANK_DAMAGE_ANSWER){
		 kingfightrankdamageanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightrankdamageanswer;
		}
		/** 占山为王据点快捷查看信息请求 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_ALL_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 占山为王据点快捷查看信息应答 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_ALL_INFO_ANSWER){
		 crusadefortressallinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressallinfoanswer;
		}
		/** 占山为王据点信息请求 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_INFO_REQUEST){
		 crusadefortressinforequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressinforequest;
		}
		/** 占山为王据点信息应答 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_INFO_ANSWER){
		 crusadefortressinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressinfoanswer;
		}
		/** 占山为王据点挑战请求 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_FIGHT_REQUEST){
		 crusadefortressfightrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressfightrequest;
		}
		/** 占山为王据点挑战应答 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_FIGHT_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 占山为王据点领取进度宝箱请求 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_OPEN_BOX_REQUEST){
		 crusadefortressopenboxrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressopenboxrequest;
		}
		/** 占山为王据点领取进度宝箱回复 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_OPEN_BOX_ANSWER){
		 crusadefortressopenboxanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressopenboxanswer;
		}
		/** 占山为王据点领取据点收益请求 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_REWARD_REQUEST){
		 crusadefortressrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressrewardrequest;
		}
		/** 占山为王据点领取据点收益应答 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_REWARD_ANSWER){
		 crusadefortressopenboxanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressopenboxanswer;
		}
		/** 占山为王据点战斗记录请求 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_BATTLE_RECORD_REQUEST){
		 crusadefortressbattlerecordrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressbattlerecordrequest;
		}
		/** 占山为王据点战斗记录应答 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_BATTLE_RECORD_ANSWER){
		 crusadefortressbattlerecordanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressbattlerecordanswer;
		}
		/** 占山为王据点战斗回放请求 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_REPLAY_RECORD_REQUEST){
		 crusadefortressreplayrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressreplayrequest;
		}
		/** 占山为王据点战斗回放应答 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_REPLAY_RECORD_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 占山为王据点擂主购买buff请求 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_BUY_BUFF_REQUEST){
		 crusadefortressbuybuffrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressbuybuffrequest;
		}
		/** 占山为王据点擂主购买buff应答 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_BUY_BUFF_ANSWER){
		 crusadefortressbuybuffanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&crusadefortressbuybuffanswer;
		}
		/** 占山为王据点购买次数请求 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_BUY_CNT_REQUEST){
		 kingfightbuycntrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightbuycntrequest;
		}
		/** 占山为王据点购买次数应答 **/
		if((NetMsgId)msgId==CRUSADE_FORTRESS_BUY_CNT_ANSWER){
		 kingfightbuycntanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&kingfightbuycntanswer;
		}
		/** 武帝预选排名请求 **/
		if((NetMsgId)msgId==WUDI_PRESELECT_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 武帝预选排名应答 **/
		if((NetMsgId)msgId==WUDI_PRESELECT_RANK_ANSWER){
		 wudipreselectrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&wudipreselectrankanswer;
		}
		/** 武帝信息请求 **/
		if((NetMsgId)msgId==WUDI_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 武帝信息应答 **/
		if((NetMsgId)msgId==WUDI_INFO_ANSWER){
		 wudiinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&wudiinfoanswer;
		}
		/** 武帝挑战请求 **/
		if((NetMsgId)msgId==WUDI_FIGHT_REQUEST){
		 wudifightrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&wudifightrequest;
		}
		/** 武帝挑战应答 **/
		if((NetMsgId)msgId==WUDI_FIGHT_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 武帝伤害排行请求 **/
		if((NetMsgId)msgId==WUDI_HURT_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 武帝伤害排行应答 **/
		if((NetMsgId)msgId==WUDI_HURT_RANK_ANSWER){
		 wudihurtrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&wudihurtrankanswer;
		}
		/** 购买武帝挑战次数请求 **/
		if((NetMsgId)msgId==BUY_WUDI_FIGHT_CNT_REQUEST){
		 buywudifightcntrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&buywudifightcntrequest;
		}
		/** 购买武帝挑战次数应答 **/
		if((NetMsgId)msgId==BUY_WUDI_FIGHT_CNT_ANSWER){
		 buywudifightcntanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&buywudifightcntanswer;
		}
		/** 购买武帝挑战buff请求 **/
		if((NetMsgId)msgId==BUY_WUDI_FIGHT_BUFF_REQUEST){
		 buywudifightbuffrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&buywudifightbuffrequest;
		}
		/** 购买武帝挑战buff应答 **/
		if((NetMsgId)msgId==BUY_WUDI_FIGHT_BUFF_ANSWER){
		 buywudifightbuffanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&buywudifightbuffanswer;
		}
		/** 购买武帝buff请求 **/
		if((NetMsgId)msgId==BUY_WUDI_BOSS_BUFF_REQUEST){
		 buywudibossbuffrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&buywudibossbuffrequest;
		}
		/** 购买武帝buff应答 **/
		if((NetMsgId)msgId==BUY_WUDI_BOSS_BUFF_ANSWER){
		 buywudibossbuffanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&buywudibossbuffanswer;
		}
		/** 武帝开放通知 **/
		if((NetMsgId)msgId==WUDI_OPEN_NOTIFY){
		 wudiopennotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&wudiopennotify;
		}
		/** 寻访信息请求 **/
		if((NetMsgId)msgId==VISIT_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 寻访信息应答 **/
		if((NetMsgId)msgId==VISIT_INFO_ANSWER){
		 visitinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitinfoanswer;
		}
		/** 寻访发车请求 **/
		if((NetMsgId)msgId==VISIT_START_REQUEST){
		 visitstartrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitstartrequest;
		}
		/** 寻访发车应答 **/
		if((NetMsgId)msgId==VISIT_START_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 寻访领取奖励请求 **/
		if((NetMsgId)msgId==VISIT_GET_REWARD_REQUEST){
		 visitgetrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitgetrewardrequest;
		}
		/** 寻访领取奖励应答 **/
		if((NetMsgId)msgId==VISIT_GET_REWARD_ANSWER){
		 visitgetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitgetrewardanswer;
		}
		/** 随机拜访信息请求 **/
		if((NetMsgId)msgId==VISIT_INFO_RANDOM_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 随机拜访信息应答 **/
		if((NetMsgId)msgId==VISIT_INFO_RANDOM_ANSWER){
		 visitinforandomanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitinforandomanswer;
		}
		/** 拜访好友列表请求 **/
		if((NetMsgId)msgId==VISIT_FRIEND_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 拜访好友列表应答 **/
		if((NetMsgId)msgId==VISIT_FRIEND_LIST_ANSWER){
		 visitfriendlistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitfriendlistanswer;
		}
		/** 拜访好友请求 **/
		if((NetMsgId)msgId==VISIT_FRIEND_REQUEST){
		 visitfriendrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitfriendrequest;
		}
		/** 拜访好友应答 **/
		if((NetMsgId)msgId==VISIT_FRIEND_ANSWER){
		 visitinforandomanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitinforandomanswer;
		}
		/** 领取好友驿站奖励请求 **/
		if((NetMsgId)msgId==VISIT_FRIEND_REWARD_REQUEST){
		 visitfriendrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitfriendrewardrequest;
		}
		/** 领取好友驿站奖励应答 **/
		if((NetMsgId)msgId==VISIT_FRIEND_REWARD_ANSWER){
		 visitfriendrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitfriendrewardanswer;
		}
		/** 好友加速请求 **/
		if((NetMsgId)msgId==VISIT_FRIEND_ACCELERATE_REQUEST){
		 visitfriendacceleraterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitfriendacceleraterequest;
		}
		/** 好友加速应答 **/
		if((NetMsgId)msgId==VISIT_FRIEND_ACCELERATE_ANSWER){
		 visitfriendaccelerateanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitfriendaccelerateanswer;
		}
		/** 寻访保存方案请求 **/
		if((NetMsgId)msgId==VISIT_SAVE_ROUTE_REQUEST){
		 visitsaverouterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitsaverouterequest;
		}
		/** 寻访保存方案应答 **/
		if((NetMsgId)msgId==VISIT_SAVE_ROUTE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 一键发车请求 **/
		if((NetMsgId)msgId==VISIT_ONE_KEY_START_REQUEST){
		 visitsaverouterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitsaverouterequest;
		}
		/** 一键发车应答 **/
		if((NetMsgId)msgId==VISIT_ONE_KEY_START_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 获取保存方案请求 **/
		if((NetMsgId)msgId==VISIT_GET_SAVE_ROUTE_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 获取保存方案答复 **/
		if((NetMsgId)msgId==VISIT_GET_SAVE_ROUTE_ANSWER){
		 visitgetsaverouteanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitgetsaverouteanswer;
		}
		/** 一键领取奖励请求 **/
		if((NetMsgId)msgId==VISIT_ONE_KEY_GET_REWARD_REQUEST){
		 visitonekeygetrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitonekeygetrewardrequest;
		}
		/** 一键领取奖励应答 **/
		if((NetMsgId)msgId==VISIT_ONE_KEY_GET_REWARD_ANSWER){
		 visitonekeygetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&visitonekeygetrewardanswer;
		}
		/** 开服基金请求 **/
		if((NetMsgId)msgId==OPEN_FUND_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 开服基金应答 **/
		if((NetMsgId)msgId==OPEN_FUND_ANSWER){
		 openfundanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&openfundanswer;
		}
		/** 购买开服基金请求 **/
		if((NetMsgId)msgId==OPEN_FUND_BUY_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 购买开服基金应答 **/
		if((NetMsgId)msgId==OPEN_FUND_BUY_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 领取开服基金请求 **/
		if((NetMsgId)msgId==OPEN_FUND_GET_REQUEST){
		 openfundgetrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&openfundgetrequest;
		}
		/** 领取开服基金应答 **/
		if((NetMsgId)msgId==OPEN_FUND_GET_ANSWER){
		 openfundgetanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&openfundgetanswer;
		}
		/** 领取全民福利请求 **/
		if((NetMsgId)msgId==UNIVERSAL_WELFARE_GET_REQUEST){
		 openfundgetrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&openfundgetrequest;
		}
		/** 领取全民福利应答 **/
		if((NetMsgId)msgId==UNIVERSAL_WELFARE_GET_ANSWER){
		 openfundgetanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&openfundgetanswer;
		}
		/** 月卡信息请求 **/
		if((NetMsgId)msgId==MONTH_CARD_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 月卡信息应答 **/
		if((NetMsgId)msgId==MONTH_CARD_INFO_ANSWER){
		 monthcardinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&monthcardinfoanswer;
		}
		/** 月卡奖励领取请求 **/
		if((NetMsgId)msgId==MONTH_CARD_GET_REQUEST){
		 monthcardgetrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&monthcardgetrequest;
		}
		/** 月卡奖励领取应答 **/
		if((NetMsgId)msgId==MONTH_CARD_GET_ANSWER){
		 monthcardgetanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&monthcardgetanswer;
		}
		/** 首充送礼领取请求 **/
		if((NetMsgId)msgId==FIRST_RECHARGE_AWARD_GET_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 首充送礼领取应答 **/
		if((NetMsgId)msgId==FIRST_RECHARGE_AWARD_GET_ANSWER){
		 firstrechargeawardgetanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&firstrechargeawardgetanswer;
		}
		/** 充值通知 **/
		if((NetMsgId)msgId==RECHARGE_NOTIFY){
		 rechargenotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&rechargenotify;
		}
		/** 元宝购买月卡请求 **/
		if((NetMsgId)msgId==BUY_MONTH_CARD_REQUEST){
		 buymonthcardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&buymonthcardrequest;
		}
		/** 元宝购买月卡应答 **/
		if((NetMsgId)msgId==BUY_MONTH_CARD_ANSWER){
		 buymonthcardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&buymonthcardanswer;
		}
		/** 帮派副本信息请求 **/
		if((NetMsgId)msgId==LEGION_BOSS_INFO_REQUEST){
		 legionbosscommonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosscommonrequest;
		}
		/** 帮派副本信息应答 **/
		if((NetMsgId)msgId==LEGION_BOSS_INFO_ANSWER){
		 legionbossinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbossinfoanswer;
		}
		/** 帮派副本开始请求 **/
		if((NetMsgId)msgId==LEGION_BOSS_FIGHT_REQUEST){
		 legionbosscommonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosscommonrequest;
		}
		/** 帮派副本开始应答 **/
		if((NetMsgId)msgId==LEGION_BOSS_FIGHT_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 帮派副本获取奖励请求 **/
		if((NetMsgId)msgId==LEGION_BOSS_GET_REWARD_REQUEST){
		 legionbosscommonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosscommonrequest;
		}
		/** 帮派副本获取奖励应答 **/
		if((NetMsgId)msgId==LEGION_BOSS_GET_REWARD_ANSWER){
		 legionbossgetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbossgetrewardanswer;
		}
		/** 帮派消灭排行请求 **/
		if((NetMsgId)msgId==LEGION_BOSS_FIRST_KILL_RANK_REQUEST){
		 legionbosscommonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosscommonrequest;
		}
		/** 帮派消灭排行应答 **/
		if((NetMsgId)msgId==LEGION_BOSS_FIRST_KILL_RANK_ANSWER){
		 legionbossfirstkillrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbossfirstkillrankanswer;
		}
		/** 帮派推本排行请求 **/
		if((NetMsgId)msgId==LEGION_BOSS_TOTAL_STAGE_RANK_REQUEST){
		 legionbosscommonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosscommonrequest;
		}
		/** 帮派推本排行应答 **/
		if((NetMsgId)msgId==LEGION_BOSS_TOTAL_STAGE_RANK_ANSWER){
		 legionbosstotalstagerankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosstotalstagerankanswer;
		}
		/** 帮内单次伤害排行请求 **/
		if((NetMsgId)msgId==LEGION_BOSS_LEGION_MAX_DAMAGE_RANK_REQUEST){
		 legionbosscommonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosscommonrequest;
		}
		/** 帮内单次伤害排行应答 **/
		if((NetMsgId)msgId==LEGION_BOSS_LEGION_MAX_DAMAGE_RANK_ANSWER){
		 legionbosslegionmaxdamagerankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosslegionmaxdamagerankanswer;
		}
		/** 全服单次伤害排行请求 **/
		if((NetMsgId)msgId==LEGION_BOSS_MAX_DAMAGE_RANK_REQUEST){
		 legionbosscommonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosscommonrequest;
		}
		/** 全服单次伤害排行应答 **/
		if((NetMsgId)msgId==LEGION_BOSS_MAX_DAMAGE_RANK_ANSWER){
		 legionbossmaxdamagerankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbossmaxdamagerankanswer;
		}
		/** 帮派BOSS击杀数排行请求 **/
		if((NetMsgId)msgId==LEGION_BOSS_KILL_COUNT_RANK_REQUEST){
		 legionbosscommonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosscommonrequest;
		}
		/** 帮派BOSS击杀数排行应答 **/
		if((NetMsgId)msgId==LEGION_BOSS_KILL_COUNT_RANK_ANSWER){
		 legionbosskillcountrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosskillcountrankanswer;
		}
		/** 帮派BOSS任务信息请求 **/
		if((NetMsgId)msgId==LEGION_BOSS_TASK_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 帮派BOSS任务信息应答 **/
		if((NetMsgId)msgId==LEGION_BOSS_TASK_INFO_ANSWER){
		 legionbosstaskinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosstaskinfoanswer;
		}
		/** 帮派BOSS任务奖励领取请求 **/
		if((NetMsgId)msgId==LEGION_BOSS_TASK_GET_REQUEST){
		 legionbosstaskgetrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbosstaskgetrequest;
		}
		/** 帮派BOSS任务奖励领取应答 **/
		if((NetMsgId)msgId==LEGION_BOSS_TASK_GET_ANSWER){
		 legionbossgetrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&legionbossgetrewardanswer;
		}
		/** 时装穿戴请求 **/
		if((NetMsgId)msgId==FASHION_DRESS_REQUEST){
		 fashiondressrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&fashiondressrequest;
		}
		/** 时装穿戴应答 **/
		if((NetMsgId)msgId==FASHION_DRESS_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 时装卸下请求 **/
		if((NetMsgId)msgId==FASHION_UNDRESS_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 时装卸下应答 **/
		if((NetMsgId)msgId==FASHION_UNDRESS_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 时装强化请求 **/
		if((NetMsgId)msgId==FASHION_STRENGTHEN_REQUEST){
		 fashionstrengthenrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&fashionstrengthenrequest;
		}
		/** 时装强化应答 **/
		if((NetMsgId)msgId==FASHION_STRENGTHEN_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 转盘信息通知 **/
		if((NetMsgId)msgId==TURNTABLE_NOTIFY){
		 turntablenotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&turntablenotify;
		}
		/** 转盘抽奖请求 **/
		if((NetMsgId)msgId==TURNTABLE_START_REQUEST){
		 turntablestartrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&turntablestartrequest;
		}
		/** 转盘抽奖应答 **/
		if((NetMsgId)msgId==TURNTABLE_START_ANSWER){
		 turntablestartanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&turntablestartanswer;
		}
		/** 转盘刷新请求 **/
		if((NetMsgId)msgId==TURNTABLE_REFRESH_REQUEST){
		 turntablerefreshrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&turntablerefreshrequest;
		}
		/** 转盘刷新应答 **/
		if((NetMsgId)msgId==TURNTABLE_REFRESH_ANSWER){
		 turntablerefreshanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&turntablerefreshanswer;
		}
		/** 转盘抽奖记录请求 **/
		if((NetMsgId)msgId==TURNTABLE_RECORD_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 转盘抽奖记录应答 **/
		if((NetMsgId)msgId==TURNTABLE_RECORD_ANSWER){
		 turntablerecordanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&turntablerecordanswer;
		}
		/** 转盘活动任务列表请求 **/
		if((NetMsgId)msgId==TURNTABLE_TASK_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 转盘活动任务列表应答 **/
		if((NetMsgId)msgId==TURNTABLE_TASK_LIST_ANSWER){
		 turntabletasklistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&turntabletasklistanswer;
		}
		/** 转盘活动领取任务奖励请求 **/
		if((NetMsgId)msgId==TURNTABLE_TASK_REWARD_REQUEST){
		 turntabletaskrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&turntabletaskrewardrequest;
		}
		/** 转盘活动领取任务奖励应答 **/
		if((NetMsgId)msgId==TURNTABLE_TASK_REWARD_ANSWER){
		 turntabletaskrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&turntabletaskrewardanswer;
		}
		/** 招财猫信息通知 **/
		if((NetMsgId)msgId==ZHAOCAIMAO_NOTIFY){
		 zhaocaimaonotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&zhaocaimaonotify;
		}
		/** 招财猫抽奖请求 **/
		if((NetMsgId)msgId==ZHAOCAIMAO_START_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 招财猫抽奖应答 **/
		if((NetMsgId)msgId==ZHAOCAIMAO_START_ANSWER){
		 zhaocaimaostartanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&zhaocaimaostartanswer;
		}
		/** 招财猫抽奖记录请求 **/
		if((NetMsgId)msgId==ZHAOCAIMAO_RECORD_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 招财猫抽奖记录应答 **/
		if((NetMsgId)msgId==ZHAOCAIMAO_RECORD_ANSWER){
		 zhaocaimaorecordanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&zhaocaimaorecordanswer;
		}
		/** 招财猫活动任务列表请求 **/
		if((NetMsgId)msgId==ZHAOCAIMAO_TASK_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 招财猫活动任务列表应答 **/
		if((NetMsgId)msgId==ZHAOCAIMAO_TASK_LIST_ANSWER){
		 zhaocaimaotasklistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&zhaocaimaotasklistanswer;
		}
		/** 招财猫活动领取任务奖励请求 **/
		if((NetMsgId)msgId==ZHAOCAIMAO_TASK_REWARD_REQUEST){
		 zhaocaimaotaskrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&zhaocaimaotaskrewardrequest;
		}
		/** 招财猫活动领取任务奖励应答 **/
		if((NetMsgId)msgId==ZHAOCAIMAO_TASK_REWARD_ANSWER){
		 zhaocaimaotaskrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&zhaocaimaotaskrewardanswer;
		}
		/** 打开界面 **/
		if((NetMsgId)msgId==OPEN_UI_REPORT){
		 openuireport.ParseFromArray(protoBuf,len);
		 *result=(char*)&openuireport;
		}
		/** 跨服积分赛信息请求 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_STATE_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 跨服积分赛信息应答 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_STATE_ANSWER){
		 cspointsracestateanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracestateanswer;
		}
		/** 跨服积分赛基础信息请求 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_GET_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 跨服积分赛基础信息应答 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_GET_INFO_ANSWER){
		 cspointsracegetinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracegetinfoanswer;
		}
		/** 跨服积分赛获取对手列表请求 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_GET_OPPONENTS_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 跨服积分赛获取对手列表应答 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_GET_OPPONENTS_ANSWER){
		 cspointsracegetopponentsanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracegetopponentsanswer;
		}
		/** 跨服积分赛挑战请求 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_FIGHT_REQUEST){
		 cspointsracefightrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracefightrequest;
		}
		/** 跨服积分赛挑战应答 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_FIGHT_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 跨服积分赛复仇请求 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_REVENGE_REQUEST){
		 cspointsracerevengerequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracerevengerequest;
		}
		/** 跨服积分赛复仇应答 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_REVENGE_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 跨服积分赛预挑战请求 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_PREPARE_FIGHT_REQUEST){
		 cspointsracepreparefightrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracepreparefightrequest;
		}
		/** 跨服积分赛预挑战应答 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_PREPARE_FIGHT_ANSWER){
		 cspointsracepreparefightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracepreparefightanswer;
		}
		/** 跨服积分赛排行榜请求 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 跨服积分赛排行榜应答 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_RANK_ANSWER){
		 cspointsracerankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracerankanswer;
		}
		/** 跨服积分赛防守记录请求 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_DEFEND_LOG_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 跨服积分赛防守记录应答 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_DEFEND_LOG_ANSWER){
		 cspointsracedefendloganswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracedefendloganswer;
		}
		/** 跨服积分赛刷新对手请求 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_REFRESH_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 跨服积分赛刷新对手应答 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_REFRESH_ANSWER){
		 cspointsracegetopponentsanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracegetopponentsanswer;
		}
		/** 跨服积分赛购买挑战次数请求 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_BUYCNT_REQUEST){
		 cspointsracefightbuyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&cspointsracefightbuyrequest;
		}
		/** 跨服积分赛购买挑战次数应答 **/
		if((NetMsgId)msgId==CS_POINTS_RACE_BUYCNT_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 分解豪侠请求 **/
		if((NetMsgId)msgId==FENJIE_GALLANT_REQUEST){
		 fenjiegallantrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&fenjiegallantrequest;
		}
		/** 分解豪侠应答 **/
		if((NetMsgId)msgId==FENJIE_GALLANT_ANSWER){
		 fenjiegallantanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fenjiegallantanswer;
		}
		/** 合成豪侠请求 **/
		if((NetMsgId)msgId==COMPOSE_GALLANT_REQUEST){
		 composegallantrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&composegallantrequest;
		}
		/** 合成豪侠应答 **/
		if((NetMsgId)msgId==COMPOSE_GALLANT_ANSWER){
		 fenjiegallantanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fenjiegallantanswer;
		}
		/** 豪侠传条目信息通知 **/
		if((NetMsgId)msgId==GALLANT_ENTRY_INFO_NOTIFY){
		 gallantentryinfonotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&gallantentryinfonotify;
		}
		/** 豪侠传条目激活请求 **/
		if((NetMsgId)msgId==GALLANT_ENTRY_ACTIVATE_REQUEST){
		 gallantentryactivaterequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&gallantentryactivaterequest;
		}
		/** 豪侠传条目激活应答 **/
		if((NetMsgId)msgId==GALLANT_ENTRY_ACTIVATE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 豪侠传排行榜请求 **/
		if((NetMsgId)msgId==GALLANT_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 豪侠传排行榜应答 **/
		if((NetMsgId)msgId==GALLANT_RANK_ANSWER){
		 gallantrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&gallantrankanswer;
		}
		/** 豪侠传试炼信息请求 **/
		if((NetMsgId)msgId==GALLANT_RAID_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 豪侠传试炼信息应答 **/
		if((NetMsgId)msgId==GALLANT_RAID_INFO_ANSWER){
		 gallantraidinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&gallantraidinfoanswer;
		}
		/** 豪侠传试炼刷新请求 **/
		if((NetMsgId)msgId==GALLANT_RAID_REFRESH_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 豪侠传试炼刷新应答 **/
		if((NetMsgId)msgId==GALLANT_RAID_REFRESH_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 豪侠传试炼挑战请求 **/
		if((NetMsgId)msgId==GALLANT_RAID_FIGHT_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 豪侠传试炼挑战应答 **/
		if((NetMsgId)msgId==GALLANT_RAID_FIGHT_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 限时购买通知 **/
		if((NetMsgId)msgId==LIMITED_TIME_BUY_NOTIFY){
		 limitedtimebuynotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&limitedtimebuynotify;
		}
		/** 限时购买请求 **/
		if((NetMsgId)msgId==LIMITED_TIME_BUY_REQUEST){
		 limitedtimebuyrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&limitedtimebuyrequest;
		}
		/** 限时购买应答 **/
		if((NetMsgId)msgId==LIMITED_TIME_BUY_ANSWER){
		 limitedtimebuyanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&limitedtimebuyanswer;
		}
		/** 返利信息通知 **/
		if((NetMsgId)msgId==REBATE_INFO_NOTIFY){
		 rebateinfonotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebateinfonotify;
		}
		/** 返利领取请求 **/
		if((NetMsgId)msgId==REBATE_RECEIVE_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 返利领取应答 **/
		if((NetMsgId)msgId==REBATE_RECEIVE_ANSWER){
		 rebatereceiveanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&rebatereceiveanswer;
		}
		/** 装备宠物请求 **/
		if((NetMsgId)msgId==PET_DRESS_REQUEST){
		 petdressrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&petdressrequest;
		}
		/** 装备宠物应答 **/
		if((NetMsgId)msgId==PET_DRESS_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 卸下宠物请求 **/
		if((NetMsgId)msgId==PET_UNDRESS_REQUEST){
		 petdressrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&petdressrequest;
		}
		/** 卸下宠物应答 **/
		if((NetMsgId)msgId==PET_UNDRESS_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 上阵宠物请求 **/
		if((NetMsgId)msgId==PET_IN_BATTLE_REQUEST){
		 petdressrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&petdressrequest;
		}
		/** 上阵宠物应答 **/
		if((NetMsgId)msgId==PET_IN_BATTLE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 下阵宠物请求 **/
		if((NetMsgId)msgId==PET_OUT_BATTLE_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 下阵宠物应答 **/
		if((NetMsgId)msgId==PET_OUT_BATTLE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 宠物升级请求 **/
		if((NetMsgId)msgId==PET_UPLEVEL_REQUEST){
		 petuplevelrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&petuplevelrequest;
		}
		/** 宠物升级应答 **/
		if((NetMsgId)msgId==PET_UPLEVEL_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 宠物升星请求 **/
		if((NetMsgId)msgId==PET_STAR_UPGRADE_REQUEST){
		 petstarupgraderequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&petstarupgraderequest;
		}
		/** 宠物升星应答 **/
		if((NetMsgId)msgId==PET_STAR_UPGRADE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 宠物神炼请求 **/
		if((NetMsgId)msgId==PET_REFINE_REQUEST){
		 petuplevelrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&petuplevelrequest;
		}
		/** 宠物神炼应答 **/
		if((NetMsgId)msgId==PET_REFINE_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 年兽活动通知 **/
		if((NetMsgId)msgId==NIAN_EVENT_NOTIFY){
		 nianeventnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&nianeventnotify;
		}
		/** 年兽信息请求 **/
		if((NetMsgId)msgId==NIAN_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 年兽信息应答 **/
		if((NetMsgId)msgId==NIAN_INFO_ANSWER){
		 nianinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&nianinfoanswer;
		}
		/** 购买礼花请求 **/
		if((NetMsgId)msgId==NIAN_BUY_FIREWORKS_REQUEST){
		 nianbuyfireworksrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&nianbuyfireworksrequest;
		}
		/** 购买礼花应答 **/
		if((NetMsgId)msgId==NIAN_BUY_FIREWORKS_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 使用礼花请求 **/
		if((NetMsgId)msgId==NIAN_USE_FIREWORKS_REQUEST){
		 nianbuyfireworksrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&nianbuyfireworksrequest;
		}
		/** 使用礼花应答 **/
		if((NetMsgId)msgId==NIAN_USE_FIREWORKS_ANSWER){
		 nianusefireworksanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&nianusefireworksanswer;
		}
		/** 获取红包请求 **/
		if((NetMsgId)msgId==NIAN_GET_RED_PACKET_REQUEST){
		 niangetredpacketrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&niangetredpacketrequest;
		}
		/** 获取红包应答 **/
		if((NetMsgId)msgId==NIAN_GET_RED_PACKET_ANSWER){
		 niangetredpacketanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&niangetredpacketanswer;
		}
		/** 年兽排行榜请求 **/
		if((NetMsgId)msgId==NIAN_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 年兽排行榜应答 **/
		if((NetMsgId)msgId==NIAN_RANK_ANSWER){
		 nianrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&nianrankanswer;
		}
		/** 年兽活动任务列表请求 **/
		if((NetMsgId)msgId==NIAN_TASK_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 年兽活动任务列表应答 **/
		if((NetMsgId)msgId==NIAN_TASK_LIST_ANSWER){
		 niantasklistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&niantasklistanswer;
		}
		/** 年兽活动领取任务奖励请求 **/
		if((NetMsgId)msgId==NIAN_TASK_REWARD_REQUEST){
		 niantaskrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&niantaskrewardrequest;
		}
		/** 年兽活动领取任务奖励应答 **/
		if((NetMsgId)msgId==NIAN_TASK_REWARD_ANSWER){
		 niantaskrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&niantaskrewardanswer;
		}
		/** 年兽活动排行榜前几名变化通知 **/
		if((NetMsgId)msgId==NIAN_TOP_RANK_CHANGED_NOTIFY){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 巅峰之路成就列表请求 **/
		if((NetMsgId)msgId==ACHIEVEMENT_TASK_LIST_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 巅峰之路成就列表应答 **/
		if((NetMsgId)msgId==ACHIEVEMENT_TASK_LIST_ANSWER){
		 achievementtasklistanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&achievementtasklistanswer;
		}
		/** 巅峰之路领取奖励请求 **/
		if((NetMsgId)msgId==ACHIEVEMENT_TASK_REWARD_REQUEST){
		 achievementtaskrewardrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&achievementtaskrewardrequest;
		}
		/** 巅峰之路领取奖励应答 **/
		if((NetMsgId)msgId==ACHIEVEMENT_TASK_REWARD_ANSWER){
		 achievementtaskrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&achievementtaskrewardanswer;
		}
		/** 巅峰之路一键领取奖励请求 **/
		if((NetMsgId)msgId==ACHIEVEMENT_ONE_KEY_REWARD_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 巅峰之路一键领取奖励应答 **/
		if((NetMsgId)msgId==ACHIEVEMENT_ONE_KEY_REWARD_ANSWER){
		 achievementonekeyrewardanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&achievementonekeyrewardanswer;
		}
		/** 巅峰之路新任务完成通知 **/
		if((NetMsgId)msgId==ACHIEVEMENT_NEW_TASK_COMPLETE_NOTIFY){
		 achievementnewtaskcompletenotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&achievementnewtaskcompletenotify;
		}
		/** 宠物副本信息请求 **/
		if((NetMsgId)msgId==PET_RAID_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 宠物副本信息应答 **/
		if((NetMsgId)msgId==PET_RAID_INFO_ANSWER){
		 petraidinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&petraidinfoanswer;
		}
		/** 宠物副本布阵请求 **/
		if((NetMsgId)msgId==PET_RAID_DEPLOY_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 宠物副本布阵应答 **/
		if((NetMsgId)msgId==PET_RAID_DEPLOY_ANSWER){
		 petraiddeployanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&petraiddeployanswer;
		}
		/** 宠物副本挑战请求 **/
		if((NetMsgId)msgId==PET_RAID_FIGHT_REQUEST){
		 petraidfightrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&petraidfightrequest;
		}
		/** 宠物副本挑战应答 **/
		if((NetMsgId)msgId==PET_RAID_FIGHT_ANSWER){
		 fightanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&fightanswer;
		}
		/** 宠物副本宝箱通知 **/
		if((NetMsgId)msgId==PET_RAID_BOX_NOTIFY){
		 petraidboxnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&petraidboxnotify;
		}
		/** 宠物副本重置请求 **/
		if((NetMsgId)msgId==PET_RAID_RESET_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 宠物副本重置应答 **/
		if((NetMsgId)msgId==PET_RAID_RESET_ANSWER){
		 commonanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonanswer;
		}
		/** 宠物副本一键通关请求 **/
		if((NetMsgId)msgId==PET_RAID_ONE_KEY_PASS_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 宠物副本一键通关应答 **/
		if((NetMsgId)msgId==PET_RAID_ONE_KEY_PASS_ANSWER){
		 petraidonekeypassanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&petraidonekeypassanswer;
		}
		/** 宠物副本通关数排行请求 **/
		if((NetMsgId)msgId==PET_RAID_PASS_COUNT_RANK_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 宠物副本通关数排行应答 **/
		if((NetMsgId)msgId==PET_RAID_PASS_COUNT_RANK_ANSWER){
		 petraidpasscountrankanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&petraidpasscountrankanswer;
		}
		/** 放河灯请求 **/
		if((NetMsgId)msgId==CS_RIVER_LANTERN_FLOAT_REQUEST){
		 csriverlanternfloatrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&csriverlanternfloatrequest;
		}
		/** 放河灯应答 **/
		if((NetMsgId)msgId==CS_RIVER_LANTERN_FLOAT_ANSWER){
		 csriverlanternfloatanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&csriverlanternfloatanswer;
		}
		/** 河灯活动信息请求 **/
		if((NetMsgId)msgId==CS_RIVER_LANTERN_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 河灯活动信息应答 **/
		if((NetMsgId)msgId==CS_RIVER_LANTERN_INFO_ANSWER){
		 csriverlanterninfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&csriverlanterninfoanswer;
		}
		/** 新河灯通知 **/
		if((NetMsgId)msgId==CS_RIVER_LANTERN_NEW_FLOAT_NOTIFY){
		 csriverlanternnewfloatnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&csriverlanternnewfloatnotify;
		}
		/** 新河灯排行榜通知 **/
		if((NetMsgId)msgId==CS_RIVER_LANTERN_NEW_RANK_NOTIFY){
		 csriverlanternnewranknotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&csriverlanternnewranknotify;
		}
		/** 河灯自己排名变化通知 **/
		if((NetMsgId)msgId==CS_RIVER_LANTERN_SELF_RANK_UPDATE_NOTIFY){
		 csriverlanternselfrankupdatenotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&csriverlanternselfrankupdatenotify;
		}
		/** 河灯他人获得物品通知 **/
		if((NetMsgId)msgId==CS_RIVER_LANTERN_OTHERS_GET_ITEM_NOTIFY){
		 csriverlanternothersgetitemnotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&csriverlanternothersgetitemnotify;
		}
		/** 团购信息请求 **/
		if((NetMsgId)msgId==CS_GROUPON_INFO_REQUEST){
		 commonrequest.ParseFromArray(protoBuf,len);
		 *result=(char*)&commonrequest;
		}
		/** 团购信息应答 **/
		if((NetMsgId)msgId==CS_GROUPON_INFO_ANSWER){
		 csgrouponinfoanswer.ParseFromArray(protoBuf,len);
		 *result=(char*)&csgrouponinfoanswer;
		}
		/** 团购更新剩余次数 **/
		if((NetMsgId)msgId==CS_GROUPON_COUNT_UPDATE_NOTIFY){
		 csgrouponcountupdatenotify.ParseFromArray(protoBuf,len);
		 *result=(char*)&csgrouponcountupdatenotify;
		}
}

bool ProtoPackTool::getByteFromProto(int msgId,::google::protobuf::MessageLite* proto,char** byteArray,int &byteArrayLen )
{
		static char* protoBufMem=new char[MAX_PROTOBUF_MEM_SIZE];
		//memset(protoBufMem,0,512);
		int protoHeaderSize=sizeof(ProtoHeader);
		if(proto->SerializeToArray(protoBufMem+protoHeaderSize,MAX_PROTOBUF_MEM_SIZE-protoHeaderSize)){
			int dataLen=proto->GetCachedSize();
			ProtoHeader* ph=(ProtoHeader*)protoBufMem;
			//字节序问题, 在ServerTool里面做过转换了
			ph->len=dataLen+protoHeaderSize;
			ph->msg_id=msgId;
			*byteArray=protoBufMem;
			byteArrayLen=ph->len;
			return true;
		}else{
			return false;
		}
}


