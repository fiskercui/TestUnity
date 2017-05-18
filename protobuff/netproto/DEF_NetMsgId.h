#ifndef DEF_NETMSGID_H
#define DEF_NETMSGID_H
/**��Ϣ�Ŷ���**/
enum DEF_NetMsgId {
/**��¼����**/
	LOGIN_REQUEST = 1 ,
/**��¼Ӧ��**/
	LOGIN_ANSWER = 2 ,
/**������ɫ����**/
	CREATE_ROLE_REQUEST = 3 ,
/**������ɫӦ��**/
	CREATE_ROLE_ANSWER = 4 ,
/**������Ϸ����**/
	ENTER_GAME_REQUEST = 5 ,
/**������ϷӦ��**/
	ENTER_GAME_ANSWER = 6 ,
/**�ʺű���**/
	LOGIN_AGAIN_NOTIFY = 7 ,
/**��ȡ���Ƶ���������**/
	GET_CARD_ATTR_REQUEST = 8 ,
/**��ȡ���Ƶ�����Ӧ��**/
	GET_CARD_ATTR_ANSWER = 9 ,
/**�˳���Ϸ����**/
	EXIT_GAME_REQUEST = 10 ,
/**�˳���ϷӦ��**/
	EXIT_GAME_ANSWER = 11 ,
/**��ȡ��ɫ����������**/
	GET_PLAYER_ATTR_REQUEST = 12 ,
/**��ȡ��ɫ������Ӧ��**/
	GET_PLAYER_ATTR_ANSWER = 13 ,
/**�оٱ�������**/
	LIST_BAG_REQUEST = 14 ,
/**�оٱ���Ӧ��**/
	LIST_BAG_ANSWER = 15 ,
/**GM������Ʒ����**/
	GM_CMD_REQUEST = 16 ,
/**GM������ƷӦ��**/
	GM_CMD_ANSWER = 17 ,
/**�佫��������**/
	HERO_UPGRADE_LEVEL_REQUEST = 18 ,
/**�佫����Ӧ��**/
	HERO_UPGRADE_LEVEL_ANSWER = 19 ,
/**�佫ͻ������**/
	HERO_OVERSTEP_REQUEST = 20 ,
/**�佫ͻ��Ӧ��**/
	HERO_OVERSTEP_ANSWER = 21 ,
/**�佫��������**/
	HERO_PLAY_REQUEST = 22 ,
/**�佫����Ӧ��**/
	HERO_PLAY_ANSWER = 23 ,
/**�佫��������**/
	HERO_CHEER_REQUEST = 24 ,
/**�佫����Ӧ��**/
	HERO_CHEER_ANSWER = 25 ,
/**�佫��������**/
	HERO_EMBATTLE_REQUEST = 26 ,
/**�佫����Ӧ��**/
	HERO_EMBATTLE_ANSWER = 27 ,
/**װ��ǿ������**/
	EQUIP_STRENGTHEN_REQUEST = 28 ,
/**װ��ǿ��Ӧ��**/
	EQUIP_STRENGTHEN_ANSWER = 29 ,
/**װ����������**/
	EQUIP_UPGRADE_STAR_REQUEST = 30 ,
/**װ������Ӧ��**/
	EQUIP_UPGRADE_STAR_ANSWER = 31 ,
/**װ����������**/
	EQUIP_REFINING_REQUEST = 32 ,
/**װ������Ӧ��**/
	EQUIP_REFINING_ANSWER = 33 ,
/**��װ������**/
	EQUIP_DRESS_REQUEST = 34 ,
/**��װ��Ӧ��**/
	EQUIP_DRESS_ANSWER = 35 ,
/**��װ������**/
	EQUIP_UNDRESS_REQUEST = 36 ,
/**��װ��Ӧ��**/
	EQUIP_UNDRESS_ANSWER = 37 ,
/**������ʼ����**/
	RAID_START_REQUEST = 38 ,
/**������ʼӦ��**/
	RAID_START_ANSWER = 39 ,
/**ʹ����Ʒ����**/
	USEITEM_REQUEST = 40 ,
/**ʹ����ƷӦ��**/
	USEITEM_ANSWER = 41 ,
/**������¼����**/
	RAID_RECORD_REQUEST = 42 ,
/**������¼Ӧ��**/
	RAID_RECORD_ANSWER = 43 ,
/**�������佱������**/
	RAID_REWARD_REQUEST = 44 ,
/**�������佱��Ӧ��**/
	RAID_REWARD_ANSWER = 45 ,
/**�佫��������**/
	HERO_UPGRADE_DESTINY_REQUEST = 46 ,
/**�佫����Ӧ��**/
	HERO_UPGRADE_DESTINY_ANSWER = 47 ,
/**�佫��������**/
	HERO_CULTURE_REQUEST = 48 ,
/**�佫����Ӧ��**/
	HERO_CULTURE_ANSWER = 49 ,
/**�佫�����滻����**/
	HERO_CULTURE_REPLACE_REQUEST = 50 ,
/**�佫�����滻Ӧ��**/
	HERO_CULTURE_REPLACE_ANSWER = 51 ,
/**�佫��������**/
	HERO_UPGRADE_AWAKEN_REQUEST = 52 ,
/**�佫����Ӧ��**/
	HERO_UPGRADE_AWAKEN_ANSWER = 53 ,
/**�佫��������װ������**/
	HERO_INSTALL_AWAKEN_EQUIP_REQUEST = 54 ,
/**�佫��������װ��Ӧ��**/
	HERO_INSTALL_AWAKEN_EQUIP_ANSWER = 55 ,
/**�佫����װ���ϳ�����**/
	HERO_AWAKEN_EQUIP_COMPOSE_REQUEST = 56 ,
/**�佫��������װ��Ӧ��**/
	HERO_AWAKEN_EQUIP_COMPOSE_ANSWER = 57 ,
/**��ȡ��������ɫ�б�����**/
	ARENA_GET_PLAYER_REQUEST = 58 ,
/**��ȡ��������ɫ�б�Ӧ��**/
	ARENA_GET_PLAYER_ANSWER = 59 ,
/**��������ʼ����**/
	ARENA_START_REQUEST = 60 ,
/**��������ʼӦ��**/
	ARENA_START_ANSWER = 61 ,
/**��������������**/
	ARENA_FLOP_REQUEST = 62 ,
/**����������Ӧ��**/
	ARENA_FLOP_ANSWER = 63 ,
/**�������̵�����**/
	ARENA_SHOP_REQUEST = 64 ,
/**�������̵�Ӧ��**/
	ARENA_SHOP_ANSWER = 65 ,
/**�������̵깺������**/
	ARENA_SHOP_BUY_REQUEST = 66 ,
/**�������̵깺��Ӧ��**/
	ARENA_SHOP_BUY_ANSWER = 67 ,
/**�ֽ�����**/
	FENJIE_REQUEST = 68 ,
/**�ֽ��Ӧ**/
	FENJIE_ANSWER = 69 ,
/**�����ʼ�����**/
	MAIL_INSERT_REQUEST = 70 ,
/**�����ʼ�Ӧ��**/
	MAIL_INSERT_ANSWER = 71 ,
/**�б��ʼ�����**/
	MAIL_LIST_REQUEST = 72 ,
/**�б��ʼ���Ӧ**/
	MAIL_LIST_ANSWER = 73 ,
/**��ȡ�ʼ������б�**/
	MAIL_GET_ITEM_REQUEST = 74 ,
/**��ȡ�ʼ�������Ӧ**/
	MAIL_GET_ITEM_ANSWER = 75 ,
/**���ʼ�֪ͨ**/
	MAIL_NEW_NOTIFY = 76 ,
/**�ʼ�ɾ������**/
	MAIL_DEL_REQUEST = 77 ,
/**�ʼ�ɾ��Ӧ��**/
	MAIL_DEL_ANSWER = 78 ,
/**�ʼ���ȡ����**/
	MAIL_READER_REQUEST = 79 ,
/**��Ƭ�ϲ�����**/
	CHIP_MERGE_REQUEST = 80 ,
/**��Ƭ�ϲ�Ӧ��**/
	CHIP_MERGE_ANSWER = 81 ,
/**һ��װ������װ������**/
	AUTO_INSTALL_AWAKEN_REQUEST = 82 ,
/**һ��װ������װ��Ӧ��**/
	AUTO_INSTALL_AWAKEN_ANSWER = 83 ,
/**������Ϣ����**/
	TOWER_LADDER_INFO_REQUEST = 84 ,
/**������ϢӦ��**/
	TOWER_LADDER_INFO_ANSWER = 85 ,
/**������������**/
	TOWER_LADDER_RESET_REQUEST = 86 ,
/**��������Ӧ��**/
	TOWER_LADDER_RESET_ANSWER = 87 ,
/**����ѡ����������**/
	TOWER_LADDER_ATTR_REQUEST = 88 ,
/**����ѡ������Ӧ��**/
	TOWER_LADDER_ATTR_ANSWER = 89 ,
/**������ʼ��������**/
	TOWER_LADDER_START_REQUEST = 90 ,
/**������ʼ����Ӧ��**/
	TOWER_LADDER_START_ANSWER = 91 ,
/**������ʼ��Ӣ��������**/
	TOWER_LADDER_ELITE_REQUEST = 92 ,
/**������ʼ��Ӣ����Ӧ��**/
	TOWER_LADDER_ELITE_ANSWER = 93 ,
/**������������**/
	TOWER_LADDER_RANK_REQUEST = 94 ,
/**��������Ӧ��**/
	TOWER_LADDER_RANK_ANSWER = 95 ,
/**��������Ӣ��������**/
	TOWER_BUY_ELITE_REQUEST = 96 ,
/**��������Ӣ����Ӧ��**/
	TOWER_BUY_ELITE_ANSWER = 97 ,
/**���������Ƽ���������**/
	TOWER_BUY_PROP_REQUEST = 98 ,
/**���������Ƽ�����Ӧ��**/
	TOWER_BUY_PROP_ANSWER = 99 ,
/**��ͥ����**/
	HUANGTING_REQUEST = 100 ,
/**��ͥӦ��**/
	HUANGTING_ANSWER = 101 ,
/**�佫��������**/
	HERO_UNPLAY_REQUEST = 102 ,
/**�佫����Ӧ��**/
	HERO_UNPLAY_ANSWER = 103 ,
/**������ɫ����**/
	FRIEND_NEAR_REQUEST = 104 ,
/**������ɫӦ��**/
	FRIEND_NEAR_ANSWER = 105 ,
/**��ս��������**/
	FRIEND_DEKARON_REQUEST = 106 ,
/**��ս����Ӧ��**/
	FRIEND_DEKARON_ANSWER = 107 ,
/**�鿨����**/
	CHOUKA_REQUEST = 108 ,
/**�鿨����Ӧ��**/
	CHOUKA_ANSWER = 109 ,
/**��ȡ��ɫ��Ϣ����**/
	GET_PLAYER_INFO_REQUEST = 110 ,
/**��ȡ��ɫ��ϢӦ��**/
	GET_PLAYER_INFO_ANSWER = 111 ,
/**����ɨ������**/
	MAIN_RAID_SWEEP_REQUEST = 112 ,
/**����ɨ��Ӧ��**/
	MAIN_RAID_SWEEP_ANSWER = 113 ,
/**�о��б�����**/
	REBEL_LIST_REQUEST = 114 ,
/**�о��б�Ӧ��**/
	REBEL_LIST_ANSWER = 115 ,
/**�о������ߺ�������**/
	REBEL_SHARE_REQUEST = 116 ,
/**�о������ߺ���Ӧ��**/
	REBEL_SHARE_ANSWER = 117 ,
/**�о�������ʼ����**/
	REBEL_RAID_START_REQUEST = 118 ,
/**�о�������ʼӦ��**/
	REBEL_RAID_START_ANSWER = 119 ,
/**�о�BOSS��ѫ���а�����**/
	REBEL_BOSS_CREDIT_RANK_REQUEST = 120 ,
/**�о�BOSS��ѫ���а�Ӧ��**/
	REBEL_BOSS_CREDIT_RANK_ANSWER = 121 ,
/**�о��˺����а�����**/
	REBEL_HURT_RANK_REQUEST = 122 ,
/**�о��˺����а�Ӧ��**/
	REBEL_HURT_RANK_ANSWER = 123 ,
/**���̵�����**/
	SHENJIANG_SHOP_REQUEST = 124 ,
/**���̵깺������**/
	SHENJIANG_SHOP_BUY_REQUEST = 125 ,
/**���̵�Ӧ��**/
	SHENJIANG_SHOP_ANSWER = 126 ,
/**�淨�̵�����**/
	SHOP_PLAY_INFO_REQUEST = 127 ,
/**�淨�̵�Ӧ��**/
	SHOP_PLAY_ANSWER = 128 ,
/**�淨�̵깺������**/
	SHOP_PLAY_BUY_REQUEST = 129 ,
/**�淨�̵깺��Ӧ��**/
	SHOP_PLAY_BUY_ANSWER = 130 ,
/**�о���ѫ��������**/
	REBEL_EXPLOIT_REWARD_REQUEST = 131 ,
/**�о���ѫ����Ӧ��**/
	REBEL_EXPLOIT_REWARD_ANSWER = 132 ,
/**����������**/
	TREASURE_DRESS_REQUEST = 133 ,
/**������Ӧ��**/
	TREASURE_DRESS_ANSWER = 134 ,
/**�ѱ�������**/
	TREASURE_UNDRESS_REQUEST = 135 ,
/**�ѱ���Ӧ��**/
	TREASURE_UNDRESS_ANSWER = 136 ,
/**����ǿ������**/
	TREASURE_STRENGTHEN_REQUEST = 137 ,
/**����ǿ��Ӧ��**/
	TREASURE_STRENGTHEN_ANSWER = 138 ,
/**���ﾫ������**/
	TREASURE_REFINING_REQUEST = 139 ,
/**���ﾫ��Ӧ��**/
	TREASURE_REFINING_ANSWER = 140 ,
/**������������**/
	TREASURE_FORGE_REQUEST = 141 ,
/**��������Ӧ��**/
	TREASURE_FORGE_ANSWER = 142 ,
/**�о�BOSS�б�����**/
	REBEL_BOSS_LIST_REQUEST = 143 ,
/**�о�BOSS�б�Ӧ��**/
	REBEL_BOSS_LIST_ANSWER = 144 ,
/**�о�BOSS������ʼ����**/
	REBEL_BOSS_START_REQUEST = 145 ,
/**�о�BOSS������ʼӦ��**/
	REBEL_BOSS_START_ANSWER = 146 ,
/**�о�BOSS�˺����а�����**/
	REBEL_BOSS_HURT_RANK_REQUEST = 147 ,
/**�о�BOSS�˺����а�Ӧ��**/
	REBEL_BOSS_HURT_RANK_ANSWER = 148 ,
/**ÿ���о���ѫ���а�����**/
	REBEL_CREDIT_DAILY_RANK_REQUEST = 149 ,
/**ÿ���о���ѫ���а�Ӧ��**/
	REBEL_CREDIT_DAILY_RANK_ANSWER = 150 ,
/**ÿ���о��˺����а�����**/
	REBEL_HURT_DAILY_RANK_REQUEST = 151 ,
/**ÿ���о��˺����а�Ӧ��**/
	REBEL_HURT_DAILY_RANK_ANSWER = 152 ,
/**��֬�б�����**/
	BLUSHER_LIST_REQUEST = 153 ,
/**��֬�б�Ӧ��**/
	BLUSHER_LIST_ANSWER = 154 ,
/**��֬ȡ������**/
	BLUSHER_WOO_REQUEST = 155 ,
/**��֬ȡ��Ӧ��**/
	BLUSHER_WOO_ANSWER = 156 ,
/**��֬��������**/
	BLUSHER_ADMIRE_REQUEST = 157 ,
/**��֬����Ӧ��**/
	BLUSHER_ADMIRE_ANSWER = 158 ,
/**��֬��ȡ������������**/
	BLUSHER_UPLV_REWARD_REQUEST = 159 ,
/**��֬��ȡ��������Ӧ��**/
	BLUSHER_UPLV_REWARD_ANSWER = 160 ,
/**��֬��ȡ������������**/
	BLUSHER_LUCK_REWARD_REQUEST = 161 ,
/**��֬��ȡ��������Ӧ��**/
	BLUSHER_LUCK_REWARD_ANSWER = 162 ,
/**��֬��������**/
	BLUSHER_RANK_REQUEST = 163 ,
/**��֬����Ӧ��**/
	BLUSHER_RANK_ANSWER = 164 ,
/**������ǰ30����������**/
	ARENA_RANK_REQUEST = 165 ,
/**������ǰ30������Ӧ��**/
	ARENA_RANK_ANSWER = 166 ,
/**������������**/
	CHAT_SEND_REQUEST = 167 ,
/**��������Ӧ��**/
	CHAT_SEND_ANSWER = 168 ,
/**������Ϣ֪ͨ**/
	CHAT_MSG_NOTIFY = 169 ,
/**�㲥��Ϣ֪ͨ**/
	BROADCAST_NOTIFY = 170 ,
/**�Իƹ�����**/
	EAT_CUCUMBER_REQUEST = 171 ,
/**�Իƹ�Ӧ��**/
	EAT_CUCUMBER_ANSWER = 172 ,
/**�ճ������б�**/
	TASK_DAILY_LIST_REQUEST = 173 ,
/**�ճ�����Ӧ��**/
	TASK_DAILY_LIST_ANSWER = 174 ,
/**�ճ������ȡ�����б�**/
	TASK_DAILY_GET_REWARD_REQUEST = 175 ,
/**�ճ������ȡ����Ӧ��**/
	TASK_DAILY_GET_REWARD_ANSWER = 176 ,
/**�ճ������佱������**/
	TASK_DAILY_BOX_REWARD_REQUEST = 177 ,
/**�ճ������佱��Ӧ��**/
	TASK_DAILY_BOX_REWARD_ANSWER = 178 ,
/**���������б�**/
	TASK_SEVEN_LIST_REQUEST = 179 ,
/**��������Ӧ��**/
	TASK_SEVEN_LIST_ANSWER = 180 ,
/**���������ȡ�����б�**/
	TASK_SEVEN_GET_REWARD_REQUEST = 181 ,
/**���������ȡ����Ӧ��**/
	TASK_SEVEN_GET_REWARD_ANSWER = 182 ,
/**���հ�۹�������**/
	TASK_SEVEN_BUY_REWARD_REQUEST = 183 ,
/**���հ�۹���Ӧ��**/
	TASK_SEVEN_BUY_REWARD_ANSWER = 184 ,
/**�ɾ������б�**/
	TASK_VOSTRO_LIST_REQUEST = 185 ,
/**�ɾ�����Ӧ��**/
	TASK_VOSTRO_LIST_ANSWER = 186 ,
/**�ɾ������ȡ�����б�**/
	TASK_VOSTRO_GET_REWARD_REQUEST = 187 ,
/**�ɾ������ȡ����Ӧ��**/
	TASK_VOSTRO_GET_REWARD_ANSWER = 188 ,
/**ǩ������**/
	SIGN_REQUEST = 189 ,
/**ǩ��Ӧ��**/
	SIGN_ANSWER = 190 ,
/**ҡǮ������**/
	MONEY_TREE_REQUEST = 191 ,
/**ҡǮ��Ӧ��**/
	MONEY_TREE_ANSWER = 192 ,
/**��б�����**/
	ACTIVITY_LIST_REQUEST = 193 ,
/**��б�Ӧ��**/
	ACTIVITY_LIST_ANSWER = 194 ,
/**���ȡ��������**/
	ACTIVITY_REWARD_REQUEST = 195 ,
/**���ȡ����Ӧ��**/
	ACTIVITY_REWARD_ANSWER = 196 ,
/**��������֪ͨ**/
	LEVEL_UP_NOTIFY = 197 ,
/**���а�����**/
	COMMON_RANK_REQUEST = 198 ,
/**���а�Ӧ��**/
	COMMON_RANK_ANSWER = 199 ,
/**���а��������**/
	COMMON_RANK_LIKE_REQUEST = 200 ,
/**���а����Ӧ��**/
	COMMON_RANK_LIKE_ANSWER = 201 ,
/**�鿴�������**/
	VIEW_PLAYER_REQUEST = 202 ,
/**�鿴���Ӧ��**/
	VIEW_PLAYER_ANSWER = 203 ,
/**�д�����**/
	QIECUO_START_REQUEST = 204 ,
/**�д迪ʼ����(���з�-��Ϸ��)**/
	QIECUO_START_SERVER_REQUEST = 205 ,
/**�д�Ӧ��**/
	QIECUO_START_ANSWER = 206 ,
/**���ջ��Ƭ��������**/
	TASK_SEVEN_CHIP_REWARD_REQUEST = 207 ,
/**���ջ��Ƭ����Ӧ��**/
	TASK_SEVEN_CHIP_REWARD_ANSWER = 208 ,
/**�����б�����**/
	FRIEND_LIST_REQUEST = 209 ,
/**�����б�Ӧ��**/
	FRIEND_LIST_ANSWER = 210 ,
/**������������**/
	FRIEND_APPLY_ADD_REQUEST = 211 ,
/**��������Ӧ��**/
	FRIEND_APPLY_ADD_ANSWER = 212 ,
/**��������ͬ������**/
	FRIEND_AGREE_REQUEST = 213 ,
/**��������ͬ��Ӧ��**/
	FRIEND_AGREE_ANSWER = 214 ,
/**��������ܾ�����**/
	FRIEND_REFUSE_REQUEST = 215 ,
/**��������ܾ�Ӧ��**/
	FRIEND_REFUSE_ANSWER = 216 ,
/**ɾ����������**/
	FRIEND_DEL_REQUEST = 217 ,
/**ɾ������Ӧ��**/
	FRIEND_DEL_ANSWER = 218 ,
/**���;�������**/
	FRIEND_SEND_ENERGY_REQUEST = 219 ,
/**���;���Ӧ��**/
	FRIEND_SEND_ENERGY_ANSWER = 220 ,
/**���ܾ�������**/
	FRIEND_RECV_ENERGY_REQUEST = 221 ,
/**���ܾ���Ӧ��**/
	FRIEND_RECV_ENERGY_ANSWER = 222 ,
/**���������б�����**/
	FRIEND_APPLY_LIST_REQUEST = 223 ,
/**���������б�Ӧ��**/
	FRIEND_APPLY_LIST_ANSWER = 224 ,
/**�����Ƽ�����**/
	FRIEND_RECOMMEND_REQUEST = 225 ,
/**�����Ƽ�Ӧ��**/
	FRIEND_RECOMMEND_ANSWER = 226 ,
/**һ��װ��ǿ������**/
	EQUIP_AUTO_STRENGTHEN_REQUEST = 227 ,
/**һ��װ��ǿ��Ӧ��**/
	EQUIP_AUTO_STRENGTHEN_ANSWER = 228 ,
/**���ú��Ѻ���������**/
	FRIEND_BLACKLIST_REQUEST = 229 ,
/**���ú��Ѻ�����Ӧ��**/
	FRIEND_BLACKLIST_ANSWER = 230 ,
/**ȡ�����Ѻ���������**/
	FRIEND_CANCEL_BLACKLIST_REQUEST = 231 ,
/**ȡ�����Ѻ�����Ӧ��**/
	FRIEND_CANCEL_BLACKLIST_ANSWER = 232 ,
/**�������б�����**/
	BLACK_LIST_REQUEST = 233 ,
/**�������б�Ӧ��**/
	BLACK_LIST_ANSWER = 234 ,
/**�����������Ӻ�������**/
	FRIEND_ADD_BY_NAME_REQUEST = 235 ,
/**�����ʼ�����**/
	MAIL_SEND_REQUEST = 236 ,
/**�����ʼ�Ӧ��**/
	MAIL_SEND_ANSWER = 237 ,
/**�ύ��������**/
	GUILD_COMMIT_REQUEST = 238 ,
/**ʹ�öһ�����**/
	USE_CDK_ANSWER = 239 ,
/**���������佫**/
	INC_HOER_NOTIFY = 240 ,
/**�佫��������**/
	HERO_SELL_REQUEST = 241 ,
/**�佫����Ӧ��**/
	HERO_SELL_ANSWER = 242 ,
/**װ����������**/
	EQUIP_SELL_REQUEST = 243 ,
/**װ������Ӧ��**/
	EQUIP_SELL_ANSWER = 244 ,
/**�����������**/
	TREASURE_SELL_REQUEST = 245 ,
/**�������Ӧ��**/
	TREASURE_SELL_ANSWER = 246 ,
/**������Ƭ����**/
	SELL_CHIP_REQUEST = 247 ,
/**������ƬӦ��**/
	SELL_CHIP_ANSWER = 248 ,
/**��֬���̵깺������**/
	BLUSHER_SHOP_BUY_REQUEST = 249 ,
/**��֬���̵깺��Ӧ��**/
	BLUSHER_SHOP_BUY_ANSWER = 250 ,
/**������������**/
	RAID_RESET_REQUEST = 251 ,
/**��������Ӧ��**/
	RAID_RESET_ANSWER = 252 ,
/**�о��˺����а�Ӧ��**/
	REBEL_SHARE_FLAG_NOTIFY = 253 ,
/**���Ѿ�֪ͨ**/
	REBEL_CREATE_FLAG_NOTIFY = 254 ,
/**���⽱��֪ͨ**/
	SPECIAL_AWARD_NOTIFY = 255 ,
/**���ɴ�������**/
	LEGION_CREATE_REQUEST = 256 ,
/**���ɴ���Ӧ��**/
	LEGION_CREATE_ANSWER = 257 ,
/**���ɽ�ɢ����**/
	LEGION_DELETE_REQUEST = 258 ,
/**���ɽ�ɢӦ��**/
	LEGION_DELETE_ANSWER = 259 ,
/**������Ϣ����**/
	LEGION_INFO_REQUEST = 260 ,
/**������ϢӦ��**/
	LEGION_INFO_ANSWER = 261 ,
/**���ɳ�Ա�б�����**/
	LEGION_MEMBER_LIST_REQUEST = 262 ,
/**���ɳ�Ա�б�Ӧ��**/
	LEGION_MEMBER_LIST_ANSWER = 263 ,
/**���ɶ�̬����**/
	LEGION_EVENT_REQUEST = 264 ,
/**���ɶ�̬Ӧ��**/
	LEGION_EVENT_ANSWER = 265 ,
/**�����б�����**/
	LEGION_LIST_REQUEST = 266 ,
/**�����б�Ӧ��**/
	LEGION_LIST_ANSWER = 267 ,
/**���������������**/
	LEGION_APPLY_REQUEST = 268 ,
/**�����������Ӧ��**/
	LEGION_APPLY_ANSWER = 269 ,
/**���ɳ�����������**/
	LEGION_CANCEL_APPLY_REQUEST = 270 ,
/**���ɳ�������Ӧ��**/
	LEGION_CANCEL_APPLY_ANSWER = 271 ,
/**���������б�����**/
	LEGION_APPLY_LIST_REQUEST = 272 ,
/**���������б�Ӧ��**/
	LEGION_APPLY_LIST_ANSWER = 273 ,
/**���ɽ��������������**/
	LEGION_ACCEPT_APPLY_REQUEST = 274 ,
/**���ɽ����������Ӧ��**/
	LEGION_ACCEPT_APPLY_ANSWER = 275 ,
/**���ɾܾ������������**/
	LEGION_REFUSE_APPLY_REQUEST = 276 ,
/**���ɾܾ��������Ӧ��**/
	LEGION_REFUSE_APPLY_ANSWER = 277 ,
/**������������������**/
	LEGION_APPOINT_REQUEST = 278 ,
/**��������������Ӧ��**/
	LEGION_APPOINT_ANSWER = 279 ,
/**���ɰ��⸱��������**/
	LEGION_DISMISS_REQUEST = 280 ,
/**���ɰ��⸱����Ӧ��**/
	LEGION_DISMISS_ANSWER = 281 ,
/**�����ƽ���������**/
	LEGION_TRANSFER_REQUEST = 282 ,
/**�����ƽ�����Ӧ��**/
	LEGION_TRANSFER_ANSWER = 283 ,
/**�����߳�����**/
	LEGION_MEMBER_DEL_REQUEST = 284 ,
/**�����߳�Ӧ��**/
	LEGION_MEMBER_DEL_ANSWER = 285 ,
/**�����˳�����**/
	LEGION_QUIT_REQUEST = 286 ,
/**�����˳�Ӧ��**/
	LEGION_QUIT_ANSWER = 287 ,
/**���ɵ�������**/
	LEGION_IMPEACH_REQUEST = 288 ,
/**���ɵ���Ӧ��**/
	LEGION_IMPEACH_ANSWER = 289 ,
/**���ɱ�־�޸�����**/
	LEGION_CHANGE_LOGO_REQUEST = 290 ,
/**���ɱ�־�޸�Ӧ��**/
	LEGION_CHANGE_LOGO_ANSWER = 291 ,
/**�������԰�����**/
	LEGION_MESSAGE_REQUEST = 292 ,
/**�������԰�Ӧ��**/
	LEGION_MESSAGE_ANSWER = 293 ,
/**������������**/
	LEGION_SEND_MESSAGE_REQUEST = 294 ,
/**��������Ӧ��**/
	LEGION_SEND_MESSAGE_ANSWER = 295 ,
/**�����ö���������**/
	LEGION_STICKY_MESSAGE_REQUEST = 296 ,
/**�����ö�����Ӧ��**/
	LEGION_STICKY_MESSAGE_ANSWER = 297 ,
/**���ɼ�������**/
	LEGION_WORSHIP_REQUEST = 298 ,
/**���ɼ���Ӧ��**/
	LEGION_WORSHIP_ANSWER = 299 ,
/**��ȡVIPÿ�ո�������**/
	DRAW_VIP_WELFARE_REQUEST = 300 ,
/**��ȡVIPÿ�ո���Ӧ��**/
	DRAW_VIP_WELFARE_ANSWER = 301 ,
/**���ɼ��쿪��������**/
	LEGION_WORSHIP_OPEN_BOX_REQUEST = 302 ,
/**���ɼ��쿪����Ӧ��**/
	LEGION_WORSHIP_OPEN_BOX_ANSWER = 303 ,
/**������ʱ�̵���Ϣ����**/
	LEGION_LIMIT_SHOP_INFO_REQUEST = 304 ,
/**������ʱ�̵���ϢӦ��**/
	LEGION_LIMIT_SHOP_INFO_ANSWER = 305 ,
/**������ʱ�̵깺������**/
	LEGION_LIMIT_SHOP_BUY_REQUEST = 306 ,
/**������ʱ�̵깺��Ӧ��**/
	LEGION_LIMIT_SHOP_BUY_ANSWER = 307 ,
/**���ɼ�����Ϣ����**/
	LEGION_SKILL_INFO_REQUEST = 308 ,
/**���ɼ�����ϢӦ��**/
	LEGION_SKILL_INFO_ANSWER = 309 ,
/**���ɼ�����������**/
	LEGION_SKILL_UPLEVEL_REQUEST = 310 ,
/**���ɼ�������Ӧ��**/
	LEGION_SKILL_UPLEVEL_ANSWER = 311 ,
/**���ɼ��������ȼ���������**/
	LEGION_SKILL_UPLIMIT_REQUEST = 312 ,
/**���ɼ��������ȼ�����Ӧ��**/
	LEGION_SKILL_UPLIMIT_ANSWER = 313 ,
/**�������л��Ϣ����**/
	OPENSRV_RANK_ACTIVITY_REQUEST = 314 ,
/**�������л��Ϣ**/
	OPENSRV_RANK_ACTIVITY_ANSWER = 315 ,
/**�������л��ȡ��������**/
	OPENSRV_RANK_DRAW_AWARD_REQUEST = 316 ,
/**�������л��ȡ����Ӧ��**/
	OPENSRV_RANK_DRAW_AWARD_ANSWER = 317 ,
/**����ȡ���ö���������**/
	LEGION_CANCEL_STICKY_MESSAGE_REQUEST = 318 ,
/**����ȡ���ö�����Ӧ��**/
	LEGION_CANCEL_STICKY_MESSAGE_ANSWER = 319 ,
/**vip�������Ϣ����**/
	VIP_WEEK_PACKAGE_INFO_REQUEST = 320 ,
/**vip�������ϢӦ��**/
	VIP_WEEK_PACKAGE_INFO_ANSWER = 321 ,
/**vip����������**/
	VIP_WEEK_PACKAGE_BUY_REQUEST = 322 ,
/**vip������Ӧ��**/
	VIP_WEEK_PACKAGE_BUY_ANSWER = 323 ,
/**�������а�����**/
	LEGION_RANK_REQUEST = 324 ,
/**�������а�Ӧ��**/
	LEGION_RANK_ANSWER = 325 ,
/**������ս��������**/
	TOWER_LADDER_START_FLOOR_REQUEST = 326 ,
/**������ս����Ӧ��**/
	TOWER_LADDER_START_FLOOR_ANSWER = 327 ,
/**�����޸���������**/
	LEGION_CHANGE_DECLARATION_REQUEST = 328 ,
/**�����޸�����Ӧ��**/
	LEGION_CHANGE_DECLARATION_ANSWER = 329 ,
/**�����޸Ĺ�������**/
	LEGION_CHANGE_BULLETIN_REQUEST = 330 ,
/**�����޸Ĺ���Ӧ��**/
	LEGION_CHANGE_BULLETIN_ANSWER = 331 ,
/**����ɨ������**/
	TOWER_LADDER_SWEEP_REQUEST = 332 ,
/**����ɨ��Ӧ��**/
	TOWER_LADDER_SWEEP_ANSWER = 333 ,
/**����������ս������**/
	ARENA_MULTI_START_REQUEST = 334 ,
/**����������ս��Ӧ��**/
	ARENA_MULTI_START_ANSWER = 335 ,
/**��������ʱ֪ͨ**/
	BAG_NOT_ENOUGH_NOTIFY = 336 ,
/**ռɽΪ���ݵ���Ϣ����**/
	CRUSADE_FORTRESS_INFO_REQUEST = 337 ,
/**ռɽΪ���ݵ���ϢӦ��**/
	CRUSADE_FORTRESS_INFO_ANSWER = 338 ,
/**ռɽΪ���ݵ���ս����**/
	CRUSADE_FORTRESS_FIGHT_REQUEST = 339 ,
/**ռɽΪ���ݵ���սӦ��**/
	CRUSADE_FORTRESS_FIGHT_ANSWER = 340 ,
/**ռɽΪ����������**/
	KING_FIGHT_REQUEST = 341 ,
/**ռɽΪ������Ӧ��**/
	KING_FIGHT_ANSWER = 342 ,
/**ռɽΪ���ؿ���������**/
	KING_FIGHT_STAGE_INFO_REQUEST = 343 ,
/**ռɽΪ���ؿ�����Ӧ��**/
	KING_FIGHT_STAGE_INFO_ANSWER = 344 ,
/**��սռɽΪ���ؿ�����**/
	KING_FIGHT_START_REQUEST = 345 ,
/**��սռɽΪ���ؿ�Ӧ��**/
	KING_FIGHT_START_ANSWER = 346 ,
/**ռɽΪ������ʹ������**/
	KING_FIGHT_USE_ITEM_REQUEST = 347 ,
/**ռɽΪ������ʹ��Ӧ��**/
	KING_FIGHT_USE_ITEM_ANSWER = 348 ,
/**ռɽΪ���ݵ���ȡ�ݵ���������**/
	CRUSADE_FORTRESS_REWARD_REQUEST = 349 ,
/**ռɽΪ���ݵ���ȡ�ݵ�����Ӧ��**/
	CRUSADE_FORTRESS_REWARD_ANSWER = 350 ,
/**ռɽΪ���ݵ���ȡ���ȱ�������**/
	CRUSADE_FORTRESS_OPEN_BOX_REQUEST = 351 ,
/**ռɽΪ���ݵ���ȡ���ȱ���ظ�**/
	CRUSADE_FORTRESS_OPEN_BOX_ANSWER = 352 ,
/**Ѱ����Ϣ����**/
	VISIT_INFO_REQUEST = 353 ,
/**Ѱ����ϢӦ��**/
	VISIT_INFO_ANSWER = 354 ,
/**Ѱ�÷�������**/
	VISIT_START_REQUEST = 355 ,
/**Ѱ�÷���Ӧ��**/
	VISIT_START_ANSWER = 356 ,
/**Ѱ����ȡ��������**/
	VISIT_GET_REWARD_REQUEST = 357 ,
/**Ѱ����ȡ����Ӧ��**/
	VISIT_GET_REWARD_ANSWER = 358 ,
/**ռɽΪ�������������**/
	KING_FIGHT_BUY_CNT_REQUEST = 359 ,
/**ռɽΪ���������Ӧ��**/
	KING_FIGHT_BUY_CNT_ANSWER = 360 ,
/**ռɽΪ���Ǽ���������**/
	KING_FIGHT_RANK_STAR_REQUEST = 361 ,
/**ռɽΪ���Ǽ�����Ӧ��**/
	KING_FIGHT_RANK_STAR_ANSWER = 362 ,
/**ռɽΪ���˺���������**/
	KING_FIGHT_RANK_DAMAGE_REQUEST = 363 ,
/**ռɽΪ���˺�����Ӧ��**/
	KING_FIGHT_RANK_DAMAGE_ANSWER = 364 ,
/**����ݷ���Ϣ����**/
	VISIT_INFO_RANDOM_REQUEST = 365 ,
/**����ݷ���ϢӦ��**/
	VISIT_INFO_RANDOM_ANSWER = 366 ,
/**�ݷú����б�����**/
	VISIT_FRIEND_LIST_REQUEST = 367 ,
/**�ݷú����б�Ӧ��**/
	VISIT_FRIEND_LIST_ANSWER = 368 ,
/**�ݷú�������**/
	VISIT_FRIEND_REQUEST = 369 ,
/**�ݷú���Ӧ��**/
	VISIT_FRIEND_ANSWER = 370 ,
/**��ȡ������վ��������**/
	VISIT_FRIEND_REWARD_REQUEST = 371 ,
/**��ȡ������վ����Ӧ��**/
	VISIT_FRIEND_REWARD_ANSWER = 372 ,
/**���Ѽ�������**/
	VISIT_FRIEND_ACCELERATE_REQUEST = 373 ,
/**���Ѽ���Ӧ��**/
	VISIT_FRIEND_ACCELERATE_ANSWER = 374 ,
/**ռɽΪ���ݵ�ս����¼����**/
	CRUSADE_FORTRESS_BATTLE_RECORD_REQUEST = 375 ,
/**ռɽΪ���ݵ�ս����¼Ӧ��**/
	CRUSADE_FORTRESS_BATTLE_RECORD_ANSWER = 376 ,
/**ռɽΪ���ݵ�ս���ط�����**/
	CRUSADE_FORTRESS_REPLAY_RECORD_REQUEST = 377 ,
/**ռɽΪ���ݵ�ս���ط�Ӧ��**/
	CRUSADE_FORTRESS_REPLAY_RECORD_ANSWER = 378 ,
/**Ѱ�ñ��淽������**/
	VISIT_SAVE_ROUTE_REQUEST = 379 ,
/**Ѱ�ñ��淽��Ӧ��**/
	VISIT_SAVE_ROUTE_ANSWER = 380 ,
/**һ����������**/
	VISIT_ONE_KEY_START_REQUEST = 381 ,
/**һ������Ӧ��**/
	VISIT_ONE_KEY_START_ANSWER = 382 ,
/**��ȡ���淽������**/
	VISIT_GET_SAVE_ROUTE_REQUEST = 383 ,
/**��ȡ���淽����**/
	VISIT_GET_SAVE_ROUTE_ANSWER = 384 ,
/**ռɽΪ���ݵ���������buff����**/
	CRUSADE_FORTRESS_BUY_BUFF_REQUEST = 385 ,
/**ռɽΪ���ݵ���������buffӦ��**/
	CRUSADE_FORTRESS_BUY_BUFF_ANSWER = 386 ,
/**ռɽΪ���ݵ��ݲ鿴��Ϣ����**/
	CRUSADE_FORTRESS_ALL_INFO_REQUEST = 387 ,
/**ռɽΪ���ݵ��ݲ鿴��ϢӦ��**/
	CRUSADE_FORTRESS_ALL_INFO_ANSWER = 388 ,
/**ռɽΪ���ݵ㹺���������**/
	CRUSADE_FORTRESS_BUY_CNT_REQUEST = 389 ,
/**ռɽΪ���ݵ㹺�����Ӧ��**/
	CRUSADE_FORTRESS_BUY_CNT_ANSWER = 390 ,
/**һ����ȡ��������**/
	VISIT_ONE_KEY_GET_REWARD_REQUEST = 391 ,
/**һ����ȡ����Ӧ��**/
	VISIT_ONE_KEY_GET_REWARD_ANSWER = 392 ,
/**ϵͳ����֪ͨ**/
	SYSTEM_UPDATE_NOTIFY = 393 ,
/**������������**/
	OPEN_FUND_REQUEST = 394 ,
/**��������Ӧ��**/
	OPEN_FUND_ANSWER = 395 ,
/**���򿪷���������**/
	OPEN_FUND_BUY_REQUEST = 396 ,
/**���򿪷�����Ӧ��**/
	OPEN_FUND_BUY_ANSWER = 397 ,
/**��ȡ������������**/
	OPEN_FUND_GET_REQUEST = 398 ,
/**��ȡ��������Ӧ��**/
	OPEN_FUND_GET_ANSWER = 399 ,
/**��ȡȫ��������**/
	UNIVERSAL_WELFARE_GET_REQUEST = 400 ,
/**��ȡȫ����Ӧ��**/
	UNIVERSAL_WELFARE_GET_ANSWER = 401 ,
/**���Ԥѡ��������**/
	WUDI_PRESELECT_RANK_REQUEST = 402 ,
/**���Ԥѡ����Ӧ��**/
	WUDI_PRESELECT_RANK_ANSWER = 403 ,
/**�����Ϣ����**/
	WUDI_INFO_REQUEST = 404 ,
/**�����ϢӦ��**/
	WUDI_INFO_ANSWER = 405 ,
/**�¿���Ϣ����**/
	MONTH_CARD_INFO_REQUEST = 406 ,
/**�¿���ϢӦ��**/
	MONTH_CARD_INFO_ANSWER = 407 ,
/**�¿�������ȡ����**/
	MONTH_CARD_GET_REQUEST = 408 ,
/**�¿�������ȡӦ��**/
	MONTH_CARD_GET_ANSWER = 409 ,
/**�����ս����**/
	WUDI_FIGHT_REQUEST = 410 ,
/**�����սӦ��**/
	WUDI_FIGHT_ANSWER = 411 ,
/**����˺���������**/
	WUDI_HURT_RANK_REQUEST = 412 ,
/**����˺�����Ӧ��**/
	WUDI_HURT_RANK_ANSWER = 413 ,
/**���������ս��������**/
	BUY_WUDI_FIGHT_CNT_REQUEST = 414 ,
/**���������ս����Ӧ��**/
	BUY_WUDI_FIGHT_CNT_ANSWER = 415 ,
/**���������սbuff����**/
	BUY_WUDI_FIGHT_BUFF_REQUEST = 416 ,
/**���������սbuffӦ��**/
	BUY_WUDI_FIGHT_BUFF_ANSWER = 417 ,
/**�������buff����**/
	BUY_WUDI_BOSS_BUFF_REQUEST = 418 ,
/**�������buffӦ��**/
	BUY_WUDI_BOSS_BUFF_ANSWER = 419 ,
/**��ۿ���֪ͨ**/
	WUDI_OPEN_NOTIFY = 420 ,
/**�����޸�������������**/
	LEGION_CHANGE_ACCEPT_TPYE_REQUEST = 421 ,
/**�����޸���������Ӧ��**/
	LEGION_CHANGE_ACCEPT_TPYE_ANSWER = 422 ,
/**���ѵ��߳�������**/
	SELL_AWAKEN_ITEM_REQUEST = 423 ,
/**���ѵ��߳���Ӧ��**/
	SELL_AWAKEN_ITEM_ANSWER = 424 ,
/**���ѵ��߷ֽ�����**/
	FENJIE_AWAKEN_ITEM_REQUEST = 425 ,
/**���ѵ��߷ֽ�Ӧ��**/
	FENJIE_AWAKEN_ITEM_ANSWER = 426 ,
/**�׳�������ȡ����**/
	FIRST_RECHARGE_AWARD_GET_REQUEST = 427 ,
/**�׳�������ȡӦ��**/
	FIRST_RECHARGE_AWARD_GET_ANSWER = 428 ,
/**�ʼ�״̬����**/
	MAIL_STATUS_REQUEST = 429 ,
/**�鿨�֪ͨ**/
	CHOUKA_ACTIVITY_NOTIFY = 430 ,
/**���ɸ�����Ϣ����**/
	LEGION_BOSS_INFO_REQUEST = 431 ,
/**���ɸ�����ϢӦ��**/
	LEGION_BOSS_INFO_ANSWER = 432 ,
/**���ɸ�����ʼ����**/
	LEGION_BOSS_FIGHT_REQUEST = 433 ,
/**���ɸ�����ʼӦ��**/
	LEGION_BOSS_FIGHT_ANSWER = 434 ,
/**���ɸ�����ȡ��������**/
	LEGION_BOSS_GET_REWARD_REQUEST = 435 ,
/**���ɸ�����ȡ����Ӧ��**/
	LEGION_BOSS_GET_REWARD_ANSWER = 436 ,
/**����������������**/
	LEGION_BOSS_FIRST_KILL_RANK_REQUEST = 437 ,
/**������������Ӧ��**/
	LEGION_BOSS_FIRST_KILL_RANK_ANSWER = 438 ,
/**�����Ʊ���������**/
	LEGION_BOSS_TOTAL_STAGE_RANK_REQUEST = 439 ,
/**�����Ʊ�����Ӧ��**/
	LEGION_BOSS_TOTAL_STAGE_RANK_ANSWER = 440 ,
/**���ڵ����˺���������**/
	LEGION_BOSS_LEGION_MAX_DAMAGE_RANK_REQUEST = 441 ,
/**���ڵ����˺�����Ӧ��**/
	LEGION_BOSS_LEGION_MAX_DAMAGE_RANK_ANSWER = 442 ,
/**ȫ�������˺���������**/
	LEGION_BOSS_MAX_DAMAGE_RANK_REQUEST = 443 ,
/**ȫ�������˺�����Ӧ��**/
	LEGION_BOSS_MAX_DAMAGE_RANK_ANSWER = 444 ,
/**����BOSS��ɱ����������**/
	LEGION_BOSS_KILL_COUNT_RANK_REQUEST = 445 ,
/**����BOSS��ɱ������Ӧ��**/
	LEGION_BOSS_KILL_COUNT_RANK_ANSWER = 446 ,
/**����BOSS������Ϣ����**/
	LEGION_BOSS_TASK_INFO_REQUEST = 447 ,
/**����BOSS������ϢӦ��**/
	LEGION_BOSS_TASK_INFO_ANSWER = 448 ,
/**����BOSS��������ȡ����**/
	LEGION_BOSS_TASK_GET_REQUEST = 449 ,
/**����BOSS��������ȡӦ��**/
	LEGION_BOSS_TASK_GET_ANSWER = 450 ,
/**����ǩ����ȡ��������**/
	LUXURY_SIGN_GET_REWARD_REQUEST = 451 ,
/**����ǩ����ȡ����Ӧ��**/
	LUXURY_SIGN_GET_REWARD_ANSWER = 452 ,
/**��չʾ���ĺϻ��佫֪ͨ**/
	UNITE_SKILL_SHOW_NOTIFY = 453 ,
/**��������**/
	RENAME_REQUEST = 454 ,
/**����Ӧ��**/
	RENAME_ANSWER = 455 ,
/**��������**/
	HEARTBEAT_REQUEST = 456 ,
/**����Ӧ��**/
	HEARTBEAT_ANSWER = 457 ,
/**ʱװ��������**/
	FASHION_DRESS_REQUEST = 458 ,
/**ʱװ����Ӧ��**/
	FASHION_DRESS_ANSWER = 459 ,
/**ʱװж������**/
	FASHION_UNDRESS_REQUEST = 460 ,
/**ʱװж��Ӧ��**/
	FASHION_UNDRESS_ANSWER = 461 ,
/**�鿨��������ֵ֪ͨ**/
	CHOUKA_SHARE_LUCK_NOTIFY = 462 ,
/**ʱװǿ������**/
	FASHION_STRENGTHEN_REQUEST = 463 ,
/**ʱװǿ��Ӧ��**/
	FASHION_STRENGTHEN_ANSWER = 464 ,
/**��ȡ����ֵ��������**/
	DRAW_LUCK_PACKAGE_REQUEST = 465 ,
/**��ȡ����ֵ������Ӧ**/
	DRAW_LUCK_PACKAGE_ANSWER = 466 ,
/**ת����Ϣ֪ͨ**/
	TURNTABLE_NOTIFY = 467 ,
/**ת�̳齱����**/
	TURNTABLE_START_REQUEST = 468 ,
/**ת�̳齱Ӧ��**/
	TURNTABLE_START_ANSWER = 469 ,
/**ת��ˢ������**/
	TURNTABLE_REFRESH_REQUEST = 470 ,
/**ת��ˢ��Ӧ��**/
	TURNTABLE_REFRESH_ANSWER = 471 ,
/**ת�̳齱��¼����**/
	TURNTABLE_RECORD_REQUEST = 472 ,
/**ת�̳齱��¼Ӧ��**/
	TURNTABLE_RECORD_ANSWER = 473 ,
/**ת�̻�����б�����**/
	TURNTABLE_TASK_LIST_REQUEST = 474 ,
/**ת�̻�����б�Ӧ��**/
	TURNTABLE_TASK_LIST_ANSWER = 475 ,
/**ת�̻��ȡ����������**/
	TURNTABLE_TASK_REWARD_REQUEST = 476 ,
/**ת�̻��ȡ������Ӧ��**/
	TURNTABLE_TASK_REWARD_ANSWER = 477 ,
/**�в�è��Ϣ֪ͨ**/
	ZHAOCAIMAO_NOTIFY = 478 ,
/**�в�è�齱����**/
	ZHAOCAIMAO_START_REQUEST = 479 ,
/**�в�è�齱Ӧ��**/
	ZHAOCAIMAO_START_ANSWER = 480 ,
/**�в�è�齱��¼����**/
	ZHAOCAIMAO_RECORD_REQUEST = 481 ,
/**�в�è�齱��¼Ӧ��**/
	ZHAOCAIMAO_RECORD_ANSWER = 482 ,
/**�в�è������б�����**/
	ZHAOCAIMAO_TASK_LIST_REQUEST = 483 ,
/**�в�è������б�Ӧ��**/
	ZHAOCAIMAO_TASK_LIST_ANSWER = 484 ,
/**�в�è���ȡ����������**/
	ZHAOCAIMAO_TASK_REWARD_REQUEST = 485 ,
/**�в�è���ȡ������Ӧ��**/
	ZHAOCAIMAO_TASK_REWARD_ANSWER = 486 ,
/**�򿪽���**/
	OPEN_UI_REPORT = 487 ,
/**���������������Ϣ����**/
	CS_POINTS_RACE_GET_INFO_REQUEST = 488 ,
/**���������������ϢӦ��**/
	CS_POINTS_RACE_GET_INFO_ANSWER = 489 ,
/**�����������ȡ�����б�����**/
	CS_POINTS_RACE_GET_OPPONENTS_REQUEST = 490 ,
/**�����������ȡ�����б�Ӧ��**/
	CS_POINTS_RACE_GET_OPPONENTS_ANSWER = 491 ,
/**�����������ս����**/
	CS_POINTS_RACE_FIGHT_REQUEST = 492 ,
/**�����������սӦ��**/
	CS_POINTS_RACE_FIGHT_ANSWER = 493 ,
/**�����������������**/
	CS_POINTS_RACE_REVENGE_REQUEST = 494 ,
/**�������������Ӧ��**/
	CS_POINTS_RACE_REVENGE_ANSWER = 495 ,
/**���������Ԥ��ս����**/
	CS_POINTS_RACE_PREPARE_FIGHT_REQUEST = 496 ,
/**���������Ԥ��սӦ��**/
	CS_POINTS_RACE_PREPARE_FIGHT_ANSWER = 497 ,
/**������������а�����**/
	CS_POINTS_RACE_RANK_REQUEST = 498 ,
/**������������а�Ӧ��**/
	CS_POINTS_RACE_RANK_ANSWER = 499 ,
/**������������ؼ�¼����**/
	CS_POINTS_RACE_DEFEND_LOG_REQUEST = 500 ,
/**������������ؼ�¼Ӧ��**/
	CS_POINTS_RACE_DEFEND_LOG_ANSWER = 501 ,
/**���������ˢ�¶�������**/
	CS_POINTS_RACE_REFRESH_REQUEST = 502 ,
/**���������ˢ�¶���Ӧ��**/
	CS_POINTS_RACE_REFRESH_ANSWER = 503 ,
/**�ֽ��������**/
	FENJIE_GALLANT_REQUEST = 504 ,
/**�ֽ����Ӧ��**/
	FENJIE_GALLANT_ANSWER = 505 ,
/**�ϳɺ�������**/
	COMPOSE_GALLANT_REQUEST = 506 ,
/**�ϳɺ���Ӧ��**/
	COMPOSE_GALLANT_ANSWER = 507 ,
/**��������Ŀ��Ϣ֪ͨ**/
	GALLANT_ENTRY_INFO_NOTIFY = 508 ,
/**��������Ŀ��������**/
	GALLANT_ENTRY_ACTIVATE_REQUEST = 509 ,
/**��������Ŀ����Ӧ��**/
	GALLANT_ENTRY_ACTIVATE_ANSWER = 510 ,
/**���������а�����**/
	GALLANT_RANK_REQUEST = 511 ,
/**���������а�Ӧ��**/
	GALLANT_RANK_ANSWER = 512 ,
/**������������Ϣ����**/
	GALLANT_RAID_INFO_REQUEST = 513 ,
/**������������ϢӦ��**/
	GALLANT_RAID_INFO_ANSWER = 514 ,
/**����������ˢ������**/
	GALLANT_RAID_REFRESH_REQUEST = 515 ,
/**����������ˢ��Ӧ��**/
	GALLANT_RAID_REFRESH_ANSWER = 516 ,
/**������������ս����**/
	GALLANT_RAID_FIGHT_REQUEST = 517 ,
/**������������սӦ��**/
	GALLANT_RAID_FIGHT_ANSWER = 518 ,
/**���������������ս��������**/
	CS_POINTS_RACE_BUYCNT_REQUEST = 519 ,
/**���������������ս����Ӧ��**/
	CS_POINTS_RACE_BUYCNT_ANSWER = 520 ,
/**��ʱ����֪ͨ**/
	LIMITED_TIME_BUY_NOTIFY = 521 ,
/**��ʱ��������**/
	LIMITED_TIME_BUY_REQUEST = 522 ,
/**��ʱ����Ӧ��**/
	LIMITED_TIME_BUY_ANSWER = 523 ,
/**������Ϣ֪ͨ**/
	REBATE_INFO_NOTIFY = 524 ,
/**������ȡ����**/
	REBATE_RECEIVE_REQUEST = 525 ,
/**������ȡӦ��**/
	REBATE_RECEIVE_ANSWER = 526 ,
/**��ֵ֪ͨ**/
	RECHARGE_NOTIFY = 527 ,
/**װ����������**/
	PET_DRESS_REQUEST = 528 ,
/**װ������Ӧ��**/
	PET_DRESS_ANSWER = 529 ,
/**ж�³�������**/
	PET_UNDRESS_REQUEST = 530 ,
/**ж�³���Ӧ��**/
	PET_UNDRESS_ANSWER = 531 ,
/**�����������**/
	PET_IN_BATTLE_REQUEST = 532 ,
/**�������Ӧ��**/
	PET_IN_BATTLE_ANSWER = 533 ,
/**�����������**/
	PET_OUT_BATTLE_REQUEST = 534 ,
/**�������Ӧ��**/
	PET_OUT_BATTLE_ANSWER = 535 ,
/**������������**/
	PET_UPLEVEL_REQUEST = 536 ,
/**��������Ӧ��**/
	PET_UPLEVEL_ANSWER = 537 ,
/**������������**/
	PET_STAR_UPGRADE_REQUEST = 538 ,
/**��������Ӧ��**/
	PET_STAR_UPGRADE_ANSWER = 539 ,
/**������������**/
	PET_REFINE_REQUEST = 540 ,
/**��������Ӧ��**/
	PET_REFINE_ANSWER = 541 ,
/**�����������Ϣ����**/
	CS_POINTS_RACE_STATE_REQUEST = 542 ,
/**�����������ϢӦ��**/
	CS_POINTS_RACE_STATE_ANSWER = 543 ,
/**���޻֪ͨ**/
	NIAN_EVENT_NOTIFY = 544 ,
/**������Ϣ����**/
	NIAN_INFO_REQUEST = 545 ,
/**������ϢӦ��**/
	NIAN_INFO_ANSWER = 546 ,
/**����������**/
	NIAN_BUY_FIREWORKS_REQUEST = 547 ,
/**������Ӧ��**/
	NIAN_BUY_FIREWORKS_ANSWER = 548 ,
/**ʹ��������**/
	NIAN_USE_FIREWORKS_REQUEST = 549 ,
/**ʹ����Ӧ��**/
	NIAN_USE_FIREWORKS_ANSWER = 550 ,
/**��ȡ�������**/
	NIAN_GET_RED_PACKET_REQUEST = 551 ,
/**��ȡ���Ӧ��**/
	NIAN_GET_RED_PACKET_ANSWER = 552 ,
/**�������а�����**/
	NIAN_RANK_REQUEST = 553 ,
/**�������а�Ӧ��**/
	NIAN_RANK_ANSWER = 554 ,
/**���޻�����б�����**/
	NIAN_TASK_LIST_REQUEST = 555 ,
/**���޻�����б�Ӧ��**/
	NIAN_TASK_LIST_ANSWER = 556 ,
/**���޻��ȡ����������**/
	NIAN_TASK_REWARD_REQUEST = 557 ,
/**���޻��ȡ������Ӧ��**/
	NIAN_TASK_REWARD_ANSWER = 558 ,
/**���޻���а�ǰ�����仯֪ͨ**/
	NIAN_TOP_RANK_CHANGED_NOTIFY = 559 ,
/**�۷�֮·�ɾ��б�����**/
	ACHIEVEMENT_TASK_LIST_REQUEST = 560 ,
/**�۷�֮·�ɾ��б�Ӧ��**/
	ACHIEVEMENT_TASK_LIST_ANSWER = 561 ,
/**�۷�֮·��ȡ��������**/
	ACHIEVEMENT_TASK_REWARD_REQUEST = 562 ,
/**�۷�֮·��ȡ����Ӧ��**/
	ACHIEVEMENT_TASK_REWARD_ANSWER = 563 ,
/**�۷�֮·һ����ȡ��������**/
	ACHIEVEMENT_ONE_KEY_REWARD_REQUEST = 564 ,
/**�۷�֮·һ����ȡ����Ӧ��**/
	ACHIEVEMENT_ONE_KEY_REWARD_ANSWER = 565 ,
/**�۷�֮·���������֪ͨ**/
	ACHIEVEMENT_NEW_TASK_COMPLETE_NOTIFY = 566 ,
/**����֪ͨ**/
	ANNOUNCEMENT_NOTIFY = 567 ,
/**����֪ͨ**/
	BLESSING_BAG_NOTIFY = 568 ,
/**��¼����֪ͨ**/
	ENTER_GAME_GUIDE_NOTIFY = 569 ,
/**Ԫ�������¿�����**/
	BUY_MONTH_CARD_REQUEST = 570 ,
/**Ԫ�������¿�Ӧ��**/
	BUY_MONTH_CARD_ANSWER = 571 ,
/**���︱����Ϣ����**/
	PET_RAID_INFO_REQUEST = 572 ,
/**���︱����ϢӦ��**/
	PET_RAID_INFO_ANSWER = 573 ,
/**���︱����������**/
	PET_RAID_DEPLOY_REQUEST = 574 ,
/**���︱������Ӧ��**/
	PET_RAID_DEPLOY_ANSWER = 575 ,
/**���︱����ս����**/
	PET_RAID_FIGHT_REQUEST = 576 ,
/**���︱����սӦ��**/
	PET_RAID_FIGHT_ANSWER = 577 ,
/**���︱������֪ͨ**/
	PET_RAID_BOX_NOTIFY = 578 ,
/**���︱����������**/
	PET_RAID_RESET_REQUEST = 579 ,
/**���︱������Ӧ��**/
	PET_RAID_RESET_ANSWER = 580 ,
/**���︱��һ��ͨ������**/
	PET_RAID_ONE_KEY_PASS_REQUEST = 581 ,
/**���︱��һ��ͨ��Ӧ��**/
	PET_RAID_ONE_KEY_PASS_ANSWER = 582 ,
/**���︱��ͨ������������**/
	PET_RAID_PASS_COUNT_RANK_REQUEST = 583 ,
/**���︱��ͨ��������Ӧ��**/
	PET_RAID_PASS_COUNT_RANK_ANSWER = 584 ,
/**ģ�鶩������**/
	MODULE_SUBSCRIBE_REQUEST = 585 ,
/**�źӵ�����**/
	CS_RIVER_LANTERN_FLOAT_REQUEST = 586 ,
/**�źӵ�Ӧ��**/
	CS_RIVER_LANTERN_FLOAT_ANSWER = 587 ,
/**�ӵƻ��Ϣ����**/
	CS_RIVER_LANTERN_INFO_REQUEST = 588 ,
/**�ӵƻ��ϢӦ��**/
	CS_RIVER_LANTERN_INFO_ANSWER = 589 ,
/**�ºӵ�֪ͨ**/
	CS_RIVER_LANTERN_NEW_FLOAT_NOTIFY = 590 ,
/**�ºӵ����а�֪ͨ**/
	CS_RIVER_LANTERN_NEW_RANK_NOTIFY = 591 ,
/**�ӵ��Լ������仯֪ͨ**/
	CS_RIVER_LANTERN_SELF_RANK_UPDATE_NOTIFY = 592 ,
/**�ӵ����˻����Ʒ֪ͨ**/
	CS_RIVER_LANTERN_OTHERS_GET_ITEM_NOTIFY = 593 ,
/**�Ź���Ϣ����**/
	CS_GROUPON_INFO_REQUEST = 594 ,
/**�Ź���ϢӦ��**/
	CS_GROUPON_INFO_ANSWER = 595 ,
/**�Ź�����ʣ�����**/
	CS_GROUPON_COUNT_UPDATE_NOTIFY = 596 ,
};
#endif