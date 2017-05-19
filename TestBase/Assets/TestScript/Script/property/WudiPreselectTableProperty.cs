using System.Collections.Generic; 
 public class WudiPreselectTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<WudiPreselectTableObject> WudiPreselectTable{ get; set;}
}
public class WudiPreselectTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int value1{ get; set;}
	 public int value2{ get; set;}
	 public int value3{ get; set;}
}
