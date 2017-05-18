//配表枚举类型 
DEF_Configs = {
//生命 
E_CONF_PROPERTY_HP : 0, 
//攻击 
E_CONF_PROPERTY_ATT : 1, 
//物防 
E_CONF_PROPERTY_DEFPY : 2, 
//魔防 
E_CONF_PROPERTY_DEFMG : 3, 
//命中率 
E_CONF_PROPERTY_MINZHONGLV : 4, 
//闪避率 
E_CONF_PROPERTY_SHANBILV : 5, 
//暴击率 
E_CONF_PROPERTY_BAOJILV : 6, 
//坚韧率 
E_CONF_PROPERTY_JIANRENLV : 7, 
//伤害增加 
E_CONF_PROPERTY_ADDSHANGHAI : 8, 
//伤害减免 
E_CONF_PROPERTY_DECSHANGHAI : 9, 
//主角 
E_CONF_ZY_MAINROLE : 0, 
//北凉 
E_CONF_ZY_BEILIANG : 1, 
//离阳 
E_CONF_ZY_LIYANG : 2, 
//北莽 
E_CONF_ZY_BEIMANG : 3, 
//江湖 
E_CONF_ZY_JIANGHU : 4, 
//主角 
E_CONF_CARD_MAINROLE : 1, 
//武将 
E_CONF_CARD_WUJIANG : 2, 
//空闲 
E_CONF_CARD_STATE_IDLE : 0, 
//上阵 
E_CONF_CARD_STATE_PLAY : 1, 
//援军 
E_CONF_CARD_STATE_CHEER : 2, 
//男 
E_CONF_GENDER_MALE : 1, 
//女 
E_CONF_GENDER_FEMALE : 0, 
//白 
E_CONF_COLOR_BAI : 1, 
//绿 
E_CONF_COLOR_LV : 2, 
//蓝 
E_CONF_COLOR_LAN : 3, 
//紫 
E_CONF_COLOR_ZI : 4, 
//橙 
E_CONF_COLOR_CHENG : 5, 
//红 
E_CONF_COLOR_HONG : 6, 
//金 
E_CONF_COLOR_JIN : 7, 
//主角 
E_CONF_PRO_MAINROLE : 0, 
//坦克 
E_CONF_PRO_TANK : 1, 
//DPS 
E_CONF_PRO_DPS : 2, 
//辅助 
E_CONF_PRO_FUZHU : 3, 
//银两 
E_CONF_SELL_YINLIANG : 1, 
//元宝 
E_SELL_YUANBAO : 2, 
//竞技场积分 
E_CONF_SELL_JJC : 3, 
//魔神积分 
E_CONF_SELL_MOSHEN : 4, 
//夺宝积分 
E_CONF_SELL_DUOBAO : 5, 
//武魂 
E_CONF_SELL_WUHUN : 6, 
//体力 
E_CONF_SELL_POWER : 7, 
//精力 
E_CONF_SELL_ENERGY : 8, 
//军团贡献 
E_CONF_SELL_LEGION_DEVOTE : 9, 
//物理 
E_CONF_HURT_PY : 1, 
//魔法 
E_CONF_HURT_MG : 2, 
//武器 
E_CONF_EQUIP_WUQI : 1, 
//衣服 
E_CONF_EQUIP_YIFU : 2, 
//头饰 
E_CONF_EQUIP_TOUSHI : 3, 
//腰带 
E_CONF_EQUIP_YAODAI : 4, 
//最大装备值 
E_CONF_EQUIP_MAX : 5, 
//攻击 
E_CONF_TREASURE_ATTACK : 1, 
//防御 
E_CONF_TREASURE_DEFENSE : 2, 
//经验 
E_CONF_TREASURE_EXP : 3, 
//最大宝物值 
E_CONF_TREASURE_MAX : 4, 
//无 
E_CONF_EQUIPPRO_NONE : 0, 
//物理攻击 
E_CONF_EQUIPPRO_ATTPY : 1, 
//魔法攻击 
E_CONF_EQUIPPRO_ATTMG : 2, 
//物理防御 
E_CONF_EQUIPPRO_DEFPY : 3, 
//魔法防御 
E_CONF_EQUIPPRO_DEFMG : 4, 
//血量 
E_CONF_EQUIPPRO_HP : 5, 
//同时增加物理攻击和魔法攻击 
E_CONF_EQUIPPRO_ATT : 6, 
//物理攻击百分比 
E_CONF_EQUIPPRO_ATTPYRATIO : 7, 
//魔法攻击百分比 
E_CONF_EQUIPPRO_ATTMGRATIO : 8, 
//物理防御百分比 
E_CONF_EQUIPPRO_DEFPYRATIO : 9, 
//魔法防御百分比 
E_CONF_EQUIPPRO_DEFMGRATIO : 10, 
//血量百分比 
E_CONF_EQUIPPRO_HPRATIO : 11, 
//同时增加物攻和魔攻百分比 
E_CONF_EQUIPPRO_ATTRATIO : 12, 
//命中率 
E_CONF_EQUIPPRO_MINGZHONG : 13, 
//闪避率 
E_CONF_EQUIPPRO_SHANBI : 14, 
//暴击率 
E_CONF_EQUIPPRO_BAOJI : 15, 
//韧性率 
E_CONF_EQUIPPRO_RENXING : 16, 
//伤害加成百分比 
E_CONF_EQUIPPRO_HURTRATIO : 17, 
//免伤加成百分比 
E_CONF_EQUIPPRO_MIANSHANGRATIO : 18, 
//基础怒气值 
E_CONF_EQUIPPRO_BASEANGER : 19, 
//怒气恢复值 
E_CONF_EQUIPPRO_ANGERHUIFU : 20, 
//同时增加物防和魔防绝对值 
E_CONF_EQUIPPRO_DEF : 21, 
//PVP增伤 
E_CONF_EQUIPPRO_PVPADDHURT : 22, 
//PVP减伤 
E_CONF_EQUIPPRO_PVPSUBHURT : 23, 
//同时增加物防和魔防百分比 
E_CONF_EQUIPPRO_DEFRATIO : 24, 
//经验加成 
E_CONF_EQUIPPRO_EXPRATE : 25, 
//同时增加生命、攻击、防御百分比 
E_CONF_EQUIPPRO_ALLRATIO : 26, 
//对阵营1伤害增加 
E_CONF_EQUIPPRO_CAMP1_ADDHURT : 27, 
//对阵营2伤害增加 
E_CONF_EQUIPPRO_CAMP2_ADDHURT : 28, 
//对阵营3伤害增加 
E_CONF_EQUIPPRO_CAMP3_ADDHURT : 29, 
//对阵营4伤害增加 
E_CONF_EQUIPPRO_CAMP4_ADDHURT : 30, 
//对阵营1伤害减免 
E_CONF_EQUIPPRO_CAMP1_DECHURT : 31, 
//对阵营2伤害减免 
E_CONF_EQUIPPRO_CAMP2_DECHURT : 32, 
//对阵营3伤害减免 
E_CONF_EQUIPPRO_CAMP3_DECHURT : 33, 
//对阵营4伤害减免 
E_CONF_EQUIPPRO_CAMP4_DECHURT : 34, 
//装备属性枚举最大值 
E_CONF_EQUIPPRO_MAX : 35, 
//装备精炼到X级 
E_CONF_JINGLIAN_X : 1, 
//宝物精炼到X级 
E_CONF_JINGLIANBAOWU_X : 2, 
//攻击时伤害加成X%，X为千分比 
E_CONF_EQUIPPRO_SPECIAL_1 : 1, 
//收到攻击时，恢复自身生命最大值X%的生命，X为千分比 
E_CONF_EQUIPPRO_SPECIAL_2 : 2, 
//每次收到魔法攻击时，反弹总伤害的X%，X为千分比 
E_CONF_EQUIPPRO_SPECIAL_3 : 3, 
//每次收到物理攻击时，反弹总伤害的X%，X为千分比 
E_CONF_EQUIPPRO_SPECIAL_4 : 4, 
//攻击时无视对方防御最大值的X%，X为千分比 
E_CONF_EQUIPPRO_SPECIAL_5 : 5, 
//收到致命攻击时，生命的恢复值。 
E_CONF_EQUIPPRO_SPECIAL_6 : 6, 
//收到致命攻击时，无敌的回合数。 
E_CONF_EQUIPPRO_SPECIAL_7 : 7, 
//每次攻击时x%的概率将造成的伤害x%转化为自身生命 
E_CONF_EQUIPPRO_SPECIAL_8 : 8, 
//特殊属性最大个数 
E_CONF_EQUIPPRO_SPECIAL_MAX : 9, 
//全身装备强化等级大于等于X 
E_CONF_QIANGHUADASHI_1 : 1, 
//全身宝物强化等级大于等于X 
E_CONF_QIANGHUADASHI_2 : 2, 
//全身装备精炼等级大于等于X 
E_CONF_QIANGHUADASHI_3 : 3, 
//全身宝物精炼等级大于等于X 
E_CONF_QIANGHUADASHI_4 : 4, 
//六个小伙伴等级大于X 
E_CONF_QIANGHUADASHI_5 : 5, 
//增加[作用目标]的命中率 
E_CONF_SKILLADDTIVE_1 : 1, 
//增加[作用目标]的闪避率 
E_CONF_SKILLADDTIVE_2 : 2, 
//增加[作用目标]的暴击率 
E_CONF_SKILLADDTIVE_3 : 3, 
//增加[作用目标]的坚韧率 
E_CONF_SKILLADDTIVE_4 : 4, 
//增加[作用目标]的伤害加成 
E_CONF_SKILLADDTIVE_5 : 5, 
//增加[作用目标]的伤害减免 
E_CONF_SKILLADDTIVE_6 : 6, 
//增加[作用目标]的物攻and魔攻千分比 
E_CONF_SKILLADDTIVE_7 : 7, 
//增加[作用目标]的物防and魔防千分比 
E_CONF_SKILLADDTIVE_8 : 8, 
//增加[作用目标]的生命最大值千分比 
E_CONF_SKILLADDTIVE_9 : 9, 
//增加[作用目标]对阵营1武将的伤害加成 
E_CONF_SKILLADDTIVE_10 : 10, 
//增加[作用目标]对阵营2武将的伤害加成 
E_CONF_SKILLADDTIVE_11 : 11, 
//增加[作用目标]对阵营3武将的伤害加成 
E_CONF_SKILLADDTIVE_12 : 12, 
//增加[作用目标]对阵营4武将的伤害加成 
E_CONF_SKILLADDTIVE_13 : 13, 
//增加[作用目标]的基础怒气值 
E_CONF_SKILLADDTIVE_14 : 14, 
//增加[作用目标]的怒气恢复值 
E_CONF_SKILLADDTIVE_15 : 15, 
//增加[作用目标]的攻击力绝对值 
E_CONF_SKILLADDTIVE_16 : 16, 
//增加[作用目标]的生命绝对值 
E_CONF_SKILLADDTIVE_17 : 17, 
//增加[作用目标]的物防和魔防绝对值 
E_CONF_SKILLADDTIVE_18 : 18, 
//增加[作用目标]的物攻和魔攻和物防和魔防和生命最大值千分比 
E_CONF_SKILLADDTIVE_19 : 19, 
//增加[作用目标]的生命恢复效果加成 
E_CONF_SKILLADDTIVE_20 : 20, 
//1-物攻攻击 
E_CONF_BLUSHER_1 : 1, 
//2-物攻防御 
E_CONF_BLUSHER_2 : 2, 
//3-法攻攻击 
E_CONF_BLUSHER_3 : 3, 
//4-法攻防御 
E_CONF_BLUSHER_4 : 4, 
//5-命中 
E_CONF_BLUSHER_5 : 5, 
//6-闪避 
E_CONF_BLUSHER_6 : 6, 
//7-生命 
E_CONF_BLUSHER_7 : 7, 
//8-暴击 
E_CONF_BLUSHER_8 : 8, 
//9-抗暴 
E_CONF_BLUSHER_9 : 9, 
//侠客事件 
E_CONF_VISIT_EVENT_TYPE_1 : 1, 
//路线事件 
E_CONF_VISIT_EVENT_TYPE_2 : 2, 
//驿站事件 
E_CONF_VISIT_EVENT_TYPE_3 : 3, 
//驿站固定事件 
E_CONF_VISIT_EVENT_TYPE_4 : 4, 
//快马加鞭事件 
E_CONF_VISIT_EVENT_TYPE_5 : 5, 
//起始事件 
E_CONF_VISIT_EVENT_TYPE_6 : 6, 
//终点事件 
E_CONF_VISIT_EVENT_TYPE_7 : 7, 
//帮主 
E_CONF_LEGION_POS_HEAD : 1, 
//副帮主 
E_CONF_LEGION_POS_DEPUTY : 2, 
//帮众 
E_CONF_LEGION_POS_MEMBER : 3, 
//默认开启, 没限制 
E_CONF_LEGION_NO_LIMIT : 1, 
//帮派等级限制 
E_CONF_LEGION_LV_LIMIT : 2, 
//帮派战名次限制 
E_CONF_LEGION_BATTLE_RANK_LIMIT : 3, 
//帮派副本通关限制 
E_CONF_LEGION_RAID_LIMIT : 4, 
//默认, 无限制 
E_CONF_LEGION_ACCEPT_NO_LIMIT : 0, 
//等级限制 
E_CONF_LEGION_ACCEPT_LV_LIMIT : 1, 
//战力限制 
E_CONF_LEGION_ACCEPT_FIGHT_LIMIT : 2, 
//VIP限制 
E_CONF_LEGION_ACCEPT_VIP_LIMIT : 3, 
//枚举最大值 
E_CONF_LEGION_ACCEPT_MAX : 4, 
//低级车 
E_CONF_VISIT_HORSE_LOW : 1, 
//中级车 
E_CONF_VISIT_HORSE_MID : 2, 
//高级车 
E_CONF_VISIT_HORSE_HIGH : 3, 
//永久卡 
E_CONF_TIMELESS_CARD : 1, 
//月卡 
E_CONF_MONTH_CARD : 2, 
//普通奖励 
E_CONF_FIGHT_REWARD_DROP : 0, 
//首次奖励 
E_CONF_FIGHT_REWARD_FIRST_DROP : 1, 
//自身 
E_CONF_SKILLTARGET_1 : 1, 
//我方全体 
E_CONF_SKILLTARGET_2 : 2, 
//我方所有阵营为1的武将 
E_CONF_SKILLTARGET_3 : 3, 
//我方所有阵营为2的武将 
E_CONF_SKILLTARGET_4 : 4, 
//我方所有阵营为3的武将 
E_CONF_SKILLTARGET_5 : 5, 
//我方所有阵营为4的武将 
E_CONF_SKILLTARGET_6 : 6, 
//我方所有非阵营1武将 
E_CONF_SKILLTARGET_7 : 7, 
//我方所有非阵营2武将 
E_CONF_SKILLTARGET_8 : 8, 
//我方所有非阵营3武将 
E_CONF_SKILLTARGET_9 : 9, 
//我方所有非阵营4武将 
E_CONF_SKILLTARGET_10 : 10, 
//1-扣血 
E_CONF_BUFFTYPE_1 : 1, 
//2-加血 
E_CONF_BUFFTYPE_2 : 2, 
//3-加生命最大值（none） 
E_CONF_BUFFTYPE_3 : 3, 
//4-减生命最大值（none） 
E_CONF_BUFFTYPE_4 : 4, 
//5-加物攻 
E_CONF_BUFFTYPE_5 : 5, 
//6-减物攻 
E_CONF_BUFFTYPE_6 : 6, 
//7-加魔攻 
E_CONF_BUFFTYPE_7 : 7, 
//8-减魔攻 
E_CONF_BUFFTYPE_8 : 8, 
//9-加物防 
E_CONF_BUFFTYPE_9 : 9, 
//10-减物防 
E_CONF_BUFFTYPE_10 : 10, 
//11-加魔防 
E_CONF_BUFFTYPE_11 : 11, 
//12-减魔防 
E_CONF_BUFFTYPE_12 : 12, 
//13-加命中率 
E_CONF_BUFFTYPE_13 : 13, 
//14-减命中率 
E_CONF_BUFFTYPE_14 : 14, 
//15-加回避率 
E_CONF_BUFFTYPE_15 : 15, 
//16-减回避率 
E_CONF_BUFFTYPE_16 : 16, 
//17-加暴击率 
E_CONF_BUFFTYPE_17 : 17, 
//18-减暴击率 
E_CONF_BUFFTYPE_18 : 18, 
//19-加坚韧率 
E_CONF_BUFFTYPE_19 : 19, 
//20-减坚韧率 
E_CONF_BUFFTYPE_20 : 20, 
//21-加物攻and魔攻 
E_CONF_BUFFTYPE_21 : 21, 
//22-减物攻and魔攻 
E_CONF_BUFFTYPE_22 : 22, 
//23-加物防and魔防 
E_CONF_BUFFTYPE_23 : 23, 
//24-减物防and魔防 
E_CONF_BUFFTYPE_24 : 24, 
//25-增加伤害加成 
E_CONF_BUFFTYPE_25 : 25, 
//26-减少伤害加成 
E_CONF_BUFFTYPE_26 : 26, 
//27-增加伤害减免 
E_CONF_BUFFTYPE_27 : 27, 
//28-减少伤害减免 
E_CONF_BUFFTYPE_28 : 28, 
//29-眩晕（无法行动） 
E_CONF_BUFFTYPE_29 : 29, 
//30-增加无视防御 
E_CONF_BUFFTYPE_30 : 30, 
//31-减少无视防御 
E_CONF_BUFFTYPE_31 : 31, 
//32-增加伤害反弹 
E_CONF_BUFFTYPE_32 : 32, 
//33-（断经）普攻不能回复怒气 
E_CONF_BUFFTYPE_33 : 33, 
//34-（断经）任何情况下都不回复怒气 
E_CONF_BUFFTYPE_34 : 34, 
//35-睡眠（无法行动，被攻击会被打醒） 
E_CONF_BUFFTYPE_35 : 35, 
//36-流血（被加血时驱除） 
E_CONF_BUFFTYPE_36 : 36, 
//37-灼烧（每回合掉血） 
E_CONF_BUFFTYPE_37 : 37, 
//38-按生命最大值比率(千分比)扣血 
E_CONF_BUFFTYPE_38 : 38, 
//39-按生命最大值比率(千分比)加血 
E_CONF_BUFFTYPE_39 : 39, 
//40-无敌 
E_CONF_BUFFTYPE_40 : 40, 
//41-加攻防血 
E_CONF_BUFFTYPE_41 : 41, 
//42-不回血 
E_CONF_BUFFTYPE_42 : 42, 
//状态类(一直生效，先行动，再次数-1，清除) 
E_CONF_BUFF_STATE : 1, 
//DOT类(先生效，次数-1，清除，再行动) 
E_CONF_BUFF_DOT : 2, 
//增益BUFF 
E_CONF_BUFFADD_TYPE : 1, 
//减益BUFF 
E_CONF_BUFFDEC_TYPE : 2, 
//受击动画开始时 
E_CONF_BUFF_PERF_STEP1 : 1, 
//人物跳回来之后 
E_CONF_BUFF_PERF_STEP2 : 2, 
//普通攻击 
E_CONF_SKILLTYPE_1 : 1, 
//怒气技能 
E_CONF_SKILLTYPE_2 : 2, 
//合击技能 
E_CONF_SKILLTYPE_3 : 3, 
//超合击技能 
E_CONF_SKILLTYPE_4 : 4, 
//阶段技能 
E_CONF_SKILLTYPE_10 : 10, 
//敌方默认目标 
E_CONF_SKILLRANGE_1 : 1, 
//敌方全体 
E_CONF_SKILLRANGE_2 : 2, 
//敌方随机3个 
E_CONF_SKILLRANGE_3 : 3, 
//敌方前排全体 
E_CONF_SKILLRANGE_4 : 4, 
//敌方后排全体 
E_CONF_SKILLRANGE_5 : 5, 
//我方全体 
E_CONF_SKILLRANGE_6 : 6, 
//自身 
E_CONF_SKILLRANGE_7 : 7, 
//打默认对象所在列 
E_CONF_SKILLRANGE_8 : 8, 
//我方随机一个 
E_CONF_SKILLRANGE_9 : 9, 
//我方血最少的一个 
E_CONF_SKILLRANGE_10 : 10, 
//对方血最少的一个 
E_CONF_SKILLRANGE_11 : 11, 
//后排单体 
E_CONF_SKILLRANGE_12 : 12, 
//我方血最少的三个单位 
E_CONF_SKILLRANGE_13 : 13, 
//己方随机三个单位 
E_CONF_SKILLRANGE_14 : 14, 
//己方所有生命不满60%的单位 
E_CONF_SKILLRANGE_15 : 15, 
//敌方全体生命大于80%的单位 
E_CONF_SKILLRANGE_16 : 16, 
//己方随机2个单位 
E_CONF_SKILLRANGE_17 : 17, 
//对位及其相邻 
E_CONF_SKILLRANGE_18 : 18, 
//对位及另一个随机的敌人，只有对位时就不随机 
E_CONF_SKILLRANGE_19 : 19, 
//继承随机 
E_CONF_SKILLRANGE_20 : 20, 
//敌方随机一个 
E_CONF_SKILLRANGE_21 : 21, 
//自己和己方随机一个 
E_CONF_SKILLRANGE_22 : 22, 
//完美十字 
E_CONF_SKILLRANGE_23 : 23, 
//自己除外的相邻人物 
E_CONF_SKILLRANGE_24 : 24, 
//三次对方全体随机 
E_CONF_SKILLRANGE_25 : 25, 
//对位敌方相邻（除了对位人员） 
E_CONF_SKILLRANGE_26 : 26, 
//技能受击者血量低于10% 
E_CONF_SKILLRANGE_27 : 27, 
//有目标死亡，选择自己 
E_CONF_SKILLRANGE_28 : 28, 
//BUFF 
E_CONF_SKILLUSETYPE_0 : 0, 
//扣血 
E_CONF_SKILLUSETYPE_1 : 1, 
//加血 
E_CONF_SKILLUSETYPE_2 : 2, 
//清所有增益BUFF 
E_CONF_SKILLUSETYPE_3 : 3, 
//清除减益DEBUFF 
E_CONF_SKILLUSETYPE_4 : 4, 
//消除减益DOT 
E_CONF_SKILLUSETYPE_5 : 5, 
//扣怒气 
E_CONF_SKILLUSETYPE_6 : 6, 
//加怒气 
E_CONF_SKILLUSETYPE_7 : 7, 
//如果前段暴击了加怒气 
E_CONF_SKILLUSETYPE_8 : 8, 
//目标下次行动前清除身上所有DEBUFF 
E_CONF_SKILLUSETYPE_9 : 9, 
//扣血，暴击算全体，不单独算 
E_CONF_SKILLUSETYPE_10 : 10, 
//目标下次行动前清除身上所有DEBUFF，若没有则增加1点怒气 
E_CONF_SKILLUSETYPE_11 : 11, 
//根据目标dot个数对伤害进行相应倍数加成，最大100倍 
E_CONF_SKILLUSETYPE_12 : 12, 
//召唤怪物组 
E_CONF_SKILLUSETYPE_30 : 30, 
//白 
E_CONF_SKILLCOLOR_1 : 1, 
//绿 
E_CONF_SKILLCOLOR_2 : 2, 
//蓝 
E_CONF_SKILLCOLOR_3 : 3, 
//紫 
E_CONF_SKILLCOLOR_4 : 4, 
//橙 
E_CONF_SKILLCOLOR_5 : 5, 
//红 
E_CONF_SKILLCOLOR_6 : 6, 
//金 
E_CONF_SKILLCOLOR_7 : 7, 
//消耗怒气 
E_CONF_ANGER_SUB : 1, 
//增加怒气 
E_CONF_ANGER_ADD : 2, 
//原地不动 
E_CONF_SKILLPOS_1 : 1, 
//屏幕中心 
E_CONF_SKILLPOS_2 : 2, 
//目标对象中心 
E_CONF_SKILLPOS_3 : 3, 
//受击对象所在行的左边位置 
E_CONF_SKILLPOS_4 : 4, 
//受击对象所在行的中间位置 
E_CONF_SKILLPOS_5 : 5, 
//受击对象所在行的右边位置 
E_CONF_SKILLPOS_6 : 6, 
//受击对象所在列的前排位置 
E_CONF_SKILLPOS_7 : 7, 
//受击对象所在列的后排位置 
E_CONF_SKILLPOS_8 : 8, 
//敌方2号位置 
E_CONF_SKILLPOS_9 : 9, 
//我方2号位置 
E_CONF_SKILLPOS_10 : 10, 
//敌方中间 
E_CONF_SKILLPOS_11 : 11, 
//我方中间 
E_CONF_SKILLPOS_12 : 12, 
//0.无任何用处（活动道具） 
E_CONF_ITEMUSE_TYPE_0 : 0, 
//1. 可使用；按钮：使用 
E_CONF_ITEMUSE_TYPE_1 : 1, 
//2. 去进阶；按钮：去进阶； 
E_CONF_ITEMUSE_TYPE_2 : 2, 
//3. 去精练；按钮：去精练； 
E_CONF_ITEMUSE_TYPE_3 : 3, 
//4. 去洗练；按钮：去洗练； 
E_CONF_ITEMUSE_TYPE_4 : 4, 
//5. 去武将光环；按钮：去光环；（现在也没有这个系统） 
E_CONF_ITEMUSE_TYPE_5 : 5, 
//6. 连接至神秘商店；按钮：神秘商店； 
E_CONF_ITEMUSE_TYPE_6 : 6, 
//7. 链接至宝物精练；按钮：宝物精练 
E_CONF_ITEMUSE_TYPE_7 : 7, 
//8. 打开抽将；按钮：去抽卡 
E_CONF_ITEMUSE_TYPE_8 : 8, 
//9. 浮动提示【暂未开启该功能】 
E_CONF_ITEMUSE_TYPE_9 : 9, 
//10.【去XX】；链接至三国志系统 
E_CONF_ITEMUSE_TYPE_10 : 10, 
//11.【去娱乐】：链接至富甲天下主界面 
E_CONF_ITEMUSE_TYPE_11 : 11, 
//12.【去觉醒】：链接到觉醒界面 
E_CONF_ITEMUSE_TYPE_12 : 12, 
//13.n选1道具 
E_CONF_ITEMUSE_TYPE_13 : 13, 
//14.“去娱乐”，链接至大富翁系统 
E_CONF_ITEMUSE_TYPE_14 : 14, 
//15.”去激活“，链接称号系统 
E_CONF_ITEMUSE_TYPE_15 : 15, 
//16.”去喂养”链接宠物背包 
E_CONF_ITEMUSE_TYPE_16 : 16, 
//17.“去神炼”链接宠物背包 
E_CONF_ITEMUSE_TYPE_17 : 17, 
//18.“去升星”链接宠物背包 
E_CONF_ITEMUSE_TYPE_18 : 18, 
//19.去兑换 链接至卦盘商店 
E_CONF_ITEMUSE_TYPE_19 : 19, 
//20.去兑换 链接至胭脂商店 
E_CONF_ITEMUSE_TYPE_20 : 20, 
//1-礼包类(按钮使用) 
E_CONF_ITEM_TYPE_1 : 1, 
//2-武将升星石 
E_CONF_ITEM_TYPE_2 : 2, 
//3-三国志碎片 
E_CONF_ITEM_TYPE_3 : 3, 
//4-武将光环石 
E_CONF_ITEM_TYPE_4 : 4, 
//5-武将培养石 
E_CONF_ITEM_TYPE_5 : 5, 
//6-装备精炼石 
E_CONF_ITEM_TYPE_6 : 6, 
//7-技能书 
E_CONF_ITEM_TYPE_7 : 7, 
//8-体力恢复类（pvp值）(按钮使用) 
E_CONF_ITEM_TYPE_8 : 8, 
//9-精力恢复类（pve值）(按钮使用) 
E_CONF_ITEM_TYPE_9 : 9, 
//10-招募令 
E_CONF_ITEM_TYPE_10 : 10, 
//11.精炼石 
E_CONF_ITEM_TYPE_11 : 11, 
//12.刷新令 
E_CONF_ITEM_TYPE_12 : 12, 
//13.免战牌 
E_CONF_ITEM_TYPE_13 : 13, 
//14. 宝物精炼石 
E_CONF_ITEM_TYPE_14 : 14, 
//15.技能卷轴 
E_CONF_ITEM_TYPE_15 : 15, 
//16.出征令恢复（叛军值）（按钮使用） 
E_CONF_ITEM_TYPE_16 : 16, 
//17.纯描述类道具 
E_CONF_ITEM_TYPE_17 : 17, 
//18.时装精华 
E_CONF_ITEM_TYPE_18 : 18, 
//19.任务道具 
E_CONF_ITEM_TYPE_19 : 19, 
//20.觉醒道具 
E_CONF_ITEM_TYPE_20 : 20, 
//21.n选1道具(item_box_info) 
E_CONF_ITEM_TYPE_21 : 21, 
//22.时装箱子(item_choose_info) 
E_CONF_ITEM_TYPE_22 : 22, 
//23.幸运色子 
E_CONF_ITEM_TYPE_23 : 23, 
//24.称号道具 
E_CONF_ITEM_TYPE_24 : 24, 
//25.鲜花 
E_CONF_ITEM_TYPE_25 : 25, 
//26.宠物口粮 
E_CONF_ITEM_TYPE_26 : 26, 
//27.宠物神炼石 
E_CONF_ITEM_TYPE_27 : 27, 
//28.宠物升星石 
E_CONF_ITEM_TYPE_28 : 28, 
//29.奇门八卦卦盘 
E_CONF_ITEM_TYPE_29 : 29, 
//30.月卡续期 
E_CONF_ITEM_TYPE_30 : 30, 
//1、武将缘分 
E_CONF_YUANFEN_1 : 1, 
//2、装备缘分 
E_CONF_YUANFEN_2 : 2, 
//3、宝物缘分 
E_CONF_YUANFEN_3 : 3, 
//主线副本 
E_CONF_RAID_TYPE_MAIN : 1, 
//精英副本 
E_CONF_RAID_TYPE_ELITE : 2, 
//日常副本 
E_CONF_RAID_TYPE_DAILY : 3, 
//名将副本 
E_CONF_RAID_TYPE_FAMOUS_HERO : 4, 
//武将碎片 
E_CONF_CHIP_WUJIANG : 1, 
//装备碎片 
E_CONF_CHIP_EQUIP : 2, 
//宝物碎片 
E_CONF_CHIP_TREASURE : 3, 
//时装碎片 
E_CONF_CHIP_FASHION : 4, 
//宠物碎片 
E_CONF_CHIP_PET : 5, 
//银两 
ITEM_TYPE_SILVER : 1, 
//元宝 
ITEM_TYPE_YUENBO : 2, 
//道具 
ITEM_TYPE_PROP : 3, 
//武将 
ITEM_TYPE_HERO : 4, 
//装备 
ITEM_TYPE_EQUIP : 5, 
//碎片 
ITEM_TYPE_CHIP : 6, 
//宝物 
ITEM_TYPE_TREASURE : 7, 
//宝物碎片(作废，放在碎片里) 
ITEM_TYPE_TREASURE_CHIP : 8, 
//掉落id 
ITEM_TYPE_OTHER_DROP : 9, 
//武将按星级 
ITEM_TYPE_HERO_STAR : 10, 
//武将按阵营 
ITEM_TYPE_HERO_CAMP : 11, 
//武将按潜力 
ITEM_TYPE_HERO_POTENTIAL : 12, 
//阵营为1的武将(按星级) 
ITEM_TYPE_HERO_CAMP1_STAR : 13, 
//阵营为2的武将(按星级) 
ITEM_TYPE_HERO_CAMP2_STAR : 14, 
//阵营为3的武将(按星级) 
ITEM_TYPE_HERO_CAMP3_STAR : 15, 
//阵营为4的武将(按星级) 
ITEM_TYPE_HERO_CAMP4_STAR : 16, 
//装备(按部位) 
ITEM_TYPE_EQUIP_POS : 17, 
//装备(星级) 
ITEM_TYPE_EQUIP_STAR : 18, 
//装备(潜力) 
ITEM_TYPE_EQUIP_POTENTIAL : 19, 
//装备部位为1(按星级) 
ITEM_TYPE_EQUIP_POS1_STAR : 20, 
//装备部位为2(按星级) 
ITEM_TYPE_EQUIP_POS2_STAR : 21, 
//装备部位为3(按星级) 
ITEM_TYPE_EQUIP_POS3_STAR : 22, 
//装备部位为4(按星级) 
ITEM_TYPE_EQUIP_POS4_STAR : 23, 
//宝物(按部位) 
ITEM_TYPE_TREASURE_POS : 24, 
//宝物(星级)，未开发 
ITEM_TYPE_TREASURE_STAR : 25, 
//宝物(潜力) 
ITEM_TYPE_TREASURE_POTENTIAL : 26, 
//类型为1的宝物(按星级)，未开发 
ITEM_TYPE_TREASURE1_STAR : 27, 
//类型为1的宝物(按星级)，未开发 
ITEM_TYPE_TREASURE2_STAR : 28, 
//类型为1的宝物(按星级)，未开发 
ITEM_TYPE_TREASURE3_STAR : 29, 
//类型为1的碎片(按品质) 
ITEM_TYPE_CHIP1_STAR : 30, 
//类型为2的碎片(按品质) 
ITEM_TYPE_CHIP2_STAR : 31, 
//道具按类型 
ITEM_TYPE_PROP_BY_TYPE : 32, 
//随机掉落一个道具(从道具表中) 
ITEM_TYPE_PROP_RAND : 33, 
//碎片按类型 
ITEM_TYPE_CHIP_BY_TYPE : 34, 
//宝物碎片(按星级)，未开发 
ITEM_TYPE_TREASURE_CHIP_STAR : 35, 
//将魂 
ITEM_TYPE_HERO_SOUL : 36, 
//觉醒道具(按id) 
ITEM_TYPE_AWAKEN_PROP_ID : 37, 
//觉醒道具(按品质) 
ITEM_TYPE_AWAKEN_PROP_QUALITY : 38, 
//时装(id) 
ITEM_TYPE_FASHION : 39, 
//神魂(值) 
ITEM_TYPE_GOD_SOUL : 40, 
//声望 
ITEM_TYPE_PRESTIGE : 41, 
//战功 
ITEM_TYPE_CREDIT : 42, 
//演武勋章 
ITEM_TYPE_MEDAL : 43, 
//军团贡献 
ITEM_TYPE_LEGION_DEVOTE : 44, 
//团购卷，未开发 
ITEM_TYPE_GROUP_BUYS_VOLUME : 45, 
//战宠 
ITEM_TYPE_BEAST : 46, 
//兽魂(战宠积分) 
ITEM_TYPE_BEAST_SOUL : 47, 
//威名 
ITEM_TYPE_WELL_WART : 48, 
//VIP积分 
ITEM_TYPE_VIP_SCORE : 49, 
//领地(占山为王关)卡道具 
ITEM_TYPE_TERRITORY_GATE_ITEM : 50, 
//侠义(值) 
ITEM_TYPE_XIAYI : 51, 
//阅历(值) 
ITEM_TYPE_YUELI : 52, 
//豪侠 
ITEM_TYPE_GALLANT : 53, 
//跨服积分赛荣誉点 
ITEM_TYPE_CSPOINTSRACE_HONOR : 54, 
//系统 
MAIL_TYPE_SYSTEM : 1, 
//战斗 
MAIL_TYPE_FIGHT : 2, 
//好友 
MAIL_TYPE_FRIEND : 3, 
//世界频道 
CHAT_CHANNEL_WORLD : 1, 
//军团频道 
CHAT_CHANNEL_LEGION : 2, 
//私聊频道 
CHAT_CHANNEL_PRIVATE : 3, 
//队伍 
CHAT_CHANNEL_TEAM : 4, 
//普通任务 
TASK_COMPLETE_TYPE_COMMON : 1, 
//充值 
TASK_COMPLETE_CHARGE : 2, 
//兑换 
TASK_COMPLETE_EXCHANGE : 3, 
//初始化 
TASK_STATUS_INIT : 0, 
//接收; 进行中 
TASK_STATUS_ACCEPT : 1, 
//任务进度完成; 可领取奖励 
TASK_STATUS_COMPLETE : 2, 
//任务结束; 奖励已领取 
TASK_STATUS_FINISH : 3, 
//主线副本  
JUMP_FUNCTION_1 : 1, 
//雪刀传  
JUMP_FUNCTION_2 : 2, 
//日常副本  
JUMP_FUNCTION_3 : 3, 
//精英副本  
JUMP_FUNCTION_4 : 4, 
//竞技场  
JUMP_FUNCTION_5 : 5, 
//夺宝  
JUMP_FUNCTION_6 : 6, 
//勇闯武帝城  
JUMP_FUNCTION_7 : 7, 
//领地攻讨  
JUMP_FUNCTION_8 : 8, 
//围剿叛军  
JUMP_FUNCTION_9 : 9, 
//武将列表  
JUMP_FUNCTION_10 : 10, 
//装备列表  
JUMP_FUNCTION_11 : 11, 
//宝物列表  
JUMP_FUNCTION_12 : 12, 
//道具商城  
JUMP_FUNCTION_13 : 13, 
//普通召唤  
JUMP_FUNCTION_14 : 14, 
//黄金召唤  
JUMP_FUNCTION_15 : 15, 
//好友  
JUMP_FUNCTION_16 : 16, 
//充值  
JUMP_FUNCTION_17 : 17, 
//vip  
JUMP_FUNCTION_18 : 18, 
//跨服演武  
JUMP_FUNCTION_19 : 19, 
//激战虎牢关  
JUMP_FUNCTION_20 : 20, 
//百战沙场  
JUMP_FUNCTION_21 : 21, 
//决战赤壁  
JUMP_FUNCTION_22 : 22, 
//将星召唤  
JUMP_FUNCTION_23 : 23, 
//布阵  
JUMP_FUNCTION_24 : 24, 
//阵容  
JUMP_FUNCTION_25 : 25, 
//大黄庭  
JUMP_FUNCTION_26 : 26, 
//邮件  
JUMP_FUNCTION_27 : 27, 
//回收  
JUMP_FUNCTION_28 : 28, 
//道具  
JUMP_FUNCTION_29 : 29, 
//觉醒道具  
JUMP_FUNCTION_30 : 30, 
//胭脂榜  
JUMP_FUNCTION_31 : 31, 
//侠客商店  
JUMP_FUNCTION_32 : 32, 
//日常任务  
JUMP_FUNCTION_33 : 33, 
//阵容推荐  
JUMP_FUNCTION_34 : 34, 
//运营活动  
JUMP_FUNCTION_35 : 35, 
//7日活动  
JUMP_FUNCTION_36 : 36, 
//签到  
JUMP_FUNCTION_37 : 37, 
//我要变强  
JUMP_FUNCTION_38 : 38, 
//开服庆典  
JUMP_FUNCTION_39 : 39, 
//寻访  
JUMP_FUNCTION_40 : 40, 
//占山为王  
JUMP_FUNCTION_41 : 41, 
//帮派  
JUMP_FUNCTION_42 : 42, 
//豪侠传  
JUMP_FUNCTION_43 : 43, 
//灵宠  
JUMP_FUNCTION_44 : 44, 
//灵宠洞天  
JUMP_FUNCTION_45 : 45, 
//连续登陆n天，从创角开始算，断了重新计 
TASK_TYPE_1 : 1, 
//累计登陆n天，从创角开始算 
TASK_TYPE_2 : 2, 
//登陆 
TASK_TYPE_3 : 3, 
//主角达到n级 
TASK_TYPE_4 : 4, 
//战斗力达到n 
TASK_TYPE_5 : 5, 
//主线副本胜利n次 
TASK_TYPE_6 : 6, 
//雪刀传胜利n次 
TASK_TYPE_7 : 7, 
//日常副本胜利n次 
TASK_TYPE_8 : 8, 
//精英副本胜利n次 
TASK_TYPE_9 : 9, 
//主线副本星数达到n 
TASK_TYPE_10 : 10, 
//精英副本星数达到n 
TASK_TYPE_11 : 11, 
//通关主线副本第n章 
TASK_TYPE_12 : 12, 
//通关精英副本第n章 
TASK_TYPE_13 : 13, 
//通关雪刀传第n章 
TASK_TYPE_14 : 14, 
//武将培养n次 
TASK_TYPE_15 : 15, 
//装备强化n次 
TASK_TYPE_16 : 16, 
//装备精炼n次 
TASK_TYPE_17 : 17, 
//宝物合成n次 
TASK_TYPE_18 : 18, 
//宝物强化n次 
TASK_TYPE_19 : 19, 
//宝物精炼n次 
TASK_TYPE_20 : 20, 
//武将进阶n次 
TASK_TYPE_21 : 21, 
//上阵武将最高天命等级达到n级 
TASK_TYPE_22 : 22, 
//上阵n名武将等级达到m级 
TASK_TYPE_25 : 25, 
//上阵n名武将天命达到m级 
TASK_TYPE_26 : 26, 
//上阵n名武将突破达到m级 
TASK_TYPE_27 : 27, 
//上阵n名武将觉醒达到m级 
TASK_TYPE_28 : 28, 
//上阵n名武将穿齐四件装备 
TASK_TYPE_29 : 29, 
//上阵n名武将穿齐两件宝物 
TASK_TYPE_30 : 30, 
//6名上阵武将全部穿齐4件强化等级n以上装备 
TASK_TYPE_31 : 31, 
//6名上阵武将全部穿齐4件n品质以上装备 
TASK_TYPE_32 : 32, 
//6名上阵武将全部穿齐4件精炼等级n以上装备 
TASK_TYPE_33 : 33, 
//6名上阵武将全部穿齐2件精炼等级n以上宝物 
TASK_TYPE_34 : 34, 
//穿戴装备最高精炼等级达到n级 
TASK_TYPE_35 : 35, 
//穿戴宝物最高精炼等级达到n级 
TASK_TYPE_36 : 36, 
//武评榜胜利n次 
TASK_TYPE_37 : 37, 
//武评榜历史最高排名达到n名 
TASK_TYPE_38 : 38, 
//勇闯武帝城胜利n次 
TASK_TYPE_39 : 39, 
//勇闯武帝城重置n次 
TASK_TYPE_40 : 40, 
//勇闯武帝城星数达到n 
TASK_TYPE_41 : 41, 
//勇闯武帝城最高排名达到n 
TASK_TYPE_42 : 42, 
//叛军攻打n次 
TASK_TYPE_43 : 43, 
//终结叛军n次 
TASK_TYPE_44 : 44, 
//分享叛军n次 
TASK_TYPE_45 : 45, 
//叛军伤害达到n 
TASK_TYPE_46 : 46, 
//叛军功勋达到n 
TASK_TYPE_47 : 47, 
//普通召唤n次 
TASK_TYPE_48 : 48, 
//黄金召唤n次 
TASK_TYPE_49 : 49, 
//购买id为m的道具n个 
TASK_TYPE_50 : 50, 
//夺宝胜利n次 
TASK_TYPE_51 : 51, 
//合成m品质宝物n个 
TASK_TYPE_52 : 52, 
//解决暴动n次 
TASK_TYPE_53 : 53, 
//领地巡逻n小时 
TASK_TYPE_54 : 54, 
//神将商店刷新n次 
TASK_TYPE_55 : 55, 
//神将商店购买n次商品 
TASK_TYPE_56 : 56, 
//赠送精力n次 
TASK_TYPE_57 : 57, 
//vip等级达到n级 
TASK_TYPE_58 : 58, 
//开服7天内累计充值n元 
TASK_TYPE_59 : 59, 
//从创角开始累计充值n元 
TASK_TYPE_60 : 60, 
//将星招募n次 
TASK_TYPE_61 : 61, 
//点将n次 
TASK_TYPE_62 : 62, 
//购买体力丹n个 
TASK_TYPE_63 : 63, 
//购买精力丹n个 
TASK_TYPE_64 : 64, 
//击杀精英外敌n次 
TASK_TYPE_65 : 65, 
//百战沙场重置n次 
TASK_TYPE_66 : 66, 
//虎牢关胜利n次 
TASK_TYPE_67 : 67, 
//名将试炼胜利n次 
TASK_TYPE_68 : 68, 
//6名上阵武将全部穿齐2件n品质以上宝物 
TASK_TYPE_69 : 69, 
//n名上阵武品质达到条件1及以上 
TASK_TYPE_70 : 70, 
//加入或创建军团 
TASK_TYPE_71 : 71, 
//军团高级祭天n次 
TASK_TYPE_72 : 72, 
//消耗n声望 
TASK_TYPE_73 : 73, 
//消耗n威名 
TASK_TYPE_74 : 74, 
//消耗n战功 
TASK_TYPE_75 : 75, 
//消耗n将魂 
TASK_TYPE_76 : 76, 
//消耗n元宝 
TASK_TYPE_77 : 77, 
//从接到任务开始充值n元 
TASK_TYPE_78 : 78, 
//上阵n名橙色侠客 
TASK_TYPE_79 : 79, 
//胭脂榜取悦n次 
TASK_TYPE_80 : 80, 
//武帝城精英挑战通过n关 
TASK_TYPE_81 : 81, 
//元宝培养n次 
TASK_TYPE_82 : 82, 
//快马加鞭n次 
TASK_TYPE_83 : 83, 
//军团祭天n次 
TASK_TYPE_84 : 84, 
//豪侠激活条目数达n个 
TASK_TYPE_85 : 85, 
//豪侠激活阵图值达n 
TASK_TYPE_86 : 86, 
//单笔充值n元 
TASK_TYPE_87 : 87, 
//护佑和出战灵宠等级总数达到n 
TASK_TYPE_88 : 88, 
//护佑和出战灵宠灵印总数达到n 
TASK_TYPE_89 : 89, 
//护佑和出战灵宠星级总数达到n 
TASK_TYPE_90 : 90, 
//帮派祭天累计贡献达到n 
TASK_TYPE_91 : 91, 
//江湖寻访完成n次 
TASK_TYPE_92 : 92, 
//豪侠试炼胜利n次 
TASK_TYPE_93 : 93, 
//上阵武将觉醒星级总数达到n 
TASK_TYPE_94 : 94, 
//上阵武将天命总数达到n 
TASK_TYPE_95 : 95, 
//上阵武将装备精炼等级总数达到n 
TASK_TYPE_96 : 96, 
//上阵武将装备星级总数达到n 
TASK_TYPE_97 : 97, 
//上阵武将宝物强化等级总数达到n 
TASK_TYPE_98 : 98, 
//攻城略地关卡胜利n次 
TASK_TYPE_99 : 99, 
//跨服战攻打n次 
TASK_TYPE_100 : 100, 
//从接到任务开始充值n元宝 
TASK_TYPE_101 : 101, 
//宠物副本通关层数最高达到n 
TASK_TYPE_102 : 102, 
//宠物副本通关关数最高达到n 
TASK_TYPE_103 : 103, 
//宠物副本重置n次 
TASK_TYPE_104 : 104, 
//宠物副本在有阵营为m的侠客参战的情况下通关关数最高达到n(手动才算) 
TASK_TYPE_105 : 105, 
//宠物副本获得id为m的道具n个 
TASK_TYPE_106 : 106, 
//宠物副本胜利n次 
TASK_TYPE_107 : 107, 
//宠物副本通关n层 
TASK_TYPE_108 : 108, 
//宠物副本满心灯过n关 
TASK_TYPE_109 : 109, 
//宠物副本一键通关n次 
TASK_TYPE_110 : 110, 
//体力自动恢复 
AUTO_RECOVERY_POWER : 1, 
//精力力自动恢复 
AUTO_RECOVERY_ENERGY : 2, 
//征讨令自动恢复 
AUTO_RECOVERY_CRUSADE : 3, 
//粮草自动恢复 
AUTO_RECOVERY_FORAGE : 4, 
//可攻打次数自动恢复 
AUTO_RECOVERY_ATTACK_CNT : 5, 
//跨服积分赛挑战次数自动恢复 
AUTO_RECOVERY_CSPOINTSRACE_CNT : 9, 
//武评榜奖励 
MAIL_TEMPLETE_1 : 1, 
//叛军功勋排名奖励 
MAIL_TEMPLETE_2 : 2, 
//叛军伤害排名奖励 
MAIL_TEMPLETE_3 : 3, 
//勇闯武帝城扫荡 
MAIL_TEMPLETE_4 : 4, 
//GM后台发东西 
MAIL_TEMPLETE_5 : 5, 
//GM发邮件说话 
MAIL_TEMPLETE_6 : 6, 
//对话 
MAIL_TEMPLETE_7 : 7, 
//加好友的申请 
MAIL_TEMPLETE_8 : 8, 
//申请成功的反馈 
MAIL_TEMPLETE_9 : 9, 
//发现叛军奖励 
MAIL_TEMPLETE_10 : 10, 
//击杀叛军 
MAIL_TEMPLETE_11 : 11, 
//充值成功 
MAIL_TEMPLETE_12 : 12, 
//月卡充值 
MAIL_TEMPLETE_13 : 13, 
//礼品码领奖 
MAIL_TEMPLETE_14 : 14, 
//武评榜防守失败 
MAIL_TEMPLETE_15 : 15, 
//武评榜防守成功 
MAIL_TEMPLETE_16 : 16, 
//防守失败（名次未下降） 
MAIL_TEMPLETE_17 : 17, 
//同意军团申请 
MAIL_TEMPLETE_18 : 18, 
//踢出军团通知 
MAIL_TEMPLETE_19 : 19, 
//军团解散（手动） 
MAIL_TEMPLETE_20 : 20, 
//军团解散（自动） 
MAIL_TEMPLETE_21 : 21, 
//军团排行发奖 
MAIL_TEMPLETE_22 : 22, 
//申请军团被拒 
MAIL_TEMPLETE_23 : 23, 
//任命副军团长通知 
MAIL_TEMPLETE_24 : 24, 
//罢免职位通知 
MAIL_TEMPLETE_25 : 25, 
//任命为军团长通知 
MAIL_TEMPLETE_26 : 26, 
//封测充值返还通知 
MAIL_TEMPLETE_27 : 27, 
//转盘领奖 
MAIL_TEMPLETE_28 : 28, 
//群英战离线贡献 
MAIL_TEMPLETE_29 : 29, 
//应用宝奖励 
MAIL_TEMPLETE_30 : 30, 
//巡游领奖 
MAIL_TEMPLETE_31 : 31, 
//巡回领奖 
MAIL_TEMPLETE_32 : 32, 
//跨服积分赛排名奖励北凉 
MAIL_TEMPLETE_33 : 33, 
//跨服积分赛排名奖励离阳 
MAIL_TEMPLETE_34 : 34, 
//跨服积分赛排名奖励北莽 
MAIL_TEMPLETE_35 : 35, 
//跨服积分赛排名奖励江湖 
MAIL_TEMPLETE_36 : 36, 
//巡游领奖 
MAIL_TEMPLETE_37 : 37, 
//跨服争霸赛排名奖励 
MAIL_TEMPLETE_38 : 38, 
//叛军首领最高伤害排名北凉 
MAIL_TEMPLETE_39 : 39, 
//叛军首领最高伤害排名离阳 
MAIL_TEMPLETE_40 : 40, 
//叛军首领最高伤害排名北莽 
MAIL_TEMPLETE_41 : 41, 
//叛军首领最高伤害排名江湖 
MAIL_TEMPLETE_42 : 42, 
//叛军首领累计荣誉排名北凉 
MAIL_TEMPLETE_43 : 43, 
//叛军首领累计荣誉排名离阳 
MAIL_TEMPLETE_44 : 44, 
//叛军首领累计荣誉排名北莽 
MAIL_TEMPLETE_45 : 45, 
//叛军首领累计荣誉排名江湖 
MAIL_TEMPLETE_46 : 46, 
//叛军首领幸运一击奖励 
MAIL_TEMPLETE_47 : 47, 
//叛军首领击杀奖励 
MAIL_TEMPLETE_48 : 48, 
//争霸赛防守失败提示 
MAIL_TEMPLETE_49 : 49, 
//争霸赛防守成功提示 
MAIL_TEMPLETE_50 : 50, 
//优惠充值 
MAIL_TEMPLETE_51 : 51, 
//押注异常 
MAIL_TEMPLETE_52 : 52, 
//叛军首领-军团排名奖励 
MAIL_TEMPLETE_53 : 53, 
//奇门八卦奖励 
MAIL_TEMPLETE_54 : 54, 
//击杀叛军奖励 
MAIL_TEMPLETE_55 : 55, 
//攻击叛军奖励 
MAIL_TEMPLETE_56 : 56, 
//叛军伤害奖励 
MAIL_TEMPLETE_57 : 57, 
//开服庆典 
MAIL_TEMPLETE_58 : 58, 
//弹劾失败 
MAIL_TEMPLETE_59 : 59, 
//弹劾成功 
MAIL_TEMPLETE_60 : 60, 
//新手邮件 
MAIL_TEMPLETE_61 : 61, 
//据点收益邮件(据点被攻下) 
MAIL_TEMPLETE_64 : 64, 
//所占收益邮件(更换据点) 
MAIL_TEMPLETE_65 : 65, 
//据点被攻下 
MAIL_TEMPLETE_66 : 66, 
//攻城掠地重置奖励 
MAIL_TEMPLETE_67 : 67, 
//攻城掠地活跃奖励 
MAIL_TEMPLETE_68 : 68, 
//武帝战败奖励 
MAIL_TEMPLETE_69 : 69, 
//武帝战胜奖励 
MAIL_TEMPLETE_70 : 70, 
//武帝伤害排行奖励 
MAIL_TEMPLETE_71 : 71, 
//永久卡充值 
MAIL_TEMPLETE_72 : 72, 
//帮派消灭排行 
MAIL_TEMPLETE_73 : 73, 
//单次伤害排行 
MAIL_TEMPLETE_74 : 74, 
//全服伤害排行 
MAIL_TEMPLETE_75 : 75, 
//全服斩杀排行 
MAIL_TEMPLETE_76 : 76, 
//全服推图排行 
MAIL_TEMPLETE_77 : 77, 
//帮派副本通关奖励 
MAIL_TEMPLETE_78 : 78, 
//豪华签到奖励 
MAIL_TEMPLETE_79 : 79, 
//帮派副本奖励 
MAIL_TEMPLETE_80 : 80, 
//跨服积分赛奖励 
MAIL_TEMPLETE_81 : 81, 
//年兽排行奖励 
MAIL_TEMPLETE_82 : 82, 
//年兽斩杀奖励 
MAIL_TEMPLETE_83 : 83, 
//天降福袋 
MAIL_TEMPLETE_84 : 84, 
//宠物副本宝箱奖励 
MAIL_TEMPLETE_85 : 85, 
//宠物副本一键奖励 
MAIL_TEMPLETE_86 : 86, 
//河灯排行奖励 
MAIL_TEMPLETE_87 : 87, 
//团购 
MAIL_TEMPLETE_88 : 88, 
//团购大奖 
MAIL_TEMPLETE_89 : 89, 
//增加 
INC_OPER_TYPE_ADD : 1, 
//删除 
INC_OPER_TYPE_DEL : 2, 
//修改 
INC_OPER_TYPE_MODIFY : 3, 
//武评榜名次突破 
SPECIAL_AWARD_ARENA : 1, 
//雪刀传首胜 
SPECIAL_AWARD_FAMOUS : 2, 
//宝物背包容量额外增加#value1# 
VIP_PRIVILEGE_TYPE_1 : 1, 
//觉醒商店每日可刷新#value1#次 
VIP_PRIVILEGE_TYPE_2 : 2, 
//开启培养#value1#次功能 
VIP_PRIVILEGE_TYPE_3 : 3, 
//开启胭脂榜取悦#value1#次 
VIP_PRIVILEGE_TYPE_4 : 4, 
//开启战斗3倍速 
VIP_PRIVILEGE_TYPE_5 : 5, 
//每日可购买商店某一物品次数 
VIP_PRIVILEGE_TYPE_6 : 6, 
//神秘商店每日可刷新#value1#次 
VIP_PRIVILEGE_TYPE_7 : 7, 
//武帝城精英挑战每日可购买#value1#次 
VIP_PRIVILEGE_TYPE_8 : 8, 
//武帝城每日重置#value1#次 
VIP_PRIVILEGE_TYPE_9 : 9, 
//武将背包容量额外增加#value1# 
VIP_PRIVILEGE_TYPE_10 : 10, 
//雪刀传每日可挑战#value1#次 
VIP_PRIVILEGE_TYPE_11 : 11, 
//主线副本每日可重置#value1#次 
VIP_PRIVILEGE_TYPE_12 : 12, 
//开启叛军跳过功能 
VIP_PRIVILEGE_TYPE_13 : 13, 
//开启宝物一键升级功能 
VIP_PRIVILEGE_TYPE_14 : 14, 
//开启侠客一键升级功能 
VIP_PRIVILEGE_TYPE_15 : 15, 
//开启装备一键强化功能 
VIP_PRIVILEGE_TYPE_16 : 16, 
//开启装备一键升星功能 
VIP_PRIVILEGE_TYPE_17 : 17, 
//帮派签到开启高等祭天功能 
VIP_PRIVILEGE_TYPE_18 : 18, 
//开启20连抽功能 
VIP_PRIVILEGE_TYPE_19 : 19, 
//开启主线副本一键扫荡功能 
VIP_PRIVILEGE_TYPE_20 : 20, 
//开启武帝城扫荡功能 
VIP_PRIVILEGE_TYPE_21 : 21, 
//开启武帝城一键3星功能 
VIP_PRIVILEGE_TYPE_22 : 22, 
//开启胭脂榜一键合成宝物功能 
VIP_PRIVILEGE_TYPE_23 : 23, 
//开启主线副本扫荡功能 
VIP_PRIVILEGE_TYPE_24 : 24, 
//装备强化#value1#%概率额外提升1级 
VIP_PRIVILEGE_TYPE_25 : 25, 
//装备强化#value1#%概率额外提升2级 
VIP_PRIVILEGE_TYPE_26 : 26, 
//开启创建帮派功能 
VIP_PRIVILEGE_TYPE_27 : 27, 
//开启叛军快捷攻打功能 
VIP_PRIVILEGE_TYPE_28 : 28, 
//开启武评榜连战5次功能 
VIP_PRIVILEGE_TYPE_29 : 29, 
//开启阵容位置一键强化功能 
VIP_PRIVILEGE_TYPE_30 : 30, 
//开启阵容位置一键装备功能 
VIP_PRIVILEGE_TYPE_31 : 31, 
//寻访一键寻访 
VIP_PRIVILEGE_TYPE_32 : 32, 
//寻访一键领取路线奖励 
VIP_PRIVILEGE_TYPE_33 : 33, 
//寻访一键领取好友奖励 
VIP_PRIVILEGE_TYPE_34 : 34, 
//寻访一键给好友路线加速 
VIP_PRIVILEGE_TYPE_35 : 35, 
//抽卡自动分解 
VIP_PRIVILEGE_TYPE_36 : 36, 
//抽卡类型 
VIP_PRIVILEGE_TYPE_37 : 37, 
//豪侠商店每日可刷新#value1#次 
VIP_PRIVILEGE_TYPE_38 : 38, 
//豪侠传试炼免费刷新#value1#次 
VIP_PRIVILEGE_TYPE_39 : 39, 
//豪侠传试炼每日可刷新#value1#次 
VIP_PRIVILEGE_TYPE_40 : 40, 
//豪侠传试炼每日可挑战#value1#次 
VIP_PRIVILEGE_TYPE_41 : 41, 
//开启豪侠卡合成 
VIP_PRIVILEGE_TYPE_42 : 42, 
//灵宠商店每日可刷新#value1#次 
VIP_PRIVILEGE_TYPE_43 : 43, 
//宠物副本每日可重置#value1#次 
VIP_PRIVILEGE_TYPE_44 : 44, 
//宠物副本一键通关 
VIP_PRIVILEGE_TYPE_45 : 45, 
//是否有新邮件 
SYSTEM_UPDATE_MAIL : 1, 
//是否有叛军奖励 
SYSTEM_UPDATE_REBEL_REWARD : 2, 
//是否有好友申请 
SYSTEM_UPDATE_FRIEND_APPLY : 3, 
//活动是否需要更新 
SYSTEM_UPDATE_ACTIVITY : 4, 
//叛军出现 
SYSTEM_UPDATE_REBEL_APPEAR : 5, 
//侠义商店更新CD 
SYSTEM_UPDATE_HAOXIA_SHOP : 6, 
//是否有年兽任务未完成 
SYSTEM_UPDATE_HAS_NIANTASK : 7, 
//订阅河灯 
SUBSCRIBE_RIVER_LANTERN : 1, 
//订阅团购 
SUBSCRIBE_GROUPON : 2, 
PLATFORM_OS_WINDOWS : 0, 
PLATFORM_OS_LINUX : 1, 
PLATFORM_OS_MAC : 2, 
PLATFORM_OS_ANDROID : 3, 
PLATFORM_OS_IPHONE : 4, 
PLATFORM_OS_IPAD : 5, 
PLATFORM_OS_BLACKBERRY : 6, 
PLATFORM_OS_NACL : 7, 
PLATFORM_OS_EMSCRIPTEN : 8, 
PLATFORM_OS_TIZEN : 9, 
PLATFORM_OS_WINRT : 10, 
PLATFORM_OS_WP8 : 11, 
//重复登录 
KICK_ROLE_REASON_REPEAT_LOGIN : 1, 
//GM踢人 
KICK_ROLE_REASON_GM_KICK : 2, 
//被封号 
KICK_ROLE_REASON_BAN_USER : 3, 
//每天的一个时间段 
LIMITED_TIME_BUY_COND_DAYTIME : 1, 
//等级触发 
LIMITED_TIME_BUY_COND_LEVEL : 2, 
//道具商城 
LIMITED_TIME_BUY_TYPE_SHOP : 1, 
//充值购买 
LIMITED_TIME_BUY_TYPE_RECHARGE : 2, 
//空闲 
PET_IDLE : 0, 
//护佑 
PET_BLESS : 1, 
//上阵 
PET_ONFIGHT : 2, 
};
exports = module.exports = DEF_Configs;