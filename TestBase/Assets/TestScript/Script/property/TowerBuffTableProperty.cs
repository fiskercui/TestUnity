using System.Collections.Generic; 
 public class TowerBuffTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TowerBuffTableObject> TowerBuffTable{ get; set;}
}
public class TowerBuffTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int star{ get; set;}
	 public int skillId{ get; set;}
	 public string icon{ get; set;}
}
