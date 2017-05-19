using System.Collections.Generic; 
 public class OpeningBuffTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<OpeningBuffTableObject> OpeningBuffTable{ get; set;}
}
public class OpeningBuffTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int buff{ get; set;}
	 public int target_range{ get; set;}
	 public int target_type{ get; set;}
	 public int value{ get; set;}
	 public int duration{ get; set;}
	 public string desc{ get; set;}
}
