using System.Collections.Generic; 
 public class ArenaShopTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ArenaShopTableObject> ArenaShopTable{ get; set;}
}
public class ArenaShopTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int type{ get; set;}
	 public int rank_limit{ get; set;}
	 public int level_limit{ get; set;}
	 public int quota_type{ get; set;}
	 public int quota_time{ get; set;}
	 public int item_type{ get; set;}
	 public int item_id{ get; set;}
	 public int item_value{ get; set;}
	 public int currency_1_type{ get; set;}
	 public int currency_1_value{ get; set;}
	 public int currency_2_type{ get; set;}
	 public int currency_2_value{ get; set;}
	 public int sale_id{ get; set;}
}
