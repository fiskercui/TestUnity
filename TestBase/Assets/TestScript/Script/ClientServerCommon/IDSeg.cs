namespace ClientServerCommon
{
    using System;

    public class IDSeg
    {
        public const int InvalidId = 0;

        public static void Initialize()
        {
            _AssetType.Initialize();
            _SpecialId.Initialize();
        }

        public static int ToAssetType(int id)
        {
            return ((id >> 0x18) & 0xff);
        }

        public class _AssetType : TypeNameContainer<IDSeg>
        {
            public const int Accumulation = 0x20;
            public const int Action = 0x31;
            public const int Activity = 12;
            public const int AllPlayerGiftCounter = 0x55;
            public const int AppleGood = 6;
            public const int ArenaGood = 15;
            public const int ArenaGrade = 0x29;
            public const int Avatar = 3;
            public const int AvatarAssemble = 0x27;
            public const int AvatarAsset = 2;
            public const int Beast = 0x66;
            public const int BeastPart = 0x67;
            public const int BeastScroll = 0x68;
            public const int Buff = 0x33;
            public const int CombatTurn = 50;
            public const int Cycle = 0x25;
            public const int Dan = 0x57;
            public const int Dialogue = 0x12;
            public const int DinerBagId = 0x30;
            public const int Dungeon = 9;
            public const int Equipment = 4;
            public const int Exchange = 0x17;
            public const int FirstGet = 0x18;
            public const int Friend = 0x48;
            public const int FriendCampaign = 0x54;
            public const int Good = 8;
            public const int GoodStatus = 0x19;
            public const int Guide = 13;
            public const int GuildConstructionTask = 0x59;
            public const int GuildConstructionTaskCounter = 0x60;
            public const int GuildExchangeGoods = 0x65;
            public const int GuildPrivateGoods = 100;
            public const int GuildPublicGoods = 0x63;
            public const int GuildTask = 0x61;
            public const int GuildTaskCounter = 0x62;
            public const int Icon = 0x15;
            public const int Illusion = 0x56;
            public const int Item = 7;
            public const int LevelReward = 0x13;
            public const int MarvellousAdventure = 0x49;
            public const int Meridian = 0x22;
            public const int MeridianBuff = 0x21;
            public const int MonthCard = 0x47;
            public const int MysteryGood = 0x26;
            public const int Npc = 5;
            public const int Partner = 0x42;
            public const int PlotNpcId = 0x43;
            public const int Position = 0x41;
            public const int PveBuff = 0x10;
            public const int PveGroup = 11;
            public const int QinInfo = 70;
            public const int Quest = 0x16;
            public const int Question = 0x24;
            public const int RewardSet = 10;
            public const int Robot = 240;
            public const int Scene = 1;
            public const int SkillActivation = 40;
            public const int Special = 0xff;
            public const int StartServerReward = 0x23;
            public const int TaskId = 0x44;
            public const int Tavern = 14;
            public const int Tutorial = 20;
            public const int Unknown = 0;
            public const int VipLevel = 0x11;
            public const int WolfSmoke = 0x45;
            public const int Zentia = 0x58;

            public static bool Initialize()
            {
                bool flag = false;
                TypeNameContainer<IDSeg>.SetTextSectionName("Code_AssetType");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Scene", 1, "AssetType_Scene");
                flag &= TypeNameContainer<IDSeg>.RegisterType("AvatarAsset", 2, "AssetType_AvatarAsset");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Avatar", 3, "AssetType_Avatar");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Equipment", 4, "AssetType_Equipment");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Npc", 5, "AssetType_Npc");
                flag &= TypeNameContainer<IDSeg>.RegisterType("AppleGood", 6, "AssetType_AppleGood");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Item", 7, "AssetType_Item");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Good", 8, "AssetType_Good");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Dungeon", 9, "AssetType_Dungeon");
                flag &= TypeNameContainer<IDSeg>.RegisterType("RewardSet", 10, "AssetType_RewardSet");
                flag &= TypeNameContainer<IDSeg>.RegisterType("PveGroup", 11, "AssetType_PveGroup");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Activity", 12, "AssetType_Activity");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Guide", 13, "AssetType_Guide");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Tavern", 14, "AssetType_Tavern");
                flag &= TypeNameContainer<IDSeg>.RegisterType("ArenaGood", 15, "AssetType_ArenaGood");
                flag &= TypeNameContainer<IDSeg>.RegisterType("PveBuff", 0x10, "AssetType_PveBuff");
                flag &= TypeNameContainer<IDSeg>.RegisterType("VipLevel", 0x11, "AssetType_VipLevel");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Dialogue", 0x12, "AssetType_Dialogue");
                flag &= TypeNameContainer<IDSeg>.RegisterType("LevelReward", 0x13, "AssetType_LevelReward");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Tutorial", 20, "AssetType_Tutorial");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Icon", 0x15, "AssetType_Icon");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Quest", 0x16, "AssetType_Quest");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Exchange", 0x17, "AssetType_Exchange");
                flag &= TypeNameContainer<IDSeg>.RegisterType("FirstGet", 0x18, "AssetType_FirstGet");
                flag &= TypeNameContainer<IDSeg>.RegisterType("GoodStatus", 0x19, "AssetType_GoodStatus");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Accumulation", 0x20, "AssetType_Accumulation");
                flag &= TypeNameContainer<IDSeg>.RegisterType("MeridianBuff", 0x21, "AssetType_MeridianBuff");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Meridian", 0x22, "AssetType_Meridian");
                flag &= TypeNameContainer<IDSeg>.RegisterType("StartServerReward", 0x23, "AssetType_StartServerReward");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Question", 0x24, "AssetType_Question");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Cycle", 0x25, "AssetType_Cycle");
                flag &= TypeNameContainer<IDSeg>.RegisterType("MysteryGood", 0x26, "AssetType_MysteryGood");
                flag &= TypeNameContainer<IDSeg>.RegisterType("PlotNpcId", 0x43, "PlotNpcId");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Action", 0x31, "AssetType_Action");
                flag &= TypeNameContainer<IDSeg>.RegisterType("CombatTurn", 50, "AssetType_CombatTurn");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Buff", 0x33, "AssetType_Buff");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Position", 0x41, "Position");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Partner", 0x42, "Partner");
                flag &= TypeNameContainer<IDSeg>.RegisterType("TaskId", 0x44, "TaskId");
                flag &= TypeNameContainer<IDSeg>.RegisterType("WolfSmoke", 0x45, "WolfSmoke");
                flag &= TypeNameContainer<IDSeg>.RegisterType("QinInfo", 70, "QinInfo");
                flag &= TypeNameContainer<IDSeg>.RegisterType("MonthCard", 0x47, "MonthCard");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Friend", 0x48, "Friend");
                flag &= TypeNameContainer<IDSeg>.RegisterType("AllPlayerGiftCounter", 0x55, "AllPlayerGiftCounter");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Special", 0xff, "AssetType_Special");
                flag &= TypeNameContainer<IDSeg>.RegisterType("AvatarAssemble", 0x27, "AvatarAssemble");
                flag &= TypeNameContainer<IDSeg>.RegisterType("SkillActivation", 40, "SkillActivation");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Robot", 240, "Robot");
                flag &= TypeNameContainer<IDSeg>.RegisterType("MarvellousAdventure", 0x49, "MarvellousAdventure");
                flag &= TypeNameContainer<IDSeg>.RegisterType("FriendCampaign", 0x54, "FriendCampaign");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Illusion", 0x56, "Illusion");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Dan", 0x57, "AssetType_Dan");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Zentia", 0x58, "Zentia");
                flag &= TypeNameContainer<IDSeg>.RegisterType("GuildConstructionTask", 0x59, "GuildConstructionTask");
                flag &= TypeNameContainer<IDSeg>.RegisterType("GuildConstructionTaskCounter", 0x60, "GuildConstructionTaskCounter");
                flag &= TypeNameContainer<IDSeg>.RegisterType("GuildTask", 0x61, "GuildTask");
                flag &= TypeNameContainer<IDSeg>.RegisterType("GuildTaskCounter", 0x62, "GuildTaskCounter");
                flag &= TypeNameContainer<IDSeg>.RegisterType("GuildPublicGoods", 0x63, "GuildPublicGoods");
                flag &= TypeNameContainer<IDSeg>.RegisterType("GuildPrivateGoods", 100, "GuildPrivateGoods");
                flag &= TypeNameContainer<IDSeg>.RegisterType("GuildExchangeGoods", 0x65, "GuildExchangeGoods");
                flag &= TypeNameContainer<IDSeg>.RegisterType("Beast", 0x66, "Beast");
                flag &= TypeNameContainer<IDSeg>.RegisterType("BeastPart", 0x67, "BeastPart");
                return (flag & TypeNameContainer<IDSeg>.RegisterType("BeastScroll", 0x68, "BeastScroll"));
            }
        }

        public class _SpecialId : TypeNameContainer<IDSeg._SpecialId>
        {
            public const int ArenaChallengeTimes = -16777208;
            public const int ArenaHonorPoint = -16777209;
            public const int Badge = -16777207;
            public const int Energy = -16777196;
            public const int EnergyBuyCount = -16777194;
            public const int Experience = -16777213;
            public const int GameMoney = -16777215;
            public const int GuildBossCount = -16777190;
            public const int GuildMoney = -16777192;
            public const int GuildMoveCount = -16777191;
            public const int Iron = -16777202;
            public const int Medals = -16777199;
            public const int QinInfoAnswerCount = -16777197;
            public const int RealMoney = -16777214;
            public const int Soul = -16777206;
            public const int Spirit = -16777203;
            public const int Stamina = -16777212;
            public const int StaminaBuyCount = -16777198;
            public const int ThreeToken = -16777204;
            public const int TrialStamp = -16777200;
            public const int UseItemCount_AddStamina = -16777211;
            public const int VipLevel = -16777205;
            public const int WineSoul = -16777195;
            public const int WorldChatTimes = -16777210;
            public const int Zentia = -16777193;

            public static bool Initialize()
            {
                bool flag = false;
                TypeNameContainer<IDSeg._SpecialId>.SetTextSectionName("SpecialAsset");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("GameMoney", -16777215, "GameMoney");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("RealMoney", -16777214, "RealMoney");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("Experience", -16777213, "Experience");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("Stamina", -16777212, "Stamina");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("UseItemCount_AddStamina", -16777211, "UseItemCount_AddStamina");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("WorldChatTimes", -16777210, "WorldChatTimes");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("ArenaHonorPoint", -16777209, "ArenaHonorPoint");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("ArenaChallengeTimes", -16777208, "ArenaChallengeTimes");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("Badge", -16777207, "Badge");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("Soul", -16777206, "Soul");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("VipLevel", -16777205, "VipLevel");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("ThreeToken", -16777204, "ThreeToken");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("Spirit", -16777203, "Spirit");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("Iron", -16777202, "Iron");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("TrialStamp", -16777200, "TrialStamp");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("Medals", -16777199, "Medals");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("StaminaBuyCount", -16777198, "StaminaBuyCount");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("QinInfoAnswerCount", -16777197, "QinInfoAnswerCount");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("Energy", -16777196, "Energy");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("WineSoul", -16777195, "WineSoul");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("EnergyBuyCount", -16777194, "EnergyBuyCount");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("Zentia", -16777193, "Zentia");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("GuildMoney", -16777192, "GuildMoney");
                flag &= TypeNameContainer<IDSeg._SpecialId>.RegisterType("GuildMoveCount", -16777191, "GuildMoveCount");
                return (flag & TypeNameContainer<IDSeg._SpecialId>.RegisterType("GuildBossCount", -16777190, "GuildBossCount"));
            }
        }
    }
}

