using System.Collections.Generic; 
 public class TurntableConsumeTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TurntableConsumeTableObject> TurntableConsumeTable{ get; set;}
}
public class TurntableConsumeTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int value{ get; set;}
	 public int item_type{ get; set;}
	 public int item_id{ get; set;}
	 public int item_num{ get; set;}
}
