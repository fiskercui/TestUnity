using System.Collections.Generic; 
 public class RadioItemTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RadioItemTableObject> RadioItemTable{ get; set;}
}
public class RadioItemTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string desc{ get; set;}
	 public int item_id{ get; set;}
	 public int select_num{ get; set;}
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
}
