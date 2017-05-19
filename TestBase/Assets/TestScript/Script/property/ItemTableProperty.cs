using System.Collections.Generic; 
 public class ItemTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ItemTableObject> ItemTable{ get; set;}
}
public class ItemTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string icon{ get; set;}
	 public int item_type{ get; set;}
	 public int item_type_value{ get; set;}
	 public int stackCeil{ get; set;}
	 public int quality{ get; set;}
	 public string description{ get; set;}
	 public int use_type{ get; set;}
	 public int use_level{ get; set;}
	 public int is_drop{ get; set;}
	 public string tip{ get; set;}
	 public int gm{ get; set;}
	 public int live_time{ get; set;}
	 public string close_date{ get; set;}
	 public int activity_type{ get; set;}
}
