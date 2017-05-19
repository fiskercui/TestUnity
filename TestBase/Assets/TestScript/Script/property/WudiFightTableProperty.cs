using System.Collections.Generic; 
 public class WudiFightTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<WudiFightTableObject> WudiFightTable{ get; set;}
}
public class WudiFightTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int wday{ get; set;}
	 public int begin_time{ get; set;}
	 public int end_time{ get; set;}
	 public int attack_cd{ get; set;}
	 public string attack_buff_list{ get; set;}
	 public string attack_buff_cost{ get; set;}
	 public string defend_buff_list1{ get; set;}
	 public string defend_buff_cost1{ get; set;}
	 public string defend_buff_list2{ get; set;}
	 public string defend_buff_cost2{ get; set;}
	 public int attack_reward{ get; set;}
	 public int rank_reward{ get; set;}
	 public int boss_reward{ get; set;}
	 public int default_buff{ get; set;}
}
