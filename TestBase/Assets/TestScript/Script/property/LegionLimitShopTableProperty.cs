using System.Collections.Generic; 
 public class LegionLimitShopTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LegionLimitShopTableObject> LegionLimitShopTable{ get; set;}
}
public class LegionLimitShopTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int min_level{ get; set;}
	 public int max_level{ get; set;}
	 public int probability{ get; set;}
	 public int item_type{ get; set;}
	 public int item_id{ get; set;}
	 public int item_num{ get; set;}
	 public int buy_num{ get; set;}
	 public int price_type{ get; set;}
	 public int price{ get; set;}
	 public int original_price{ get; set;}
	 public int extra_type{ get; set;}
	 public int extra_value{ get; set;}
	 public int extra_size{ get; set;}
}
