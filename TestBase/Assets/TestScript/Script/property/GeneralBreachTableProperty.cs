using System.Collections.Generic; 
 public class GeneralBreachTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<GeneralBreachTableObject> GeneralBreachTable{ get; set;}
}
public class GeneralBreachTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int role_type{ get; set;}
	 public int advanced_level{ get; set;}
	 public int level_ban{ get; set;}
	 public int cost1_type{ get; set;}
	 public int cost1_value{ get; set;}
	 public int cost1_num{ get; set;}
	 public int cost2_type{ get; set;}
	 public int cost2_value{ get; set;}
	 public int cost2_num{ get; set;}
	 public int cost3_type{ get; set;}
	 public int cost3_value{ get; set;}
	 public int cost3_num{ get; set;}
	 public int cost_money{ get; set;}
}
