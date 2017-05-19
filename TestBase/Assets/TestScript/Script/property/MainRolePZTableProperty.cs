using System.Collections.Generic; 
 public class MainRolePZTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<MainRolePZTableObject> MainRolePZTable{ get; set;}
}
public class MainRolePZTableObject{
	 public AttributeInfo @attributes;
	 public int roleidold{ get; set;}
	 public int tiaojian{ get; set;}
	 public int tiaojianvalue{ get; set;}
	 public int roleidnew{ get; set;}
	 public int isupdatable{ get; set;}
}
