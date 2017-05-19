using System.Collections.Generic; 
 public class RechargeTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RechargeTableObject> RechargeTable{ get; set;}
}
public class RechargeTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int app_id{ get; set;}
	 public string product_id{ get; set;}
	 public string name{ get; set;}
	 public string res_id{ get; set;}
	 public int size{ get; set;}
	 public int recharge_gold{ get; set;}
	 public int gift_gold_first{ get; set;}
	 public int gift_gold{ get; set;}
}
