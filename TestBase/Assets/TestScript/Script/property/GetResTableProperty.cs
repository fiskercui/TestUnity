using System.Collections.Generic; 
 public class GetResTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<GetResTableObject> GetResTable{ get; set;}
}
public class GetResTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string basicDesc{ get; set;}
	 public string tips{ get; set;}
	 public int type{ get; set;}
	 public string itemID{ get; set;}
}
