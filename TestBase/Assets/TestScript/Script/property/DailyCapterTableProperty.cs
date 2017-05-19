using System.Collections.Generic; 
 public class DailyCapterTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<DailyCapterTableObject> DailyCapterTable{ get; set;}
}
public class DailyCapterTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
	 public string timeopen{ get; set;}
	 public string icon{ get; set;}
	 public int role{ get; set;}
	 public string mapids{ get; set;}
	 public string powers{ get; set;}
	 public string lvls{ get; set;}
}
