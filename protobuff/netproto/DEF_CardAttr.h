#ifndef DEF_CARDATTR_H
#define DEF_CARDATTR_H
/**��������**/
enum DEF_CardAttr {
/**����**/
	HERO_ATTR_HP = 1 ,
/**�﹥**/
	HERO_ATTR_PHYSICS_ATTACK = 2 ,
/**ħ��**/
	HERO_ATTR_MAGIC_ATTACK = 3 ,
/**���**/
	HERO_ATTR_PHYSICS_DEFENSE = 4 ,
/**ħ��**/
	HERO_ATTR_MAGIC_DEFENSE = 5 ,
/**��ʼŭ��**/
	HERO_ATTR_INIT_ANGER = 6 ,
/**ŭ���ָ�ֵ**/
	HERO_ATTR_RESET_ANGER = 7 ,
/**����Ӫ1�˺�����**/
	HERO_ATTR_CAMP1_REDUCE_HURT = 8 ,
/**����Ӫ2�˺�����**/
	HERO_ATTR_CAMP2_REDUCE_HURT = 9 ,
/**����Ӫ3�˺�����**/
	HERO_ATTR_CAMP3_REDUCE_HURT = 10 ,
/**����Ӫ4�˺�����**/
	HERO_ATTR_CAMP4_REDUCE_HURT = 11 ,
/**������**/
	HERO_ATTR_HIT_RATE = 12 ,
/**������**/
	HERO_ATTR_DODGE_RATE = 13 ,
/**������**/
	HERO_ATTR_CRIT_RATE = 14 ,
/**������**/
	HERO_ATTR_TENACITY_RATE = 15 ,
/**�˺�����**/
	HERO_ATTR_ADD_HURT = 16 ,
/**�˺�����**/
	HERO_ATTR_REDUCE_HURT = 17 ,
/**���ӷ���**/
	HERO_ATTR_IGNORE_DEFENSE = 18 ,
/**�˺��ӳ�**/
	HERO_ATTR_HURT_ADDITION = 19 ,
/**�����˺�**/
	HERO_ATTR_REBOUND_HURT = 20 ,
/**����Ӫ1�˺��ӳ�**/
	HERO_ATTR_CAMP1_ADD_HURT = 21 ,
/**����Ӫ2�˺��ӳ�**/
	HERO_ATTR_CAMP2_ADD_HURT = 22 ,
/**����Ӫ3�˺��ӳ�**/
	HERO_ATTR_CAMP3_ADD_HURT = 23 ,
/**����Ӫ4�˺��ӳ�**/
	HERO_ATTR_CAMP4_ADD_HURT = 24 ,
/**PVP����**/
	HERO_ATTR_PVPADDHURT = 25 ,
/**PVP����**/
	HERO_ATTR_PVPSUBHURT = 26 ,
/**ս��ʹ������������**/
	HERO_ATTR_FIGHT_MAX = 27 ,
/**��Ӫ**/
	HERO_ATTR_CAMP = 27 ,
/**��������**/
	HERO_ATTR_CARD_TYPE = 28 ,
/**�Ա�**/
	HERO_ATTR_SEX = 29 ,
/**����Ʒ�ʣ���ɫ**/
	HERO_ATTR_COLOR = 30 ,
/**����ְҵ**/
	HERO_ATTR_JOB = 31 ,
/**����װ���������ͼӳ��ۼƣ����ص���һ�����飬�����á�װ���������͡�**/
	HERO_ATTR_ALL_EQUIPS = 32 ,
/**����װ�������������ͼӳ��ۼƣ����ص���һ�����飬�����á�װ�������������͡�**/
	HERO_ATTR_ALL_EQUIPS_SPECIAL = 33 ,
/**���б������ܼӳ����ͼӳ��ۼƣ����ص���һ�����飬�����á��������ܼӳ����͡�**/
	HERO_ATTR_ALL_PASSIVE_SKILL = 34 ,
/**����ս��������Buff�ӳ����͵��ۻ������ص���һ�����飬�����á�Buff���͡�**/
	HERO_ATTR_ALL_BUFF = 35 ,
/**����ֵ**/
	HERO_ATTR_EXP = 36 ,
/**�ȼ�**/
	HERO_ATTR_LEVEL = 37 ,
/**����; ͻ�Ƶȼ�**/
	HERO_ATTR_SCALA = 38 ,
/**�����ȼ�**/
	HERO_ATTR_DESTINY_LV = 39 ,
/**��������**/
	HERO_ATTR_DESTINY_EXP = 40 ,
/**û����**/
	HERO_ATTR_UNUSE = 41 ,
/**���ѵȼ�**/
	HERO_ATTR_AWAKEN_LV = 42 ,
/**�����Ǽ�**/
	HERO_ATTR_AWAKEN_STAR = 43 ,
/**����**/
	HERO_ATTR_RESERVE_101 = 44 ,
/**����**/
	HERO_ATTR_RESERVE_102 = 45 ,
/**��������**/
	HERO_ATTR_ATTACK_TYPE = 46 ,
/**����**/
	HERO_ATTR_RESERVE_103 = 47 ,
/**����**/
	HERO_ATTR_RESERVE_104 = 48 ,
/**����**/
	HERO_ATTR_RESERVE_105 = 49 ,
/**����**/
	HERO_ATTR_RESERVE_106 = 50 ,
/**����**/
	HERO_ATTR_RESERVE_107 = 51 ,
/**����**/
	HERO_ATTR_RESERVE_108 = 52 ,
/**����**/
	HERO_ATTR_RESERVE_109 = 53 ,
/**����**/
	HERO_ATTR_RESERVE_110 = 54 ,
/**����**/
	HERO_ATTR_RESERVE_111 = 55 ,
/**����**/
	HERO_ATTR_RESERVE_112 = 56 ,
/**����**/
	HERO_ATTR_RESERVE_113 = 57 ,
/**����**/
	HERO_ATTR_RESERVE_114 = 58 ,
/**����**/
	HERO_ATTR_RESERVE_115 = 59 ,
/**����**/
	HERO_ATTR_RESERVE_116 = 60 ,
/**����**/
	HERO_ATTR_RESERVE_117 = 61 ,
/**�����������ֵ**/
	HERO_ATTR_MAX = 62 ,
};
#endif