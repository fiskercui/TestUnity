using System.Collections.Generic; 
 public class MonthCardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<MonthCardTableObject> MonthCardTable{ get; set;}
}
public class MonthCardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int app_id{ get; set;}
	 public string product_id{ get; set;}
	 public string name{ get; set;}
	 public string res_id{ get; set;}
	 public int size{ get; set;}
	 public int recharge_gold{ get; set;}
	 public int gold_back{ get; set;}
	 public int last_day{ get; set;}
}
