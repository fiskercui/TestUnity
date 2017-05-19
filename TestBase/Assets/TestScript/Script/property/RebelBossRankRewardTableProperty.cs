using System.Collections.Generic; 
 public class RebelBossRankRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelBossRankRewardTableObject> RebelBossRankRewardTable{ get; set;}
}
public class RebelBossRankRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int min_rank{ get; set;}
	 public int max_rank{ get; set;}
	 public int type1{ get; set;}
	 public int id1{ get; set;}
	 public int num1{ get; set;}
	 public int type2{ get; set;}
	 public int id2{ get; set;}
	 public int num2{ get; set;}
}
