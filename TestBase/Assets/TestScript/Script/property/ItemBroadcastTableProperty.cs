using System.Collections.Generic; 
 public class ItemBroadcastTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ItemBroadcastTableObject> ItemBroadcastTable{ get; set;}
}
public class ItemBroadcastTableObject{
	 public AttributeInfo @attributes;
	 public int item_id{ get; set;}
	 public int check_type{ get; set;}
	 public int check_value{ get; set;}
	 public int check_num{ get; set;}
	 public int broadcast_id{ get; set;}
}
