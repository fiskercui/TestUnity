#ifndef DEF_NETMSGID_H
#define DEF_NETMSGID_H
/**消息号定义**/
enum DEF_NetMsgId {
/**登录请求**/
	LOGIN_REQUEST = 1 ,
/**登录应答**/
	LOGIN_ANSWER = 2 ,
/**创建角色请求**/
	CREATE_ROLE_REQUEST = 3 ,
/**创建角色应答**/
	CREATE_ROLE_ANSWER = 4 ,
/**进入游戏请求**/
	ENTER_GAME_REQUEST = 5 ,
/**进入游戏应答**/
	ENTER_GAME_ANSWER = 6 ,
/**帐号被踢**/
	LOGIN_AGAIN_NOTIFY = 7 ,
/**获取卡牌的属性请求**/
	GET_CARD_ATTR_REQUEST = 8 ,
/**获取卡牌的属性应答**/
	GET_CARD_ATTR_ANSWER = 9 ,
/**退出游戏请求**/
	EXIT_GAME_REQUEST = 10 ,
/**退出游戏应答**/
	EXIT_GAME_ANSWER = 11 ,
/**获取角色的属性请求**/
	GET_PLAYER_ATTR_REQUEST = 12 ,
/**获取角色的属性应答**/
	GET_PLAYER_ATTR_ANSWER = 13 ,
/**列举背包请求**/
	LIST_BAG_REQUEST = 14 ,
/**列举背包应答**/
	LIST_BAG_ANSWER = 15 ,
/**GM增加物品请求**/
	GM_CMD_REQUEST = 16 ,
/**GM增加物品应答**/
	GM_CMD_ANSWER = 17 ,
/**武将升级请求**/
	HERO_UPGRADE_LEVEL_REQUEST = 18 ,
/**武将升级应答**/
	HERO_UPGRADE_LEVEL_ANSWER = 19 ,
/**武将突破请求**/
	HERO_OVERSTEP_REQUEST = 20 ,
/**武将突破应答**/
	HERO_OVERSTEP_ANSWER = 21 ,
/**武将上阵请求**/
	HERO_PLAY_REQUEST = 22 ,
/**武将上阵应答**/
	HERO_PLAY_ANSWER = 23 ,
/**武将助阵请求**/
	HERO_CHEER_REQUEST = 24 ,
/**武将助阵应答**/
	HERO_CHEER_ANSWER = 25 ,
/**武将布阵请求**/
	HERO_EMBATTLE_REQUEST = 26 ,
/**武将布阵应答**/
	HERO_EMBATTLE_ANSWER = 27 ,
/**装备强化请求**/
	EQUIP_STRENGTHEN_REQUEST = 28 ,
/**装备强化应答**/
	EQUIP_STRENGTHEN_ANSWER = 29 ,
/**装备升星请求**/
	EQUIP_UPGRADE_STAR_REQUEST = 30 ,
/**装备升星应答**/
	EQUIP_UPGRADE_STAR_ANSWER = 31 ,
/**装备精练请求**/
	EQUIP_REFINING_REQUEST = 32 ,
/**装备精练应答**/
	EQUIP_REFINING_ANSWER = 33 ,
/**穿装备请求**/
	EQUIP_DRESS_REQUEST = 34 ,
/**穿装备应答**/
	EQUIP_DRESS_ANSWER = 35 ,
/**脱装备请求**/
	EQUIP_UNDRESS_REQUEST = 36 ,
/**脱装备应答**/
	EQUIP_UNDRESS_ANSWER = 37 ,
/**副本开始请求**/
	RAID_START_REQUEST = 38 ,
/**副本开始应答**/
	RAID_START_ANSWER = 39 ,
/**使用物品请求**/
	USEITEM_REQUEST = 40 ,
/**使用物品应答**/
	USEITEM_ANSWER = 41 ,
/**副本记录请求**/
	RAID_RECORD_REQUEST = 42 ,
/**副本记录应答**/
	RAID_RECORD_ANSWER = 43 ,
/**副本宝箱奖励请求**/
	RAID_REWARD_REQUEST = 44 ,
/**副本宝箱奖励应答**/
	RAID_REWARD_ANSWER = 45 ,
/**武将天命请求**/
	HERO_UPGRADE_DESTINY_REQUEST = 46 ,
/**武将天命应答**/
	HERO_UPGRADE_DESTINY_ANSWER = 47 ,
/**武将培养请求**/
	HERO_CULTURE_REQUEST = 48 ,
/**武将培养应答**/
	HERO_CULTURE_ANSWER = 49 ,
/**武将培养替换请求**/
	HERO_CULTURE_REPLACE_REQUEST = 50 ,
/**武将培养替换应答**/
	HERO_CULTURE_REPLACE_ANSWER = 51 ,
/**武将觉醒请求**/
	HERO_UPGRADE_AWAKEN_REQUEST = 52 ,
/**武将觉醒应答**/
	HERO_UPGRADE_AWAKEN_ANSWER = 53 ,
/**武将穿戴觉醒装备请求**/
	HERO_INSTALL_AWAKEN_EQUIP_REQUEST = 54 ,
/**武将穿戴觉醒装备应答**/
	HERO_INSTALL_AWAKEN_EQUIP_ANSWER = 55 ,
/**武将觉醒装备合成请求**/
	HERO_AWAKEN_EQUIP_COMPOSE_REQUEST = 56 ,
/**武将穿戴觉醒装备应答**/
	HERO_AWAKEN_EQUIP_COMPOSE_ANSWER = 57 ,
/**获取竞技场角色列表请求**/
	ARENA_GET_PLAYER_REQUEST = 58 ,
/**获取竞技场角色列表应答**/
	ARENA_GET_PLAYER_ANSWER = 59 ,
/**竞技场开始请求**/
	ARENA_START_REQUEST = 60 ,
/**竞技场开始应答**/
	ARENA_START_ANSWER = 61 ,
/**竞技场翻牌请求**/
	ARENA_FLOP_REQUEST = 62 ,
/**竞技场翻牌应答**/
	ARENA_FLOP_ANSWER = 63 ,
/**竞技场商店请求**/
	ARENA_SHOP_REQUEST = 64 ,
/**竞技场商店应答**/
	ARENA_SHOP_ANSWER = 65 ,
/**竞技场商店购买请求**/
	ARENA_SHOP_BUY_REQUEST = 66 ,
/**竞技场商店购买应答**/
	ARENA_SHOP_BUY_ANSWER = 67 ,
/**分解请求**/
	FENJIE_REQUEST = 68 ,
/**分解回应**/
	FENJIE_ANSWER = 69 ,
/**插入邮件请求**/
	MAIL_INSERT_REQUEST = 70 ,
/**插入邮件应答**/
	MAIL_INSERT_ANSWER = 71 ,
/**列表邮件请求**/
	MAIL_LIST_REQUEST = 72 ,
/**列表邮件回应**/
	MAIL_LIST_ANSWER = 73 ,
/**领取邮件附件列表**/
	MAIL_GET_ITEM_REQUEST = 74 ,
/**领取邮件附件回应**/
	MAIL_GET_ITEM_ANSWER = 75 ,
/**新邮件通知**/
	MAIL_NEW_NOTIFY = 76 ,
/**邮件删除请求**/
	MAIL_DEL_REQUEST = 77 ,
/**邮件删除应答**/
	MAIL_DEL_ANSWER = 78 ,
/**邮件读取请求**/
	MAIL_READER_REQUEST = 79 ,
/**碎片合并请求**/
	CHIP_MERGE_REQUEST = 80 ,
/**碎片合并应答**/
	CHIP_MERGE_ANSWER = 81 ,
/**一健装备觉醒装备请求**/
	AUTO_INSTALL_AWAKEN_REQUEST = 82 ,
/**一健装备觉醒装备应答**/
	AUTO_INSTALL_AWAKEN_ANSWER = 83 ,
/**爬塔信息请求**/
	TOWER_LADDER_INFO_REQUEST = 84 ,
/**爬塔信息应答**/
	TOWER_LADDER_INFO_ANSWER = 85 ,
/**爬塔重置请求**/
	TOWER_LADDER_RESET_REQUEST = 86 ,
/**爬塔重置应答**/
	TOWER_LADDER_RESET_ANSWER = 87 ,
/**爬塔选择属性请求**/
	TOWER_LADDER_ATTR_REQUEST = 88 ,
/**爬塔选择属性应答**/
	TOWER_LADDER_ATTR_ANSWER = 89 ,
/**爬塔开始副本请求**/
	TOWER_LADDER_START_REQUEST = 90 ,
/**爬塔开始副本应答**/
	TOWER_LADDER_START_ANSWER = 91 ,
/**爬塔开始精英副本请求**/
	TOWER_LADDER_ELITE_REQUEST = 92 ,
/**爬塔开始精英副本应答**/
	TOWER_LADDER_ELITE_ANSWER = 93 ,
/**爬塔排行请求**/
	TOWER_LADDER_RANK_REQUEST = 94 ,
/**爬塔排行应答**/
	TOWER_LADDER_RANK_ANSWER = 95 ,
/**爬塔购买精英次数请求**/
	TOWER_BUY_ELITE_REQUEST = 96 ,
/**爬塔购买精英次数应答**/
	TOWER_BUY_ELITE_ANSWER = 97 ,
/**爬塔购买推荐道具请求**/
	TOWER_BUY_PROP_REQUEST = 98 ,
/**爬塔购买推荐道具应答**/
	TOWER_BUY_PROP_ANSWER = 99 ,
/**黄庭请求**/
	HUANGTING_REQUEST = 100 ,
/**黄庭应答**/
	HUANGTING_ANSWER = 101 ,
/**武将下阵请求**/
	HERO_UNPLAY_REQUEST = 102 ,
/**武将下阵应答**/
	HERO_UNPLAY_ANSWER = 103 ,
/**附近角色请求**/
	FRIEND_NEAR_REQUEST = 104 ,
/**附近角色应答**/
	FRIEND_NEAR_ANSWER = 105 ,
/**挑战好友请求**/
	FRIEND_DEKARON_REQUEST = 106 ,
/**挑战好友应答**/
	FRIEND_DEKARON_ANSWER = 107 ,
/**抽卡请求**/
	CHOUKA_REQUEST = 108 ,
/**抽卡好友应答**/
	CHOUKA_ANSWER = 109 ,
/**获取角色信息请求**/
	GET_PLAYER_INFO_REQUEST = 110 ,
/**获取角色信息应答**/
	GET_PLAYER_INFO_ANSWER = 111 ,
/**副本扫荡请求**/
	MAIN_RAID_SWEEP_REQUEST = 112 ,
/**副本扫荡应答**/
	MAIN_RAID_SWEEP_ANSWER = 113 ,
/**判军列表请求**/
	REBEL_LIST_REQUEST = 114 ,
/**判军列表应答**/
	REBEL_LIST_ANSWER = 115 ,
/**判军分享线好友请求**/
	REBEL_SHARE_REQUEST = 116 ,
/**判军分享线好友应答**/
	REBEL_SHARE_ANSWER = 117 ,
/**判军副本开始请求**/
	REBEL_RAID_START_REQUEST = 118 ,
/**判军副本开始应答**/
	REBEL_RAID_START_ANSWER = 119 ,
/**判军BOSS功勋排行榜请求**/
	REBEL_BOSS_CREDIT_RANK_REQUEST = 120 ,
/**判军BOSS功勋排行榜应答**/
	REBEL_BOSS_CREDIT_RANK_ANSWER = 121 ,
/**判军伤害排行榜请求**/
	REBEL_HURT_RANK_REQUEST = 122 ,
/**判军伤害排行榜应答**/
	REBEL_HURT_RANK_ANSWER = 123 ,
/**神将商店请求**/
	SHENJIANG_SHOP_REQUEST = 124 ,
/**神将商店购买请求**/
	SHENJIANG_SHOP_BUY_REQUEST = 125 ,
/**神将商店应答**/
	SHENJIANG_SHOP_ANSWER = 126 ,
/**玩法商店请求**/
	SHOP_PLAY_INFO_REQUEST = 127 ,
/**玩法商店应答**/
	SHOP_PLAY_ANSWER = 128 ,
/**玩法商店购买请求**/
	SHOP_PLAY_BUY_REQUEST = 129 ,
/**玩法商店购买应答**/
	SHOP_PLAY_BUY_ANSWER = 130 ,
/**判军功勋奖励请求**/
	REBEL_EXPLOIT_REWARD_REQUEST = 131 ,
/**判军功勋奖励应答**/
	REBEL_EXPLOIT_REWARD_ANSWER = 132 ,
/**穿宝物请求**/
	TREASURE_DRESS_REQUEST = 133 ,
/**穿宝物应答**/
	TREASURE_DRESS_ANSWER = 134 ,
/**脱宝物请求**/
	TREASURE_UNDRESS_REQUEST = 135 ,
/**脱宝物应答**/
	TREASURE_UNDRESS_ANSWER = 136 ,
/**宝物强化请求**/
	TREASURE_STRENGTHEN_REQUEST = 137 ,
/**宝物强化应答**/
	TREASURE_STRENGTHEN_ANSWER = 138 ,
/**宝物精练请求**/
	TREASURE_REFINING_REQUEST = 139 ,
/**宝物精练应答**/
	TREASURE_REFINING_ANSWER = 140 ,
/**宝物铸造请求**/
	TREASURE_FORGE_REQUEST = 141 ,
/**宝物铸造应答**/
	TREASURE_FORGE_ANSWER = 142 ,
/**判军BOSS列表请求**/
	REBEL_BOSS_LIST_REQUEST = 143 ,
/**判军BOSS列表应答**/
	REBEL_BOSS_LIST_ANSWER = 144 ,
/**判军BOSS副本开始请求**/
	REBEL_BOSS_START_REQUEST = 145 ,
/**判军BOSS副本开始应答**/
	REBEL_BOSS_START_ANSWER = 146 ,
/**判军BOSS伤害排行榜请求**/
	REBEL_BOSS_HURT_RANK_REQUEST = 147 ,
/**判军BOSS伤害排行榜应答**/
	REBEL_BOSS_HURT_RANK_ANSWER = 148 ,
/**每日判军功勋排行榜请求**/
	REBEL_CREDIT_DAILY_RANK_REQUEST = 149 ,
/**每日判军功勋排行榜应答**/
	REBEL_CREDIT_DAILY_RANK_ANSWER = 150 ,
/**每日判军伤害排行榜请求**/
	REBEL_HURT_DAILY_RANK_REQUEST = 151 ,
/**每日判军伤害排行榜应答**/
	REBEL_HURT_DAILY_RANK_ANSWER = 152 ,
/**胭脂列表请求**/
	BLUSHER_LIST_REQUEST = 153 ,
/**胭脂列表应答**/
	BLUSHER_LIST_ANSWER = 154 ,
/**胭脂取悦请求**/
	BLUSHER_WOO_REQUEST = 155 ,
/**胭脂取悦应答**/
	BLUSHER_WOO_ANSWER = 156 ,
/**胭脂点赞请求**/
	BLUSHER_ADMIRE_REQUEST = 157 ,
/**胭脂点赞应答**/
	BLUSHER_ADMIRE_ANSWER = 158 ,
/**胭脂领取升级奖励请求**/
	BLUSHER_UPLV_REWARD_REQUEST = 159 ,
/**胭脂领取升级奖励应答**/
	BLUSHER_UPLV_REWARD_ANSWER = 160 ,
/**胭脂领取奇遇奖励请求**/
	BLUSHER_LUCK_REWARD_REQUEST = 161 ,
/**胭脂领取奇遇奖励应答**/
	BLUSHER_LUCK_REWARD_ANSWER = 162 ,
/**胭脂排行请求**/
	BLUSHER_RANK_REQUEST = 163 ,
/**胭脂排行应答**/
	BLUSHER_RANK_ANSWER = 164 ,
/**竞技场前30名排行请求**/
	ARENA_RANK_REQUEST = 165 ,
/**竞技场前30名排行应答**/
	ARENA_RANK_ANSWER = 166 ,
/**发送聊天请求**/
	CHAT_SEND_REQUEST = 167 ,
/**发送聊天应答**/
	CHAT_SEND_ANSWER = 168 ,
/**聊天消息通知**/
	CHAT_MSG_NOTIFY = 169 ,
/**广播消息通知**/
	BROADCAST_NOTIFY = 170 ,
/**吃黄瓜请求**/
	EAT_CUCUMBER_REQUEST = 171 ,
/**吃黄瓜应答**/
	EAT_CUCUMBER_ANSWER = 172 ,
/**日常任务列表**/
	TASK_DAILY_LIST_REQUEST = 173 ,
/**日常任务应答**/
	TASK_DAILY_LIST_ANSWER = 174 ,
/**日常任务获取奖励列表**/
	TASK_DAILY_GET_REWARD_REQUEST = 175 ,
/**日常任务获取奖励应答**/
	TASK_DAILY_GET_REWARD_ANSWER = 176 ,
/**日常任务宝箱奖励请求**/
	TASK_DAILY_BOX_REWARD_REQUEST = 177 ,
/**日常任务宝箱奖励应答**/
	TASK_DAILY_BOX_REWARD_ANSWER = 178 ,
/**七日任务列表**/
	TASK_SEVEN_LIST_REQUEST = 179 ,
/**七日任务应答**/
	TASK_SEVEN_LIST_ANSWER = 180 ,
/**七日任务获取奖励列表**/
	TASK_SEVEN_GET_REWARD_REQUEST = 181 ,
/**七日任务获取奖励应答**/
	TASK_SEVEN_GET_REWARD_ANSWER = 182 ,
/**七日半价购买请求**/
	TASK_SEVEN_BUY_REWARD_REQUEST = 183 ,
/**七日半价购买应答**/
	TASK_SEVEN_BUY_REWARD_ANSWER = 184 ,
/**成就任务列表**/
	TASK_VOSTRO_LIST_REQUEST = 185 ,
/**成就任务应答**/
	TASK_VOSTRO_LIST_ANSWER = 186 ,
/**成就任务获取奖励列表**/
	TASK_VOSTRO_GET_REWARD_REQUEST = 187 ,
/**成就任务获取奖励应答**/
	TASK_VOSTRO_GET_REWARD_ANSWER = 188 ,
/**签到请求**/
	SIGN_REQUEST = 189 ,
/**签到应答**/
	SIGN_ANSWER = 190 ,
/**摇钱树请求**/
	MONEY_TREE_REQUEST = 191 ,
/**摇钱树应答**/
	MONEY_TREE_ANSWER = 192 ,
/**活动列表请求**/
	ACTIVITY_LIST_REQUEST = 193 ,
/**活动列表应答**/
	ACTIVITY_LIST_ANSWER = 194 ,
/**活动领取奖励请求**/
	ACTIVITY_REWARD_REQUEST = 195 ,
/**活动领取奖励应答**/
	ACTIVITY_REWARD_ANSWER = 196 ,
/**主角升级通知**/
	LEVEL_UP_NOTIFY = 197 ,
/**排行榜请求**/
	COMMON_RANK_REQUEST = 198 ,
/**排行榜应答**/
	COMMON_RANK_ANSWER = 199 ,
/**排行榜点赞请求**/
	COMMON_RANK_LIKE_REQUEST = 200 ,
/**排行榜点赞应答**/
	COMMON_RANK_LIKE_ANSWER = 201 ,
/**查看玩家请求**/
	VIEW_PLAYER_REQUEST = 202 ,
/**查看玩家应答**/
	VIEW_PLAYER_ANSWER = 203 ,
/**切磋请求**/
	QIECUO_START_REQUEST = 204 ,
/**切磋开始请求(排行服-游戏服)**/
	QIECUO_START_SERVER_REQUEST = 205 ,
/**切磋应答**/
	QIECUO_START_ANSWER = 206 ,
/**七日活动碎片奖励请求**/
	TASK_SEVEN_CHIP_REWARD_REQUEST = 207 ,
/**七日活动碎片奖励应答**/
	TASK_SEVEN_CHIP_REWARD_ANSWER = 208 ,
/**好友列表请求**/
	FRIEND_LIST_REQUEST = 209 ,
/**好友列表应答**/
	FRIEND_LIST_ANSWER = 210 ,
/**好友申请请求**/
	FRIEND_APPLY_ADD_REQUEST = 211 ,
/**好友申请应答**/
	FRIEND_APPLY_ADD_ANSWER = 212 ,
/**好友申请同意请求**/
	FRIEND_AGREE_REQUEST = 213 ,
/**好友申请同意应答**/
	FRIEND_AGREE_ANSWER = 214 ,
/**好友申请拒绝请求**/
	FRIEND_REFUSE_REQUEST = 215 ,
/**好友申请拒绝应答**/
	FRIEND_REFUSE_ANSWER = 216 ,
/**删除好友请求**/
	FRIEND_DEL_REQUEST = 217 ,
/**删除好友应答**/
	FRIEND_DEL_ANSWER = 218 ,
/**赠送精力请求**/
	FRIEND_SEND_ENERGY_REQUEST = 219 ,
/**赠送精力应答**/
	FRIEND_SEND_ENERGY_ANSWER = 220 ,
/**接受精力请求**/
	FRIEND_RECV_ENERGY_REQUEST = 221 ,
/**接受精力应答**/
	FRIEND_RECV_ENERGY_ANSWER = 222 ,
/**好友申请列表请求**/
	FRIEND_APPLY_LIST_REQUEST = 223 ,
/**好友申请列表应答**/
	FRIEND_APPLY_LIST_ANSWER = 224 ,
/**好友推荐请求**/
	FRIEND_RECOMMEND_REQUEST = 225 ,
/**好友推荐应答**/
	FRIEND_RECOMMEND_ANSWER = 226 ,
/**一键装备强化请求**/
	EQUIP_AUTO_STRENGTHEN_REQUEST = 227 ,
/**一键装备强化应答**/
	EQUIP_AUTO_STRENGTHEN_ANSWER = 228 ,
/**设置好友黑名单请求**/
	FRIEND_BLACKLIST_REQUEST = 229 ,
/**设置好友黑名单应答**/
	FRIEND_BLACKLIST_ANSWER = 230 ,
/**取消好友黑名单请求**/
	FRIEND_CANCEL_BLACKLIST_REQUEST = 231 ,
/**取消好友黑名单应答**/
	FRIEND_CANCEL_BLACKLIST_ANSWER = 232 ,
/**黑名单列表请求**/
	BLACK_LIST_REQUEST = 233 ,
/**黑名单列表应答**/
	BLACK_LIST_ANSWER = 234 ,
/**根据名字增加好友请求**/
	FRIEND_ADD_BY_NAME_REQUEST = 235 ,
/**发送邮件请求**/
	MAIL_SEND_REQUEST = 236 ,
/**发送邮件应答**/
	MAIL_SEND_ANSWER = 237 ,
/**提交新手引导**/
	GUILD_COMMIT_REQUEST = 238 ,
/**使用兑换码结果**/
	USE_CDK_ANSWER = 239 ,
/**增量推送武将**/
	INC_HOER_NOTIFY = 240 ,
/**武将出售请求**/
	HERO_SELL_REQUEST = 241 ,
/**武将出售应答**/
	HERO_SELL_ANSWER = 242 ,
/**装备出售请求**/
	EQUIP_SELL_REQUEST = 243 ,
/**装备出售应答**/
	EQUIP_SELL_ANSWER = 244 ,
/**宝物出售请求**/
	TREASURE_SELL_REQUEST = 245 ,
/**宝物出售应答**/
	TREASURE_SELL_ANSWER = 246 ,
/**出售碎片请求**/
	SELL_CHIP_REQUEST = 247 ,
/**出售碎片应答**/
	SELL_CHIP_ANSWER = 248 ,
/**胭脂榜商店购买请求**/
	BLUSHER_SHOP_BUY_REQUEST = 249 ,
/**胭脂榜商店购买应答**/
	BLUSHER_SHOP_BUY_ANSWER = 250 ,
/**副本重置请求**/
	RAID_RESET_REQUEST = 251 ,
/**副本重置应答**/
	RAID_RESET_ANSWER = 252 ,
/**判军伤害排行榜应答**/
	REBEL_SHARE_FLAG_NOTIFY = 253 ,
/**新叛军通知**/
	REBEL_CREATE_FLAG_NOTIFY = 254 ,
/**特殊奖励通知**/
	SPECIAL_AWARD_NOTIFY = 255 ,
/**帮派创建请求**/
	LEGION_CREATE_REQUEST = 256 ,
/**帮派创建应答**/
	LEGION_CREATE_ANSWER = 257 ,
/**帮派解散请求**/
	LEGION_DELETE_REQUEST = 258 ,
/**帮派解散应答**/
	LEGION_DELETE_ANSWER = 259 ,
/**帮派信息请求**/
	LEGION_INFO_REQUEST = 260 ,
/**帮派信息应答**/
	LEGION_INFO_ANSWER = 261 ,
/**帮派成员列表请求**/
	LEGION_MEMBER_LIST_REQUEST = 262 ,
/**帮派成员列表应答**/
	LEGION_MEMBER_LIST_ANSWER = 263 ,
/**帮派动态请求**/
	LEGION_EVENT_REQUEST = 264 ,
/**帮派动态应答**/
	LEGION_EVENT_ANSWER = 265 ,
/**帮派列表请求**/
	LEGION_LIST_REQUEST = 266 ,
/**帮派列表应答**/
	LEGION_LIST_ANSWER = 267 ,
/**帮派入帮申请请求**/
	LEGION_APPLY_REQUEST = 268 ,
/**帮派入帮申请应答**/
	LEGION_APPLY_ANSWER = 269 ,
/**帮派撤销申请请求**/
	LEGION_CANCEL_APPLY_REQUEST = 270 ,
/**帮派撤销申请应答**/
	LEGION_CANCEL_APPLY_ANSWER = 271 ,
/**帮派申请列表请求**/
	LEGION_APPLY_LIST_REQUEST = 272 ,
/**帮派申请列表应答**/
	LEGION_APPLY_LIST_ANSWER = 273 ,
/**帮派接受入帮申请请求**/
	LEGION_ACCEPT_APPLY_REQUEST = 274 ,
/**帮派接受入帮申请应答**/
	LEGION_ACCEPT_APPLY_ANSWER = 275 ,
/**帮派拒绝入帮申请请求**/
	LEGION_REFUSE_APPLY_REQUEST = 276 ,
/**帮派拒绝入帮申请应答**/
	LEGION_REFUSE_APPLY_ANSWER = 277 ,
/**帮派任命副帮主请求**/
	LEGION_APPOINT_REQUEST = 278 ,
/**帮派任命副帮主应答**/
	LEGION_APPOINT_ANSWER = 279 ,
/**帮派罢免副帮主请求**/
	LEGION_DISMISS_REQUEST = 280 ,
/**帮派罢免副帮主应答**/
	LEGION_DISMISS_ANSWER = 281 ,
/**帮派移交帮主请求**/
	LEGION_TRANSFER_REQUEST = 282 ,
/**帮派移交帮主应答**/
	LEGION_TRANSFER_ANSWER = 283 ,
/**帮派踢出请求**/
	LEGION_MEMBER_DEL_REQUEST = 284 ,
/**帮派踢出应答**/
	LEGION_MEMBER_DEL_ANSWER = 285 ,
/**帮派退出请求**/
	LEGION_QUIT_REQUEST = 286 ,
/**帮派退出应答**/
	LEGION_QUIT_ANSWER = 287 ,
/**帮派弹劾请求**/
	LEGION_IMPEACH_REQUEST = 288 ,
/**帮派弹劾应答**/
	LEGION_IMPEACH_ANSWER = 289 ,
/**帮派标志修改请求**/
	LEGION_CHANGE_LOGO_REQUEST = 290 ,
/**帮派标志修改应答**/
	LEGION_CHANGE_LOGO_ANSWER = 291 ,
/**帮派留言板请求**/
	LEGION_MESSAGE_REQUEST = 292 ,
/**帮派留言板应答**/
	LEGION_MESSAGE_ANSWER = 293 ,
/**帮派留言请求**/
	LEGION_SEND_MESSAGE_REQUEST = 294 ,
/**帮派留言应答**/
	LEGION_SEND_MESSAGE_ANSWER = 295 ,
/**帮派置顶留言请求**/
	LEGION_STICKY_MESSAGE_REQUEST = 296 ,
/**帮派置顶留言应答**/
	LEGION_STICKY_MESSAGE_ANSWER = 297 ,
/**帮派祭天请求**/
	LEGION_WORSHIP_REQUEST = 298 ,
/**帮派祭天应答**/
	LEGION_WORSHIP_ANSWER = 299 ,
/**领取VIP每日福利请求**/
	DRAW_VIP_WELFARE_REQUEST = 300 ,
/**领取VIP每日福利应答**/
	DRAW_VIP_WELFARE_ANSWER = 301 ,
/**帮派祭天开箱子请求**/
	LEGION_WORSHIP_OPEN_BOX_REQUEST = 302 ,
/**帮派祭天开箱子应答**/
	LEGION_WORSHIP_OPEN_BOX_ANSWER = 303 ,
/**军团限时商店信息请求**/
	LEGION_LIMIT_SHOP_INFO_REQUEST = 304 ,
/**军团限时商店信息应答**/
	LEGION_LIMIT_SHOP_INFO_ANSWER = 305 ,
/**军团限时商店购买请求**/
	LEGION_LIMIT_SHOP_BUY_REQUEST = 306 ,
/**军团限时商店购买应答**/
	LEGION_LIMIT_SHOP_BUY_ANSWER = 307 ,
/**帮派技能信息请求**/
	LEGION_SKILL_INFO_REQUEST = 308 ,
/**帮派技能信息应答**/
	LEGION_SKILL_INFO_ANSWER = 309 ,
/**帮派技能升级请求**/
	LEGION_SKILL_UPLEVEL_REQUEST = 310 ,
/**帮派技能升级应答**/
	LEGION_SKILL_UPLEVEL_ANSWER = 311 ,
/**帮派技能提升等级上限请求**/
	LEGION_SKILL_UPLIMIT_REQUEST = 312 ,
/**帮派技能提升等级上限应答**/
	LEGION_SKILL_UPLIMIT_ANSWER = 313 ,
/**开服排行活动信息请求**/
	OPENSRV_RANK_ACTIVITY_REQUEST = 314 ,
/**开服排行活动信息**/
	OPENSRV_RANK_ACTIVITY_ANSWER = 315 ,
/**开服排行活动领取奖励请求**/
	OPENSRV_RANK_DRAW_AWARD_REQUEST = 316 ,
/**开服排行活动领取奖励应答**/
	OPENSRV_RANK_DRAW_AWARD_ANSWER = 317 ,
/**帮派取消置顶留言请求**/
	LEGION_CANCEL_STICKY_MESSAGE_REQUEST = 318 ,
/**帮派取消置顶留言应答**/
	LEGION_CANCEL_STICKY_MESSAGE_ANSWER = 319 ,
/**vip周礼包信息请求**/
	VIP_WEEK_PACKAGE_INFO_REQUEST = 320 ,
/**vip周礼包信息应答**/
	VIP_WEEK_PACKAGE_INFO_ANSWER = 321 ,
/**vip周礼购买请求**/
	VIP_WEEK_PACKAGE_BUY_REQUEST = 322 ,
/**vip周礼购买应答**/
	VIP_WEEK_PACKAGE_BUY_ANSWER = 323 ,
/**帮派排行榜请求**/
	LEGION_RANK_REQUEST = 324 ,
/**帮派排行榜应答**/
	LEGION_RANK_ANSWER = 325 ,
/**爬塔挑战整层请求**/
	TOWER_LADDER_START_FLOOR_REQUEST = 326 ,
/**爬塔挑战整层应答**/
	TOWER_LADDER_START_FLOOR_ANSWER = 327 ,
/**帮派修改宣言请求**/
	LEGION_CHANGE_DECLARATION_REQUEST = 328 ,
/**帮派修改宣言应答**/
	LEGION_CHANGE_DECLARATION_ANSWER = 329 ,
/**帮派修改公告请求**/
	LEGION_CHANGE_BULLETIN_REQUEST = 330 ,
/**帮派修改公告应答**/
	LEGION_CHANGE_BULLETIN_ANSWER = 331 ,
/**爬塔扫荡请求**/
	TOWER_LADDER_SWEEP_REQUEST = 332 ,
/**爬塔扫荡应答**/
	TOWER_LADDER_SWEEP_ANSWER = 333 ,
/**竞技场批量战斗请求**/
	ARENA_MULTI_START_REQUEST = 334 ,
/**竞技场批量战斗应答**/
	ARENA_MULTI_START_ANSWER = 335 ,
/**背包不足时通知**/
	BAG_NOT_ENOUGH_NOTIFY = 336 ,
/**占山为王据点信息请求**/
	CRUSADE_FORTRESS_INFO_REQUEST = 337 ,
/**占山为王据点信息应答**/
	CRUSADE_FORTRESS_INFO_ANSWER = 338 ,
/**占山为王据点挑战请求**/
	CRUSADE_FORTRESS_FIGHT_REQUEST = 339 ,
/**占山为王据点挑战应答**/
	CRUSADE_FORTRESS_FIGHT_ANSWER = 340 ,
/**占山为王进度请求**/
	KING_FIGHT_REQUEST = 341 ,
/**占山为王进度应答**/
	KING_FIGHT_ANSWER = 342 ,
/**占山为王关卡数据请求**/
	KING_FIGHT_STAGE_INFO_REQUEST = 343 ,
/**占山为王关卡数据应答**/
	KING_FIGHT_STAGE_INFO_ANSWER = 344 ,
/**挑战占山为王关卡请求**/
	KING_FIGHT_START_REQUEST = 345 ,
/**挑战占山为王关卡应答**/
	KING_FIGHT_START_ANSWER = 346 ,
/**占山为王道具使用请求**/
	KING_FIGHT_USE_ITEM_REQUEST = 347 ,
/**占山为王道具使用应答**/
	KING_FIGHT_USE_ITEM_ANSWER = 348 ,
/**占山为王据点领取据点收益请求**/
	CRUSADE_FORTRESS_REWARD_REQUEST = 349 ,
/**占山为王据点领取据点收益应答**/
	CRUSADE_FORTRESS_REWARD_ANSWER = 350 ,
/**占山为王据点领取进度宝箱请求**/
	CRUSADE_FORTRESS_OPEN_BOX_REQUEST = 351 ,
/**占山为王据点领取进度宝箱回复**/
	CRUSADE_FORTRESS_OPEN_BOX_ANSWER = 352 ,
/**寻访信息请求**/
	VISIT_INFO_REQUEST = 353 ,
/**寻访信息应答**/
	VISIT_INFO_ANSWER = 354 ,
/**寻访发车请求**/
	VISIT_START_REQUEST = 355 ,
/**寻访发车应答**/
	VISIT_START_ANSWER = 356 ,
/**寻访领取奖励请求**/
	VISIT_GET_REWARD_REQUEST = 357 ,
/**寻访领取奖励应答**/
	VISIT_GET_REWARD_ANSWER = 358 ,
/**占山为王购买次数请求**/
	KING_FIGHT_BUY_CNT_REQUEST = 359 ,
/**占山为王购买次数应答**/
	KING_FIGHT_BUY_CNT_ANSWER = 360 ,
/**占山为王星级排行请求**/
	KING_FIGHT_RANK_STAR_REQUEST = 361 ,
/**占山为王星级排行应答**/
	KING_FIGHT_RANK_STAR_ANSWER = 362 ,
/**占山为王伤害排行请求**/
	KING_FIGHT_RANK_DAMAGE_REQUEST = 363 ,
/**占山为王伤害排行应答**/
	KING_FIGHT_RANK_DAMAGE_ANSWER = 364 ,
/**随机拜访信息请求**/
	VISIT_INFO_RANDOM_REQUEST = 365 ,
/**随机拜访信息应答**/
	VISIT_INFO_RANDOM_ANSWER = 366 ,
/**拜访好友列表请求**/
	VISIT_FRIEND_LIST_REQUEST = 367 ,
/**拜访好友列表应答**/
	VISIT_FRIEND_LIST_ANSWER = 368 ,
/**拜访好友请求**/
	VISIT_FRIEND_REQUEST = 369 ,
/**拜访好友应答**/
	VISIT_FRIEND_ANSWER = 370 ,
/**领取好友驿站奖励请求**/
	VISIT_FRIEND_REWARD_REQUEST = 371 ,
/**领取好友驿站奖励应答**/
	VISIT_FRIEND_REWARD_ANSWER = 372 ,
/**好友加速请求**/
	VISIT_FRIEND_ACCELERATE_REQUEST = 373 ,
/**好友加速应答**/
	VISIT_FRIEND_ACCELERATE_ANSWER = 374 ,
/**占山为王据点战斗记录请求**/
	CRUSADE_FORTRESS_BATTLE_RECORD_REQUEST = 375 ,
/**占山为王据点战斗记录应答**/
	CRUSADE_FORTRESS_BATTLE_RECORD_ANSWER = 376 ,
/**占山为王据点战斗回放请求**/
	CRUSADE_FORTRESS_REPLAY_RECORD_REQUEST = 377 ,
/**占山为王据点战斗回放应答**/
	CRUSADE_FORTRESS_REPLAY_RECORD_ANSWER = 378 ,
/**寻访保存方案请求**/
	VISIT_SAVE_ROUTE_REQUEST = 379 ,
/**寻访保存方案应答**/
	VISIT_SAVE_ROUTE_ANSWER = 380 ,
/**一键发车请求**/
	VISIT_ONE_KEY_START_REQUEST = 381 ,
/**一键发车应答**/
	VISIT_ONE_KEY_START_ANSWER = 382 ,
/**获取保存方案请求**/
	VISIT_GET_SAVE_ROUTE_REQUEST = 383 ,
/**获取保存方案答复**/
	VISIT_GET_SAVE_ROUTE_ANSWER = 384 ,
/**占山为王据点擂主购买buff请求**/
	CRUSADE_FORTRESS_BUY_BUFF_REQUEST = 385 ,
/**占山为王据点擂主购买buff应答**/
	CRUSADE_FORTRESS_BUY_BUFF_ANSWER = 386 ,
/**占山为王据点快捷查看信息请求**/
	CRUSADE_FORTRESS_ALL_INFO_REQUEST = 387 ,
/**占山为王据点快捷查看信息应答**/
	CRUSADE_FORTRESS_ALL_INFO_ANSWER = 388 ,
/**占山为王据点购买次数请求**/
	CRUSADE_FORTRESS_BUY_CNT_REQUEST = 389 ,
/**占山为王据点购买次数应答**/
	CRUSADE_FORTRESS_BUY_CNT_ANSWER = 390 ,
/**一键领取奖励请求**/
	VISIT_ONE_KEY_GET_REWARD_REQUEST = 391 ,
/**一键领取奖励应答**/
	VISIT_ONE_KEY_GET_REWARD_ANSWER = 392 ,
/**系统更新通知**/
	SYSTEM_UPDATE_NOTIFY = 393 ,
/**开服基金请求**/
	OPEN_FUND_REQUEST = 394 ,
/**开服基金应答**/
	OPEN_FUND_ANSWER = 395 ,
/**购买开服基金请求**/
	OPEN_FUND_BUY_REQUEST = 396 ,
/**购买开服基金应答**/
	OPEN_FUND_BUY_ANSWER = 397 ,
/**领取开服基金请求**/
	OPEN_FUND_GET_REQUEST = 398 ,
/**领取开服基金应答**/
	OPEN_FUND_GET_ANSWER = 399 ,
/**领取全民福利请求**/
	UNIVERSAL_WELFARE_GET_REQUEST = 400 ,
/**领取全民福利应答**/
	UNIVERSAL_WELFARE_GET_ANSWER = 401 ,
/**武帝预选排名请求**/
	WUDI_PRESELECT_RANK_REQUEST = 402 ,
/**武帝预选排名应答**/
	WUDI_PRESELECT_RANK_ANSWER = 403 ,
/**武帝信息请求**/
	WUDI_INFO_REQUEST = 404 ,
/**武帝信息应答**/
	WUDI_INFO_ANSWER = 405 ,
/**月卡信息请求**/
	MONTH_CARD_INFO_REQUEST = 406 ,
/**月卡信息应答**/
	MONTH_CARD_INFO_ANSWER = 407 ,
/**月卡奖励领取请求**/
	MONTH_CARD_GET_REQUEST = 408 ,
/**月卡奖励领取应答**/
	MONTH_CARD_GET_ANSWER = 409 ,
/**武帝挑战请求**/
	WUDI_FIGHT_REQUEST = 410 ,
/**武帝挑战应答**/
	WUDI_FIGHT_ANSWER = 411 ,
/**武帝伤害排行请求**/
	WUDI_HURT_RANK_REQUEST = 412 ,
/**武帝伤害排行应答**/
	WUDI_HURT_RANK_ANSWER = 413 ,
/**购买武帝挑战次数请求**/
	BUY_WUDI_FIGHT_CNT_REQUEST = 414 ,
/**购买武帝挑战次数应答**/
	BUY_WUDI_FIGHT_CNT_ANSWER = 415 ,
/**购买武帝挑战buff请求**/
	BUY_WUDI_FIGHT_BUFF_REQUEST = 416 ,
/**购买武帝挑战buff应答**/
	BUY_WUDI_FIGHT_BUFF_ANSWER = 417 ,
/**购买武帝buff请求**/
	BUY_WUDI_BOSS_BUFF_REQUEST = 418 ,
/**购买武帝buff应答**/
	BUY_WUDI_BOSS_BUFF_ANSWER = 419 ,
/**武帝开放通知**/
	WUDI_OPEN_NOTIFY = 420 ,
/**帮派修改收人条件请求**/
	LEGION_CHANGE_ACCEPT_TPYE_REQUEST = 421 ,
/**帮派修改收人条件应答**/
	LEGION_CHANGE_ACCEPT_TPYE_ANSWER = 422 ,
/**觉醒道具出售请求**/
	SELL_AWAKEN_ITEM_REQUEST = 423 ,
/**觉醒道具出售应答**/
	SELL_AWAKEN_ITEM_ANSWER = 424 ,
/**觉醒道具分解请求**/
	FENJIE_AWAKEN_ITEM_REQUEST = 425 ,
/**觉醒道具分解应答**/
	FENJIE_AWAKEN_ITEM_ANSWER = 426 ,
/**首充送礼领取请求**/
	FIRST_RECHARGE_AWARD_GET_REQUEST = 427 ,
/**首充送礼领取应答**/
	FIRST_RECHARGE_AWARD_GET_ANSWER = 428 ,
/**邮件状态请求**/
	MAIL_STATUS_REQUEST = 429 ,
/**抽卡活动通知**/
	CHOUKA_ACTIVITY_NOTIFY = 430 ,
/**帮派副本信息请求**/
	LEGION_BOSS_INFO_REQUEST = 431 ,
/**帮派副本信息应答**/
	LEGION_BOSS_INFO_ANSWER = 432 ,
/**帮派副本开始请求**/
	LEGION_BOSS_FIGHT_REQUEST = 433 ,
/**帮派副本开始应答**/
	LEGION_BOSS_FIGHT_ANSWER = 434 ,
/**帮派副本获取奖励请求**/
	LEGION_BOSS_GET_REWARD_REQUEST = 435 ,
/**帮派副本获取奖励应答**/
	LEGION_BOSS_GET_REWARD_ANSWER = 436 ,
/**帮派消灭排行请求**/
	LEGION_BOSS_FIRST_KILL_RANK_REQUEST = 437 ,
/**帮派消灭排行应答**/
	LEGION_BOSS_FIRST_KILL_RANK_ANSWER = 438 ,
/**帮派推本排行请求**/
	LEGION_BOSS_TOTAL_STAGE_RANK_REQUEST = 439 ,
/**帮派推本排行应答**/
	LEGION_BOSS_TOTAL_STAGE_RANK_ANSWER = 440 ,
/**帮内单次伤害排行请求**/
	LEGION_BOSS_LEGION_MAX_DAMAGE_RANK_REQUEST = 441 ,
/**帮内单次伤害排行应答**/
	LEGION_BOSS_LEGION_MAX_DAMAGE_RANK_ANSWER = 442 ,
/**全服单次伤害排行请求**/
	LEGION_BOSS_MAX_DAMAGE_RANK_REQUEST = 443 ,
/**全服单次伤害排行应答**/
	LEGION_BOSS_MAX_DAMAGE_RANK_ANSWER = 444 ,
/**帮派BOSS击杀数排行请求**/
	LEGION_BOSS_KILL_COUNT_RANK_REQUEST = 445 ,
/**帮派BOSS击杀数排行应答**/
	LEGION_BOSS_KILL_COUNT_RANK_ANSWER = 446 ,
/**帮派BOSS任务信息请求**/
	LEGION_BOSS_TASK_INFO_REQUEST = 447 ,
/**帮派BOSS任务信息应答**/
	LEGION_BOSS_TASK_INFO_ANSWER = 448 ,
/**帮派BOSS任务奖励领取请求**/
	LEGION_BOSS_TASK_GET_REQUEST = 449 ,
/**帮派BOSS任务奖励领取应答**/
	LEGION_BOSS_TASK_GET_ANSWER = 450 ,
/**豪华签到领取奖励请求**/
	LUXURY_SIGN_GET_REWARD_REQUEST = 451 ,
/**豪华签到领取奖励应答**/
	LUXURY_SIGN_GET_REWARD_ANSWER = 452 ,
/**已展示过的合击武将通知**/
	UNITE_SKILL_SHOW_NOTIFY = 453 ,
/**改名请求**/
	RENAME_REQUEST = 454 ,
/**改名应答**/
	RENAME_ANSWER = 455 ,
/**心跳请求**/
	HEARTBEAT_REQUEST = 456 ,
/**心跳应答**/
	HEARTBEAT_ANSWER = 457 ,
/**时装穿戴请求**/
	FASHION_DRESS_REQUEST = 458 ,
/**时装穿戴应答**/
	FASHION_DRESS_ANSWER = 459 ,
/**时装卸下请求**/
	FASHION_UNDRESS_REQUEST = 460 ,
/**时装卸下应答**/
	FASHION_UNDRESS_ANSWER = 461 ,
/**抽卡共享幸运值通知**/
	CHOUKA_SHARE_LUCK_NOTIFY = 462 ,
/**时装强化请求**/
	FASHION_STRENGTHEN_REQUEST = 463 ,
/**时装强化应答**/
	FASHION_STRENGTHEN_ANSWER = 464 ,
/**领取幸运值奖励请求**/
	DRAW_LUCK_PACKAGE_REQUEST = 465 ,
/**领取幸运值奖励回应**/
	DRAW_LUCK_PACKAGE_ANSWER = 466 ,
/**转盘信息通知**/
	TURNTABLE_NOTIFY = 467 ,
/**转盘抽奖请求**/
	TURNTABLE_START_REQUEST = 468 ,
/**转盘抽奖应答**/
	TURNTABLE_START_ANSWER = 469 ,
/**转盘刷新请求**/
	TURNTABLE_REFRESH_REQUEST = 470 ,
/**转盘刷新应答**/
	TURNTABLE_REFRESH_ANSWER = 471 ,
/**转盘抽奖记录请求**/
	TURNTABLE_RECORD_REQUEST = 472 ,
/**转盘抽奖记录应答**/
	TURNTABLE_RECORD_ANSWER = 473 ,
/**转盘活动任务列表请求**/
	TURNTABLE_TASK_LIST_REQUEST = 474 ,
/**转盘活动任务列表应答**/
	TURNTABLE_TASK_LIST_ANSWER = 475 ,
/**转盘活动领取任务奖励请求**/
	TURNTABLE_TASK_REWARD_REQUEST = 476 ,
/**转盘活动领取任务奖励应答**/
	TURNTABLE_TASK_REWARD_ANSWER = 477 ,
/**招财猫信息通知**/
	ZHAOCAIMAO_NOTIFY = 478 ,
/**招财猫抽奖请求**/
	ZHAOCAIMAO_START_REQUEST = 479 ,
/**招财猫抽奖应答**/
	ZHAOCAIMAO_START_ANSWER = 480 ,
/**招财猫抽奖记录请求**/
	ZHAOCAIMAO_RECORD_REQUEST = 481 ,
/**招财猫抽奖记录应答**/
	ZHAOCAIMAO_RECORD_ANSWER = 482 ,
/**招财猫活动任务列表请求**/
	ZHAOCAIMAO_TASK_LIST_REQUEST = 483 ,
/**招财猫活动任务列表应答**/
	ZHAOCAIMAO_TASK_LIST_ANSWER = 484 ,
/**招财猫活动领取任务奖励请求**/
	ZHAOCAIMAO_TASK_REWARD_REQUEST = 485 ,
/**招财猫活动领取任务奖励应答**/
	ZHAOCAIMAO_TASK_REWARD_ANSWER = 486 ,
/**打开界面**/
	OPEN_UI_REPORT = 487 ,
/**跨服积分赛基础信息请求**/
	CS_POINTS_RACE_GET_INFO_REQUEST = 488 ,
/**跨服积分赛基础信息应答**/
	CS_POINTS_RACE_GET_INFO_ANSWER = 489 ,
/**跨服积分赛获取对手列表请求**/
	CS_POINTS_RACE_GET_OPPONENTS_REQUEST = 490 ,
/**跨服积分赛获取对手列表应答**/
	CS_POINTS_RACE_GET_OPPONENTS_ANSWER = 491 ,
/**跨服积分赛挑战请求**/
	CS_POINTS_RACE_FIGHT_REQUEST = 492 ,
/**跨服积分赛挑战应答**/
	CS_POINTS_RACE_FIGHT_ANSWER = 493 ,
/**跨服积分赛复仇请求**/
	CS_POINTS_RACE_REVENGE_REQUEST = 494 ,
/**跨服积分赛复仇应答**/
	CS_POINTS_RACE_REVENGE_ANSWER = 495 ,
/**跨服积分赛预挑战请求**/
	CS_POINTS_RACE_PREPARE_FIGHT_REQUEST = 496 ,
/**跨服积分赛预挑战应答**/
	CS_POINTS_RACE_PREPARE_FIGHT_ANSWER = 497 ,
/**跨服积分赛排行榜请求**/
	CS_POINTS_RACE_RANK_REQUEST = 498 ,
/**跨服积分赛排行榜应答**/
	CS_POINTS_RACE_RANK_ANSWER = 499 ,
/**跨服积分赛防守记录请求**/
	CS_POINTS_RACE_DEFEND_LOG_REQUEST = 500 ,
/**跨服积分赛防守记录应答**/
	CS_POINTS_RACE_DEFEND_LOG_ANSWER = 501 ,
/**跨服积分赛刷新对手请求**/
	CS_POINTS_RACE_REFRESH_REQUEST = 502 ,
/**跨服积分赛刷新对手应答**/
	CS_POINTS_RACE_REFRESH_ANSWER = 503 ,
/**分解豪侠请求**/
	FENJIE_GALLANT_REQUEST = 504 ,
/**分解豪侠应答**/
	FENJIE_GALLANT_ANSWER = 505 ,
/**合成豪侠请求**/
	COMPOSE_GALLANT_REQUEST = 506 ,
/**合成豪侠应答**/
	COMPOSE_GALLANT_ANSWER = 507 ,
/**豪侠传条目信息通知**/
	GALLANT_ENTRY_INFO_NOTIFY = 508 ,
/**豪侠传条目激活请求**/
	GALLANT_ENTRY_ACTIVATE_REQUEST = 509 ,
/**豪侠传条目激活应答**/
	GALLANT_ENTRY_ACTIVATE_ANSWER = 510 ,
/**豪侠传排行榜请求**/
	GALLANT_RANK_REQUEST = 511 ,
/**豪侠传排行榜应答**/
	GALLANT_RANK_ANSWER = 512 ,
/**豪侠传试炼信息请求**/
	GALLANT_RAID_INFO_REQUEST = 513 ,
/**豪侠传试炼信息应答**/
	GALLANT_RAID_INFO_ANSWER = 514 ,
/**豪侠传试炼刷新请求**/
	GALLANT_RAID_REFRESH_REQUEST = 515 ,
/**豪侠传试炼刷新应答**/
	GALLANT_RAID_REFRESH_ANSWER = 516 ,
/**豪侠传试炼挑战请求**/
	GALLANT_RAID_FIGHT_REQUEST = 517 ,
/**豪侠传试炼挑战应答**/
	GALLANT_RAID_FIGHT_ANSWER = 518 ,
/**跨服积分赛购买挑战次数请求**/
	CS_POINTS_RACE_BUYCNT_REQUEST = 519 ,
/**跨服积分赛购买挑战次数应答**/
	CS_POINTS_RACE_BUYCNT_ANSWER = 520 ,
/**限时购买通知**/
	LIMITED_TIME_BUY_NOTIFY = 521 ,
/**限时购买请求**/
	LIMITED_TIME_BUY_REQUEST = 522 ,
/**限时购买应答**/
	LIMITED_TIME_BUY_ANSWER = 523 ,
/**返利信息通知**/
	REBATE_INFO_NOTIFY = 524 ,
/**返利领取请求**/
	REBATE_RECEIVE_REQUEST = 525 ,
/**返利领取应答**/
	REBATE_RECEIVE_ANSWER = 526 ,
/**充值通知**/
	RECHARGE_NOTIFY = 527 ,
/**装备宠物请求**/
	PET_DRESS_REQUEST = 528 ,
/**装备宠物应答**/
	PET_DRESS_ANSWER = 529 ,
/**卸下宠物请求**/
	PET_UNDRESS_REQUEST = 530 ,
/**卸下宠物应答**/
	PET_UNDRESS_ANSWER = 531 ,
/**上阵宠物请求**/
	PET_IN_BATTLE_REQUEST = 532 ,
/**上阵宠物应答**/
	PET_IN_BATTLE_ANSWER = 533 ,
/**下阵宠物请求**/
	PET_OUT_BATTLE_REQUEST = 534 ,
/**下阵宠物应答**/
	PET_OUT_BATTLE_ANSWER = 535 ,
/**宠物升级请求**/
	PET_UPLEVEL_REQUEST = 536 ,
/**宠物升级应答**/
	PET_UPLEVEL_ANSWER = 537 ,
/**宠物升星请求**/
	PET_STAR_UPGRADE_REQUEST = 538 ,
/**宠物升星应答**/
	PET_STAR_UPGRADE_ANSWER = 539 ,
/**宠物神炼请求**/
	PET_REFINE_REQUEST = 540 ,
/**宠物神炼应答**/
	PET_REFINE_ANSWER = 541 ,
/**跨服积分赛信息请求**/
	CS_POINTS_RACE_STATE_REQUEST = 542 ,
/**跨服积分赛信息应答**/
	CS_POINTS_RACE_STATE_ANSWER = 543 ,
/**年兽活动通知**/
	NIAN_EVENT_NOTIFY = 544 ,
/**年兽信息请求**/
	NIAN_INFO_REQUEST = 545 ,
/**年兽信息应答**/
	NIAN_INFO_ANSWER = 546 ,
/**购买礼花请求**/
	NIAN_BUY_FIREWORKS_REQUEST = 547 ,
/**购买礼花应答**/
	NIAN_BUY_FIREWORKS_ANSWER = 548 ,
/**使用礼花请求**/
	NIAN_USE_FIREWORKS_REQUEST = 549 ,
/**使用礼花应答**/
	NIAN_USE_FIREWORKS_ANSWER = 550 ,
/**获取红包请求**/
	NIAN_GET_RED_PACKET_REQUEST = 551 ,
/**获取红包应答**/
	NIAN_GET_RED_PACKET_ANSWER = 552 ,
/**年兽排行榜请求**/
	NIAN_RANK_REQUEST = 553 ,
/**年兽排行榜应答**/
	NIAN_RANK_ANSWER = 554 ,
/**年兽活动任务列表请求**/
	NIAN_TASK_LIST_REQUEST = 555 ,
/**年兽活动任务列表应答**/
	NIAN_TASK_LIST_ANSWER = 556 ,
/**年兽活动领取任务奖励请求**/
	NIAN_TASK_REWARD_REQUEST = 557 ,
/**年兽活动领取任务奖励应答**/
	NIAN_TASK_REWARD_ANSWER = 558 ,
/**年兽活动排行榜前几名变化通知**/
	NIAN_TOP_RANK_CHANGED_NOTIFY = 559 ,
/**巅峰之路成就列表请求**/
	ACHIEVEMENT_TASK_LIST_REQUEST = 560 ,
/**巅峰之路成就列表应答**/
	ACHIEVEMENT_TASK_LIST_ANSWER = 561 ,
/**巅峰之路领取奖励请求**/
	ACHIEVEMENT_TASK_REWARD_REQUEST = 562 ,
/**巅峰之路领取奖励应答**/
	ACHIEVEMENT_TASK_REWARD_ANSWER = 563 ,
/**巅峰之路一键领取奖励请求**/
	ACHIEVEMENT_ONE_KEY_REWARD_REQUEST = 564 ,
/**巅峰之路一键领取奖励应答**/
	ACHIEVEMENT_ONE_KEY_REWARD_ANSWER = 565 ,
/**巅峰之路新任务完成通知**/
	ACHIEVEMENT_NEW_TASK_COMPLETE_NOTIFY = 566 ,
/**公告通知**/
	ANNOUNCEMENT_NOTIFY = 567 ,
/**福袋通知**/
	BLESSING_BAG_NOTIFY = 568 ,
/**登录公告通知**/
	ENTER_GAME_GUIDE_NOTIFY = 569 ,
/**元宝购买月卡请求**/
	BUY_MONTH_CARD_REQUEST = 570 ,
/**元宝购买月卡应答**/
	BUY_MONTH_CARD_ANSWER = 571 ,
/**宠物副本信息请求**/
	PET_RAID_INFO_REQUEST = 572 ,
/**宠物副本信息应答**/
	PET_RAID_INFO_ANSWER = 573 ,
/**宠物副本布阵请求**/
	PET_RAID_DEPLOY_REQUEST = 574 ,
/**宠物副本布阵应答**/
	PET_RAID_DEPLOY_ANSWER = 575 ,
/**宠物副本挑战请求**/
	PET_RAID_FIGHT_REQUEST = 576 ,
/**宠物副本挑战应答**/
	PET_RAID_FIGHT_ANSWER = 577 ,
/**宠物副本宝箱通知**/
	PET_RAID_BOX_NOTIFY = 578 ,
/**宠物副本重置请求**/
	PET_RAID_RESET_REQUEST = 579 ,
/**宠物副本重置应答**/
	PET_RAID_RESET_ANSWER = 580 ,
/**宠物副本一键通关请求**/
	PET_RAID_ONE_KEY_PASS_REQUEST = 581 ,
/**宠物副本一键通关应答**/
	PET_RAID_ONE_KEY_PASS_ANSWER = 582 ,
/**宠物副本通关数排行请求**/
	PET_RAID_PASS_COUNT_RANK_REQUEST = 583 ,
/**宠物副本通关数排行应答**/
	PET_RAID_PASS_COUNT_RANK_ANSWER = 584 ,
/**模块订阅请求**/
	MODULE_SUBSCRIBE_REQUEST = 585 ,
/**放河灯请求**/
	CS_RIVER_LANTERN_FLOAT_REQUEST = 586 ,
/**放河灯应答**/
	CS_RIVER_LANTERN_FLOAT_ANSWER = 587 ,
/**河灯活动信息请求**/
	CS_RIVER_LANTERN_INFO_REQUEST = 588 ,
/**河灯活动信息应答**/
	CS_RIVER_LANTERN_INFO_ANSWER = 589 ,
/**新河灯通知**/
	CS_RIVER_LANTERN_NEW_FLOAT_NOTIFY = 590 ,
/**新河灯排行榜通知**/
	CS_RIVER_LANTERN_NEW_RANK_NOTIFY = 591 ,
/**河灯自己排名变化通知**/
	CS_RIVER_LANTERN_SELF_RANK_UPDATE_NOTIFY = 592 ,
/**河灯他人获得物品通知**/
	CS_RIVER_LANTERN_OTHERS_GET_ITEM_NOTIFY = 593 ,
/**团购信息请求**/
	CS_GROUPON_INFO_REQUEST = 594 ,
/**团购信息应答**/
	CS_GROUPON_INFO_ANSWER = 595 ,
/**团购更新剩余次数**/
	CS_GROUPON_COUNT_UPDATE_NOTIFY = 596 ,
};
#endif