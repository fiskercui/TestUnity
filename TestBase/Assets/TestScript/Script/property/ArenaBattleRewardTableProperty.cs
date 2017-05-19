using System.Collections.Generic; 
 public class ArenaBattleRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ArenaBattleRewardTableObject> ArenaBattleRewardTable{ get; set;}
}
public class ArenaBattleRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int victoryVal{ get; set;}
	 public int failVal{ get; set;}
	 public int dropId{ get; set;}
}
