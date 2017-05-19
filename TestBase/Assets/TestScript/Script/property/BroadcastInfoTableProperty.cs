using System.Collections.Generic; 
 public class BroadcastInfoTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<BroadcastInfoTableObject> BroadcastInfoTable{ get; set;}
}
public class BroadcastInfoTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string text{ get; set;}
}
