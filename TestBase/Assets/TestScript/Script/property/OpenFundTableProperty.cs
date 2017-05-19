using System.Collections.Generic; 
 public class OpenFundTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<OpenFundTableObject> OpenFundTable{ get; set;}
}
public class OpenFundTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int limit_type{ get; set;}
	 public int limit_num{ get; set;}
	 public int item_type{ get; set;}
	 public int item_id{ get; set;}
	 public int item_num{ get; set;}
}
