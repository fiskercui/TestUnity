using System.Collections.Generic; 
 public class TowerRaidTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TowerRaidTableObject> TowerRaidTable{ get; set;}
}
public class TowerRaidTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int image_id{ get; set;}
	 public string name{ get; set;}
	 public int monsterStar1{ get; set;}
	 public int monsterStar2{ get; set;}
	 public int monsterStar3{ get; set;}
	 public int dropIdStar1{ get; set;}
	 public int dropIdStar2{ get; set;}
	 public int dropIdStar3{ get; set;}
	 public int victoryType{ get; set;}
	 public int fcStar1{ get; set;}
	 public int fcStar2{ get; set;}
	 public int fcStar3{ get; set;}
	 public string victoryDesc{ get; set;}
	 public string dialogue{ get; set;}
	 public string winTips{ get; set;}
	 public string loseTips{ get; set;}
	 public int level{ get; set;}
}
