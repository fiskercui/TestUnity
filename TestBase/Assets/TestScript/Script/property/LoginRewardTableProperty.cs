using System.Collections.Generic; 
 public class LoginRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LoginRewardTableObject> LoginRewardTable{ get; set;}
}
public class LoginRewardTableObject{
	 public AttributeInfo @attributes;
	 public int month{ get; set;}
	 public int day{ get; set;}
	 public int type{ get; set;}
	 public int item_type1{ get; set;}
	 public int item_id1{ get; set;}
	 public int item_num1{ get; set;}
	 public int item_type2{ get; set;}
	 public int item_id2{ get; set;}
	 public int item_num2{ get; set;}
	 public int item_type3{ get; set;}
	 public int item_id3{ get; set;}
	 public int item_num3{ get; set;}
	 public int vip_double_level{ get; set;}
}
