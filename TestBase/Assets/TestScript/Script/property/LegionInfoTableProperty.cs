using System.Collections.Generic; 
 public class LegionInfoTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LegionInfoTableObject> LegionInfoTable{ get; set;}
}
public class LegionInfoTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int level{ get; set;}
	 public int exp{ get; set;}
	 public int boss_fight_count{ get; set;}
	 public int number{ get; set;}
	 public int plunder_exp{ get; set;}
	 public int worship_value_1{ get; set;}
	 public int item_type_1{ get; set;}
	 public int item_id_1{ get; set;}
	 public int item_size_1{ get; set;}
	 public int worship_value_2{ get; set;}
	 public int item_type_2{ get; set;}
	 public int item_id_2{ get; set;}
	 public int item_size_2{ get; set;}
	 public int worship_value_3{ get; set;}
	 public int item_type_3{ get; set;}
	 public int item_id_3{ get; set;}
	 public int item_size_3{ get; set;}
	 public int worship_value_4{ get; set;}
	 public int item_type_4{ get; set;}
	 public int item_id_4{ get; set;}
	 public int item_size_4{ get; set;}
}
