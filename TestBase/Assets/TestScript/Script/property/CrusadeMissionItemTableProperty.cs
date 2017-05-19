using System.Collections.Generic; 
 public class CrusadeMissionItemTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CrusadeMissionItemTableObject> CrusadeMissionItemTable{ get; set;}
}
public class CrusadeMissionItemTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int quality{ get; set;}
	 public string icon{ get; set;}
	 public int attr_type{ get; set;}
	 public int attr_value{ get; set;}
	 public int use_limit{ get; set;}
	 public string name{ get; set;}
}
