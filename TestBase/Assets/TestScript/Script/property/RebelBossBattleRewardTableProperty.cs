using System.Collections.Generic; 
 public class RebelBossBattleRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelBossBattleRewardTableObject> RebelBossBattleRewardTable{ get; set;}
}
public class RebelBossBattleRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int quality{ get; set;}
	 public int rewards_num{ get; set;}
	 public int prob{ get; set;}
}
