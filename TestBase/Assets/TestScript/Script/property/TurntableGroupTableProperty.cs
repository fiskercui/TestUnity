using System.Collections.Generic; 
 public class TurntableGroupTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TurntableGroupTableObject> TurntableGroupTable{ get; set;}
}
public class TurntableGroupTableObject{
	 public AttributeInfo @attributes;
	 public int gid{ get; set;}
	 public int weight{ get; set;}
}
