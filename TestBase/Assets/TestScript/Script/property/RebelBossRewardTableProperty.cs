using System.Collections.Generic; 
 public class RebelBossRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelBossRewardTableObject> RebelBossRewardTable{ get; set;}
}
public class RebelBossRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int boss_exploit_type{ get; set;}
	 public int boss_exploit{ get; set;}
	 public int rewards_type{ get; set;}
	 public int rewards_value{ get; set;}
	 public int rewards_num{ get; set;}
}
