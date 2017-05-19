using System.Collections.Generic; 
 public class TowerResetTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TowerResetTableObject> TowerResetTable{ get; set;}
}
public class TowerResetTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int cost{ get; set;}
	 public int vipLv{ get; set;}
}
