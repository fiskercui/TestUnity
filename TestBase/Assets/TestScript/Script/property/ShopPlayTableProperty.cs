using System.Collections.Generic; 
 public class ShopPlayTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ShopPlayTableObject> ShopPlayTable{ get; set;}
}
public class ShopPlayTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int shopType{ get; set;}
	 public int shopPage{ get; set;}
	 public int limit_level{ get; set;}
	 public int type{ get; set;}
	 public int value{ get; set;}
	 public int num{ get; set;}
	 public int buy_type1{ get; set;}
	 public int buy_value1{ get; set;}
	 public int buy_num1{ get; set;}
	 public int buy_type2{ get; set;}
	 public int buy_value2{ get; set;}
	 public int buy_num2{ get; set;}
	 public int buy_type3{ get; set;}
	 public int buy_value3{ get; set;}
	 public int buy_num3{ get; set;}
	 public int num_limit_type{ get; set;}
	 public int num_limit_vip0{ get; set;}
	 public int num_limit_vip1{ get; set;}
	 public int num_limit_vip2{ get; set;}
	 public int num_limit_vip3{ get; set;}
	 public int num_limit_vip4{ get; set;}
	 public int num_limit_vip5{ get; set;}
	 public int num_limit_vip6{ get; set;}
	 public int num_limit_vip7{ get; set;}
	 public int num_limit_vip8{ get; set;}
	 public int num_limit_vip9{ get; set;}
	 public int num_limit_vip10{ get; set;}
	 public int num_limit_vip11{ get; set;}
	 public int num_limit_vip12{ get; set;}
	 public int seq{ get; set;}
	 public int effect{ get; set;}
	 public int buy_limit_type1{ get; set;}
	 public int buy_limit_value1{ get; set;}
	 public int buy_limit_type2{ get; set;}
	 public int buy_limit_value2{ get; set;}
	 public string desc{ get; set;}
	 public string discount{ get; set;}
	 public int original_price{ get; set;}
	 public int step_price_type{ get; set;}
}
