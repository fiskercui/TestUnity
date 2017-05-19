using System.Collections.Generic; 
 public class RebelRankRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelRankRewardTableObject> RebelRankRewardTable{ get; set;}
}
public class RebelRankRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int rank_type{ get; set;}
	 public int max_rank{ get; set;}
	 public int min_rank{ get; set;}
	 public int rewards_type{ get; set;}
	 public int rewards_value{ get; set;}
	 public int rewards_num{ get; set;}
}
