using System.Collections.Generic; 
 public class SlotMachineActivityTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<SlotMachineActivityTableObject> SlotMachineActivityTable{ get; set;}
}
public class SlotMachineActivityTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int cost_type_1{ get; set;}
	 public int cost_value_1{ get; set;}
	 public int cost_num_1{ get; set;}
	 public int cost_type_2{ get; set;}
	 public int cost_value_2{ get; set;}
	 public int cost_num_2{ get; set;}
	 public int max_in_view{ get; set;}
	 public int real_min{ get; set;}
	 public int real_max{ get; set;}
}
