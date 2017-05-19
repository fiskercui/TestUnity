using System.Collections.Generic; 
 public class RebelBossCorpsRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelBossCorpsRewardTableObject> RebelBossCorpsRewardTable{ get; set;}
}
public class RebelBossCorpsRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int rank{ get; set;}
	 public string desc{ get; set;}
	 public int drop_id{ get; set;}
}
