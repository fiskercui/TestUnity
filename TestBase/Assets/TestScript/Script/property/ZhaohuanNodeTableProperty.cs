using System.Collections.Generic; 
 public class ZhaohuanNodeTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ZhaohuanNodeTableObject> ZhaohuanNodeTable{ get; set;}
}
public class ZhaohuanNodeTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int dropCount{ get; set;}
	 public string dropPackage{ get; set;}
	 public string desc{ get; set;}
	 public int special{ get; set;}
}
