using System.Collections.Generic; 
 public class LegionEventTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LegionEventTableObject> LegionEventTable{ get; set;}
}
public class LegionEventTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
}
