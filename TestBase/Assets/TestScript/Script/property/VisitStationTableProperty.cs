using System.Collections.Generic; 
 public class VisitStationTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<VisitStationTableObject> VisitStationTable{ get; set;}
}
public class VisitStationTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int time{ get; set;}
	 public int speed_up{ get; set;}
	 public int speed_up_limit{ get; set;}
	 public int reward_type1{ get; set;}
	 public int low_reward_value1{ get; set;}
	 public int mid_reward_value1{ get; set;}
	 public int high_reward_value1{ get; set;}
	 public string desc1{ get; set;}
	 public int reward_type2{ get; set;}
	 public int low_reward_value2{ get; set;}
	 public int mid_reward_value2{ get; set;}
	 public int high_reward_value2{ get; set;}
	 public string desc2{ get; set;}
	 public int low_consume_type1{ get; set;}
	 public int low_consume_value1{ get; set;}
	 public int low_consume_type2{ get; set;}
	 public int low_consume_value2{ get; set;}
	 public int mid_consume_type1{ get; set;}
	 public int mid_consume_value1{ get; set;}
	 public int mid_consume_type2{ get; set;}
	 public int mid_consume_value2{ get; set;}
	 public int high_consume_type1{ get; set;}
	 public int high_consume_value1{ get; set;}
	 public int high_consume_type2{ get; set;}
	 public int high_consume_value2{ get; set;}
	 public int event_group{ get; set;}
}
