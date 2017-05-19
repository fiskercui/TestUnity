using System.Collections.Generic; 
 public class FuncOpenLevelTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<FuncOpenLevelTableObject> FuncOpenLevelTable{ get; set;}
}
public class FuncOpenLevelTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int function_id{ get; set;}
	 public int level{ get; set;}
	 public int vip{ get; set;}
	 public string icon{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
	 public string desc_1{ get; set;}
	 public int guide_id{ get; set;}
}
