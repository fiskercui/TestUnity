using System.Collections.Generic; 
 public class RandNameTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RandNameTableObject> RandNameTable{ get; set;}
}
public class RandNameTableObject{
	 public AttributeInfo @attributes;
	 public int nameID{ get; set;}
	 public string title{ get; set;}
	 public string firstName{ get; set;}
	 public string mLastName{ get; set;}
	 public string wLastName{ get; set;}
}
