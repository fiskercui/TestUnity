#ifndef DEF_CARDATTR_H
#define DEF_CARDATTR_H
/**卡牌属性**/
enum DEF_CardAttr {
/**生命**/
	HERO_ATTR_HP = 1 ,
/**物攻**/
	HERO_ATTR_PHYSICS_ATTACK = 2 ,
/**魔攻**/
	HERO_ATTR_MAGIC_ATTACK = 3 ,
/**物防**/
	HERO_ATTR_PHYSICS_DEFENSE = 4 ,
/**魔防**/
	HERO_ATTR_MAGIC_DEFENSE = 5 ,
/**初始怒气**/
	HERO_ATTR_INIT_ANGER = 6 ,
/**怒气恢复值**/
	HERO_ATTR_RESET_ANGER = 7 ,
/**对阵营1伤害减免**/
	HERO_ATTR_CAMP1_REDUCE_HURT = 8 ,
/**对阵营2伤害减免**/
	HERO_ATTR_CAMP2_REDUCE_HURT = 9 ,
/**对阵营3伤害减免**/
	HERO_ATTR_CAMP3_REDUCE_HURT = 10 ,
/**对阵营4伤害减免**/
	HERO_ATTR_CAMP4_REDUCE_HURT = 11 ,
/**命中率**/
	HERO_ATTR_HIT_RATE = 12 ,
/**闪避率**/
	HERO_ATTR_DODGE_RATE = 13 ,
/**暴击率**/
	HERO_ATTR_CRIT_RATE = 14 ,
/**韧性率**/
	HERO_ATTR_TENACITY_RATE = 15 ,
/**伤害增加**/
	HERO_ATTR_ADD_HURT = 16 ,
/**伤害减免**/
	HERO_ATTR_REDUCE_HURT = 17 ,
/**无视防御**/
	HERO_ATTR_IGNORE_DEFENSE = 18 ,
/**伤害加成**/
	HERO_ATTR_HURT_ADDITION = 19 ,
/**反弹伤害**/
	HERO_ATTR_REBOUND_HURT = 20 ,
/**对阵营1伤害加成**/
	HERO_ATTR_CAMP1_ADD_HURT = 21 ,
/**对阵营2伤害加成**/
	HERO_ATTR_CAMP2_ADD_HURT = 22 ,
/**对阵营3伤害加成**/
	HERO_ATTR_CAMP3_ADD_HURT = 23 ,
/**对阵营4伤害加成**/
	HERO_ATTR_CAMP4_ADD_HURT = 24 ,
/**PVP增伤**/
	HERO_ATTR_PVPADDHURT = 25 ,
/**PVP减伤**/
	HERO_ATTR_PVPSUBHURT = 26 ,
/**战斗使用属性最大个数**/
	HERO_ATTR_FIGHT_MAX = 27 ,
/**阵营**/
	HERO_ATTR_CAMP = 27 ,
/**卡牌类型**/
	HERO_ATTR_CARD_TYPE = 28 ,
/**性别**/
	HERO_ATTR_SEX = 29 ,
/**卡牌品质，颜色**/
	HERO_ATTR_COLOR = 30 ,
/**卡牌职业**/
	HERO_ATTR_JOB = 31 ,
/**所有装备属性类型加成累计，返回的是一个数组，索引用【装备属性类型】**/
	HERO_ATTR_ALL_EQUIPS = 32 ,
/**所有装备特殊属性类型加成累计，返回的是一个数组，索引用【装备特殊属性类型】**/
	HERO_ATTR_ALL_EQUIPS_SPECIAL = 33 ,
/**所有被动技能加成类型加成累计，返回的是一个数组，索引用【被动技能加成类型】**/
	HERO_ATTR_ALL_PASSIVE_SKILL = 34 ,
/**卡牌战斗中所有Buff加成类型的累积，返回的是一个数组，索引用【Buff类型】**/
	HERO_ATTR_ALL_BUFF = 35 ,
/**经验值**/
	HERO_ATTR_EXP = 36 ,
/**等级**/
	HERO_ATTR_LEVEL = 37 ,
/**阶数; 突破等级**/
	HERO_ATTR_SCALA = 38 ,
/**天命等级**/
	HERO_ATTR_DESTINY_LV = 39 ,
/**天命经验**/
	HERO_ATTR_DESTINY_EXP = 40 ,
/**没用了**/
	HERO_ATTR_UNUSE = 41 ,
/**觉醒等级**/
	HERO_ATTR_AWAKEN_LV = 42 ,
/**觉醒星级**/
	HERO_ATTR_AWAKEN_STAR = 43 ,
/**保留**/
	HERO_ATTR_RESERVE_101 = 44 ,
/**保留**/
	HERO_ATTR_RESERVE_102 = 45 ,
/**攻击类型**/
	HERO_ATTR_ATTACK_TYPE = 46 ,
/**保留**/
	HERO_ATTR_RESERVE_103 = 47 ,
/**保留**/
	HERO_ATTR_RESERVE_104 = 48 ,
/**保留**/
	HERO_ATTR_RESERVE_105 = 49 ,
/**保留**/
	HERO_ATTR_RESERVE_106 = 50 ,
/**保留**/
	HERO_ATTR_RESERVE_107 = 51 ,
/**保留**/
	HERO_ATTR_RESERVE_108 = 52 ,
/**保留**/
	HERO_ATTR_RESERVE_109 = 53 ,
/**保留**/
	HERO_ATTR_RESERVE_110 = 54 ,
/**保留**/
	HERO_ATTR_RESERVE_111 = 55 ,
/**保留**/
	HERO_ATTR_RESERVE_112 = 56 ,
/**保留**/
	HERO_ATTR_RESERVE_113 = 57 ,
/**保留**/
	HERO_ATTR_RESERVE_114 = 58 ,
/**保留**/
	HERO_ATTR_RESERVE_115 = 59 ,
/**保留**/
	HERO_ATTR_RESERVE_116 = 60 ,
/**保留**/
	HERO_ATTR_RESERVE_117 = 61 ,
/**卡牌属性最大值**/
	HERO_ATTR_MAX = 62 ,
};
#endif