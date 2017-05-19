using System.Collections.Generic; 
 public class SlotMachineTaskTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<SlotMachineTaskTableObject> SlotMachineTaskTable{ get; set;}
}
public class SlotMachineTaskTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string task_desc{ get; set;}
	 public int min_level{ get; set;}
	 public int max_level{ get; set;}
	 public int task_type{ get; set;}
	 public int task_num{ get; set;}
	 public int jump_type{ get; set;}
	 public int condition_type{ get; set;}
	 public int condition_value_1{ get; set;}
	 public int condition_value_2{ get; set;}
	 public int item_type_1{ get; set;}
	 public int item_value_1{ get; set;}
	 public int item_num_1{ get; set;}
	 public int item_type_2{ get; set;}
	 public int item_value_2{ get; set;}
	 public int item_num_2{ get; set;}
	 public int item_type_3{ get; set;}
	 public int item_value_3{ get; set;}
	 public int item_num_3{ get; set;}
	 public int item_type_4{ get; set;}
	 public int item_value_4{ get; set;}
	 public int item_num_4{ get; set;}
	 public int progress{ get; set;}
	 public int exchange_type{ get; set;}
	 public int exchange_id{ get; set;}
	 public int exchange_num{ get; set;}
	 public string tag{ get; set;}
	 public int in_use{ get; set;}
}
