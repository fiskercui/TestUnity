using System.Collections.Generic; 
 public class TowerBossTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TowerBossTableObject> TowerBossTable{ get; set;}
}
public class TowerBossTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int bossid{ get; set;}
	 public string name{ get; set;}
	 public int prevRaidId{ get; set;}
	 public int prevBossId{ get; set;}
	 public int monsterGroupId{ get; set;}
	 public int firstDropId{ get; set;}
	 public int rewardDropId{ get; set;}
	 public int imageId{ get; set;}
	 public string iconId{ get; set;}
}
