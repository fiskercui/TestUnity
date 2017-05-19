using System.Collections.Generic; 
 public class DisabledCharsetProperty
{
	public TableHeadInfo TResHeadAll;
	public List<DisabledCharsetObject> DisabledCharset{ get; set;}
}
public class DisabledCharsetObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string chars{ get; set;}
}
