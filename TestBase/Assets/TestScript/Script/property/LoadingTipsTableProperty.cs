using System.Collections.Generic; 
 public class LoadingTipsTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LoadingTipsTableObject> LoadingTipsTable{ get; set;}
}
public class LoadingTipsTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string tips{ get; set;}
	 public int type{ get; set;}
	 public int start_level{ get; set;}
	 public int end_level{ get; set;}
	 public string renwugap{ get; set;}
	 public string wujianggap{ get; set;}
	 public string backgroundgap{ get; set;}
}
