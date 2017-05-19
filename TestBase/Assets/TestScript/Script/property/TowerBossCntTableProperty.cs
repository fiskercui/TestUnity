using System.Collections.Generic; 
 public class TowerBossCntTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TowerBossCntTableObject> TowerBossCntTable{ get; set;}
}
public class TowerBossCntTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int cost{ get; set;}
	 public int vipLv{ get; set;}
}
