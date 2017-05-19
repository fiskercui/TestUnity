using System.Collections.Generic; 
 public class ZhaohuanBaseTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ZhaohuanBaseTableObject> ZhaohuanBaseTable{ get; set;}
}
public class ZhaohuanBaseTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int group{ get; set;}
	 public int awardSilver{ get; set;}
	 public int priorityUseType{ get; set;}
	 public int priorityUseItemId{ get; set;}
	 public int priorityUseItemCount{ get; set;}
	 public int useType{ get; set;}
	 public int useItemId{ get; set;}
	 public int useItemCount{ get; set;}
	 public int fiveFlag{ get; set;}
	 public int useItemCountForFive{ get; set;}
	 public int tenFlag{ get; set;}
	 public int useItemCountForTen{ get; set;}
	 public string dropPackageForTen{ get; set;}
	 public int freeCount{ get; set;}
	 public int freeCD{ get; set;}
	 public string nodeId{ get; set;}
	 public string desc{ get; set;}
	 public int tenDiscount{ get; set;}
	 public string btnRes{ get; set;}
	 public string sceneRes{ get; set;}
	 public string titleRes{ get; set;}
	 public int sort{ get; set;}
	 public int defOpen{ get; set;}
	 public string name{ get; set;}
	 public int shareLuckId{ get; set;}
	 public int luckPackageId{ get; set;}
	 public int belongto{ get; set;}
	 public int extra_reward_type{ get; set;}
	 public int extra_reward_id{ get; set;}
	 public int extra_reward_num{ get; set;}
}
