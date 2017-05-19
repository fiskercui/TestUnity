using System.Collections.Generic; 
 public class LegionLogoTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LegionLogoTableObject> LegionLogoTable{ get; set;}
}
public class LegionLogoTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public string name{ get; set;}
	 public string icon{ get; set;}
	 public int open_type{ get; set;}
	 public int open_value{ get; set;}
	 public string desc{ get; set;}
}
