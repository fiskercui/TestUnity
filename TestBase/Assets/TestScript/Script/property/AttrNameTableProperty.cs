using System.Collections.Generic; 
 public class AttrNameTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<AttrNameTableObject> AttrNameTable{ get; set;}
}
public class AttrNameTableObject{
	 public AttributeInfo @attributes;
	 public int attr_id{ get; set;}
	 public string attr_name{ get; set;}
}
