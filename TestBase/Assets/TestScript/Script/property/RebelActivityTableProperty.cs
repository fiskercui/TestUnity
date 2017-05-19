using System.Collections.Generic; 
 public class RebelActivityTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelActivityTableObject> RebelActivityTable{ get; set;}
}
public class RebelActivityTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int value{ get; set;}
	 public string start_time{ get; set;}
	 public string end_time{ get; set;}
	 public string desc{ get; set;}
}
