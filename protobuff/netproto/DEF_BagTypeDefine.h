#ifndef DEF_BAGTYPEDEFINE_H
#define DEF_BAGTYPEDEFINE_H
/**背包类型定义**/
enum DEF_BagTypeDefine {
/**物品背包; **/
	BAG_TYPE_ITEM = 1 ,
/**装备背包; **/
	BAG_TYPE_EQUIP = 2 ,
/**穿戴背包;  0~23**/
	BAG_TYPE_CHUANDAI = 3 ,
/**觉醒道具背包;**/
	BAG_TYPE_AWAKEN = 4 ,
/**碎片类背包**/
	BAG_TYPE_CHIP = 5 ,
/**宝物背包; **/
	BAG_TYPE_TREASURE = 6 ,
/**宝物穿戴背包;  0~11**/
	BAG_TYPE_TREASURE_INSTALL = 7 ,
/**时装背包; **/
	BAG_TYPE_FASHION = 8 ,
/**时装穿戴背包;  0(只有一件)**/
	BAG_TYPE_FASHION_INSTALL = 10 ,
/**豪侠背包; **/
	BAG_TYPE_GALLANT = 11 ,
/**上阵宠物; **/
	BAG_TYPE_PET_ONFIGHT = 12 ,
/**护佑宠物; **/
	BAG_TYPE_PET_BLESS = 13 ,
/**待命宠物; **/
	BAG_TYPE_PET_IDLE = 14 ,
};
#endif