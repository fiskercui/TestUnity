using System.Collections.Generic; 
 public class TowerFloorTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TowerFloorTableObject> TowerFloorTable{ get; set;}
}
public class TowerFloorTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string raidlist{ get; set;}
	 public int rewardStar3{ get; set;}
	 public int rewardStar6{ get; set;}
	 public int rewardStar9{ get; set;}
}
