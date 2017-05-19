using System.Collections.Generic; 
 public class ArenaRankRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ArenaRankRewardTableObject> ArenaRankRewardTable{ get; set;}
}
public class ArenaRankRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int minRank{ get; set;}
	 public int maxRank{ get; set;}
	 public int itemType1{ get; set;}
	 public int itemId1{ get; set;}
	 public int itemNum1{ get; set;}
	 public int itemType2{ get; set;}
	 public int itemId2{ get; set;}
	 public int itemNum2{ get; set;}
	 public int itemType3{ get; set;}
	 public int itemId3{ get; set;}
	 public int itemNum3{ get; set;}
}
