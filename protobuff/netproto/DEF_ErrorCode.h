#ifndef DEF_ERRORCODE_H
#define DEF_ERRORCODE_H
/**�������**/
enum DEF_ErrorCode {
/**�ɹ�**/
	ERRORCODE_RESULT_ID_SUCCESS = 0 ,
/**ϵͳ����**/
	ERRORCODE_RESULT_ID_FAIL = 1 ,
/**��Ҳ�����**/
	ERRORCODE_ROLE_NOT_EXIST = 3 ,
/**�������ߣ�����˺����������豸�ϵ�¼**/
	ERRORCODE_KICK_REQISTER = 4 ,
/**������ʹ��**/
	ERRORCODE_NAME_USED = 5 ,
/**��������**/
	ERRORCODE_SEND_WORD_LIMIT = 6 ,
/**����Ƶ�������쳣**/
	ERRORCODE_CHAT_EXCEPTION = 7 ,
/**��Ʒ������**/
	ERRORCODE_BAG_FULL = 8 ,
/**��������**/
	ERRORCODE_FRIEND_FULL = 9 ,
/**�Է���������**/
	ERRORCODE_PEER_FRIEND_FULL = 10 ,
/**�����ѳ�����ս����**/
	ERRORCODE_RAID_DEKARON_LIMIT = 11 ,
/**�������㹻**/
	ERRORCODE_POWER_NOT_ENOUGH = 12 ,
/**���佱���Ѿ���ȡ**/
	ERRORCODE_BOX_REWARD_ALREADY_RECV = 13 ,
/**ɨ����ȴ�С�**/
	ERRORCODE_SWEEP_COOLING = 14 ,
/**���ǽ�������ȡ**/
	ERRORCODE_STAR_REWARD_RECV = 15 ,
/**����������**/
	ERRORCODE_STAR_NOT_ENOUGH = 16 ,
/**���佱���Ѿ���ȡ**/
	ERRORCODE_BOX_REWARD_RECV = 17 ,
/**Ԫ�����㹻**/
	ERRORCODE_YUEN_BAO_NOT_ENOUGH = 19 ,
/**���Ҳ��㹻**/
	ERRORCODE_SILVER_NOT_ENOUGH = 20 ,
/**�佫�ռ�����**/
	ERRORCODE_HERO_FULL = 21 ,
/**װ���ռ�����**/
	ERRORCODE_EQUIP_FULL = 22 ,
/**����ǰ��Ĺ����������Ұɣ�**/
	ERRORCODE_PREV_RAID = 23 ,
/**�ȼ����㹻**/
	ERRORCODE_LEVEL_NOT_ENOUGH = 24 ,
/**�������㹻**/
	ERRORCODE_ENERGY_NOT_ENOUGH = 25 ,
/**vip�̳ǹ��򵽴�����**/
	ERRORCODE_VIP_SHOP_LIMIT = 26 ,
/**�������㹻**/
	ERRORCODE_PRESTIGE_NOT_ENOUGH = 27 ,
/**�佫������**/
	ERRORCODE_HERO_NOT_EXIST = 28 ,
/**����ͨ�����Ĳ��Ͽ�����**/
	ERRORCODE_MATERIAL_UP_LEVEL = 29 ,
/**�佫�ȼ����ɳ�����ɫ�ȼ�**/
	ERRORCODE_HERO_LV_LIMIT = 30 ,
/**�Լ�����������������**/
	ERRORCODE_NOT_MATERIAL_CARD = 31 ,
/**���������佫������**/
	ERRORCODE_HERO_MATERIAL_NOT_EXIST = 32 ,
/**���������佫�ظ�**/
	ERRORCODE_HERO_MATERIAL_REPEAT = 33 ,
/**�����佫������Ϊ��������**/
	ERRORCODE_PLAY_HERO_UP_LV_MATERIAL = 34 ,
/**�����佫ͻ���Ѿ��ﵽ����**/
	ERRORCODE_HERO_BREAKTHROUGH_LIMIT = 35 ,
/**ͻ����������������**/
	ERRORCODE_HERO_BREAKTHROUGH_CARD = 36 ,
/**�佫���ײ��Ͽ���id����**/
	ERRORCODE_HERO_SCALA_MATERIAL_ID = 37 ,
/**�����佫���ɵ���ͻ�Ʋ���**/
	ERRORCODE_PLAY_HERO_BREAKTHROUGH_MATERIAL = 38 ,
/**������������**/
	ERRORCODE_PROP_NOT_ENOUGH = 39 ,
/**ǰ�ü���δѧϰ**/
	ERRORCODE_PREV_SKILL_NOT_STUDY = 40 ,
/**���ܴﵽ����**/
	ERRORCODE_SKILL_LEVEL_FULL = 41 ,
/**���ܵ㲻��**/
	ERRORCODE_SKILL_POINT_NOT_ENOUGH = 42 ,
/**����δ�ҵ�**/
	ERRORCODE_SKILL_NOT_EXIST = 43 ,
/**ͬ���ͼ��ܲ��������޷�ϴ����**/
	ERRORCODE_SAME_SKILL_NOT_EXIST = 44 ,
/**���ܲ�λ����**/
	ERRORCODE_SKILL_SLOT_ERROR = 45 ,
/**�佫����ֵ��������**/
	ERRORCODE_HERO_CULTURE_VAL_OVERFLOW = 46 ,
/**ϴ������ϴ��λ��Ϊ��**/
	ERRORCODE_WASH_SKILL_SLOT_NOT_EMPTY = 47 ,
/**��������������������**/
	ERRORCODE_FAMOUS_HERO_LIMIT = 48 ,
/**����־�����Ѿ���ȡ**/
	ERRORCODE_MIKUNI_ALREADY_RECV = 49 ,
/**װ��������**/
	ERRORCODE_EQUIP_NOT_EXIST = 50 ,
/**װ��ǿ���ȼ���������**/
	ERRORCODE_EQUIP_STRENGTHEN_LIMIT = 51 ,
/**װ�������ȼ���������**/
	ERRORCODE_EQUIP_REFINING_LIMIT = 52 ,
/**�������Ͳ���**/
	ERRORCODE_EQUIP_TYEP_ERROR = 53 ,
/**�佫�����ȼ��Ѿ��ﵽ���**/
	ERRORCODE_HERO_DESTINY_LIMIT = 54 ,
/**���̵깺�򵽴�����**/
	ERRORCODE_MYSTERY_SHOP_BUY_LIMIT = 56 ,
/**���겻�㹻**/
	ERRORCODE_HERO_SOLU_NOT_ENOUGH = 57 ,
/**��ǰ���Ѿ��޷�����**/
	ERRORCODE_REBEL_UNABLE_ATTACK = 58 ,
/**������㹻**/
	ERRORCODE_CRUSADE_NOT_ENOUGH = 59 ,
/**û�ҵ��Ѿ�����ID**/
	ERRORCODE_REBEL_REWARD_ID_NOT_EXIST = 60 ,
/**���ﱳ������**/
	ERRORCODE_TREASURE_BAG_FULL = 61 ,
/**�佫���ܱ�ͻ��**/
	ERRORCODE_HERO_UNABLE_BREAKTHROUGH = 62 ,
/**���ﲻ����**/
	ERRORCODE_TREASURE_NOT_EXIST = 63 ,
/**ǿ�����ϱ����ظ�**/
	ERRORCODE_STRENGTHEN_MATERIAL_REPEAT = 64 ,
/**�������ϱ������ݲ���**/
	ERRORCODE_REFINING_MATERIAL_NOT_ENOUGH = 65 ,
/**������Ƭ��������**/
	ERRORCODE_TREASURE_CHIP_NOT_ENOUGH = 66 ,
/**�Ѿ��Ƿ����Ѿ����޹���(�Ѿ�û�п��Ÿ����ѣ��������Ѿ����Կ���)**/
	ERRORCODE_REBEL_ILLEGAL_OPEN = 67 ,
/**�Ѿ��Ƿ��������Լ����ѵ��Ѿ�**/
	ERRORCODE_REBEL_ILLEGAL_NOT_FRIEND = 68 ,
/**������װ��**/
	ERRORCODE_TREASURE_ALREADY_WEAR = 69 ,
/**�ñ��ﲻ�ܱ�ǿ������**/
	ERRORCODE_TREASURE_NON_STRENGTHEN_REFINING = 70 ,
/**û���㹻�Ĺ�ѫ**/
	ERRORCODE_MILITARY_EXPLOITS_NOT_ENOUGH = 71 ,
/**�������㹻**/
	ERRORCODE_WAL_MART_NOT_ENOUGH = 72 ,
/**�����������Ѹ���**/
	ERRORCODE_ARENA_RANK_CHANGE = 73 ,
/**װ��ѧϰ������߲���**/
	ERRORCODE_EQUIP_STUDY_PROP_NOT_ENOUGH = 75 ,
/**���ü��ܼ��ܵȼ��Ƿ�**/
	ERRORCODE_RESET_SKILL_LV_ILLEGAL = 76 ,
/**������ݸ����С�**/
	ERRORCODE_PLAYER_DATA_UPDATE = 77 ,
/**�ñ�����Ƭ�ѱ�����**/
	ERRORCODE_TREASURE_CHIP_ALREADY_ROB = 78 ,
/**����Ѿ�����**/
	ERRORCODE_PLAYER_OFFLINE = 79 ,
/**�Է���������ĺ���**/
	ERRORCODE_PEER_NOT_FRIEND = 80 ,
/**���������Ѿ����˺ܶ���**/
	ERRORCODE_BUY_TOO_MUCH = 81 ,
/**�������Ʒ��ﵽ��������������Ŷ**/
	ERRORCODE_ARENA_RANK_NOT_ENOUGH = 82 ,
/**�������Ʒ��ﵽ������˫��������Ŷ**/
	ERRORCODE_TOWER_FLOOR_NOT_ENOUGH = 83 ,
/**�ճ�����δ����**/
	ERRORCODE_DAILY_RAID_NOT_OPEN = 84 ,
/**�ճ������Ĵ����Ѿ�����**/
	ERRORCODE_DAILY_RAID_EXHAUSTION = 85 ,
/**����VIP�ȼ���������**/
	ERRORCODE_VIP_LV_NOT_ENOUGH = 86 ,
/**�������Ƶ��**/
	ERRORCODE_CHAT_SEND_WORD_OFTEN = 87 ,
/**��Ѿ�����**/
	ERRORCODE_ACTIVITY_IS_OVER = 88 ,
/**����¿�����ȡ**/
	ERRORCODE_MONTH_CARD_ALREADY_RECV = 89 ,
/**��ǰ���ܰݲ���**/
	ERRORCODE_UNABLE_WORSHIP_MAMMON = 90 ,
/**�ճ�����Ľ�����δ���**/
	ERRORCODE_DAILY_TASK_NOT_COMPLETE = 91 ,
/**���ճ�����Ľ����Ѿ���ȡ����Ŷ**/
	ERRORCODE_DAILY_TASK_REWARD_RECV = 92 ,
/**�������Ѿ���ȡ**/
	ERRORCODE_TASK_BOX_REWARD_RECV = 93 ,
/**���佱����������**/
	ERRORCODE_BOX_REWARD_POINT_NOT_ENOUGH = 94 ,
/**���ô����Ѵﵽ����**/
	ERRORCODE_RESET_COUNT_LIMIT = 95 ,
/**���Ѿ�������**/
	ERRORCODE_BAN_SPEECH = 96 ,
/**����˺ŵ�ǰ���ڶ���״̬**/
	ERRORCODE_ACCOUNT_FREEZE = 97 ,
/**�佫�ȼ�����**/
	ERRORCODE_HERO_LEVEL_NOT_ENOUGH = 98 ,
/**��¼��ʱ����ص���¼�������µ�¼**/
	ERRORCODE_LOGIN_TIMEOUT = 99 ,
/**����ʱ��Ȩ�޵�¼�����Ժ�����**/
	ERRORCODE_LOGIN_NO_PERMISSIONS = 100 ,
/**��Ҵ�����ս״̬�����ܱ�����**/
	ERRORCODE_FREE_FIGHT_NOT_ROB = 101 ,
/**�����ﵽ20��������ս������ǰ10��**/
	ERRORCODE_ARENA_RIRST20_DEKARON = 102 ,
/**�������˴������Ʒ��**/
	ERRORCODE_GIFT_CODE = 103 ,
/**�ͻ��˰汾����**/
	ERRORCODE_CLIENT_VERSION = 104 ,
/**����ǩ�����ɳ���20����Ŷ**/
	ERRORCODE_SIGN_WORD_LIMIT = 105 ,
/**��������δ����**/
	ERRORCODE_SERVICE_NOT_OPEN = 107 ,
/**�Ѿ�����������ʱ�䣬�޷�����**/
	ERRORCODE_FUND_BUY_TIME_EXPIRE = 108 ,
/**���������𲻿��ظ�����**/
	ERRORCODE_FUND_BUY_REPEAT = 109 ,
/**�����δ�������**/
	ERRORCODE_USER_NOT_BUY_FUND = 110 ,
/**��������ȡʱ���ѹ��ڣ��޷���ȡ**/
	ERRORCODE_FUND_RECV_TIME_EXPIRE = 111 ,
/**�������Ѿ���ȡ**/
	ERRORCODE_FUND_REWARD_ALREADY_RECV = 112 ,
/**�������Ѿ���ȡ**/
	ERRORCODE_FUND_WELFARE_ALREADY_RECV = 113 ,
/**��������ȡ����û�д��**/
	ERRORCODE_FUND_WELFARE_CONDIT_NOT_ENOUGH = 114 ,
/**���������������ȡ**/
	ERRORCODE_ACTIVITY_REWARD_CONDIT_NOT_RECV = 115 ,
/**������һ���Ʒ����**/
	ERRORCODE_ACTIVITY_EXCHANGE_NOT_ENOUGH = 116 ,
/**���Ѿ�������޹����**/
	ERRORCODE_ATTEND_PURCHASE_LIMITS_ACTIVITY = 117 ,
/**�޹�����Ʒ�Ѿ�����������**/
	ERRORCODE_PURCHASE_LIMITS_EXHAUST = 118 ,
/**��Ѿ�����**/
	ERRORCODE_ACTIVITY_FINISH = 119 ,
/**�����Ѿ�����������ѹ��**/
	ERRORCODE_RIOT_OTHER_REPRESS = 120 ,
/**����Ʒ���ѹ���**/
	ERRORCODE_GIFT_CODE_EXPIRE = 121 ,
/**��Ʒ��ȱ�ٲ���**/
	ERRORCODE_GIFT_CODE_LACK_PARAM = 122 ,
/**��������**/
	ERRORCODE_INPUT_PARAM = 123 ,
/**����Ʒ���Ѿ�ʧЧ**/
	ERRORCODE_GIFT_CODE_INVALID = 124 ,
/**����Ʒ�벻����**/
	ERRORCODE_GIFT_CODE_NOT_EXIST = 126 ,
/**��Ѿ�����**/
	ERRORCODE_ACTIVITY_EXPIRE = 127 ,
/**����Ʒ���Ѿ�������ʹ�ô���**/
	ERRORCODE_GIFT_CODE_USE_LIMIT = 128 ,
/**���Ϸ�������**/
	ERRORCODE_ACTIVITY_CODE = 129 ,
/**�û����Ǹð��û�**/
	ERRORCODE_USER_NON_BINDING = 130 ,
/**У�������**/
	ERRORCODE_VERIFY_CODE = 131 ,
/**���Ų�����**/
	ERRORCODE_LEGION_NOT_EXIST = 132 ,
/**���ŵ������ǷǷ���**/
	ERRORCODE_LEGION_NAME_INVALID = 133 ,
/**���ŵ������Ѵ���**/
	ERRORCODE_LEGION_NAME_EXIST = 134 ,
/**����ľ����Ѿ�����**/
	ERRORCODE_LEGION_EXIST = 135 ,
/**������ľ��������Ѵﵽ����**/
	ERRORCODE_LEGION_APPLY_LIMIT = 136 ,
/**����ǰ���ھ���ʱ����ȴ��**/
	ERRORCODE_LEGION_COOLING = 137 ,
/**������������**/
	ERRORCODE_LEGION_ROLE_LIMIT = 138 ,
/**����Ȩ�޲���**/
	ERRORCODE_NOT_PERMISSION = 139 ,
/**������Ѿ����������ľ���**/
	ERRORCODE_ALREADY_JOINED_OTHER_LEGION = 140 ,
/**���ŵı߿�����������**/
	ERRORCODE_LEGION_FRAME_COND_NOT_ENOUGH = 141 ,
/**���Ÿ�������������**/
	ERRORCODE_VICE_LEGION_ROLE_LIMIT = 142 ,
/**��������������С��ɢ��������**/
	ERRORCODE_LEGION_ROLE_GT_DISSOLVE_ROLE = 143 ,
/**���Ѿ��������Ź�����**/
	ERRORCODE_LEGION_DEVOTE_ALREADY_USE = 144 ,
/**���������Ѿ�������Ź��׽���**/
	ERRORCODE_LEGION_DEVOTE_GIFT_ALREADY_RECV = 145 ,
/**���Ź��׽����������㣬�޷��콱**/
	ERRORCODE_LEGION_DEVOTE_POINT_NOT_ENOUGH = 146 ,
/**���ŵ�������**/
	ERRORCODE_LEGION_POINT_NOT_ENOUGH = 147 ,
/**����������������**/
	ERRORCODE_REWARD_NUM_LIMIT = 148 ,
/**ȫ������������������**/
	ERRORCODE_ALL_SRV_REWARD_NUM_LIMIT = 149 ,
/**�ý���������ȡ**/
	ERRORCODE_REWARD_UNABLE_RECV = 150 ,
/**����ID����**/
	ERRORCODE_REWARD_ID_ERROR = 151 ,
/**������������**/
	ERRORCODE_CARD_NUM_NOT_ENOUGH = 152 ,
/**װ����������**/
	ERRORCODE_EQUIP_NUM_NOT_ENOUGH = 153 ,
/**������������**/
	ERRORCODE_TREASURE_NUM_NOT_ENOUGH = 154 ,
/**������ȡʱ��δ��**/
	ERRORCODE_REWARD_TIME_NOT_MEET = 155 ,
/**�������ų���ʱ��δ��**/
	ERRORCODE_IMPEACH_PRESIDENT_TIME_NOT_MEET = 156 ,
/**���ų������˳�����**/
	ERRORCODE_PRESIDENT_UNABLE_EXIT_LEGION = 157 ,
/**�����̵����Ʒ�����ڣ������ѹ���**/
	ERRORCODE_LEGION_SHOP_ITEM_NOT_EXIST = 158 ,
/**�㵱ǰû�м����κξ���**/
	ERRORCODE_NOT_JOINED_LEGION = 159 ,
/**���Ѿ������������**/
	ERRORCODE_ALREADY_JOINED_LEGION = 160 ,
/**ʱװǿ���ȼ���������**/
	ERRORCODE_FASHION_STRENGTHEN_LEVEL_LIMIT = 161 ,
/**ʱװ������**/
	ERRORCODE_FASHION_NOT_EXIST = 162 ,
/**���Ѿ������˸õ���**/
	ERRORCODE_ALREADY_BUY_PROP = 163 ,
/**���þ����½���Ϣ��������**/
	ERRORCODE_SET_LEGION_INFO_NOT_ENOUGH = 164 ,
/**�Ѿ��ﵽ�����Ÿ�����ִ�д���**/
	ERRORCODE_LEGION_RAID_LIMIT = 165 ,
/**���Ÿ�����Ϣ������Ϣ�ѹ���**/
	ERRORCODE_LEGION_RAID_INFO_EXPIRE = 166 ,
/**���Ÿ����Ѿ�����**/
	ERRORCODE_LEGION_RAID_FINISH = 167 ,
/**���Ÿ���û��ͨ��**/
	ERRORCODE_LEGION_RAID_NOT_PASS = 168 ,
/**��û�о��Ÿ����Ľ���**/
	ERRORCODE_LEGION_RAID_REWARD_NOT_EXIST = 169 ,
/**���Ѿ���ȡ�����Ÿ�������**/
	ERRORCODE_LEGION_RAID_REWARD_ALREADY_RECV = 170 ,
/**���ջ�콱������������**/
	ERRORCODE_FEAST_ACTIVITY_REWARD_LIMIT = 171 ,
/**���ջ��δ����**/
	ERRORCODE_FEAST_ACTIVITY_NOT_OPEN = 172 ,
/**�˵����ѹ���**/
	ERRORCODE_PROP_EXPIRE = 173 ,
/**�ñ����Ѿ������˽����ȵ���**/
	ERRORCODE_BOX_OTHER_RECV = 174 ,
/**�Ƿ����Ŷ��⹫��**/
	ERRORCODE_ILLEGAL_LEGION_OUTSIDE_NOTICY = 175 ,
/**�Ƿ����Ŷ��ڹ���**/
	ERRORCODE_ILLEGAL_LEGION_INSIDE_NOTICY = 176 ,
/**��Ʒ��Ĳ�������**/
	ERRORCODE_GIFT_CODE_TOO_FAST = 177 ,
/**��ǰ�����ھ���ʱ����ȴ��**/
	ERRORCODE_LEGION_TIME_COOLING = 178 ,
/**��Ҿ������벻����**/
	ERRORCODE_LEGION_APPLY_NOT_EXIST = 179 ,
/**���ż����Ѵﵽ���ֵ**/
	ERRORCODE_LEGION_WORSHIP_LIMIT = 180 ,
/**�������Ѿ��ﵽ��������**/
	ERRORCODE_SERVER_LIMIT = 181 ,
/**�����̳���Ʒ�Ѿ�����**/
	ERRORCODE_LEGION_SHOP_SELL_OUT = 182 ,
/**�����������ڴ���24Сʱ�޷���ɢ**/
	ERRORCODE_LEGION_CREATE_DAILY_NOT_DISSOLVE = 183 ,
/**�޷������ճ���������**/
	ERRORCODE_UNABLE_BUY_DAILY_RAID_NUM = 184 ,
/**�䷵��Ѿ�����**/
	ERRORCODE_RECHARGE_REBATE_ACT_FINISH = 185 ,
/**�������Ƶ��**/
	ERRORCODE_REQUEST_TOO_OFTEN = 186 ,
/**�޷���ȡ��������Ϊ���������������Ѿ���ȡ��**/
	ERRORCODE_OTHER_SERVER_ALREADY_RECVB = 187 ,
/**�䷵��ȡʧ��**/
	ERRORCODE_RECHARGE_REBATE_RECV_FAILED = 188 ,
/**����װ����������**/
	ERRORCODE_AWAKEN_BAG_FULL = 189 ,
/**ת�̻��ֲ���**/
	ERRORCODE_TURNTABLE_SCORE_NOT_ENOUGH = 190 ,
/**ת���ܻ��ֲ���**/
	ERRORCODE_TURNTABLE_ALL_SCORE_NOT_ENOUGH = 191 ,
/**����װ����������**/
	ERRORCODE_AWAKEN_EQUIP_NUM_NOT_ENOUGH = 192 ,
/**�佫���ܾ���**/
	ERRORCODE_HERO_UNABLE_AWAKEN = 193 ,
/**�佫����װ��λ�ò���**/
	ERRORCODE_HERO_AWAKEN_EQUIP_POS_ERROR = 194 ,
/**�þ���װ���Ѿ�������**/
	ERRORCODE_AWAKEN_EQUIP_NOT_EXIST = 195 ,
/**�佫���ѵȼ��ѳ�������**/
	ERRORCODE_AWAKEN_LEVEL_LIMIT = 196 ,
/**�佫���ѵ���δ����**/
	ERRORCODE_HERO_AWAKEN_EQUIP_NOT_ALL = 197 ,
/**�佫���Ѳ��Ͽ�����������**/
	ERRORCODE_AWAKEN_MATERIAL_NOT_ENOUGH = 198 ,
/**�佫���Ѳ��Ͽ��ƴ���**/
	ERRORCODE_AWAKEN_MATERIALERR = 199 ,
/**�����佫������Ϊ���Ѳ���**/
	ERRORCODE_PLAY_HERO_AWAKEN_MATERIAL = 200 ,
/**��û���㹻�����**/
	ERRORCODE_GOD_SOUL_NOT_ENOUGH = 201 ,
/**�þ�����������**/
	ERRORCODE_LEGION_APPLY_FULL = 202 ,
/**���Ÿ�����������ﵽ����**/
	ERRORCODE_LEGION_RAID_BUY_LIMIT = 203 ,
/**�ƺ���װ��**/
	ERRORCODE_EPITHET_ALREADY_WEAR = 204 ,
/**�ƺ��ѹ���**/
	ERRORCODE_EPITHET_ALREADY_EXPIRE = 205 ,
/**����ѫ�²��㹻**/
	ERRORCODE_MEDAL_NOT_ENOUGH = 206 ,
/**������ʤ��������**/
	ERRORCODE_JOUST_WINNING_STREAK_NOT_ENOUGH = 208 ,
/**��ʱ����δ����**/
	ERRORCODE_TIMED_RAID_NOT_OPEN = 209 ,
/**��ʱ������ս�����**/
	ERRORCODE_TIMED_RAID_DEKARON_FINISH = 210 ,
/**ת�̻�ѽ���**/
	ERRORCODE_TURNTABLE_ACTIVITY_FINISH = 211 ,
/**���̻�ѽ���**/
	ERRORCODE_RICHMAN_ACTIVITY_FINISH = 212 ,
/**δ֪�۸�����**/
	ERRORCODE_UNKNOW_PRICE_TYPE = 213 ,
/**��ǰû�л����**/
	ERRORCODE_NOT_ACTIVITY_ON = 214 ,
/**��Ҳ����߻򲻴���**/
	ERRORCODE_PLAYER_OFFLINE_OR_NOT_EXIST = 215 ,
/**�ʼ����ȳ���**/
	ERRORCODE_MAIL_LEN_LIMIT = 216 ,
/**��Ӣ����״̬����**/
	ERRORCODE_ELITE_RAID_STATE_ERR = 217 ,
/**���ս���������Ƶ��**/
	ERRORCODE_FIGHT_FREQUENTLY = 218 ,
/**���������Ҫ�ָ�**/
	ERRORCODE_PLAYER_DATA_NEED_RESET = 219 ,
/**�㽨����С�������Ѿ��ﵽ������**/
	ERRORCODE_ACCOUNT_NUM_LIMIT = 220 ,
/**�ͻ����������**/
	ERRORCODE_CLIENT_REQUEST_ERR = 221 ,
/**�Ѿ�boss���δ����**/
	ERRORCODE_REBEL_BOSS_NOT_OPEN = 222 ,
/**�����ս��������**/
	ERRORCODE_DEKARON_NUM_NOT_ENOUGH = 223 ,
/**��Ľ����Ѿ���ȡ**/
	ERRORCODE_REWARD_ALREADY_RECV = 224 ,
/**boss�Ѿ�����**/
	ERRORCODE_BOSS_ALREADY_DEAD = 225 ,
/**���û�Ϊ�ڿ�����û�**/
	ERRORCODE_PLAYER_ALREADY_BAN = 226 ,
/**���Ѿ�ѡ�����Ӫ**/
	ERRORCODE_CAMP_ALREADY_CHOOSE = 227 ,
/**�ƹ���ҵĵȼ�����**/
	ERRORCODE_SEM_USER_LV_NOT_ENOUGH = 228 ,
/**�ƹ�����Ѿ��ﵽ�������**/
	ERRORCODE_SEM_USER_MAX = 229 ,
/**�ƹ㽱����ȡʧ��**/
	ERRORCODE_SEM_REWARD_RECV_ERR = 230 ,
/**����ƹ���ֲ���**/
	ERRORCODE_SEM_SCORE_NOT_ENOUGH = 231 ,
/**��������ʱ���Ѿ�������**/
	ERRORCODE_FORAGE_ROB_TIME_OVER = 232 ,
/**����������δ����**/
	ERRORCODE_FORAGE_ROB_NOT_OPEN = 233 ,
/**��û�м�����������ս**/
	ERRORCODE_FORAGE_ROB_NOT_JOINED = 234 ,
/**�㴦�ڶ���ƥ�����ȴʱ����**/
	ERRORCODE_FIT_MATCH_COOLING = 235 ,
/**����ʣ���������**/
	ERRORCODE_FORAGE_ROB_NUM_NOT_ENOUGH = 236 ,
/**���ڶ�����ȴʱ����**/
	ERRORCODE_FORAGE_ROB_COOLING = 237 ,
/**�Է����ڶԷ��б���**/
	ERRORCODE_OTHER_SIDE_NOT_IN_LIST = 238 ,
/**��ĸ����������**/
	ERRORCODE_REVENGE_NUM_NOT_ENOUGH = 239 ,
/**�ó��˲�������**/
	ERRORCODE_ENEMY_NOT_EXIST = 240 ,
/**�����Ѹ���**/
	ERRORCODE_ENEMY_ALREADY_REVENGE = 241 ,
/**�ɾ�ID����**/
	ERRORCODE_ACHIEVE_ID_ERR = 242 ,
/**�óɾ�δ���**/
	ERRORCODE_ACHIEVE_NOT_REACHED = 243 ,
/**���ɶԸ���Ҿ͸���**/
	ERRORCODE_CAN_NOT_USER_REVENGE = 244 ,
/**��ʱ�Ż��̵����Ʒ����**/
	ERRORCODE_TIME_LIMIT_SHOP_ITEM_NOT_ENOUGH = 245 ,
/**��ʱ�Ż���δ��ʼ**/
	ERRORCODE_TIME_LIMIT_DISCOUNT_NOT_OPEN = 246 ,
/**���Ѿ��ﵽ�˹�������**/
	ERRORCODE_BUY_ITEM_LIMIT = 247 ,
/**��ʱ�Ż��̵��ȫ�������Ѿ���ȡ**/
	ERRORCODE_DISCOUNT_ALL_SEV_WELFARE_RECV = 248 ,
/**��ʱ�Ż��̵�ȫ������������ȡ**/
	ERRORCODE_DISCOUNT_ALL_SEV_WELFARE_UNABLE = 249 ,
/**�㵱ǰ������ȡ���а���**/
	ERRORCODE_RANK_REWARD_UNABLE_RECV = 250 ,
/**������а����Ѿ���ȡ**/
	ERRORCODE_RANK_REWARD_ALREADY_RECV = 251 ,
/**��������û���κν���**/
	ERRORCODE_FORAGE_RANK_NOT_REWARD = 252 ,
/**������������ѳ��������������**/
	ERRORCODE_FORAGE_TOKEN_BUY_LIMIT = 253 ,
/**�������Ƽ۸����**/
	ERRORCODE_FORAGE_TOKEN_PRICE_ERR = 254 ,
/**��ʱ�Ż��̵�δ�ҵ���ֵid**/
	ERRORCODE_TIME_LIMIT_SHOP_ID_ERR = 255 ,
/**��ʱ�Ż��̵�δ�ҵ���Ӧ��Ʒ**/
	ERRORCODE_TIME_LIMIT_SHOP_ITEM_ERR = 256 ,
/**�ƹ�Ƿ�����**/
	ERRORCODE_SEM_INPUT_ILLEGAL = 257 ,
/**�Ѿ�ע��**/
	ERRORCODE_ALREADY_REGISTER = 258 ,
/**���ڽ���ע���ϵ�����Ե�**/
	ERRORCODE_REGISTRATION = 259 ,
/**ע��ʧ�ܣ�������Ҳ���һ�������**/
	ERRORCODE_REGISTER_FAILED_NOT_SAME_SRV = 260 ,
/**�Ѿ�bossˢ���������Ƶ��**/
	ERRORCODE_REBEL_BOSS_REFRESH_FREQUENTLY = 261 ,
/**�Ѿ�bossս���������Ƶ��**/
	ERRORCODE_REBEL_BOSS_FIGHT_FREQUENTLY = 262 ,
/**ע��ʱ�����ʧ��**/
	ERRORCODE_REGISTER_CONN_SER_FAILED = 264 ,
/**���Ž������Ѿ���ȡ���ˣ������ظ���ȡ**/
	ERRORCODE_LEGION_REWARD_ALREADY_RECV = 265 ,
/**����ս��������ȡ��**/
	ERRORCODE_FORAGE_FIGHT_REWARD_ALREADY_RECV = 266 ,
/**�½ڽ�������ȡ��**/
	ERRORCODE_CHAPTER_REWARD_ALREADY_RECV = 267 ,
/**���Ÿ�����δ����**/
	ERRORCODE_LEGION_RAID_NOT_OPEN = 268 ,
/**�»������ô���**/
	ERRORCODE_MONTH_FUND_CONFIG_ERR = 269 ,
/**�»�����δ��ʼ**/
	ERRORCODE_MONTH_FUND_NOT_OPEN = 270 ,
/**�»����Ҳ����������**/
	ERRORCODE_MONTH_FUND_FIND_USER_ERR = 271 ,
/**�»�������ȡʱ��**/
	ERRORCODE_MONTH_FUND_NOT_RECV_TIME = 272 ,
/**���ս�������ȡ**/
	ERRORCODE_DAILY_REWARD_ALREADY_RECV = 273 ,
/**û�й�����»���**/
	ERRORCODE_NOT_BUY_MONTH_FUND = 274 ,
/**��ȼ���ƥ��**/
	ERRORCODE_ACTIVITY_LV_NOT_MATCH = 275 ,
/**�VIP�ȼ���ƥ��**/
	ERRORCODE_ACTIVITY_VIPLV_NOT_MATCH = 276 ,
/**38��������İ���˷����ʼ�**/
	ERRORCODE_LV38_SEND_MAIL_TO_STRANGER = 277 ,
/**ÿ�ն�İ���˷����ʼ��������ܳ���10��**/
	ERRORCODE_SEND_MAIL_TO_STRANGER_LIMIT = 278 ,
/**���ֹ⻷��ѽ���**/
	ERRORCODE_NOVICE_HALO_ACTIVITY_FINISH = 279 ,
/**��ʱ�齫����Ӫ�ѱ�**/
	ERRORCODE_LIMIT_TIME_LOTTERY_HERO_CHANGE = 280 ,
/**��ʱ�齫�Ĵ�������**/
	ERRORCODE_LIMIT_TIME_LOTTERY_HERO_LIMIT = 281 ,
/**��ʱ�齫�����彫������**/
	ERRORCODE_LIMIT_TIME_LOTTERY_MAIN_HERO = 282 ,
/**��������ֵ����**/
	ERRORCODE_STAR_LUCK_NOT_ENOUGH = 283 ,
/**���Ĺ����������**/
	ERRORCODE_BUY_COUNT_NOT_ENOUGH = 284 ,
/**����Ź��콱�����쳣**/
	ERRORCODE_GROUPON_RECV_REWARD_EXCEPTION = 285 ,
/**�����콱���ֲ���**/
	ERRORCODE_REWARD_SCORE_NOT_ENOUGH = 286 ,
/**����ȫ���콱���ֲ���**/
	ERRORCODE_ALL_SRV_REWARD_SCORE_NOT_ENOUGH = 287 ,
/**����Ź������Ѿ���ȡ����**/
	ERRORCODE_GROUPON_REWARD_ALREADY_RECV = 288 ,
/**����ʱ�Ź�������Ԫ�������쳣**/
	ERRORCODE_GROUPON_REBATE_YUANBAO_EXCEPTION = 289 ,
/**���Ź���vip�ȼ�����**/
	ERRORCODE_GROUPON_VIPLV_NOT_ENOUGH = 290 ,
/**����Ź��ȼ������쳣**/
	ERRORCODE_GROUPON_LV_EXCEPTION = 291 ,
/**��ʱ�Ź���ǰ���ܹ���**/
	ERRORCODE_LIMIT_TIME_GROUPON_UNABLE_BUY = 292 ,
/**��ʱ�Ź���������쳣**/
	ERRORCODE_LIMIT_TIME_GROUPON_EXCEPTION = 293 ,
/**�û���ڻʱ��**/
	ERRORCODE_ACTIVITY_TIME_EXPIRE = 294 ,
/**�Ź������콱ʱ��**/
	ERRORCODE_GROUPON_NOT_IN_RECV_TIME = 295 ,
/**�Ź���������쳣**/
	ERRORCODE_GROUPON_USER_DATA_EXCEPTION = 296 ,
/**����ͷ������쳣**/
	ERRORCODE_REPLACE_HEAD_ICON_EXCEPTION = 297 ,
/**ս�豳������**/
	ERRORCODE_BATTLE_PET_BAG_FULL = 298 ,
/**�����ڱ�ս��**/
	ERRORCODE_BATTLE_PET_NOT_EXIST = 299 ,
/**�ó���������**/
	ERRORCODE_BATTLE_PET_ALREADY_PLAY = 300 ,
/**δ���������һ�ص�����**/
	ERRORCODE_NEXT_PASS_COND_NOT_MEET = 301 ,
/**�޷����ð�սɳ��**/
	ERRORCODE_UNABLE_RESET_BATTLEFIELD = 302 ,
/**��սɳ����Ϣ����**/
	ERRORCODE_BATTLEFIELD_INFO_EXPIRE = 303 ,
/**�����ز��콱ʧ��**/
	ERRORCODE_RECV_ARSENALS_REWARD_FAILED = 304 ,
/**���ؿ��ѱ�����**/
	ERRORCODE_RAID_ALREADY_BEAT = 305 ,
/**���ڼ��أ����Ե�**/
	ERRORCODE_LOADING = 306 ,
/**ս���̵�ˢ�´�������**/
	ERRORCODE_PET_SHOP_REFRESH_LIMIT = 307 ,
/**��ǰ�½ڹ��ͣ��޷���ȡ����**/
	ERRORCODE_CHAPTER_LOW_UNABLE_RECV_REWARD = 308 ,
/**�޻겻�㹻**/
	ERRORCODE_BEAST_SOUL_NOT_ENOUGH = 309 ,
/**�����㹻**/
	ERRORCODE_JADE_NOT_ENOUGH = 310 ,
/**���Ź��ײ��㹻**/
	ERRORCODE_DEVOTE_NOT_ENOUGH = 311 ,
/**���λ��ֲ��㹻**/
	ERRORCODE_SCORE_NOT_ENOUGH = 312 ,
/**��Ƭ���㹻**/
	ERRORCODE_CHIP_NUM = 313 ,
/**����ʧ�ܣ���Ҫ���ò��ܼ�������**/
	ERRORCODE_TOWER_NEED_RESET = 314 ,
/**�Ѿ�����δ��ʼ**/
	ERRORCODE_REBEL_NOT_OPEN = 315 ,
/**�Ѿ��Ѿ�����**/
	ERRORCODE_REBEL_JUMPED_WAY = 316 ,
/**�ԻƹϽ�������ȡ**/
	ERRORCODE_ALREADY_EAT_CUCUMBER = 317 ,
/**δ���Իƹ�ʱ��**/
	ERRORCODE_NOT_EAT_CUCUMBER_TS = 318 ,
/**�����Ѿ���ȡ��[7���ճ�����(��Ʒ����)]**/
	ERRORCODE_REWARD_ALREADY_RECEIVE_END = 319 ,
/**����������**/
	ERRORCODE_NOT_ALLOWED_SELL = 320 ,
/**���޴���������**/
	ERRORCODE_AVAILABLE_TIMES_DEPLETE = 321 ,
/**�������״̬����**/
	ERRORCODE_SPAN_SRV_LEGION_STATE_ERR = 1000 ,
/**��������Ѿ�����**/
	ERRORCODE_SPAN_SRV_LEGION_ALREADY_REGISTER = 1001 ,
/**�˿������δ����**/
	ERRORCODE_SPAN_SRV_LEGION_NOT_REGISTER = 1002 ,
/**������ű�������������**/
	ERRORCODE_SPAN_SRV_LEGION_REG_COND_ERR = 1004 ,
/**���ս��������ѳ�������������**/
	ERRORCODE_SPAN_SRV_INSPIRE_LEGION_LIMIT = 1005 ,
/**������賬�����������**/
	ERRORCODE_SPAN_SRV_INSPIRE_USER_LIMIT = 1006 ,
/**���ս��ˢ��CD��**/
	ERRORCODE_SPAN_SRV_FIGHT_REFRESH_COOLING = 1007 ,
/**���ս��CD��**/
	ERRORCODE_SPAN_SRV_FIGHT_COOLING = 1008 ,
/**���ڿ��ս��CD��**/
	ERRORCODE_SPAN_SRV_FIGHT_NOT_COOLING = 1009 ,
/**��ս��������**/
	ERRORCODE_BATTLEFIELD_NOT_EXIST = 1010 ,
/**��ѯ�쳣**/
	ERRORCODE_QUERY_EXCEPTION = 1011 ,
/**������ս��Ҵﵽ������**/
	ERRORCODE_LEGION_DEKARON_USER_LIMIT = 1013 ,
/**���������Լ�Ϊ����Ŀ��**/
	ERRORCODE_UNABLE_SET_SELF_TARGET = 1014 ,
/**����ս״̬������**/
	ERRORCODE_LEGION_STATE_IS_LOCKING = 1015 ,
/**���������æ**/
	ERRORCODE_SPAN_SRV_BUSY = 1016 ,
/**����������ô����ﵽ����**/
	ERRORCODE_SPAN_SRV_ENBU_RESET_LIMIT = 1017 ,
/**���������ս����Ϣ��������**/
	ERRORCODE_JOUST_SRV_BATTLEFIELD_ERR = 1018 ,
/**����״̬��������**/
	ERRORCODE_JOUST_STATE_ERR = 1019 ,
/**��������δѡ����Ӫ**/
	ERRORCODE_JOUST_USER_NOT_CHOSE_CAMP = 1020 ,
/**���Ѿ�û���κ�ˢ�´���**/
	ERRORCODE_REFRESH_COUNT_EXHAUSTION = 1021 ,
/**������������б����Ƶ��**/
	ERRORCODE_JOUST_USER_LIST_FREQUENTLY = 1022 ,
/**����ս���з�������**/
	ERRORCODE_FIGHT_ERR = 1023 ,
/**���Ѿ���ս����**/
	ERRORCODE_ALREADY_DEKARON = 1024 ,
/**���Ѿ�û���κ���ս����**/
	ERRORCODE_DEKARON_COUNT_FREQUENTLY = 1025 ,
/**��ȡ������Ϣʧ��**/
	ERRORCODE_GET_PEER_INFO_FAILED = 1026 ,
/**��δ����������������ʸ�**/
	ERRORCODE_COMPETITION_PERMISSION_DENIED = 1027 ,
/**Ͷע����**/
	ERRORCODE_BETTING_ERR = 1028 ,
/**�Ѿ���ȡ��ȫ������**/
	ERRORCODE_ALL_REWARD_ALREADY_RECV = 1029 ,
/**�������ڳ�ʼ��״̬**/
	ERRORCODE_REWARD_INIT_STATE = 1030 ,
/**��δ��ɽ�������**/
	ERRORCODE_REWARD_COND_NOT_MEET = 1031 ,
/**��������δ����**/
	ERRORCODE_COMPETITION_NOT_OPEN = 1032 ,
/**Ͷע���ڳ�ʼ��״̬**/
	ERRORCODE_BETTING_INIT_STATE = 1033 ,
/**Ͷע���ڽ���״̬**/
	ERRORCODE_BETTING_ACCOUNT_STATE = 1034 ,
/**��ս��Ϣ����**/
	ERRORCODE_DEKARON_INFO_ERR = 1035 ,
/**��������ڱ���ս**/
	ERRORCODE_USER_IS_DEKARON = 1036 ,
/**Ͷע�Ѿ���������**/
	ERRORCODE_BETTING_LIMIT = 1037 ,
/**���Ѿ���ȡ��Ͷע����**/
	ERRORCODE_BETTING_REWARD_ALREADY_RECV = 1038 ,
/**�����Ϣ��ȡʧ��**/
	ERRORCODE_GET_PLAYER_INFO_FAILED = 1039 ,
/**�������Ѿ�ǩ������**/
	ERRORCODE_REPEAT_SIGN = 1040 ,
/**��û�пɲ�ǩ��������**/
	ERRORCODE_NO_NEED_SPEND_SIGN = 1041 ,
/**��û�п���ȡ���ۼ�ǩ��������**/
	ERRORCODE_HAVE_NO_SIGN_REWARD = 1042 ,
/**�ۼ�ǩ������δ�ﵽҪ��**/
	ERRORCODE_LESS_SIGN_DAYS = 1043 ,
/**���ȶԽ������ǩ��**/
	ERRORCODE_MUST_SIGN_TODAY = 1044 ,
/**ҡǮ��������ȴ��**/
	ERRORCODE_MONEY_TREE_CD = 1045 ,
/**ҡǮ�����н����Ѿ���ȡ����**/
	ERRORCODE_MONEY_TREE_DONE = 1046 ,
/**ǿ���������ı��ﲻ���Ե�������**/
	ERRORCODE_INVALID_TREASURE_MATERIAL = 1047 ,
/**���ͥ�Ѿ�������**/
	ERRORCODE_DAHUANGTING_LEVEL_MAX = 1048 ,
/**����ս����������**/
	ERRORCODE_ELITE_TOWER_COUNT_LIMIT = 1049 ,
/**�Ѿ��Ѿ�����**/
	ERRORCODE_REBEL_IS_DEAD = 1050 ,
/**���Ѿ��Ѿ���������**/
	ERRORCODE_REBEL_NOT_EXIST = 1051 ,
/**�𽫲��ܱ��ֽ�**/
	ERRORCODE_GOLD_CARD_DENY_FENJIE = 1052 ,
/**�����չ���Ӣ��ս�����Ѵ�����**/
	ERRORCODE_TOWER_ELITE_BUY_LIMIT = 1053 ,
/**��������սѩ���������Ѵ�����**/
	ERRORCODE_FAMOUS_RAID_LIMIT = 1054 ,
/**�������ô������þ�**/
	ERRORCODE_TOWER_RESET_LIMIT = 1055 ,
/**����Ҫ����VIP�ȼ�����ʹ�øù���**/
	ERRORCODE_FUNC_NEED_VIP_LEVEL = 1056 ,
/**���������øø��������Ѵ�����**/
	ERRORCODE_RAID_RESET_LIMIT = 1057 ,
/**������ھ�����**/
	ERRORCODE_ROLE_IN_LEGION = 1058 ,
/**���û�о���**/
	ERRORCODE_ROLE_NOT_IN_LEGION = 1059 ,
/**LOGO�Ƿ�**/
	ERRORCODE_LEGION_LOGO_INVALID = 1060 ,
/**��Ҳ��Ǿ��ų�**/
	ERRORCODE_NOT_LEGION_HEAD = 1061 ,
/**���ų�Ա����**/
	ERRORCODE_LEGION_MEMBER_NUM_LIMIT = 1062 ,
/**������ˢ�´����Ѵ�����**/
	ERRORCODE_SHOP_REFRESH_LIMIT = 1063 ,
/**VIP���ֲ���**/
	ERRORCODE_VIP_SCORE_NOT_ENOUGH = 1064 ,
/**���û����þ���**/
	ERRORCODE_LEGION_NOT_APPLIED = 1065 ,
/**������ȡ�ô���������**/
	ERRORCODE_BLUSHER_WOO_LIMIT = 1066 ,
/**ֻ���߳��¼�**/
	ERRORCODE_CAN_ONLY_DEL_SUBORDINATE = 1067 ,
/**�Է��Ѳ��ھ���**/
	ERRORCODE_OTHER_NOT_IN_LEGION = 1068 ,
/**���ų�����**/
	ERRORCODE_LEGION_DEPUTY_FULL = 1069 ,
/**�Է����Ǹ��ų�**/
	ERRORCODE_OTHER_NOT_LEGION_DEPUTY = 1070 ,
/**VIP�ȼ���ƥ��**/
	ERRORCODE_VIP_LEVEL_MISMATCH = 1071 ,
/**�������Ѿ���ȡ���˸ø���**/
	ERRORCODE_REPEAT_DRAW_VIP_WELFARE = 1072 ,
/**�̳������ѹ���**/
	ERRORCODE_LEGION_LIMIT_SHOP_INFO_EXPIRED = 1073 ,
/**����Ʒ�Ѿ�����**/
	ERRORCODE_LEGION_LIMIT_SHOP_SOLD_OUT = 1074 ,
/**���ɼ�������Ѵ����ֵ**/
	ERRORCODE_LEGION_WORSHIP_COUNT_LIMIT = 1075 ,
/**�����Ѽ���**/
	ERRORCODE_LEGION_WORSHIP_DONE = 1076 ,
/**�ü��챦������ȡ**/
	ERRORCODE_LEGION_WORSHIP_BOX_OPENED = 1077 ,
/**�������ɵ�vip�ȼ�����**/
	ERRORCODE_CREATE_LEGION_VIP_LEVEL_LIMIT = 1078 ,
/**�����vip�ȼ�����**/
	ERRORCODE_LEGION_WORSHIP_VIP_LEVEL_LIMIT = 1079 ,
/**�ð��ɼ��ܵȼ��Ѵﵽѧϰ����**/
	ERRORCODE_LEGION_SKILL_LEARN_LIMIT = 1080 ,
/**�ð��ɼ��ܵȼ��Ѵﵽ�о�����**/
	ERRORCODE_LEGION_SKILL_RESEARCH_LIMIT = 1081 ,
/**���ɾ��鲻��**/
	ERRORCODE_LEGION_EXP_NOT_ENOUGH = 1082 ,
/**���ɵȼ�����**/
	ERRORCODE_LEGION_LEVEL_LIMIT = 1083 ,
/**�һ��Ѵﵽ����**/
	ERRORCODE_EXCHANGE_COUNT_LIMIT = 1084 ,
/**��������Ϣ������**/
	ERRORCODE_LEGION_MESSAGE_NOT_EXIST = 1085 ,
/**��������Ϣ���ö�**/
	ERRORCODE_LEGION_MESSAGE_ALREADY_STICKY = 1086 ,
/**��������Ϣû�ö�**/
	ERRORCODE_LEGION_MESSAGE_NOT_STICKY = 1087 ,
/**10����ֻ������һ��**/
	ERRORCODE_LEGION_MESSAGE_INTERVAL_LIMIT = 1088 ,
/**��������ʱ�䲻��7��**/
	ERRORCODE_LEGION_HEAD_OFFLINE_LIMIT = 1089 ,
/**�Ѿ����˵�������**/
	ERRORCODE_LEGION_IMPEACH_ALREADY_BEGIN = 1090 ,
/**�Ѿ�����߲���**/
	ERRORCODE_TOWER_LADDER_SWEEP_MAX = 1091 ,
/**�뿪���ɺ�Ҫ24Сʱ֮��������½�������**/
	ERRORCODE_LEGION_OUT_TIME_LIMIT = 1092 ,
/**�ó�Ա��ﲻ��24Сʱ�������߳�**/
	ERRORCODE_LEGION_IN_TIME_LIMIT = 1093 ,
/**���ʹﵽ50�����ܾ���**/
	ERRORCODE_AWAKEN_LEVEL_NOT_ENGOUGH = 1094 ,
/**�����ﵽ500����**/
	ERRORCODE_EXCEED_POWER_LIMIT = 1095 ,
/**�����ﵽ200����**/
	ERRORCODE_EXCEED_ENERGY_LIMIT = 1096 ,
/**�������佫���ֽܷ������**/
	ERRORCODE_HERO_IS_NOT_IDLE = 1097 ,
/**�Ѵ�����װ�����ֽܷ������**/
	ERRORCODE_EQUIP_IS_NOT_IDLE = 1098 ,
/**�Ѵ����ı��ﲻ�ֽܷ������**/
	ERRORCODE_TREASURE_IS_NOT_IDLE = 1099 ,
/**����������ά����**/
	ERRORCODE_SERVER_IN_MAINTENANCE = 1100 ,
/**Ѱ��ս������**/
	ERRORCODE_VISIT_POWER_NOT_ENOUGH = 1101 ,
/**Ѱ�õȼ�����**/
	ERRORCODE_VISIT_LEVEL_NOT_ENOUGH = 1102 ,
/**���߲���**/
	ERRORCODE_TERRITORY_ITEM_NOT_ENOUGH = 1103 ,
/**ʹ�õ��������ﵽ����**/
	ERRORCODE_TERRITORY_USE_ITEM_LIMIT = 1104 ,
/**���յ����ˢ�´����Ѵ�����**/
	ERRORCODE_TERRITORY_FREE_REFRESH_LIMIT = 1105 ,
/**���յ���ս����������**/
	ERRORCODE_TERRITORY_FIGHT_CNT_LIMIT = 1106 ,
/**��ǰû����ҿ���Ѱ��**/
	ERRORCODE_NO_VISIT_ROUTE_EXIST = 1107 ,
/**ֱ�ӹ����˾ݵ�**/
	ERRORCODE_FORTRESS_DIRECT_WIN = 1108 ,
/**�ݵ��Ѿ���ʧ**/
	ERRORCODE_FORTRESS_HAS_BEEN_LOST = 1109 ,
/**�ݵ����ڱ�����**/
	ERRORCODE_FORTRESS_IN_PROTECTION = 1110 ,
/**δ�ﵽ��ȡ����**/
	ERRORCODE_FORTRESS_CAN_NOT_DRAW_BOX = 1111 ,
/**�ý����Ѿ���ȡ����**/
	ERRORCODE_FORTRESS_REPEAT_DRAW_BOX = 1112 ,
/**û���ܿ���ӱ޵�Ѱ��·��**/
	ERRORCODE_VISIT_NO_ROUTE_CAN_SPEEDUP = 1113 ,
/**���ܶԸ�Ѱ��·�߿���ӱ�**/
	ERRORCODE_VISIT_ROUTE_CANNOT_SPEEDUP = 1114 ,
/**������ͣս�ڣ�������ս**/
	ERRORCODE_FORTRESS_STOP_FIGHT = 1115 ,
/**�Ѵﵱ�������ȡǮ����**/
	ERRORCODE_VISIT_REWARD_COUNT_LIMIT = 1116 ,
/**û�п���ȡ������·��**/
	ERRORCODE_NO_VISIT_ROUTE_REWARD = 1117 ,
/**δ������ʱ��**/
	ERRORCODE_TERRITORY_NOT_OPEN = 1118 ,
/**�ѹ��򿪷�����**/
	ERRORCODE_ALREADY_BUY_OPEN_FUND = 1119 ,
/**δ���򿪷�����**/
	ERRORCODE_HAS_NOT_BUY_OPEN_FUND = 1120 ,
/**�ÿ�������������ȡ**/
	ERRORCODE_HAS_GET_OPEN_FUND = 1121 ,
/**δ�ﵽָ���ȼ�**/
	ERRORCODE_OPEN_FUND_LEVEL_LIMIT = 1122 ,
/**��ȫ��������ȡ**/
	ERRORCODE_HAS_GET_WELFARE = 1123 ,
/**���򿪷���������δ�ﵽָ������**/
	ERRORCODE_WELFARE_BUY_NUM_LIMIT = 1124 ,
/**�������Ʒ������**/
	ERRORCODE_NO_MATCHING_PRODUCT = 1125 ,
/**��Ʒ��������**/
	ERRORCODE_PRODUCT_NUM_WRONG = 1126 ,
/**���ÿ������ظ�����**/
	ERRORCODE_MONTH_CARD_CANNOT_REPEAT = 1127 ,
/**δ���¿��ɹ���ʱ��**/
	ERRORCODE_MONTH_CARD_TIME_LIMIT = 1128 ,
/**�¿�����һ��ֻ����ȡһ��**/
	ERRORCODE_SAME_DAY_GET_TWICE = 1129 ,
/**�¿��ѹ���**/
	ERRORCODE_MONTH_CARD_DEADLINE = 1130 ,
/**��δ�������սʱ��**/
	ERRORCODE_NOT_WUDI_FIGHT_TIME = 1131 ,
/**����Ѿ���������**/
	ERRORCODE_WUDI_HAS_DIED = 1132 ,
/**���Ѿ�û����ս������**/
	ERRORCODE_WUDI_FIGHT_CNT_LIMIT = 1133 ,
/**��ս��ȴʱ��δ��**/
	ERRORCODE_WUDI_FIGHT_CD_LIMIT = 1134 ,
/**������ս�����Ѵﵽ������**/
	ERRORCODE_WUDI_FIGHT_BUY_CNT_LIMIT = 1135 ,
/**û�ﵽ�ð���Ҫ��Ĺ���ȼ�**/
	ERRORCODE_LEGION_APPLY_VIP_LIMIT = 1136 ,
/**û�ﵽ�ð���Ҫ��ĵȼ�**/
	ERRORCODE_LEGION_APPLY_LV_LIMIT = 1137 ,
/**û�ﵽ�ð���Ҫ���ս��**/
	ERRORCODE_LEGION_APPLY_FIGHT_LIMIT = 1138 ,
/**�ѻ���׳佱��**/
	ERRORCODE_FIRST_RECHARGE_AWARD_ALREADY_GET = 1139 ,
/**�ѹ���ͬ�����¿�**/
	ERRORCODE_MONTH_CARD_SAME_TYPE = 1140 ,
/**û�а��ɸ�����ս����**/
	ERRORCODE_LEGION_BOSS_NO_COUNT = 1141 ,
/**���ɸ�����ս��ȴ��**/
	ERRORCODE_LEGION_BOSS_IN_CD = 1142 ,
/**���ڰ��ɸ�����ս�涨ʱ��**/
	ERRORCODE_LEGION_BOSS_TIME_INVALID = 1143 ,
/**���ɵȼ����ͣ�δ�￪�����ɸ�������Ҫ��**/
	ERRORCODE_LEGION_BOSS_LEVEL_LIMIT = 1144 ,
/**�ý�������ȡ**/
	ERRORCODE_LEGION_BOSS_REWARD_GOT = 1145 ,
/**�ùظ���δ����**/
	ERRORCODE_LEGION_BOSS_NOT_OPEN = 1146 ,
/**�ùظ�����ͨ��**/
	ERRORCODE_LEGION_BOSS_KILLED = 1147 ,
/**����յĳ�ֵ����**/
	ERRORCODE_LUXURY_SIGN_RECHARGE_NOT_ENOUGH = 1148 ,
/**�ý�������ȡ**/
	ERRORCODE_LUXURY_SIGN_ALREADY_GET = 1149 ,
/**�ð����������룬�����ĵȴ��������**/
	ERRORCODE_LEGION_ALREADY_APPLIED = 1150 ,
/**������ȡ��������������**/
	ERRORCODE_RECV_FRIEND_ENERGY_LIMIT = 1151 ,
/**��Ч��������**/
	ERRORCODE_INVALID_RENAME = 1152 ,
/**�����˺Ŵ����쳣����������ϵ�ͷ���**/
	ERRORCODE_USER_BANED = 1153 ,
/**�þݵ�δ�������Ԥѡ���ݲ�����ս**/
	ERRORCODE_NOT_TAKEPARTIN_WUDI = 1154 ,
/**������ѷ�������Ѿ�**/
	ERRORCODE_REPEAT_SHARE_REBEL = 1155 ,
/**�����ͻ�ѹ���**/
	ERRORCODE_CHOUKA_HAS_EXPIRED = 1156 ,
/**�ڶԷ��������У����ܼ�Ϊ����**/
	ERRORCODE_IN_PEER_BLACKLIST = 1157 ,
/**��δ�ﵽװ����ʱװ��Ҫ��ĵȼ�**/
	ERRORCODE_FASHION_DRESS_LV_LIMIT = 1158 ,
/**��������ֵ����**/
	ERRORCODE_ZHAOHUAN_LUCK_NOT_ENOUGH = 1159 ,
/**ʱװ��������**/
	ERRORCODE_FASHION_NUM_NOT_ENOUGH = 1160 ,
/**�û�ѽ���**/
	ERRORCODE_TURNTABLE_ENDED = 1161 ,
/**�齱ʧ�ܣ���Ҫˢ������**/
	ERRORCODE_TURNTABLE_REWARD_FAIL = 1162 ,
/**�������Ѿ���������**/
	ERRORCODE_TASK_NOT_EXIST = 1163 ,
/**������δ���**/
	ERRORCODE_TASK_UNCOMLETED = 1164 ,
/**�û�ѽ���**/
	ERRORCODE_ZHAOCAIMAO_ENDED = 1165 ,
/**���н��ѳ���**/
	ERRORCODE_ZHAOCAIMAO_NO_MORE = 1166 ,
/**�������Ѵﵽ��������**/
	ERRORCODE_TASK_COUNT_LIMIT = 1167 ,
/**�������ѽ���**/
	ERRORCODE_CS_POINTS_RACE_ENDED = 1168 ,
/**���岻�㹻**/
	ERRORCODE_XIAYI_NOT_ENOUGH = 1169 ,
/**�������㹻**/
	ERRORCODE_YUELI_NOT_ENOUGH = 1170 ,
/**�ú������ֽܷ�**/
	ERRORCODE_GALLANT_CANNOT_FENJIE = 1171 ,
/**�ú�������ֱ�Ӻϳ�**/
	ERRORCODE_GALLANT_CANNOT_COMPOSE = 1172 ,
/**���Ѿ�����˶Է��������ظ���ս**/
	ERRORCODE_CS_POINTS_HAS_DIED = 1173 ,
/**��ȡ�Է������쳣**/
	ERRORCODE_CS_POINTS_OPPONENT_ERROR = 1174 ,
/**����Ŀ�Ѽ���**/
	ERRORCODE_GALLANT_ENTRY_ALREADY_ACTIVATE = 1175 ,
/**�����������ս��������**/
	ERRORCODE_CSPOINTSRACE_CNT_NOT_ENOUGH = 1176 ,
/**���������������������**/
	ERRORCODE_CSPOINTSRACE_HONOR_NOT_ENOUGH = 1177 ,
/**�����������ս�����Ѵ�����**/
	ERRORCODE_CSPOINTSRACE_CNT_MAX_LIMIT = 1178 ,
/**���������δ����**/
	ERRORCODE_CS_POINTS_RACE_NOT_OPEN = 1179 ,
/**���Ѹ���Է��������ظ�����**/
	ERRORCODE_CS_POINTS_RACE_HASREVENGED = 1180 ,
/**�����̵���ˢ��**/
	ERRORCODE_HAOXIA_SHOP_ALREADY_REFRESH = 1181 ,
/**����Ʒ�Ѿ�������**/
	ERRORCODE_LIMITED_TIME_BUY_EXPIRED = 1182 ,
/**�����ظ��������Ʒ**/
	ERRORCODE_LIMITED_TIME_BUY_REPEAT = 1183 ,
/**��������������ȡ**/
	ERRORCODE_GET_REBATE_ERROR = 1184 ,
/**�ѹ�������ȡ�Ľ�ֹʱ��**/
	ERRORCODE_GET_REBATE_DEADLINE = 1185 ,
/**�÷�����������������ѡ������������**/
	ERRORCODE_ERRORCODE_SERVER_IS_FULL = 1186 ,
/**����VIP�ȼ�����**/
	ERRORCODE_ERRORCODE_VIPLV_NOT_ENOUGH = 1187 ,
/**ս��ȼ����ܳ������ǵȼ�**/
	ERRORCODE_PET_LV_LIMIT = 1188 ,
/**����Ƶ����������ҵȼ��ﵽ20��**/
	ERRORCODE_CHAT_LV_LIMIT = 1189 ,
/**����Ƶ��������������¿�**/
	ERRORCODE_CHAT_MONTH_CARD_LIMIT = 1190 ,
/**�������������ά����**/
	ERRORCODE_CROSSSERVER_IN_MAINTAIN = 1191 ,
/**���޻��δ����**/
	ERRORCODE_NIAN_EVENT_NOT_BEGIN = 1192 ,
/**���޻�ѽ���**/
	ERRORCODE_NIAN_EVENT_END = 1193 ,
/**�����ѱ���ɱ**/
	ERRORCODE_NIAN_DEAD = 1194 ,
/**���޺������δ�ﵽ**/
	ERRORCODE_NIAN_PROGRESS_NOT_REACH = 1195 ,
/**���޺������ȡ**/
	ERRORCODE_NIAN_RED_PACKET_ALREADY_GET = 1196 ,
/**�����񻨲��ܹ���**/
	ERRORCODE_NIAN_FIREWORKS_CANT_BUY = 1197 ,
/**�ɾ�δ���**/
	ERRORCODE_ACHIEVEMENT_TASK_NOT_COMPLETE = 1198 ,
/**�ɾͽ�������**/
	ERRORCODE_ACHIEVEMENT_REWARD_HAVE_GOT = 1199 ,
/**��ս����������**/
	ERRORCODE_NO_PET_RAID_FIGHT_COUNT = 1200 ,
/**�ùؿ�������ս**/
	ERRORCODE_PET_RAID_CANNOT_FIGHT = 1201 ,
/**���ǳ��︱�����һ��**/
	ERRORCODE_PET_RAID_LAST_ID = 1202 ,
/**�ѵ����︱����ʷ��߹�**/
	ERRORCODE_PET_RAID_IS_MAX_COUNT = 1203 ,
/**һ��ͨ��ֻ����һ��**/
	ERRORCODE_PET_RAID_ALREADY_USE_ONE_KEY = 1204 ,
};
#endif