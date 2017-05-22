namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class Player
    {
        private List<int> appleGoodIds = new List<int>();
        private WeihuaGames.ClientClass.ArenaData arenaData;
        private List<WeihuaGames.ClientClass.Avatar> avatars = new List<WeihuaGames.ClientClass.Avatar>();
        private int badge;
        private float battleSpeed = 1f;
        private List<WeihuaGames.ClientClass.Beast> beasts = new List<WeihuaGames.ClientClass.Beast>();
        private WeihuaGames.ClientClass.CampaignData campaignData = new WeihuaGames.ClientClass.CampaignData();
        private int cancelEvaluateLevel;
        private int canPickDailyQuestCount;
        private int canPickGoalQuestCount;
        private List<int> cardIds = new List<int>();
        private WeihuaGames.ClientClass.ChatData chatData = new WeihuaGames.ClientClass.ChatData();
        private ClientDynamicValueData clientDynamicValue = new ClientDynamicValueData();
        private List<WeihuaGames.ClientClass.Consumable> consumables;
        private DynamicInt currentChatCount = new DynamicInt();
        private int currentPickedLevel;
        private List<WeihuaGames.ClientClass.Dan> dans = new List<WeihuaGames.ClientClass.Dan>();
        private bool didCharge;
        private float directionX;
        private float directionZ;
        private float dungeonBattleCameraAngle;
        private WeihuaGames.ClientClass.EmailData emailData = new WeihuaGames.ClientClass.EmailData();
        private PointTimer energy = new PointTimer();
        private int energyBuyCount;
        private long energyBuyCountLastResetTime;
        private List<WeihuaGames.ClientClass.Equipment> equipments = new List<WeihuaGames.ClientClass.Equipment>();
        private List<WeihuaGames.ClientClass.PlayerRecord> friends;
        private WeihuaGames.ClientClass.Function function;
        private List<State> functionStates = new List<State>();
        private DynamicInt gameMoney = new DynamicInt();
        private int guildBossCount;
        private WeihuaGames.ClientClass.GuildGameData guildGameData = new WeihuaGames.ClientClass.GuildGameData();
        private int guildMoney;
        private bool hasEvaluate;
        private WeihuaGames.ClientClass.HireDinerData hireDinerData = new WeihuaGames.ClientClass.HireDinerData();
        private com.kodgames.corgi.protocol.IllusionData illusionData;
        private int iron;
        private long lastChatResetTime;
        private WeihuaGames.ClientClass.LevelAttrib levelAttrib = new WeihuaGames.ClientClass.LevelAttrib();
        private long loginTime;
        private int medals;
        private WeihuaGames.ClientClass.MelaleucaFloorData melaleucaFloorData = new WeihuaGames.ClientClass.MelaleucaFloorData();
        private WeihuaGames.ClientClass.MsgFlowData msgFlowData;
        private Dictionary<int, WeihuaGames.ClientClass.MysteryShopInfo> mysteryShopInfos = new Dictionary<int, WeihuaGames.ClientClass.MysteryShopInfo>();
        private string name;
        private int newCombatEmailCount;
        private int newFriendEmailCount;
        private int newGuildEmailCount;
        private int newSystemEmailCount;
        private WeihuaGames.ClientClass.NoticeData noticeData = new WeihuaGames.ClientClass.NoticeData();
        private string platformId;
        private int playerId;
        private WeihuaGames.ClientClass.PlayerLevelUpData playerLevelUpData;
        private WeihuaGames.ClientClass.PositionData positionData = new WeihuaGames.ClientClass.PositionData();
        private int power;
        private PointTimer qinInfoAnswerCount = new PointTimer();
        private WeihuaGames.ClientClass.QuestData questData = new WeihuaGames.ClientClass.QuestData();
        private WeihuaGames.ClientClass.RankData rankData = new WeihuaGames.ClientClass.RankData();
        private DynamicInt realMoney = new DynamicInt();
        private DynamicInt remainingCostRMB = new DynamicInt();
        private WeihuaGames.ClientClass.ShopData shopData = new WeihuaGames.ClientClass.ShopData();
        private WeihuaGames.ClientClass.SignData signData;
        private List<WeihuaGames.ClientClass.Skill> skills = new List<WeihuaGames.ClientClass.Skill>();
        private int soul;
        private int spirit;
        private PointTimer stamina = new PointTimer();
        private int staminaBuyCount;
        private long staminaBuyCountLastResetTime;
        private WeihuaGames.ClientClass.StartServerRewardInfo startServerRewardInfo;
        private WeihuaGames.ClientClass.TaskData taskData = new WeihuaGames.ClientClass.TaskData();
        private int threeToken;
        private int timeZone;
        private DynamicInt totalCostRMB = new DynamicInt();
        private int trialStamp;
        private List<int> unDoneTutorials = new List<int>();
        private DynamicInt vipLevel = new DynamicInt();
        private int wineSoul;
        private int zentia;

        public void AddAvatar(WeihuaGames.ClientClass.Avatar avatar)
        {
            this.avatars.Add(avatar);
        }

        public void AddBeast(WeihuaGames.ClientClass.Beast beast)
        {
            this.beasts.Add(beast);
        }

        public WeihuaGames.ClientClass.Consumable AddConsumable(int id, int count)
        {
            WeihuaGames.ClientClass.Consumable item = this.SearchConsumable(id);
            if (item == null)
            {
                item = new WeihuaGames.ClientClass.Consumable {
                    Id = id,
                    Amount = 0
                };
                this.consumables.Add(item);
            }
            item.Amount += count;
            return item;
        }

        public void AddDan(WeihuaGames.ClientClass.Dan dan)
        {
            this.dans.Add(dan);
        }

        public void AddEquipment(WeihuaGames.ClientClass.Equipment equipment)
        {
            this.equipments.Add(equipment);
        }

        public void AddFriend(WeihuaGames.ClientClass.PlayerRecord newFriend)
        {
            if (this.friends != null)
            {
                this.friends.Add(newFriend);
            }
        }

        public void AddMysteryShopInfo(WeihuaGames.ClientClass.MysteryShopInfo shop)
        {
            if (shop != null)
            {
                if (this.mysteryShopInfos.ContainsKey(shop.ShopType))
                {
                    this.mysteryShopInfos[shop.ShopType] = shop;
                }
                else
                {
                    this.mysteryShopInfos.Add(shop.ShopType, shop);
                }
            }
        }

        public void AddSkill(WeihuaGames.ClientClass.Skill skill)
        {
            this.skills.Add(skill);
        }

        public WeihuaGames.ClientClass.Player FromProtobuf(com.kodgames.corgi.protocol.Player player)
        {
            this.levelAttrib = new WeihuaGames.ClientClass.LevelAttrib();
            this.skills = new List<WeihuaGames.ClientClass.Skill>();
            this.equipments = new List<WeihuaGames.ClientClass.Equipment>();
            this.consumables = new List<WeihuaGames.ClientClass.Consumable>();
            this.avatars = new List<WeihuaGames.ClientClass.Avatar>();
            this.SignData = new WeihuaGames.ClientClass.SignData();
            this.playerId = player.playerId;
            this.name = player.name;
            this.gameMoney = player.gameMoney;
            this.realMoney = player.realMoney;
            this.iron = player.iron;
            this.spirit = player.spirit;
            this.medals = player.medals;
            this.wineSoul = player.wineSoul;
            this.zentia = player.zentia;
            this.guildMoney = player.guildMoney;
            this.guildBossCount = player.guildBossCount;
            this.power = player.power;
            this.stamina.Point = new TimerIncreaseValue(player.stamina, player.staminaLastCalculateTime);
            this.lastChatResetTime = player.lastResetChatTime;
            this.currentChatCount = player.currentChatCount;
            this.chatData.UnreadPrivateChatMsgCount = player.unreadPrivateMsgCount;
            this.chatData.UnreadGuildChatCount = player.guildUnreadChatCount;
            this.timeZone = player.timeZone;
            this.newCombatEmailCount = player.newCombatEmailCount;
            this.newFriendEmailCount = player.newFriendEmailCount;
            this.newSystemEmailCount = player.newSystemEmailCount;
            this.newGuildEmailCount = player.newGuildEmailCount;
            this.energy.Point = new TimerIncreaseValue(player.energy, player.energyLastCalculateTime);
            this.energyBuyCount = player.energyBuyCount;
            this.energyBuyCountLastResetTime = player.energyBuyCountLastResetTime;
            this.vipLevel = player.vipLevel;
            this.totalCostRMB = player.totalCostRMB;
            this.remainingCostRMB = player.remainningCostRMB;
            this.badge = player.badge;
            this.loginTime = player.loginTime;
            if (player.levelAttrib != null)
            {
                this.levelAttrib.FromProtobuf(player.levelAttrib);
            }
            this.soul = player.soul;
            this.currentPickedLevel = player.curentPickedLevel;
            if (player.signData != null)
            {
                this.SignData.FromProtobuf(player.signData);
            }
            foreach (com.kodgames.corgi.protocol.Avatar avatar in player.avatars)
            {
                WeihuaGames.ClientClass.Avatar item = new WeihuaGames.ClientClass.Avatar();
                item.FromProtobuf(avatar);
                this.avatars.Add(item);
            }
            foreach (com.kodgames.corgi.protocol.Equipment equipment in player.equipments)
            {
                WeihuaGames.ClientClass.Equipment equipment2 = new WeihuaGames.ClientClass.Equipment();
                equipment2.FromProtobuf(equipment);
                this.equipments.Add(equipment2);
            }
            foreach (com.kodgames.corgi.protocol.Consumable consumable in player.consumables)
            {
                WeihuaGames.ClientClass.Consumable consumable2 = new WeihuaGames.ClientClass.Consumable();
                consumable2.FromProtobuf(consumable);
                this.consumables.Add(consumable2);
            }
            foreach (com.kodgames.corgi.protocol.Skill skill in player.skills)
            {
                WeihuaGames.ClientClass.Skill skill2 = new WeihuaGames.ClientClass.Skill();
                skill2.FromProtobuf(skill);
                this.skills.Add(skill2);
            }
            this.didCharge = player.didCharge;
            if (player.unDoneTutorialIds != null)
            {
                this.unDoneTutorials = player.unDoneTutorialIds;
            }
            this.staminaBuyCount = player.staminaBuyCount;
            this.staminaBuyCountLastResetTime = player.staminaBuyCountLastResetTime;
            this.trialStamp = player.trialStamp;
            this.threeToken = player.threeToken;
            if (player.questQuick != null)
            {
                this.questData.QuestQuick = new WeihuaGames.ClientClass.QuestQuick().FromProtoBuffer(player.questQuick);
            }
            if (player.startServerRewardInfo != null)
            {
                this.startServerRewardInfo = new WeihuaGames.ClientClass.StartServerRewardInfo().FromProtoBuf(player.startServerRewardInfo);
            }
            this.hasEvaluate = player.hasEvaluate;
            this.cancelEvaluateLevel = player.cancelEvaluateLevel;
            if (player.hireDinerData != null)
            {
                this.hireDinerData.FromProtoBuf(player.hireDinerData);
            }
            this.qinInfoAnswerCount.Point = new TimerIncreaseValue(player.qinInfoAnswerCount, player.qinInfoAnswerCountRecoverTime);
            this.positionData.FromProtobuf(player.positionData);
            foreach (int num in player.appleGoodIds)
            {
                this.appleGoodIds.Add(num);
            }
            this.illusionData = new com.kodgames.corgi.protocol.IllusionData();
            if (player.illusionData != null)
            {
                this.illusionData = player.illusionData;
            }
            foreach (com.kodgames.corgi.protocol.Dan dan in player.dans)
            {
                WeihuaGames.ClientClass.Dan dan2 = new WeihuaGames.ClientClass.Dan();
                dan2.FromProtobuf(dan);
                this.dans.Add(dan2);
            }
            foreach (com.kodgames.corgi.protocol.Beast beast in player.beasts)
            {
                WeihuaGames.ClientClass.Beast beast2 = new WeihuaGames.ClientClass.Beast();
                beast2.FromProtobuf(beast);
                this.beasts.Add(beast2);
            }
            return this;
        }

        public WeihuaGames.ClientClass.PlayerRecord GetFriendInfoById(int friendId)
        {
            for (int i = 0; i < this.friends.Count; i++)
            {
                if (this.friends[i].PlayerId == friendId)
                {
                    return this.friends[i];
                }
            }
            return null;
        }

        public WeihuaGames.ClientClass.MysteryShopInfo GetMysteryShopByType(int type)
        {
            if (this.mysteryShopInfos.ContainsKey(type))
            {
                return this.mysteryShopInfos[type];
            }
            return null;
        }

        public void RemoveAvatar(string guid)
        {
            WeihuaGames.ClientClass.Avatar item = this.SearchAvatar(guid);
            if (item != null)
            {
                this.avatars.Remove(item);
            }
        }

        public void RemoveBeast(string guid)
        {
            WeihuaGames.ClientClass.Beast item = this.SearchBeast(guid);
            if (item != null)
            {
                this.beasts.Remove(item);
            }
        }

        public WeihuaGames.ClientClass.Consumable RemoveConsumable(int id, int count)
        {
            WeihuaGames.ClientClass.Consumable item = this.SearchConsumable(id);
            if (item == null)
            {
                return null;
            }
            item.Amount -= count;
            if (item.Amount <= 0)
            {
                this.consumables.Remove(item);
            }
            return item;
        }

        public void RemoveDan(string guid)
        {
            WeihuaGames.ClientClass.Dan item = this.SearchDan(guid);
            if (item != null)
            {
                this.dans.Remove(item);
            }
        }

        public void RemoveEquipment(string guid)
        {
            WeihuaGames.ClientClass.Equipment item = this.SearchEquipment(guid);
            if (item != null)
            {
                this.equipments.Remove(item);
            }
        }

        public void RemoveFriend(int playerId)
        {
            WeihuaGames.ClientClass.PlayerRecord item = this.SearchFriendByPlayerId(playerId);
            if (item != null)
            {
                this.friends.Remove(item);
            }
        }

        public void RemoveSkill(string guid)
        {
            WeihuaGames.ClientClass.Skill item = this.SearchSkill(guid);
            if (item != null)
            {
                this.skills.Remove(item);
            }
        }

        public WeihuaGames.ClientClass.Avatar SearchAvatar(string guid)
        {
            foreach (WeihuaGames.ClientClass.Avatar avatar in this.avatars)
            {
                if (avatar.Guid.Equals(guid))
                {
                    return avatar;
                }
            }
            return null;
        }

        public WeihuaGames.ClientClass.Beast SearchBeast(string guid)
        {
            foreach (WeihuaGames.ClientClass.Beast beast in this.beasts)
            {
                if (beast.Guid.Equals(guid))
                {
                    return beast;
                }
            }
            return null;
        }

        public WeihuaGames.ClientClass.Consumable SearchConsumable(int id)
        {
            foreach (WeihuaGames.ClientClass.Consumable consumable in this.consumables)
            {
                if (consumable.Id == id)
                {
                    return consumable;
                }
            }
            return null;
        }

        public int SearchConsumableIndex(int id)
        {
            for (int i = 0; i < this.consumables.Count; i++)
            {
                if (this.consumables[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public WeihuaGames.ClientClass.Dan SearchDan(string guid)
        {
            foreach (WeihuaGames.ClientClass.Dan dan in this.dans)
            {
                if (dan.Guid.Equals(guid))
                {
                    return dan;
                }
            }
            return null;
        }

        public WeihuaGames.ClientClass.Equipment SearchEquipment(string guid)
        {
            foreach (WeihuaGames.ClientClass.Equipment equipment in this.equipments)
            {
                if (equipment.Guid.Equals(guid))
                {
                    return equipment;
                }
            }
            return null;
        }

        public WeihuaGames.ClientClass.PlayerRecord SearchFriendByPlayerId(int playerId)
        {
            if (this.friends != null)
            {
                foreach (WeihuaGames.ClientClass.PlayerRecord record in this.friends)
                {
                    if (record.PlayerId == playerId)
                    {
                        return record;
                    }
                }
            }
            return null;
        }

        public WeihuaGames.ClientClass.Skill SearchSkill(string guid)
        {
            foreach (WeihuaGames.ClientClass.Skill skill in this.skills)
            {
                if (skill.Guid.Equals(guid))
                {
                    return skill;
                }
            }
            return null;
        }

        public List<int> AppleGoodIds
        {
            get
            {
                return this.appleGoodIds;
            }
            set
            {
                this.appleGoodIds = value;
            }
        }

        public WeihuaGames.ClientClass.ArenaData ArenaData
        {
            get
            {
                return this.arenaData;
            }
            set
            {
                this.arenaData = value;
            }
        }

        public List<WeihuaGames.ClientClass.Avatar> Avatars
        {
            get
            {
                return this.avatars;
            }
            set
            {
                this.avatars = value;
            }
        }

        public int Badge
        {
            get
            {
                return this.badge;
            }
            set
            {
                this.badge = value;
            }
        }

        public float BattleSpeed
        {
            get
            {
                return this.battleSpeed;
            }
            set
            {
                this.battleSpeed = value;
            }
        }

        public List<WeihuaGames.ClientClass.Beast> Beasts
        {
            get
            {
                return this.beasts;
            }
            set
            {
                this.beasts = value;
            }
        }

        public WeihuaGames.ClientClass.CampaignData CampaignData
        {
            get
            {
                return this.campaignData;
            }
        }

        public int CancelEvaluateLevel
        {
            get
            {
                return this.cancelEvaluateLevel;
            }
            set
            {
                this.cancelEvaluateLevel = value;
            }
        }

        public int CanPickDailyQuestCount
        {
            get
            {
                return this.canPickDailyQuestCount;
            }
            set
            {
                this.canPickDailyQuestCount = value;
            }
        }

        public int CanPickGoalQuestCount
        {
            get
            {
                return this.canPickGoalQuestCount;
            }
            set
            {
                this.canPickGoalQuestCount = value;
            }
        }

        public List<int> CardIds
        {
            get
            {
                return this.cardIds;
            }
        }

        public WeihuaGames.ClientClass.ChatData ChatData
        {
            get
            {
                return this.chatData;
            }
        }

        public ClientDynamicValueData ClientDynamicValue
        {
            get
            {
                return this.clientDynamicValue;
            }
        }

        public List<WeihuaGames.ClientClass.Consumable> Consumables
        {
            get
            {
                return this.consumables;
            }
            set
            {
                this.consumables = value;
            }
        }

        public int CurrentChatCount
        {
            get
            {
                return (int) this.currentChatCount;
            }
            set
            {
                this.currentChatCount = value;
            }
        }

        public int CurrentPickedLevel
        {
            get
            {
                return this.currentPickedLevel;
            }
            set
            {
                this.currentPickedLevel = value;
            }
        }

        public List<WeihuaGames.ClientClass.Dan> Dans
        {
            get
            {
                return this.dans;
            }
            set
            {
                this.dans = value;
            }
        }

        public bool DidCharge
        {
            get
            {
                return this.didCharge;
            }
            set
            {
                this.didCharge = value;
            }
        }

        public float DirectionX
        {
            get
            {
                return this.directionX;
            }
            set
            {
                this.directionX = value;
            }
        }

        public float DirectionZ
        {
            get
            {
                return this.directionZ;
            }
            set
            {
                this.directionZ = value;
            }
        }

        public float DungeonBattleCameraAngle
        {
            get
            {
                return this.dungeonBattleCameraAngle;
            }
            set
            {
                this.dungeonBattleCameraAngle = value;
            }
        }

        public WeihuaGames.ClientClass.EmailData EmailData
        {
            get
            {
                return this.emailData;
            }
        }

        public PointTimer Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                this.energy = value;
            }
        }

        public int EnergyBuyCount
        {
            get
            {
                return this.energyBuyCount;
            }
            set
            {
                this.energyBuyCount = value;
            }
        }

        public long EnergyBuyCountLastResetTime
        {
            get
            {
                return this.energyBuyCountLastResetTime;
            }
            set
            {
                this.energyBuyCountLastResetTime = value;
            }
        }

        public List<WeihuaGames.ClientClass.Equipment> Equipments
        {
            get
            {
                return this.equipments;
            }
            set
            {
                this.equipments = value;
            }
        }

        public List<WeihuaGames.ClientClass.PlayerRecord> Friends
        {
            get
            {
                return this.friends;
            }
            set
            {
                this.friends = value;
            }
        }

        public WeihuaGames.ClientClass.Function Function
        {
            get
            {
                return this.function;
            }
            set
            {
                this.function = value;
            }
        }

        public List<State> FunctionStates
        {
            get
            {
                return this.functionStates;
            }
            set
            {
                this.functionStates = value;
            }
        }

        public int GameMoney
        {
            get
            {
                return (int) this.gameMoney;
            }
            set
            {
                this.gameMoney = value;
            }
        }

        public int GuildBossCount
        {
            get
            {
                return this.guildBossCount;
            }
            set
            {
                this.guildBossCount = value;
            }
        }

        public WeihuaGames.ClientClass.GuildGameData GuildGameData
        {
            get
            {
                return this.guildGameData;
            }
        }

        public int GuildMoney
        {
            get
            {
                return this.guildMoney;
            }
            set
            {
                this.guildMoney = value;
            }
        }

        public bool HasEvaluate
        {
            get
            {
                return this.hasEvaluate;
            }
            set
            {
                this.hasEvaluate = value;
            }
        }

        public WeihuaGames.ClientClass.HireDinerData HireDinerData
        {
            get
            {
                return this.hireDinerData;
            }
            set
            {
                this.hireDinerData = value;
            }
        }

        public com.kodgames.corgi.protocol.IllusionData IllusionData
        {
            get
            {
                return this.illusionData;
            }
            set
            {
                this.illusionData = value;
            }
        }

        public int Iron
        {
            get
            {
                return this.iron;
            }
            set
            {
                this.iron = value;
            }
        }

        public long LastChatResetTime
        {
            get
            {
                return this.lastChatResetTime;
            }
            set
            {
                this.lastChatResetTime = value;
            }
        }

        public WeihuaGames.ClientClass.LevelAttrib LevelAttrib
        {
            get
            {
                return this.levelAttrib;
            }
            set
            {
                this.levelAttrib = value;
            }
        }

        public long LoginTime
        {
            get
            {
                return this.loginTime;
            }
            set
            {
                this.loginTime = value;
            }
        }

        public int Medals
        {
            get
            {
                return this.medals;
            }
            set
            {
                this.medals = value;
            }
        }

        public WeihuaGames.ClientClass.MelaleucaFloorData MelaleucaFloorData
        {
            get
            {
                return this.melaleucaFloorData;
            }
            set
            {
                this.melaleucaFloorData = value;
            }
        }

        public WeihuaGames.ClientClass.MsgFlowData MsgFlowData
        {
            get
            {
                if (this.msgFlowData == null)
                {
                    this.msgFlowData = new WeihuaGames.ClientClass.MsgFlowData();
                }
                return this.msgFlowData;
            }
            set
            {
                this.msgFlowData = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int NewCombatEmailCount
        {
            get
            {
                return this.newCombatEmailCount;
            }
            set
            {
                this.newCombatEmailCount = value;
            }
        }

        public int NewFriendEmailCount
        {
            get
            {
                return this.newFriendEmailCount;
            }
            set
            {
                this.newFriendEmailCount = value;
            }
        }

        public int NewGuildEmailCount
        {
            get
            {
                return this.newGuildEmailCount;
            }
            set
            {
                this.newGuildEmailCount = value;
            }
        }

        public int NewSystemEmailCount
        {
            get
            {
                return this.newSystemEmailCount;
            }
            set
            {
                this.newSystemEmailCount = value;
            }
        }

        public WeihuaGames.ClientClass.NoticeData NoticeData
        {
            get
            {
                return this.noticeData;
            }
        }

        public string PlatformId
        {
            get
            {
                return this.platformId;
            }
            set
            {
                this.platformId = value;
            }
        }

        public int PlayerId
        {
            get
            {
                return this.playerId;
            }
            set
            {
                this.playerId = value;
            }
        }

        public WeihuaGames.ClientClass.PlayerLevelUpData PlayerLevelUpData
        {
            get
            {
                return this.playerLevelUpData;
            }
            set
            {
                this.playerLevelUpData = value;
            }
        }

        public WeihuaGames.ClientClass.PositionData PositionData
        {
            get
            {
                return this.positionData;
            }
            set
            {
                this.positionData = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            set
            {
                this.power = value;
            }
        }

        public PointTimer QinInfoAnswerCount
        {
            get
            {
                return this.qinInfoAnswerCount;
            }
            set
            {
                this.qinInfoAnswerCount = value;
            }
        }

        public WeihuaGames.ClientClass.QuestData QuestData
        {
            get
            {
                return this.questData;
            }
            set
            {
                this.questData = value;
            }
        }

        public WeihuaGames.ClientClass.RankData RankData
        {
            get
            {
                return this.rankData;
            }
        }

        public int RealMoney
        {
            get
            {
                return (int) this.realMoney;
            }
            set
            {
                this.realMoney = value;
            }
        }

        public int RemainingCostRMB
        {
            get
            {
                return (int) this.remainingCostRMB;
            }
            set
            {
                this.remainingCostRMB = value;
            }
        }

        public WeihuaGames.ClientClass.ShopData ShopData
        {
            get
            {
                return this.shopData;
            }
        }

        public WeihuaGames.ClientClass.SignData SignData
        {
            get
            {
                return this.signData;
            }
            set
            {
                this.signData = value;
            }
        }

        public List<WeihuaGames.ClientClass.Skill> Skills
        {
            get
            {
                return this.skills;
            }
            set
            {
                this.skills = value;
            }
        }

        public int Soul
        {
            get
            {
                return this.soul;
            }
            set
            {
                this.soul = value;
            }
        }

        public int Spirit
        {
            get
            {
                return this.spirit;
            }
            set
            {
                this.spirit = value;
            }
        }

        public PointTimer Stamina
        {
            get
            {
                return this.stamina;
            }
            set
            {
                this.stamina = value;
            }
        }

        public int StaminaBuyCount
        {
            get
            {
                return this.staminaBuyCount;
            }
            set
            {
                this.staminaBuyCount = value;
            }
        }

        public long StaminaBuyCountLastResetTime
        {
            get
            {
                return this.staminaBuyCountLastResetTime;
            }
            set
            {
                this.staminaBuyCountLastResetTime = value;
            }
        }

        public WeihuaGames.ClientClass.StartServerRewardInfo StartServerRewardInfo
        {
            get
            {
                return this.startServerRewardInfo;
            }
            set
            {
                this.startServerRewardInfo = value;
            }
        }

        public WeihuaGames.ClientClass.TaskData TaskData
        {
            get
            {
                return this.taskData;
            }
        }

        public int ThreeToken
        {
            get
            {
                return this.threeToken;
            }
            set
            {
                this.threeToken = value;
            }
        }

        public int TimeZone
        {
            get
            {
                return this.timeZone;
            }
            set
            {
                this.timeZone = value;
            }
        }

        public int TotalCostRMB
        {
            get
            {
                return (int) this.totalCostRMB;
            }
            set
            {
                this.totalCostRMB = value;
            }
        }

        public int TotalNewEmailCount
        {
            get
            {
                return ((this.newCombatEmailCount + this.newFriendEmailCount) + this.newSystemEmailCount);
            }
        }

        public int TrialStamp
        {
            get
            {
                return this.trialStamp;
            }
            set
            {
                this.trialStamp = value;
            }
        }

        public List<int> UnDoneTutorials
        {
            get
            {
                return this.unDoneTutorials;
            }
            set
            {
                this.unDoneTutorials = value;
            }
        }

        public int VipLevel
        {
            get
            {
                return (int) this.vipLevel;
            }
            set
            {
                this.vipLevel = value;
            }
        }

        public int WineSoul
        {
            get
            {
                return this.wineSoul;
            }
            set
            {
                this.wineSoul = value;
            }
        }

        public int Zentia
        {
            get
            {
                return this.zentia;
            }
            set
            {
                this.zentia = value;
            }
        }
    }
}

