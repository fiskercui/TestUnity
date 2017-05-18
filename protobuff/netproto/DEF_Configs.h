#ifndef DEF_CONFIGS_H
#define DEF_CONFIGS_H
/**���ö������**/
enum DEF_Configs {
/**����**/
	E_CONF_PROPERTY_HP = 0 ,
/**����**/
	E_CONF_PROPERTY_ATT = 1 ,
/**���**/
	E_CONF_PROPERTY_DEFPY = 2 ,
/**ħ��**/
	E_CONF_PROPERTY_DEFMG = 3 ,
/**������**/
	E_CONF_PROPERTY_MINZHONGLV = 4 ,
/**������**/
	E_CONF_PROPERTY_SHANBILV = 5 ,
/**������**/
	E_CONF_PROPERTY_BAOJILV = 6 ,
/**������**/
	E_CONF_PROPERTY_JIANRENLV = 7 ,
/**�˺�����**/
	E_CONF_PROPERTY_ADDSHANGHAI = 8 ,
/**�˺�����**/
	E_CONF_PROPERTY_DECSHANGHAI = 9 ,
/**����**/
	E_CONF_ZY_MAINROLE = 0 ,
/**����**/
	E_CONF_ZY_BEILIANG = 1 ,
/**����**/
	E_CONF_ZY_LIYANG = 2 ,
/**��ç**/
	E_CONF_ZY_BEIMANG = 3 ,
/**����**/
	E_CONF_ZY_JIANGHU = 4 ,
/**����**/
	E_CONF_CARD_MAINROLE = 1 ,
/**�佫**/
	E_CONF_CARD_WUJIANG = 2 ,
/**����**/
	E_CONF_CARD_STATE_IDLE = 0 ,
/**����**/
	E_CONF_CARD_STATE_PLAY = 1 ,
/**Ԯ��**/
	E_CONF_CARD_STATE_CHEER = 2 ,
/**��**/
	E_CONF_GENDER_MALE = 1 ,
/**Ů**/
	E_CONF_GENDER_FEMALE = 0 ,
/**��**/
	E_CONF_COLOR_BAI = 1 ,
/**��**/
	E_CONF_COLOR_LV = 2 ,
/**��**/
	E_CONF_COLOR_LAN = 3 ,
/**��**/
	E_CONF_COLOR_ZI = 4 ,
/**��**/
	E_CONF_COLOR_CHENG = 5 ,
/**��**/
	E_CONF_COLOR_HONG = 6 ,
/**��**/
	E_CONF_COLOR_JIN = 7 ,
/**����**/
	E_CONF_PRO_MAINROLE = 0 ,
/**̹��**/
	E_CONF_PRO_TANK = 1 ,
/**DPS**/
	E_CONF_PRO_DPS = 2 ,
/**����**/
	E_CONF_PRO_FUZHU = 3 ,
/**����**/
	E_CONF_SELL_YINLIANG = 1 ,
/**Ԫ��**/
	E_SELL_YUANBAO = 2 ,
/**����������**/
	E_CONF_SELL_JJC = 3 ,
/**ħ�����**/
	E_CONF_SELL_MOSHEN = 4 ,
/**�ᱦ����**/
	E_CONF_SELL_DUOBAO = 5 ,
/**���**/
	E_CONF_SELL_WUHUN = 6 ,
/**����**/
	E_CONF_SELL_POWER = 7 ,
/**����**/
	E_CONF_SELL_ENERGY = 8 ,
/**���Ź���**/
	E_CONF_SELL_LEGION_DEVOTE = 9 ,
/**����**/
	E_CONF_HURT_PY = 1 ,
/**ħ��**/
	E_CONF_HURT_MG = 2 ,
/**����**/
	E_CONF_EQUIP_WUQI = 1 ,
/**�·�**/
	E_CONF_EQUIP_YIFU = 2 ,
/**ͷ��**/
	E_CONF_EQUIP_TOUSHI = 3 ,
/**����**/
	E_CONF_EQUIP_YAODAI = 4 ,
/**���װ��ֵ**/
	E_CONF_EQUIP_MAX = 5 ,
/**����**/
	E_CONF_TREASURE_ATTACK = 1 ,
/**����**/
	E_CONF_TREASURE_DEFENSE = 2 ,
/**����**/
	E_CONF_TREASURE_EXP = 3 ,
/**�����ֵ**/
	E_CONF_TREASURE_MAX = 4 ,
/**��**/
	E_CONF_EQUIPPRO_NONE = 0 ,
/**������**/
	E_CONF_EQUIPPRO_ATTPY = 1 ,
/**ħ������**/
	E_CONF_EQUIPPRO_ATTMG = 2 ,
/**�������**/
	E_CONF_EQUIPPRO_DEFPY = 3 ,
/**ħ������**/
	E_CONF_EQUIPPRO_DEFMG = 4 ,
/**Ѫ��**/
	E_CONF_EQUIPPRO_HP = 5 ,
/**ͬʱ������������ħ������**/
	E_CONF_EQUIPPRO_ATT = 6 ,
/**�������ٷֱ�**/
	E_CONF_EQUIPPRO_ATTPYRATIO = 7 ,
/**ħ�������ٷֱ�**/
	E_CONF_EQUIPPRO_ATTMGRATIO = 8 ,
/**��������ٷֱ�**/
	E_CONF_EQUIPPRO_DEFPYRATIO = 9 ,
/**ħ�������ٷֱ�**/
	E_CONF_EQUIPPRO_DEFMGRATIO = 10 ,
/**Ѫ���ٷֱ�**/
	E_CONF_EQUIPPRO_HPRATIO = 11 ,
/**ͬʱ�����﹥��ħ���ٷֱ�**/
	E_CONF_EQUIPPRO_ATTRATIO = 12 ,
/**������**/
	E_CONF_EQUIPPRO_MINGZHONG = 13 ,
/**������**/
	E_CONF_EQUIPPRO_SHANBI = 14 ,
/**������**/
	E_CONF_EQUIPPRO_BAOJI = 15 ,
/**������**/
	E_CONF_EQUIPPRO_RENXING = 16 ,
/**�˺��ӳɰٷֱ�**/
	E_CONF_EQUIPPRO_HURTRATIO = 17 ,
/**���˼ӳɰٷֱ�**/
	E_CONF_EQUIPPRO_MIANSHANGRATIO = 18 ,
/**����ŭ��ֵ**/
	E_CONF_EQUIPPRO_BASEANGER = 19 ,
/**ŭ���ָ�ֵ**/
	E_CONF_EQUIPPRO_ANGERHUIFU = 20 ,
/**ͬʱ���������ħ������ֵ**/
	E_CONF_EQUIPPRO_DEF = 21 ,
/**PVP����**/
	E_CONF_EQUIPPRO_PVPADDHURT = 22 ,
/**PVP����**/
	E_CONF_EQUIPPRO_PVPSUBHURT = 23 ,
/**ͬʱ���������ħ���ٷֱ�**/
	E_CONF_EQUIPPRO_DEFRATIO = 24 ,
/**����ӳ�**/
	E_CONF_EQUIPPRO_EXPRATE = 25 ,
/**ͬʱ���������������������ٷֱ�**/
	E_CONF_EQUIPPRO_ALLRATIO = 26 ,
/**����Ӫ1�˺�����**/
	E_CONF_EQUIPPRO_CAMP1_ADDHURT = 27 ,
/**����Ӫ2�˺�����**/
	E_CONF_EQUIPPRO_CAMP2_ADDHURT = 28 ,
/**����Ӫ3�˺�����**/
	E_CONF_EQUIPPRO_CAMP3_ADDHURT = 29 ,
/**����Ӫ4�˺�����**/
	E_CONF_EQUIPPRO_CAMP4_ADDHURT = 30 ,
/**����Ӫ1�˺�����**/
	E_CONF_EQUIPPRO_CAMP1_DECHURT = 31 ,
/**����Ӫ2�˺�����**/
	E_CONF_EQUIPPRO_CAMP2_DECHURT = 32 ,
/**����Ӫ3�˺�����**/
	E_CONF_EQUIPPRO_CAMP3_DECHURT = 33 ,
/**����Ӫ4�˺�����**/
	E_CONF_EQUIPPRO_CAMP4_DECHURT = 34 ,
/**װ������ö�����ֵ**/
	E_CONF_EQUIPPRO_MAX = 35 ,
/**װ��������X��**/
	E_CONF_JINGLIAN_X = 1 ,
/**���ﾫ����X��**/
	E_CONF_JINGLIANBAOWU_X = 2 ,
/**����ʱ�˺��ӳ�X%��XΪǧ�ֱ�**/
	E_CONF_EQUIPPRO_SPECIAL_1 = 1 ,
/**�յ�����ʱ���ָ������������ֵX%��������XΪǧ�ֱ�**/
	E_CONF_EQUIPPRO_SPECIAL_2 = 2 ,
/**ÿ���յ�ħ������ʱ���������˺���X%��XΪǧ�ֱ�**/
	E_CONF_EQUIPPRO_SPECIAL_3 = 3 ,
/**ÿ���յ�������ʱ���������˺���X%��XΪǧ�ֱ�**/
	E_CONF_EQUIPPRO_SPECIAL_4 = 4 ,
/**����ʱ���ӶԷ��������ֵ��X%��XΪǧ�ֱ�**/
	E_CONF_EQUIPPRO_SPECIAL_5 = 5 ,
/**�յ���������ʱ�������Ļָ�ֵ��**/
	E_CONF_EQUIPPRO_SPECIAL_6 = 6 ,
/**�յ���������ʱ���޵еĻغ�����**/
	E_CONF_EQUIPPRO_SPECIAL_7 = 7 ,
/**ÿ�ι���ʱx%�ĸ��ʽ���ɵ��˺�x%ת��Ϊ��������**/
	E_CONF_EQUIPPRO_SPECIAL_8 = 8 ,
/**��������������**/
	E_CONF_EQUIPPRO_SPECIAL_MAX = 9 ,
/**ȫ��װ��ǿ���ȼ����ڵ���X**/
	E_CONF_QIANGHUADASHI_1 = 1 ,
/**ȫ����ǿ���ȼ����ڵ���X**/
	E_CONF_QIANGHUADASHI_2 = 2 ,
/**ȫ��װ�������ȼ����ڵ���X**/
	E_CONF_QIANGHUADASHI_3 = 3 ,
/**ȫ���ﾫ���ȼ����ڵ���X**/
	E_CONF_QIANGHUADASHI_4 = 4 ,
/**����С���ȼ�����X**/
	E_CONF_QIANGHUADASHI_5 = 5 ,
/**����[����Ŀ��]��������**/
	E_CONF_SKILLADDTIVE_1 = 1 ,
/**����[����Ŀ��]��������**/
	E_CONF_SKILLADDTIVE_2 = 2 ,
/**����[����Ŀ��]�ı�����**/
	E_CONF_SKILLADDTIVE_3 = 3 ,
/**����[����Ŀ��]�ļ�����**/
	E_CONF_SKILLADDTIVE_4 = 4 ,
/**����[����Ŀ��]���˺��ӳ�**/
	E_CONF_SKILLADDTIVE_5 = 5 ,
/**����[����Ŀ��]���˺�����**/
	E_CONF_SKILLADDTIVE_6 = 6 ,
/**����[����Ŀ��]���﹥andħ��ǧ�ֱ�**/
	E_CONF_SKILLADDTIVE_7 = 7 ,
/**����[����Ŀ��]�����andħ��ǧ�ֱ�**/
	E_CONF_SKILLADDTIVE_8 = 8 ,
/**����[����Ŀ��]���������ֵǧ�ֱ�**/
	E_CONF_SKILLADDTIVE_9 = 9 ,
/**����[����Ŀ��]����Ӫ1�佫���˺��ӳ�**/
	E_CONF_SKILLADDTIVE_10 = 10 ,
/**����[����Ŀ��]����Ӫ2�佫���˺��ӳ�**/
	E_CONF_SKILLADDTIVE_11 = 11 ,
/**����[����Ŀ��]����Ӫ3�佫���˺��ӳ�**/
	E_CONF_SKILLADDTIVE_12 = 12 ,
/**����[����Ŀ��]����Ӫ4�佫���˺��ӳ�**/
	E_CONF_SKILLADDTIVE_13 = 13 ,
/**����[����Ŀ��]�Ļ���ŭ��ֵ**/
	E_CONF_SKILLADDTIVE_14 = 14 ,
/**����[����Ŀ��]��ŭ���ָ�ֵ**/
	E_CONF_SKILLADDTIVE_15 = 15 ,
/**����[����Ŀ��]�Ĺ���������ֵ**/
	E_CONF_SKILLADDTIVE_16 = 16 ,
/**����[����Ŀ��]����������ֵ**/
	E_CONF_SKILLADDTIVE_17 = 17 ,
/**����[����Ŀ��]�������ħ������ֵ**/
	E_CONF_SKILLADDTIVE_18 = 18 ,
/**����[����Ŀ��]���﹥��ħ���������ħ�����������ֵǧ�ֱ�**/
	E_CONF_SKILLADDTIVE_19 = 19 ,
/**����[����Ŀ��]�������ָ�Ч���ӳ�**/
	E_CONF_SKILLADDTIVE_20 = 20 ,
/**1-�﹥����**/
	E_CONF_BLUSHER_1 = 1 ,
/**2-�﹥����**/
	E_CONF_BLUSHER_2 = 2 ,
/**3-��������**/
	E_CONF_BLUSHER_3 = 3 ,
/**4-��������**/
	E_CONF_BLUSHER_4 = 4 ,
/**5-����**/
	E_CONF_BLUSHER_5 = 5 ,
/**6-����**/
	E_CONF_BLUSHER_6 = 6 ,
/**7-����**/
	E_CONF_BLUSHER_7 = 7 ,
/**8-����**/
	E_CONF_BLUSHER_8 = 8 ,
/**9-����**/
	E_CONF_BLUSHER_9 = 9 ,
/**�����¼�**/
	E_CONF_VISIT_EVENT_TYPE_1 = 1 ,
/**·���¼�**/
	E_CONF_VISIT_EVENT_TYPE_2 = 2 ,
/**��վ�¼�**/
	E_CONF_VISIT_EVENT_TYPE_3 = 3 ,
/**��վ�̶��¼�**/
	E_CONF_VISIT_EVENT_TYPE_4 = 4 ,
/**����ӱ��¼�**/
	E_CONF_VISIT_EVENT_TYPE_5 = 5 ,
/**��ʼ�¼�**/
	E_CONF_VISIT_EVENT_TYPE_6 = 6 ,
/**�յ��¼�**/
	E_CONF_VISIT_EVENT_TYPE_7 = 7 ,
/**����**/
	E_CONF_LEGION_POS_HEAD = 1 ,
/**������**/
	E_CONF_LEGION_POS_DEPUTY = 2 ,
/**����**/
	E_CONF_LEGION_POS_MEMBER = 3 ,
/**Ĭ�Ͽ���, û����**/
	E_CONF_LEGION_NO_LIMIT = 1 ,
/**���ɵȼ�����**/
	E_CONF_LEGION_LV_LIMIT = 2 ,
/**����ս��������**/
	E_CONF_LEGION_BATTLE_RANK_LIMIT = 3 ,
/**���ɸ���ͨ������**/
	E_CONF_LEGION_RAID_LIMIT = 4 ,
/**Ĭ��, ������**/
	E_CONF_LEGION_ACCEPT_NO_LIMIT = 0 ,
/**�ȼ�����**/
	E_CONF_LEGION_ACCEPT_LV_LIMIT = 1 ,
/**ս������**/
	E_CONF_LEGION_ACCEPT_FIGHT_LIMIT = 2 ,
/**VIP����**/
	E_CONF_LEGION_ACCEPT_VIP_LIMIT = 3 ,
/**ö�����ֵ**/
	E_CONF_LEGION_ACCEPT_MAX = 4 ,
/**�ͼ���**/
	E_CONF_VISIT_HORSE_LOW = 1 ,
/**�м���**/
	E_CONF_VISIT_HORSE_MID = 2 ,
/**�߼���**/
	E_CONF_VISIT_HORSE_HIGH = 3 ,
/**���ÿ�**/
	E_CONF_TIMELESS_CARD = 1 ,
/**�¿�**/
	E_CONF_MONTH_CARD = 2 ,
/**��ͨ����**/
	E_CONF_FIGHT_REWARD_DROP = 0 ,
/**�״ν���**/
	E_CONF_FIGHT_REWARD_FIRST_DROP = 1 ,
/**����**/
	E_CONF_SKILLTARGET_1 = 1 ,
/**�ҷ�ȫ��**/
	E_CONF_SKILLTARGET_2 = 2 ,
/**�ҷ�������ӪΪ1���佫**/
	E_CONF_SKILLTARGET_3 = 3 ,
/**�ҷ�������ӪΪ2���佫**/
	E_CONF_SKILLTARGET_4 = 4 ,
/**�ҷ�������ӪΪ3���佫**/
	E_CONF_SKILLTARGET_5 = 5 ,
/**�ҷ�������ӪΪ4���佫**/
	E_CONF_SKILLTARGET_6 = 6 ,
/**�ҷ����з���Ӫ1�佫**/
	E_CONF_SKILLTARGET_7 = 7 ,
/**�ҷ����з���Ӫ2�佫**/
	E_CONF_SKILLTARGET_8 = 8 ,
/**�ҷ����з���Ӫ3�佫**/
	E_CONF_SKILLTARGET_9 = 9 ,
/**�ҷ����з���Ӫ4�佫**/
	E_CONF_SKILLTARGET_10 = 10 ,
/**1-��Ѫ**/
	E_CONF_BUFFTYPE_1 = 1 ,
/**2-��Ѫ**/
	E_CONF_BUFFTYPE_2 = 2 ,
/**3-���������ֵ��none��**/
	E_CONF_BUFFTYPE_3 = 3 ,
/**4-���������ֵ��none��**/
	E_CONF_BUFFTYPE_4 = 4 ,
/**5-���﹥**/
	E_CONF_BUFFTYPE_5 = 5 ,
/**6-���﹥**/
	E_CONF_BUFFTYPE_6 = 6 ,
/**7-��ħ��**/
	E_CONF_BUFFTYPE_7 = 7 ,
/**8-��ħ��**/
	E_CONF_BUFFTYPE_8 = 8 ,
/**9-�����**/
	E_CONF_BUFFTYPE_9 = 9 ,
/**10-�����**/
	E_CONF_BUFFTYPE_10 = 10 ,
/**11-��ħ��**/
	E_CONF_BUFFTYPE_11 = 11 ,
/**12-��ħ��**/
	E_CONF_BUFFTYPE_12 = 12 ,
/**13-��������**/
	E_CONF_BUFFTYPE_13 = 13 ,
/**14-��������**/
	E_CONF_BUFFTYPE_14 = 14 ,
/**15-�ӻر���**/
	E_CONF_BUFFTYPE_15 = 15 ,
/**16-���ر���**/
	E_CONF_BUFFTYPE_16 = 16 ,
/**17-�ӱ�����**/
	E_CONF_BUFFTYPE_17 = 17 ,
/**18-��������**/
	E_CONF_BUFFTYPE_18 = 18 ,
/**19-�Ӽ�����**/
	E_CONF_BUFFTYPE_19 = 19 ,
/**20-��������**/
	E_CONF_BUFFTYPE_20 = 20 ,
/**21-���﹥andħ��**/
	E_CONF_BUFFTYPE_21 = 21 ,
/**22-���﹥andħ��**/
	E_CONF_BUFFTYPE_22 = 22 ,
/**23-�����andħ��**/
	E_CONF_BUFFTYPE_23 = 23 ,
/**24-�����andħ��**/
	E_CONF_BUFFTYPE_24 = 24 ,
/**25-�����˺��ӳ�**/
	E_CONF_BUFFTYPE_25 = 25 ,
/**26-�����˺��ӳ�**/
	E_CONF_BUFFTYPE_26 = 26 ,
/**27-�����˺�����**/
	E_CONF_BUFFTYPE_27 = 27 ,
/**28-�����˺�����**/
	E_CONF_BUFFTYPE_28 = 28 ,
/**29-ѣ�Σ��޷��ж���**/
	E_CONF_BUFFTYPE_29 = 29 ,
/**30-�������ӷ���**/
	E_CONF_BUFFTYPE_30 = 30 ,
/**31-�������ӷ���**/
	E_CONF_BUFFTYPE_31 = 31 ,
/**32-�����˺�����**/
	E_CONF_BUFFTYPE_32 = 32 ,
/**33-���Ͼ����չ����ܻظ�ŭ��**/
	E_CONF_BUFFTYPE_33 = 33 ,
/**34-���Ͼ����κ�����¶����ظ�ŭ��**/
	E_CONF_BUFFTYPE_34 = 34 ,
/**35-˯�ߣ��޷��ж����������ᱻ���ѣ�**/
	E_CONF_BUFFTYPE_35 = 35 ,
/**36-��Ѫ������Ѫʱ������**/
	E_CONF_BUFFTYPE_36 = 36 ,
/**37-���գ�ÿ�غϵ�Ѫ��**/
	E_CONF_BUFFTYPE_37 = 37 ,
/**38-���������ֵ����(ǧ�ֱ�)��Ѫ**/
	E_CONF_BUFFTYPE_38 = 38 ,
/**39-���������ֵ����(ǧ�ֱ�)��Ѫ**/
	E_CONF_BUFFTYPE_39 = 39 ,
/**40-�޵�**/
	E_CONF_BUFFTYPE_40 = 40 ,
/**41-�ӹ���Ѫ**/
	E_CONF_BUFFTYPE_41 = 41 ,
/**42-����Ѫ**/
	E_CONF_BUFFTYPE_42 = 42 ,
/**״̬��(һֱ��Ч�����ж����ٴ���-1�����)**/
	E_CONF_BUFF_STATE = 1 ,
/**DOT��(����Ч������-1����������ж�)**/
	E_CONF_BUFF_DOT = 2 ,
/**����BUFF**/
	E_CONF_BUFFADD_TYPE = 1 ,
/**����BUFF**/
	E_CONF_BUFFDEC_TYPE = 2 ,
/**�ܻ�������ʼʱ**/
	E_CONF_BUFF_PERF_STEP1 = 1 ,
/**����������֮��**/
	E_CONF_BUFF_PERF_STEP2 = 2 ,
/**��ͨ����**/
	E_CONF_SKILLTYPE_1 = 1 ,
/**ŭ������**/
	E_CONF_SKILLTYPE_2 = 2 ,
/**�ϻ�����**/
	E_CONF_SKILLTYPE_3 = 3 ,
/**���ϻ�����**/
	E_CONF_SKILLTYPE_4 = 4 ,
/**�׶μ���**/
	E_CONF_SKILLTYPE_10 = 10 ,
/**�з�Ĭ��Ŀ��**/
	E_CONF_SKILLRANGE_1 = 1 ,
/**�з�ȫ��**/
	E_CONF_SKILLRANGE_2 = 2 ,
/**�з����3��**/
	E_CONF_SKILLRANGE_3 = 3 ,
/**�з�ǰ��ȫ��**/
	E_CONF_SKILLRANGE_4 = 4 ,
/**�з�����ȫ��**/
	E_CONF_SKILLRANGE_5 = 5 ,
/**�ҷ�ȫ��**/
	E_CONF_SKILLRANGE_6 = 6 ,
/**����**/
	E_CONF_SKILLRANGE_7 = 7 ,
/**��Ĭ�϶���������**/
	E_CONF_SKILLRANGE_8 = 8 ,
/**�ҷ����һ��**/
	E_CONF_SKILLRANGE_9 = 9 ,
/**�ҷ�Ѫ���ٵ�һ��**/
	E_CONF_SKILLRANGE_10 = 10 ,
/**�Է�Ѫ���ٵ�һ��**/
	E_CONF_SKILLRANGE_11 = 11 ,
/**���ŵ���**/
	E_CONF_SKILLRANGE_12 = 12 ,
/**�ҷ�Ѫ���ٵ�������λ**/
	E_CONF_SKILLRANGE_13 = 13 ,
/**�������������λ**/
	E_CONF_SKILLRANGE_14 = 14 ,
/**����������������60%�ĵ�λ**/
	E_CONF_SKILLRANGE_15 = 15 ,
/**�з�ȫ����������80%�ĵ�λ**/
	E_CONF_SKILLRANGE_16 = 16 ,
/**�������2����λ**/
	E_CONF_SKILLRANGE_17 = 17 ,
/**��λ��������**/
	E_CONF_SKILLRANGE_18 = 18 ,
/**��λ����һ������ĵ��ˣ�ֻ�ж�λʱ�Ͳ����**/
	E_CONF_SKILLRANGE_19 = 19 ,
/**�̳����**/
	E_CONF_SKILLRANGE_20 = 20 ,
/**�з����һ��**/
	E_CONF_SKILLRANGE_21 = 21 ,
/**�Լ��ͼ������һ��**/
	E_CONF_SKILLRANGE_22 = 22 ,
/**����ʮ��**/
	E_CONF_SKILLRANGE_23 = 23 ,
/**�Լ��������������**/
	E_CONF_SKILLRANGE_24 = 24 ,
/**���ζԷ�ȫ�����**/
	E_CONF_SKILLRANGE_25 = 25 ,
/**��λ�з����ڣ����˶�λ��Ա��**/
	E_CONF_SKILLRANGE_26 = 26 ,
/**�����ܻ���Ѫ������10%**/
	E_CONF_SKILLRANGE_27 = 27 ,
/**��Ŀ��������ѡ���Լ�**/
	E_CONF_SKILLRANGE_28 = 28 ,
/**BUFF**/
	E_CONF_SKILLUSETYPE_0 = 0 ,
/**��Ѫ**/
	E_CONF_SKILLUSETYPE_1 = 1 ,
/**��Ѫ**/
	E_CONF_SKILLUSETYPE_2 = 2 ,
/**����������BUFF**/
	E_CONF_SKILLUSETYPE_3 = 3 ,
/**�������DEBUFF**/
	E_CONF_SKILLUSETYPE_4 = 4 ,
/**��������DOT**/
	E_CONF_SKILLUSETYPE_5 = 5 ,
/**��ŭ��**/
	E_CONF_SKILLUSETYPE_6 = 6 ,
/**��ŭ��**/
	E_CONF_SKILLUSETYPE_7 = 7 ,
/**���ǰ�α����˼�ŭ��**/
	E_CONF_SKILLUSETYPE_8 = 8 ,
/**Ŀ���´��ж�ǰ�����������DEBUFF**/
	E_CONF_SKILLUSETYPE_9 = 9 ,
/**��Ѫ��������ȫ�壬��������**/
	E_CONF_SKILLUSETYPE_10 = 10 ,
/**Ŀ���´��ж�ǰ�����������DEBUFF����û��������1��ŭ��**/
	E_CONF_SKILLUSETYPE_11 = 11 ,
/**����Ŀ��dot�������˺�������Ӧ�����ӳɣ����100��**/
	E_CONF_SKILLUSETYPE_12 = 12 ,
/**�ٻ�������**/
	E_CONF_SKILLUSETYPE_30 = 30 ,
/**��**/
	E_CONF_SKILLCOLOR_1 = 1 ,
/**��**/
	E_CONF_SKILLCOLOR_2 = 2 ,
/**��**/
	E_CONF_SKILLCOLOR_3 = 3 ,
/**��**/
	E_CONF_SKILLCOLOR_4 = 4 ,
/**��**/
	E_CONF_SKILLCOLOR_5 = 5 ,
/**��**/
	E_CONF_SKILLCOLOR_6 = 6 ,
/**��**/
	E_CONF_SKILLCOLOR_7 = 7 ,
/**����ŭ��**/
	E_CONF_ANGER_SUB = 1 ,
/**����ŭ��**/
	E_CONF_ANGER_ADD = 2 ,
/**ԭ�ز���**/
	E_CONF_SKILLPOS_1 = 1 ,
/**��Ļ����**/
	E_CONF_SKILLPOS_2 = 2 ,
/**Ŀ���������**/
	E_CONF_SKILLPOS_3 = 3 ,
/**�ܻ����������е����λ��**/
	E_CONF_SKILLPOS_4 = 4 ,
/**�ܻ����������е��м�λ��**/
	E_CONF_SKILLPOS_5 = 5 ,
/**�ܻ����������е��ұ�λ��**/
	E_CONF_SKILLPOS_6 = 6 ,
/**�ܻ����������е�ǰ��λ��**/
	E_CONF_SKILLPOS_7 = 7 ,
/**�ܻ����������еĺ���λ��**/
	E_CONF_SKILLPOS_8 = 8 ,
/**�з�2��λ��**/
	E_CONF_SKILLPOS_9 = 9 ,
/**�ҷ�2��λ��**/
	E_CONF_SKILLPOS_10 = 10 ,
/**�з��м�**/
	E_CONF_SKILLPOS_11 = 11 ,
/**�ҷ��м�**/
	E_CONF_SKILLPOS_12 = 12 ,
/**0.���κ��ô�������ߣ�**/
	E_CONF_ITEMUSE_TYPE_0 = 0 ,
/**1. ��ʹ�ã���ť��ʹ��**/
	E_CONF_ITEMUSE_TYPE_1 = 1 ,
/**2. ȥ���ף���ť��ȥ���ף�**/
	E_CONF_ITEMUSE_TYPE_2 = 2 ,
/**3. ȥ��������ť��ȥ������**/
	E_CONF_ITEMUSE_TYPE_3 = 3 ,
/**4. ȥϴ������ť��ȥϴ����**/
	E_CONF_ITEMUSE_TYPE_4 = 4 ,
/**5. ȥ�佫�⻷����ť��ȥ�⻷��������Ҳû�����ϵͳ��**/
	E_CONF_ITEMUSE_TYPE_5 = 5 ,
/**6. �����������̵ꣻ��ť�������̵ꣻ**/
	E_CONF_ITEMUSE_TYPE_6 = 6 ,
/**7. ���������ﾫ������ť�����ﾫ��**/
	E_CONF_ITEMUSE_TYPE_7 = 7 ,
/**8. �򿪳齫����ť��ȥ�鿨**/
	E_CONF_ITEMUSE_TYPE_8 = 8 ,
/**9. ������ʾ����δ�����ù��ܡ�**/
	E_CONF_ITEMUSE_TYPE_9 = 9 ,
/**10.��ȥXX��������������־ϵͳ**/
	E_CONF_ITEMUSE_TYPE_10 = 10 ,
/**11.��ȥ���֡�����������������������**/
	E_CONF_ITEMUSE_TYPE_11 = 11 ,
/**12.��ȥ���ѡ������ӵ����ѽ���**/
	E_CONF_ITEMUSE_TYPE_12 = 12 ,
/**13.nѡ1����**/
	E_CONF_ITEMUSE_TYPE_13 = 13 ,
/**14.��ȥ���֡�������������ϵͳ**/
	E_CONF_ITEMUSE_TYPE_14 = 14 ,
/**15.��ȥ��������ӳƺ�ϵͳ**/
	E_CONF_ITEMUSE_TYPE_15 = 15 ,
/**16.��ȥι�������ӳ��ﱳ��**/
	E_CONF_ITEMUSE_TYPE_16 = 16 ,
/**17.��ȥ���������ӳ��ﱳ��**/
	E_CONF_ITEMUSE_TYPE_17 = 17 ,
/**18.��ȥ���ǡ����ӳ��ﱳ��**/
	E_CONF_ITEMUSE_TYPE_18 = 18 ,
/**19.ȥ�һ� �����������̵�**/
	E_CONF_ITEMUSE_TYPE_19 = 19 ,
/**20.ȥ�һ� ��������֬�̵�**/
	E_CONF_ITEMUSE_TYPE_20 = 20 ,
/**1-�����(��ťʹ��)**/
	E_CONF_ITEM_TYPE_1 = 1 ,
/**2-�佫����ʯ**/
	E_CONF_ITEM_TYPE_2 = 2 ,
/**3-����־��Ƭ**/
	E_CONF_ITEM_TYPE_3 = 3 ,
/**4-�佫�⻷ʯ**/
	E_CONF_ITEM_TYPE_4 = 4 ,
/**5-�佫����ʯ**/
	E_CONF_ITEM_TYPE_5 = 5 ,
/**6-װ������ʯ**/
	E_CONF_ITEM_TYPE_6 = 6 ,
/**7-������**/
	E_CONF_ITEM_TYPE_7 = 7 ,
/**8-�����ָ��ࣨpvpֵ��(��ťʹ��)**/
	E_CONF_ITEM_TYPE_8 = 8 ,
/**9-�����ָ��ࣨpveֵ��(��ťʹ��)**/
	E_CONF_ITEM_TYPE_9 = 9 ,
/**10-��ļ��**/
	E_CONF_ITEM_TYPE_10 = 10 ,
/**11.����ʯ**/
	E_CONF_ITEM_TYPE_11 = 11 ,
/**12.ˢ����**/
	E_CONF_ITEM_TYPE_12 = 12 ,
/**13.��ս��**/
	E_CONF_ITEM_TYPE_13 = 13 ,
/**14. ���ﾫ��ʯ**/
	E_CONF_ITEM_TYPE_14 = 14 ,
/**15.���ܾ���**/
	E_CONF_ITEM_TYPE_15 = 15 ,
/**16.������ָ����Ѿ�ֵ������ťʹ�ã�**/
	E_CONF_ITEM_TYPE_16 = 16 ,
/**17.�����������**/
	E_CONF_ITEM_TYPE_17 = 17 ,
/**18.ʱװ����**/
	E_CONF_ITEM_TYPE_18 = 18 ,
/**19.�������**/
	E_CONF_ITEM_TYPE_19 = 19 ,
/**20.���ѵ���**/
	E_CONF_ITEM_TYPE_20 = 20 ,
/**21.nѡ1����(item_box_info)**/
	E_CONF_ITEM_TYPE_21 = 21 ,
/**22.ʱװ����(item_choose_info)**/
	E_CONF_ITEM_TYPE_22 = 22 ,
/**23.����ɫ��**/
	E_CONF_ITEM_TYPE_23 = 23 ,
/**24.�ƺŵ���**/
	E_CONF_ITEM_TYPE_24 = 24 ,
/**25.�ʻ�**/
	E_CONF_ITEM_TYPE_25 = 25 ,
/**26.�������**/
	E_CONF_ITEM_TYPE_26 = 26 ,
/**27.��������ʯ**/
	E_CONF_ITEM_TYPE_27 = 27 ,
/**28.��������ʯ**/
	E_CONF_ITEM_TYPE_28 = 28 ,
/**29.���Ű�������**/
	E_CONF_ITEM_TYPE_29 = 29 ,
/**30.�¿�����**/
	E_CONF_ITEM_TYPE_30 = 30 ,
/**1���佫Ե��**/
	E_CONF_YUANFEN_1 = 1 ,
/**2��װ��Ե��**/
	E_CONF_YUANFEN_2 = 2 ,
/**3������Ե��**/
	E_CONF_YUANFEN_3 = 3 ,
/**���߸���**/
	E_CONF_RAID_TYPE_MAIN = 1 ,
/**��Ӣ����**/
	E_CONF_RAID_TYPE_ELITE = 2 ,
/**�ճ�����**/
	E_CONF_RAID_TYPE_DAILY = 3 ,
/**��������**/
	E_CONF_RAID_TYPE_FAMOUS_HERO = 4 ,
/**�佫��Ƭ**/
	E_CONF_CHIP_WUJIANG = 1 ,
/**װ����Ƭ**/
	E_CONF_CHIP_EQUIP = 2 ,
/**������Ƭ**/
	E_CONF_CHIP_TREASURE = 3 ,
/**ʱװ��Ƭ**/
	E_CONF_CHIP_FASHION = 4 ,
/**������Ƭ**/
	E_CONF_CHIP_PET = 5 ,
/**����**/
	ITEM_TYPE_SILVER = 1 ,
/**Ԫ��**/
	ITEM_TYPE_YUENBO = 2 ,
/**����**/
	ITEM_TYPE_PROP = 3 ,
/**�佫**/
	ITEM_TYPE_HERO = 4 ,
/**װ��**/
	ITEM_TYPE_EQUIP = 5 ,
/**��Ƭ**/
	ITEM_TYPE_CHIP = 6 ,
/**����**/
	ITEM_TYPE_TREASURE = 7 ,
/**������Ƭ(���ϣ�������Ƭ��)**/
	ITEM_TYPE_TREASURE_CHIP = 8 ,
/**����id**/
	ITEM_TYPE_OTHER_DROP = 9 ,
/**�佫���Ǽ�**/
	ITEM_TYPE_HERO_STAR = 10 ,
/**�佫����Ӫ**/
	ITEM_TYPE_HERO_CAMP = 11 ,
/**�佫��Ǳ��**/
	ITEM_TYPE_HERO_POTENTIAL = 12 ,
/**��ӪΪ1���佫(���Ǽ�)**/
	ITEM_TYPE_HERO_CAMP1_STAR = 13 ,
/**��ӪΪ2���佫(���Ǽ�)**/
	ITEM_TYPE_HERO_CAMP2_STAR = 14 ,
/**��ӪΪ3���佫(���Ǽ�)**/
	ITEM_TYPE_HERO_CAMP3_STAR = 15 ,
/**��ӪΪ4���佫(���Ǽ�)**/
	ITEM_TYPE_HERO_CAMP4_STAR = 16 ,
/**װ��(����λ)**/
	ITEM_TYPE_EQUIP_POS = 17 ,
/**װ��(�Ǽ�)**/
	ITEM_TYPE_EQUIP_STAR = 18 ,
/**װ��(Ǳ��)**/
	ITEM_TYPE_EQUIP_POTENTIAL = 19 ,
/**װ����λΪ1(���Ǽ�)**/
	ITEM_TYPE_EQUIP_POS1_STAR = 20 ,
/**װ����λΪ2(���Ǽ�)**/
	ITEM_TYPE_EQUIP_POS2_STAR = 21 ,
/**װ����λΪ3(���Ǽ�)**/
	ITEM_TYPE_EQUIP_POS3_STAR = 22 ,
/**װ����λΪ4(���Ǽ�)**/
	ITEM_TYPE_EQUIP_POS4_STAR = 23 ,
/**����(����λ)**/
	ITEM_TYPE_TREASURE_POS = 24 ,
/**����(�Ǽ�)��δ����**/
	ITEM_TYPE_TREASURE_STAR = 25 ,
/**����(Ǳ��)**/
	ITEM_TYPE_TREASURE_POTENTIAL = 26 ,
/**����Ϊ1�ı���(���Ǽ�)��δ����**/
	ITEM_TYPE_TREASURE1_STAR = 27 ,
/**����Ϊ1�ı���(���Ǽ�)��δ����**/
	ITEM_TYPE_TREASURE2_STAR = 28 ,
/**����Ϊ1�ı���(���Ǽ�)��δ����**/
	ITEM_TYPE_TREASURE3_STAR = 29 ,
/**����Ϊ1����Ƭ(��Ʒ��)**/
	ITEM_TYPE_CHIP1_STAR = 30 ,
/**����Ϊ2����Ƭ(��Ʒ��)**/
	ITEM_TYPE_CHIP2_STAR = 31 ,
/**���߰�����**/
	ITEM_TYPE_PROP_BY_TYPE = 32 ,
/**�������һ������(�ӵ��߱���)**/
	ITEM_TYPE_PROP_RAND = 33 ,
/**��Ƭ������**/
	ITEM_TYPE_CHIP_BY_TYPE = 34 ,
/**������Ƭ(���Ǽ�)��δ����**/
	ITEM_TYPE_TREASURE_CHIP_STAR = 35 ,
/**����**/
	ITEM_TYPE_HERO_SOUL = 36 ,
/**���ѵ���(��id)**/
	ITEM_TYPE_AWAKEN_PROP_ID = 37 ,
/**���ѵ���(��Ʒ��)**/
	ITEM_TYPE_AWAKEN_PROP_QUALITY = 38 ,
/**ʱװ(id)**/
	ITEM_TYPE_FASHION = 39 ,
/**���(ֵ)**/
	ITEM_TYPE_GOD_SOUL = 40 ,
/**����**/
	ITEM_TYPE_PRESTIGE = 41 ,
/**ս��**/
	ITEM_TYPE_CREDIT = 42 ,
/**����ѫ��**/
	ITEM_TYPE_MEDAL = 43 ,
/**���Ź���**/
	ITEM_TYPE_LEGION_DEVOTE = 44 ,
/**�Ź���δ����**/
	ITEM_TYPE_GROUP_BUYS_VOLUME = 45 ,
/**ս��**/
	ITEM_TYPE_BEAST = 46 ,
/**�޻�(ս�����)**/
	ITEM_TYPE_BEAST_SOUL = 47 ,
/**����**/
	ITEM_TYPE_WELL_WART = 48 ,
/**VIP����**/
	ITEM_TYPE_VIP_SCORE = 49 ,
/**���(ռɽΪ����)������**/
	ITEM_TYPE_TERRITORY_GATE_ITEM = 50 ,
/**����(ֵ)**/
	ITEM_TYPE_XIAYI = 51 ,
/**����(ֵ)**/
	ITEM_TYPE_YUELI = 52 ,
/**����**/
	ITEM_TYPE_GALLANT = 53 ,
/**���������������**/
	ITEM_TYPE_CSPOINTSRACE_HONOR = 54 ,
/**ϵͳ**/
	MAIL_TYPE_SYSTEM = 1 ,
/**ս��**/
	MAIL_TYPE_FIGHT = 2 ,
/**����**/
	MAIL_TYPE_FRIEND = 3 ,
/**����Ƶ��**/
	CHAT_CHANNEL_WORLD = 1 ,
/**����Ƶ��**/
	CHAT_CHANNEL_LEGION = 2 ,
/**˽��Ƶ��**/
	CHAT_CHANNEL_PRIVATE = 3 ,
/**����**/
	CHAT_CHANNEL_TEAM = 4 ,
/**��ͨ����**/
	TASK_COMPLETE_TYPE_COMMON = 1 ,
/**��ֵ**/
	TASK_COMPLETE_CHARGE = 2 ,
/**�һ�**/
	TASK_COMPLETE_EXCHANGE = 3 ,
/**��ʼ��**/
	TASK_STATUS_INIT = 0 ,
/**����; ������**/
	TASK_STATUS_ACCEPT = 1 ,
/**����������; ����ȡ����**/
	TASK_STATUS_COMPLETE = 2 ,
/**�������; ��������ȡ**/
	TASK_STATUS_FINISH = 3 ,
/**���߸��� **/
	JUMP_FUNCTION_1 = 1 ,
/**ѩ���� **/
	JUMP_FUNCTION_2 = 2 ,
/**�ճ����� **/
	JUMP_FUNCTION_3 = 3 ,
/**��Ӣ���� **/
	JUMP_FUNCTION_4 = 4 ,
/**������ **/
	JUMP_FUNCTION_5 = 5 ,
/**�ᱦ **/
	JUMP_FUNCTION_6 = 6 ,
/**�´���۳� **/
	JUMP_FUNCTION_7 = 7 ,
/**��ع��� **/
	JUMP_FUNCTION_8 = 8 ,
/**Χ���Ѿ� **/
	JUMP_FUNCTION_9 = 9 ,
/**�佫�б� **/
	JUMP_FUNCTION_10 = 10 ,
/**װ���б� **/
	JUMP_FUNCTION_11 = 11 ,
/**�����б� **/
	JUMP_FUNCTION_12 = 12 ,
/**�����̳� **/
	JUMP_FUNCTION_13 = 13 ,
/**��ͨ�ٻ� **/
	JUMP_FUNCTION_14 = 14 ,
/**�ƽ��ٻ� **/
	JUMP_FUNCTION_15 = 15 ,
/**���� **/
	JUMP_FUNCTION_16 = 16 ,
/**��ֵ **/
	JUMP_FUNCTION_17 = 17 ,
/**vip **/
	JUMP_FUNCTION_18 = 18 ,
/**������� **/
	JUMP_FUNCTION_19 = 19 ,
/**��ս���ι� **/
	JUMP_FUNCTION_20 = 20 ,
/**��սɳ�� **/
	JUMP_FUNCTION_21 = 21 ,
/**��ս��� **/
	JUMP_FUNCTION_22 = 22 ,
/**�����ٻ� **/
	JUMP_FUNCTION_23 = 23 ,
/**���� **/
	JUMP_FUNCTION_24 = 24 ,
/**���� **/
	JUMP_FUNCTION_25 = 25 ,
/**���ͥ **/
	JUMP_FUNCTION_26 = 26 ,
/**�ʼ� **/
	JUMP_FUNCTION_27 = 27 ,
/**���� **/
	JUMP_FUNCTION_28 = 28 ,
/**���� **/
	JUMP_FUNCTION_29 = 29 ,
/**���ѵ��� **/
	JUMP_FUNCTION_30 = 30 ,
/**��֬�� **/
	JUMP_FUNCTION_31 = 31 ,
/**�����̵� **/
	JUMP_FUNCTION_32 = 32 ,
/**�ճ����� **/
	JUMP_FUNCTION_33 = 33 ,
/**�����Ƽ� **/
	JUMP_FUNCTION_34 = 34 ,
/**��Ӫ� **/
	JUMP_FUNCTION_35 = 35 ,
/**7�ջ **/
	JUMP_FUNCTION_36 = 36 ,
/**ǩ�� **/
	JUMP_FUNCTION_37 = 37 ,
/**��Ҫ��ǿ **/
	JUMP_FUNCTION_38 = 38 ,
/**������� **/
	JUMP_FUNCTION_39 = 39 ,
/**Ѱ�� **/
	JUMP_FUNCTION_40 = 40 ,
/**ռɽΪ�� **/
	JUMP_FUNCTION_41 = 41 ,
/**���� **/
	JUMP_FUNCTION_42 = 42 ,
/**������ **/
	JUMP_FUNCTION_43 = 43 ,
/**��� **/
	JUMP_FUNCTION_44 = 44 ,
/**��趴�� **/
	JUMP_FUNCTION_45 = 45 ,
/**������½n�죬�Ӵ��ǿ�ʼ�㣬�������¼�**/
	TASK_TYPE_1 = 1 ,
/**�ۼƵ�½n�죬�Ӵ��ǿ�ʼ��**/
	TASK_TYPE_2 = 2 ,
/**��½**/
	TASK_TYPE_3 = 3 ,
/**���Ǵﵽn��**/
	TASK_TYPE_4 = 4 ,
/**ս�����ﵽn**/
	TASK_TYPE_5 = 5 ,
/**���߸���ʤ��n��**/
	TASK_TYPE_6 = 6 ,
/**ѩ����ʤ��n��**/
	TASK_TYPE_7 = 7 ,
/**�ճ�����ʤ��n��**/
	TASK_TYPE_8 = 8 ,
/**��Ӣ����ʤ��n��**/
	TASK_TYPE_9 = 9 ,
/**���߸��������ﵽn**/
	TASK_TYPE_10 = 10 ,
/**��Ӣ���������ﵽn**/
	TASK_TYPE_11 = 11 ,
/**ͨ�����߸�����n��**/
	TASK_TYPE_12 = 12 ,
/**ͨ�ؾ�Ӣ������n��**/
	TASK_TYPE_13 = 13 ,
/**ͨ��ѩ������n��**/
	TASK_TYPE_14 = 14 ,
/**�佫����n��**/
	TASK_TYPE_15 = 15 ,
/**װ��ǿ��n��**/
	TASK_TYPE_16 = 16 ,
/**װ������n��**/
	TASK_TYPE_17 = 17 ,
/**����ϳ�n��**/
	TASK_TYPE_18 = 18 ,
/**����ǿ��n��**/
	TASK_TYPE_19 = 19 ,
/**���ﾫ��n��**/
	TASK_TYPE_20 = 20 ,
/**�佫����n��**/
	TASK_TYPE_21 = 21 ,
/**�����佫��������ȼ��ﵽn��**/
	TASK_TYPE_22 = 22 ,
/**����n���佫�ȼ��ﵽm��**/
	TASK_TYPE_25 = 25 ,
/**����n���佫�����ﵽm��**/
	TASK_TYPE_26 = 26 ,
/**����n���佫ͻ�ƴﵽm��**/
	TASK_TYPE_27 = 27 ,
/**����n���佫���Ѵﵽm��**/
	TASK_TYPE_28 = 28 ,
/**����n���佫�����ļ�װ��**/
	TASK_TYPE_29 = 29 ,
/**����n���佫������������**/
	TASK_TYPE_30 = 30 ,
/**6�������佫ȫ������4��ǿ���ȼ�n����װ��**/
	TASK_TYPE_31 = 31 ,
/**6�������佫ȫ������4��nƷ������װ��**/
	TASK_TYPE_32 = 32 ,
/**6�������佫ȫ������4�������ȼ�n����װ��**/
	TASK_TYPE_33 = 33 ,
/**6�������佫ȫ������2�������ȼ�n���ϱ���**/
	TASK_TYPE_34 = 34 ,
/**����װ����߾����ȼ��ﵽn��**/
	TASK_TYPE_35 = 35 ,
/**����������߾����ȼ��ﵽn��**/
	TASK_TYPE_36 = 36 ,
/**������ʤ��n��**/
	TASK_TYPE_37 = 37 ,
/**��������ʷ��������ﵽn��**/
	TASK_TYPE_38 = 38 ,
/**�´���۳�ʤ��n��**/
	TASK_TYPE_39 = 39 ,
/**�´���۳�����n��**/
	TASK_TYPE_40 = 40 ,
/**�´���۳������ﵽn**/
	TASK_TYPE_41 = 41 ,
/**�´���۳���������ﵽn**/
	TASK_TYPE_42 = 42 ,
/**�Ѿ�����n��**/
	TASK_TYPE_43 = 43 ,
/**�ս��Ѿ�n��**/
	TASK_TYPE_44 = 44 ,
/**�����Ѿ�n��**/
	TASK_TYPE_45 = 45 ,
/**�Ѿ��˺��ﵽn**/
	TASK_TYPE_46 = 46 ,
/**�Ѿ���ѫ�ﵽn**/
	TASK_TYPE_47 = 47 ,
/**��ͨ�ٻ�n��**/
	TASK_TYPE_48 = 48 ,
/**�ƽ��ٻ�n��**/
	TASK_TYPE_49 = 49 ,
/**����idΪm�ĵ���n��**/
	TASK_TYPE_50 = 50 ,
/**�ᱦʤ��n��**/
	TASK_TYPE_51 = 51 ,
/**�ϳ�mƷ�ʱ���n��**/
	TASK_TYPE_52 = 52 ,
/**�������n��**/
	TASK_TYPE_53 = 53 ,
/**���Ѳ��nСʱ**/
	TASK_TYPE_54 = 54 ,
/**���̵�ˢ��n��**/
	TASK_TYPE_55 = 55 ,
/**���̵깺��n����Ʒ**/
	TASK_TYPE_56 = 56 ,
/**���;���n��**/
	TASK_TYPE_57 = 57 ,
/**vip�ȼ��ﵽn��**/
	TASK_TYPE_58 = 58 ,
/**����7�����ۼƳ�ֵnԪ**/
	TASK_TYPE_59 = 59 ,
/**�Ӵ��ǿ�ʼ�ۼƳ�ֵnԪ**/
	TASK_TYPE_60 = 60 ,
/**������ļn��**/
	TASK_TYPE_61 = 61 ,
/**�㽫n��**/
	TASK_TYPE_62 = 62 ,
/**����������n��**/
	TASK_TYPE_63 = 63 ,
/**��������n��**/
	TASK_TYPE_64 = 64 ,
/**��ɱ��Ӣ���n��**/
	TASK_TYPE_65 = 65 ,
/**��սɳ������n��**/
	TASK_TYPE_66 = 66 ,
/**���ι�ʤ��n��**/
	TASK_TYPE_67 = 67 ,
/**��������ʤ��n��**/
	TASK_TYPE_68 = 68 ,
/**6�������佫ȫ������2��nƷ�����ϱ���**/
	TASK_TYPE_69 = 69 ,
/**n��������Ʒ�ʴﵽ����1������**/
	TASK_TYPE_70 = 70 ,
/**����򴴽�����**/
	TASK_TYPE_71 = 71 ,
/**���Ÿ߼�����n��**/
	TASK_TYPE_72 = 72 ,
/**����n����**/
	TASK_TYPE_73 = 73 ,
/**����n����**/
	TASK_TYPE_74 = 74 ,
/**����nս��**/
	TASK_TYPE_75 = 75 ,
/**����n����**/
	TASK_TYPE_76 = 76 ,
/**����nԪ��**/
	TASK_TYPE_77 = 77 ,
/**�ӽӵ�����ʼ��ֵnԪ**/
	TASK_TYPE_78 = 78 ,
/**����n����ɫ����**/
	TASK_TYPE_79 = 79 ,
/**��֬��ȡ��n��**/
	TASK_TYPE_80 = 80 ,
/**��۳Ǿ�Ӣ��սͨ��n��**/
	TASK_TYPE_81 = 81 ,
/**Ԫ������n��**/
	TASK_TYPE_82 = 82 ,
/**����ӱ�n��**/
	TASK_TYPE_83 = 83 ,
/**���ż���n��**/
	TASK_TYPE_84 = 84 ,
/**����������Ŀ����n��**/
	TASK_TYPE_85 = 85 ,
/**����������ͼֵ��n**/
	TASK_TYPE_86 = 86 ,
/**���ʳ�ֵnԪ**/
	TASK_TYPE_87 = 87 ,
/**���Ӻͳ�ս���ȼ������ﵽn**/
	TASK_TYPE_88 = 88 ,
/**���Ӻͳ�ս�����ӡ�����ﵽn**/
	TASK_TYPE_89 = 89 ,
/**���Ӻͳ�ս����Ǽ������ﵽn**/
	TASK_TYPE_90 = 90 ,
/**���ɼ����ۼƹ��״ﵽn**/
	TASK_TYPE_91 = 91 ,
/**����Ѱ�����n��**/
	TASK_TYPE_92 = 92 ,
/**��������ʤ��n��**/
	TASK_TYPE_93 = 93 ,
/**�����佫�����Ǽ������ﵽn**/
	TASK_TYPE_94 = 94 ,
/**�����佫���������ﵽn**/
	TASK_TYPE_95 = 95 ,
/**�����佫װ�������ȼ������ﵽn**/
	TASK_TYPE_96 = 96 ,
/**�����佫װ���Ǽ������ﵽn**/
	TASK_TYPE_97 = 97 ,
/**�����佫����ǿ���ȼ������ﵽn**/
	TASK_TYPE_98 = 98 ,
/**�����Եعؿ�ʤ��n��**/
	TASK_TYPE_99 = 99 ,
/**���ս����n��**/
	TASK_TYPE_100 = 100 ,
/**�ӽӵ�����ʼ��ֵnԪ��**/
	TASK_TYPE_101 = 101 ,
/**���︱��ͨ�ز�����ߴﵽn**/
	TASK_TYPE_102 = 102 ,
/**���︱��ͨ�ع�����ߴﵽn**/
	TASK_TYPE_103 = 103 ,
/**���︱������n��**/
	TASK_TYPE_104 = 104 ,
/**���︱��������ӪΪm�����Ͳ�ս�������ͨ�ع�����ߴﵽn(�ֶ�����)**/
	TASK_TYPE_105 = 105 ,
/**���︱�����idΪm�ĵ���n��**/
	TASK_TYPE_106 = 106 ,
/**���︱��ʤ��n��**/
	TASK_TYPE_107 = 107 ,
/**���︱��ͨ��n��**/
	TASK_TYPE_108 = 108 ,
/**���︱�����ĵƹ�n��**/
	TASK_TYPE_109 = 109 ,
/**���︱��һ��ͨ��n��**/
	TASK_TYPE_110 = 110 ,
/**�����Զ��ָ�**/
	AUTO_RECOVERY_POWER = 1 ,
/**�������Զ��ָ�**/
	AUTO_RECOVERY_ENERGY = 2 ,
/**�������Զ��ָ�**/
	AUTO_RECOVERY_CRUSADE = 3 ,
/**�����Զ��ָ�**/
	AUTO_RECOVERY_FORAGE = 4 ,
/**�ɹ�������Զ��ָ�**/
	AUTO_RECOVERY_ATTACK_CNT = 5 ,
/**�����������ս�����Զ��ָ�**/
	AUTO_RECOVERY_CSPOINTSRACE_CNT = 9 ,
/**��������**/
	MAIL_TEMPLETE_1 = 1 ,
/**�Ѿ���ѫ��������**/
	MAIL_TEMPLETE_2 = 2 ,
/**�Ѿ��˺���������**/
	MAIL_TEMPLETE_3 = 3 ,
/**�´���۳�ɨ��**/
	MAIL_TEMPLETE_4 = 4 ,
/**GM��̨������**/
	MAIL_TEMPLETE_5 = 5 ,
/**GM���ʼ�˵��**/
	MAIL_TEMPLETE_6 = 6 ,
/**�Ի�**/
	MAIL_TEMPLETE_7 = 7 ,
/**�Ӻ��ѵ�����**/
	MAIL_TEMPLETE_8 = 8 ,
/**����ɹ��ķ���**/
	MAIL_TEMPLETE_9 = 9 ,
/**�����Ѿ�����**/
	MAIL_TEMPLETE_10 = 10 ,
/**��ɱ�Ѿ�**/
	MAIL_TEMPLETE_11 = 11 ,
/**��ֵ�ɹ�**/
	MAIL_TEMPLETE_12 = 12 ,
/**�¿���ֵ**/
	MAIL_TEMPLETE_13 = 13 ,
/**��Ʒ���콱**/
	MAIL_TEMPLETE_14 = 14 ,
/**���������ʧ��**/
	MAIL_TEMPLETE_15 = 15 ,
/**��������سɹ�**/
	MAIL_TEMPLETE_16 = 16 ,
/**����ʧ�ܣ�����δ�½���**/
	MAIL_TEMPLETE_17 = 17 ,
/**ͬ���������**/
	MAIL_TEMPLETE_18 = 18 ,
/**�߳�����֪ͨ**/
	MAIL_TEMPLETE_19 = 19 ,
/**���Ž�ɢ���ֶ���**/
	MAIL_TEMPLETE_20 = 20 ,
/**���Ž�ɢ���Զ���**/
	MAIL_TEMPLETE_21 = 21 ,
/**�������з���**/
	MAIL_TEMPLETE_22 = 22 ,
/**������ű���**/
	MAIL_TEMPLETE_23 = 23 ,
/**���������ų�֪ͨ**/
	MAIL_TEMPLETE_24 = 24 ,
/**����ְλ֪ͨ**/
	MAIL_TEMPLETE_25 = 25 ,
/**����Ϊ���ų�֪ͨ**/
	MAIL_TEMPLETE_26 = 26 ,
/**����ֵ����֪ͨ**/
	MAIL_TEMPLETE_27 = 27 ,
/**ת���콱**/
	MAIL_TEMPLETE_28 = 28 ,
/**ȺӢս���߹���**/
	MAIL_TEMPLETE_29 = 29 ,
/**Ӧ�ñ�����**/
	MAIL_TEMPLETE_30 = 30 ,
/**Ѳ���콱**/
	MAIL_TEMPLETE_31 = 31 ,
/**Ѳ���콱**/
	MAIL_TEMPLETE_32 = 32 ,
/**���������������������**/
	MAIL_TEMPLETE_33 = 33 ,
/**���������������������**/
	MAIL_TEMPLETE_34 = 34 ,
/**�������������������ç**/
	MAIL_TEMPLETE_35 = 35 ,
/**���������������������**/
	MAIL_TEMPLETE_36 = 36 ,
/**Ѳ���콱**/
	MAIL_TEMPLETE_37 = 37 ,
/**�����������������**/
	MAIL_TEMPLETE_38 = 38 ,
/**�Ѿ���������˺���������**/
	MAIL_TEMPLETE_39 = 39 ,
/**�Ѿ���������˺���������**/
	MAIL_TEMPLETE_40 = 40 ,
/**�Ѿ���������˺�������ç**/
	MAIL_TEMPLETE_41 = 41 ,
/**�Ѿ���������˺���������**/
	MAIL_TEMPLETE_42 = 42 ,
/**�Ѿ������ۼ�������������**/
	MAIL_TEMPLETE_43 = 43 ,
/**�Ѿ������ۼ�������������**/
	MAIL_TEMPLETE_44 = 44 ,
/**�Ѿ������ۼ�����������ç**/
	MAIL_TEMPLETE_45 = 45 ,
/**�Ѿ������ۼ�������������**/
	MAIL_TEMPLETE_46 = 46 ,
/**�Ѿ���������һ������**/
	MAIL_TEMPLETE_47 = 47 ,
/**�Ѿ������ɱ����**/
	MAIL_TEMPLETE_48 = 48 ,
/**����������ʧ����ʾ**/
	MAIL_TEMPLETE_49 = 49 ,
/**���������سɹ���ʾ**/
	MAIL_TEMPLETE_50 = 50 ,
/**�Żݳ�ֵ**/
	MAIL_TEMPLETE_51 = 51 ,
/**Ѻע�쳣**/
	MAIL_TEMPLETE_52 = 52 ,
/**�Ѿ�����-������������**/
	MAIL_TEMPLETE_53 = 53 ,
/**���Ű��Խ���**/
	MAIL_TEMPLETE_54 = 54 ,
/**��ɱ�Ѿ�����**/
	MAIL_TEMPLETE_55 = 55 ,
/**�����Ѿ�����**/
	MAIL_TEMPLETE_56 = 56 ,
/**�Ѿ��˺�����**/
	MAIL_TEMPLETE_57 = 57 ,
/**�������**/
	MAIL_TEMPLETE_58 = 58 ,
/**����ʧ��**/
	MAIL_TEMPLETE_59 = 59 ,
/**�����ɹ�**/
	MAIL_TEMPLETE_60 = 60 ,
/**�����ʼ�**/
	MAIL_TEMPLETE_61 = 61 ,
/**�ݵ������ʼ�(�ݵ㱻����)**/
	MAIL_TEMPLETE_64 = 64 ,
/**��ռ�����ʼ�(�����ݵ�)**/
	MAIL_TEMPLETE_65 = 65 ,
/**�ݵ㱻����**/
	MAIL_TEMPLETE_66 = 66 ,
/**�����ӵ����ý���**/
	MAIL_TEMPLETE_67 = 67 ,
/**�����ӵػ�Ծ����**/
	MAIL_TEMPLETE_68 = 68 ,
/**���ս�ܽ���**/
	MAIL_TEMPLETE_69 = 69 ,
/**���սʤ����**/
	MAIL_TEMPLETE_70 = 70 ,
/**����˺����н���**/
	MAIL_TEMPLETE_71 = 71 ,
/**���ÿ���ֵ**/
	MAIL_TEMPLETE_72 = 72 ,
/**������������**/
	MAIL_TEMPLETE_73 = 73 ,
/**�����˺�����**/
	MAIL_TEMPLETE_74 = 74 ,
/**ȫ���˺�����**/
	MAIL_TEMPLETE_75 = 75 ,
/**ȫ��նɱ����**/
	MAIL_TEMPLETE_76 = 76 ,
/**ȫ����ͼ����**/
	MAIL_TEMPLETE_77 = 77 ,
/**���ɸ���ͨ�ؽ���**/
	MAIL_TEMPLETE_78 = 78 ,
/**����ǩ������**/
	MAIL_TEMPLETE_79 = 79 ,
/**���ɸ�������**/
	MAIL_TEMPLETE_80 = 80 ,
/**�������������**/
	MAIL_TEMPLETE_81 = 81 ,
/**�������н���**/
	MAIL_TEMPLETE_82 = 82 ,
/**����նɱ����**/
	MAIL_TEMPLETE_83 = 83 ,
/**�콵����**/
	MAIL_TEMPLETE_84 = 84 ,
/**���︱�����佱��**/
	MAIL_TEMPLETE_85 = 85 ,
/**���︱��һ������**/
	MAIL_TEMPLETE_86 = 86 ,
/**�ӵ����н���**/
	MAIL_TEMPLETE_87 = 87 ,
/**�Ź�**/
	MAIL_TEMPLETE_88 = 88 ,
/**�Ź���**/
	MAIL_TEMPLETE_89 = 89 ,
/**����**/
	INC_OPER_TYPE_ADD = 1 ,
/**ɾ��**/
	INC_OPER_TYPE_DEL = 2 ,
/**�޸�**/
	INC_OPER_TYPE_MODIFY = 3 ,
/**����������ͻ��**/
	SPECIAL_AWARD_ARENA = 1 ,
/**ѩ������ʤ**/
	SPECIAL_AWARD_FAMOUS = 2 ,
/**���ﱳ��������������#value1#**/
	VIP_PRIVILEGE_TYPE_1 = 1 ,
/**�����̵�ÿ�տ�ˢ��#value1#��**/
	VIP_PRIVILEGE_TYPE_2 = 2 ,
/**��������#value1#�ι���**/
	VIP_PRIVILEGE_TYPE_3 = 3 ,
/**������֬��ȡ��#value1#��**/
	VIP_PRIVILEGE_TYPE_4 = 4 ,
/**����ս��3����**/
	VIP_PRIVILEGE_TYPE_5 = 5 ,
/**ÿ�տɹ����̵�ĳһ��Ʒ����**/
	VIP_PRIVILEGE_TYPE_6 = 6 ,
/**�����̵�ÿ�տ�ˢ��#value1#��**/
	VIP_PRIVILEGE_TYPE_7 = 7 ,
/**��۳Ǿ�Ӣ��սÿ�տɹ���#value1#��**/
	VIP_PRIVILEGE_TYPE_8 = 8 ,
/**��۳�ÿ������#value1#��**/
	VIP_PRIVILEGE_TYPE_9 = 9 ,
/**�佫����������������#value1#**/
	VIP_PRIVILEGE_TYPE_10 = 10 ,
/**ѩ����ÿ�տ���ս#value1#��**/
	VIP_PRIVILEGE_TYPE_11 = 11 ,
/**���߸���ÿ�տ�����#value1#��**/
	VIP_PRIVILEGE_TYPE_12 = 12 ,
/**�����Ѿ���������**/
	VIP_PRIVILEGE_TYPE_13 = 13 ,
/**��������һ����������**/
	VIP_PRIVILEGE_TYPE_14 = 14 ,
/**��������һ����������**/
	VIP_PRIVILEGE_TYPE_15 = 15 ,
/**����װ��һ��ǿ������**/
	VIP_PRIVILEGE_TYPE_16 = 16 ,
/**����װ��һ�����ǹ���**/
	VIP_PRIVILEGE_TYPE_17 = 17 ,
/**����ǩ�������ߵȼ��칦��**/
	VIP_PRIVILEGE_TYPE_18 = 18 ,
/**����20���鹦��**/
	VIP_PRIVILEGE_TYPE_19 = 19 ,
/**�������߸���һ��ɨ������**/
	VIP_PRIVILEGE_TYPE_20 = 20 ,
/**������۳�ɨ������**/
	VIP_PRIVILEGE_TYPE_21 = 21 ,
/**������۳�һ��3�ǹ���**/
	VIP_PRIVILEGE_TYPE_22 = 22 ,
/**������֬��һ���ϳɱ��﹦��**/
	VIP_PRIVILEGE_TYPE_23 = 23 ,
/**�������߸���ɨ������**/
	VIP_PRIVILEGE_TYPE_24 = 24 ,
/**װ��ǿ��#value1#%���ʶ�������1��**/
	VIP_PRIVILEGE_TYPE_25 = 25 ,
/**װ��ǿ��#value1#%���ʶ�������2��**/
	VIP_PRIVILEGE_TYPE_26 = 26 ,
/**�����������ɹ���**/
	VIP_PRIVILEGE_TYPE_27 = 27 ,
/**�����Ѿ���ݹ�����**/
	VIP_PRIVILEGE_TYPE_28 = 28 ,
/**������������ս5�ι���**/
	VIP_PRIVILEGE_TYPE_29 = 29 ,
/**��������λ��һ��ǿ������**/
	VIP_PRIVILEGE_TYPE_30 = 30 ,
/**��������λ��һ��װ������**/
	VIP_PRIVILEGE_TYPE_31 = 31 ,
/**Ѱ��һ��Ѱ��**/
	VIP_PRIVILEGE_TYPE_32 = 32 ,
/**Ѱ��һ����ȡ·�߽���**/
	VIP_PRIVILEGE_TYPE_33 = 33 ,
/**Ѱ��һ����ȡ���ѽ���**/
	VIP_PRIVILEGE_TYPE_34 = 34 ,
/**Ѱ��һ��������·�߼���**/
	VIP_PRIVILEGE_TYPE_35 = 35 ,
/**�鿨�Զ��ֽ�**/
	VIP_PRIVILEGE_TYPE_36 = 36 ,
/**�鿨����**/
	VIP_PRIVILEGE_TYPE_37 = 37 ,
/**�����̵�ÿ�տ�ˢ��#value1#��**/
	VIP_PRIVILEGE_TYPE_38 = 38 ,
/**�������������ˢ��#value1#��**/
	VIP_PRIVILEGE_TYPE_39 = 39 ,
/**����������ÿ�տ�ˢ��#value1#��**/
	VIP_PRIVILEGE_TYPE_40 = 40 ,
/**����������ÿ�տ���ս#value1#��**/
	VIP_PRIVILEGE_TYPE_41 = 41 ,
/**�����������ϳ�**/
	VIP_PRIVILEGE_TYPE_42 = 42 ,
/**����̵�ÿ�տ�ˢ��#value1#��**/
	VIP_PRIVILEGE_TYPE_43 = 43 ,
/**���︱��ÿ�տ�����#value1#��**/
	VIP_PRIVILEGE_TYPE_44 = 44 ,
/**���︱��һ��ͨ��**/
	VIP_PRIVILEGE_TYPE_45 = 45 ,
/**�Ƿ������ʼ�**/
	SYSTEM_UPDATE_MAIL = 1 ,
/**�Ƿ����Ѿ�����**/
	SYSTEM_UPDATE_REBEL_REWARD = 2 ,
/**�Ƿ��к�������**/
	SYSTEM_UPDATE_FRIEND_APPLY = 3 ,
/**��Ƿ���Ҫ����**/
	SYSTEM_UPDATE_ACTIVITY = 4 ,
/**�Ѿ�����**/
	SYSTEM_UPDATE_REBEL_APPEAR = 5 ,
/**�����̵����CD**/
	SYSTEM_UPDATE_HAOXIA_SHOP = 6 ,
/**�Ƿ�����������δ���**/
	SYSTEM_UPDATE_HAS_NIANTASK = 7 ,
/**���ĺӵ�**/
	SUBSCRIBE_RIVER_LANTERN = 1 ,
/**�����Ź�**/
	SUBSCRIBE_GROUPON = 2 ,
	PLATFORM_OS_WINDOWS = 0 ,
	PLATFORM_OS_LINUX = 1 ,
	PLATFORM_OS_MAC = 2 ,
	PLATFORM_OS_ANDROID = 3 ,
	PLATFORM_OS_IPHONE = 4 ,
	PLATFORM_OS_IPAD = 5 ,
	PLATFORM_OS_BLACKBERRY = 6 ,
	PLATFORM_OS_NACL = 7 ,
	PLATFORM_OS_EMSCRIPTEN = 8 ,
	PLATFORM_OS_TIZEN = 9 ,
	PLATFORM_OS_WINRT = 10 ,
	PLATFORM_OS_WP8 = 11 ,
/**�ظ���¼**/
	KICK_ROLE_REASON_REPEAT_LOGIN = 1 ,
/**GM����**/
	KICK_ROLE_REASON_GM_KICK = 2 ,
/**�����**/
	KICK_ROLE_REASON_BAN_USER = 3 ,
/**ÿ���һ��ʱ���**/
	LIMITED_TIME_BUY_COND_DAYTIME = 1 ,
/**�ȼ�����**/
	LIMITED_TIME_BUY_COND_LEVEL = 2 ,
/**�����̳�**/
	LIMITED_TIME_BUY_TYPE_SHOP = 1 ,
/**��ֵ����**/
	LIMITED_TIME_BUY_TYPE_RECHARGE = 2 ,
/**����**/
	PET_IDLE = 0 ,
/**����**/
	PET_BLESS = 1 ,
/**����**/
	PET_ONFIGHT = 2 ,
};
#endif