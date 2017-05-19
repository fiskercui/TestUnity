using System.Collections.Generic; 
 public class AccessPathTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<AccessPathTableObject> AccessPathTable{ get; set;}
}
public class AccessPathTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string remark{ get; set;}
	 public string title{ get; set;}
	 public string desc{ get; set;}
	 public string icon{ get; set;}
	 public int func1{ get; set;}
	 public int func2{ get; set;}
	 public int chapter{ get; set;}
	 public int openLevel{ get; set;}
	 public int itemID{ get; set;}
}
